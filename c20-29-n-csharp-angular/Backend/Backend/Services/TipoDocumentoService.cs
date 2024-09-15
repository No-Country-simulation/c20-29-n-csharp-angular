using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Backend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly AppDbContext _context;
        public TipoDocumentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tipodocumento>> ListarTipodocumentos()
        {
            return await _context.Tipodocumento.ToListAsync();
        }

        public async Task<Tipodocumento> ObtenerTipodocumentoById(int IdTipoDocumento)
        {
            return await _context.Tipodocumento.Where(x => x.IdTipoDocumento == IdTipoDocumento).FirstOrDefaultAsync();
        }
        public async Task<RespuestaOperacionDTO> RegistrarTipodocumento(Tipodocumento tipodocumento)
        {
            tipodocumento.IdTipoDocumento = default;

            _context.Tipodocumento.Add(tipodocumento);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.RegistroExitosoConDatos(tipodocumento);
        }

        public async Task<RespuestaOperacionDTO> ActualizarTipodocumento(Tipodocumento tipodocumento)
        {
            _context.Tipodocumento.Update(tipodocumento);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.ExitoConDatos(tipodocumento);
        }

        public async Task<RespuestaOperacionDTO> EliminarTipodocumento(int IdTipoDocumento)
        {
            var tipodoc = await ObtenerTipodocumentoById(IdTipoDocumento);
            if (tipodoc is null)
            {
                return RespuestaOperacionDTO.FalloConMensaje("El registro ya se encuentra eliminado");
            }
            _context.Entry(tipodoc).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.Exitoso();
        }

    }
}
