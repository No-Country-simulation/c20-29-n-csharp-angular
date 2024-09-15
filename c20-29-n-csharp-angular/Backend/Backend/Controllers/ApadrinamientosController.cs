using Backend.DTO;
using Backend.Models;
using Backend.Services.interfaces;
using Backend.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApadrinamientosController : ControllerBase
    {
        private readonly IApadrinamientosService _ApadrinamientosService;

        public ApadrinamientosController(IApadrinamientosService ApadrinamientosService)
        {
            _ApadrinamientosService = ApadrinamientosService;
        }

        [HttpGet("GetListaApadrinamientos")]
        public async Task<IActionResult> ListarApadrinamientos()
        {
            var data = await _ApadrinamientosService.ListarApadrinamientos();
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpGet("GetrApadrinamientoById/{idApadrinamientos}")]
        public async Task<IActionResult> ObtenerApadrinamientoById(int idApadrinamientos)
        {
            var data = await _ApadrinamientosService.ObtenerApadrinamientoById(idApadrinamientos);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpPost("PostApadrinamientos")]
        public async Task<IActionResult> RegistraridApadrinamientos([FromBody] Apadrinamientos apadrinamientos)
        {
            var response = await _ApadrinamientosService.RegistrarApadrinamientos(apadrinamientos);
            return Ok(response);
        }

        [HttpPut("PutApadrinamientos")]
        public async Task<IActionResult> ActualizaridApadrinamientos([FromBody] Apadrinamientos apadrinamientos)
        {
            var data = await _ApadrinamientosService.ActualizarApadrinamientos(apadrinamientos);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpDelete("DeleteApadrinamientos/{idApadrinamientos}")]
        public async Task<IActionResult> EliminaridApadrinamientos(int idApadrinamientos)
        {
            var response = await _ApadrinamientosService.EliminarApadrinamientos(idApadrinamientos);
            return Ok(response);
        }
    }
}
