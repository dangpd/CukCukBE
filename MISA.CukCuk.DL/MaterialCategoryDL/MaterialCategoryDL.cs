using Dapper;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.ProceduceName;
using MISA.CukCuk.DL.BaseDL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.MaterialCategoryDL
{
    public class MaterialCategoryDL : BaseDL<MaterialCategory>,IMaterialCategoryDL
    {
        public int CheckDuplicateCode(Guid? recordId, string? recordCode)
        {
            // Khởi tạo lấy kết nối đường dẫn database
            string connectionString = DatabaseContext.ConnectionString;

            // Chuẩn bị tên stored procedure
            var storedProcedureName = string.Format(ProceduceName.DuplicateCode, typeof(MaterialCategory).Name);

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"p_CategoryId", recordId);
            parameters.Add($"p_CategoryCode", recordCode);

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
