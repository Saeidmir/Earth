namespace Earth.Core.Domain.Exceptions;
/// <summary>
/// The error about Domain layer, Enitites, Value objects are sent to higher layers.
/// due to the fact that entity and value objects send the error with the same example, a class for exception is designed.
/// for recognition of different between erros and the location the MicroType pattern was used...MSM
/// </summary>



public abstract class DomainStateException : Exception
{
    /// <summary>
    /// The parameter list.if any parameter, send message like pattern and the paramter should be place on the pattern...MSM 
    /// </summary>
    public string[] Parameters { get; set; }

    public DomainStateException(string message, params string[] parameters) : base(message)
    {

        Parameters = parameters;

    }

    public override string ToString()
    {
        if (Parameters?.Length < 1)
        {
            return Message;
        }
        string result = Message;

        for (int i = 0; i < Parameters.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            result = result.Replace(placeHolder, Parameters[i]);
        }

        return result;
    }
}
