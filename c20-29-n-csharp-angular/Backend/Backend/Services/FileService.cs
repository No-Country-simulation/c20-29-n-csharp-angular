
using Backend.Helper;
using Microsoft.AspNetCore.StaticFiles;

namespace Backend.Services
{
	public class ArchivoService
	{
		private const string _carpeta = "wwwroot/Uploads";

		public async Task<List<string>> GuardarListaArchivos(IFormFileCollection listaArchivos)
		{
			List<string> listaNombres = new List<string>();
			foreach (var item in listaArchivos)
			{
				string nombreArchivo = await GuardarArchivo(item);
				listaNombres.Add(nombreArchivo);
			}
			return listaNombres;
		}

		public async Task<string> GuardarArchivo(IFormFile archivo)
		{
			var ruta = Path.Combine(Directory.GetCurrentDirectory(), _carpeta);

			if (!Directory.Exists(ruta))
			{
				Directory.CreateDirectory(ruta);
			}

			string nombreArchivo = ObtenerNombreArchivo(archivo, true);
			string rutaConNombreArchivo = Path.Combine(ruta, nombreArchivo);

			using (var fileStream = new FileStream(rutaConNombreArchivo, FileMode.Create))
			{
				await archivo.CopyToAsync(fileStream);
			}

			if (File.Exists(rutaConNombreArchivo))
				return nombreArchivo;
			else
				return string.Empty;
		}

		private string ObtenerNombreArchivo(IFormFile archivo, bool hacerloUnico)
		{
			string nombre = Guid.NewGuid().ToString();
			string extension = ObtenerExtension(archivo);
			return nombre + extension;
		}

		private string ObtenerExtension(IFormFile file)
		{
			return (file != null) ? file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower()
								  : string.Empty;
		}

		public async Task<FileHelper> ObtenerArchivo(string nombre)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), _carpeta, nombre);
			if (!File.Exists(filePath))
			{
				return null;
			}

			var fileBytes = await File.ReadAllBytesAsync(filePath);

			var provider = new FileExtensionContentTypeProvider();
			string contentType;
			if (!provider.TryGetContentType(filePath, out contentType))
			{
				contentType = "application/octet-stream";
			}

			return new FileHelper()
			{
				FileBytes = fileBytes,
				MimeType = contentType,
				FileName = nombre
			};
		}
	}
}
