using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Mapping.Contracts.Base
{
    public interface IBaseMapper<TSource, TDestination>
        where TSource : class
        where TDestination : class
    {
        public TDestination Map(TSource source, TDestination destination);
    }
}
