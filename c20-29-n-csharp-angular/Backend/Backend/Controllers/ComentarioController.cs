using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        IComentariosRepositorio _comentariosRepositorio;
        public ComentarioController(IComentariosRepositorio comentarioRepositorio)
        {
            _comentariosRepositorio = comentarioRepositorio;
        }

        [HttpGet("GetComentarios")]
        public IEnumerable<Comentarios> GetComentarios()
        {
            IEnumerable<Comentarios> comentarios = _comentariosRepositorio.GetComentarios();
            return comentarios;
        }

        [HttpGet("GetSingleCustomer/{idComentario}")]
        public Comentarios GetSingleComentario(int idComentario)
        {
            Comentarios comentario = _comentariosRepositorio.GetSingleComentario(idComentario);
            if (comentario != null)
            {
                return comentario;
            }
            throw new Exception("Error al intentar optener comentario");
        }
    }
}
