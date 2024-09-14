using Backend.DTO;
using Backend.Models;
using Backend.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MegustaController : ControllerBase
    {
        private readonly IMeGustaService _MeGustaService;
        public MegustaController(IMeGustaService MeGustaService)
        {
            _MeGustaService = MeGustaService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListarMegustas()
        {
            var data = await _MeGustaService.ListarMegustas();
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpGet("{IdMeGusta}")]
        public async Task<IActionResult> ObtenerMegustaById(int IdMeGusta)
        {
            var data = await _MeGustaService.ObtenerMegustaById(IdMeGusta);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> RegistrarMegusta([FromBody] Megusta megusta)
        {
            var response = await _MeGustaService.RegistrarMegusta(megusta);
            return Ok(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> ActualizarMegusta([FromBody] Megusta megusta)
        {
            var data = await _MeGustaService.ActualizarMegusta(megusta);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpDelete("{IdMeGusta}")]
        public async Task<IActionResult> EliminarMegusta(int IdMeGusta)
        {
            var response = await _MeGustaService.EliminarMegusta(IdMeGusta);
            return Ok(response);
        }
    }
}
