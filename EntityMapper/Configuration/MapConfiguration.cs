using System;
using System.Collections.Generic;
using System.Text;

namespace EntityMapper.Configuration
{
    public class MapConfiguration<TSource, TDestination> : IConfiguration
        //where TSource : class
        //where TDestination : class
    {
        public bool DeepCopy { get; set; }
        public bool Reversal { get; set; }

        internal MapConfiguration()
        {
        }
        
        internal MapConfiguration(bool reversal = false, bool deepCopy = false)
        {
            DeepCopy = deepCopy;
            Reversal = reversal;
        }
        
        internal Tuple<IMapInfo, IMapInfo> CreateMap()
        {
            Type sourceType = typeof(TSource);
            Type destType = typeof(TDestination);
            MapInfo<TSource, TDestination> map = null;
            MapInfo<TDestination, TSource> mapReversal = null;
            if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
                (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
            {
                map = new MapInfo<TSource, TDestination>();
                MapperCompiler.GenerateDynamicClass(map);
            }
            if (this.Reversal)
            {
                mapReversal = new MapInfo<TDestination, TSource>();
                if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
                (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
                {
                    MapperCompiler.GenerateDynamicClass(mapReversal);
                }
            }

            return new Tuple<IMapInfo, IMapInfo>(map, mapReversal);
        }
    }
}
