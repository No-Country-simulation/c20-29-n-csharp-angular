using Backend.DTO;
using Backend.Models;
using Backend.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionesController : ControllerBase
    {
        private readonly IDonacionesService _donacionesService;

        public DonacionesController(IDonacionesService donacionesService)
        {
            _donacionesService = donacionesService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListarDonaciones()
        {
            var data = await _donacionesService.ListarDonaciones();
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpGet("{idDonacion}")]
        public async Task<IActionResult> ObtenerDonacionById(int idDonacion)
        {
            var data = await _donacionesService.ObtenerDonacionById(idDonacion);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> RegistrarDonaciones([FromBody] Donaciones Donaciones)
        {
            var response = await _donacionesService.RegistrarDonaciones(Donaciones);
            return Ok(response);
        }

        [HttpPut("")]
        public async Task<IActionResult> ActualizarDonaciones([FromBody] Donaciones Donaciones)
        {
            var data = await _donacionesService.ActualizarDonaciones(Donaciones);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpDelete("{idDonacion}")]
        public async Task<IActionResult> EliminarDonaciones(int idDonacion)
        {
            var response = await _donacionesService.EliminarDonaciones(idDonacion);
            return Ok(response);
        }
    }
}

