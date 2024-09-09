using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsuariosController : ControllerBase
	{
		private readonly UsuarioService _usuarioService;

		public UsuariosController(UsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpGet("")]
		public async Task<IActionResult> ListarUsuarios()
		{
			var data = await _usuarioService.ListarUsuarios();
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpGet("{idUsuario}")]
		public async Task<IActionResult> ObtenerUsuario(int idUsuario)
		{
			var data = await _usuarioService.ObtenerUsuario(idUsuario);
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpPost("")]
		public async Task<IActionResult> RegistrarUsuario(Usuario usuario)
		{
			var response = await _usuarioService.RegistrarUsuario(usuario);
			return Ok(response);
		}

		[HttpPut("")]
		public async Task<IActionResult> ActualizarUsuario(Usuario usuario)
		{
			var data = await _usuarioService.ActualizarUsuario(usuario);
			var response = RespuestaOperacionDTO.ExitoConDatos(data);
			return Ok(response);
		}

		[HttpDelete("{idUsuario}")]
		public async Task<IActionResult> EliminarUsuario(int idUsuario)
		{
			await _usuarioService.EliminarUsuario(idUsuario);
			var response = RespuestaOperacionDTO.Exitoso();
			return Ok(response);
		}


		[HttpPost("ValidarLogin")]
		public async Task<IActionResult> ValidarLogin(LoginRequestDTO loginRequestDTO)
		{
			var response = await _usuarioService.ValidarLogin(loginRequestDTO);
			return Ok(response);
		}
	}
}
