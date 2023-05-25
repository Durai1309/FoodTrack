using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace FoodTrack.Services.Identity
{
	public static class StaticData
	{
		public const string Admin = "Admin";
		public const string Customer = "Customer";

		public static IEnumerable<IdentityResource> IdentityResources
			=> new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Email(),
				new IdentityResources.Profile(),

			};

		public static IEnumerable<ApiScope> ApiScopes
			=> new List<ApiScope>
		{
			new ApiScope("FoodTrack","FoodTrack Server"),
			new ApiScope(name:"read",displayName:"Read Your data"),
			new ApiScope(name:"Write",displayName:"Write Your data"),
			new ApiScope(name:"delete",displayName:"delete Your data"),
		};

		public static IEnumerable<Client> Clients = new List<Client>
		{
			new Client
			{
				ClientId="client",
				ClientSecrets= { new Secret("secret".Sha256())},
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AllowedScopes={ "read", "write","profile"}
			},
			new Client
			{
				ClientId="FoodTrack",
				ClientSecrets= { new Secret("secret".Sha256())},
				AllowedGrantTypes = GrantTypes.Code,
				RedirectUris={ "https://localhost:44379/signin-oidc" },
				PostLogoutRedirectUris = { "https://localhost:44379/signout-callback-oidc" },
				   AllowedScopes=new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						IdentityServerConstants.StandardScopes.Email,
						"FoodTrack"
					}
			},
		};

	}
}




