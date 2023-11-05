using Domain;
using Domain.Interfaces;
using MediatR;
using N5NowWebApi.Commands;
using N5NowWebApi.Extensions;
using Nest;

namespace N5NowWebApi.Handlers
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, Permission>
    {
        private const string KAFKA_GUID = "-Id: {0}";
        private const string KAFKA_OPERATION = "-Name operation: request";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticClient _elasticClient;
        private readonly IKafkaProducerWrapper _producer;

        public CreatePermissionHandler(IUnitOfWork unitOfWork, IElasticClient elasticClient, IKafkaProducerWrapper producer)
        {
            _unitOfWork = unitOfWork;
            _elasticClient = elasticClient;
            _producer = producer;
        }
        public  Task<Permission> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
        {
            var permission = new Permission()
            {
                NombreEmpleado = command.NombreEmpleado,
                ApellidoEmpleado= command.ApellidoEmpleado,
                TipoPermiso= command.TipoPermiso,
                FechaPermiso= command.FechaPermiso
            };

            var result = _unitOfWork.Permission.AddPermission(permission);
            _unitOfWork.Save();
            _elasticClient.IndexDocumentAsync(permission);
            this.WriteMessagesToKafka();
            return Task.FromResult(result);
        }

        private void WriteMessagesToKafka()
        {
            _producer.ProduceAsync(String.Format(KAFKA_GUID, Guid.NewGuid()));
            _producer.ProduceAsync(KAFKA_OPERATION);
        }
    }
}
