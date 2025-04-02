using NLog;
using NLog.Web;
using Vivi.Infrastructure.Core;
using Vivi.SharedKernel.Const.AppSettings;

namespace Vivi.SharedKernel.Application.Extensions;

public static class WebApplicationBuilderExtension
{
    /// <summary>
    /// Configure Configuration/ServiceCollection/Logging/AOP
    /// <param name="builder"></param>
    /// <param name="serviceInfo"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static WebApplicationBuilder Default(this WebApplicationBuilder builder, IServiceInfo serviceInfo)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(serviceInfo);
        LogManager.Setup().LoadConfigurationFromAppSettings();

        // Add Default Configuration
        builder.Configuration.AddInMemoryCollection([new("ServiceName", serviceInfo.ServiceName)]);

        OnSettingConfigurationChanged(builder.Configuration);

        //ServiceCollection
        builder.Services.ReplaceConfiguration(builder.Configuration);
        builder.Services.AddSingleton(typeof(IServiceInfo), serviceInfo);
        builder.Services.AddVivi(serviceInfo);


        //Logging
        builder.Logging.ClearProviders();
        var logContainer = builder.Configuration.GetValue(NodeConsts.Logging_LogContainer, "console");
        LogManager.Setup().LoadConfigurationFromFile($"{AppContext.BaseDirectory}/ApiService/NLog/nlog-{logContainer}.config");
        builder.Host.UseNLog();
        return builder;
    }

    /// <summary>
    /// replace placeholder
    /// </summary>
    /// <param name="sections"></param>
    private static void ReplacePlaceholder(IEnumerable<IConfigurationSection> sections)
    {
        var serviceInfo = ServiceInfo.GetInstance();
        foreach (var section in sections)
        {
            var childrenSections = section.GetChildren();
            if (childrenSections.IsNotNullOrEmpty())
                ReplacePlaceholder(childrenSections);

            if (section.Value.IsNullOrWhiteSpace())
                continue;

            var sectionValue = section.Value;
            if (sectionValue.Contains("$SERVICENAME"))
                section.Value = sectionValue.Replace("$SERVICENAME", serviceInfo.ServiceName);

            if (sectionValue.Contains("$SHORTNAME"))
                section.Value = sectionValue.Replace("$SHORTNAME", serviceInfo.ShortName);
        }
    }

    /// <summary>
    /// Register Cofiguration ChangeCallback
    /// </summary>
    /// <param name="state"></param>
    private static IDisposable _callbackRegistration;

    private static void OnSettingConfigurationChanged(object state)
    {
        _callbackRegistration?.Dispose();
        var configuration = state as IConfiguration;
        var changedChildren = configuration.GetChildren();
        var reloadToken = configuration.GetReloadToken();

        ReplacePlaceholder(changedChildren);

        _callbackRegistration = reloadToken.RegisterChangeCallback(OnSettingConfigurationChanged, state);
    }
}