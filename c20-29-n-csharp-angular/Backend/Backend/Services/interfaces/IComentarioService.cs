using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services.interfaces
{
    public interface IComentariosService
    {
        public Task<List<Comentarios>> GetComentariosAsync();
        public Task<Comentarios> GetUnicoComentarioAsync(int idComentario);
        public Task<Comentarios> PostComentarioAsync(Comentarios Comentarios);
        public Task<Comentarios> DeleteComentario(int idComentario);
        public Task<Comentarios> UnicoComentario(int idComentario);
        public Task<Comentarios> PutComentarioAsync(int idComentario, Comentarios Comentarios);
        public bool ExisteComentario(int idComentario);
        public Task<Comentarios> EliminarEntidad(int idComentario);
        public bool GuardarCambios();
        public void AgregarEntidad<T>(T endidad);
    }
}
