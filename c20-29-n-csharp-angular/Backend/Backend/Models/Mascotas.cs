using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Mascotas
{
    public int IdMascota { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? FotoVideo { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public int? IdRefugio { get; set; }

    public virtual ICollection<Adopciones> Adopciones { get; set; } = new List<Adopciones>();

    public virtual ICollection<Apadrinamientos> Apadrinamientos { get; set; } = new List<Apadrinamientos>();

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual Refugios? IdRefugioNavigation { get; set; }

    public virtual ICollection<MeGusta> MeGusta { get; set; } = new List<MeGusta>();
}
