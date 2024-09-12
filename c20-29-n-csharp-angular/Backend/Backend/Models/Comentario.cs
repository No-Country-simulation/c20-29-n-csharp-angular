using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        public string Texto { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPost { get; set; }
        public int IdUsuario { get; set; }
    }
}
