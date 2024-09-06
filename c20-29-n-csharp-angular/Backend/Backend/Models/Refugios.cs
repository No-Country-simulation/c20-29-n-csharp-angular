using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Utility;

namespace Backend.Models;

public class Refugios
{
    [Key]
    public int IdRefugio { get; set; }

    public string Nombre { get; set; } 
    
    public TipoOrg _TipoOrganizacion { get; set; }

    public string? UbicacionFisica { get; set; }

    public int? AñoFundacion { get; set; }

    public string? DatosContacto { get; set; }

    public string? DocumentoLegal { get; set; }

    public string? FotosRefugio { get; set; }   

    public string? VideoPresentacion { get; set; }

    public string? RedesSociales { get; set; }

    public string? TestimoniosReferencias { get; set; }

    public virtual ICollection<Donaciones> Donaciones { get; set; } = new List<Donaciones>();

    //public virtual ICollection<Mascotas> Mascotas { get; set; } = new List<Mascotas>();

    public virtual ICollection<Post> Post { get; set; } = new List<Post>();
}
