using System;
using System.Collections.Generic;

namespace Domain;

public partial class PermissionType
{
    /// <summary>
    /// Unique Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Permission description
    /// </summary>
    public string Descripcion { get; set; } = null!;

    //public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
