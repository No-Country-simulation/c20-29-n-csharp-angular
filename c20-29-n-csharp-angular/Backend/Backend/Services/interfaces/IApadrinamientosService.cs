using Backend.DTO;
using Backend.Models;

namespace Backend.Services.interfaces
{
    public interface IApadrinamientosService
    {
        Task<List<Apadrinamientos>> ListarApadrinamientos();
        Task<Apadrinamientos> ObtenerApadrinamientoById(int idApadrinamientos);
        Task<RespuestaOperacionDTO> RegistrarApadrinamientos(Apadrinamientos apadrinamientos);
        Task<RespuestaOperacionDTO> ActualizarApadrinamientos(Apadrinamientos apadrinamientos);
        Task<RespuestaOperacionDTO> EliminarApadrinamientos(int idApadrinamientos);
    }
}
