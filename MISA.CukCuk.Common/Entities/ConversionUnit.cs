﻿using MISA.CukCuk.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities
{
    public class ConversionUnit
    {
        /// <summary>
        /// ID đơn vị chuyển đổi
        /// </summary>
        [MaterialIdNotEmpty]
        public Guid MaterialId { get; set; }

        /// <summary>
        /// Id nguyên vật liệu
        /// </summary>
        [ConversionUnitIdNotEmpty]
        public Guid ConversionUnitId { get; set; }

        /// <summary>
        /// Tỷ lệ chuyển đổi
        /// </summary>
        public double ConversionRate { get; set; }

        /// <summary>
        /// Phép tính
        /// </summary>
        public Enums.Calculate Calculation { get; set; }

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

        /// <summary>
        /// Loại sửa đổi
        /// </summary>
        public Enums.Type? Type { get; set; }

        /// <summary>
        /// Id cũ của đơn vị chuyển đổi khi sửa
        /// </summary>  
        public Guid? ConversionUnitIDOld { get; set; }
    }
}