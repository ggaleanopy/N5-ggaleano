using Domain;
using MediatR;
namespace N5NowWebApi.Commands
{
    public class CreatePermissionCommand : IRequest<Permission>
    {
        public string NombreEmpleado { get; set; } = null!;

        public string ApellidoEmpleado { get; set; } = null!;

        public int TipoPermiso { get; set; }

        public DateTime FechaPermiso { get; set; }

        public CreatePermissionCommand(string nombreEmpleado, string apellidoEmpleado, int tipoPermiso, DateTime fechaPermiso)
        {
            NombreEmpleado = nombreEmpleado;
            ApellidoEmpleado= apellidoEmpleado;
            TipoPermiso= tipoPermiso;
            FechaPermiso = fechaPermiso;
        }
    }
}
