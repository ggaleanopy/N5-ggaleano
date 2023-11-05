using Domain;
using Domain.Interfaces;
using MediatR;
using N5NowWebApi.Commands;
using N5NowWebApi.Extensions;
using Nest;

namespace N5NowWebApi.Handlers
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, Permission>
    {
        private const string KAFKA_GUID = "-Id: {0}";
        private const string KAFKA_OPERATION = "-Name operation: modify";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticClient _elasticClient;
        private readonly IKafkaProducerWrapper _producer;

        public UpdatePermissionHandler(IUnitOfWork unitOfWork, IElasticClient elasticClient, IKafkaProducerWrapper producer)
        {
            _unitOfWork = unitOfWork;
            _elasticClient = elasticClient;
            _producer = producer;
        }
        public  Task<Permission> Handle(UpdatePermissionCommand command, CancellationToken cancellationToken)
        {
            var permission = new Permission()
            {
                Id = command.Id,
                NombreEmpleado = command.NombreEmpleado,
                ApellidoEmpleado= command.ApellidoEmpleado,
                TipoPermiso= command.TipoPermiso,
                FechaPermiso= command.FechaPermiso
            };

            var result = _unitOfWork.Permission.UpdatePermission(permission);
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
