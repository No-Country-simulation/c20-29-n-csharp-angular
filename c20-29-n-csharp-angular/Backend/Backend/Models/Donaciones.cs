using System;
using System.Collections.Generic;

namespace Backend.Models;

public class Donaciones
{
    public int IdDonacion { get; set; }

    public decimal Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdPost { get; set; }

    public int? IdRefugio { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

    public virtual Refugios? IdRefugioNavigation { get; set; }
}
