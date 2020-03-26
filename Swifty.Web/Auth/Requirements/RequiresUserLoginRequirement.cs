using Microsoft.AspNetCore.Authorization;

namespace Swifty.Web.Auth
{
    public class RequiresUserLoginRequirement : IAuthorizationRequirement
    {
        public RequiresUserLoginRequirement()
        {

        }
    }
}