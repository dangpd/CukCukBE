using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Resource;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Error
{
    public class HandleError
    {
        public static ErrorResult? GenerateExceptionResult(Exception exception)
        {
            return new ErrorResult(
                Enums.ErrorCode.Exception,
                exception.Message,
                exception.Message,
                "https://openapi.misa.com.vn/errorcode/e002",
                "");
        }
        public static ErrorResult? GenerateDuplicateCodeErrorResult<T>(MySqlException mySqlException)
        {
            if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
            {
                var tableName = EntityUtilities.GetTableName<T>();
                var errorCode = Common.Resource.Error.NoDefine;

                // Trùng mã nguyên vật liệu
                if (tableName == TableName.Material)
                {
                    errorCode = Common.Resource.Error.DuplicateMaterial;
                }
                else if (tableName == TableName.MaterialCategory)
                {
                    errorCode = Common.Resource.Error.DuplicateMaterialCategory;
                }
                // Trùng mã kho ngầm định
                else if (tableName == TableName.Stock)
                {
                    errorCode = Common.Resource.Error.DuplicateStock;
                }
                // Trùng tên đơn vị tính
                else if (tableName == TableName.Unit)
                {
                    errorCode = Common.Resource.Error.DuplicateUnit;
                }
                // Trùng tên đơn vị chuyển đổi
                else if (tableName == TableName.ConversionUnit)
                {
                    errorCode = Common.Resource.Error.DuplicateConversionUnit;
                }


                return new ErrorResult(
                    Enums.ErrorCode.InvalidData,
                    Common.Resource.Resource.DuplicateCode,
                    Common.Resource.Resource.DuplicateCode,
                    errorCode,
                    "");
            }

            return new ErrorResult(
                Enums.ErrorCode.InvalidData,
                Common.Resource.Error.AnUnknownError,
                Common.Resource.Error.AnUnknownError,
                "https://openapi.misa.com.vn/errorcode/e002",
                "");
        }
    }
}
