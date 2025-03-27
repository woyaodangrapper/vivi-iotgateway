namespace Vivi.Infrastructure.Repository.EfCore.PostgreSQL;

public class PostgreSQLDbContext : AddDbContext
{
    public PostgreSQLDbContext(
        DbContextOptions options,
        IEntityInfo entityInfo)
        : base(options, entityInfo)
    {
    }
}