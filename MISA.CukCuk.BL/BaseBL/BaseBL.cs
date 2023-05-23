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

        public PagingData<T> GetPaging(long pageSize, long pageNumber, List<FilterPaging> filterPagings, string? sort)
        {
            string queryWhere = null;

            // Set sort theo ModifiedDate nếu k truyền
            if (string.IsNullOrEmpty(sort))
            {
                sort = $"{QueryCondition.ModifiedDate}";
            }

            // Kiểm tra chuỗi filter rỗng
            if (filterPagings != null)
            {
                // Danh sách các item cần query cho WHERE
                //var listFilter = JsonSerializer.Deserialize<List<FilterPaging>>(textSearch);

                queryWhere = BuildWhereFilter(filterPagings);
                //queryWhere = textSearch;
            }
            return _baseDL.GetPaging(pageSize, pageNumber, queryWhere, sort);
        }

        private string BuildWhereFilter(List<FilterPaging> listFilter)
        {
            string baseWhere = "";
            string[] listFilterBuild = new string[listFilter.Count];
            int i = 0;
            foreach (var item in listFilter)
            {
                string filterBuild = "";
                switch (item.Operater)
                {
                    case QueryCondition.LIKE:
                        filterBuild = $"{item.Field} like '%{item.Value}%'";
                        break;
                    case QueryCondition.EQUAL:
                        filterBuild = $"{item.Field} = '{item.Value}'";
                        break;
                    case QueryCondition.START_WIDTH:
                        filterBuild = $"{item.Field} like '%{item.Value}'";
                        break;
                    case QueryCondition.END_WIDTH:
                        filterBuild = $"{item.Field} like '{item.Value}%'";
                        break;
                    case QueryCondition.NOTLIKE:
                        filterBuild = $"{item.Field} not like '%{item.Value}%'";
                        break;
                    case QueryCondition.GREATER:
                        filterBuild = $"{item.Field} > '{item.Value}'";
                        break;
                    case QueryCondition.GREATER_OR_EQUAL:
                        filterBuild = $"{item.Field} >= '{item.Value}'";
                        break;
                    case QueryCondition.LESS:
                        filterBuild = $"{item.Field} < '{item.Value}'";
                        break;
                    case QueryCondition.LESS_OR_EQUAL:
                        filterBuild = $"{item.Field} <= '{item.Value}'";
                        break;
                    default:
                        break;
                }
                listFilterBuild[i] = filterBuild;
                if (i == 0)
                {
                    baseWhere += $" {filterBuild}";
                }
                else
                {
                    baseWhere += $" AND {filterBuild}";
                }
                i++;

            }
            return baseWhere;
        }

        public T GetRecordById(Guid idRecord)
        {
            var record = _baseDL.GetRecordById(idRecord);
            if (record == null)
            {
                throw new MISAException(
                    new ErrorResult(
                        Common.Enums.ErrorCode.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
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
                        Error.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
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
                        Error.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
                        Error.NotExistOrDeleted,
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

                    // Validate tên đơn vị không được bỏ trống
                    if (typeofAttr == typeof(UnitNameNotEmpty))
                    {

                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.UnitNameNotEmpty);
                        }
                    }

                    // Validate tên kho không được bỏ trống
                    if (typeofAttr == typeof(StockNameNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.StockNameNotEmpty);
                        }
                    }

                    // Validate mã kho không được bỏ trống
                    if (typeofAttr == typeof(StockCodeNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.StockCodeNotEmpty);
                        }
                    }

                    // Validate tên nhóm nguyên liệu không được bỏ trống
                    if (typeofAttr == typeof(CategoryNameNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.CategoryNameNotEmpty);
                        }
                    }

                    // Validate mã nhóm nguyên liệu không được bỏ trống
                    if (typeofAttr == typeof(CategoryCodeNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.CategoryCodeNotEmpty);
                        }
                    }

                    // Validate tên nguyên vật liệu không được bỏ trống
                    if (typeofAttr == typeof(MaterialNameNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.MaterialNameNotEmpty);
                        }
                    }

                    // Validate mã nhóm nguyên vật liệu không được bỏ trống
                    if (typeofAttr == typeof(MaterialCodeNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.MaterialCodeNotEmpty);
                        }
                    }

                    // Validate tính chất không được bỏ trống
                    if (typeofAttr == typeof(FeatureNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.FeatureNotEmpty);
                        }
                    }

                    // Validate id đơn vị chuyển đổi không được bỏ trống
                    if (typeofAttr == typeof(ConversionUnitIdNotEmpty))
                    {
                        if (string.IsNullOrEmpty(propValue?.ToString()?.Trim()))
                        {
                            isValid = false;
                            errorList.Add(Common.Resource.Error.ConversionUnitIdNotEmpty);
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

    }
}
