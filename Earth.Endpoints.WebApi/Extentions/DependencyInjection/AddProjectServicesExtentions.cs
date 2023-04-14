using Earth.Utilities;
using Zamin.Extensions.Logger.Abstractions;

namespace Earth.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddProjectServicesExtentions
{
    public static IServiceCollection AddProjectUntilityServices(
        this IServiceCollection services)
    {

        services.AddScoped<IScopeInformation, ScopeInformation>();
        services.AddTransient<EarthAttachedServices>();
        return services;
    }

}

