using EntityMapper.Configuration;
using EntityMapper.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapper
{
    public class Mapper : IMapper
    {
        #region Static Fields
        static MapperConfiguration Configuration = MapperConfiguration.Instance;
        #endregion

        #region Singleton
        static Mapper _instance = null;
        private static readonly object _lock = new object();
        //public Mapper(IConfigurationProvider configurationProvider);
        private Mapper()
        {
        }

        public static Mapper Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new Mapper();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Object Map
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TDestination : class
        {
            IMappable instance = Configuration.GetMap<TSource, TDestination>();
            var mapInfo = Configuration.GetMapInfo<TSource, TDestination>();
            var result = instance.ConvertTo(source, destination) as TDestination;
            mapInfo.ExecuteCustomMappings(source, result);
            return result;
        }
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            //IMappable instance = Configuration.GetMap<TSource, TDestination>();
            var mapInfo = Configuration.GetMapInfo<TSource, TDestination>();
            mapInfo.Instance.Source = source;
            var result = mapInfo.Instance.ConvertTo() as TDestination;
            mapInfo.ExecuteCustomMappings(source, result);
            return result;
        }

        public TDestination MapDeep<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            IMappable instance = Configuration.GetMap<TSource, TDestination>();
            instance.Source = source;
            return instance.ConvertToDeepCopy() as TDestination;
        }
        #endregion

        #region Collection Map
        public TDestination MapListDeep<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            IMappable instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToListDeepCopy(source) as TDestination;
        }
        public TDestination MapListDeepParallel<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            IMappable instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToListMiltiTreadedDeepCopy(source) as TDestination;
        }

        public TDestination MapList<TSource, TDestination>(TSource source) 
            where TDestination : class, new()
        {
            IMappable instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToList(source) as TDestination;
        }

        public TDestination MapListParallel<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            IMappable instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToListMultiThreaded(source) as TDestination;
        }

        #endregion
        public static void Configure(Action<MapperConfiguration> action)
        {
            action.Invoke(Configuration);    
        }
        //need to make this recursive to include are the "inside types (like props, lists, etc.)"
        //public static void CreateMap<TSource, TDestination>(bool reversal = false)
        //{
        //    Type sourceType = typeof(TSource);
        //    Type destType = typeof(TDestination);

            
        //    MapInfo<TSource, TDestination> map = new MapInfo<TSource, TDestination>();
        //    Configuration.AddMap<TSource, TDestination>(map);
        //    if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
        //        (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
        //    {
        //        _maps.Add(map);
        //        MapperCompiler.GenerateDynamicClass(map);
        //    }
        //    if (reversal)
        //    {
        //        MapInfo<TDestination, TSource> mapReversal = new MapInfo<TDestination, TSource>();
        //        Configuration.AddMap<TDestination, TSource>(mapReversal, reversal);

        //        if ((sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(List<>)) == false &&
        //        (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(List<>)) == false)
        //        {
        //            _maps.Add(mapReversal);
        //            MapperCompiler.GenerateDynamicClass(mapReversal);
        //        }
        //    }
        //}

        //public static void Compile(string assemblyName = "EntityMapper.Dynamic.Mappers.dll")
        //{
        //    MapperCompiler.Compile(Configuration._MappingsToCompile, assemblyName);
        //}
    }
}
