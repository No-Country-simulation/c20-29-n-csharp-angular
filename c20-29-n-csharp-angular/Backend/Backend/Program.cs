using Backend.Data;
using Backend.Models;
using Backend.Services;
using Backend.Services.interfaces;
using Backend.Servicios.Interfaces;
using Backend.Servicios;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("AppDbConnectionString"),
                new MySqlServerVersion(new Version(10, 4, 32))));

            builder.Services.AddTransient<UsuarioService>();
            builder.Services.AddTransient<ArchivoService>();
            builder.Services.AddTransient<UsuarioService>();
            builder.Services.AddTransient<ArchivoService>();
            builder.Services.AddScoped<IComentariosService, ComentarioService>();
            builder.Services.AddScoped<IDonacionesService, DonacionesService>();
            builder.Services.AddScoped<IRefugioService, RefugioService>();
            builder.Services.AddScoped<IProductoServicioService, ProductoServicioService>();
            builder.Services.AddScoped<IPostService, PostService>();

            //var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
            //builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            //Cors policy
            builder.Services.AddCors((options) =>
            {
                options.AddPolicy("DevCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000", "http://127.0.0.1:8080")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

                options.AddPolicy("ProdCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("https://productionSite.com")
                    .AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("DevCors");
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseCors("ProdCors");
                app.UseHttpsRedirection();
            }

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI();
            //}

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
