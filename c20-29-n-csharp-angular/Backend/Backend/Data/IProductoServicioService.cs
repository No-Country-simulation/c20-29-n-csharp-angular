using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public interface IProductoServicioService
	{
		Task<List<Productoservicio>> ListarProductosServicios();
		Task<Productoservicio> ObtenerProductoServicio(int idProductoServicio);
		Task<RespuestaOperacionDTO> RegistrarProductoServicio(Productoservicio productoservicio);
		Task<RespuestaOperacionDTO> ActualizarProductoServicioo(Productoservicio productoservicio);
		Task<RespuestaOperacionDTO> EliminarProductoServicio(int idProductoServicio);
	}
}
