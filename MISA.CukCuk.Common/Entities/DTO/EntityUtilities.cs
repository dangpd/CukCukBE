using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities.DTO
{
    public class EntityUtilities
    {
        public static string GetTableName<T>()
        {
            string tableName = typeof(T).Name; // Lấy tên class
            var customAttributes = typeof(T).GetTypeInfo().GetCustomAttributes<TableAttribute>();
            if (customAttributes.Count() > 0)
            {
                tableName = customAttributes.First().Name; // Tên bảng
            }
            return tableName;
        }
    }
}
