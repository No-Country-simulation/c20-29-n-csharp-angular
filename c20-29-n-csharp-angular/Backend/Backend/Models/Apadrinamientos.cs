using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models;

public partial class Apadrinamientos
{
	[Key]
	public int IdApadrinamiento { get; set; }

	public int? IdPost { get; set; }

    public DateTime? Fecha { get; set; }

	public int? IdPadrino { get; set; }

	[JsonIgnore]
	[ForeignKey("IdPost")]
	public virtual Usuario? Padrino { get; set; }
    [JsonIgnore]
    [ForeignKey("IdPadrino")]
	public virtual Post? Post { get; set; }
}
