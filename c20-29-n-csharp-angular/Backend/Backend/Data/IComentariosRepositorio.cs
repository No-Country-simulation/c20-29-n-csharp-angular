using Backend.Models;

namespace Backend.Data
{
    public interface IComentariosRepositorio
    {
        public IEnumerable<Comentarios> GetComentarios();
        public Comentarios GetSingleComentario(int idComentario);
    }
}
