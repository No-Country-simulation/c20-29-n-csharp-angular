using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
	public class RefugioService : IRefugioService
	{
		private readonly AppDbContext _appDbContext;

		public RefugioService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Refugios>> ListarRefugios()
		{
			return await _appDbContext.Refugios.ToListAsync();
		}

		public async Task<Refugios> ObtenerRefugio(int idRefugio)
		{
			return await _appDbContext.Refugios.Where(x => x.IdRefugio == idRefugio).FirstOrDefaultAsync();
		}

		public async Task<Refugios> ObtenerRefugioPorNombre(string nombre)
		{
			return await _appDbContext.Refugios.Where(x => x.Nombre == nombre).FirstOrDefaultAsync();
		}

		public async Task<RespuestaOperacionDTO> RegistrarRefugio(Refugios refugio)
		{
			var refugioBD = await ObtenerRefugioPorNombre(refugio.Nombre);
			if (refugioBD is not null)
			{
				return RespuestaOperacionDTO.FalloConMensaje("El refugio ya se encuentra registrado");
			}

			refugio.IdRefugio = default;
			refugio.FechaRegistro = DateTime.Now;

			_appDbContext.Refugios.Add(refugio);
			await _appDbContext.SaveChangesAsync();
			return RespuestaOperacionDTO.RegistroExitosoConDatos(refugio);
		}

		public async Task<Refugios> ActualizarRefugio(Refugios refugio)
		{
			_appDbContext.Refugios.Update(refugio);
			await _appDbContext.SaveChangesAsync();
			return refugio;
		}

		public async Task<RespuestaOperacionDTO> EliminarRefugio(int idRefugio)
		{
			var refugio = await ObtenerRefugio(idRefugio);
			if (refugio is null)
			{
				return RespuestaOperacionDTO.FalloConMensaje("El refugio ya se encuentra eliminado");
			}
			_appDbContext.Entry(refugio).State = EntityState.Deleted;
			await _appDbContext.SaveChangesAsync();
			return RespuestaOperacionDTO.Exitoso();
		}
	}
}
