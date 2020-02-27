using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class AdminRepository : SwiftyRepository<Admin>
    {
        public AdminRepository(SwiftyContext context) : base(context) { }
    }
}
