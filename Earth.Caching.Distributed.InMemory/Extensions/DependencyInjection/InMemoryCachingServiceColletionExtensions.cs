using Earth.Caching.Distributed.InMemory.Services;
using Earth.Extension.Abstractions.Caching;
using Microsoft.Extensions.DependencyInjection;

namespace Earth.Caching.Distributed.InMemory.Extensions.DependencyInjection;

public static class InMemoryCachingServiceCollectionExtensions
{
    public static IServiceCollection AddProjectMemoryCaching(this IServiceCollection services)
        => services.AddMemoryCache().AddTransient<ICahceAdapter.ICacheAdapter, InMemoryCacheAdapter>();

}