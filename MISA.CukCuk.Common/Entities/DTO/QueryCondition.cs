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
        public const string LIKE = "LIKE";

        /// <summary>
        /// Bằng
        /// </summary>
        public const string EQUAL = "=";

        /// <summary>
        /// Bắt đầu bằng
        /// </summary>
        public const string START_WIDTH = "STARTWIDTH";

        /// <summary>
        /// Kết thúc bằng
        /// </summary>
        public const string END_WIDTH = "ENDWIDTH";

        /// <summary>
        /// Không chứa
        /// </summary>
        public const string NOTLIKE = "NOTLIKE";

        /// <summary>
        /// Lớn hơn
        /// </summary>
        public const string GREATER = ">";

        /// <summary>
        /// Lớn hơn bằng
        /// </summary>
        public const string GREATER_OR_EQUAL = ">=";

        /// <summary>
        /// Lớn hơn
        /// </summary>
        public const string LESS = "<";

        /// <summary>
        /// Lớn hơn bằng
        /// </summary>
        public const string LESS_OR_EQUAL = "<=";

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public const string ModifiedDate = "ModifiedDate DESC";
    }
}
