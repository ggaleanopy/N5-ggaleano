using Domain;
using MediatR;
namespace N5NowWebApi.Commands
{
    public class CreatePermissionTypeCommand : IRequest<PermissionType>
    {
        //public int Id { get; set; }
        public string Description { get; set; }
        
        public CreatePermissionTypeCommand(string description)
        {
            //Id = id;
            Description = description;
        }
    }
}
