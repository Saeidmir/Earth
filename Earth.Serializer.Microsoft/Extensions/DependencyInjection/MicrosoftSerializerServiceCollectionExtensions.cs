using Earth.Extension.Abstractions.Serializer;
using Earth.Serializer.Microsoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Earth.Serializer.Microsoft.Extensions.DependencyInjection;

public static class MicrosoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddProjectMicrosoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
}
