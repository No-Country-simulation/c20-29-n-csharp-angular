using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
	[JsonIgnore]
	[ForeignKey("IdPost")]
	public virtual Post? Post { get; set; }
    [JsonIgnore]
    [ForeignKey("IdUsuarioPeticion")]
	public virtual Usuario? UsuarioPeticion { get; set; }
    [JsonIgnore]
    [ForeignKey("IdUsuarioDonate")]
	public virtual Usuario? UsuarioDonate { get; set; }
}
