using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Comentarios
{
	[Key]
	public int IdComentario { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime? Fecha { get; set; }

	public int? IdPost { get; set; }

	public int? IdUsuario { get; set; }

	[ForeignKey("IdPost")]
	public virtual Post? Post { get; set; }

	[ForeignKey("IdUsuario")]
	public virtual Usuario? Usuario { get; set; }
}
