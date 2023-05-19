using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.MaterialCategoryDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.MaterialCategoryBL
{
    public class MaterialCategoryBL : BaseBL<MaterialCategory>,IMaterialCategoryBL
    {
        #region Field

        private IMaterialCategoryDL _materialCategoryDL;

        #endregion

        #region Constructor

        public MaterialCategoryBL(IMaterialCategoryDL materialCategoryDL) : base(materialCategoryDL)
        {
            _materialCategoryDL = materialCategoryDL;
        }
        protected override ServiceResult ValidateCustom(MaterialCategory? record)
        {
            int duplicateCode = _materialCategoryDL.CheckDuplicateCode(record.CategoryID, record.CategoryCode);

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
        //protected override ServiceResult CheckDuplicateCode(Guid? recordID, MaterialCategory record)
        //{
        //    int duplicateCode = _materialCategoryDL.CheckDuplicateCode(recordID, record.CategoryCode);

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
