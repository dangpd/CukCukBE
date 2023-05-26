using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.MaterialDL
{
    public interface IMaterialDL : IBaseDL<Material>
    {
        /// <summary>
        /// Thêm mới nguyên vật liệu
        /// </summary>
        /// <param name="material"></param>
        /// <param name="listConversionUnit"></param>
        /// <returns></returns>
        public int InsertMaterial(InforMaterial inforMaterial);

        /// <summary>
        /// Cập nhập nguyên vật liệu
        /// </summary>
        /// <param name="inforMaterial"></param>
        /// <returns></returns>
        public int UpdateMaterial(Guid materialId, InforMaterial updateMaterial);

        /// <summary>
        /// Lấy thông tin 1 nguyên vật liệu
        /// </summary>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public InforMaterial GetMaterialByID(Guid materialId);

        /// <summary>
        /// Xóa 1 bản ghi <typeparamref name="T"/>
        /// </summary>
        /// <param name="idRecord"> id bản ghi cần xóa </param>
        /// <returns> Số bản ghi bị tác động </returns>
        public int DeleteOneRecord(Guid idRecord);

        public Material getByCode(string code);


        public List<ConversionUnit> getConversionUnits(Guid id);
    }
}
