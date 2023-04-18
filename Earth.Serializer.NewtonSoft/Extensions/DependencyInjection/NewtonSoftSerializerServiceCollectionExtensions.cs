using Earth.Extension.Abstractions.Serializer;
using Earth.Serializer.NewtonSoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Earth.Serializer.NewtonSoft.Extensions.DependencyInjection;

public static class NewtonSoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddProjectNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();
}