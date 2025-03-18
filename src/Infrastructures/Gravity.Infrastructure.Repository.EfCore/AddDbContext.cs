namespace Gravity.Infrastructure.Repository.EfCore;

public abstract class AddDbContext : DbContext
{
    private readonly IEntityInfo _entityInfo;

    protected AddDbContext(DbContextOptions options, IEntityInfo entityInfo)
        : base(options)
    {
        _entityInfo = entityInfo;
        Database.AutoTransactionsEnabled = false;
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //没有自动开启事务的情况下,保证主从表插入，主从表更新开启事务。
        var isManualTransaction = false;
        if (!Database.AutoTransactionsEnabled && Database.CurrentTransaction is null)
        {
            isManualTransaction = true;
            Database.AutoTransactionsEnabled = true;
        }

        var result = base.SaveChangesAsync(cancellationToken);

        //如果手工开启了自动事务，用完后关闭。
        if (isManualTransaction)
            Database.AutoTransactionsEnabled = false;

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => _entityInfo.OnModelCreating(modelBuilder);

}