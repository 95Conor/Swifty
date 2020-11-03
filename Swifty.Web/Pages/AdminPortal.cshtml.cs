using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Swifty.Web.Pages
{
    [Authorize("IsAdmin")]
    public class AdminPortalModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}