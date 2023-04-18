using Earth.Extension.Abstractions.Serializer;
using Earth.Serializer.EPPlus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Earth.Serializer.EPPlus.Extensions.DependencyInjection;

public static class EPPlusExcelSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}