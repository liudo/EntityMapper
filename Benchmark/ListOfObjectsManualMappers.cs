using Benchmark.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class ManualMapper_ListOfObjectsMapper : MapperTestBase, IMaperTest
    {
        public bool UseParallel { get; set; }
        public int RandomDataSampleSize { get; set; }

        public void Init(int randomDataSampleSize, int listMapperListSize = 1000)
        {
            RandomDataSampleSize = randomDataSampleSize;
            AssignRandomDataLists(randomDataSampleSize, listMapperListSize);
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

        private double Map<TSource, TDestionation>()
            where TSource : _Base//List<TSource>
            where TDestionation : _Base, new()//List<TSource>, new()
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
        public double MapInternal<TSource, TDestionation>()
             where TSource : _Base//List<TSource>
             where TDestionation : _Base, new()//List<TSource>, new()
            //where TSourceItem : _DeepBase//List<TSource>
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<List<TSource>>(ii);
                stopwatch.Start();
                var dest = base.MapListOfObjects<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

        public double MapInternalParallel<TSource, TDestionation>()
             where TSource : _Base//List<TSource>
             where TDestionation : _Base, new()//List<TSource>, new()
            //where TSourceItem : _DeepBase//List<TSource>
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<List<TSource>>(ii);
                stopwatch.Start();
                var dest = base.MapListOfObjects_Parallel<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }
}
