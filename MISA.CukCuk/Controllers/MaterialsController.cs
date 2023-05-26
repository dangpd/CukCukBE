using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BaseController;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.MaterialBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Error;
using MySqlConnector;

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
        /// Lọc phân trang
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpPost("Filter")]
        public IActionResult GetPaging([FromBody] List<FilterPaging> filterPagings, [FromQuery] long pageSize = 20, [FromQuery] long pageNumber = 1, [FromQuery] string? sort = "")
        {
            try
            {
                // Lấy kết quả trả về bên Bussiness Layer
                var filterData = _materialBL.GetPaging(pageSize, pageNumber, filterPagings, sort);

                // Thành công return danh sách record
                if (filterData == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, null);

                }
                return StatusCode(StatusCodes.Status200OK, filterData);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<Material>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
            }
        }

        /// <summary>
        /// Lấy mã nguyên vật liệu lớn nhất
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //[HttpGet("GetNewCode")]
        //public IActionResult GetNewCode(string code)
        //{
        //    try
        //    {
        //        var newCode = _materialBL.GetNewCode(code); // mã code mới
        //        return StatusCode(StatusCodes.Status200OK, newCode);
        //    }
        //    catch (MISAException misaEx)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
        //    }
        //    catch (MySqlException mySqlException)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<Material>(mySqlException));
        //    }
        //    catch (Exception exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
        //    }
        //}

        /// <summary>
        /// Thêm mới một nguyên vật liệu
        /// </summary>
        /// <param name="inforMaterial"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertOneRecord([FromBody] InforMaterial inforMaterial)
        {
            try
            {
                var insert = _materialBL.InsertMaterial(inforMaterial); // số bản ghi được insert
                return StatusCode(StatusCodes.Status200OK, insert);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<Material>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
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
            try
            {
                int countDelete = _materialBL.DeleteOneRecord(idRecord); // số bản ghi bị xóa
                return StatusCode(StatusCodes.Status200OK, countDelete);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<Material>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
            }
        }

        /// <summary>
        /// Cập nhập thông tin 1 bản ghi
        /// </summary>
        /// <param name="materialID"></param>
        /// <param name="updateMaterial"></param>
        /// <returns></returns>
        [HttpPut("{materialID}")]
        public IActionResult UpdateOne([FromRoute] Guid materialID, InforMaterial updateMaterial)
        {
            try
            {
                int result = _materialBL.UpdateMaterial(materialID, updateMaterial); // số bản ghi được update
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<Material>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
            }
        }

        /// <summary>
        /// Lấy 1 nguyên vật liệu theo id
        /// </summary>
        /// <param name="materialID"></param>
        /// <returns></returns>
        [HttpGet("{materialID}")]
        public IActionResult GetByID([FromRoute] Guid materialID)
        {
            try
            {
                var inforMaterial = _materialBL.GetMaterialByID(materialID);
                return StatusCode(StatusCodes.Status200OK, inforMaterial);
            }
            catch (MISAException misaEx)
            {
                return StatusCode(StatusCodes.Status400BadRequest, misaEx.ErrorResult);
            }
            catch (MySqlException mySqlException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, HandleError.GenerateDuplicateCodeErrorResult<Material>(mySqlException));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HandleError.GenerateExceptionResult(exception));
            }
        }


        #endregion
    }
}
