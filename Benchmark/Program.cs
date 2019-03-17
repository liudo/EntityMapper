using AutoMapper;
using Benchmark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{
    class Program
    {
        static Dictionary<string, IMaperTest[]> mappers = new Dictionary<string, IMaperTest[]>
                {
                    { "AutoMapper_ObjectMapper", new IMaperTest[] { new AutoMapper_ObjectMapper()} },
                    { "SimpleMapper_ObjectMapper", new IMaperTest[] { new SimpleMapper_ObjectMapper()} },
                    { "ManualMapper_ObjectMapper", new IMaperTest[] { new ManualMapper_ObjectMapper()} },
                    { "AutoMapper_ObjectDeepMapper", new IMaperTest[] { new AutoMapper_ObjectDeepMapper()} },

                    { "SimpleMapper_ObjectDeepMapper_ShallowCopy", new IMaperTest[] { new SimpleMapper_ObjectDeepMapper_ShallowCopy()} },
                    { "SimpleMapper_ObjectDeepMapper_DeepCopy", new IMaperTest[] { new SimpleMapper_ObjectDeepMapper_DeepCopy()} },
                    { "ManualMapper_ObjectDeepMapper_ShallowCopy", new IMaperTest[] { new ManualMapper_ObjectDeepMapper_ShallowCopy()} },
                    { "ManualMapper_ObjectDeepMapper_DeepCopy", new IMaperTest[] { new ManualMapper_ObjectDeepMapper_DeepCopy()} },

                    { "AutoMapper_ListOfObjectsMapper", new IMaperTest[] { new AutoMapper_ListOfObjectsMapper()} },
                    { "SimpleMapper_ListOfObjectsMapper", new IMaperTest[] { new SimpleMapper_ListOfObjectsMapper()} },
                    { "SimpleMapper_ListOfObjectsMapper_Parallel", new IMaperTest[] { new SimpleMapper_ListOfObjectsMapper() { UseParallel = true } } },
                    { "ManualMapper_ListOfObjectsMapper", new IMaperTest[] { new ManualMapper_ListOfObjectsMapper()} },
                    { "ManualMapper_ListOfObjectsMapper_Parallel", new IMaperTest[] { new ManualMapper_ListOfObjectsMapper() { UseParallel = true } } },

                    { "AutoMapper_ListOfDeepObjectsMapper", new IMaperTest[] { new AutoMapper_ListOfDeepObjectsMapper()} },
                    { "SimpleMapper_ListOfDeepObjectsMapper_ShallowCopy", new IMaperTest[] { new SimpleMapper_ListOfDeepObjectsMapper_ShallowCopy()} },
                    { "SimpleMapper_ListOfDeepObjectsMapper_ShallowCopy_Parallel", new IMaperTest[] { new SimpleMapper_ListOfDeepObjectsMapper_ShallowCopy() { UseParallel = true } } },
                    { "SimpleMapper_ListOfDeepObjectsMapper_DeepCopy", new IMaperTest[] { new SimpleMapper_ListOfDeepObjectsMapper_DeepCopy()} },
                    { "SimpleMapper_ListOfDeepObjectsMapper_DeepCopy_Parallel", new IMaperTest[] { new SimpleMapper_ListOfDeepObjectsMapper_DeepCopy() { UseParallel = true } } },
                };

        static Dictionary<string, double> mapperTestTimes = new Dictionary<string, double>();
       
        static void Main(string[] args)
        {
            //TestAutomapper();
            //var code = GenerateMapSourceCode(typeof(DeepBCDEF), typeof(DeepCDE));
            foreach (var pair in mappers)
            {
                mapperTestTimes.Add(pair.Key, 0);
            }

            int numberOfTests = 10000;
            int numberOfListTests = 100;
            int sampleSize = 100;
            int listMapperListSize = 1000;
            int continueTesting = 1;
            int testLists = 1;
            do
            {
                Console.WriteLine("=============================================================");
                testLists = ReadIntInput($"Test list mapping? (default{testLists})=", testLists);

                numberOfTests = ReadIntInput($"# of tests (default{numberOfTests})=", numberOfTests);
                sampleSize = ReadIntInput($"sample size (default{sampleSize})=", sampleSize);
                if (testLists == 1)
                {
                    numberOfListTests = ReadIntInput($"# of tests (default{numberOfListTests})=", numberOfListTests);
                    listMapperListSize = ReadIntInput($"List mapping - list size (default{listMapperListSize})=", listMapperListSize);
                }
                foreach (var pair in mappers)
                {
                    foreach (var mapper in pair.Value)
                    {
                        if (pair.Key.ToLower().Contains("list") && testLists != 1) continue;

                        if (pair.Key.ToLower().Contains("list"))
                        {


                            mapperTestTimes[pair.Key] = new TestEngine(mapper).Start(numberOfListTests, sampleSize, listMapperListSize);
                        }
                        else
                        {
                            mapperTestTimes[pair.Key] = new TestEngine(mapper).Start(numberOfTests, sampleSize);
                        }
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("% Results:");

                if (testLists == 1)
                {
                    PrintResultAll();
                }
                Console.WriteLine("=============================================================");
                continueTesting = ReadIntInput($"Continue testing? (default{continueTesting})=", continueTesting);

            } while (continueTesting == 1);

            Console.ReadLine();
        }

        static void PrintResultAll()
        {
            List<string> mapperGroups = new List<string>();
            List<string> mapperNames = new List<string>();
            foreach (var mapper in mappers)
            {
                var mapperName = mapper.Key.Split('_')[0];
                var mapperGroup = mapper.Key.Split('_')[1];
                if (mapperGroups.Contains(mapperGroup) == false) mapperGroups.Add(mapperGroup);
                if (mapperNames.Contains(mapperName) == false) mapperNames.Add(mapperName);
            }

            foreach(var mapperTestTypeKvp in mapperTestTimes)
            {
                var mapperName = mapperTestTypeKvp.Key.Split('_')[0];
                var mapperGroup = mapperTestTypeKvp.Key.Split('_')[1];
                var mapperGroupFilter = mapperTestTypeKvp.Key.Split('_')[1].Replace("_Parallel", "");
                Console.WriteLine("");
                Console.WriteLine(mapperTestTypeKvp.Key + ":");
                foreach (var mapperTestTypeKvpCompareTo in mapperTestTimes.Where(m => m.Key.Contains(mapperGroupFilter)))
                {
                    if (mapperTestTypeKvp.Key == mapperTestTypeKvpCompareTo.Key) continue;
                    PrintTestResult(mapperGroupFilter, mapperTestTypeKvp.Key, mapperTestTypeKvpCompareTo.Key);
                }
            }
        }

        static void PrintTestResult(string mapperGroupName, string mapper1, string mapper2)
        {
            var time1 = mapperTestTimes[mapper1];
            var time2 = mapperTestTimes[mapper2];
            var diffInPercents = mapperTestTimes[mapper2] / mapperTestTimes[mapper1] * 100 - 100;
            Console.WriteLine($"{mapperGroupName} -> {mapper1} vs {mapper2}: {diffInPercents} % {(diffInPercents < 0 ? "slower" : "faster")}");
        }

        static int ReadIntInput(string message, int defaultVal)
        {
            Console.WriteLine(message);
            var val = Console.ReadLine();
            int parsed;
            if (Int32.TryParse(val, out parsed)) return parsed;

            return defaultVal;
        }

        static string GenerateMapSourceCode(Type src, Type dest, string destinationName = "destination", string sourceName = "this")
        {
            StringBuilder result = new StringBuilder();
            var destProps = dest.GetProperties();
            foreach (var srcProp in src.GetProperties().Where(p => p.GetMethod.IsPublic && p.SetMethod.IsPublic))
            {
                var destProp = destProps.Where(p => p.Name == srcProp.Name && p.GetMethod.IsPublic && p.SetMethod.IsPublic).FirstOrDefault();
                if (destProp != null)
                {
                    //this need to be configurable -> if true -> objDest.ObjProp = objSource.ObjProp; if false -> objDest.ObjProp = SimpleMapper.Mapper.Current.Map<objSource.ObjPropType, objDest.ObjPropType>(source);
                    if ((destProp.PropertyType.IsPrimitive == true || destProp.PropertyType.Name == "String"))
                    {
                        result.AppendLine($"{destinationName}.{destProp.Name} = {sourceName}.{srcProp.Name};");
                    }
                    else
                    {
                        result.AppendLine(GenerateMapSourceCode(srcProp.PropertyType, destProp.PropertyType,
                            $"{destinationName}.{destProp.Name}", $"{sourceName}.{srcProp.Name}"));
                    }
                }
            }
            return result.ToString();
        }
        static void TestAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<B, B>();
                cfg.CreateMap<C, C>();
                cfg.CreateMap<D, D>();
                cfg.CreateMap<E, E>();
                cfg.CreateMap<F, F>();
                cfg.CreateMap<BDto, B>();
                cfg.CreateMap<CDto, C>();
                cfg.CreateMap<DDto, D>();
                cfg.CreateMap<EDto, E>();
                cfg.CreateMap<FDto, F>();
                cfg.CreateMap<B, BDto>();
                cfg.CreateMap<C, CDto>();
                cfg.CreateMap<D, DDto>();
                cfg.CreateMap<E, EDto>();
                cfg.CreateMap<F, FDto>();
            });
            config.AssertConfigurationIsValid();
            var _mapper = config.CreateMapper();
            List<List<B>> listOfListsOfBs = new List<List<B>>();
            for (int i = 0; i < 10; i++)
            {
                listOfListsOfBs.Add(DataGenerator.GetRandomList<B>(100));
            }

            for (int i = 0; i < 10; i++)
            {
                var dest = _mapper.Map<List<B>, List<B>>(listOfListsOfBs[i]);
                var dest1 = _mapper.Map<List<B>, List<B>> (listOfListsOfBs[i]);
            }
        }
    }
}
