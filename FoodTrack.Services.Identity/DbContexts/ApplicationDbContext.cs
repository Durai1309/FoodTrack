using FoodTrack.Services.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.Services.Identity.DbContexts
{
		public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
		{
			public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
			{

			}
		}
}
