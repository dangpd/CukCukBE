using Dapper;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.ProceduceName;
using MISA.CukCuk.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
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

                    if (inforMaterial.ListConversionUnits != null)
                    {
                        foreach (var conversionUnit in inforMaterial.ListConversionUnits)
                        {
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
            string deleteStoredProcedureName = String.Format(ProceduceName.Delete, typeof(ConversionUnit).Name);
            string updateStoredProcedureName = String.Format(ProceduceName.Update, typeof(ConversionUnit).Name);
            string addStoredProcedureName = String.Format(ProceduceName.Update, typeof(ConversionUnit).Name);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                mySqlConnection.Open();

                totalSuccess += UpdateOneRecord(updateMaterial.Material, materialId);


                foreach (var conversionUnit in updateMaterial.ListConversionUnits)
                {

                    var properties = typeof(ConversionUnit).GetProperties();
                    var parameters = new DynamicParameters();

                    foreach (var property in properties)
                    {
                        var propertyName = $"v_{property.Name}"; // Tạo biến cho đầu vào cho store procedure
                        var propertyValue = property.GetValue(conversionUnit); // Lấy giá có thuộc tính propertyName của record
                        parameters.Add(propertyName, propertyValue);
                    }

                    // Xóa đơn vị chuyển đổi
                    if (conversionUnit.Type == Common.Enums.Type.Delete)
                    {
                        totalSuccess += mySqlConnection.Execute(deleteStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    // Sửa đơn vị chuyển đổi
                    else if (conversionUnit.Type == Common.Enums.Type.Update)
                    {
                        totalSuccess += mySqlConnection.Query(updateStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList()[0].Count;
                    }
                    // Thêm mới đơn vị chuyển đổi
                    else if (conversionUnit.Type == Common.Enums.Type.Add)
                    {
                        totalSuccess += baseDLConversionUnit.InsertOneRecord(conversionUnit);
                    }
                }

                return totalSuccess;
            }
        }
        public virtual int CheckDuplicateCode(Guid? recordId, string? recordCode)
        {

            // Chuẩn bị tên stored procedure
            var storedProcedureName = string.Format(ProceduceName.DuplicateCode, typeof(Material).Name);

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"p_MaterialId", recordId);
            parameters.Add($"p_MaterialCode", recordCode);

            int DuplicateCode;

            // Khởi tạo kết nối đến DB
            using (var mySqlConnecttion = new MySqlConnection(connectionString))
            {
                DuplicateCode = mySqlConnecttion.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return DuplicateCode;
        }
    }
}
