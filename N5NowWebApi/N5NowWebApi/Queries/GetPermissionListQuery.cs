using Domain;
using MediatR;

namespace N5NowWebApi.Queries
{
    public class GetPermissionListQuery : IRequest<List<Permission>>
    {
    }
}
