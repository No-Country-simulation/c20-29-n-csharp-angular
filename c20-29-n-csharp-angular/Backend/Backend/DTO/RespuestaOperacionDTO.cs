namespace Backend.DTO
{
	public class RespuestaOperacionDTO
	{
		public bool EsExitoso { get; set; }
		public string Mensaje { get; set; }
		public dynamic Datos { get; set; }

		public static RespuestaOperacionDTO Exitoso()
		{
			return new RespuestaOperacionDTO() { EsExitoso = true };
		}

		public static RespuestaOperacionDTO ExitoConDatos(dynamic Datos = null)
		{
			return new RespuestaOperacionDTO() { EsExitoso = true, Datos = Datos };
		}

		public static RespuestaOperacionDTO FalloConMensaje(string Mensaje)
		{
			return new RespuestaOperacionDTO() { EsExitoso = false, Mensaje = Mensaje };
		}
	}

	public class RespuestaOperacionDTO<S> : RespuestaOperacionDTO
	{
		public new bool EsExitoso { get; set; }
		public new string Mensaje { get; set; }
		public new S Datos { get; set; }

		public static RespuestaOperacionDTO<S> ExitoConDatos(S Datos)
		{
			return new RespuestaOperacionDTO<S>() { EsExitoso = true, Datos = Datos };
		}
	}
}
