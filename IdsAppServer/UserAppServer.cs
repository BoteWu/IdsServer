using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdsAppServer
{
    public class UserAppServer : IUserAppServer
    {
        public async Task<List<Claim>> ValidateUserAsync(string loginName, string password)
        {
            //TODO 这里可以通过用户名和密码到数据库中去验证是否存在，以及角色相关信息
            //var user = OAuthConfig.GetTestUsers();

            //if (user == null)
            //    throw new Exception("登录失败，用户名和密码不正确");

            return new List<Claim>()
        {
            new Claim(ClaimTypes.Name, $"{loginName}"),
             new Claim("role","role11"),
                new Claim("company","company22"),
                new Claim("company1","company221"),
                new Claim("company2","company222"),
                new Claim("company3","company223"),
                new Claim("company4","company224"),
                new Claim("company5","company225"),
                new Claim("company51","company225"),
                new Claim("company52","company225"),
                new Claim("company53","company225"),
                new Claim("company54","company225"),
                new Claim("company55","company225"),
                new Claim("company56","company225"),
                new Claim("company5700000","company22050000")
        };
        }
    }
}
