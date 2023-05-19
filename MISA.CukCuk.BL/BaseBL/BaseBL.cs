﻿using MISA.CukCuk.Common.Attributes;
using MISA.CukCuk.Common.Entities.DTO;
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

        public PagingData<T> GetPagingMaterial(long pageSize, long pageNumber, string? textSearch, string? sort)
        {
            string queryWhere = null;

            // Set sort theo ModifiedDate nếu k truyền
            if (string.IsNullOrEmpty(sort))
            {
                sort = $"{Resource.SortModifiedDateDESC}";
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
            return _baseDL.GetRecordById(idRecord);

        }

        public ServiceResult InsertOneRecord(T record)
        {
            // validate
            var validateResults = ValidateData(record);

            // thất bại return lỗi
            if (validateResults != null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = validateResults.Data,
                };
            }
            // Kiểm tra tồn tại
            //var checkCode = CheckDuplicateCode(null, record);
            //// thất bại return lỗi
            //if (checkCode != null)
            //{
            //    return new ServiceResult
            //    {
            //        IsSuccess = false,
            //        Data = checkCode.Data
            //    };
            //}
            // thành công chạy proceduce
            var numberOfAffectedRows = _baseDL.InsertOneRecord(record);
            // Xử lí kết quả thành công
            if (numberOfAffectedRows > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                };
            }
            else
            {
                // Thất bại return lỗi server
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InsertFail,
                        DevMsg = Common.Resource.DataResource.DevMsg_InsertFailed,
                        UserMsg = Common.Resource.DataResource.UserMsg_InsertFailed,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_InsertFailed
                    }
                };
            }
        }

        public ServiceResult UpdateOneRecord(T record, Guid idRecord)
        {
            // Lấy kết quả trả về bên Data Layer
            var validateResults = ValidateData(record);

            // thất bại return lỗi
            if (validateResults != null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = validateResults.Data
                };
            }
            
            // Kiểm tra tồn tại
            //var checkCode = CheckDuplicateCode(idRecord, record);
            // thất bại return lỗi
            //if (checkCode != null)
            //{
            //    return new ServiceResult
            //    {
            //        IsSuccess = false,
            //        Data = checkCode.Data
            //    };
            //}
            // thành công chạy proceduce
            var numberOfAffectedRows = _baseDL.UpdateOneRecord(record, idRecord);
            // Xử lí kết quả thành công
            if (numberOfAffectedRows > 0)
            {
                return new ServiceResult
                {
                    IsSuccess = true,
                };
            }
            else
            {
                // Thất bại lỗi server
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.UpdateFail,
                        DevMsg = Common.Resource.DataResource.DevMsg_UpdateFailed,
                        UserMsg = Common.Resource.DataResource.UserMsg_UpdateFailed,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_UpdateFailed
                    }
                };
            }
        }
        public ServiceResult DeleteOneRecord(Guid idRecord)
        {
            // thành công chạy proceduce
            var numberOfAffectedRows = _baseDL.DeleteOneRecord(idRecord);
            // Xử lí kết quả
            if (numberOfAffectedRows > 0)
            {
                // Thành công
                return new ServiceResult
                {
                    IsSuccess = true,
                };
            }
            else
            {
                // Thất bại
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.DeleteFail,
                        DevMsg = Common.Resource.DataResource.DevMsg_DeleteFailed,
                        UserMsg = Common.Resource.DataResource.UserMsg_DeleteFailed,
                        MoreInfo = Common.Resource.MoreInfo.MoreInfo_DeleteFailed
                    }
                };
            }
        }
        public ServiceResult ValidateData(T? record)
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
                return new ServiceResult
                {
                    IsSuccess = false,
                    Data = new ErrorResult
                    {
                        ErrorCode = Common.Enums.ErrorCode.InvalidData,
                        DevMsg = Common.Resource.DataResource.DevMsg_InvalidData,
                        UserMsg = Common.Resource.DataResource.UserMsg_InvalidData,
                        MoreInfo = errorList
                    }
                };
            }
            
            // Kiểm tra custom validate(trường kiểm tra trùng mã)
            var validateCustom = ValidateCustom(record);
            // Có lõi trùng return lỗi
            if (!validateCustom.IsSuccess)
            {
                return validateCustom;
            }
                
            // Kiểm tra tồn tại
            //var checkCode = CheckDuplicateCode(idRecord, record);
            //// thất bại return lỗi
            //if (checkCode != null)
            //{
            //    return new ServiceResult
            //    {
            //        IsSuccess = false,    
            //        Data = checkCode.Data
            //    };
            //}
            return null;
        }

        protected virtual ServiceResult ValidateCustom(T? record)
        {
            return new ServiceResult { };
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