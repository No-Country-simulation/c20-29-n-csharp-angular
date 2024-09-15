using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Backend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ApadrinamientosService: IApadrinamientosService
    {
        private readonly AppDbContext _context;
        public ApadrinamientosService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Apadrinamientos>> ListarApadrinamientos()
        {
            return await _context.Apadrinamientos.ToListAsync();
        }

        public async Task<Apadrinamientos> ObtenerApadrinamientoById(int idApadrinamientos)
        {
            return await _context.Apadrinamientos.Where(x => x.IdApadrinamiento == idApadrinamientos).FirstOrDefaultAsync();
        }

        public async Task<RespuestaOperacionDTO> RegistrarApadrinamientos(Apadrinamientos apadrinamientos)
        {
            apadrinamientos.IdApadrinamiento = default;
            apadrinamientos.Fecha = DateTime.Now;

            _context.Apadrinamientos.Add(apadrinamientos);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.RegistroExitosoConDatos(apadrinamientos);
        }

        public async Task<RespuestaOperacionDTO> ActualizarApadrinamientos(Apadrinamientos apadrinamientos)
        {
            _context.Apadrinamientos.Update(apadrinamientos);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.ExitoConDatos(apadrinamientos);
        }

        public async Task<RespuestaOperacionDTO> EliminarApadrinamientos(int idApadrinamientos)
        {
            var apadrinamientos = await ObtenerApadrinamientoById(idApadrinamientos);
            if (apadrinamientos is null)
            {
                return RespuestaOperacionDTO.FalloConMensaje("El registro ya se encuentra eliminado");
            }
            _context.Entry(apadrinamientos).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.Exitoso();
        }
    }
}
