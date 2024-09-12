using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.Services
{
    public class ComentarioService : IComentariosService
    {
        private readonly AppDbContext _comRepositorio;
        public ComentarioService(AppDbContext appDbContext)
        {
            _comRepositorio = appDbContext;
        }
        public bool GuardarCambios()
        {
            return _comRepositorio.SaveChanges() > 0;
        }
        public async Task<Comentarios> EliminarEntidad(int IdComentario)
        {
            Comentarios Comentarios = await UnicoComentario(IdComentario);
            if (Comentarios != null)
            {
                _comRepositorio.Comentarios.Remove(Comentarios);
                GuardarCambios();
            }
            return Comentarios;
        }
        public void AgregarEntidad<T>(T endidad)
        {
            _comRepositorio.Add(endidad);
        }
        public async Task<Comentarios> UnicoComentario(int IdComentario)
        {
            Comentarios Comentarios = await _comRepositorio.Comentarios.FindAsync(IdComentario);

            return Comentarios;
        }
        public bool ExisteComentario(int IdComentario)
        {
            return _comRepositorio.Comentarios.Any(e => e.IdComentario == IdComentario);
        }


        public async Task<List<Comentarios>> GetComentariosAsync()
        {
            var Comentarios = await _comRepositorio.Comentarios.ToListAsync();
            return Comentarios;
        }
        public async Task<Comentarios> GetUnicoComentarioAsync(int IdComentario)
        {
            try
            {
                Comentarios Comentarios = await UnicoComentario(IdComentario);
                if (Comentarios == null)
                {
                    throw new Exception("No se encontro el Comentarios.");
                }
                return Comentarios;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se encontro el Comentarios. ${ex.Message}");
            }
        }
        public async Task<Comentarios> PostComentarioAsync(Comentarios Comentarios)
        {
            if (
                Comentarios == null ||
                Comentarios.IdPost == null ||
                Comentarios.Texto == null ||
                Comentarios.Fecha == null ||
                Comentarios.IdUsuario == null
                )
            {
                throw new Exception("Alguna de la data del Comentarios es nula.");
            }

            try
            {
                Comentarios ComentariosToDb = new Comentarios();

                ComentariosToDb.Texto = Comentarios.Texto;
                ComentariosToDb.Fecha = Comentarios.Fecha;
                ComentariosToDb.IdPost = Comentarios.IdPost;
                ComentariosToDb.IdUsuario = Comentarios.IdUsuario;



                AgregarEntidad(ComentariosToDb);
                if (GuardarCambios())
                {
                    return ComentariosToDb;
                }
                else
                {
                    throw new Exception("Alguna de la data del Comentarios es nula.");
                }
            }
            catch (DbUpdateException ex)
            {

                throw new Exception("Alguna de la data del Comentarios es nula.");
            }
        }



        public async Task<Comentarios> PutComentarioAsync(int IdComentario, Comentarios Comentarios)
        {
            Comentarios ComentariosEnDb = await UnicoComentario(IdComentario);

            if (IdComentario != ComentariosEnDb.IdComentario)
            {
                throw new Exception("Id Comentarios no coincide.");
            }

            try
            {
                ComentariosEnDb.Texto = Comentarios.Texto;

                _comRepositorio.Entry(ComentariosEnDb).State = EntityState.Modified;
                if (GuardarCambios())
                {
                    return ComentariosEnDb;

                }
                else
                {
                    throw new Exception("Comentarios no encontrado.");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteComentario(IdComentario))
                {
                    throw new Exception("Comentarios no encontrado.");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<Comentarios> DeleteComentario(int IdComentario)
        {
            try
            {
                if (!ExisteComentario(IdComentario))
                {
                    throw new Exception($"No se encontro el Comentarios con ID {IdComentario}.");
                }
                Comentarios Comentarios = await UnicoComentario(IdComentario);

                Comentarios ComentariosEliminado = await EliminarEntidad(Comentarios.IdComentario);

                if (ComentariosEliminado != null)
                {
                    return ComentariosEliminado;
                }
                else
                {
                    throw new Exception($"No se encontro el Comentarios con ID {IdComentario}.");
                }
            }
            catch (DbUpdateException ex)
            {

                throw new Exception($"No se encontro el Comentarios con ID {ex.Message}.");
            }
        }
    }
}
