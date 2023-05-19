using MISA.CukCuk.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.BaseBL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi <typeparamref name="T"/>
        /// </summary>
        /// <returns>Danh sách các bản ghi <typeparamref name="T"/></returns>
        public List<T> GetAllRecord();

        /// <summary>
        /// Lấy 1 bản ghi <typeparamref name="T"/>
        /// </summary>
        /// <param name="idRecord"> id bản ghi cần lấy </param>
        /// <returns> Bản ghi <typeparamref name="T"/> </returns>
        public T GetRecordById(Guid idRecord);

        /// <summary>
        /// Thêm mới một bản ghi <typeparamref name="T"/>
        /// </summary>
        /// <param name="record"> <typeparamref name="T"/> </param>
        /// <returns> Số bản ghi bị tác động </returns>
        public ServiceResult InsertOneRecord(T record);

        /// <summary>
        /// Cập nhập 1 bản ghi <typeparamref name="T"/>
        /// </summary>
        /// <param name="record"> Thông tin bản ghi cần cập nhập <typeparamref name="T"/> </param>
        /// <param name="idRecord"> id bản ghi cần cập nhập </param>
        /// <returns> Số bản ghi bị tác động </returns>
        public ServiceResult UpdateOneRecord(T record, Guid idRecord);

        /// <summary>
        /// Xóa 1 bản ghi <typeparamref name="T"/>
        /// </summary>
        /// <param name="idRecord"> id bản ghi cần xóa </param>
        /// <returns> Số bản ghi bị tác động </returns>
        public ServiceResult DeleteOneRecord(Guid idRecord);

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="textSearch"> chuỗi search where </param>
        /// <param name="pageSize"> kích thước 1 trang </param>
        /// <param name="pageNumber"> vị trí trang </param>
        /// <param name="sort"> loại sắp xếp </param>
        /// <returns></returns>
        public PagingData<T> GetPaging(long pageSize, long pageNumber, string? textSearch, string? sort);

        /// <summary>
        /// Phân trang
        /// </summary>
        /// <param name="textSearch"> chuỗi search where </param>
        /// <param name="pageSize"> kích thước 1 trang </param>
        /// <param name="pageNumber"> vị trí trang </param>
        /// <param name="sort"> loại sắp xếp </param>
        /// <returns></returns>
        public PagingData<T> GetPagingMaterial(long pageSize, long pageNumber, string? textSearch, string? sort);

    }
}
