using SimpleMapper.Configuration;
using SimpleMapper.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapper
{
    public class Mapper : IMapper, IRuntimeMapper
    {
        //public Mapper(IConfigurationProvider configurationProvider);
        static MapperConfiguration Configuration = MapperConfiguration.Instance;
        
        //static HashSet<IMapInfo> _maps = new HashSet<IMapInfo>();
        static Dictionary<long, Dictionary<long, IMapInfo>> _mapsD = new Dictionary<long, Dictionary<long, IMapInfo>>();

        public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            IMapableInternal instance = Configuration.GetMap<TSource, TDestination>();
            instance.Source = source;
            return instance.ConvertTo() as TDestination;
        }

        public static TDestination MapDeep<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            IMapableInternal instance = Configuration.GetMap<TSource, TDestination>();
            instance.Source = source;
            return instance.ConvertToDeepCopy() as TDestination;
        }
        public static TDestination MapListDeep<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            IMapableInternal instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToListDeepCopy(source) as TDestination;
        }
        public static TDestination MapListDeepParallel<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            IMapableInternal instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToListMiltiTreadedDeepCopy(source) as TDestination;
        }

        public static TDestination MapList<TSource, TDestination>(TSource source) 
            where TDestination : class, new()
        {
            IMapableInternal instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToList(source) as TDestination;
        }

        public static TDestination MapListParallel<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            IMapableInternal instance = Configuration.GetMapList<TSource, TDestination>();
            return instance.ConvertToListMultiThreaded(source) as TDestination;
        }


        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TDestination : class
        {
            IMapableInternal instance = Configuration.GetMap<TSource, TDestination>();
            return instance.ConvertTo(source, destination) as TDestination;
        }
        
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

        //public static void Compile(string assemblyName = "SimpleMapper.Dynamic.Mappers.dll")
        //{
        //    MapperCompiler.Compile(Configuration._MappingsToCompile, assemblyName);
        //}
    }
}
