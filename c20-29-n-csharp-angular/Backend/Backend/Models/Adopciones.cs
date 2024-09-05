using System;
using System.Collections.Generic;

namespace Backend.Models;

public class Adopciones
{   
    public int IdAdopcion { get; set; }

    public int? IdPost { get; set; }

    // public int? IdMascota { get; set; }

    public DateTime? Fecha { get; set; }

    // public virtual Mascotas? IdMascotaNavigation { get; set; }

    public virtual Post? IdPostNavigation { get; set; }
}
