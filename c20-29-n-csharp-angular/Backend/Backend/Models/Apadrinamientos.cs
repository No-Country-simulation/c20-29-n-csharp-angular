using System;
using System.Collections.Generic;

namespace Backend.Models;

public class Apadrinamientos
{
    public int IdApadrinamiento { get; set; }

    public int? IdPost { get; set; }

    //public int? IdMascota { get; set; }

    public DateTime? Fecha { get; set; }

   // public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }
}
