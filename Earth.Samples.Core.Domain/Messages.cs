using Earth.Samples.Core.Domain.People.ValueObjects;

namespace Earth.Samples.Core.Domain;

public class Messages
{
    public static string InvalidNullValue = "The value of {0} should be null or whitespace";
    public static string InvalidStringLength = "The length of {0} should be between {1} -- {2}";
    public static string InvalidNumberValueRange = "The value of {0} should not be less than {1}";
    public static string FirstName = nameof(FirstName);
    public static string LastName = nameof(LastName);
}