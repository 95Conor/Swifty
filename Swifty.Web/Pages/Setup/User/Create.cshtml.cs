using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swifty.Core.Entities;
using Entities = Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Web.Pages.Setup.User
{
    public class CreateModel : PageModel
    {
        private readonly IBaseRepository<Entities.User> _userRepository;

        public CreateModel(IBaseRepository<Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entities.User UserEntity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userRepository.AddAsync(UserEntity);

            return RedirectToPage("./Index");
        }
    }
}
