using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Comentarios
{
    [Key]
    public int IdComentario { get; set; }

    public string Texto { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdPost { get; set; }

    public int? IdMascota { get; set; }

    public int? IdProducto { get; set; }

    //public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

    //public virtual Productos? IdProductoNavigation { get; set; }
}
