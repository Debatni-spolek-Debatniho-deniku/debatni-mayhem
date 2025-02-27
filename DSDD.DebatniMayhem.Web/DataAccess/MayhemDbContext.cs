using Microsoft.EntityFrameworkCore;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public partial class MayhemDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new ReadOnlyInterceptor());

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}