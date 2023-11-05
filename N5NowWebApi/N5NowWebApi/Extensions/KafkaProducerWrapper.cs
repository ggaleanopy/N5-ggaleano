using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace N5NowWebApi.Extensions
{
    public class KafkaProducerWrapper : IKafkaProducerWrapper
    {
        private IProducer<string, string> producer;
        private string defaultTopic;

        //public KafkaProducerWrapper(string bootstrapServers, string defaultTopic)
        public KafkaProducerWrapper(IConfiguration configuration)
        {
            var config = new ProducerConfig { BootstrapServers = configuration["KafkaConfiguration:url"] };
            this.producer = new ProducerBuilder<string, string>(config).Build();
            this.defaultTopic = configuration["KafkaConfiguration:topic"];
        }

        public async Task ProduceAsync(string message)
        {
            // Envía el mensaje al tema predeterminado
            await producer.ProduceAsync(defaultTopic, new Message<string, string> { Value = message });
        }

        public void Dispose()
        {
            producer.Dispose();
        }
    }
}
