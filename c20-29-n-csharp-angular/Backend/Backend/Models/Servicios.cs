using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Servicios
{
    public int IdServicio { get; set; }

    public string TipoServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdProveedor { get; set; }

    public virtual Proveedores? IdProveedorNavigation { get; set; }
}
