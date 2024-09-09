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
        private readonly AppDbContext _appDbContext;
        public ComentarioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("GetListaComentarios")]
        public async Task<IActionResult> GetComentarios()
        {
            try
            {
                var response = await _appDbContext.Comentarios.ToListAsync();
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
                Comentario? usuario = await UnicoComentario(idComentario);
                if (usuario == null)
                {
                    return NotFound("No se encontro el comentario.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while retrieving the user.");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("PostComentario")]
        public async Task<IActionResult> PostComentario([FromBody] Comentario comentario)
        {
            if (
                comentario == null ||
                comentario.IdUsuario == null ||
                comentario.IdPost == null ||
                comentario.Texto == null ||
                comentario.Fecha == null
                )
            {
                return BadRequest("Alguna de la data del comentario es nula.");
            }

            try
            {
                Comentario comentarioToDb = new Comentario();

                comentarioToDb.Texto = comentario.Texto;
                comentarioToDb.Fecha = comentario.Fecha;    
                comentarioToDb.IdPost = comentario.IdPost;
                comentarioToDb.IdUsuario = comentario.IdUsuario;
                

                _appDbContext.Comentarios.Add(comentario);
                if (GuardarCambios())
                {
                    return Ok(CreatedAtAction(nameof(GetUnicoComentario), new { IdComentario = comentario.IdComentario }, comentarioToDb));
                }
                else
                {
                    return BadRequest("Alguna de la data del comentario es nula.");
                }
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                // Log.Error(ex, "An error occurred while creating the user.");

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("PutComentario/{idComentario}")]
        public async Task<IActionResult> PutComentario(int idComentario,[FromBody] Comentario comentario)
        {
            Comentario comentarioEnDb = await UnicoComentario(idComentario);

            if (idComentario != comentarioEnDb.IdComentario)
            {
                return BadRequest("Id comentario no coincide.");
            }

            try
            {
                comentarioEnDb.Texto = comentario.Texto;

                _appDbContext.Entry(comentarioEnDb).State = EntityState.Modified;
                if (GuardarCambios())
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
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteComentario(idComentario))
                {
                    return NotFound("Comentario no encontrado.");
                }
                else
                {
                    throw;
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
                if (!ExisteComentario(idComentario))
                {
                    return NotFound($"No se encontro el comentario con ID {idComentario}.");
                }
                Comentario comentario = await UnicoComentario(idComentario);
                _appDbContext.Comentarios.Remove(comentario);
                await _appDbContext.SaveChangesAsync();
                return Ok(
                    new
                    {
                        Message = $"El comentario con el ID {idComentario} ha sido eliminado",
                        Comentario = comentario
                    }
                    );
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        private bool ExisteComentario(int idComentario)
        {
            return _appDbContext.Comentarios.Any(e => e.IdComentario == idComentario);
        }
        private async Task<Comentario> UnicoComentario(int idComentario)
        {
            Comentario? usuario = await _appDbContext.Comentarios.FindAsync(idComentario);

            return usuario;
        }
        private bool GuardarCambios()
        {
            return _appDbContext.SaveChanges() > 0;
        }

    }
}
