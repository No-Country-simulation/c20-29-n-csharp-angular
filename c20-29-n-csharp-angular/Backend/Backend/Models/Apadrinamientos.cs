using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Apadrinamientos
{
    [Key]
    public int IdApadrinamiento { get; set; }

    public int? IdPost { get; set; }

    //public int? IdMascota { get; set; }

    public DateTime? Fecha { get; set; }

   // public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }
}
