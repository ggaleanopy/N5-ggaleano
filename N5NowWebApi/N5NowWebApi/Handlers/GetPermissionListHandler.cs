using DataAccessEF.TypeRepository;
using Domain;
using Domain.Interfaces;
using MediatR;
using N5NowWebApi.Queries;
using System.Numerics;

namespace N5NowWebApi.Handlers
{
    public class GetPermissionListHandler : IRequestHandler<GetPermissionListQuery, List<Permission>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        Task<List<Permission>> IRequestHandler<GetPermissionListQuery, List<Permission>>.Handle(GetPermissionListQuery request, CancellationToken cancellationToken)
        {
            List<Permission> permissions = _unitOfWork.Permission.GetPermissions();
            return Task.FromResult(permissions);
        }
    }
}
