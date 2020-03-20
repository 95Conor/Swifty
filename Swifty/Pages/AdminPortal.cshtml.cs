﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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