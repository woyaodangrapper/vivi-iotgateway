namespace Gravity.Infrastructure.Entities;

public interface IEntityInfo
{
    void OnModelCreating(dynamic modelBuilder);
}