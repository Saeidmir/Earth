using Earth.Infra.Data.Sql.Queries;
using Microsoft.EntityFrameworkCore;

namespace Earth.Samples.Infra.Data.SqlQueries.Common;

public class SampleQueryDbContext:BaseQueryDbContext
{
    public SampleQueryDbContext(DbContextOptions options) : base(options)
    {
    }
}