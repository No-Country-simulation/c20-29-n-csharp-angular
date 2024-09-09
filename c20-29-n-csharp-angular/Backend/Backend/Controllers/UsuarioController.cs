using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly AppDbContext _comRepositorio;

		public UsuarioController(AppDbContext appDbContext)
        {
			_comRepositorio = appDbContext;
		}

		[HttpGet("ListarUsuarios")]
		public async Task<IActionResult> ListarUsuarios()
		{
			var response = await _comRepositorio.Usuario.ToListAsync();
			return Ok(response);
		}
    }
}
