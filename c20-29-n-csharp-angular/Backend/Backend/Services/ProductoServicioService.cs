using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
	public class ProductoServicioService: IProductoServicioService
	{
		private readonly AppDbContext _appDbContext;

		public ProductoServicioService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Productoservicio>> ListarProductosServicios()
		{
			return await _appDbContext.Productoservicio.ToListAsync();
		}

		public async Task<Productoservicio> ObtenerProductoServicio(int idProductoServicio)
		{
			return await _appDbContext.Productoservicio.Where(x => x.IdProductoServicio == idProductoServicio).FirstOrDefaultAsync();
		}

		public async Task<RespuestaOperacionDTO> RegistrarProductoServicio(Productoservicio productoservicio)
		{
			productoservicio.IdProductoServicio = default;
			productoservicio.FechaRegistro = DateTime.Now;

			_appDbContext.Productoservicio.Add(productoservicio);
			await _appDbContext.SaveChangesAsync();
			return RespuestaOperacionDTO.RegistroExitosoConDatos(productoservicio);
		}

		public async Task<RespuestaOperacionDTO> ActualizarProductoServicioo(Productoservicio productoservicio)
		{
			_appDbContext.Productoservicio.Update(productoservicio);
			await _appDbContext.SaveChangesAsync();
			return RespuestaOperacionDTO.ExitoConDatos(productoservicio);
		}

		public async Task<RespuestaOperacionDTO> EliminarProductoServicio(int idProductoServicio)
		{
			var productoservicio = await ObtenerProductoServicio(idProductoServicio);
			if (productoservicio is null)
			{
				return RespuestaOperacionDTO.FalloConMensaje("El registro ya se encuentra eliminado");
			}
			_appDbContext.Entry(productoservicio).State = EntityState.Deleted;
			await _appDbContext.SaveChangesAsync();
			return RespuestaOperacionDTO.Exitoso();
		}
	}
}
