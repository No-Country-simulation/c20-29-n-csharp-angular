using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.Data
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly AppDbContext _comRepositorio;
        public ComentarioRepositorio(AppDbContext appDbContext)
        {
            _comRepositorio = appDbContext;
        }
        public bool GuardarCambios()
        {
            return _comRepositorio.SaveChanges() > 0;
        }
        public async Task<Comentario> EliminarEntidad(int idComentario)
        {
            Comentario comentario = await UnicoComentario(idComentario);
            if (comentario != null)
            {
                _comRepositorio.Comentarios.Remove(comentario);
                GuardarCambios();
            }
            return comentario;
        }
        public void AgregarEntidad<T>(T endidad)
        {
            _comRepositorio.Add(endidad);
        }
        public async Task<Comentario> UnicoComentario(int idComentario)
        {
            Comentario? comentario = await _comRepositorio.Comentarios.FindAsync(idComentario);

            return comentario;
        }
        public bool ExisteComentario(int idComentario)
        {
            return _comRepositorio.Comentarios.Any(e => e.IdComentario == idComentario);
        }
       
        
        public async Task<List<Comentario>> GetComentariosAsync()
        {
           var comentarios = await _comRepositorio.Comentarios.ToListAsync();
            return comentarios;
        }
        public async Task<Comentario> GetUnicoComentarioAsync(int idComentario)
        {
            try
            {
                Comentario? comentario = await UnicoComentario(idComentario);
                if (comentario == null)
                {
                    throw (new Exception("No se encontro el comentario."));
                }
                return comentario;
            }
            catch (Exception ex)
            {
                throw (new Exception($"No se encontro el comentario. ${ex.Message}"));
            }
        }
        public async Task<Comentario> PostComentarioAsync(Comentario comentario)
        {
            if (
                comentario == null ||
                comentario.IdPost == null ||
                comentario.Texto == null ||
                comentario.Fecha == null ||
                comentario.IdUsuario == null
                )
            {
                throw (new Exception("Alguna de la data del comentario es nula."));
            }

            try
            {
                Comentario comentarioToDb = new Comentario();

                comentarioToDb.Texto = comentario.Texto;
                comentarioToDb.Fecha = comentario.Fecha;
                comentarioToDb.IdPost = comentario.IdPost;
                comentarioToDb.IdUsuario = comentario.IdUsuario;



                AgregarEntidad(comentarioToDb);
                if (GuardarCambios())
                {
                    return comentarioToDb;
                }
                else
                {
                    throw (new Exception("Alguna de la data del comentario es nula."));
                }
            }
            catch (DbUpdateException ex)
            {

                throw (new Exception("Alguna de la data del comentario es nula."));
            }
        }


       
        public async Task<Comentario> PutComentarioAsync(int idComentario, Comentario comentario)
        {
            Comentario comentarioEnDb = await UnicoComentario(idComentario);

            if (idComentario != comentarioEnDb.IdComentario)
            {
                throw (new Exception("Id comentario no coincide."));
            }

            try
            {
                comentarioEnDb.Texto = comentario.Texto;

                _comRepositorio.Entry(comentarioEnDb).State = EntityState.Modified;
                if (GuardarCambios())
                {
                    return comentarioEnDb;
                        
                }
                else
                {
                    throw (new Exception("Comentario no encontrado."));
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteComentario(idComentario))
                {
                    throw (new Exception("Comentario no encontrado."));
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<Comentario> DeleteComentario(int idComentario)
        {
            try
            {
                if (!ExisteComentario(idComentario))
                {
                    throw (new Exception($"No se encontro el comentario con ID {idComentario}."));
                }
                Comentario comentario = await UnicoComentario(idComentario);

                Comentario comentarioEliminado = await EliminarEntidad(comentario.IdComentario);

                if (comentarioEliminado != null)
                {
                    return comentarioEliminado;
                }
                else
                {
                    throw (new Exception($"No se encontro el comentario con ID {idComentario}."));
                }
            }
            catch (DbUpdateException ex)
            {

                throw (new Exception($"No se encontro el comentario con ID {ex.Message}."));
            }
        }
    }
}
