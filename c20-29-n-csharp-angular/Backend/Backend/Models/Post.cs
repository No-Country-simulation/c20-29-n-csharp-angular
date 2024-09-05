using System;
using System.Collections.Generic;

namespace Backend.Models;

public class Post
{
    public int IdPost { get; set; }

    public string Titulo { get; set; }

    public string TipoPost { get; set; }

    public string? Descripcion { get; set; }

    public string? FotoVideo { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public string? Categoria { get; set; }

    public decimal? Precio { get; set; }

    public string? TipoProveedor { get; set; }

    public string? NumeroIdentificacionFiscal { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? RedesSociales { get; set; }

    public int? IdRefugio { get; set; }

    public virtual ICollection<Adopciones> Adopciones { get; set; } = new List<Adopciones>();

    public virtual ICollection<Apadrinamientos> Apadrinamientos { get; set; } = new List<Apadrinamientos>();

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual ICollection<Donaciones> Donaciones { get; set; } = new List<Donaciones>();

    public virtual Refugios? IdRefugioNavigation { get; set; }

    public virtual ICollection<MeGusta> MeGusta { get; set; } = new List<MeGusta>();
}
