using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public partial class Tipodocumento
{
	[Key]
	public int IdTipoDocumento { get; set; }

    public string Descripcion { get; set; } = null!;
}
