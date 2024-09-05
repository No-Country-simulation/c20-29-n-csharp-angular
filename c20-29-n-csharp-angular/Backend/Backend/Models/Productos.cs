using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Productos
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? IdProveedor { get; set; }

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual Proveedores? IdProveedorNavigation { get; set; }

    public virtual ICollection<MeGusta> MeGusta { get; set; } = new List<MeGusta>();
}
