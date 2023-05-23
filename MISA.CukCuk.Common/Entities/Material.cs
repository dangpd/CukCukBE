using MISA.CukCuk.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities
{
    [Table("material")]
    public class Material
    {
        /// <summary>
        /// Id nguyên vật liệu
        /// </summary>
        [Key]
        public Guid? MaterialId { get; set; }

        /// <summary>
        /// Mã nguyên vật liệu
        /// </summary>
        [MaterialCodeNotEmpty]
        public string? MaterialCode { get; set; }

        /// <summary>
        /// Tên nguyên vật liệu
        /// </summary>
        [MaterialNameNotEmpty]
        public string? MaterialName { get; set; }

        /// <summary>
        /// Tính chất
        /// </summary>
        [FeatureNotEmpty]
        public string? Feature { get; set; }

        /// <summary>
        /// Id nhóm nguyên vật liệu
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Tên nhóm nguyên vật liệu
        /// </summary>
        public string? CategoryName { get; set; }

        /// <summary>
        /// Mã đơn vị tính
        /// </summary>
        [ConversionUnitIdNotEmpty]
        public Guid? ConversionUnitId { get; set; }

        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        public string? ConversionUnitName { get; set; }

        /// <summary>
        /// ID kho ngầm định
        /// </summary>
        public Guid? StockId { get; set; }

        /// <summary>
        /// Tên kho nhầm định
        /// </summary>
        public string? StockName { get; set; }

        /// <summary>
        /// Hạn sử dụng
        /// </summary>
        public string? ExpiryDate { get; set; }


        /// <summary>
        /// Số lượng tồn tối thiểu
        /// </summary>
        public double? InventoryNumber { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Trạng thái theo dõi
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
