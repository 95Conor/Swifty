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
    public class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminService<Admin> _adminService;

        public IsAdminHandler(IConfiguration configuration, IAdminService<Admin> adminService)
        {
            _configuration = configuration;
            _adminService = adminService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            string emailClaim = context.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            if (string.IsNullOrWhiteSpace(emailClaim))
            {
                return;
            }

            bool userIsAdmin = await _adminService.ValidateIsAdminByEmail(emailClaim);

            if (userIsAdmin)
            {
                context.Succeed(requirement);
            }
        }
    }
}