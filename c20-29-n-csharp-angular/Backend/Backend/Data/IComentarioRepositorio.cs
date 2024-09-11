using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Data
{
    public interface IComentarioRepositorio
    {
        public Task<List<Comentario>> GetComentariosAsync();
        public Task<Comentario> GetUnicoComentarioAsync(int idComentario);
        public Task<Comentario> PostComentarioAsync(Comentario comentario);
        public Task<Comentario> DeleteComentario(int idComentario);
        public Task<Comentario> UnicoComentario(int idComentario);
        public Task<Comentario> PutComentarioAsync(int idComentario, Comentario comentario);
        public bool ExisteComentario(int idComentario);
        public Task<Comentario> EliminarEntidad(int idComentario);
        public bool GuardarCambios();
        public void AgregarEntidad<T>(T endidad);
    }
}
