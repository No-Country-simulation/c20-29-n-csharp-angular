using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public partial class Productoservicio
{
	[Key]
	public int IdProductoServicio { get; set; }

    public string Titulo { get; set; } = null!;

    public string TipoProducto { get; set; } = null!;

    public string? DescripcionProducto { get; set; }

    public string? MultimediaProducto { get; set; }

    public string? NumeroIdentificacionFiscal { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? RedesSociales { get; set; }
}
