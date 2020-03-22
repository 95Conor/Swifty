using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Mapping.Contracts.Base
{
    public interface IBaseMapper
    {
        public void MapFrom<TSource, TDestination>() 
            where TSource : class 
            where TDestination : class;

        public void MapTo<TSource, TDestination>()
            where TSource : class
            where TDestination : class;
    }
}
