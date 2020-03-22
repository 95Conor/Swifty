using Swifty.Mapping.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Mapping.Mappers.Base
{
    public class BaseMapper : IBaseMapper
    {
        public virtual TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            MapEquivalentProperties(source, destination);
            return destination;
        }

        private void MapEquivalentProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destinationProperty in destinationProperties)
                {
                    if (sourceProperty.Name == destinationProperty.Name 
                        && sourceProperty.PropertyType == destinationProperty.PropertyType 
                        && destinationProperty.CanWrite)
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
}
