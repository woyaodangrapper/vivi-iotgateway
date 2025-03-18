namespace SanGu.Infrastructure.Repository.EfCore.SqlServer;

public class SqlServerDbContext : AddDbContext
{
    public SqlServerDbContext(
        DbContextOptions options,
        IEntityInfo entityInfo)
        : base(options, entityInfo)
    {
    }
}