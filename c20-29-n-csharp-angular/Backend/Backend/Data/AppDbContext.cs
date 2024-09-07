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

		public virtual DbSet<Formularios> Formularios { get; set; }

		public virtual DbSet<Megusta> Megusta { get; set; }

		public virtual DbSet<Post> Post { get; set; }

		public virtual DbSet<Productoservicio> Productoservicio { get; set; }

		public virtual DbSet<Refugios> Refugios { get; set; }

		public virtual DbSet<Tipodocumento> Tipodocumento { get; set; }

		public virtual DbSet<Tipoorganizacion> Tipoorganizacion { get; set; }

		public virtual DbSet<Usuario> Usuario { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
