using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Apadrinamientos
{
	[Key]
	public int IdApadrinamiento { get; set; }

	public int? IdPost { get; set; }

    public DateTime? Fecha { get; set; }

	public int? IdPadrino { get; set; }

	[ForeignKey("IdPost")]
	public virtual Usuario? Padrino { get; set; }

	[ForeignKey("IdPadrino")]
	public virtual Post? Post { get; set; }
}
