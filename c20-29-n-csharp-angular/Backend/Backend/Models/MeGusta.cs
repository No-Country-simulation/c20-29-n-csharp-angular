using System;
using System.Collections.Generic;

namespace Backend.Models;

public class MeGusta
{
    public int IdMeGusta { get; set; }

    public int? IdPost { get; set; }

    public int? IdMascota { get; set; }

   // public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

   // public virtual Productos? IdProductoNavigation { get; set; }
}
