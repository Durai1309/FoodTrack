using Microsoft.AspNetCore.Identity;

namespace FoodTrack.Services.Indentity.Models
{
	public class ApplicationUser :IdentityUser
	{

		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
