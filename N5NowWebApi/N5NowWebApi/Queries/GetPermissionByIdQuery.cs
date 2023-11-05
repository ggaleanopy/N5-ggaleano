using Domain;
using MediatR;

namespace N5NowWebApi.Queries
{
    public class GetPermissionByIdQuery : IRequest<Permission>
    {
        public int Id { get; set; }
    }
}
