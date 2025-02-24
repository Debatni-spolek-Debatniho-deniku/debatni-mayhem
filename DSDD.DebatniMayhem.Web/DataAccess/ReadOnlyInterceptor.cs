using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public class ReadOnlyInterceptor: ISaveChangesInterceptor
{
    public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        throw new NotImplementedException("This DB context is read-only!");
    }

    public ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException("This DB context is read-only!");
    }
}