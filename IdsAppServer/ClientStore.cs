using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdsAppServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdsAppServer
{
    public class ClientStore : IClientStore
    {
        private IClientAppServer _clientAppServer;
        public ClientStore(IClientAppServer clientAppServer)
        {
            _clientAppServer = clientAppServer;
        }
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            #region 通过数据库查询Client 信息
            return _clientAppServer.GetClient(clientId);
            #endregion
        }
    }
}
