
using Backend.Data;
using Backend.Models;
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

            //builder.Services.AddDbContext<AppDbContext>(options =>
            //	options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            //	new MySqlServerVersion(new Version(8,0,21))));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<IComentarioRepositorio, ComentarioRepositorio>();
            //Cors policy
            builder.Services.AddCors((options) =>
            {
                options.AddPolicy("DevCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
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


            app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
