using Domain;
using Domain.Interfaces;
using MediatR;
using N5NowWebApi.Commands;

namespace N5NowWebApi.Handlers
{
    public class CreatePermissionTypeHandler : IRequestHandler<CreatePermissionTypeCommand, PermissionType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePermissionTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public  Task<PermissionType> Handle(CreatePermissionTypeCommand command, CancellationToken cancellationToken)
        {
            var permissionType = new PermissionType()
            {
                Descripcion = command.Description
            };

            var result = _unitOfWork.PermissionType.AddPermissionType(permissionType);
            _unitOfWork.Save();
            return Task.FromResult(result);
        }
    }
}
