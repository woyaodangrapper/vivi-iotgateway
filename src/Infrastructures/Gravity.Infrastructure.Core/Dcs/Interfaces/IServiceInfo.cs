namespace Gravity.Infrastructure.Core.Interfaces;

public interface IServiceInfo
{
    /// <summary>
    /// servername-xxx-apiService-188933
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// servername-xxx-apiService
    /// </summary>
    public string ServiceName { get; }

    /// <summary>
    /// corsPolicy
    /// </summary>
    public string CorsPolicy { get; set; }

    /// <summary>
    ///  usr or maint or cus or xxx
    /// </summary>
    public string ShortName { get; }

    /// <summary>
    /// 0.9.2.xx
    /// </summary>
    public string Version { get; }

    /// <summary>
    /// description
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// assembly  of start's project
    /// </summary>
    public Assembly StartAssembly { get; }
}