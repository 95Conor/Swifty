using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Contracts.Entities
{
    public interface IArchiveableEntity : IEntityBase
    {
        bool IsArchived { get; set; }
    }
}
