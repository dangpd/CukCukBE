using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.StockBL;
using MISA.CukCuk.Common.Entities;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StocksController : BasesController<Stock>
    {
        #region Field

        private IStockBL _stockBL;

        #endregion

        public StocksController(IStockBL stockBL) : base(stockBL)
        {
            _stockBL = stockBL;
        }
    }
}
