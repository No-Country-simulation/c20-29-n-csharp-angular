namespace Backend.DTO
{
	public class RespuestaOperacionDTO
	{
		public int State { get; set; }
		public string Message { get; set; }
		public dynamic Data { get; set; }

		public static RespuestaOperacionDTO Exitoso()
		{
			return new RespuestaOperacionDTO() { State = 200 };
		}

		public static RespuestaOperacionDTO ExitoConDatos(dynamic Data = null)
		{
			return new RespuestaOperacionDTO() { State = 200, Data = Data };
		}

		public static RespuestaOperacionDTO RegistroExitosoConDatos(dynamic Data = null)
		{
			return new RespuestaOperacionDTO() { State = 201, Data = Data };
		}

		public static RespuestaOperacionDTO FalloConMensaje(string Mensaje)
		{
			return new RespuestaOperacionDTO() { State = 400, Message = Mensaje };
		}
	}

	public class RespuestaOperacionDTO<S> : RespuestaOperacionDTO
	{
		public int State { get; set; }
		public string Message { get; set; }
		public new S Data { get; set; }

		public static RespuestaOperacionDTO<S> ExitoConDatos(S Data)
		{
			return new RespuestaOperacionDTO<S>() { State = 200, Data = Data };
		}
	}
}
