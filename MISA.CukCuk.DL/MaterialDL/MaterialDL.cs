using Dapper;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.ProceduceName;
using MISA.CukCuk.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MISA.CukCuk.DL.MaterialDL
{
    public class MaterialDL : BaseDL<Material>, IMaterialDL
    {
        // Khởi tạo lấy kết nối đường dẫn database
        string connectionString = DatabaseContext.ConnectionString;
        public InforMaterial GetMaterialByID(Guid materialId)
        {
            // Chuẩn bị tên store procedure
            string getOneRecordstoreProcedureName = String.Format(ProceduceName.GetRecordById, typeof(Material).Name);

            //Truyền tham số cho procedure
            var parameters = new DynamicParameters();
            parameters.Add("p_MaterialId", materialId);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                var multiResults = mySqlConnection.QueryMultiple(getOneRecordstoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var materials = multiResults.Read<Material>().ToList();
                if (materials.Count > 0)
                {
                    var listConversionUnit = multiResults.Read<ConversionUnit>().ToList();
                    return new InforMaterial
                    {
                        Material = materials[0],
                        ListConversionUnits = listConversionUnit
                    };
                }
                return null;
            }
        }

        public int InsertMaterial(InforMaterial inforMaterial)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (var mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();
                    int totalSuccess = 0;
                    var baseDLConversionUnit = new BaseDL<ConversionUnit>();
                    totalSuccess += InsertOneRecord(inforMaterial.Material);
                    Material materialByCode = getByCode(inforMaterial.Material.MaterialCode);
                    if (inforMaterial.ListConversionUnits != null)
                    {
                        foreach (var conversionUnit in inforMaterial.ListConversionUnits)
                        {
                            conversionUnit.MaterialId = (Guid)materialByCode.MaterialId;
                            totalSuccess += baseDLConversionUnit.InsertOneRecord(conversionUnit);
                        }
                    }
                    scope.Complete();
                    return totalSuccess;

                }
            }
        }

        public int UpdateMaterial(Guid materialId, InforMaterial updateMaterial)
        {
            int totalSuccess = 0;
            var baseDLConversionUnit = new BaseDL<ConversionUnit>();
            string updateConvertionUnit = String.Format(ProceduceName.Update, typeof(ConversionUnit).Name);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();

                totalSuccess += UpdateOneRecord(updateMaterial.Material, materialId);
                // lấy ra danh sách chuyển đổi ở database
                List<string> listID = new List<string>();
                List<ConversionUnit> listConvertion = getConversionUnits((Guid)updateMaterial.Material.MaterialId);

                if (updateMaterial.ListConversionUnits.Count > 0 && listConvertion.Count > 0)
                {
                    foreach (var item in updateMaterial.ListConversionUnits)
                    {
                        listID.Add(item.ConversionUnitId.ToString());
                    }
                    // Lấy ra các phần tử giống nhau ở database và phần tử gửi lên
                    var commonObject = updateMaterial.ListConversionUnits.Where(obj1 => listConvertion.Any(obj2 => obj2.ConversionUnitId == obj1.ConversionUnitId));
                    foreach (var item in commonObject)
                    {
                        var properties = typeof(ConversionUnit).GetProperties();
                        var parameters = new DynamicParameters();

                        foreach (var property in properties)
                        {
                            // Set key id cập nhật bằng id truyền vào
                            var keyAttribute = (KeyAttribute?)property.GetCustomAttribute(typeof(KeyAttribute), false);
                            if (keyAttribute != null)
                            {
                                parameters.Add($"p_{property.Name}", item.ConversionUnitId);
                            }
                            var propertyName = $"p_{property.Name}"; // Tạo biến cho đầu vào cho store procedure
                            var propertyValue = property.GetValue(item); // Lấy giá có thuộc tính propertyName của record
                            parameters.Add(propertyName, propertyValue);

                        }
                        parameters.Add("p_ModifiedDate", DateTime.Now);
                        parameters.Add("p_ModifiedBy", "DangPD");
                        totalSuccess += mySqlConnection.Execute(updateConvertionUnit, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }

                // Trường cần so sánh
                string compareField = "ConversionUnitId";

                List<string> listIdDelete = new List<string>();
                if (updateMaterial.ListConversionUnits.Count > 0 && listConvertion.Count > 0)
                {
                    // Lấy ra các phần tử khác nhau ở database và phần tử gửi lên
                    var diffrentObjectDatabase = listConvertion
                        .Select(obj1 => obj1.GetType().GetProperty(compareField).GetValue(obj1))
                        .Except(updateMaterial.ListConversionUnits.Select(obj2 => obj2.GetType().GetProperty(compareField).GetValue(obj2)))
                        .Select(id => listConvertion.First(obj1 => obj1.GetType().GetProperty(compareField).GetValue(obj1).Equals(id)));

                    // Khai báo danh sách Id cần xóa
                    listIdDelete = diffrentObjectDatabase.Select(obj => obj.GetType().GetProperty(compareField).GetValue(obj)?.ToString()).ToList();
                }
                else
                {
                    listIdDelete = listConvertion.Select(obj => obj.GetType().GetProperty(compareField).GetValue(obj)?.ToString()).ToList();
                }
                string deleteInfo = "";

                if (listIdDelete.Count > 0)
                {
                    deleteInfo = "( ";
                    for (int i = 0; i < listIdDelete.Count; i++)
                    {
                        deleteInfo += $" '{listIdDelete[i]}' ";
                        if (i != listIdDelete.Count - 1)
                            deleteInfo += " , ";
                    }
                    deleteInfo += " )";
                }

                // xóa nhiều database
                if(deleteInfo.Length > 0)
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        string deleteMultipleConvertionUnit = ProceduceName.deleteMultipleConvertionUnit;
                        var parametersDelete = new DynamicParameters();
                        parametersDelete.Add("p_MulitipleID", deleteInfo);
                        totalSuccess += mySqlConnection.Execute(deleteMultipleConvertionUnit, parametersDelete, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }


                string insertConvertionUnit = String.Format(ProceduceName.Insert, typeof(ConversionUnit).Name);
                if (updateMaterial.ListConversionUnits.Count > 0)
                {
                    // Lấy ra các phần tử khác nhau của phần tử gửi lên và database
                    var diffrentObjectUpdate = updateMaterial.ListConversionUnits
                        .Where(obj1 => !listConvertion.Any(obj2 => obj2.GetType().GetProperty(compareField).GetValue(obj2)?.ToString() == obj1.GetType().GetProperty(compareField).GetValue(obj1)?.ToString()))
                        .ToList();

                    // Thêm database
                    foreach (var item in diffrentObjectUpdate)
                    {
                        var properties = typeof(ConversionUnit).GetProperties();
                        var parameters = new DynamicParameters();

                        foreach (var property in properties)
                        {
                            var propertyName = $"p_{property.Name}"; // Tạo biến cho đầu vào cho store procedure
                            var propertyValue = property.GetValue(item); // Lấy giá có thuộc tính propertyName của record
                            parameters.Add(propertyName, propertyValue);
                            // Key attribute thì thực hiện set id là guid mới
                            var primaryKeyAttribute = (KeyAttribute?)Attribute.GetCustomAttribute(property, typeof(KeyAttribute));
                            if (primaryKeyAttribute != null)
                            {
                                parameters.Add($"p_{property.Name}", Guid.NewGuid());
                            }
                        }
                        parameters.Add("p_CreatedDate", DateTime.Now);
                        parameters.Add("p_CreatedBy", "DangPD");
                        parameters.Add("p_ModifiedDate", DateTime.Now);
                        parameters.Add("p_ModifiedBy", "DangPD");
                        totalSuccess += mySqlConnection.Execute(insertConvertionUnit, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
                    
                return totalSuccess;
            }
        }

        public Material getByCode(string code)
        {
            // Chuẩn bị tên store procedure
            string getOneRecordstoreProcedureName = ProceduceName.GetByCode;

            //Truyền tham số cho procedure
            var parameters = new DynamicParameters();

            // lấy tên primary key của table 

            var propertyName = $"p_MaterialCode";
            parameters.Add(propertyName, code);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                return mySqlConnection.QueryFirstOrDefault<Material>(getOneRecordstoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<ConversionUnit> getConversionUnits(Guid id)
        {
            // Chuẩn bị tên store procedure
            string getOneRecordstoreProcedureName = ProceduceName.getListConvertionUnit;

            //Truyền tham số cho procedure
            var parameters = new DynamicParameters();

            // lấy tên primary key của table 

            var propertyName = $"p_MaterialID";
            parameters.Add(propertyName, id);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                return mySqlConnection.Query<ConversionUnit>(getOneRecordstoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }
    }
}
