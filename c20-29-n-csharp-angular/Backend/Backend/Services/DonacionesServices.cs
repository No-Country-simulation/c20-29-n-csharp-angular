using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Backend.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Servicios
{
    public class DonacionesService : IDonacionesService
    {
        private readonly AppDbContext _context;
        public DonacionesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Donaciones>> ListarDonaciones()
        {
            return await _context.Donaciones.ToListAsync();
        }
        public async Task<Donaciones> ObtenerDonacionById(int idDonacion)
        {
            return await _context.Donaciones.Where(x => x.IdDonacion == idDonacion).FirstOrDefaultAsync();
        }
        public async Task<RespuestaOperacionDTO> RegistrarDonaciones(Donaciones Donaciones)
        {
            Donaciones.IdDonacion = default;
            Donaciones.Fecha = DateTime.Now;

            _context.Donaciones.Add(Donaciones);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.RegistroExitosoConDatos(Donaciones);
        }
        public async Task<RespuestaOperacionDTO> ActualizarDonaciones(Donaciones Donaciones)
        {
            _context.Donaciones.Update(Donaciones);
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.ExitoConDatos(Donaciones);
        }

        public async Task<RespuestaOperacionDTO> EliminarDonaciones(int idDonacion)
        {
            var Donaciones = await ObtenerDonacionById(idDonacion);
            if (Donaciones is null)
            {
                return RespuestaOperacionDTO.FalloConMensaje("El registro ya se encuentra eliminado");
            }
            _context.Entry(Donaciones).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RespuestaOperacionDTO.Exitoso();
        }

    }

}

