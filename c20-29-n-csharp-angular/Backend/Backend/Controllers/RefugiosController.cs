using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[Route("[controller]")]
	public class RefugiosController : ControllerBase
	{
		private readonly IRefugioService _refugioService;

		public RefugiosController(IRefugioService refugioService)
		{
			_refugioService = refugioService;
		}

		[HttpGet("")]
		public async Task<IActionResult> ListarRefugios()
		{
			var data = await _refugioService.ListarRefugios();
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpGet("{idRefugio}")]
		public async Task<IActionResult> ObtenerRefugio(int idRefugio)
		{
			var data = await _refugioService.ObtenerRefugio(idRefugio);
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpPost("")]
		public async Task<IActionResult> RegistrarRefugio([FromBody] Refugios refugio)
		{
			var response = await _refugioService.RegistrarRefugio(refugio);
			return Ok(response);
		}

		[HttpPut("")]
		public async Task<IActionResult> ActualizarRefugio([FromBody] Refugios refugio)
		{
			var data = await _refugioService.ActualizarRefugio(refugio);
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpDelete("{idRefugio}")]
		public async Task<IActionResult> EliminarRefugio(int idRefugio)
		{
			var response = await _refugioService.EliminarRefugio(idRefugio);
			return Ok(response);
		}
	}
}
