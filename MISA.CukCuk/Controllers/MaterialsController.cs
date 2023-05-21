using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.MaterialBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Error;
using MySqlConnector;

namespace MISA.CukCuk.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaterialsController : BasesController<Material>
    {
        #region Field

        private IMaterialBL _materialBL;

        #endregion

        #region Constructor

        public MaterialsController(IMaterialBL materialBL) : base(materialBL) 
        {
            _materialBL = materialBL;
        }

        #endregion
    }
}
