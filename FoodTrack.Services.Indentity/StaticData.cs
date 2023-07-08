using Duende.IdentityServer.Models;

namespace FoodTrack.Services.Indentity
{
	public static class StaticData
	{
		public const string Admin = "Admin";
		public const string Customer = "Customer";

		public static IEnumerable<IdentityResource> IdentityResources =>
				 new List<IdentityResource>
				 {
					 new IdentityResources.OpenId(),
					 new IdentityResources.Email(),
					 new IdentityResources.Profile()
				 };

		public static IEnumerable<ApiScope> ApiScopes =>
			new List<ApiScope>
			{
				  new ApiScope("FoodTrack", "FoodTrack Server"),
				  new ApiScope(name : "read", displayName:"Read your data."),
				  new ApiScope(name : "write",displayName : "Write your data."),
				  new ApiScope(name:"delete" ,displayName:"Delete your data")
			};

	}
}
