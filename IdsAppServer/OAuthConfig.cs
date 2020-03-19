using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdsAppServer
{
    public class OAuthConfig
    {
        /// <summary>
        /// Define which APIs will use this IdentityServer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource("client1", "CAS Client Service"),
                new ApiResource("client2", "CAS Product Service"),
                new ApiResource("client3", "CAS Agent Service")
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
