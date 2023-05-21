using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Enums
{
    public enum ErrorCode
    {
        InvalidData = 400,
        Exception = 500,
        Nodifine = 501,
        NotExistOrDeleted = 502,
    }
    /// <summary>
    /// Trạng thái theo dõi
    /// </summary>
    public enum StatusFollow
    {
        /// <summary>
        /// Theo dõi
        /// </summary>
        Follow = 1,

        /// <summary>
        /// Ngưng theo dõi
        /// </summary>
        StopFollow = 2

    }

    /// <summary>
    /// Thể loại convert
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        Add = 1,

        /// <summary>
        /// Cập nhập
        /// </summary>
        Update = 2,

        /// <summary>
        /// Xóa
        /// </summary>
        Delete = 3
    }

    /// <summary>
    /// Phép tính
    /// </summary>
    public enum Calculate
    {
        /// <summary>
        /// Phép nhân
        /// </summary>
        Multiplication = 1,

        /// <summary>
        /// Phép chia
        /// </summary>
        Division = 2,
    }
}
