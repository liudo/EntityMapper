using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using SimpleMapper;
using Benchmark.Common;


namespace SimpleMapper.Dynamic.Mappers
{
    public class B_B : Benchmark.Common.B, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.B source = this.Source as Benchmark.Common.B;
            B destination = new B();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.B source = this.Source as Benchmark.Common.B;
            B destination = new B();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.B source = sourceObject as Benchmark.Common.B;
            B destination = destinationObject as B;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.B source = this.Source as Benchmark.Common.B;
            B destination = this.Destination as B;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new B()) as B);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new B()) as B);
            });

            return destination.ToList<B>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.B, B>(source) as B);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.B, B>(source) as B);
            });

            return destination.ToList<B>();
        }
    }
    public class C_C : Benchmark.Common.C, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.C source = this.Source as Benchmark.Common.C;
            C destination = new C();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.C source = this.Source as Benchmark.Common.C;
            C destination = new C();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.C source = sourceObject as Benchmark.Common.C;
            C destination = destinationObject as C;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.C source = this.Source as Benchmark.Common.C;
            C destination = this.Destination as C;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new C()) as C);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new C()) as C);
            });

            return destination.ToList<C>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.C, C>(source) as C);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.C, C>(source) as C);
            });

            return destination.ToList<C>();
        }
    }
    public class D_D : Benchmark.Common.D, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.D source = this.Source as Benchmark.Common.D;
            D destination = new D();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.D source = this.Source as Benchmark.Common.D;
            D destination = new D();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.D source = sourceObject as Benchmark.Common.D;
            D destination = destinationObject as D;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.D source = this.Source as Benchmark.Common.D;
            D destination = this.Destination as D;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new D()) as D);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new D()) as D);
            });

            return destination.ToList<D>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.D, D>(source) as D);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.D, D>(source) as D);
            });

            return destination.ToList<D>();
        }
    }
    public class E_E : Benchmark.Common.E, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.E source = this.Source as Benchmark.Common.E;
            E destination = new E();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.E source = this.Source as Benchmark.Common.E;
            E destination = new E();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.E source = sourceObject as Benchmark.Common.E;
            E destination = destinationObject as E;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.E source = this.Source as Benchmark.Common.E;
            E destination = this.Destination as E;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new E()) as E);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new E()) as E);
            });

            return destination.ToList<E>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.E, E>(source) as E);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.E, E>(source) as E);
            });

            return destination.ToList<E>();
        }
    }
    public class F_F : Benchmark.Common.F, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.F source = this.Source as Benchmark.Common.F;
            F destination = new F();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.F source = this.Source as Benchmark.Common.F;
            F destination = new F();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.F source = sourceObject as Benchmark.Common.F;
            F destination = destinationObject as F;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.F source = this.Source as Benchmark.Common.F;
            F destination = this.Destination as F;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new F()) as F);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new F()) as F);
            });

            return destination.ToList<F>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.F, F>(source) as F);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.F, F>(source) as F);
            });

            return destination.ToList<F>();
        }
    }
    public class B_BDto : Benchmark.Common.B, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.B source = this.Source as Benchmark.Common.B;
            BDto destination = new BDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.B source = this.Source as Benchmark.Common.B;
            BDto destination = new BDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.B source = sourceObject as Benchmark.Common.B;
            BDto destination = destinationObject as BDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.B source = this.Source as Benchmark.Common.B;
            BDto destination = this.Destination as BDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<BDto> destination = new List<BDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new BDto()) as BDto);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<BDto> destination = new ConcurrentBag<BDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new BDto()) as BDto);
            });

            return destination.ToList<BDto>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<BDto> destination = new List<BDto>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.B, BDto>(source) as BDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<BDto> destination = new ConcurrentBag<BDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.B, BDto>(source) as BDto);
            });

            return destination.ToList<BDto>();
        }
    }
    public class BDto_B : Benchmark.Common.BDto, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.BDto source = this.Source as Benchmark.Common.BDto;
            B destination = new B();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.BDto source = this.Source as Benchmark.Common.BDto;
            B destination = new B();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.BDto source = sourceObject as Benchmark.Common.BDto;
            B destination = destinationObject as B;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.BDto source = this.Source as Benchmark.Common.BDto;
            B destination = this.Destination as B;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new B()) as B);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new B()) as B);
            });

            return destination.ToList<B>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.BDto, B>(source) as B);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.BDto, B>(source) as B);
            });

            return destination.ToList<B>();
        }
    }
    public class C_CDto : Benchmark.Common.C, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.C source = this.Source as Benchmark.Common.C;
            CDto destination = new CDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.C source = this.Source as Benchmark.Common.C;
            CDto destination = new CDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.C source = sourceObject as Benchmark.Common.C;
            CDto destination = destinationObject as CDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.C source = this.Source as Benchmark.Common.C;
            CDto destination = this.Destination as CDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<CDto> destination = new List<CDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new CDto()) as CDto);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<CDto> destination = new ConcurrentBag<CDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new CDto()) as CDto);
            });

            return destination.ToList<CDto>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<CDto> destination = new List<CDto>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.C, CDto>(source) as CDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<CDto> destination = new ConcurrentBag<CDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.C, CDto>(source) as CDto);
            });

            return destination.ToList<CDto>();
        }
    }
    public class CDto_C : Benchmark.Common.CDto, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.CDto source = this.Source as Benchmark.Common.CDto;
            C destination = new C();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.CDto source = this.Source as Benchmark.Common.CDto;
            C destination = new C();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.CDto source = sourceObject as Benchmark.Common.CDto;
            C destination = destinationObject as C;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.CDto source = this.Source as Benchmark.Common.CDto;
            C destination = this.Destination as C;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new C()) as C);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new C()) as C);
            });

            return destination.ToList<C>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.CDto, C>(source) as C);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.CDto, C>(source) as C);
            });

            return destination.ToList<C>();
        }
    }
    public class D_DDto : Benchmark.Common.D, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.D source = this.Source as Benchmark.Common.D;
            DDto destination = new DDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.D source = this.Source as Benchmark.Common.D;
            DDto destination = new DDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.D source = sourceObject as Benchmark.Common.D;
            DDto destination = destinationObject as DDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.D source = this.Source as Benchmark.Common.D;
            DDto destination = this.Destination as DDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<DDto> destination = new List<DDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new DDto()) as DDto);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<DDto> destination = new ConcurrentBag<DDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new DDto()) as DDto);
            });

            return destination.ToList<DDto>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<DDto> destination = new List<DDto>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.D, DDto>(source) as DDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<DDto> destination = new ConcurrentBag<DDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.D, DDto>(source) as DDto);
            });

            return destination.ToList<DDto>();
        }
    }
    public class DDto_D : Benchmark.Common.DDto, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.DDto source = this.Source as Benchmark.Common.DDto;
            D destination = new D();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.DDto source = this.Source as Benchmark.Common.DDto;
            D destination = new D();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.DDto source = sourceObject as Benchmark.Common.DDto;
            D destination = destinationObject as D;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.DDto source = this.Source as Benchmark.Common.DDto;
            D destination = this.Destination as D;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new D()) as D);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new D()) as D);
            });

            return destination.ToList<D>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.DDto, D>(source) as D);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.DDto, D>(source) as D);
            });

            return destination.ToList<D>();
        }
    }
    public class E_EDto : Benchmark.Common.E, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.E source = this.Source as Benchmark.Common.E;
            EDto destination = new EDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.E source = this.Source as Benchmark.Common.E;
            EDto destination = new EDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.E source = sourceObject as Benchmark.Common.E;
            EDto destination = destinationObject as EDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.E source = this.Source as Benchmark.Common.E;
            EDto destination = this.Destination as EDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<EDto> destination = new List<EDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new EDto()) as EDto);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<EDto> destination = new ConcurrentBag<EDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new EDto()) as EDto);
            });

            return destination.ToList<EDto>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<EDto> destination = new List<EDto>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.E, EDto>(source) as EDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<EDto> destination = new ConcurrentBag<EDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.E, EDto>(source) as EDto);
            });

            return destination.ToList<EDto>();
        }
    }
    public class EDto_E : Benchmark.Common.EDto, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.EDto source = this.Source as Benchmark.Common.EDto;
            E destination = new E();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.EDto source = this.Source as Benchmark.Common.EDto;
            E destination = new E();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.EDto source = sourceObject as Benchmark.Common.EDto;
            E destination = destinationObject as E;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.EDto source = this.Source as Benchmark.Common.EDto;
            E destination = this.Destination as E;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new E()) as E);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new E()) as E);
            });

            return destination.ToList<E>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.EDto, E>(source) as E);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.EDto, E>(source) as E);
            });

            return destination.ToList<E>();
        }
    }
    public class F_FDto : Benchmark.Common.F, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.F source = this.Source as Benchmark.Common.F;
            FDto destination = new FDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.F source = this.Source as Benchmark.Common.F;
            FDto destination = new FDto();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.F source = sourceObject as Benchmark.Common.F;
            FDto destination = destinationObject as FDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.F source = this.Source as Benchmark.Common.F;
            FDto destination = this.Destination as FDto;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<FDto> destination = new List<FDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new FDto()) as FDto);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<FDto> destination = new ConcurrentBag<FDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new FDto()) as FDto);
            });

            return destination.ToList<FDto>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<FDto> destination = new List<FDto>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.F, FDto>(source) as FDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<FDto> destination = new ConcurrentBag<FDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.F, FDto>(source) as FDto);
            });

            return destination.ToList<FDto>();
        }
    }
    public class FDto_F : Benchmark.Common.FDto, IMapableInternal
    {
        public object Source { get; set; }
        public object Destination { get; set; }
        public object ConvertTo()
        {
            Benchmark.Common.FDto source = this.Source as Benchmark.Common.FDto;
            F destination = new F();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToDeepCopy()
        {
            Benchmark.Common.FDto source = this.Source as Benchmark.Common.FDto;
            F destination = new F();
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertTo(object sourceObject, object destinationObject)
        {
            Benchmark.Common.FDto source = sourceObject as Benchmark.Common.FDto;
            F destination = destinationObject as F;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        internal F ConvertTo(FDto sourceObject, F destinationObject)
        {
            Benchmark.Common.FDto source = sourceObject as Benchmark.Common.FDto;
            F destination = destinationObject as F;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertFromSourceToDest()
        {
            Benchmark.Common.FDto source = this.Source as Benchmark.Common.FDto;
            F destination = this.Destination as F;
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }

        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(ConvertTo(source, new F()) as F);
            }

            return destination;
        }

        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertTo(source, new F()));
            });

            return destination.ToList<F>();
        }

        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.FDto, F>(source) as F);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(SimpleMapper.Mapper.MapDeep<Benchmark.Common.FDto, F>(source) as F);
            });

            return destination.ToList<F>();
        }
    }

}

