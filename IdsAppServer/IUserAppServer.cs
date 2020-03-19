using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdsAppServer
{
    public interface IUserAppServer
    {
       Task<List<Claim>> ValidateUserAsync(string loginName, string password);
    }
}
