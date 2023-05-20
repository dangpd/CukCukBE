using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.MaterialBL
{
    public interface IMaterialBL : IBaseBL<Material>
    {
        /// <summary>
        /// Thêm mới nguyên vật liệu
        /// </summary>
        /// <param name="material"></param>
        /// <param name="listConversionUnit"></param>
        /// <returns></returns>
        public ServiceResult InsertMaterial(InforMaterial inforMaterial);

        /// <summary>
        /// Cập nhập nguyên vật liệu
        /// </summary>
        /// <param name="inforMaterial"></param>
        /// <returns></returns>
        public ServiceResult UpdateMaterial(Guid materialId, InforMaterial updateMaterial);

        /// <summary>
        /// Lấy nguyên liệu theo id
        /// </summary>
        /// <param name="materialID"></param>
        /// <returns></returns>
        public InforMaterial GetMaterialByID(Guid materialId);
    }
}
