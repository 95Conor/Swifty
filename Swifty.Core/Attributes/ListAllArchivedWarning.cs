using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Attributes
{
    [Obsolete("Repository warning: ListAllAsync() does not filter archived entities. Use ListAllNonArchivedAsync() if you wish to achieve this.")]
    public class ListAllArchivedWarning : System.Attribute
    {
        // This isn't pretty, obsolete is not really what we want, but a nice little way to get a compiler warning nonetheless.
    }
}
