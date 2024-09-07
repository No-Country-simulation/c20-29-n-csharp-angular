using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public partial class Tipoorganizacion
{
	[Key]
	public int IdTipoOrganizacion { get; set; }

    public string Descripcion { get; set; } = null!;
}
