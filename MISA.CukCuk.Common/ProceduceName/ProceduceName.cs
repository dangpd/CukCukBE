using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.ProceduceName
{
    public class ProceduceName
    {
        // Store proceduce Name của lấy tất cả bản ghi
        public static string GetAllRecord = "Proc_{0}_GetAll";

        // Store proceduce Name của lấy 1 bản ghi
        public static string GetRecordById = "Proc_{0}_GetById";

        // Store proceduce Name của thêm 1 bản ghi mới
        public static string Insert = "Proc_{0}_Insert";

        // Store proceduce Name của sửa 1 bản ghi 
        public static string Update = "Proc_{0}_Update";

        // Store proceduce Name của xóa 1 bản ghi 
        public static string Delete = "Proc_{0}_Delete";

        // Store proceduce Name của Filter and paging
        public static string PagingAndFilter = "Proc_{0}_Filter";

        // Kiểm tra tồn tại
        public static string DuplicateCode = "Proc_{0}_DuplicateCode";

    }
}
