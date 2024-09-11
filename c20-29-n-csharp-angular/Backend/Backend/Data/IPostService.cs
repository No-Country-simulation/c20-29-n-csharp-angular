using Backend.Models;

namespace Backend.Data
{
    public interface IPostService
    {
        public bool GuardarCambios();
        public Task<Post> EliminarEntidad(int idPost);
        public void AgregarEntidad<T>(T endidad);
        public Task<Post> UnicoPost(int idPost);
        public bool ExistePost(int idPost);
        public Task<List<Post>> GetPostsAsync();
        public  Task<Post> GetUnicoPostAsync(int idPost);
        public Task<Post> PostPostAsync(Post post);
        public Task<Post> PutPostAsync(int idPost, Post post);
        public Task<Post> DeletePost(int idPost);
    }
}
