using Earth.Events.Outbox.Interceptors;
using Earth.Infra.Data.Sql.Commands;
using Earth.Infra.Data.Sql.Commands.OutBoxEventItems;
using Microsoft.EntityFrameworkCore;

namespace Earth.Events.Outbox;

public class BaseOutboxcommandDbContext:BaseCommandDbContext
{
    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

    public BaseOutboxcommandDbContext()
    {
        
    }

    public BaseOutboxcommandDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(new AddOutBoxEventItemInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new OutBoxEventItemConfig());
    }
}