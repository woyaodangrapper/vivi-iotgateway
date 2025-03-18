namespace Gravity.SharedKernel.Application.Registrar;

public abstract partial class AbstractApplicationDependencyRegistrar
{
    /// <summary>
    /// 注册EFCoreContext与仓储
    /// </summary>
    protected virtual void AddEfCoreContextWithRepositories()
    {
        var serviceType = typeof(IEntityInfo);
        var implType = RepositoryOrDomainLayerAssembly.ExportedTypes.FirstOrDefault(type => type.IsAssignableTo(serviceType) && type.IsNotAbstractClass(true));
        if (implType is null)
            throw new NotImplementedException(nameof(IEntityInfo));
        else
            Services.AddScoped(serviceType, implType);

        AddEfCoreContext();
    }

    /// <summary>
    /// 注册EFCoreContext
    /// </summary>
    protected virtual void AddEfCoreContext()
    {
        Services.AddDcsInfraEfCoreSQLServer(SqlServerSection);

        //var mysqlConfig = MysqlSection.Get<MysqlOptions>();
        //var serverVersion = new MariaDbServerVersion(new Version(10, 5, 4));
        //Services.AddDcsInfraEfCoreMySql(options =>
        //{
        //    options.UseLowerCaseNamingConvention();
        //    options.UseMySql(mysqlConfig.ConnectionString, serverVersion, optionsBuilder =>
        //    {
        //        var startAssemblyName = ServiceInfo.StartAssembly.GetName().Name;
        //        if (startAssemblyName is null)
        //            throw new NullReferenceException("StartAssembly Name is null");
        //        else
        //        {
        //            var migrationsAssemblyName = startAssemblyName.Replace("WebApi", "Migrations");
        //            optionsBuilder.MinBatchSize(4)
        //                                    .MigrationsAssembly(migrationsAssemblyName)
        //                                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        //        }
        //    });
        //    //if (this.IsDevelopment())
        //    //{
        //    //    //options.AddInterceptors(new DefaultDbCommandInterceptor())
        //    //    options.LogTo(Console.WriteLine, LogLevel.Information)
        //    //                .EnableSensitiveDataLogging()
        //    //                .EnableDetailedErrors();
        //    //}
        //    //替换默认查询sql生成器,如果通过mycat中间件实现读写分离需要替换默认SQL工厂。
        //    //options.ReplaceService<IQuerySqlGeneratorFactory, DcsMySqlQuerySqlGeneratorFactory>();
        //});
    }

}