using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;

		public UsuarioController(AppDbContext appDbContext)
        {
			_appDbContext = appDbContext;
		}

		[HttpGet("ListarUsuarios")]
		public async Task<IActionResult> ListarUsuarios()
		{
			var response = await _appDbContext.Usuarios.ToListAsync();
			return Ok(response);
		}
	}
}
