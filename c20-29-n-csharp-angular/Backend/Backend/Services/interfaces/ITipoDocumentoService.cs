using Backend.DTO;
using Backend.Models;

namespace Backend.Services.interfaces
{
    public interface ITipoDocumentoService
    {
        Task<List<Tipodocumento>> ListarTipodocumentos();
        Task<Tipodocumento> ObtenerTipodocumentoById(int IdTipoDocumento);
        Task<RespuestaOperacionDTO> RegistrarTipodocumento(Tipodocumento tipodocumento);
        Task<RespuestaOperacionDTO> ActualizarTipodocumento(Tipodocumento tipodocumento);
        Task<RespuestaOperacionDTO> EliminarTipodocumento(int IdTipoDocumento);
    }
}
