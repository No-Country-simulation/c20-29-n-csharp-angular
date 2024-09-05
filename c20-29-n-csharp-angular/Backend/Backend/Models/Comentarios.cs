using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Comentarios
{
    public int IdComentario { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public int? IdPost { get; set; }

    public int? IdMascota { get; set; }

    public int? IdProducto { get; set; }

    public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }
}
