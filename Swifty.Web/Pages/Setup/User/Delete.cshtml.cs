using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Entities = Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;
using Swifty.Core.Helpers;

namespace Swifty.Web.Pages.Setup.User
{
    public class DeleteModel : PageModel
    {
        private readonly IBaseRepository<Entities.User> _userRepository;

        public DeleteModel(IBaseRepository<Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public Entities.User UserEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserEntity = await _userRepository.GetByIdAsync(id.Value);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserEntity = await _userRepository.GetByIdAsync(id.Value);

            if (User != null)
            {
                await _userRepository.DeleteAsync(UserEntity);
            }

            return RedirectToPage("./Index");
        }
    }
}
