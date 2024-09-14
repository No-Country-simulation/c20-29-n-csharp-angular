using Backend.DTO;
using Backend.Models;

namespace Backend.Servicios.Interfaces
{
    public interface IDonacionesService
    {
        Task<List<Donaciones>> ListarDonaciones();
        Task<Donaciones> ObtenerDonacionById(int idDonacion);
        Task<RespuestaOperacionDTO> RegistrarDonaciones(Donaciones Donaciones);
        Task<RespuestaOperacionDTO> ActualizarDonaciones(Donaciones Donaciones);
        Task<RespuestaOperacionDTO> EliminarDonaciones(int idDonacion);
    }

}

