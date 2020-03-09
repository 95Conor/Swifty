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
        private readonly IConfiguration configuration;
        private readonly IAdminService<Admin> adminService;

        public IsAdminHandler(IConfiguration configuration, IAdminService<Admin> adminService)
        {
            this.configuration = configuration;
            this.adminService = adminService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            string emailClaim = context.User.Claims.FirstOrDefault(x => x.Type.Equals(configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            if (string.IsNullOrWhiteSpace(emailClaim))
            {
                return;
            }

            bool userIsAdmin = await adminService.ValidateIsAdminByEmail(emailClaim);

            if (userIsAdmin)
            {
                context.Succeed(requirement);
            }
        }
    }
}