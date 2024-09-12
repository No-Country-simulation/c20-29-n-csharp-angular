using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Donaciones
{
	[Key]
    public int IdDonacion { get; set; }

    public decimal Monto { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuarioPeticion { get; set; }

	public int? IdUsuarioDonate { get; set; }

	public int? IdPost { get; set; }

	[ForeignKey("IdPost")]
	public virtual Post? Post { get; set; }

	[ForeignKey("IdUsuarioPeticion")]
	public virtual Usuario? UsuarioPeticion { get; set; }

	[ForeignKey("IdUsuarioDonate")]
	public virtual Usuario? UsuarioDonate { get; set; }
}
