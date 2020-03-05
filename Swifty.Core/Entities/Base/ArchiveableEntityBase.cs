using Swifty.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities.Base
{
    public abstract class ArchiveableEntityBase : EntityBase, IArchiveableEntity
    {
        public abstract bool IsArchived { get; set; }
    }
}
