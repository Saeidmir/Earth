namespace Earth.Extension.Abstractions.ObjectMapper;
public interface IMapperAdapter
{
    TDestination Map<TSource, TDestination>(TSource source);
}
