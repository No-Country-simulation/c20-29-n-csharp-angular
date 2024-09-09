using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Usuario
{
	[Key]
	[Column("IdUsuario")]
	public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

	public string Perfil { get; set; } = null!;

	public string UrlFoto { get; set; } = null!;

	public DateTime? FechaRegistro { get; set; }

    [NotMapped]
    public virtual ICollection<Adopciones> Adopciones { get; set; } = new List<Adopciones>();

	[NotMapped]
	public virtual ICollection<Apadrinamientos> Apadrinamientos { get; set; } = new List<Apadrinamientos>();

	[NotMapped]
	public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

	[InverseProperty("UsuarioPeticion")]
	public virtual ICollection<Donaciones> ListaUsuarioPeticion { get; set; } = new List<Donaciones>();

	[InverseProperty("UsuarioDonate")]
	public virtual ICollection<Donaciones> ListaUsuarioDonate { get; set; } = new List<Donaciones>();

	[NotMapped]
	public virtual ICollection<Post> Post { get; set; } = new List<Post>();
}
