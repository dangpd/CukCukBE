using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.DL.BaseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.DL.MaterialCategoryDL
{
    public interface IMaterialCategoryDL : IBaseDL<MaterialCategory>
    {
        /// <summary>
        /// Kiểm tra mã trùng
        /// </summary>
        /// <param name="recordCode"></param>
        /// <param name="recordID"></param>
        /// <returns>bool kiểm tra có trùng hay không</returns>
        public int CheckDuplicateCode(Guid? recordId, string? recordCode);
    }
}
