using DataAccessEF.TypeRepository;
using Domain;
using Domain.Interfaces;
using MediatR;
using N5NowWebApi.Extensions;
using N5NowWebApi.Queries;
using Nest;
using System.Numerics;

namespace N5NowWebApi.Handlers
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdQuery, Permission>
    {
        private const string KAFKA_GUID = "-Id: {0}";
        private const string KAFKA_OPERATION = "-Name operation: get";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IElasticClient _elasticClient;
        private readonly IKafkaProducerWrapper _producer;

        public GetPermissionByIdHandler(IUnitOfWork unitOfWork, IElasticClient elasticClient, IKafkaProducerWrapper producer)
        {
            _unitOfWork = unitOfWork;
            _elasticClient = elasticClient;
            _producer = producer;
        }

        Task<Permission> IRequestHandler<GetPermissionByIdQuery, Permission>.Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            Permission permission = _unitOfWork.Permission.GetPermissionById(request.Id);
            _elasticClient.IndexDocumentAsync(permission);
            this.WriteMessagesToKafka();
            return Task.FromResult(permission);
        }

        private void WriteMessagesToKafka()
        {
            _producer.ProduceAsync(String.Format(KAFKA_GUID, Guid.NewGuid()));
            _producer.ProduceAsync(KAFKA_OPERATION);
        }
    }
}
