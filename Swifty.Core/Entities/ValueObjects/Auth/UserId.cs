using Swifty.Core.Entities.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities.ValueObjects.Auth
{
    public class UserId : ValueObject
    {
        public int? Id { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }
    }
}
