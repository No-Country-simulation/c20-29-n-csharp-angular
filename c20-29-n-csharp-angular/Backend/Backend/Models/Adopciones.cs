using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Adopciones
{
	[Key]
	public int IdAdopcion { get; set; }

	public int IdPost { get; set; }

	public int? IdUsuarioAdopcion { get; set; }

    public int? IdFormulario { get; set; }

    public DateTime? Fecha { get; set; }

	[ForeignKey("IdPost")]
	public virtual Post Post { get; set; } = null!;

	[ForeignKey("IdUsuarioAdopcion")]
	public virtual Usuario? UsuarioAdopcion { get; set; }
}
