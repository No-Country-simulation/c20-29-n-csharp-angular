using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Adopciones> Adopciones { get; set; }

        public virtual DbSet<Apadrinamientos> Apadrinamientos { get; set; }

        public virtual DbSet<Comentarios> Comentarios { get; set; }

        public virtual DbSet<Donaciones> Donaciones { get; set; }

        //public virtual DbSet<Mascotas> Mascotas { get; set; }

        public virtual DbSet<MeGusta> MeGusta { get; set; }

        public virtual DbSet<Post> Post { get; set; }

        public virtual DbSet<Refugios> Refugios { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
