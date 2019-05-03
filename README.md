# EntityMapper - Work In Progress
.Net Object to object mapper library. Provides shallow and deep copy mapping of objects and collections.

### How to Configure
```c#
EntityMapper.Mapper.Configure(cfg =>
{
    cfg.ClearMappings();
    cfg.CreateMap<A, A>(reversal: false);
    cfg.CreateMap<B, B>(reversal: false);
    cfg.CreateMap<A, ADto>(reversal: true);
    cfg.CreateMap<B, BDto>(reversal: true);
    cfg.Compile();
});
```

### How to Ignore Property
```c#
EntityMapper.Mapper.Configure(cfg =>
{
    cfg.ClearMappings();
    cfg.CreateMap<B, BDto>(reversal: true).Ignore("PropertyName1", "PropertyName2");
    cfg.Compile();
});
```

### How to do Custom Mappings
```c#
EntityMapper.Mapper.Configure(cfg =>
{
    cfg.ClearMappings();
    cfg.CreateMap<C, CDto>(reversal: true).CustomMappings(
        (source, dest) =>
        {
            if(source.Age > 5)
                dest.NewAge = source.Age;
        },
        (source, dest) => { dest.Color = source.Name; }
    );
    cfg.Compile();
});
```

### How to Map Objects
```c#
A source = new A();
B result = EntityMapper.Mapper.Current.Map<A, B>(source);
```

### How to Map Lists
```c#
List<A> source = new List<A>(){new A(), new A()};
List<B> result = EntityMapper.Mapper.Current.MapList<List<A>, List<B>(source);
```
