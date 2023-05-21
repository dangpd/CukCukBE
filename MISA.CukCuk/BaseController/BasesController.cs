using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Error;
using MySqlConnector;
using System;

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
                    return StatusCode(StatusCodes.Status204NoContent, null);
                }
                // Thành công return danh sách record
                return StatusCode(StatusCodes.Status200OK, listRecord);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(exception));
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
                // Thành công return data
                return StatusCode(StatusCodes.Status200OK, reordGetByID);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateExceptionResult(exception));
            }
        }

        /// <summary>
        /// Lấy danh nhân viên theo phân trang
        /// </summary>
        /// <param name="textSearch">Chuỗi cần tìm kiếm</param>
        /// <param name="pageSize"> Số bản ghi trên trang </param>
        /// <param name="pageNumber"> Vị trí trang </param>
        /// <returns></returns>
        [HttpPost("Filter")]
        public virtual IActionResult FilterAndPaging([FromBody] List<FilterPaging> filterPagings, [FromQuery] long pageSize = 20, [FromQuery] long pageNumber = 1, [FromQuery] string? sort = "ModifiedDate DESC")
        {
            try
            {
                // Lấy kết quả trả về bên Bussiness Layer
                var filterEmployee = _baseBL.GetPaging(pageSize, pageNumber, filterPagings, sort);  

                // Thành công return danh sách record
                if (filterEmployee == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent,null);

                }
                return StatusCode(StatusCodes.Status200OK, filterEmployee);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<T>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
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

            try
            {
                int result = _baseBL.InsertOneRecord(record);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<T>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
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
            try
            {
                int result = _baseBL.UpdateOneRecord(record, idRecord);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<T>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
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
            try
            {
                int result = _baseBL.DeleteOneRecord(idRecord);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
            }
        }

        #endregion

    }
}
