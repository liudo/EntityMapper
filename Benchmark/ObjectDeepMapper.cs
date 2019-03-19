using AutoMapper;
using Benchmark.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class EntityMapper_ObjectDeepMapper_ShallowCopy : MapperTestBase, IMaperTest
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
                cfg.Compile("EntityMapper_ObjectDeepMapper_ShallowCopy.dll");
            });
            //EntityMapper.Mapper.CreateMap<B, B>(reversal: false);
            //EntityMapper.Mapper.CreateMap<C, C>(reversal: false);
            //EntityMapper.Mapper.CreateMap<D, D>(reversal: false);
            //EntityMapper.Mapper.CreateMap<E, E>(reversal: false);
            //EntityMapper.Mapper.CreateMap<F, F>(reversal: false);
            //EntityMapper.Mapper.CreateMap<DeepBCDEF, DeepCDE>(reversal: true);
            //EntityMapper.Mapper.Compile("EntityMapper_ObjectToObjectDeepMapper.dll");

            AssignRandomData(randomDataSampleSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<DeepBCDEF, DeepCDE>();
                case 2:
                    return Map<DeepCDE, DeepBCDEF>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        private double Map<TSource, TDestionation>()
            where TSource : _DeepBase
            where TDestionation : class, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetTDeep<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.Map<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    public class EntityMapper_ObjectDeepMapper_DeepCopy : MapperTestBase, IMaperTest
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
                cfg.Compile("EntityMapper_ObjectDeepMapper_DeepCopy.dll");
            });
            //EntityMapper.Mapper.CreateMap<B, B>(reversal: false);
            //EntityMapper.Mapper.CreateMap<C, C>(reversal: false);
            //EntityMapper.Mapper.CreateMap<D, D>(reversal: false);
            //EntityMapper.Mapper.CreateMap<E, E>(reversal: false);
            //EntityMapper.Mapper.CreateMap<F, F>(reversal: false);
            //EntityMapper.Mapper.CreateMap<DeepBCDEF, DeepCDE>(reversal: true);
            //EntityMapper.Mapper.Compile("EntityMapper_ObjectToObjectDeepMapper.dll");

            AssignRandomData(randomDataSampleSize);
        }

        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<DeepBCDEF, DeepCDE>();
                case 2:
                    return Map<DeepCDE, DeepBCDEF>();
            }

            return (double)DateTime.MinValue.Ticks;
        }

        private double Map<TSource, TDestionation>()
            where TSource : _DeepBase
            where TDestionation : class, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetTDeep<TSource>(ii);
                stopwatch.Start();
                var dest = EntityMapper.Mapper.Current.MapDeep<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    public class AutoMapper_ObjectDeepMapper : MapperTestBase, IMaperTest
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

            AssignRandomData(randomDataSampleSize);
        }
        public double Map()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<DeepBCDEF, DeepCDE>();
                case 2:
                    return Map<DeepCDE, DeepBCDEF>();
            }

            return (double)DateTime.MinValue.Ticks;
        }
        private double Map<TSource, TDestionation>()
            where TSource : _DeepBase
            where TDestionation : class, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetTDeep<TSource>(ii);
                stopwatch.Start();
                var dest = _mapper.Map<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }

    }

    public class ManualMapper_ObjectDeepMapper_ShallowCopy : MapperTestBase, IMaperTest
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
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<DeepBCDEF, DeepCDE>();
                case 2:
                    return Map<DeepCDE, DeepBCDEF>();
            }

            return (double)DateTime.MinValue.Ticks;
        }
        private double Map<TSource, TDestionation>()
            where TSource : _DeepBase
            where TDestionation : _DeepBase, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetTDeep<TSource>(ii);
                stopwatch.Start();
                var dest = base.MapDeepManualShallowCopy<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }

    public class ManualMapper_ObjectDeepMapper_DeepCopy : MapperTestBase, IMaperTest
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
            var switchVal = random.Next(1, 2);
            switch (switchVal)
            {
                case 1:
                    return Map<DeepBCDEF, DeepCDE>();
                case 2:
                    return Map<DeepCDE, DeepBCDEF>();
            }

            return (double)DateTime.MinValue.Ticks;
        }
        private double Map<TSource, TDestionation>()
            where TSource : _DeepBase
            where TDestionation : _DeepBase, new()
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetTDeep<TSource>(ii);
                stopwatch.Start();
                var dest = base.MapDeepManualDeepCopy<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.ElapsedTicks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }
}
