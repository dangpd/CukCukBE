using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Common.Attributes
{
    /// <summary>
    /// Tên đơn vị tính không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UnitNameNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Tên kho không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StockNameNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Mã kho không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StockCodeNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Tên nhóm nguyên vật liệu không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryNameNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Mã nhóm nguyên vật liệu không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryCodeNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Mã nguyên vật liệu không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaterialCodeNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Tên nguyên vật liệu không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaterialNameNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Tính chất không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FeatureNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Id đơn vị tính không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ConversionUnitIdNotEmpty : Attribute
    {
    }

    /// <summary>
    /// Id đơn vị tính không được bỏ trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaterialIdNotEmpty : Attribute
    {
    }
}
