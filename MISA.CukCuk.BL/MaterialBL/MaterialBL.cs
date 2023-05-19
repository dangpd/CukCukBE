using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
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

        public ServiceResult InsertMaterial(InforMaterial inforMaterial)
        {
            var validateMaterial = ValidateData(inforMaterial.Material); // validate nguyên vật liệu
            var baseConversionUnit = new BaseBL<ConversionUnit>(new BaseDL<ConversionUnit>());
            // Validate nguyên vật liệu
            if (validateMaterial != null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = validateMaterial.Data,
                };
            }
            // Validate danh sách đơn vị chuyển đổi
            foreach (var item in inforMaterial.ListConversionUnits)
            {
                var validateConversionUnit = baseConversionUnit.ValidateData(item); // validate đơn vị chuyển đổi
                // thất bại return lỗi
                if (validateConversionUnit != null)
                {
                    return new ServiceResult
                    {
                        IsSuccess = false,
                        Data = validateConversionUnit.Data,
                    };
                }
            }
            //var checkCode = CheckDuplicateCode(null, inforMaterial.Material);
            //// thất bại return lỗi
            //if (checkCode != null)
            //{
            //    return new ServiceResult
            //    {
            //        IsSuccess = false,
            //        Data = checkCode.Data
            //    };
            //}
            var numberOfAffectedRows = _materialDL.InsertMaterial(inforMaterial);
            // Xử lí kết quả thành công
            if (numberOfAffectedRows > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                };
            }
            else
            {
                // Thất bại return lỗi server
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InsertFail,
                        DevMsg = Common.Resource.DataResource.DevMsg_InsertFailed,
                        UserMsg = Common.Resource.DataResource.UserMsg_InsertFailed,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_InsertFailed
                    }
                };
            }
        }

        public ServiceResult UpdateMaterial(Guid materialId, InforMaterial updateMaterial)
        {
            var validateMaterial = ValidateData(updateMaterial.Material); // validate nguyên vật liệu
            var baseConversionUnit = new BaseBL<ConversionUnit>(new BaseDL<ConversionUnit>());
            // Validate nguyên vật liệu
            if (validateMaterial != null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = validateMaterial.Data,
                };
            }

            //var checkCode = CheckDuplicateCode(materialId, updateMaterial.Material);
            //// thất bại return lỗi
            //if (checkCode != null)
            //{
            //    return new ServiceResult
            //    {
            //        IsSuccess = false,
            //        Data = checkCode.Data
            //    };
            //}
            // Validate danh sách đơn vị chuyển đổi
            foreach (var item in updateMaterial.ListConversionUnits)
            {
                var validateConversionUnit = baseConversionUnit.ValidateData(item); // validate đơn vị chuyển đổi
                // thất bại return lỗi
                if (validateConversionUnit != null)
                {
                    return new ServiceResult
                    {
                        IsSuccess = false,
                        Data = validateConversionUnit.Data,
                    };
                }
            }

            var numberOfAffectedRows = _materialDL.UpdateMaterial(materialId, updateMaterial);
            // Xử lí kết quả thành công
            if (numberOfAffectedRows > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                };
            }
            else
            {
                // Thất bại return lỗi server
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InsertFail,
                        DevMsg = Common.Resource.DataResource.DevMsg_InsertFailed,
                        UserMsg = Common.Resource.DataResource.UserMsg_InsertFailed,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_InsertFailed
                    }
                };
            }
        }
        protected override ServiceResult ValidateCustom(Material? record)
        {

            int duplicateCode = _materialDL.CheckDuplicateCode(record.MaterialId, record.MaterialCode);

            if (duplicateCode == 0)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult()
                    {
                        ErrorCode = Common.Enums.ErrorCode.DuplicateCode,
                        DevMsg = Common.Resource.DataResource.UserMsg_DuplicateCode,
                        UserMsg = Common.Resource.DataResource.UserMsg_DuplicateCode,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_DuplicateCode
                    }
                };
            }

            return new ServiceResult { IsSuccess = true };
        }
        /// <summary>
        /// Kiểm tra mã trùng
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeID"></param>
        /// <returns>bool kiểm tra có trùng hay không</returns>
        //protected override ServiceResult CheckDuplicateCode(Guid? materialId, Material material)
        //{
        //    int duplicateCode = _materialDL.CheckDuplicateCode(materialId, material.MaterialCode);

        //    if (duplicateCode == 0)
        //    {
        //        return new ServiceResult
        //        {
        //            IsSuccess = false,
        //            Data = new ErrorResult()
        //            {
        //                ErrorCode = Common.Enums.ErrorCode.DuplicateCode,
        //                DevMsg = Common.Resource.DataResource.UserMsg_DuplicateCode,
        //                UserMsg = Common.Resource.DataResource.UserMsg_DuplicateCode,
        //                MoreInfo = Common.Resource.MoreInfo.MoreInfo_DuplicateCode
        //            }
        //        };
        //    }

        //    return new ServiceResult { IsSuccess = true };
        //}
        #endregion
    }
}
