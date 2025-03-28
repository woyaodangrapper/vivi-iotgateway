using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vivi.SharedKernel.Repository.EfEntities.Config;

namespace Vivi.Dcs.Entities;

public class EntityInfo : AbstracSharedEntityInfo
{
    protected override Assembly GetCurrentAssembly() => GetType().Assembly;

    protected override void SetTableName(dynamic modelBuilder)
    {
        if (modelBuilder is not ModelBuilder builder)
            throw new ArgumentNullException(nameof(modelBuilder));
        builder.Entity<SmartDeviceEntity>().ToTable("smart_device");
    }
}

