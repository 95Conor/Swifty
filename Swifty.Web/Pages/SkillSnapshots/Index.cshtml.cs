using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Swifty.Web.Pages.SkillSnapshots
{
    [Authorize("RequiresUserLogin")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ClaimsPrincipal cp = this.User;
        }
    }
}