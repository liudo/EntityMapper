using AutoMapper;
using Benchmark.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class AutoMapper_ListOfObjectsMapper : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }
        AutoMapper.IMapper _mapper;
        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;

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
            _mapper = config.CreateMapper();
            AssignRandomDataLists(randomDataSampleSize, listMapperListSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 15);
            switch (switchVal)
            {
                case 1:
                    return Map<List<B>, List<B>>();
                case 2:
                    return Map<List<C>, List<C>>();
                case 3:
                    return Map<List<D>, List<D>>();
                case 4:
                    return Map<List<E>, List<E>>();
                case 5:
                    return Map<List<F>, List<F>>();
                case 6:
                    return Map<List<B>, List<BDto>>();
                case 7:
                    return Map<List<C>, List<CDto>>();
                case 8:
                    return Map<List<D>, List<DDto>>();
                case 9:
                    return Map<List<E>, List<EDto>>();
                case 10:
                    return Map<List<F>, List<FDto>>();
                case 11:
                    return Map<List<BDto>, List<B>>();
                case 12:
                    return Map<List<CDto>, List<C>>();
                case 13:
                    return Map<List<DDto>, List<D>>();
                case 14:
                    return Map<List<EDto>, List<E>>();
                case 15:
                    return Map<List<FDto>, List<F>>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        public double Map<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = _mapper.Map<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    public class AutoMapper_ListOfDeepObjectsMapper : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }
        AutoMapper.IMapper _mapper;
        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DeepBCDEF, DeepCDE>();
                cfg.CreateMap<DeepCDE, DeepBCDEF>();
            });
            config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
            AssignRandomDataLists(randomDataSampleSize, listMapperListSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<List<DeepBCDEF>, List<DeepCDE>>();
                case 2:
                    return Map<List<DeepCDE>, List<DeepBCDEF>>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        public double Map<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = _mapper.Map<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    

    public class EntityMapper_ListOfObjectsMapper : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }

        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;

            EntityMapper.Mapper.Configure(cfg =>
            {
                cfg.ClearMappings();
                cfg.CreateMap<B, B>(reversal: false);
                cfg.CreateMap<C, C>(reversal: false);
                cfg.CreateMap<D, D>(reversal: false);
                cfg.CreateMap<E, E>(reversal: false);
                cfg.CreateMap<F, F>(reversal: false);
                cfg.CreateMap<B, BDto>(reversal: true);
                cfg.CreateMap<C, CDto>(reversal: true);
                cfg.CreateMap<D, DDto>(reversal: true);
                cfg.CreateMap<E, EDto>(reversal: true);
                cfg.CreateMap<F, FDto>(reversal: true);
                cfg.Compile("EntityMapper_ListOfObjectsMapper.dll");
            });

            AssignRandomDataLists(randomDataSampleSize, listMapperListSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 15);
            switch (switchVal)
            {
                case 1:
                    return Map<List<B>, List<B>>();
                case 2:
                    return Map<List<C>, List<C>>();
                case 3:
                    return Map<List<D>, List<D>>();
                case 4:
                    return Map<List<E>, List<E>>();
                case 5:
                    return Map<List<F>, List<F>>();
                case 6:
                    return Map<List<B>, List<BDto>>();
                case 7:
                    return Map<List<C>, List<CDto>>();
                case 8:
                    return Map<List<D>, List<DDto>>();
                case 9:
                    return Map<List<E>, List<EDto>>();
                case 10:
                    return Map<List<F>, List<FDto>>();
                case 11:
                    return Map<List<BDto>, List<B>>();
                case 12:
                    return Map<List<CDto>, List<C>>();
                case 13:
                    return Map<List<DDto>, List<D>>();
                case 14:
                    return Map<List<EDto>, List<E>>();
                case 15:
                    return Map<List<FDto>, List<F>>();
            }

            return (double)DateTime.MinValue.Ticks;
        }
        private double Map<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {
            if(UseParallel)
            {
                return MapInternalParallel<TSource, TDestionation>();
            }
            else
            {
                return MapInternal<TSource, TDestionation>();
            }
        }

        private double MapInternal<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {
            
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapList<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

        private double MapInternalParallel<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {

            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapListParallel<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

    }


    public class EntityMapper_ListOfDeepObjectsMapper_DeepCopy : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }

        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;

            EntityMapper.Mapper.Configure(cfg =>
            {
                cfg.ClearMappings();
                cfg.CreateMap<B, B>(reversal: false);
                cfg.CreateMap<C, C>(reversal: false);
                cfg.CreateMap<D, D>(reversal: false);
                cfg.CreateMap<E, E>(reversal: false);
                cfg.CreateMap<F, F>(reversal: false);
                cfg.CreateMap<DeepBCDEF, DeepCDE>(reversal: true);
                cfg.Compile("EntityMapper_ListOfDeepObjectsMapper_DeepCopy.dll");
            });

            AssignRandomDataLists(randomDataSampleSize, listMapperListSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<List<DeepBCDEF>, List<DeepCDE>>();
                case 2:
                    return Map<List<DeepCDE>, List<DeepBCDEF>>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        private double Map<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {
            if (UseParallel)
            {
                return MapInternalParallel<TSource, TDestionation>();
            }
            else
            {
                return MapInternal<TSource, TDestionation>();
            }
        }

        private double MapInternal<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {

            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapListDeep<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

        private double MapInternalParallel<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {

            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapListDeepParallel<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    public class EntityMapper_ListOfDeepObjectsMapper_ShallowCopy : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }

        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;

            EntityMapper.Mapper.Configure(cfg =>
            {
                cfg.ClearMappings();
                cfg.CreateMap<B, B>(reversal: false);
                cfg.CreateMap<C, C>(reversal: false);
                cfg.CreateMap<D, D>(reversal: false);
                cfg.CreateMap<E, E>(reversal: false);
                cfg.CreateMap<F, F>(reversal: false);
                cfg.CreateMap<DeepBCDEF, DeepCDE>(reversal: true);
                cfg.Compile("EntityMapper_ListOfDeepObjectsMapper_ShallowCopy.dll");
            });

            AssignRandomDataLists(randomDataSampleSize, listMapperListSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<List<DeepBCDEF>, List<DeepCDE>>();
                case 2:
                    return Map<List<DeepCDE>, List<DeepBCDEF>>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        private double Map<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {
            if (UseParallel)
            {
                return MapInternalParallel<TSource, TDestionation>();
            }
            else
            {
                return MapInternal<TSource, TDestionation>();
            }
        }

        private double MapInternal<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {

            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapList<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

        private double MapInternalParallel<TSource, TDestionation>()
            where TSource : class//List<TSource>
            where TDestionation : class, new()//List<TSource>, new()
        {

            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapListParallel<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }
}
