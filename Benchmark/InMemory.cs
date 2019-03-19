using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using EntityMapper;
using Benchmark.Common;


namespace EntityMapper.Dynamic.Mappers
{
    public class B_B : Benchmark.Common.B, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.B, new B());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.B, destinationObject as B);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.B, this.Destination as B);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new B()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new B()));
            });

            return destination.ToList<B>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.B, B>(source) as B);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.B, B>(source) as B);
            });

            return destination.ToList<B>();
        }
        #endregion

        #region Internal Methods
        internal B ConvertToInternal(Benchmark.Common.B source, B destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class C_C : Benchmark.Common.C, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.C, new C());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.C, destinationObject as C);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.C, this.Destination as C);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new C()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new C()));
            });

            return destination.ToList<C>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.C, C>(source) as C);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.C, C>(source) as C);
            });

            return destination.ToList<C>();
        }
        #endregion

        #region Internal Methods
        internal C ConvertToInternal(Benchmark.Common.C source, C destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class D_D : Benchmark.Common.D, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.D, new D());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.D, destinationObject as D);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.D, this.Destination as D);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new D()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new D()));
            });

            return destination.ToList<D>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.D, D>(source) as D);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.D, D>(source) as D);
            });

            return destination.ToList<D>();
        }
        #endregion

        #region Internal Methods
        internal D ConvertToInternal(Benchmark.Common.D source, D destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class E_E : Benchmark.Common.E, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.E, new E());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.E, destinationObject as E);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.E, this.Destination as E);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new E()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new E()));
            });

            return destination.ToList<E>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.E, E>(source) as E);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.E, E>(source) as E);
            });

            return destination.ToList<E>();
        }
        #endregion

        #region Internal Methods
        internal E ConvertToInternal(Benchmark.Common.E source, E destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class F_F : Benchmark.Common.F, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.F, new F());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.F, destinationObject as F);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.F, this.Destination as F);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new F()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new F()));
            });

            return destination.ToList<F>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.F, F>(source) as F);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.F, F>(source) as F);
            });

            return destination.ToList<F>();
        }
        #endregion

        #region Internal Methods
        internal F ConvertToInternal(Benchmark.Common.F source, F destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class B_BDto : Benchmark.Common.B, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.B, new BDto());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.B, destinationObject as BDto);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.B, this.Destination as BDto);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<BDto> destination = new List<BDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new BDto()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<BDto> destination = new ConcurrentBag<BDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new BDto()));
            });

            return destination.ToList<BDto>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            List<BDto> destination = new List<BDto>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.B, BDto>(source) as BDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.B> sources = sourceList as List<Benchmark.Common.B>;
            ConcurrentBag<BDto> destination = new ConcurrentBag<BDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.B, BDto>(source) as BDto);
            });

            return destination.ToList<BDto>();
        }
        #endregion

        #region Internal Methods
        internal BDto ConvertToInternal(Benchmark.Common.B source, BDto destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class BDto_B : Benchmark.Common.BDto, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.BDto, new B());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.BDto, destinationObject as B);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.BDto, this.Destination as B);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new B()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new B()));
            });

            return destination.ToList<B>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            List<B> destination = new List<B>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.BDto, B>(source) as B);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.BDto> sources = sourceList as List<Benchmark.Common.BDto>;
            ConcurrentBag<B> destination = new ConcurrentBag<B>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.BDto, B>(source) as B);
            });

            return destination.ToList<B>();
        }
        #endregion

        #region Internal Methods
        internal B ConvertToInternal(Benchmark.Common.BDto source, B destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class C_CDto : Benchmark.Common.C, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.C, new CDto());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.C, destinationObject as CDto);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.C, this.Destination as CDto);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<CDto> destination = new List<CDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new CDto()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<CDto> destination = new ConcurrentBag<CDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new CDto()));
            });

            return destination.ToList<CDto>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            List<CDto> destination = new List<CDto>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.C, CDto>(source) as CDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.C> sources = sourceList as List<Benchmark.Common.C>;
            ConcurrentBag<CDto> destination = new ConcurrentBag<CDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.C, CDto>(source) as CDto);
            });

            return destination.ToList<CDto>();
        }
        #endregion

        #region Internal Methods
        internal CDto ConvertToInternal(Benchmark.Common.C source, CDto destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class CDto_C : Benchmark.Common.CDto, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.CDto, new C());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.CDto, destinationObject as C);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.CDto, this.Destination as C);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new C()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new C()));
            });

            return destination.ToList<C>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            List<C> destination = new List<C>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.CDto, C>(source) as C);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.CDto> sources = sourceList as List<Benchmark.Common.CDto>;
            ConcurrentBag<C> destination = new ConcurrentBag<C>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.CDto, C>(source) as C);
            });

            return destination.ToList<C>();
        }
        #endregion

        #region Internal Methods
        internal C ConvertToInternal(Benchmark.Common.CDto source, C destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class D_DDto : Benchmark.Common.D, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.D, new DDto());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.D, destinationObject as DDto);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.D, this.Destination as DDto);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<DDto> destination = new List<DDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new DDto()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<DDto> destination = new ConcurrentBag<DDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new DDto()));
            });

            return destination.ToList<DDto>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            List<DDto> destination = new List<DDto>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.D, DDto>(source) as DDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.D> sources = sourceList as List<Benchmark.Common.D>;
            ConcurrentBag<DDto> destination = new ConcurrentBag<DDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.D, DDto>(source) as DDto);
            });

            return destination.ToList<DDto>();
        }
        #endregion

        #region Internal Methods
        internal DDto ConvertToInternal(Benchmark.Common.D source, DDto destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class DDto_D : Benchmark.Common.DDto, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.DDto, new D());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.DDto, destinationObject as D);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.DDto, this.Destination as D);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new D()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new D()));
            });

            return destination.ToList<D>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            List<D> destination = new List<D>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.DDto, D>(source) as D);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.DDto> sources = sourceList as List<Benchmark.Common.DDto>;
            ConcurrentBag<D> destination = new ConcurrentBag<D>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.DDto, D>(source) as D);
            });

            return destination.ToList<D>();
        }
        #endregion

        #region Internal Methods
        internal D ConvertToInternal(Benchmark.Common.DDto source, D destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class E_EDto : Benchmark.Common.E, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.E, new EDto());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.E, destinationObject as EDto);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.E, this.Destination as EDto);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<EDto> destination = new List<EDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new EDto()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<EDto> destination = new ConcurrentBag<EDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new EDto()));
            });

            return destination.ToList<EDto>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            List<EDto> destination = new List<EDto>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.E, EDto>(source) as EDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.E> sources = sourceList as List<Benchmark.Common.E>;
            ConcurrentBag<EDto> destination = new ConcurrentBag<EDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.E, EDto>(source) as EDto);
            });

            return destination.ToList<EDto>();
        }
        #endregion

        #region Internal Methods
        internal EDto ConvertToInternal(Benchmark.Common.E source, EDto destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class EDto_E : Benchmark.Common.EDto, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.EDto, new E());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.EDto, destinationObject as E);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.EDto, this.Destination as E);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new E()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new E()));
            });

            return destination.ToList<E>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            List<E> destination = new List<E>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.EDto, E>(source) as E);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.EDto> sources = sourceList as List<Benchmark.Common.EDto>;
            ConcurrentBag<E> destination = new ConcurrentBag<E>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.EDto, E>(source) as E);
            });

            return destination.ToList<E>();
        }
        #endregion

        #region Internal Methods
        internal E ConvertToInternal(Benchmark.Common.EDto source, E destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class F_FDto : Benchmark.Common.F, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.F, new FDto());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.F, destinationObject as FDto);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.F, this.Destination as FDto);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<FDto> destination = new List<FDto>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new FDto()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<FDto> destination = new ConcurrentBag<FDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new FDto()));
            });

            return destination.ToList<FDto>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            List<FDto> destination = new List<FDto>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.F, FDto>(source) as FDto);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.F> sources = sourceList as List<Benchmark.Common.F>;
            ConcurrentBag<FDto> destination = new ConcurrentBag<FDto>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.F, FDto>(source) as FDto);
            });

            return destination.ToList<FDto>();
        }
        #endregion

        #region Internal Methods
        internal FDto ConvertToInternal(Benchmark.Common.F source, FDto destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }
    public class FDto_F : Benchmark.Common.FDto, IMappable
    {
        #region Properties
        public object Source { get; set; }
        public object Destination { get; set; }
        #endregion

        #region Object Map
        public object ConvertTo()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.FDto, new F());
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
            return ConvertToInternal(sourceObject as Benchmark.Common.FDto, destinationObject as F);
        }
        public object ConvertFromSourceToDest()
        {
            return ConvertToInternal(this.Source as Benchmark.Common.FDto, this.Destination as F);
        }
        #endregion

        #region Collection Map
        public object ConvertToList(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(ConvertToInternal(source, new F()));
            }

            return destination;
        }
        public object ConvertToListMultiThreaded(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(ConvertToInternal(source, new F()));
            });

            return destination.ToList<F>();
        }
        public object ConvertToListDeepCopy(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            List<F> destination = new List<F>();
            foreach (var source in sources)
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.FDto, F>(source) as F);
            }

            return destination;
        }
        public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
        {
            List<Benchmark.Common.FDto> sources = sourceList as List<Benchmark.Common.FDto>;
            ConcurrentBag<F> destination = new ConcurrentBag<F>();
            System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
            {
                destination.Add(EntityMapper.Mapper.Current.MapDeep<Benchmark.Common.FDto, F>(source) as F);
            });

            return destination.ToList<F>();
        }
        #endregion

        #region Internal Methods
        internal F ConvertToInternal(Benchmark.Common.FDto source, F destination)
        {
            destination.Name = source.Name;
            destination.Address = source.Address;
            destination.Age = source.Age;
            destination.Id = source.Id;
            destination.Height = source.Height;
            destination.Wight = source.Wight;
            destination.Color = source.Color;

            return destination;
        }
        #endregion
    }

}

