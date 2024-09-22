using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postRepositorio;
        public PostController(IPostService PostRepositorio)
        {
            _postRepositorio = PostRepositorio;
        }

        [HttpGet("GetListaPosts")]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var response = await _postRepositorio.GetPostsAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("GetUnicoPost/{idPost}")]
        public async Task<IActionResult> GetUnicoPost(int idPost)
        {
            try
            {
                var Post = await _postRepositorio.GetUnicoPostAsync(idPost);
                if (Post == null)
                {
                    return NotFound("No se encontro el Post.");
                }
                return Ok(Post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("PostPost")]
        public async Task<IActionResult> PostPost([FromForm] Post post, [FromForm] IFormFileCollection listaArchivos)
        {
            try
            {
                if (post == null || listaArchivos == null)
                {
                    return BadRequest("Post model or files are null.");
                }

                var postToDb = await _postRepositorio.PostPostAsync(post, listaArchivos);

                if (postToDb != null)
                {
                    return Ok(new
                    {
                        Message = "El Post se ha creado correctamente.",
                        Comentario = postToDb
                    });
                }
                else
                {
                    return BadRequest("Alguna de la data del Post es nula.");
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("PutPostAsync/{idPost}")]
        public async Task<IActionResult> PutPost(int idPost, [FromBody] Post Post)
        {

            try
            {
                var PostEnDb = await _postRepositorio.PutPostAsync(idPost, Post);

                if (PostEnDb != null)
                {
                    return Ok(
                        new
                        {
                            Message = $"El Post con ID: {idPost} ha sido modificado.",
                            Post = PostEnDb,
                        });
                }
                else
                {
                    return NotFound("Post no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("DeletePost/{idPost}")]
        public async Task<IActionResult> DeletePost(int idPost)
        {
            try
            {
                var Post = await _postRepositorio.DeletePost(idPost);

                return Ok(
                    new
                    {
                        Message = $"El Post con el ID {idPost} ha sido eliminado.",
                        Post = Post
                    }
                    );
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
