using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.Base
{
    public class BaseViewModel
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public List<string> NeutralMessages { get; set; } = new List<string>();

        public List<string> SuccessMessages { get; set; } = new List<string>();
    }
}
