namespace Earth.Core.Domain.Exceptions;

public class InvalidEntityStateException : DomainStateException
{
    /// <summary>
    /// When entity is in an invalid state the error can be raised...MSM
    /// <param name="message"> the message or the design of a message</param>
    /// <param name="parameters"> the parameters are replaced if the message pattern is used</param>
    /// </summary>
    public InvalidEntityStateException(string message, params string[] parameters) : base(message)
    {
        Parameters = parameters;
    }
}
