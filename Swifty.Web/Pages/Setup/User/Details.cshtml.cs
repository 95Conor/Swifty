using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.User
{
    public class DetailsModel : PageModel
    {
        private readonly IBaseRepository<Entities.User> _userRepository;

        public DetailsModel(IBaseRepository<Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Entities.User UserEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserEntity = await _userRepository.GetByIdAsync(id.Value);

            if (UserEntity == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
