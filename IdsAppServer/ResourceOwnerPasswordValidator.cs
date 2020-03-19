using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using IdsAppServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdsAppServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IUserAppServer _userAppServer;
        public ResourceOwnerPasswordValidator(IUserAppServer userAppServer)
        {
            _userAppServer = userAppServer;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var userName = context.UserName;
                var password = context.Password;

                //验证用户,这么可以到数据库里面验证用户名和密码是否正确
                var claimList = await _userAppServer.ValidateUserAsync(userName, password);

                // 验证账号
                context.Result = new GrantValidationResult
                (
                    subject: userName,
                    authenticationMethod: "custom",
                    claims: claimList.ToArray()
                 );
            }
            catch (Exception ex)
            {
                //验证异常结果
                context.Result = new GrantValidationResult()
                {
                    IsError = true,
                    Error = ex.Message
                };
            }
        }

        //#region Private Method
        ///// <summary>
        ///// 验证用户
        ///// </summary>
        ///// <param name="loginName"></param>
        ///// <param name="password"></param>
        ///// <returns></returns>
        //private async Task<List<Claim>> ValidateUserAsync(string loginName, string password)
        //{
        //    //TODO 这里可以通过用户名和密码到数据库中去验证是否存在，
        //    // 以及角色相关信息，我这里还是使用内存中已经存在的用户和密码
        //    //var user = OAuthConfig.GetTestUsers();

        //    //if (user == null)
        //    //    throw new Exception("登录失败，用户名和密码不正确");

        //    return new List<Claim>()
        //{
        //    new Claim(ClaimTypes.Name, $"{loginName}"),
        //     new Claim("role","role11"),
        //        new Claim("company","company22"),
        //        new Claim("company1","company221"),
        //        new Claim("company2","company222"),
        //        new Claim("company3","company223"),
        //        new Claim("company4","company224"),
        //        new Claim("company5","company225"),
        //        new Claim("company51","company225"),
        //        new Claim("company52","company225"),
        //        new Claim("company53","company225"),
        //        new Claim("company54","company225"),
        //        new Claim("company55","company225"),
        //        new Claim("company56","company225"),
        //        new Claim("company57","company225")
        //};
        //}
        //#endregion
    }
}
