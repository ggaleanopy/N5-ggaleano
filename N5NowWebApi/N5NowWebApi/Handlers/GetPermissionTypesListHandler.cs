using DataAccessEF.TypeRepository;
using Domain;
using Domain.Interfaces;
using MediatR;
using N5NowWebApi.Queries;
using System.Numerics;

namespace N5NowWebApi.Handlers
{
    public class GetPermissionTypesListHandler : IRequestHandler<GetPermissionTypesListQuery, List<PermissionType>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionTypesListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        Task<List<PermissionType>> IRequestHandler<GetPermissionTypesListQuery, List<PermissionType>>.Handle(GetPermissionTypesListQuery request, CancellationToken cancellationToken)
        {
            List<PermissionType> permissionTypes = _unitOfWork.PermissionType.GetPermissionTypes();
            return Task.FromResult(permissionTypes);
        }
    }
}
