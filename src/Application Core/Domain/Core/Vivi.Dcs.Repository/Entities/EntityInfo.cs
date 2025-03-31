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
        builder.Entity<SensorCapabilityEntity>().ToTable("sensor_capability");
        builder.Entity<SensorCapabilityMapEntity>().ToTable("sensor_capability_map");
        builder.Entity<SensorDataEntity>().ToTable("sensor_data");
        builder.Entity<SmartDeviceEntity>().ToTable("smart_device");
        builder.Entity<SmartDeviceSensorEntity>().ToTable("smart_device_sensor");
    }
}

