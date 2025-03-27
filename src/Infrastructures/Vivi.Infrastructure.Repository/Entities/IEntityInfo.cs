namespace Vivi.Infrastructure.Entities;

public interface IEntityInfo
{
    void OnModelCreating(dynamic modelBuilder);
}