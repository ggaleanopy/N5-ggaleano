using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain;
using N5NowWebApi.Queries;
using N5NowWebApi.Commands;
using Nest;

namespace N5NowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : Controller
    {
        private readonly IMediator mediator;
        
        public PermissionTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<List<PermissionType>> GetPermissionTypes()
        {
            var permissionTypes = mediator.Send(new GetPermissionTypesListQuery());
            return permissionTypes;
        }

        [HttpPost]
        public Task<PermissionType> AddPermissionType(PermissionType permissionType)
        {
            var _permissionType = mediator.Send(new CreatePermissionTypeCommand(
                permissionType.Descripcion));
            return _permissionType;
        }
    }
}
