using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdsAppServer
{
    public class ClientAppServer : IClientAppServer
    {
        public Client GetClient(string clientId)
        {
            var memoryClients = GetClients();
            if (memoryClients.Any(oo => oo.ClientId == clientId))
            {
                return memoryClients.FirstOrDefault(oo => oo.ClientId == clientId);
            }
            return null;
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "ClientId001",
                    ClientSecrets = new [] { new Secret("clientsecret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "client1" }
                },
                new Client
                {
                    ClientId = "ClientId002",
                    ClientSecrets = new [] { new Secret("productsecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "client1", "client2" }
                },
                new Client
                {
                    ClientId = "ClientId003",
                    ClientSecrets = new [] { new Secret("agentsecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "client1", "client2", "client3" }
                },
                 new Client
        {
            ClientId = "mvc1",
            ClientName = "MVC Client",
            AllowedGrantTypes = GrantTypes.Implicit,
            // where to redirect to after login
            RedirectUris = { "http://localhost:8094/signin-oidc" },
            // where to redirect to after logout
            PostLogoutRedirectUris = { "http://localhost:8094/signout-callback-oidc" },
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
            }
        }
            };
        }
    }
}
