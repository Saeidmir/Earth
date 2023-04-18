using Earth.Extension.Abstractions.MessageBus;
using Earth.MessageBus.MessageInbox.Dal.Dapper.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Earth.MessageBus.MessageInbox.Dal.Dapper.Extensions.DependencyInjection;

public static class MessageInboxServiceCollectionExtensions
{
    public static IServiceCollection AddProjectMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MessageInboxDalDapperOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddProjectMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddProjectMessageInboxDalSql(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddProjectMessageInboxDalSql(this IServiceCollection services, Action<MessageInboxDalDapperOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IMessageInboxItemRepository, SqlMessageInboxItemRepository>();
    }
}