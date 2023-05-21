using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.StockBL;
using MISA.CukCuk.BL.UnitBL;
using MISA.CukCuk.Common.Entities;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnitsController : BasesController<Unit>
    {
        #region Field

        private IUnitBL _unitBL;

        #endregion

        #region Contructor
        public UnitsController(IUnitBL unitBL) : base(unitBL)
        {
            _unitBL = unitBL;
        }
        #endregion
    }
}
