using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities.DTO
{
    public class FilterPaging
    {
        /// <summary>
        /// Trường cần lọc
        /// </summary>
        public string? Field { get; set; }

        /// <summary>
        /// Phép cần lọc ( LIKE, NOTLIKE, =  )
        /// </summary>
        public string? Operate { get; set; }

        /// <summary>
        /// Nối chuỗi query ( AND, OR )
        /// </summary>
        public string? Addition { get; set; }

        /// <summary>
        /// Từ cần lọc
        /// </summary>
        public string? Value { get; set; }
    }
}
