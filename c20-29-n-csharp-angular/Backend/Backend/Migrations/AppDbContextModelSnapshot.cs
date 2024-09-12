﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.Models.Adopciones", b =>
                {
                    b.Property<int>("IdAdopcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IdFormulario")
                        .HasColumnType("int");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioAdopcion")
                        .HasColumnType("int");

                    b.HasKey("IdAdopcion");

                    b.HasIndex("IdPost");

                    b.HasIndex("IdUsuarioAdopcion");

                    b.ToTable("Adopciones");
                });

            modelBuilder.Entity("Backend.Models.Apadrinamientos", b =>
                {
                    b.Property<int>("IdApadrinamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IdPadrino")
                        .HasColumnType("int");

                    b.Property<int?>("IdPost")
                        .HasColumnType("int");

                    b.HasKey("IdApadrinamiento");

                    b.HasIndex("IdPadrino");

                    b.HasIndex("IdPost");

                    b.ToTable("Apadrinamientos");
                });

            modelBuilder.Entity("Backend.Models.Comentarios", b =>
                {
                    b.Property<int>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .HasColumnType("longtext");

                    b.HasKey("IdComentario");

                    b.HasIndex("IdPost");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Backend.Models.Donaciones", b =>
                {
                    b.Property<int>("IdDonacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioDonate")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioPeticion")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("IdDonacion");

                    b.HasIndex("IdPost");

                    b.HasIndex("IdUsuarioDonate");

                    b.HasIndex("IdUsuarioPeticion");

                    b.ToTable("Donaciones");
                });

            modelBuilder.Entity("Backend.Models.Formularios", b =>
                {
                    b.Property<int>("IdFormularios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApellidoRef")
                        .HasColumnType("longtext");

                    b.Property<string>("Contacto")
                        .HasColumnType("longtext");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("FechaFundacion")
                        .HasColumnType("date");

                    b.Property<int>("IdProdcutoServicio")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDocumento")
                        .HasColumnType("int");

                    b.Property<string>("NombreRef")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreRefugio")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.Property<string>("TelefonoRef")
                        .HasColumnType("longtext");

                    b.Property<bool>("Terminos")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TipoFormulario")
                        .HasColumnType("longtext");

                    b.Property<int>("TipoOrganizacion")
                        .HasColumnType("int");

                    b.HasKey("IdFormularios");

                    b.ToTable("Formularios");
                });

            modelBuilder.Entity("Backend.Models.Megusta", b =>
                {
                    b.Property<int>("IdMeGusta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("Bborrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdMeGusta");

                    b.HasIndex("IdPost");

                    b.ToTable("Megusta");
                });

            modelBuilder.Entity("Backend.Models.Post", b =>
                {
                    b.Property<int>("IdPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoriaPost")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("MultimediaPost")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoPost")
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("IdPost");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Backend.Models.Productoservicio", b =>
                {
                    b.Property<int>("IdProductoServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("DescripcionProducto")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("MultimediaProducto")
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroIdentificacionFiscal")
                        .HasColumnType("longtext");

                    b.Property<string>("RedesSociales")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoProducto")
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("IdProductoServicio");

                    b.ToTable("Productoservicio");
                });

            modelBuilder.Entity("Backend.Models.Refugios", b =>
                {
                    b.Property<int>("IdRefugio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AnioFundacion")
                        .HasColumnType("int");

                    b.Property<string>("DatosContacto")
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentoLegal")
                        .HasColumnType("longtext");

                    b.Property<string>("FotosRefugio")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("RedesSociales")
                        .HasColumnType("longtext");

                    b.Property<string>("TestimoniosReferencias")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoOrganizacion")
                        .HasColumnType("longtext");

                    b.Property<string>("UbicacionFisica")
                        .HasColumnType("longtext");

                    b.Property<string>("VideoPresentacion")
                        .HasColumnType("longtext");

                    b.HasKey("IdRefugio");

                    b.ToTable("Refugios");
                });

            modelBuilder.Entity("Backend.Models.Tipodocumento", b =>
                {
                    b.Property<int>("IdTipoDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.HasKey("IdTipoDocumento");

                    b.ToTable("Tipodocumento");
                });

            modelBuilder.Entity("Backend.Models.Tipoorganizacion", b =>
                {
                    b.Property<int>("IdTipoOrganizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.HasKey("IdTipoOrganizacion");

                    b.ToTable("Tipoorganizacion");
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("Contrasenia")
                        .HasColumnType("longtext");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Perfil")
                        .HasColumnType("longtext");

                    b.Property<string>("UrlFoto")
                        .HasColumnType("longtext");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Backend.Models.Adopciones", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("Adopciones")
                        .HasForeignKey("IdPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Usuario", "UsuarioAdopcion")
                        .WithMany()
                        .HasForeignKey("IdUsuarioAdopcion");

                    b.Navigation("Post");

                    b.Navigation("UsuarioAdopcion");
                });

            modelBuilder.Entity("Backend.Models.Apadrinamientos", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("Apadrinamientos")
                        .HasForeignKey("IdPadrino");

                    b.HasOne("Backend.Models.Usuario", "Padrino")
                        .WithMany()
                        .HasForeignKey("IdPost");

                    b.Navigation("Padrino");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Backend.Models.Comentarios", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdPost");

                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario");

                    b.Navigation("Post");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Backend.Models.Donaciones", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("Donaciones")
                        .HasForeignKey("IdPost");

                    b.HasOne("Backend.Models.Usuario", "UsuarioDonate")
                        .WithMany("ListaUsuarioDonate")
                        .HasForeignKey("IdUsuarioDonate");

                    b.HasOne("Backend.Models.Usuario", "UsuarioPeticion")
                        .WithMany("ListaUsuarioPeticion")
                        .HasForeignKey("IdUsuarioPeticion");

                    b.Navigation("Post");

                    b.Navigation("UsuarioDonate");

                    b.Navigation("UsuarioPeticion");
                });

            modelBuilder.Entity("Backend.Models.Megusta", b =>
                {
                    b.HasOne("Backend.Models.Post", "Post")
                        .WithMany("Megusta")
                        .HasForeignKey("IdPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Backend.Models.Post", b =>
                {
                    b.HasOne("Backend.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Backend.Models.Post", b =>
                {
                    b.Navigation("Adopciones");

                    b.Navigation("Apadrinamientos");

                    b.Navigation("Comentarios");

                    b.Navigation("Donaciones");

                    b.Navigation("Megusta");
                });

            modelBuilder.Entity("Backend.Models.Usuario", b =>
                {
                    b.Navigation("ListaUsuarioDonate");

                    b.Navigation("ListaUsuarioPeticion");
                });
#pragma warning restore 612, 618
        }
    }
}
