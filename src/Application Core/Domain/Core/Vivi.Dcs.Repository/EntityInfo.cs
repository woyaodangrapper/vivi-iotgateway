using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vivi.Dcs.Entities;
using Vivi.SharedKernel.Repository.EfEntities.Config;

namespace Vivi.Dcs.Repository;

public class EntityInfo : AbstracSharedEntityInfo
{
    protected override Assembly GetCurrentAssembly() => GetType().Assembly;

    protected override void SetTableName(dynamic modelBuilder)
    {
        if (modelBuilder is not ModelBuilder builder)
            throw new ArgumentNullException(nameof(modelBuilder));

        builder.Entity<DeviceEntity>().ToTable("device");
        builder.Entity<UnitCapabEntity>().ToTable("unit_capab");
        builder.Entity<DeviceUnitEntity>().ToTable("device_unit");
        builder.Entity<UnitRecordsEntity>().ToTable("unit_records");
        builder.Entity<UnitCapabMapEntity>().ToTable("unit_capab_map");
        // 列名规则已在 Vivi.Infrastructure.Repository.EfCore.* 配置，这里无需重复。如需表名规则，可在此配置。
        // builder.ApplyColumnNamingConvention(); or  MapEntityAsColumn
    }
}