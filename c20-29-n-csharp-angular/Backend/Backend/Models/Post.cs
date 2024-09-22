using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public partial class Post
{
	[Key]
	public int? IdPost { get; set; }

    [Required]
    [MaxLength(100)]
    public string Titulo { get; set; }

    [Required]
    [MaxLength(50)]
    public string TipoPost { get; set; }

    public string Descripcion { get; set; }

    public byte[]? MultimediaPost { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public enum CategoriaPost
    {
        Entretenimiento,
        Adopcion,
        Apadrinamiento,
        Donaciones,
        Productos,
        Servicio
    }

    [ForeignKey("IdUsuario")]
    public virtual int IdUsuario { get; set; }
}
