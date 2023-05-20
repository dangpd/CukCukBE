using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities.DTO
{
    public class QueryCondition
    {
        /// <summary>
        /// Chứa
        /// </summary>
        public static string LIKE = "LIKE";

        /// <summary>
        /// Bằng
        /// </summary>
        public static string EQUAL = "=";

        /// <summary>
        /// Bắt đầu bằng
        /// </summary>
        public static string START_WIDTH = "STARTWIDTH";

        /// <summary>
        /// Kết thúc bằng
        /// </summary>
        public static string END_WIDTH = "ENDWIDTH";

        /// <summary>
        /// Không chứa
        /// </summary>
        public static string NOTLIKE = "NOTLIKE";

        /// <summary>
        /// Lớn hơn
        /// </summary>
        public static string GREATER = ">";

        /// <summary>
        /// Lớn hơn bằng
        /// </summary>
        public static string GREATER_OR_EQUAL = ">=";

        /// <summary>
        /// Lớn hơn
        /// </summary>
        public static string LESS = "<";

        /// <summary>
        /// Lớn hơn bằng
        /// </summary>
        public static string LESS_OR_EQUAL = "<=";

        public static string GetQueryStringWhere(List<FilterPaging> listFilterPaging)
        {
            string stringWhere = "";
            string operate = null;
            string value = "";

            var fields = typeof(QueryCondition).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var filterPaging in listFilterPaging)
            {
                operate = filterPaging.Operate;
                value = filterPaging.Value;


                if (filterPaging.Operate == LIKE) { value = $"%{value}%"; } //Chứa
                else if (filterPaging.Operate == START_WIDTH) { operate = "LIKE"; value = $"{value}%"; } // Bắt đầu bằng
                else if (filterPaging.Operate == END_WIDTH) { operate = "LIKE"; value = $"%{value}"; } // Kết thúc bằng
                else if (filterPaging.Operate == NOTLIKE) { operate = "NOT LIKE"; value = $"%{value}%"; } // Không chứa

                value = string.IsNullOrEmpty(value) ? "" : $"\"{value}\"";

                stringWhere += $" {filterPaging.Addition} {filterPaging.Field} {operate} {value}";

            }


            return stringWhere;
        }
    }
}
