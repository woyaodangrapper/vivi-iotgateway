namespace Vivi.Infrastructure.Repository.EfCore.PostgreSQL.Transaction;

public class PostgreSQLUnitOfWork<TDbContext> : UnitOfWork<TDbContext>
    where TDbContext : PostgreSQLDbContext
{
    private ICapPublisher? _publisher;

    public PostgreSQLUnitOfWork(
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