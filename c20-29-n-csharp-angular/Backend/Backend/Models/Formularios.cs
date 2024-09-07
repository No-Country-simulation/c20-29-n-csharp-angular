using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public partial class Formularios
{
    [Key]
    public int IdFormularios { get; set; }

    public string TipoFormulario { get; set; } = null!;

    public string? NombreRefugio { get; set; }

    public int TipoOrganizacion { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaFundacion { get; set; }

    public int IdTipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? TelefonoRef { get; set; }

    public string? NombreRef { get; set; }

    public string? ApellidoRef { get; set; }

    public bool Terminos { get; set; }

    public int IdProdcutoServicio { get; set; }

    public string? Contacto { get; set; }
}
