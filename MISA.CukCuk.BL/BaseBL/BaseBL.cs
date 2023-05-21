using MISA.CukCuk.Common.Attributes;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Error;
using MISA.CukCuk.Common.Resource;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.ConversionUnitDL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.BaseBL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        public IConversionUnitDL ConversionUnitDL { get; }

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        public BaseBL(IConversionUnitDL conversionUnitDL)
        {
            ConversionUnitDL = conversionUnitDL;
        }

        #endregion

        public List<T> GetAllRecord()
        {
            return _baseDL.GetAllRecord();
        }

        public PagingData<T> GetPaging(long pageSize, long pageNumber, string? textSearch, string? sort)
        {
            string queryWhere = null;

            // Set sort theo ModifiedDate nếu k truyền
            if (string.IsNullOrEmpty(sort))
            {
                sort = $"{Resource.SortModifiedDateDESC1}";
            }

            // Kiểm tra chuỗi filter rỗng
            if (!string.IsNullOrEmpty(textSearch))
            {
                // Danh sách các item cần query cho WHERE
                //var listFilter = JsonSerializer.Deserialize<List<FilterPaging>>(textSearch);

                //queryWhere = QueryCondition.GetQueryStringWhere(listFilter);
                queryWhere = textSearch;
            }
            return _baseDL.GetPaging(pageSize, pageNumber, queryWhere, sort);
        }

        public T GetRecordById(Guid idRecord)
        {
            var record = _baseDL.GetRecordById(idRecord);
            if (record == null)
            {
                throw new MISAException(
                    new ErrorResult(
                        Common.Enums.ErrorCode.NotExistOrDeleted,
                        Error.NotExistOrIsDeleted,
                        Error.NotExistOrIsDeleted,
                        Error.NotExistOrIsDeleted,
                        ""
                    )
                );
            }
            return record;
        }

        public int InsertOneRecord(T record)
        {
            // validate
            var validateResults = ValidateData(record);

            // thất bại return lỗi
            if (validateResults != null)
            {
                throw new MISAException(
                    new ErrorResult(
                        Common.Enums.ErrorCode.InvalidData,
                        Resource.DevMsg_InvalidData,
                        Resource.UserMsg_InvalidData,
                        validateResults,
                        ""
                        )
                    );
            }

            // thành công chạy proceduce
            return _baseDL.InsertOneRecord(record);
        }

        public int UpdateOneRecord(T record, Guid idRecord)
        {
            // Lấy kết quả trả về bên Data Layer
            var validateResults = ValidateData(record);

            // thất bại return lỗi
            if (validateResults != null)
            {
                throw new MISAException(
                    new ErrorResult(
                        Common.Enums.ErrorCode.InvalidData,
                        Resource.DevMsg_InvalidData,
                        Resource.UserMsg_InvalidData,
                        validateResults,
                        ""
                        )
                    );
            }
            
            // thành công chạy proceduce
            int numberOfAffectedRows = _baseDL.UpdateOneRecord(record, idRecord);
            if (numberOfAffectedRows == 0) // Nếu = 0 thông báo bản ghi bị xóa hoặc không tồn tại
            {
                throw new MISAException(
                    new ErrorResult(
                        Common.Enums.ErrorCode.NotExistOrDeleted,
                        Error.NotExistOrIsDeleted,
                        Error.NotExistOrIsDeleted,
                        Error.NotExistOrIsDeleted,
                        ""
                    )
                );
            }
            return numberOfAffectedRows;
        }
        public int DeleteOneRecord(Guid idRecord)
        {
            // thành công chạy proceduce
            int numberOfAffectedRows = _baseDL.DeleteOneRecord(idRecord);
            if (numberOfAffectedRows == 0)  // Nếu = 0 thông báo bản ghi bị xóa hoặc không tồn tại
            {
                throw new MISAException(
                    new ErrorResult(
                        Common.Enums.ErrorCode.NotExistOrDeleted,
                        Error.NotExistOrIsDeleted,
                        Error.NotExistOrIsDeleted,
                        Error.NotExistOrIsDeleted,
                        ""
                    )
                );
            }
            return numberOfAffectedRows;
        }
        public List<string> ValidateData(T? record)
        {
            // Xử lý
            bool isValid = true;

            List<string> errorList = new List<string>();

            // Lấy các thuộc tính của record
            //var props = record.GetType().GetProperties();
            var props = typeof(T).GetProperties();


            foreach (var prop in props)
            {
                // Value của thuộc tính
                var propValue = prop.GetValue(record);

                // Lấy danh sách các trường cần validate
                var attrCustoms = prop.GetCustomAttributes(true);

                foreach (var attrCustom in attrCustoms)
                {
                    var typeofAttr = attrCustom.GetType();
                    if (typeofAttr == typeof(KeyAttribute))
                    {

                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_KeyAttribue);
                        }
                    }

                    // Validate tên đơn vị không được bỏ trống
                    if (typeofAttr == typeof(UnitNameNotEmpty))
                    {

                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_UnitNameNotEmpty);
                        }
                    }

                    // Validate tên kho không được bỏ trống
                    if (typeofAttr == typeof(StockNameNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_StockNameNotEmpty);
                        }
                    }

                    // Validate mã kho không được bỏ trống
                    if (typeofAttr == typeof(StockCodeNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_StockCodeNotEmpty);
                        }
                    }

                    // Validate tên nhóm nguyên liệu không được bỏ trống
                    if (typeofAttr == typeof(CategoryNameNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_CategoryNameNotEmpty);
                        }
                    }

                    // Validate mã nhóm nguyên liệu không được bỏ trống
                    if (typeofAttr == typeof(CategoryCodeNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_CategoryCodeNotEmpty);
                        }
                    }

                    // Validate tên nguyên vật liệu không được bỏ trống
                    if (typeofAttr == typeof(MaterialNameNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_MaterialNameNotEmpty);
                        }
                    }

                    // Validate mã nhóm nguyên vật liệu không được bỏ trống
                    if (typeofAttr == typeof(MaterialCodeNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_MaterialCodeNotEmpty);
                        }
                    }

                    // Validate tính chất không được bỏ trống
                    if (typeofAttr == typeof(FeatureNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_FeatureNotEmpty);
                        }
                    }

                    // Validate id đơn vị chuyển đổi không được bỏ trống
                    if (typeofAttr == typeof(ConversionUnitIdNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Resource.UserMsg_ConversionUnitIdNotEmpty);
                        }
                    }
                }
            }

            // isValid bằng false thì moreinfo bằng list errorList
            if (!isValid)
            {
                return errorList;
            }
            
            List<string> validateCustom = ValidateCustom(record);
            // Có lõi trùng return lỗi
            if (validateCustom != null)
            {
                return validateCustom;
            }
            return null;
        }

        protected virtual List<string> ValidateCustom(T? record)
        {
            return null;
        }

        /// <summary>
        /// Kiểm tra mã trùng
        /// </summary>
        /// <param name="record"></param>
        /// <param name="recordID"></param>
        /// <returns>bool kiểm tra có trùng hay không</returns>
        //protected virtual ServiceResult CheckDuplicateCode(Guid? recordID, T record)
        //{
        //    return new ServiceResult { };
        //}

    }
}
