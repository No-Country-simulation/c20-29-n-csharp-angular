using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Backend.Models;

public partial class BdC2029NCsharpAngularContext : DbContext
{
	protected readonly IConfiguration _configuration;

	public BdC2029NCsharpAngularContext()
    {
    }

	public BdC2029NCsharpAngularContext(IConfiguration configuration)
		: base()
	{
		_configuration = configuration;
	}

	public virtual DbSet<Adopciones> Adopciones { get; set; }

    public virtual DbSet<Apadrinamientos> Apadrinamientos { get; set; }

    public virtual DbSet<Comentarios> Comentarios { get; set; }

    public virtual DbSet<Donaciones> Donaciones { get; set; }

    public virtual DbSet<Mascotas> Mascotas { get; set; }

    public virtual DbSet<MeGusta> MeGusta { get; set; }

    public virtual DbSet<Post> Post { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Refugios> Refugios { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseMySql(_configuration.GetConnectionString("BD"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.6-mariadb"));
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Adopciones>(entity =>
        {
            entity.HasKey(e => e.IdAdopcion).HasName("PRIMARY");

            entity.ToTable("adopciones");

            entity.HasIndex(e => e.IdMascota, "ID_Mascota");

            entity.HasIndex(e => e.IdPost, "ID_Post");

            entity.Property(e => e.IdAdopcion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Adopcion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.IdMascota)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.IdPost)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Post");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Adopciones)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("adopciones_ibfk_2");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Adopciones)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("adopciones_ibfk_1");
        });

        modelBuilder.Entity<Apadrinamientos>(entity =>
        {
            entity.HasKey(e => e.IdApadrinamiento).HasName("PRIMARY");

            entity.ToTable("apadrinamientos");

            entity.HasIndex(e => e.IdMascota, "ID_Mascota");

            entity.HasIndex(e => e.IdPost, "ID_Post");

            entity.Property(e => e.IdApadrinamiento)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Apadrinamiento");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.IdMascota)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.IdPost)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Post");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Apadrinamientos)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("apadrinamientos_ibfk_2");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Apadrinamientos)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("apadrinamientos_ibfk_1");
        });

        modelBuilder.Entity<Comentarios>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PRIMARY");

            entity.ToTable("comentarios");

            entity.HasIndex(e => e.IdMascota, "ID_Mascota");

            entity.HasIndex(e => e.IdPost, "ID_Post");

            entity.HasIndex(e => e.IdProducto, "ID_Producto");

