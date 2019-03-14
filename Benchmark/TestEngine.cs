using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmark
{
    public class TestEngine
    {
        private readonly IMaperTest _mapperTest;
        public TestEngine(IMaperTest maperTest)
        {
            _mapperTest = maperTest;
        }
        public double Start(int numberOfTests, int randomDataSampleSize, int listMapperListSize = 1000)
        {
            _mapperTest.Init(randomDataSampleSize, listMapperListSize);
            List<double> mappingTimes = new List<double>();
            for(int i = 0; i < numberOfTests; i++)
            {
                Console.Write($"\r#test {i+1} / {numberOfTests} -> ");
                mappingTimes.Add(_mapperTest.Map());
            }
            if (_mapperTest.GetType().Name.ToLower().Contains("list"))
            {
                Console.WriteLine(value: $"{_mapperTest.GetType().Name}_{(_mapperTest.UseParallel ? "Parallel":"")} -> Avarage mapping time: {mappingTimes.Average()} ticks out of {numberOfTests} tests with sample size: {randomDataSampleSize} and list size {listMapperListSize}");
            }
            else
                Console.WriteLine(value: $"{_mapperTest.GetType().Name}_{(_mapperTest.UseParallel ? "Parallel" : "")} -> Avarage mapping time: {mappingTimes.Average()} ticks out of {numberOfTests} tests with sample size: {randomDataSampleSize}");

            return mappingTimes.Average();
        }
    }
}
