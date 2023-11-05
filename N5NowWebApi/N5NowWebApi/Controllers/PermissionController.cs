using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain;
using N5NowWebApi.Queries;
using N5NowWebApi.Commands;

namespace N5NowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IMediator mediator; 

        public PermissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<List<Permission>> GetPermissions()
        {
            var permissions = mediator.Send(new GetPermissionListQuery());
            return permissions;
        }

        [HttpGet("permissionId")]
        public Task<Permission> GetPermissionById(int permissionId)
        {
            var permission = mediator.Send(new GetPermissionByIdQuery() { Id = permissionId });
            return permission;
        }

        [HttpPost]
        public Task<Permission> RequestPermission(Permission permission)
        {
            var _permission = mediator.Send(new CreatePermissionCommand(
                permission.NombreEmpleado,
                permission.ApellidoEmpleado,
                permission.TipoPermiso,
                permission.FechaPermiso));
            return _permission;
        }

        [HttpPut]
        public Task<Permission> ModifyPermission(Permission permission)
        {
            var _permission = mediator.Send(new UpdatePermissionCommand(
                permission.Id,
                permission.NombreEmpleado,
                permission.ApellidoEmpleado,
                permission.TipoPermiso,
                permission.FechaPermiso));
            return _permission;
        }
    }
}
