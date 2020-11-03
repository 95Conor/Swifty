using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Core.Helpers;
using Swifty.Data.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Admin
{
    [Authorize("IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IBaseRepository<Entities.Admin> _adminRepository;

        public IndexModel(IBaseRepository<Entities.Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IList<Entities.Admin> Admins { get; set; }

        public async Task OnGetAsync()
        {
            Admins = await _adminRepository.ListAllAsync();

            foreach (var admin in Admins)
            {
                admin.Email = EncryptionHelper.Decrypt(admin.Email);
            }
        }
    }
}