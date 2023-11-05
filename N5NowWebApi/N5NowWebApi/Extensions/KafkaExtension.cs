using Confluent.Kafka;
using Domain;

namespace N5NowWebApi.Extensions
{
    public static class KafkaExtension
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["KafkaConfiguration:url"];
            var client = configuration["KafkaConfiguration:client"];
            var topic = configuration["KafkaConfiguration:topic"];

            ProducerConfig config = new ProducerConfig
            {
                BootstrapServers = url,
                ClientId = client,
            };

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings
                .DefaultMappingFor<Permission>(m => m);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<Permission>(x => x.AutoMap())
            );
        }
    }
}
