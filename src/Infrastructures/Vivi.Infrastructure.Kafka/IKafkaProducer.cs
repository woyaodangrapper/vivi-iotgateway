namespace Vivi.Infrastructure.Kafka
{
    public interface IKafkaProducer
    {
        Task ProduceMessageAsync(string message, string topic);
    }

    public interface IKafkaConsumer
    {
        void ConsumeMessage(string topic);
    }
}
