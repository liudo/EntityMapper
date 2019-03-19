using AutoMapper;
using Benchmark.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class EntityMapper_ObjectMapper : MapperTestBase, IMaperTest
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
                cfg.Compile("EntityMapper_ObjectMapper.dll");
            });
            //EntityMapper.Mapper.ClearMap();
            //EntityMapper.Mapper.CreateMap<B, B>(reversal: false);
            //EntityMapper.Mapper.CreateMap<C, C>(reversal: false);
            //EntityMapper.Mapper.CreateMap<D, D>(reversal: false);
            //EntityMapper.Mapper.CreateMap<E, E>(reversal: false);
            //EntityMapper.Mapper.CreateMap<F, F>(reversal: false);
            //EntityMapper.Mapper.CreateMap<B, BDto>(reversal: true);
            //EntityMapper.Mapper.CreateMap<C, CDto>(reversal: true);
            //EntityMapper.Mapper.CreateMap<D, DDto>(reversal: true);
            //EntityMapper.Mapper.CreateMap<E, EDto>(reversal: true);
            //EntityMapper.Mapper.CreateMap<F, FDto>(reversal: true);
            //EntityMapper.Mapper.Compile("EntityMapper_ObjectToObjectMapper.dll");

            AssignRandomData(randomDataSampleSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 15);
            switch (switchVal)
            {
                case 1:
                    return Map<B, B>();
                case 2:
                    return Map<C, C>();
                case 3:
                    return Map<D, D>();
                case 4:
                    return Map<E, E>();
                case 5:
                    return Map<F, F>();
                case 6:
                    return Map<B, BDto>();
                case 7:
                    return Map<C, CDto>();
                case 8:
                    return Map<D, DDto>();
                case 9:
                    return Map<E, EDto>();
                case 10:
                    return Map<F, FDto>();
                case 11:
                    return Map<BDto, B>();
                case 12:
                    return Map<CDto, C>();
                case 13:
                    return Map<DDto, D>();
                case 14:
                    return Map<EDto, E>();
                case 15:
                    return Map<FDto, F>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        public double Map<TSource, TDestionation>()
            where TSource : _Base
            where TDestionation : class, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetT<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.Map<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    public class AutoMapper_ObjectMapper : MapperTestBase, IMaperTest
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
                cfg.CreateMap<B, BDto>();
                cfg.CreateMap<C, CDto>();
                cfg.CreateMap<D, DDto>();
                cfg.CreateMap<E, EDto>();
                cfg.CreateMap<F, FDto>();

                cfg.CreateMap<BDto, B>();
                cfg.CreateMap<CDto, C>();
                cfg.CreateMap<DDto, D>();
                cfg.CreateMap<EDto, E>();
                cfg.CreateMap<FDto, F>();
            });
            config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();

            AssignRandomData(randomDataSampleSize);
        }
        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 15);
            switch (switchVal)
            {
                case 1:
                    return Map<B, B>();
                case 2:
                    return Map<C, C>();
                case 3:
                    return Map<D, D>();
                case 4:
                    return Map<E, E>();
                case 5:
                    return Map<F, F>();
                case 6:
                    return Map<B, BDto>();
                case 7:
                    return Map<C, CDto>();
                case 8:
                    return Map<D, DDto>();
                case 9:
                    return Map<E, EDto>();
                case 10:
                    return Map<F, FDto>();
                case 11:
                    return Map<BDto, B>();
                case 12:
                    return Map<CDto, C>();
                case 13:
                    return Map<DDto, D>();
                case 14:
                    return Map<EDto, E>();
                case 15:
                    return Map<FDto, F>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        public double Map<TSource, TDestionation>()
            where TSource : _Base
            where TDestionation : class, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetT<TSource>(ii);
                stopwatch.Start();
                var dest = _mapper.Map<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }

        
    }

    public class ManualMapper_ObjectMapper : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }

        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;
            AssignRandomData(randomDataSampleSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 15);
            switch (switchVal)
            {
                case 1:
                    return Map<B, B>();
                case 2:
                    return Map<C, C>();
                case 3:
                    return Map<D, D>();
                case 4:
                    return Map<E, E>();
                case 5:
                    return Map<F, F>();
                case 6:
                    return Map<B, BDto>();
                case 7:
                    return Map<C, CDto>();
                case 8:
                    return Map<D, DDto>();
                case 9:
                    return Map<E, EDto>();
                case 10:
                    return Map<F, FDto>();
                case 11:
                    return Map<BDto, B>();
                case 12:
                    return Map<CDto, C>();
                case 13:
                    return Map<DDto, D>();
                case 14:
                    return Map<EDto, E>();
                case 15:
                    return Map<FDto, F>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        public double Map<TSource, TDestionation>()
            where TSource : _Base
            where TDestionation : _Base, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetT<TSource>(ii);
                stopwatch.Start();
                var dest = base.MapManual<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }
}
