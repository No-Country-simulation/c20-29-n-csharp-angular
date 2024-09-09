using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
	public class UsuarioService
	{
		private readonly AppDbContext _appDbContext;

		public UsuarioService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Usuario>> ListarUsuarios()
		{
			return await _appDbContext.Usuario.ToListAsync();
		}

		public async Task<Usuario> ObtenerUsuario(int idUsuario)
		{
			return await _appDbContext.Usuario.Where(x => x.IdUsuario == idUsuario).FirstOrDefaultAsync();
		}

		public async Task<Usuario> ObtenerUsuarioConEmail(string correoElectronico)
		{
			return await _appDbContext.Usuario.Where(x => x.CorreoElectronico == correoElectronico).FirstOrDefaultAsync();
		}

		public async Task<RespuestaOperacionDTO> RegistrarUsuario(Usuario usuario)
		{
			var usuarioBD = await ObtenerUsuarioConEmail(usuario.CorreoElectronico);
			if (usuarioBD is not null)
			{
				return RespuestaOperacionDTO.FalloConMensaje("El correo ya se encuentra registrado");
			}

			usuario.IdUsuario = default;
			usuario.FechaRegistro = DateTime.Now;

			_appDbContext.Usuario.Add(usuario);
			await _appDbContext.SaveChangesAsync();
			return RespuestaOperacionDTO.ExitoConDatos(usuario);
		}

		public async Task<Usuario> ActualizarUsuario(Usuario usuario)
		{
			_appDbContext.Usuario.Update(usuario);
			await _appDbContext.SaveChangesAsync();
			return usuario;
		}

		public async Task EliminarUsuario(int idUsuario)
		{
			var usuario = await ObtenerUsuario(idUsuario);
			_appDbContext.Entry(usuario).State = EntityState.Deleted;
			await _appDbContext.SaveChangesAsync();
		}

		public async Task<RespuestaOperacionDTO> ValidarLogin(LoginRequestDTO loginRequestDTO)
		{
			var usuario = await ObtenerUsuarioConEmail(loginRequestDTO.CorreoElectronico);
			if (usuario is null)
			{
				return RespuestaOperacionDTO.FalloConMensaje("Usuario no encontrado");
			}
			if (!usuario.Contrasenia.Equals(loginRequestDTO.Contrasenia))
			{
				return RespuestaOperacionDTO.FalloConMensaje("Contraseña incorrecta");
			}

			return RespuestaOperacionDTO.ExitoConDatos(usuario);
		}
	}
}
