using Microsoft.EntityFrameworkCore;
using Vivi.SharedKernel;
using Vivi.SharedKernel.Repository.EfEntities;
using System.Reflection;

namespace Vivi.Dcs.Entities;

public class EntityInfo : AbstracSharedEntityInfo
{
    public EntityInfo(UserContext userContext) : base(userContext)
    {
    }

    protected override Assembly GetCurrentAssembly() => GetType().Assembly;

    protected override void SetTableName(dynamic modelBuilder)
    {
        if (modelBuilder is not ModelBuilder builder)
            throw new ArgumentNullException(nameof(modelBuilder));
        builder.Entity<SysHello>().ToTable("sys_hello");
    }
}