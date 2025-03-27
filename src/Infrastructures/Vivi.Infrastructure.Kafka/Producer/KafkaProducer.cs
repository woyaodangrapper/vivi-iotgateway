using Confluent.Kafka;
using Vivi.Infrastructure.Kafka.Configurations;

namespace Vivi.Infrastructure.Kafka.Producer
{

    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(KafkaOptions kafkaOptions)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaOptions.BootstrapServers
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceMessageAsync(string message, string topic)
        {
            try
            {
                await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
            }
            catch (ProduceException<Null, string> e)
            {
                // 错误处理
                Console.WriteLine($"Error producing message: {e.Message}");
            }
        }

        public void Dispose()
        {
            _producer?.Dispose();
        }
    }

}
