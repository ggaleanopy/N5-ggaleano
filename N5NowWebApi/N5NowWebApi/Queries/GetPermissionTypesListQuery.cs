using Domain;
using MediatR;

namespace N5NowWebApi.Queries
{
    public class GetPermissionTypesListQuery : IRequest<List<PermissionType>>
    {
    }
}
