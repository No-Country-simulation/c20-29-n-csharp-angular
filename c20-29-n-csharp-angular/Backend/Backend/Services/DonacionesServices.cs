using Backend.Data;
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

        public async Task<IEnumerable<Donaciones>> GetDonaciones()
        {
            try
            {
                return await _context.Donaciones.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las donaciones", ex);
            }
        }
        public async Task<Donaciones> GetDonacionById(int idDonacion)
        {
            try
            {
                Donaciones donaciones = await GetOneDonacion(idDonacion);
                if (donaciones == null)
                {
                    throw new Exception("No se encontro la donacion.");
                }
                return donaciones;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se encontro la donacion. ${ex.Message}");
            }
        }

        public async Task<Donaciones> PostDonacion(Donaciones donacion)
        {
            if (
                donacion == null ||
                donacion.Monto == null ||
                donacion.Fecha == null ||
                donacion.IdPost == null ||
                donacion.IdUsuarioDonate == null ||
                donacion.IdUsuarioPeticion == null
                )
            {
                throw (new Exception("data null."));
            }

            try
            {
                Donaciones donaciondb = new Donaciones();

                donacion.Monto = donacion.Monto;
                donacion.Fecha = donacion.Fecha;
                donacion.IdPost = donacion.IdPost;
                donacion.IdUsuarioDonate = donacion.IdUsuarioDonate;
                donacion.IdUsuarioPeticion = donacion.IdUsuarioPeticion;

                AgregarEntidad(donaciondb);
                if (GuardarCambios())
                {
                    return donaciondb;
                }
                else
                {
                    throw (new Exception("data null."));
                }
            }
            catch (DbUpdateException ex)
            {

                throw (new Exception("data null."));
            }
        }
        //put
        public async Task<Donaciones> UpdateDonacion(int idDonacion, Donaciones donacion)
        {
            Donaciones donacionc = await GetOneDonacion(idDonacion);

            if (idDonacion != donacionc.IdDonacion)
            {
                throw (new Exception("Id donacion no coincide."));
            }
            try
            {
                donacionc.Monto = donacion.Monto;
                donacionc.Fecha = donacion.Fecha;
                donacionc.IdUsuarioPeticion = donacionc.IdUsuarioPeticion;
                donacionc.IdUsuarioDonate = donacionc.IdUsuarioDonate;

                _context.Entry(donacionc).State = EntityState.Modified;
                if (GuardarCambios()) { return donacionc; }

                else { throw (new Exception("donacion no encontrada")); }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteDonacion(idDonacion))
                {
                    throw (new Exception("donacion no encontrada"));
                }
                else
                {
                    throw;
                }
            }

        }
        public async Task<Donaciones> DeleteDonacion(int idDonacion)
        {
            try
            {
                if (!ExisteDonacion(idDonacion))
                {
                    throw (new Exception($"No se encontro idDonacion {idDonacion}."));
                }
                Donaciones donacion = await GetOneDonacion(idDonacion);

                Donaciones donaciondelete = await DeleteModelo(donacion.IdDonacion);

                if (donaciondelete != null)
                {
                    return donaciondelete;
                }
                else
                {
                    throw (new Exception($"No se encontro idDonacion {idDonacion}."));
                }

            }
            catch (DbUpdateException ex)
            {

                throw (new Exception($"No se encontro idDonacion {ex.Message}."));
            }
        }
        //---
        public bool GuardarCambios()
        {
            return _context.SaveChanges() > 0;
        }
        public async Task<Donaciones> DeleteModelo(int idDonacion)
        {
            Donaciones donacion = await GetDonacionById(idDonacion);
            if (donacion != null)
            {
                _context.Donaciones.Remove(donacion);
                GuardarCambios();
            }
            return donacion;
        }
        public bool ExisteDonacion(int idDonacion)
        {
            return _context.Donaciones.Any(x => x.IdDonacion == idDonacion);
        }
        public void AgregarEntidad<T>(T endidad)
        {
            _context.Add(endidad);
        }
        public async Task<Donaciones> GetOneDonacion(int idDonacion)
        {
            Donaciones donaciones = await _context.Donaciones.FindAsync(idDonacion);

            return donaciones;
        }

        //---


    }

}

