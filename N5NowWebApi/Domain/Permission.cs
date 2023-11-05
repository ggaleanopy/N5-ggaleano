using System;
using System.Collections.Generic;

namespace Domain;

public partial class Permission
{
    /// <summary>
    /// Unique Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Employee Forename
    /// </summary>
    public string NombreEmpleado { get; set; } = null!;

    /// <summary>
    /// Employee Surname
    /// </summary>
    public string ApellidoEmpleado { get; set; } = null!;

    /// <summary>
    /// Permission type
    /// </summary>
    public int TipoPermiso { get; set; }

    /// <summary>
    /// Permission granted on date
    /// </summary>
    public DateTime FechaPermiso { get; set; }

    //public virtual PermissionType TipoPermisoNavigation { get; set; } = null!;
}
