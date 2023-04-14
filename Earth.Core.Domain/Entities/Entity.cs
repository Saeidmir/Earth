using Earth.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth.Core.Domain.Entities;

/// <summary>
///The Base class for all Entities...MSM
/// </summary>

public abstract class Entity
{
   
    /// <summary>
    /// Entities Id
    /// For simplicities of saving on database
    /// </summary>
    public long Id { get; protected set; }

    /// <summary>
    /// BusinessId of a entity
    /// it can be usefull everywhere
    /// All communication should be do with this identity
    /// </summary>
    public BusinessId BusinessId { get; protected set; } = BusinessId.FromGuid(Guid.NewGuid());

    /// <summary>
    /// Default constructor should be define proetected
    /// due to the fact that all the essential properties of Entity must be create when an object create
    /// this constructor is usefull when working with ORMs
    /// سازنده پیش‌فرض به صورت Protected تعریف شده است.
    /// با توجه به اینکه این نیاز است هنگام ساخت خواص اساسی Entity ایجاد شود، هیچ شی بدون پر کردن این خواص نباید ایجاد شود.
    /// بار جلو گیری از این مورد برای همه Entityها باید سازنده‌هایی تعریف شود که مقدار ورودی دارند.
    /// برای اینکه بتوان از همین Entityها برای فرایند ذخیره سازی و بازیابی از دیتابیس به کمک ORMها استفاده کرد، ضروری است که سازنده پیش‌فرض با سطح دسترسی بالا مثل Protected یا Private ایجاد شود.
    /// </summary>
    protected Entity() { }


    #region Equality Check
    public bool Equals(Entity? other) => this == other;
    public override bool Equals(object? obj) =>
         obj is Entity otherObject && Id == otherObject.Id;

    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
        => !(right == left);

    #endregion
}