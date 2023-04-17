using Earth.Caching.Distributed.Redis.Options;
using Earth.Caching.Distributed.Redis.Services;
using Earth.Extension.Abstractions.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Earth.Caching.Distributed.Redis.Extensions.DependencyInjection;

public static class DistributedRedisCacheServiceCollectionExtensions
{
    public static IServiceCollection AddProjectRedisDistributedCache(this IServiceCollection services,
                                                                   IConfiguration configuration,
                                                                   string sectionName)
        => services.AddProjectRedisDistributedCache(configuration.GetSection(sectionName));

    public static IServiceCollection AddProjectRedisDistributedCache(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICahceAdapter.ICacheAdapter, DistributedRedisCacheAdapter>();
        services.Configure<DistributedRedisCacheOptions>(configuration);

        var option = configuration.Get<DistributedRedisCacheOptions>();

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = option.Configuration;
            options.InstanceName = option.InstanceName;
        });

        return services;
    }

    public static IServiceCollection AddProjectRedisDistributedCache(this IServiceCollection services,
                                                              Action<DistributedRedisCacheOptions> setupAction)
    {
        services.AddTransient<ICahceAdapter.ICacheAdapter, DistributedRedisCacheAdapter>();
        services.Configure(setupAction);

        var option = new DistributedRedisCacheOptions();
        setupAction.Invoke(option);

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = option.Configuration;
            options.InstanceName = option.InstanceName;
        });

        return services;
    }
}