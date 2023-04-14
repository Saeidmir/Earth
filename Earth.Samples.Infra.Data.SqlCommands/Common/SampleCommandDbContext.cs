using Earth.Infra.Data.Sql.Commands;
using Microsoft.EntityFrameworkCore;

namespace Earth.Samples.Infra.Data.SqlCommands.Common;

public class SampleCommandDbContext:BaseCommandDbContext
{
    public SampleCommandDbContext(DbContextOptions<SampleCommandDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}