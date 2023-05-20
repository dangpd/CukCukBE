using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.DL.ConversionUnitDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.ConversionUnitBL
{
    public class ConversionUnitBL : BaseBL<ConversionUnit>, IConversionUnitBL
    {
        #region Field

        private IConversionUnitDL _conversionUnitDL;

        #endregion

        #region Constructor

        public ConversionUnitBL(IConversionUnitDL conversionUnitDL) : base(conversionUnitDL)
        {
            conversionUnitDL = new ConversionUnitDL();
            _conversionUnitDL = conversionUnitDL;
        }

        #endregion

    }
}
