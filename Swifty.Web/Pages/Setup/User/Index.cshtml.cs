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
    public class IndexModel : PageModel
    {
        private readonly IBaseRepository<Entities.User> _userRepository;

        public IndexModel(IBaseRepository<Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<Entities.User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userRepository.ListAllAsync();
        }
    }
}
