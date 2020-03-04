using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Swifty.Core.Entities;
using Swifty.Data.Repositories;

namespace Swifty.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SwiftyRepository<Admin> swiftyRepository;

        public IndexModel(ILogger<IndexModel> logger, SwiftyRepository<Admin> swiftyRepository)
        {
            _logger = logger;
            this.swiftyRepository = swiftyRepository;
        }

        public async Task OnGetAsync()
        {
            //Admin me = new Admin() { Email = "conor.maher@tigerbay.co.uk" };
            //Admin rich = new Admin() { Email = "richard.hodge@tigerbay.co.uk" };

            //await swiftyRepository.AddAsync(me);
            //await swiftyRepository.AddAsync(rich);
        }
    }
}
