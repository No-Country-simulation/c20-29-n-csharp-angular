using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Adopciones> Adopciones { get; set; }

        public DbSet<Apadrinamientos> Apadrinamientos { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Donaciones> Donaciones { get; set; }

        //public virtual DbSet<Mascotas> Mascotas { get; set; }

        public DbSet<MeGusta> MeGusta { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Refugios> Refugios { get; set; }

        public DbSet<Usuarios> Usuario { get; set; }
    }
}
