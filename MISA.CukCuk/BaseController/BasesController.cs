using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities.DTO;

namespace MISA.CukCuk.BaseController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy tất cả bản ghi 
        /// </summary>
        /// <returns>Danh sách các bản ghi </returns>
        [HttpGet]
        public virtual IActionResult GetAllRecords()
        {
            try
            {
                // Lấy kết quả trả về bên Bussiness Layer
                var listRecord = _baseBL.GetAllRecord();

                // Nếu kq trả về null return lỗi server
                if (listRecord == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ServerError,
                        DevMsg = Common.Resource.DataResource.DevMsg_ServerError,
                        UserMsg = Common.Resource.DataResource.UserMsg_ServerError,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                // Thành công return danh sách record
                return StatusCode(StatusCodes.Status200OK, listRecord);
            }
            catch (Exception ex)
            {
                // Lỗi exception
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.MoreInfo.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Lấy 1 bản ghi 
        /// </summary>
        /// <param name="idRecord"> id bản ghi cần lấy </param>
        /// <returns> Bản ghi </returns>
        [HttpGet("{idRecord}")]
        public virtual IActionResult GetRecordById(Guid idRecord)
        {
            try
            {
                // Lấy kết quả trả về bên Bussiness Layer
                var reordGetByID = _baseBL.GetRecordById(idRecord);

                // Nếu kq trả về null return lỗi dữ liệu định dạng không hợp lệ
                if (reordGetByID == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InvalidData,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_InvalidData,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }

                // Thành công return id record
                return StatusCode(StatusCodes.Status200OK, reordGetByID);
            }
            catch (Exception ex)
            {
                // Lỗi exception
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.MoreInfo.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Lấy danh nhân viên theo phân trang
        /// </summary>
        /// <param name="textSearch">Chuỗi cần tìm kiếm</param>
        /// <param name="pageSize"> Số bản ghi trên trang </param>
        /// <param name="pageNumber"> Vị trí trang </param>
        /// <returns></returns>
        [HttpGet("Filter")]
        public virtual IActionResult FilterAndPaging([FromQuery] string? textSearch, [FromQuery] long pageSize, [FromQuery] long pageNumber, [FromQuery] string? sort)
        {
            try
            {
                // Lấy kết quả trả về bên Bussiness Layer
                var filterEmployee = _baseBL.GetPaging(pageSize, pageNumber, textSearch, sort);

                // Thành công return danh sách record
                if (filterEmployee != null)
                {
                    return StatusCode(StatusCodes.Status200OK, filterEmployee);
                }
                // Nếu null thất bại return lỗi nhập liệu
                else if ((object)filterEmployee == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InvalidData,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = Common.Resource.Resource.UserMsg_PageSize,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                else
                {
                    // Nếu kq trả về null return lỗi server
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ServerError,
                        DevMsg = Common.Resource.DataResource.DevMsg_ServerError,
                        UserMsg = Common.Resource.DataResource.UserMsg_ServerError,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }


            }
            catch (Exception ex)
            {
                // Lỗi exception
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_ServerError,
                    UserMsg = Common.Resource.DataResource.UserMsg_ServerError,
                    MoreInfo = Common.Resource.MoreInfo.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Thêm mới bản ghi</param>
        /// <returns>Bản ghi</returns>
        [HttpPost]
        public virtual IActionResult InsertRecord(T record)
        {
            // Lấy kết quả trả về bên Bussiness Layer
            var result = _baseBL.InsertOneRecord(record);

            try
            {
                // Thành công return 1
                if (result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status201Created, 1);
                }

                // Nếu result bằng false và errorcode == invalid data return lỗi nhập liệu
                else if (!result.IsSuccess && result.Data.ErrorCode == Common.Enums.ErrorCode.InvalidData)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = result.Data.ErrorCode,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = result.Data.MoreInfo,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                else if(!result.IsSuccess && result.Data.ErrorCode == Common.Enums.ErrorCode.DuplicateCode)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = result.Data.ErrorCode,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = result.Data.MoreInfo,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                // Nếu kq trả về null return lỗi server
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ServerError,
                        DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                        UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                // lỗi exception
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.MoreInfo.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Cập nhập 1 bản ghi 
        /// </summary>
        /// <param name="record"> Thông tin bản ghi cần cập nhập <typeparamref name="T"/> </param>
        /// <param name="idRecord"> id bản ghi cần cập nhập </param>
        /// <returns> Số bản ghi bị tác động </returns>
        [HttpPut("{idRecord}")]
        public virtual IActionResult UpdateRecord([FromBody] T record, [FromRoute] Guid idRecord)
        {
            // Lấy kết quả trả về bên Bussiness Layer
            var result = _baseBL.UpdateOneRecord(record, idRecord);
            try
            {
                // Thành công return 1
                if (result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, 1);
                }

                // Nếu result bằng false và errorcode == invalid data return lỗi nhập liệu
                else if (!result.IsSuccess && result.Data.ErrorCode == Common.Enums.ErrorCode.InvalidData)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InvalidData,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = result.Data.MoreInfo,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }

                // Nếu kq trả về null return lỗi server
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ServerError,
                        DevMsg = Common.Resource.DataResource.DevMsg_ServerError,
                        UserMsg = Common.Resource.DataResource.UserMsg_ServerError,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                // lỗi exception
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.MoreInfo.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="idRecord"> id bản ghi cần xóa </param>
        /// <returns> Số bản ghi bị tác động </returns>
        [HttpDelete("{idRecord}")]
        public virtual IActionResult DeleteOneRecord([FromRoute] Guid idRecord)
        {
            // Lấy kết quả trả về bên Bussiness Layer
            var result = _baseBL.DeleteOneRecord(idRecord);
            try
            {
                // Thành công return 1
                if (result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK, 1);
                }

                // Nếu result bằng false và errorcode == invalid data return lỗi nhập liệu
                else if (!result.IsSuccess && result.Data.ErrorCode == Common.Enums.ErrorCode.InvalidData)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.DeleteFail,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = result.Data.MoreInfo,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }

                // Nếu result bằng false và errorcode == invalid data return lỗi nhập liệu
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.ServerError,
                        DevMsg = Common.Resource.DataResource.UserMsg_ServerError,
                        UserMsg = Common.Resource.DataResource.UserMsg_ServerError,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_ServerError,
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.ErrorCode.Exception,
                    DevMsg = Common.Resource.DataResource.DevMsg_Exception,
                    UserMsg = Common.Resource.DataResource.UserMsg_Exception,
                    MoreInfo = Common.Resource.MoreInfo.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        #endregion

    }
}
