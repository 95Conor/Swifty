using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Mapping.Contracts.Base
{
    public interface IBaseMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            where TDestination : class
            where TSource : class;
    }
}
