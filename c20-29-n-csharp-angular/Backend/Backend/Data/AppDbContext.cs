using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Adopciones> Adopciones { get; set; }

        public DbSet<Apadrinamientos> Apadrinamientos { get; set; }

        public DbSet<Comentarios> Comentarios { get; set; }

        public DbSet<Donaciones> Donaciones { get; set; }

        //public virtual DbSet<Mascotas> Mascotas { get; set; }

        public DbSet<MeGusta> MeGusta { get; set; }

        public DbSet<Post> Post { get; set; }

        public DbSet<Refugios> Refugios { get; set; }

        public DbSet<Usuarios> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    _configuration.GetConnectionString("DefaultConnectionString"),
                    new MySqlServerVersion(new Version(8, 0, 30)), // Adjust the version based on your MySQL server version
                    options => options.EnableRetryOnFailure()
                );
            }
        }

    }
}
