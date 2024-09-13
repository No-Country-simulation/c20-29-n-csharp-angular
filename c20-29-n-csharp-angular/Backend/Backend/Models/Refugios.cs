using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public partial class Refugios
{
	[Key]
	public int IdRefugio { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoOrganizacion { get; set; } = null!;

    public string? UbicacionFisica { get; set; }

    public int? AnioFundacion { get; set; }

    public string? DatosContacto { get; set; }

    public string? DocumentoLegal { get; set; }

    public string? FotosRefugio { get; set; }

    public string? VideoPresentacion { get; set; }

    public string? RedesSociales { get; set; }

    public string? TestimoniosReferencias { get; set; }

	public int IdTipoOrganizacion { get; set; }

	public DateTime FechaRegistro { get; set; }
}
