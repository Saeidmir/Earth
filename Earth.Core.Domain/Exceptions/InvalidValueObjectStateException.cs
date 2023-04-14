namespace Earth.Core.Domain.Exceptions;

/// <summary>
/// Ther error can raise about falsy situration of a value objet...MSM 
/// </summary>
/// <param name="message">The message or the pattern</param>
/// <param name="parameters">The parameters to be replaced</param>
public class InvalidValueObjectStateException : DomainStateException
{
    public InvalidValueObjectStateException(string message, params string[] parameters) : base(message)
    {
        Parameters = parameters;
    }
}
