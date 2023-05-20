using MISA.CukCuk.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Error
{
    public class MISAException : Exception
    {
        #region Field
        public ErrorResult ErrorResult { get; set; }
        #endregion

        #region Constructor

        public MISAException(ErrorResult errorResult)
        {
            ErrorResult = errorResult;
        }

        #endregion
    }
}
