using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Services;
using Swifty.Data.Services;

namespace Swifty.Web.Auth
{
    public class RequiresUserLoginHandler : AuthorizationHandler<RequiresUserLoginRequirement>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService<User> _userService;

        public RequiresUserLoginHandler(IConfiguration configuration, IUserService<User> userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RequiresUserLoginRequirement requirement)
        {
            string emailClaim = context.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            if (string.IsNullOrWhiteSpace(emailClaim))
            {
                return;
            }

            await _userService.InitialiseLogin(emailClaim);

            context.Succeed(requirement);
        }
    }
}