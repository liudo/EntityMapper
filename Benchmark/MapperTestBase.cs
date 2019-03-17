using Benchmark.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public class MapperTestBase
    {
        public static int Size = 0;
        public static int ListSize = 0;

        public static List<B> listOfBs = new List<B>();
        public static List<C> listOfCs = new List<C>();
        public static List<D> listOfDs = new List<D>();
        public static List<E> listOfEs = new List<E>();
        public static List<F> listOfFs = new List<F>();
        public static List<BDto> listOfBDTOs = new List<BDto>();
        public static List<CDto> listOfCDTOs = new List<CDto>();
        public static List<DDto> listOfDDTOs = new List<DDto>();
        public static List<EDto> listOfEDTOs = new List<EDto>();
        public static List<FDto> listOfFDTOs = new List<FDto>();
        public static List<DeepBCDEF> listOfDeepBCDEFs = new List<DeepBCDEF>();
        public static List<DeepCDE> listOfDeepCDEs = new List<DeepCDE>();


        public static List<List<B>> listOfListsOfBs = new List<List<B>>();
        public static List<List<C>> listOfListsOfCs = new List<List<C>>();
        public static List<List<D>> listOfListsOfDs = new List<List<D>>();
        public static List<List<E>> listOfListsOfEs = new List<List<E>>();
        public static List<List<F>> listOfListsOfFs = new List<List<F>>();
        public static List<List<BDto>> listOfListsOfBDTOs = new List<List<BDto>>();
        public static List<List<CDto>> listOfListsOfCDTOs = new List<List<CDto>>();
        public static List<List<DDto>> listOfListsOfDDTOs = new List<List<DDto>>();
        public static List<List<EDto>> listOfListsOfEDTOs = new List<List<EDto>>();
        public static List<List<FDto>> listOfListsOfFDTOs = new List<List<FDto>>();
        public static List<List<DeepBCDEF>> listOfListsOfDeepBCDEFs = new List<List<DeepBCDEF>>();
        public static List<List<DeepCDE>> listOfListsOfDeepCDEs = new List<List<DeepCDE>>();

        public virtual void AssignRandomData(int size)
        {
            if (Size != size)
            {
                Size = size;
                listOfBs = DataGenerator.GetRandomList<B>(size);
                listOfCs = DataGenerator.GetRandomList<C>(size);
                listOfDs = DataGenerator.GetRandomList<D>(size);
                listOfEs = DataGenerator.GetRandomList<E>(size);
                listOfFs = DataGenerator.GetRandomList<F>(size);
                listOfBDTOs = DataGenerator.GetRandomList<BDto>(size);
                listOfCDTOs = DataGenerator.GetRandomList<CDto>(size);
                listOfDDTOs = DataGenerator.GetRandomList<DDto>(size);
                listOfEDTOs = DataGenerator.GetRandomList<EDto>(size);
                listOfFDTOs = DataGenerator.GetRandomList<FDto>(size);
                listOfDeepBCDEFs = DataGenerator.GetRandomDeepList<DeepBCDEF>(size);
                listOfDeepCDEs = DataGenerator.GetRandomDeepList<DeepCDE>(size);
            }
        }

        public virtual void AssignRandomDataLists(int size, int listSize)
        {
            if (ListSize != listSize)
            {
                Size = size;
                ListSize = listSize;

                for (int i = 0; i < size; i++)
                {
                    listOfListsOfBs.Add(DataGenerator.GetRandomList<B>(listSize));
                    listOfListsOfCs.Add(DataGenerator.GetRandomList<C>(listSize));
                    listOfListsOfDs.Add(DataGenerator.GetRandomList<D>(listSize));
                    listOfListsOfEs.Add(DataGenerator.GetRandomList<E>(listSize));
                    listOfListsOfFs.Add(DataGenerator.GetRandomList<F>(listSize));
                    listOfListsOfBDTOs.Add(DataGenerator.GetRandomList<BDto>(listSize));
                    listOfListsOfCDTOs.Add(DataGenerator.GetRandomList<CDto>(listSize));
                    listOfListsOfDDTOs.Add(DataGenerator.GetRandomList<DDto>(listSize));
                    listOfListsOfEDTOs.Add(DataGenerator.GetRandomList<EDto>(listSize));
                    listOfListsOfFDTOs.Add(DataGenerator.GetRandomList<FDto>(listSize));
                    listOfListsOfDeepBCDEFs.Add(DataGenerator.GetRandomDeepList<DeepBCDEF>(listSize));
                    listOfListsOfDeepCDEs.Add(DataGenerator.GetRandomDeepList<DeepCDE>(listSize));
                }
            }
        }

        public T GetTDeep<T>(int index) where T : _DeepBase
        {
            if (typeof(T) == typeof(DeepBCDEF))
            {
                return listOfDeepBCDEFs[index] as T;
            }
            else if (typeof(T) == typeof(DeepCDE))
            {
                return listOfDeepCDEs[index] as T;
            }
            return null;
        }
        public T GetListOfT<T>(int index) where T : class//List<T>
        {
            if (typeof(T) == typeof(List<B>))
            {
                return listOfListsOfBs[index] as T;
            }
            else if (typeof(T) == typeof(List<C>))
            {
                return listOfListsOfCs[index] as T;
            }
            else if (typeof(T) == typeof(List<D>))
            {
                return listOfListsOfDs[index] as T;
            }
            else if (typeof(T) == typeof(List<E>))
            {
                return listOfListsOfEs[index] as T;
            }
            else if (typeof(T) == typeof(List<F>))
            {
                return listOfListsOfFs[index] as T;
            }

            else if (typeof(T) == typeof(List<BDto>))
            {
                return listOfListsOfBDTOs[index] as T;
            }
            else if (typeof(T) == typeof(List<CDto>))
            {
                return listOfListsOfCDTOs[index] as T;
            }
            else if (typeof(T) == typeof(List<DDto>))
            {
                return listOfListsOfDDTOs[index] as T;
            }
            else if (typeof(T) == typeof(List<EDto>))
            {
                return listOfListsOfEDTOs[index] as T;
            }
            else if (typeof(T) == typeof(List<FDto>))
            {
                return listOfListsOfFDTOs[index] as T;
            }
            else if (typeof(T) == typeof(List<DeepBCDEF>))
            {
                return listOfListsOfDeepBCDEFs[index] as T;
            }
            else if (typeof(T) == typeof(List<DeepCDE>))
            {
                return listOfListsOfDeepCDEs[index] as T;
            }
            return null;
        }

        public T GetListOfT<T>() where T : class//List<T>
        {
            if (typeof(T) == typeof(List<B>))
            {
                return listOfListsOfBs as T;
            }
            else if (typeof(T) == typeof(List<C>))
            {
                return listOfListsOfCs as T;
            }
            else if (typeof(T) == typeof(List<D>))
            {
                return listOfListsOfDs as T;
            }
            else if (typeof(T) == typeof(List<E>))
            {
                return listOfListsOfEs as T;
            }
            else if (typeof(T) == typeof(List<F>))
            {
                return listOfListsOfFs as T;
            }

            else if (typeof(T) == typeof(List<BDto>))
            {
                return listOfListsOfBDTOs as T;
            }
            else if (typeof(T) == typeof(List<CDto>))
            {
                return listOfListsOfCDTOs as T;
            }
            else if (typeof(T) == typeof(List<DDto>))
            {
                return listOfListsOfDDTOs as T;
            }
            else if (typeof(T) == typeof(List<EDto>))
            {
                return listOfListsOfEDTOs as T;
            }
            else if (typeof(T) == typeof(List<FDto>))
            {
                return listOfListsOfFDTOs as T;
            }
            else if (typeof(T) == typeof(List<DeepBCDEF>))
            {
                return listOfListsOfDeepBCDEFs as T;
            }
            else if (typeof(T) == typeof(List<DeepCDE>))
            {
                return listOfListsOfDeepCDEs as T;
            }
            return null;
        }

        public T GetT<T>(int index) where T : _Base
        {
            if(typeof(T) == typeof(B))
            {
                return listOfBs[index] as T;
            }
            else if (typeof(T) == typeof(C))
            {
                return listOfCs[index] as T;
            }
            else if (typeof(T) == typeof(D))
            {
                return listOfDs[index] as T;
            }
            else if (typeof(T) == typeof(E))
            {
                return listOfEs[index] as T;
            }
            else if (typeof(T) == typeof(F))
            {
                return listOfFs[index] as T;
            }

            else if (typeof(T) == typeof(BDto))
            {
                return listOfBDTOs[index] as T;
            }
            else if (typeof(T) == typeof(CDto))
            {
                return listOfCDTOs[index] as T;
            }
            else if (typeof(T) == typeof(DDto))
            {
                return listOfDDTOs[index] as T;
            }
            else if (typeof(T) == typeof(EDto))
            {
                return listOfEDTOs[index] as T;
            }
            else if (typeof(T) == typeof(FDto))
            {
                return listOfFDTOs[index] as T;
            }

            return null;
        }

        public TDest MapManual<TSource, TDest>(TSource source)
            where TSource : _Base
            where TDest : _Base, new()
        {
            TDest result = new TDest();
            result.Name = source.Name;
            result.Address = source.Address;
            result.Age = source.Age;
            result.Id = source.Id;
            result.Height = source.Height;
            result.Wight = source.Wight;
            result.Color = source.Color;
            return result;
        }

        public TDest MapDeepManualShallowCopy<TSource, TDest>(TSource source)
            where TSource : _DeepBase
            where TDest : _DeepBase, new()
        {
            TDest result = new TDest();
            result.GetB = source.GetB;
            result.GetC = source.GetC;
            result.GetD = source.GetD;
            result.GetE = source.GetE;
            result.GetF = source.GetF;
            return result;
        }

        public TDest MapDeepManualDeepCopy<TSource, TDest>(TSource source)
            where TSource : _DeepBase
            where TDest : _DeepBase, new()
        {
            TDest result = new TDest();
            result.GetB = MapManual<B, B>(source.GetB);
            result.GetC = MapManual<C, C>(source.GetC);
            result.GetD = MapManual<D, D>(source.GetD);
            result.GetE = MapManual<E, E>(source.GetE);
            result.GetF = MapManual<F, F>(source.GetF);
            return result;
        }


        public List<TDest> MapListOfDeepObjects_DeepCopy<TSource, TDest>(List<TSource> source)
            where TSource : _DeepBase
            where TDest : _DeepBase, new()
        {
            List<TDest> result = new List<TDest>();
            foreach(var item in source)
            {
                result.Add(MapDeepManualDeepCopy<TSource, TDest>(item));
            }
            return result;
        }

        public List<TDest> MapListOfDeepObjects_DeepCopy_Parallel<TSource, TDest>(List<TSource> source)
            where TSource : _DeepBase
            where TDest : _DeepBase, new()
        {
            List<TDest> result = new List<TDest>();
            System.Threading.Tasks.Parallel.ForEach(source, item =>
            {
                result.Add(MapDeepManualDeepCopy<TSource, TDest>(item));
            });
            return result;
        }

        public List<TDest> MapListOfDeepObjects_ShallowCopy<TSource, TDest>(List<TSource> source)
            where TSource : _DeepBase
            where TDest : _DeepBase, new()
        {
            List<TDest> result = new List<TDest>();
            foreach (var item in source)
            {
                result.Add(MapDeepManualShallowCopy<TSource, TDest>(item));
            }
            return result;
        }

        public List<TDest> MapListOfDeepObjects_ShallowCopy_Parallel<TSource, TDest>(List<TSource> source)
            where TSource : _DeepBase
            where TDest : _DeepBase, new()
        {
            ConcurrentBag<TDest> result = new ConcurrentBag<TDest>();
            System.Threading.Tasks.Parallel.ForEach(source, item =>
            {
                result.Add(MapDeepManualShallowCopy<TSource, TDest>(item));
            });
            return result.ToList();
        }


        public List<TDest> MapListOfObjects<TSource, TDest>(List<TSource> source)
            where TSource : _Base
            where TDest : _Base, new()
        {
            List<TDest> result = new List<TDest>();
            foreach (var item in source)
            {
                result.Add(MapManual<TSource, TDest>(item));
            }
            return result;
        }

        public List<TDest> MapListOfObjects_Parallel<TSource, TDest>(List<TSource> source)
            where TSource : _Base
            where TDest : _Base, new()
        {
            ConcurrentBag<TDest> result = new ConcurrentBag<TDest>();
            System.Threading.Tasks.Parallel.ForEach(source, item =>
            {
                result.Add(MapManual<TSource, TDest>(item));
            });
            return result.ToList();
        }
    }
}
