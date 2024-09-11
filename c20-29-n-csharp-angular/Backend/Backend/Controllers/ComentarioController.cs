using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentariosService _comRepositorio;
        public ComentarioController(IComentariosService comentarioRepositorio)
        {
            _comRepositorio = comentarioRepositorio;
        }

        [HttpGet("GetListaComentarios")]
        public async Task<IActionResult> GetComentarios()
        {
            try
            {
                var response = await _comRepositorio.GetComentariosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("GetUnicoComentario/{idComentario}")]
        public async Task<IActionResult> GetUnicoComentario(int idComentario)
        {
            try
            {
                var comentario = await _comRepositorio.GetUnicoComentarioAsync(idComentario);
                if (comentario == null)
                {
                    return NotFound("No se encontro el comentario.");
                }
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("PostComentario")]
        public async Task<IActionResult> PostComentario([FromBody] Comentarios comentario)
        {
            var comentarioToDb = await _comRepositorio.PostComentarioAsync(comentario);

            try
            {

                if (comentarioToDb != null)
                {
                    return Ok(
                        new
                        {
                            Message = $"El comentario ID: {comentarioToDb.IdComentario} se ha creado correctamente.",
                            Coemntario = comentarioToDb
                        }
                        );
                }
                else
                {
                    return BadRequest("Alguna de la data del comentario es nula.");
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("PutComentarioAsync/{idComentario}")]
        public async Task<IActionResult> PutComentario(int idComentario,[FromBody] Comentarios comentario)
        {

            try
            {
                var comentarioEnDb = await _comRepositorio.PutComentarioAsync(idComentario, comentario);

                if (comentarioEnDb != null)
                {
                    return Ok(
                        new
                        {
                            Message = $"El comentario con ID: {idComentario} ha sido modificado.",
                            comentario = comentarioEnDb,
                        });
                }
                else
                {
                    return NotFound("Comentario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("DeleteComentario/{idComentario}")]
        public async Task<IActionResult> DeleteComentario(int idComentario)
        {
            try
            {
                var comentario = await _comRepositorio.DeleteComentario(idComentario);

                return Ok(
                    new
                    {
                        Message = $"El comentario con el ID {idComentario} ha sido eliminado.",
                        Comentario = comentario
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
