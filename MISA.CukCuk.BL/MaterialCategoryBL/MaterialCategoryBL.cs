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

        #endregion
    }
}
