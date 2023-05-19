using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities.DTO
{
    public class PagingData<T>
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public long TotalCount { get; set; } = 0;

        /// <summary>
        /// Tổng số lượng bản ghi
        /// </summary>
        public long TotalPage { get; set; }

        /// <summary>
        /// Danh sách các dữ liệu trả về 
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();
    }
}
