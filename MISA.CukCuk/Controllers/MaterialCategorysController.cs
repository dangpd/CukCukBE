﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.MaterialCategoryBL;
using MISA.CukCuk.Common.Entities;

namespace MISA.CukCuk.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaterialCategorysController : BasesController<MaterialCategory>
    {
        #region Feild

        private IMaterialCategoryBL _materialCategoryBL;

        #endregion

        #region Contructor
        public MaterialCategorysController(IMaterialCategoryBL materialCategoryBL) : base(materialCategoryBL)
        {
            _materialCategoryBL = materialCategoryBL;
        }
        #endregion
    }
}
