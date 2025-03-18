namespace Gravity.Infrastructure.Repository.EfCore.MySql.Configurations;

/// <summary>
/// MysqlConfig配置
/// </summary>
public class MysqlOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}

/// <summary>
/// SqlServerlConfig配置
/// </summary>
public class SqlServerOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}