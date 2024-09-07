using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Megusta
{
	[Key]
	public int IdMeGusta { get; set; }

	public int IdPost { get; set; }

    public int? IdUsuario { get; set; }

    public bool? Bborrado { get; set; }

	[ForeignKey("IdPost")]
	public virtual Post Post { get; set; } = null!;
}
