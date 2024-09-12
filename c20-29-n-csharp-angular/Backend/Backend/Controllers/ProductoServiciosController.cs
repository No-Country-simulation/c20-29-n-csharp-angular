using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[Route("[controller]")]
	public class ProductoServiciosController : ControllerBase
	{
		private readonly IProductoServicioService _productoServicioService;

		public ProductoServiciosController(IProductoServicioService productoServicioService)
		{
			_productoServicioService = productoServicioService;
		}

		[HttpGet("")]
		public async Task<IActionResult> ListarProductosServicios()
		{
			var data = await _productoServicioService.ListarProductosServicios();
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpGet("{idProductoServicio}")]
		public async Task<IActionResult> ObtenerProductoServicio(int idProductoServicio)
		{
			var data = await _productoServicioService.ObtenerProductoServicio(idProductoServicio);
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpPost("")]
		public async Task<IActionResult> RegistrarProductoServicio([FromBody] Productoservicio productoservicio)
		{
			var response = await _productoServicioService.RegistrarProductoServicio(productoservicio);
			return Ok(response);
		}

		[HttpPut("")]
		public async Task<IActionResult> ActualizarProductoServicioo([FromBody] Productoservicio productoservicio)
		{
			var data = await _productoServicioService.ActualizarProductoServicioo(productoservicio);
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpDelete("{idProductoServicio}")]
		public async Task<IActionResult> EliminarProductoServicio(int idProductoServicio)
		{
			var response = await _productoServicioService.EliminarProductoServicio(idProductoServicio);
			return Ok(response);
		}
	}
}
