using Benchmark.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class ManualMapper_ListOfDeepMapper_ShallowCopy : MapperTestBase, IMaperTest
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
            where TSource : _DeepBase//List<TSource>
            where TDestionation : _DeepBase, new()//List<TSource>, new()
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
             where TSource : _DeepBase//List<TSource>
             where TDestionation : _DeepBase, new()//List<TSource>, new()
            //where TSourceItem : _DeepBase//List<TSource>
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<List<TSource>>();
                stopwatch.Start();
                var dest = base.MapListOfDeepObjects_ShallowCopy<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

        public double MapInternalParallel<TSource, TDestionation>()
             where TSource : _DeepBase//List<TSource>
             where TDestionation : _DeepBase, new()//List<TSource>, new()
            //where TSourceItem : _DeepBase//List<TSource>
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<List<TSource>>();
                stopwatch.Start();
                var dest = base.MapListOfDeepObjects_ShallowCopy_Parallel<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }


    public class ManualMapper_ListOfDeepMapper_DeepCopy : MapperTestBase, IMaperTest
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
            where TSource : _DeepBase//List<TSource>
            where TDestionation : _DeepBase, new()//List<TSource>, new()
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
             where TSource : _DeepBase//List<TSource>
             where TDestionation : _DeepBase, new()//List<TSource>, new()
            //where TSourceItem : _DeepBase//List<TSource>
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<List<TSource>>();
                stopwatch.Start();
                var dest = base.MapListOfDeepObjects_DeepCopy<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }

        public double MapInternalParallel<TSource, TDestionation>()
             where TSource : _DeepBase//List<TSource>
             where TDestionation : _DeepBase, new()//List<TSource>, new()
            //where TSourceItem : _DeepBase//List<TSource>
        {
            List<long> autoMapperElapsedTicks = new List<long>();
            for (int ii = 0; ii < RandomDataSampleSize; ii++)
            {

                Stopwatch stopwatch = new Stopwatch();
                var source = this.GetListOfT<List<TSource>>();
                stopwatch.Start();
                var dest = base.MapListOfDeepObjects_DeepCopy_Parallel<TSource, TDestionation>(source);
                stopwatch.Stop();
                autoMapperElapsedTicks.Add(stopwatch.Elapsed.Ticks);
            }
            return autoMapperElapsedTicks.Average();
        }
    }
}
