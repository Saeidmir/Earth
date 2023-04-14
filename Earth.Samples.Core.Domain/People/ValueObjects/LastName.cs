using Earth.Core.Domain.Exceptions;
using Earth.Core.Domain.ValueObjects;

namespace Earth.Samples.Core.Domain.People.ValueObjects;

public class LastName:BaseValueObject<LastName>
{
    public string Value { get; set; }

    public LastName(string value)
    {
        value = value.Trim();
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidValueObjectStateException(Messages.InvalidNullValue, Messages.LastName);
        if(value.Length<2 || value.Length > 50)
            throw new InvalidValueObjectStateException(Messages.InvalidStringLength, Messages.LastName, "2", "50");
        Value = value;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}