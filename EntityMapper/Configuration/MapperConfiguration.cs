﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityMapper.Configuration
{
    public class MapperConfiguration
    {
        static MapperConfiguration _instance;
        private MapperConfiguration()
        {
        }

        internal static MapperConfiguration Instance
        {
            get
            {
                if (_instance == null) _instance = new MapperConfiguration();
                return _instance;
            }
        }

        internal Dictionary<long, Dictionary<long, IMapInfo>> _Mappings = new Dictionary<long, Dictionary<long, IMapInfo>>();
        internal HashSet<IMapInfo> _MappingsToCompile = new HashSet<IMapInfo>();

        public void ClearMappings()
        {
            _Mappings.Clear();
            _MappingsToCompile.Clear();
        }
        public MapConfiguration<TSource, TDestination> CreateMap<TSource, TDestination>(bool reversal = false)
        {
            MapConfiguration<TSource, TDestination> mapConfiguration = new MapConfiguration<TSource, TDestination>(reversal);
            var maps = mapConfiguration.CreateMap();
            if (maps.Map != null)
            {
                AddMap<TSource, TDestination>(maps.Map);
                _MappingsToCompile.Add(maps.Map);
            }
            if (maps.MapReversal != null && reversal)
            {
                AddMap<TDestination, TSource>(maps.MapReversal);
                _MappingsToCompile.Add(maps.MapReversal);
            }
            return mapConfiguration;
            //Type sourceType = typeof(TSource);
            //Type destType = typeof(TDestination);


            //MapInfo<TSource, TDestination> map = new MapInfo<TSource, TDestination>();
            //AddMap<TSource, TDestination>(map);
            //if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
            //    (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
            //{
            //    _MappingsToCompile.Add(map);
            //    MapperCompiler.GenerateDynamicClass(map);
            //}
            //if (reversal)
            //{
            //    MapInfo<TDestination, TSource> mapReversal = new MapInfo<TDestination, TSource>();
            //    AddMap<TDestination, TSource>(mapReversal, reversal);

            //    if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
            //    (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
            //    {
            //        _MappingsToCompile.Add(mapReversal);
            //        MapperCompiler.GenerateDynamicClass(mapReversal);
            //    }
            //}
        }
        public void Compile(string assemblyName = "EntityMapper.Dynamic.Mappers.dll")
        {
            MapperCompiler.Compile(_MappingsToCompile, assemblyName);
        }


        internal IMappable GetMap<TSource, TDestination>()
        {
            return _Mappings[GetMapKey<TSource>()][GetMapKey<TDestination>()].Instance;
        }
        internal MapInfo<TSource, TDestination> GetMapInfo<TSource, TDestination>()
        {
            return _Mappings[GetMapKey<TSource>()][GetMapKey<TDestination>()] as MapInfo<TSource, TDestination>;
        }

        internal IMappable GetMapList<TSource, TDestination>()
        {
            return _Mappings[GetMapKeyList<TSource>()][GetMapKeyList<TDestination>()].Instance;
        }

        internal void AddMap<TSource, TDestination>(IMapInfo map, bool reversal = false)
        {
            long hashSource = GetMapKey<TSource>();
            long hashDest = GetMapKey<TDestination>();
            if (reversal && hashSource == hashDest)
                throw new Exception($"Circular map <{typeof(TSource)}, {typeof(TDestination)}>. Set revarsal: false when calling CreateMap<{typeof(TSource)}, {typeof(TDestination)}>(reversal:false)");
            if (_Mappings.ContainsKey(hashSource) == false)
            {
                var destDic = new Dictionary<long, IMapInfo>();
                destDic.Add(hashDest, map);
                _Mappings.Add(hashSource, destDic);
            }
            else
            {
                var kvpSource = _Mappings[hashSource];
                if (kvpSource.ContainsKey(hashDest) == false)
                {
                    kvpSource.Add(hashDest, map);
                }
                else
                {
                    throw new Exception($"Map already created <{typeof(TSource)}, {typeof(TDestination)}>");
                }
            }
        }
        internal long GetMapKey<T>()
        {
            return typeof(T).GetHashCode();
        }

        internal long GetMapKeyList<T>()
        {
            return typeof(T).GenericTypeArguments[0].GetHashCode();
        }
    }
}
