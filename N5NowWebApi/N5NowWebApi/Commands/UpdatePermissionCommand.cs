using Domain;
using MediatR;
namespace N5NowWebApi.Commands
{
    public class UpdatePermissionCommand : IRequest<Permission>
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; } = null!;

        public string ApellidoEmpleado { get; set; } = null!;

        public int TipoPermiso { get; set; }

        public DateTime FechaPermiso { get; set; }

        public UpdatePermissionCommand(int id, string nombreEmpleado, string apellidoEmpleado, int tipoPermiso, DateTime fechaPermiso)
        {
            Id = id;
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado= apellidoEmpleado;
            TipoPermiso= tipoPermiso;
            FechaPermiso = fechaPermiso;
        }
    }
}
