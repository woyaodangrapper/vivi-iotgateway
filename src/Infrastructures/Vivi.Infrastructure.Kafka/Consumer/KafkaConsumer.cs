using Confluent.Kafka;
using Vivi.Infrastructure.Kafka.Configurations;

namespace Vivi.Infrastructure.Kafka.Consumer
{
    public class KafkaConsumer : IKafkaConsumer
    {
        private readonly IConsumer<Ignore, string> _consumer;

        public KafkaConsumer(KafkaOptions kafkaOptions)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaOptions.BootstrapServers,
                GroupId = kafkaOptions.ConsumerGroup,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }

        public void ConsumeMessage(string topic)
        {
            _consumer.Subscribe(topic);

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(cts.Token);
                        // 处理消息
                        Console.WriteLine($"Consumed message: {consumeResult.Message.Value}");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // 取消消费
                _consumer.Close();
            }
        }

        public void Dispose()
        {
            _consumer?.Dispose();
        }
    }
}