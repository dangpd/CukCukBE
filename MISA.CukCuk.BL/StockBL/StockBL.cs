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
    }
}
