using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public interface IRefugioService
	{
		Task<List<Refugios>> ListarRefugios();
		Task<Refugios> ObtenerRefugio(int idRefugio);
		Task<Refugios> ObtenerRefugioPorNombre(string nombre);
		Task<RespuestaOperacionDTO> RegistrarRefugio(Refugios refugio);
		Task<Refugios> ActualizarRefugio(Refugios refugio);
		Task<RespuestaOperacionDTO> EliminarRefugio(int idRefugio);
	}
}
