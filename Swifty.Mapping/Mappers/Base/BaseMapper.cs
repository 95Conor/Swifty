using Swifty.Mapping.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Mapping.Mappers.Base
{
    public abstract class BaseMapper<TSource, TDestination> : IBaseMapper<TSource, TDestination>
        where TSource : class 
        where TDestination : class
    {

        // Template Method pattern
        public virtual TDestination Map(TSource source, TDestination destination)
        {
            MapEquivalentProperties(source, destination);
            ConfigureMappingFor(source, destination);
            return destination;
        }

        public abstract void ConfigureMappingFor(TSource source, TDestination destination);

        private void MapEquivalentProperties(TSource source, TDestination destination)
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
