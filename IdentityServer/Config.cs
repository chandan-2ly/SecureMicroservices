using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                //new Client
                //{
                //    ClientId = "movieClient",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = {new Secret("secret".Sha256())},
                //    AllowedScopes = {"movieAPI"}
                //},
                new Client
                {
                    ClientId = "movies_mvc_client",
                    ClientName = "Movies MVC Web App",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "movieAPI",
                        "roles"
                    }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes => 
            new ApiScope[] 
            {
                new ApiScope("movieAPI", "Movie API")
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] 
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
                new IdentityResource("roles", "Your role(s)", new List<string>(){"role"})
            };
        public static List<TestUser> TestUsers => new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "C41A19F4-CF8B-4138-A112-3DCD4EFE354E",
                Username = "chandan",
                Password = "chandan",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "chandan"),
                    new Claim(JwtClaimTypes.FamilyName, "sah")
                }
            }
        };
    }
}
