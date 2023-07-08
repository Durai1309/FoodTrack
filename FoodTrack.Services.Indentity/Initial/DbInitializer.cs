using FoodTrack.Services.Indentity.DbContexts;
using FoodTrack.Services.Indentity.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodTrack.Services.Indentity.Initial
{
	public class DbInitializer : IDbInitializer
	{
         private readonly ApplicationDbContext _db;
		 private readonly UserManager<ApplicationUser> _userManager;
		 private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_roleManager = roleManager;
			_userManager = userManager;
		}
		public void Initial()
		{
			throw new NotImplementedException();
		}
	}
}
