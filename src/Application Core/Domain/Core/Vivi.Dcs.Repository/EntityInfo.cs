using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using System.Text.Json.Nodes;
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

        JsonObject? test = null;



        builder.Entity<AreaEntity>().ToTable("area").Property(e => e.Position)
        .HasConversion(new JsonObjectConverter())
        .HasColumnType("jsonb");

        builder.Entity<DeviceEntity>().ToTable("device");
        builder.Entity<UnitCapabEntity>().ToTable("unit_capab");
        builder.Entity<DeviceUnitEntity>().ToTable("device_unit");
        builder.Entity<UnitRecordsEntity>().ToTable("unit_records");
        builder.Entity<UnitCapabMapEntity>().ToTable("unit_capab_map");
        // 列名规则已在 Vivi.Infrastructure.Repository.EfCore.* 配置，这里无需重复。如需表名规则，可在此配置。
        //builder.ApplyColumnNamingConvention(); or MapEntityAsColumn
    }


}



public class JsonObjectConverter : ValueConverter<JsonNode?, string?>
{
    public JsonObjectConverter() : base(
        v => v == null ? null : ToString(v),
        v => string.IsNullOrEmpty(v) ? null : ToObject(v)
    )
    { }

    // 写入数据库时：JsonObject → string
    protected static string ToString(JsonNode v)
     => v.ToJsonString();


    // 从数据库读取时：string → JsonObject
    protected static JsonNode ToObject(string v)
    => JsonNode.Parse(v, null)!.AsObject();

}
