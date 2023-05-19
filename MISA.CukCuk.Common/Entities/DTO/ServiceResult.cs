using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities.DTO
{
    public class ServiceResult
    {
        /// <summary>
        /// Trạng thái kết quả
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorResult? Data { get; set; }
    }
}
