
using Backend.Data;
using Backend.Models;
using Backend.Services;
using Backend.Services.interfaces;
using Backend.Servicios;
using Backend.Servicios.Interfaces;
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

            builder.Services.AddScoped<IComentariosService, ComentarioService>();
            builder.Services.AddScoped<IDonacionesService, DonacionesService>();

            //var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
            //builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


            var app = builder.Build();

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
