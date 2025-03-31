namespace Vivi.Infrastructure.Repository.EfCore.TimescaleDB;

public class TimescaleDBContext : AddDbContext
{
    public TimescaleDBContext(
        DbContextOptions options,
        IEntityInfo entityInfo)
        : base(options, entityInfo)
    {
    }
}