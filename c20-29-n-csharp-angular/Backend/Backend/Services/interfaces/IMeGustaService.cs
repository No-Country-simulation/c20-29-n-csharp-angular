using Backend.DTO;
using Backend.Models;

namespace Backend.Services.interfaces
{
    public interface IMeGustaService
    {
        Task<List<Megusta>> ListarMegustas();
        Task<Megusta> ObtenerMegustaById(int IdMeGusta);
        Task<RespuestaOperacionDTO> RegistrarMegusta(Megusta megusta);
        Task<RespuestaOperacionDTO> ActualizarMegusta(Megusta megusta);
        Task<RespuestaOperacionDTO> EliminarMegusta(int IdMeGusta);
    }
}
