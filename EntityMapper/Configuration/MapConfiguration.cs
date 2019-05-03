using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace EntityMapper.Configuration
{
    public class MapConfiguration<TSource, TDestination> : IConfiguration
        //where TSource : class
        //where TDestination : class
    {
        public bool DeepCopy { get; set; }
        public bool Reversal { get; set; }

        internal MapInfo<TSource, TDestination> Map { get; private set; }
        internal MapInfo<TDestination, TSource> MapReversal { get; private set; }

        internal MapConfiguration()
        {
        }
        
        internal MapConfiguration(bool reversal = false, bool deepCopy = false)
        {
            DeepCopy = deepCopy;
            Reversal = reversal;
        }
        
        internal MapConfiguration<TSource, TDestination> CreateMap()
        {
            Type sourceType = typeof(TSource);
            Type destType = typeof(TDestination);
            //MapInfo<TSource, TDestination> map = null;
            //MapInfo<TDestination, TSource> mapReversal = null;
            if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
                (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
            {
                Map = new MapInfo<TSource, TDestination>();
                //MapperCompiler.GenerateDynamicClass(map);
            }
            if (this.Reversal)
            {
                Reverse();
            }

            return this;
            //return new Tuple<IMapInfo, IMapInfo>(Map, mapReversal);
        }

        public MapConfiguration<TSource, TDestination> Reverse()
        {
            Type sourceType = typeof(TSource);
            Type destType = typeof(TDestination);
            if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
                (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
            {
                MapReversal = new MapInfo<TDestination, TSource>();
                //MapperCompiler.GenerateDynamicClass(mapReversal);
            }
            return this;
        }
        public MapConfiguration<TSource, TDestination>  CustomMap(Action<TSource, TDestination> memberOption)
        {
            this.Map.AddCustomMapping(memberOption);
            return this;
        }

        public MapConfiguration<TSource, TDestination> Ingore(params string[] propertyName)
        {
            this.Map.Ignore(propertyName);
            return this;
        }

        public MapConfiguration<TSource, TDestination> CustomMappings(params Action<TSource, TDestination>[] memberOptions)
        {
            this.Map.AddCustomMappings(memberOptions);
            return this;
        }
    }
}
