namespace Vivi.Infrastructure.Kafka.Configurations;

/// <summary>
/// KafkaConfig Configurations
/// </summary>
public class KafkaOptions
{
    public string BootstrapServers { get; set; }
    public string ConsumerGroup { get; set; }
    public int MessageTimeoutMs { get; set; } = 30000;
    public bool EnableAutoCommit { get; set; } = true;
    public string KafkaTopic { get; set; }
}