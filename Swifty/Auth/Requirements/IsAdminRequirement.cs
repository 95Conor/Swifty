using Microsoft.AspNetCore.Authorization;

namespace Swifty.Web.Auth
{
    public class IsAdminRequirement : IAuthorizationRequirement
    {
        public IsAdminRequirement()
        {

        }
    }
}