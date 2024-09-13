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

        [HttpGet("GetDonaciones")]
        public async Task<IActionResult> GetDonaciones()
        {
            try
            {
                var response = await _donacionesService.GetDonaciones();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }

        }

        [HttpGet("GetDonacionById/{idDonacion}")]
        public async Task<IActionResult> GetDonacionById(int idDonacion)
        {

            try
            {
                var donacion = await _donacionesService.GetDonacionById(idDonacion);
                if (donacion == null)
                {
                    return NotFound("No se encontro el la doncaciom.");
                }
                return Ok(donacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }

        [HttpPost("PostDonacion")]
        public async Task<IActionResult> PostDonacion([FromBody] Donaciones donacion)
        {


            var donaciondb = await _donacionesService.PostDonacion(donacion);

            try
            {

                if (donaciondb != null)
                {
                    return Ok(
                        new
                        {
                            Message = $"El comentario ID: {donaciondb.IdDonacion} se ha creado correctamente.",
                            donacion = donaciondb
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

        [HttpPut("UpdateDonacion/{idDonacion}")]
        public async Task<IActionResult> UpdateDonacion(int idDonacion, [FromBody] Donaciones donacion)
        {
            try
            {
                var donacionActualizada = await _donacionesService.UpdateDonacion(idDonacion, donacion);
                if (donacionActualizada != null)
                {
                    return Ok(
                        new
                        {
                            Message = $"idDonacion: {idDonacion} ha sido modificado.",
                            donacion = donacionActualizada,
                        });
                }
                else
                {
                    return NotFound("Donacion NotFound.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);

            }
        }
        [HttpDelete("DeleteDonacion/{idDonacion}")]
        public async Task<IActionResult> DeleteDonacion(int idDonacion)
        {
            try
            {
                var donacion = await _donacionesService.DeleteDonacion(idDonacion);

                return Ok(
                    new
                    {
                        Message = $"idDonacion {idDonacion} ha sido eliminado",
                        donacion = donacion
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

