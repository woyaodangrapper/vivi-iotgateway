using Vivi.Infrastructure.Kafka;
using Vivi.Infrastructure.Kafka.Configurations;
using Vivi.Infrastructure.Kafka.Consumer;
using Vivi.Infrastructure.Kafka.Producer;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfraKafka(this IServiceCollection services, IConfigurationSection KafkaSection)
    {
        if (services.HasRegistered(nameof(AddInfraKafka)))
            return services;
        services.Configure<KafkaOptions>(KafkaSection);

        services.AddSingleton<IKafkaProducer, KafkaProducer>();
        services.AddSingleton<IKafkaConsumer, KafkaConsumer>();

        return services;
    }

}