using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Backend.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class MeGustaService : IMeGustaService
    {
        private readonly AppDbContext _context;
        public MeGustaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Megusta>> ListarMegustas()
        {
            return await _context.Megusta.ToListAsync();
        }

        public async Task<Megusta> ObtenerMegustaById(int IdMeGusta)
        {
            return await _context.Megusta.Where(x => x.IdMeGusta == IdMeGusta).FirstOrDefaultAsync();
        }

        public async Task<RespuestaOperacionDTO> RegistrarMegusta(Megusta megusta)
        {
            megusta.IdMeGusta = default;

            _context.Megusta.Add(megusta);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.RegistroExitosoConDatos(megusta);
        }
        public async Task<RespuestaOperacionDTO> ActualizarMegusta(Megusta megusta)
        {
            _context.Megusta.Update(megusta);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.ExitoConDatos(megusta);
        }

        public async Task<RespuestaOperacionDTO> EliminarMegusta(int IdMeGusta)
        {
            var megusta = await ObtenerMegustaById(IdMeGusta);
            if (megusta is null)
            {
                return RespuestaOperacionDTO.FalloConMensaje("El registro ya se encuentra eliminado");
            }
            _context.Entry(megusta).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.Exitoso();
        }

    }
}
