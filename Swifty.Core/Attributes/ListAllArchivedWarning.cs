using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Attributes
{
    [Obsolete("Repository warning: ListAllAsync() does not filter archived entities. Use ListAllNonArchivedAsync() if you wish to achieve this.")]
    public class ListAllArchivedWarning : System.Attribute
    {
    }
}
