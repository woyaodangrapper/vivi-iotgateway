namespace Vivi.Infrastructure.Repository.EfCore.TimescaleDB.Transaction;

public class TimescaleDBUnitOfWork<TDbContext> : UnitOfWork<TDbContext>
    where TDbContext : TimescaleDBContext
{
    private ICapPublisher? _publisher;

    public TimescaleDBUnitOfWork(
        TDbContext context
        , ICapPublisher? publisher = null)
        : base(context)
    {
        _publisher = publisher;
    }

    protected override IDbContextTransaction GetDbContextTransaction(
        IsolationLevel isolationLevel = IsolationLevel.ReadCommitted
        , bool distributed = false)
    {
        if (distributed)
            if (_publisher is null)
                throw new ArgumentException("CapPublisher is null");
            else
                return DcsDbContext.Database.BeginTransaction(_publisher, false);
        else
            return DcsDbContext.Database.BeginTransaction(isolationLevel);
    }
}