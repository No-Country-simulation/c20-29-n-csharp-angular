using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Proveedores
{
    public int IdProveedor { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string TipoProveedor { get; set; } = null!;

    public string NumeroIdentificacionFiscal { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? RedesSociales { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();

    public virtual ICollection<Servicios> Servicios { get; set; } = new List<Servicios>();
}
