using Vivi.Infrastructure.Core.Guard;
using Vivi.SharedKernel.Const.AppSettings;

namespace Microsoft.Extensions.DependencyInjection;
/**
 * 健康检查
 * **/
public static class HealthChecksBuilderExtension
{
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, Action<IHealthChecksBuilder> setupAction)
    {
        Checker.Argument.IsNotNull(setupAction, nameof(Action<IHealthChecksBuilder>));

        setupAction?.Invoke(services.AddHealthChecks());

        return services;
    }

    public static IHealthChecksBuilder AddKafka(this IHealthChecksBuilder checksBuilder, IConfiguration configuration)
    {
        // topic: "health-check-topic", // 指定 Kafka 主题
        // name: "kafka-check", // 健康检查名称
        // failureStatus: HealthStatus.Unhealthy, // 失败时的状态
        // tags: new[] { "kafka", "messaging" }, // 额外的标签
        // timeout: TimeSpan.FromSeconds(5)
        Checker.Argument.IsNotNull(configuration, nameof(IConfiguration));
        var kafkalConfig = configuration.GetSection(NodeConsts.Kafka).Get<Vivi.Infrastructure.Kafka.Configurations.KafkaOptions>() ?? throw new InvalidOperationException("Kafka 配置不存在，请检查 `appsettings.json`");
        return checksBuilder.AddKafka(provider =>
        {
            provider.BootstrapServers = kafkalConfig.BootstrapServers;

        });

    }

}
