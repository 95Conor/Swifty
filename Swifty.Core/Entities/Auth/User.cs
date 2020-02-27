using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }

        public string Email { get; set; }
    }
}
