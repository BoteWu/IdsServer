using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdsAppServer
{
    public interface IClientAppServer
    {
        Client GetClient(string clientId);
    }
}
