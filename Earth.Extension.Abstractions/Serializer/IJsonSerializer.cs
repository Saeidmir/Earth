namespace Earth.Extension.Abstractions.Serializer;

public interface IJsonSerializer
{
    string Serialize<TInput>(TInput input);
    TOutput Deserialize<TOutput>(string input);
    object Deserialize(string input, Type type);
}

