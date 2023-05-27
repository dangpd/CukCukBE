using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Entities.DTO
{
    public class InforMaterial
    {
        /// <summary>
        /// Nguyên vật liệu
        /// </summary>
        public Material? Material { get; set; }

        /// <summary>
        /// Danh sách đơn vị chuyển đổi
        /// </summary>
        public List<ConversionUnit>? ListConversionUnits { get; set; } = new List<ConversionUnit>();
    }
}
