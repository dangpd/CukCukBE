using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.StockDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.StockBL
{
    public class StockBL : BaseBL<Stock>, IStockBL
    {
        #region Field

        private IStockDL _stockDL;

        #endregion

        public StockBL(IStockDL stockDL) : base(stockDL)
        {
            stockDL = new StockDL();
            _stockDL = stockDL;
        }
        protected override ServiceResult ValidateCustom(Stock? record)
        {
            int duplicateCode = _stockDL.CheckDuplicateCode(record.StockId,record.StockCode);

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
        //protected override ServiceResult CheckDuplicateCode(Guid? recordID, Stock record)
        //{
        //    int duplicateCode = _stockDL.CheckDuplicateCode(recordID, record.StockCode);

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