            entity.Property(e => e.IdComentario)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Comentario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.IdMascota)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.IdPost)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Post");
            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Producto");
            entity.Property(e => e.Texto).HasColumnType("text");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentarios_ibfk_2");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentarios_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comentarios_ibfk_3");
        });

        modelBuilder.Entity<Donaciones>(entity =>
        {
            entity.HasKey(e => e.IdDonacion).HasName("PRIMARY");

            entity.ToTable("donaciones");

            entity.HasIndex(e => e.IdPost, "ID_Post");

            entity.HasIndex(e => e.IdRefugio, "ID_Refugio");

            entity.Property(e => e.IdDonacion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Donacion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.IdPost)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Post");
            entity.Property(e => e.IdRefugio)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Refugio");
            entity.Property(e => e.Monto).HasPrecision(10, 2);

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("donaciones_ibfk_1");

            entity.HasOne(d => d.IdRefugioNavigation).WithMany(p => p.Donaciones)
                .HasForeignKey(d => d.IdRefugio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("donaciones_ibfk_2");
        });

        modelBuilder.Entity<Mascotas>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PRIMARY");

            entity.ToTable("mascotas");

            entity.HasIndex(e => e.IdRefugio, "ID_Refugio");

            entity.Property(e => e.IdMascota)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Publicacion");
            entity.Property(e => e.FotoVideo)
                .HasColumnType("text")
                .HasColumnName("Foto_Video");
            entity.Property(e => e.IdRefugio)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Refugio");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRefugioNavigation).WithMany(p => p.Mascotas)
                .HasForeignKey(d => d.IdRefugio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mascotas_ibfk_1");
        });

        modelBuilder.Entity<MeGusta>(entity =>
        {
            entity.HasKey(e => e.IdMeGusta).HasName("PRIMARY");

            entity.ToTable("me_gusta");

            entity.HasIndex(e => e.IdMascota, "ID_Mascota");

            entity.HasIndex(e => e.IdPost, "ID_Post");

            entity.HasIndex(e => e.IdProducto, "ID_Producto");

            entity.Property(e => e.IdMeGusta)
                .HasColumnType("int(11)")
                .HasColumnName("ID_MeGusta");
            entity.Property(e => e.IdMascota)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Mascota");
            entity.Property(e => e.IdPost)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Post");
            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Producto");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.MeGusta)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("me_gusta_ibfk_2");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.MeGusta)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("me_gusta_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.MeGusta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("me_gusta_ibfk_3");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("PRIMARY");

            entity.ToTable("post");

            entity.HasIndex(e => e.IdRefugio, "ID_Refugio");

            entity.Property(e => e.IdPost)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Post");
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Publicacion");
            entity.Property(e => e.FotoVideo)
                .HasColumnType("text")
                .HasColumnName("Foto_Video");
            entity.Property(e => e.IdRefugio)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Refugio");
            entity.Property(e => e.NumeroIdentificacionFiscal)
                .HasMaxLength(50)
                .HasColumnName("Numero_Identificacion_Fiscal");
            entity.Property(e => e.Precio).HasPrecision(10, 2);
            entity.Property(e => e.RedesSociales)
                .HasMaxLength(255)
                .HasColumnName("Redes_Sociales");
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoPost)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Post");
            entity.Property(e => e.TipoProveedor)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Proveedor");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdRefugioNavigation).WithMany(p => p.Post)
                .HasForeignKey(d => d.IdRefugio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("post_ibfk_1");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdProveedor, "ID_Proveedor");

            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Producto");
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Proveedor");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("productos_ibfk_1");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Proveedor");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Completo");
            entity.Property(e => e.NumeroIdentificacionFiscal)
                .HasMaxLength(50)
                .HasColumnName("Numero_Identificacion_Fiscal");
            entity.Property(e => e.RedesSociales)
                .HasMaxLength(255)
                .HasColumnName("Redes_Sociales");
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoProveedor)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Proveedor");
        });

        modelBuilder.Entity<Refugios>(entity =>
        {
            entity.HasKey(e => e.IdRefugio).HasName("PRIMARY");

            entity.ToTable("refugios");

            entity.Property(e => e.IdRefugio)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Refugio");
            entity.Property(e => e.AñoFundacion)
                .HasColumnType("int(11)")
                .HasColumnName("Año_Fundacion");
            entity.Property(e => e.DatosContacto)
                .HasMaxLength(255)
                .HasColumnName("Datos_Contacto");
            entity.Property(e => e.DocumentoLegal)
                .HasColumnType("text")
                .HasColumnName("Documento_Legal");
            entity.Property(e => e.FotosRefugio)
                .HasColumnType("text")
                .HasColumnName("Fotos_Refugio");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RedesSociales)
                .HasColumnType("text")
                .HasColumnName("Redes_Sociales");
            entity.Property(e => e.TestimoniosReferencias)
                .HasColumnType("text")
                .HasColumnName("Testimonios_Referencias");
            entity.Property(e => e.TipoOrganizacion)
                .HasColumnType("enum('Mascota','Servicio','Producto')")
                .HasColumnName("Tipo_Organizacion");
            entity.Property(e => e.UbicacionFisica)
                .HasColumnType("text")
                .HasColumnName("Ubicacion_Fisica");
            entity.Property(e => e.VideoPresentacion)
                .HasColumnType("text")
                .HasColumnName("Video_Presentacion");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.HasIndex(e => e.IdProveedor, "ID_Proveedor");

            entity.Property(e => e.IdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Servicio");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.IdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Proveedor");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(50)
                .HasColumnName("Tipo_Servicio");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("servicios_ibfk_1");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.CorreoElectronico, "Correo_Electronico").IsUnique();

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Perfil).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
