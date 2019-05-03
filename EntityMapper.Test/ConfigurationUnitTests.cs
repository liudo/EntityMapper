using Benchmark;
using Benchmark.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityMapper.Test
{
    [TestClass]
    public class ConfigurationUnitTests
    {
        [TestMethod]
        public void ObjectMapperConfiguration()
        {
            Mapper.Configure(cfg =>
            {
                cfg.ClearMappings();
                //cfg.CreateMap<B, B>(reversal: false);
                //cfg.CreateMap<C, C>(reversal: false);
                //cfg.CreateMap<D, D>(reversal: false);
                //cfg.CreateMap<E, E>(reversal: false);
                //cfg.CreateMap<F, F>(reversal: false);
                cfg.CreateMap<B, BDto>(reversal: false).CustomMap((source, dest) => 
                {
                    dest.Address = source.Color;
                });
                cfg.CreateMap<C, CDto>(reversal: true).CustomMappings(
                    (source, dest) =>
                    {
                        if(source.Age > 5)
                            dest.NewAge = source.Age;
                    },
                    (source, dest) => { dest.Color = source.Name; }
                ).Ingore("Height", "Color");
                //cfg.CreateMap<D, DDto>(reversal: true);
                //cfg.CreateMap<E, EDto>(reversal: true);
                //cfg.CreateMap<F, FDto>(reversal: true);
                cfg.Compile("EntityMapper_ObjectMapper.dll");
            });

            var b = DataGenerator.GetRandom<B>();
            var bdto = Mapper.Current.Map<B, BDto>(b);
            Assert.AreEqual(b.Color, bdto.Address);

            var c = DataGenerator.GetRandom<C>();
            c.Age = 6;
            var cdto = Mapper.Current.Map<C, CDto>(c);
            Assert.AreEqual(c.Name, cdto.Color);
            Assert.AreEqual(c.Age, cdto.NewAge);

            Assert.AreEqual(cdto.Height, default(int));
            Assert.AreNotEqual(cdto.Color, default(string)); //because of the custom mapping this is not ignored

            c.Age = 3;
            cdto = Mapper.Current.Map<C, CDto>(c);
            Assert.AreEqual(c.Name, cdto.Color);
            Assert.AreEqual(0, cdto.NewAge);
        }
    }
}
