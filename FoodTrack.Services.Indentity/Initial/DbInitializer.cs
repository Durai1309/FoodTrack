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
			if(_roleManager.FindByNameAsync(StaticData.Admin).Result == null)
			{
				_roleManager.CreateAsync(new IdentityRole(StaticData.Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(StaticData.Customer)).GetAwaiter().GetResult();

			}
			else
			{
				return;
			}
		}
	}
}
