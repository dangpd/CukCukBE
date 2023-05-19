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
    public class MaterialCategory
    {
        /// <summary>
        /// ID nhóm nguyên vật liệu
        /// </summary>
        [Key]
        public Guid? CategoryID { get; set; }

        /// <summary>
        /// Mã nhóm nguyên vật liệu
        /// </summary>
        [CategoryCodeNotEmpty]
        public string? CategoryCode { get; set; }

        /// <summary>
        /// Tên nhóm nguyên vật liệu
        /// </summary>
        [CategoryNameNotEmpty]
        public string? CategoryName { get; set; }

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
