using Earth.Core.Domain.Exceptions;

namespace Earth.Core.Domain.ValueObjects;
/// <summary>
/// We send this businessId to all value object, because our entity can transact between services, when we use this id
/// we have not any concern about id in different database, another point is about events. in some situation we need Id and
/// our data not saved in db, hence we use businessI rather than snowflake or another tools.
/// <value>Guid businessId</value>
/// </summary>
public class BusinessId : BaseValueObject<BusinessId>
{
    public static BusinessId FromString(string value) => new(value);
    public static BusinessId FromGuid(Guid value) => new() { Value = value };

    public BusinessId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(BusinessId));
        }
        if (Guid.TryParse(value, out Guid tempValue))
        {
            Value = tempValue;
        }
        else
        {
            throw new InvalidValueObjectStateException("ValidationErrorInvalidValue", nameof(BusinessId));
        }
    }
    private BusinessId()
    {

    }

    public Guid Value { get; private set; }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator string(BusinessId title) => title.Value.ToString();
    public static implicit operator BusinessId(string value) => new(value);


    public static explicit operator Guid(BusinessId title) => title.Value;
    public static implicit operator BusinessId(Guid value) => new() { Value = value };

}