using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Context
{
	public class AppDbContext : BdC2029NCsharpAngularContext
	{
		public AppDbContext(IConfiguration configuration) : base(configuration) { }
	}
}
