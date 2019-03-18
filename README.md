# SimpleMapper - Work In Progress
.Net Object to object mapper library. Provides shallow and deep copy mapping of objects and collections.

### How to Configure
```c#
SimpleMapper.Mapper.Configure(cfg =>
{
    cfg.ClearMappings();
    cfg.CreateMap<A, A>(reversal: false);
    cfg.CreateMap<B, B>(reversal: false);
    cfg.CreateMap<A, ADto>(reversal: true);
    cfg.CreateMap<B, BDto>(reversal: true);
});
```

### How to Map Objects
```c#
A source = new A();
B result = SimpleMapper.Mapper.Current.Map<A, B>(source);
```

### How to Map Lists
```c#
List<A> source = new List<A>(){new A(), new A()};
List<B> result = SimpleMapper.Mapper.Current.MapList<List<A>, List<B>(source);
```
