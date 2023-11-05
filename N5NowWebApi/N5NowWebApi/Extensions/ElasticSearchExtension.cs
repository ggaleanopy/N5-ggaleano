using Nest;
using Domain;

namespace N5NowWebApi.Extensions
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ELKConfiguration:url"];
            var defaultIndex = configuration["ELKConfiguration:index"];
            //var userName = configuration["ELKConfiguration:userName"];
            //var pass = configuration["ELKConfiguration:pass"];

            var settings = new ConnectionSettings(new Uri(url))
                //.ServerCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) => true) // Permite todos los certificados, no es seguro en producción
                //.BasicAuthentication(userName, pass)
                .PrettyJson()
                .DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

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
