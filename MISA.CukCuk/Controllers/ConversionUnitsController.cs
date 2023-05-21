using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionUnitsController : BasesController<ConversionUnit>
    {
        public ConversionUnitsController(IBaseBL<ConversionUnit> baseBL) : base(baseBL)
        {
        }

        public override IActionResult GetAllRecords()
        {
            return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

        public override IActionResult GetRecordById(Guid idRecord)
        {
            return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

    }
}
