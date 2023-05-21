using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Error;
using MISA.CukCuk.Common.Resource;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.MaterialDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.MaterialBL
{
    public class MaterialBL : BaseBL<Material>, IMaterialBL
    {
        #region Field

        private IMaterialDL _materialDL;

        #endregion

        #region Constructor

        public MaterialBL(IMaterialDL materialDL) : base(materialDL)
        {
            materialDL = new MaterialDL();
            _materialDL = materialDL;
        }

        #endregion

        #region Method
        public InforMaterial GetMaterialByID(Guid materialId)
        {
            return _materialDL.GetMaterialByID(materialId); // bản ghi cần lấy 
        }

        public int InsertMaterial(InforMaterial inforMaterial)
        {
            var validateMaterial = ValidateData(inforMaterial.Material); // validate nguyên vật liệu
            var baseConversionUnit = new BaseBL<ConversionUnit>(new BaseDL<ConversionUnit>());
            // Validate nguyên vật liệu
            if (validateMaterial != null)
            {
                throw new MISAException(
                    new ErrorResult(
                            Common.Enums.ErrorCode.InvalidData,
                            Resource.DevMsg_InvalidData,
                            Resource.UserMsg_InvalidData,
                            validateMaterial,
                            ""
                        )
                    );
            }
            // Validate danh sách đơn vị chuyển đổi
            foreach (var item in inforMaterial.ListConversionUnits)
            {
                var validateConversionUnit = baseConversionUnit.ValidateData(item); // validate đơn vị chuyển đổi
                // thất bại return lỗi
                if (validateConversionUnit != null)
                {
                    throw new MISAException(
                        new ErrorResult(
                                Common.Enums.ErrorCode.InvalidData,
                                Resource.DevMsg_InvalidData,
                                Resource.UserMsg_InvalidData,
                                validateMaterial,
                                ""
                            )
                        );
                }
            }

            return _materialDL.InsertMaterial(inforMaterial);
        }

        public int UpdateMaterial(Guid materialId, InforMaterial updateMaterial)
        {
            var validateMaterial = ValidateData(updateMaterial.Material); // validate nguyên vật liệu
            var baseConversionUnit = new BaseBL<ConversionUnit>(new BaseDL<ConversionUnit>());
            // Validate nguyên vật liệu
            if (validateMaterial != null)
            {
                throw new MISAException(
                    new ErrorResult(
                            Common.Enums.ErrorCode.InvalidData,
                            Resource.DevMsg_InvalidData,
                            Resource.UserMsg_InvalidData,
                            validateMaterial,
                            ""
                        )
                    );
            }

            // Validate danh sách đơn vị chuyển đổi
            foreach (var item in updateMaterial.ListConversionUnits)
            {
                var validateConversionUnit = baseConversionUnit.ValidateData(item); // validate đơn vị chuyển đổi
                // thất bại return lỗi
                if (validateConversionUnit != null)
                {
                    throw new MISAException(
                        new ErrorResult(
                                Common.Enums.ErrorCode.InvalidData,
                                Resource.DevMsg_InvalidData,
                                Resource.UserMsg_InvalidData,
                                validateMaterial,
                                ""
                            )
                        );
                }
            }

            return _materialDL.UpdateMaterial(materialId, updateMaterial);
        }

        #endregion
    }
}
