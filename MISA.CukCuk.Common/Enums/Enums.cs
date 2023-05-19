using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Enums
{
    /// <summary>
    /// Mã lỗi
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Lỗi ngoại lệ
        /// </summary>
        Exception = 0,

        /// <summary>
        /// Thêm thất bại
        /// </summary>
        InsertFail = 1,

        /// <summary>
        /// Sửa thất bại
        /// </summary>
        UpdateFail = 2,

        /// <summary>
        /// Xóa thất bại
        /// </summary>
        DeleteFail = 3,

        /// <summary>
        /// Lỗi dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidData = 400,

        /// <summary>
        /// Lỗi sai url
        /// </summary>
        NotFound = 404,


        /// <summary>
        /// Lỗi trùng mã
        /// </summary>
        DuplicateCode = 402,

        /// <summary>
        /// Lỗi phía back-end
        /// </summary>
        ServerError = 500,
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
