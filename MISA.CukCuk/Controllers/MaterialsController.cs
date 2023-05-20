using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.MaterialBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;

namespace MISA.CukCuk.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        #region Field

        private IMaterialBL _materialBL;

        #endregion

        #region Constructor

        public MaterialsController(IMaterialBL materialBL)
        {
            _materialBL = materialBL;
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
                var listRecord = _materialBL.GetAllRecord();

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
        /// Thêm mới một nguyên vật liệu
        /// </summary>
        /// <param name="inforMaterial"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertOneRecord([FromBody] InforMaterial inforMaterial)
        {
            // Lấy kết quả trả về bên Bussiness Layer
            var result = _materialBL.InsertMaterial(inforMaterial); // số bản ghi được insert

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
        /// Xóa nguyên vật liệu
        /// </summary>
        /// <param name="idRecord"></param>
        /// <returns></returns>
        [HttpDelete("{idRecord}")]
        public IActionResult DeleteOne([FromRoute] Guid idRecord)
        {
            // Lấy kết quả trả về bên Bussiness Layer
            var result = _materialBL.DeleteOneRecord(idRecord);
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

        /// <summary>
        /// Cập nhập thông tin 1 bản ghi
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="updateMaterial"></param>
        /// <returns></returns>
        [HttpPut("{materialId}")]
        public IActionResult UpdateOne([FromRoute] Guid materialId, InforMaterial updateMaterial)
        {
            // Lấy kết quả trả về bên Bussiness Layer
            var result = _materialBL.UpdateMaterial(materialId, updateMaterial); // số bản ghi được update
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
        /// Lấy 1 nguyên vật liệu theo id
        /// </summary>
        /// <param name="materialID"></param>
        /// <returns></returns>
        [HttpGet("{materialId}")]
        public IActionResult GetByID([FromRoute] Guid materialId)
        {
            try
            {
                // Lấy kết quả trả về bên Bussiness Layer
                var reordGetByID = _materialBL.GetMaterialByID(materialId);

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
                var filterEmployee = _materialBL.GetPagingMaterial(pageSize, pageNumber, textSearch, sort);

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

        #endregion
    }
}
