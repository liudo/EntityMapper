using System;
using System.Collections.Generic;
using System.Text;
using Benchmark.Common;

namespace Benchmark.Common
{
    public class DataGenerator
    {
        public static string RandomString(int maxLength = 20)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int size = random.Next(maxLength);
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static int RandomNumber()
        {
            Random number = new Random((int)DateTime.Now.Ticks);
            return number.Next();
        }

        public static T GetRandom<T>() where T : _Base, new()
        {
            Random number = new Random((int)DateTime.Now.Ticks);

            T result = new T();
            ((_Base)result).Name = RandomString();
            ((_Base)result).Address = RandomString();
            ((_Base)result).Age = number.Next();
            ((_Base)result).Id = number.Next();
            ((_Base)result).Height = number.Next();
            ((_Base)result).Wight = number.Next();
            ((_Base)result).Color = RandomString();

            return result;
        }

        public static List<T> GetRandomList<T>(int size) where T : _Base, new()
        {
            List<T> result = new List<T>();
            for (int j = 0; j < size; j++)
            {
                result.Add(GetRandom<T>());
            }
            return result;
        }

        public static List<T> GetRandomDeepList<T>(int size) where T : _DeepBase, new()
        {
            List<T> result = new List<T>();
            for (int j = 0; j < size; j++)
            {
                T item = new T();

                if (item.GetB != null) item.GetB = GetRandom<B>();
                if (item.GetC != null) item.GetC = GetRandom<C>();
                if (item.GetD != null) item.GetD = GetRandom<D>();
                if (item.GetE != null) item.GetE = GetRandom<E>();
                if (item.GetF != null) item.GetF = GetRandom<F>();

                result.Add(item);
            }
            return result;
        }


    }
}
