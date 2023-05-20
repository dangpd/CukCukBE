using MISA.CukCuk.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities
{
    public class Unit
    {
        /// <summary>
        /// ID đơn vị chuyển đổi
        /// </summary>
        [Key]
        public Guid? ConversionUnitId { get; set; }

        /// <summary>
        /// Tên đơn vị chuyển đổi
        /// </summary>
        [UnitNameNotEmpty]
        public string? ConversionUnitName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public Enums.StatusFollow? Status { get; set; } 

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
