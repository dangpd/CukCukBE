using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.UnitDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.UnitBL
{
    public class UnitBL : BaseBL<Unit>, IUnitBL
    {
        #region Field

        private IUnitDL _unitDL;

        #endregion

        public UnitBL(IUnitDL unitDL) : base(unitDL)
        {
            unitDL = new UnitDL();
            _unitDL = unitDL;
        }
        protected override ServiceResult ValidateCustom(Unit? record)
        {
            int duplicateCode = _unitDL.CheckDuplicateName(record.ConversionUnitId, record.ConversionUnitName);

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
        //protected override ServiceResult CheckDuplicateCode(Guid? recordID, Unit record)
        //{
        //    int duplicateCode = _unitDL.CheckDuplicateName(recordID, record.ConversionUnitName);

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
    }
}
