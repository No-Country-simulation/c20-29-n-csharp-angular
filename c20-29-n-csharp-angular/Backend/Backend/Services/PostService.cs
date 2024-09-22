using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _postRepositorio;
        public PostService(AppDbContext appDbContext)
        {
            _postRepositorio = appDbContext;
        }
        public bool GuardarCambios()
        {
            return _postRepositorio.SaveChanges() > 0;
        }
        public async Task<Post> EliminarEntidad(int? idPost)
        {
            Post Post = await UnicoPost(idPost);
            if (Post != null)
            {
                _postRepositorio.Post.Remove(Post);
                GuardarCambios();
            }
            return Post;
        }
        public void AgregarEntidad<T>(T endidad)
        {
            _postRepositorio.Add(endidad);
        }
        public async Task<Post> UnicoPost(int? idPost)
        {
            Post Post = await _postRepositorio.Post.FindAsync(idPost);

            return Post;
        }
        public bool ExistePost(int? idPost)
        {
            return _postRepositorio.Post.Any(e => e.IdPost == idPost);
        }


        public async Task<List<Post>> GetPostsAsync()
        {
            var Post = await _postRepositorio.Post.ToListAsync();
            return Post;
        }
        public async Task<Post> GetUnicoPostAsync(int? idPost)
        {
            try
            {
                Post Post = await UnicoPost(idPost);
                if (Post == null)
                {
                    throw new Exception("No se encontro el Post.");
                }
                return Post;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se encontro el Post. ${ex.Message}");
            }
        }
        public async Task<Post> PostPostAsync(Post post, IFormFileCollection listaArchivos)
        {
            if (listaArchivos.Count > 0)
            {
                var file = listaArchivos[0];
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    post.MultimediaPost = memoryStream.ToArray();
                }
            }

            try
            {
                post.IdPost = null; 

                AgregarEntidad(post);
                if (GuardarCambios())
                {
                    return post;
                }
                else
                {
                    throw new Exception("Alguna de la data del Post es nula.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al guardar el Post: " + ex.Message);
            }
        }

        public async Task<Post> PutPostAsync(int? idPost, Post post)
        {
            Post postOnDb = await UnicoPost(idPost);

            if (idPost != postOnDb.IdPost)
            {
                throw new Exception("Id Post no coincide.");
            }

            try
            {
                postOnDb.Titulo = post.Titulo ?? postOnDb.Titulo;
                postOnDb.TipoPost = post.TipoPost ?? postOnDb.TipoPost;
                postOnDb.Descripcion = post.Descripcion ?? postOnDb.Descripcion;
                postOnDb.MultimediaPost = post.MultimediaPost ?? postOnDb.MultimediaPost;

                _postRepositorio.Entry(postOnDb).State = EntityState.Modified;
                if (GuardarCambios())
                {
                    return postOnDb;

                }
                else
                {
                    throw new Exception("Post no encontrado.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExistePost(idPost))
                {
                    throw new Exception("Post no encontrado.");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<Post> DeletePost(int? idPost)
        {
            try
            {
                if (!ExistePost(idPost))
                {
                    throw new Exception($"No se encontro el Post con ID {idPost}.");
                }
                Post Post = await UnicoPost(idPost);

                Post PostEliminado = await EliminarEntidad(Post.IdPost);

                if (PostEliminado != null)
                {
                    return PostEliminado;
                }
                else
                {
                    throw new Exception($"No se encontro el Post con ID {idPost}.");
                }
            }
            catch (DbUpdateException ex)
            {

                throw new Exception($"No se encontro el Post con ID {ex.Message}.");
            }
        }
    }
}
