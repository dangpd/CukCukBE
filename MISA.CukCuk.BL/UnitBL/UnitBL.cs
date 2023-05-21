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

        #region Contructor
        public UnitBL(IUnitDL unitDL) : base(unitDL)
        {
            unitDL = new UnitDL();
            _unitDL = unitDL;
        }

        #endregion

    }
}
