using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Refugios
{
    public int IdRefugio { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoOrganizacion { get; set; } = null!;

    public string? UbicacionFisica { get; set; }

    public int? AñoFundacion { get; set; }

    public string? DatosContacto { get; set; }

    public string? DocumentoLegal { get; set; }

    public string? FotosRefugio { get; set; }

    public string? VideoPresentacion { get; set; }

    public string? RedesSociales { get; set; }

    public string? TestimoniosReferencias { get; set; }

    public virtual ICollection<Donaciones> Donaciones { get; set; } = new List<Donaciones>();

    public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();

    public virtual ICollection<Post> Post { get; set; } = new List<Post>();
}
