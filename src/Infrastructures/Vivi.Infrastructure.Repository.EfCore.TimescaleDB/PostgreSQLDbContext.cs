namespace Vivi.Infrastructure.Repository.EfCore.TimescaleDB;

public class PostgreSQLDbContext : AddDbContext
{
    public PostgreSQLDbContext(
        DbContextOptions options,
        IEntityInfo entityInfo)
        : base(options, entityInfo)
    {
    }
}