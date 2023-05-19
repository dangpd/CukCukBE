using Dapper;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.ProceduceName;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.BaseDL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Method

        // Khởi tạo lấy kết nối đường dẫn database
        string connectionString = DatabaseContext.ConnectionString;

        public List<T> GetAllRecord()
        {
            // Chuẩn bị tên store procedure
            string getAllStoreProcedureName = String.Format(ProceduceName.GetAllRecord, typeof(T).Name);
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                var allRecord = mySqlConnection.Query<T>(getAllStoreProcedureName, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return allRecord;
            }
        }

        public T GetRecordById(Guid idRecord)
        {
            // Chuẩn bị tên store procedure
            string getOneRecordstoreProcedureName = String.Format(ProceduceName.GetRecordById, typeof(T).Name);

            //Truyền tham số cho procedure
            var parameters = new DynamicParameters();

            // lấy tên primary key của table 
            var primaryKeyProperty = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);

            var propertyName = $"p_{primaryKeyProperty.Name}";
            parameters.Add(propertyName, idRecord);

            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Query
                return mySqlConnection.QueryFirstOrDefault<T>(getOneRecordstoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public int InsertOneRecord(T record)
        {
            // Chuẩn bị tên store procedure
            string insertStoreProcedureName = String.Format(ProceduceName.Insert, typeof(T).Name);
            // Chuẩn bị tham số cho procedure
            var parameters = new DynamicParameters();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = $"p_{property.Name}";
                var propertyValue = property.GetValue(record);
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
            // Gọi vào db và trả về số bản ghi bị ảnh hưởng
            int numberOfAffectedRows = 0;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                numberOfAffectedRows = mySqlConnection.Execute(insertStoreProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }

        public int UpdateOneRecord(T record, Guid idRecord)
        {
            // Chuẩn bị tên store procedure
            string updateStoredProcedureName = String.Format(ProceduceName.Update, typeof(T).Name);

            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();

            // Lấy key attribute
            foreach (var property in properties)
            {
                // Set key id cập nhật bằng id truyền vào
                var keyAttribute = (KeyAttribute?)property.GetCustomAttribute(typeof(KeyAttribute), false);
                if (keyAttribute != null)
                {
                    parameters.Add($"p_{property.Name}", idRecord);
                }
                var propertyName = $"p_{property.Name}"; // Tạo biến cho đầu vào cho store procedure
                var propertyValue = property.GetValue(record); // Lấy giá có thuộc tính propertyName của record
                parameters.Add(propertyName, propertyValue);
            }

            parameters.Add("p_ModifiedDate", DateTime.Now);
            parameters.Add("p_ModifiedBy", "DangPD");

            // Số bản ghi bị ảnh hưởng
            int numberOfAffectedRow = 0;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                // Số bản ghi bị tác động
                numberOfAffectedRow = mySqlConnection.Execute(updateStoredProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            return numberOfAffectedRow;
        }

        public int DeleteOneRecord(Guid idRecord)
        {
            // Chuẩn bị tên store procedure
            string deleteStoredProcedureName = String.Format(ProceduceName.Delete, typeof(T).Name);

            // lấy khóa chính của bảng
            var primaryKeyProperty = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
            var parameters = new DynamicParameters();

            var propertyName = $"p_{primaryKeyProperty.Name}";
            parameters.Add(propertyName, idRecord);
            // Số bản ghi bị ảnh hưởng
            int numberOfAffectedRow = 0;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }
                using (var transaction = mySqlConnection.BeginTransaction())
                {
                    try
                    {
                        // Số bản ghi bị tác động 
                        numberOfAffectedRow = mySqlConnection.Execute(deleteStoredProcedureName, parameters, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                        if (numberOfAffectedRow == 1)
                        {
                            transaction.Commit();
                        }
                        // thất bại thì rollback lại db
                        else
                        {
                            transaction.Rollback();
                            numberOfAffectedRow = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        //  Lỗi exception
                        // Rollback db
                        Console.WriteLine(ex.ToString());
                        transaction.Rollback();
                        numberOfAffectedRow = 0;
                    }
                    finally
                    {
                        // Đóng kết nối
                        mySqlConnection.Close();
                    }
                }
            }
            return numberOfAffectedRow;
        }

        public PagingData<T> GetPaging(long pageSize, long pageNumber, string? textSearch, string? sort)
        {
            // Chuẩn bị tên store procedure
            string filterStoredProcedureName = String.Format(ProceduceName.PagingAndFilter, typeof(T).Name);

            var parameter = new DynamicParameters();
            parameter.Add("$Offset", pageSize);
            parameter.Add("$Limit", pageNumber);
            parameter.Add("$Sort", sort);
            parameter.Add("$Where", textSearch);
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                var multiResults = mySqlConnection.QueryMultiple(filterStoredProcedureName, parameter, commandType: System.Data.CommandType.StoredProcedure);
                var dataRecord = multiResults.Read<T>().ToList();
                var totalCount = multiResults.Read<long>().Single();
                return new PagingData<T>
                {
                    TotalCount = totalCount,
                    TotalPage = (totalCount % pageSize) > 0 ? ((totalCount / pageSize) + 1) : (totalCount / pageSize),
                    Data = dataRecord,
                };
            }
        }

        #endregion

    }
}
