using Backend.Helper;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ArchivoController : ControllerBase
	{
		private readonly ArchivoService _archivoService;

		public ArchivoController(ArchivoService archivoService)
		{
			_archivoService = archivoService;
		}

		[HttpPost]
		public async Task<IActionResult> GuardarListaArchivos([FromForm] IFormFileCollection listaArchivos)
		{
			var response = await _archivoService.GuardarListaArchivos(listaArchivos);
			return Ok(response);
		}

		[HttpGet("{nombre}")]
		public async Task<IActionResult> ObtenerArchivo(string nombre)
		{
			FileHelper response = await _archivoService.ObtenerArchivo(nombre);
			if (response is null)
				return NotFound();
			//return File(response.FileBytes, response.MimeType, response.FileName);
			return File(response.FileBytes, response.MimeType);
		}
	}
}
