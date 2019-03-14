using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark
{
    public interface IMaperTest
    {
        int RandomDataSampleSize { get; set; }
        bool UseParallel { get; set; }
        void Init(int randomDataSampleSize, int listMapperListSize = 1000);
        double Map();
        //double Map<TSource, TDestionation>() 
        //    where TSource : _Base
        //    where TDestionation : class, new();
    }
}
