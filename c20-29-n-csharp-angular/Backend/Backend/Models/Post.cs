using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Post
{
	[Key]
	public int IdPost { get; set; }

    public string Titulo { get; set; } = null!;

    public string TipoPost { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? MultimediaPost { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public string? CategoriaPost { get; set; }

	public int IdUsuario { get; set; }

    public virtual ICollection<Adopciones> Adopciones { get; set; } = new List<Adopciones>();

    public virtual ICollection<Apadrinamientos> Apadrinamientos { get; set; } = new List<Apadrinamientos>();

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual ICollection<Donaciones> Donaciones { get; set; } = new List<Donaciones>();

	[ForeignKey("IdUsuario")]
	public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Megusta> Megusta { get; set; } = new List<Megusta>();
}
