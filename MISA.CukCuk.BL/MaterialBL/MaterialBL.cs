using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.Common.Entities;
using MISA.CukCuk.Common.Entities.DTO;
using MISA.CukCuk.Common.Error;
using MISA.CukCuk.Common.Resource;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.MaterialDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.BL.MaterialBL
{
    public class MaterialBL : BaseBL<Material>, IMaterialBL
    {
        #region Field

        private IMaterialDL _materialDL;

        #endregion

        #region Constructor

        public MaterialBL(IMaterialDL materialDL) : base(materialDL)
        {
            materialDL = new MaterialDL();
            _materialDL = materialDL;
        }

        #endregion

        #region Method

        public string convertBuilderString(FilterPaging filterPaging)
        {
            if (filterPaging.Field == TableName.FeildConversionUnit)
            {
                return $"u.{filterPaging.Field} like '%{filterPaging.Value}%'";
            }
            else if (filterPaging.Field == TableName.FeildCategory)
            {
                return $"m1.{filterPaging.Field} like '%{filterPaging.Value}%'";
            }
            else
            {
                return $"m.{filterPaging.Field} like '%{filterPaging.Value}%'";
            }
        }

        protected override string BuildWhereFilter(List<FilterPaging> listFilter)
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
                        filterBuild =  convertBuilderString(item);
                        break;
                    case QueryCondition.EQUAL:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.START_WIDTH:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.END_WIDTH:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.NOTLIKE:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.GREATER:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.GREATER_OR_EQUAL:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.LESS:
                        filterBuild = convertBuilderString(item);
                        break;
                    case QueryCondition.LESS_OR_EQUAL:
                        filterBuild = convertBuilderString(item);
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

        public InforMaterial GetMaterialByID(Guid materialId)
        {
            return _materialDL.GetMaterialByID(materialId); // bản ghi cần lấy 
        }


        public int InsertMaterial(InforMaterial inforMaterial)
        {
            var validateMaterial = ValidateData(inforMaterial.Material); // validate nguyên vật liệu
            // Validate nguyên vật liệu
            if (validateMaterial != null)
            {
                throw new MISAException(
                    new ErrorResult(
                            Common.Enums.ErrorCode.InvalidData,
                            Resource.DevMsg_InvalidData,
                            Resource.UserMsg_InvalidData,
                            validateMaterial,
                            ""
                        )
                    );
            }
            // Validate danh sách đơn vị chuyển đổi
            var baseConversionUnit = new BaseBL<ConversionUnit>(new BaseDL<ConversionUnit>());
            foreach (var item in inforMaterial.ListConversionUnits)
            {
                //var convert = (ConversionUnit)item;
                var validateConversionUnit = baseConversionUnit.ValidateData(item); // validate đơn vị chuyển đổi
                // thất bại return lỗi
                if (validateConversionUnit != null)
                {
                    throw new MISAException(
                        new ErrorResult(
                                Common.Enums.ErrorCode.InvalidData,
                                Resource.DevMsg_InvalidData,
                                Resource.UserMsg_InvalidData,
                                validateMaterial,
                                ""
                            )
                        );
                }
            }

            return _materialDL.InsertMaterial(inforMaterial);
        }

        public int UpdateMaterial(Guid materialId, InforMaterial updateMaterial)
        {
            var validateMaterial = ValidateData(updateMaterial.Material); // validate nguyên vật liệu
            // Validate nguyên vật liệu
            if (validateMaterial != null)
            {
                throw new MISAException(
                    new ErrorResult(
                            Common.Enums.ErrorCode.InvalidData,
                            Resource.DevMsg_InvalidData,
                            Resource.UserMsg_InvalidData,
                            validateMaterial,
                            ""
                        )
                    );
            }

            // Validate danh sách đơn vị chuyển đổi
            var baseConversionUnit = new BaseBL<ConversionUnit>(new BaseDL<ConversionUnit>());
            foreach (var item in updateMaterial.ListConversionUnits)
            {
                var validateConversionUnit = baseConversionUnit.ValidateData(item); // validate đơn vị chuyển đổi
                // thất bại return lỗi
                if (validateConversionUnit != null)
                {
                    throw new MISAException(
                        new ErrorResult(
                                Common.Enums.ErrorCode.InvalidData,
                                Resource.DevMsg_InvalidData,
                                Resource.UserMsg_InvalidData,
                                validateMaterial,
                                ""
                            )
                        );
                }
            }



            return _materialDL.UpdateMaterial(materialId, updateMaterial);
        }

        #endregion
    }
}
