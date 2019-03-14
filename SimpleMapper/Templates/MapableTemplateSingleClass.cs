public class SourceName_TDestination : SourceNamespace.SourceName, IMapableInternal
{
    public object Source { get; set; }
    public object Destination { get; set; }
    public object ConvertTo()
    {
        SourceNamespace.SourceName source = this.Source as SourceNamespace.SourceName;
        TDestination destination = new TDestination();
        Destination.Property.Mapping;
        return destination;
    }

    public object ConvertToDeepCopy()
    {
        SourceNamespace.SourceName source = this.Source as SourceNamespace.SourceName;
        TDestination destination = new TDestination();
        Destination.Property.Mapping.Deep;
        return destination;
    }

    public object ConvertTo(object sourceObject, object destinationObject)
    {
        SourceNamespace.SourceName source = sourceObject as SourceNamespace.SourceName;
        TDestination destination = destinationObject as TDestination;
        Destination.Property.Mapping;
        return destination;
    }

    public TDestination ConvertToInternal(SourceNamespace.SourceName source, TDestination destination)
    {
        Destination.Property.Mapping;
        return destination;
    }

    public object ConvertFromSourceToDest()
    {
        SourceNamespace.SourceName source = this.Source as SourceNamespace.SourceName;
        TDestination destination = this.Destination as TDestination;
        Destination.Property.Mapping;
        return destination;
    }

    public object ConvertToList(object sourceList)
    {
        List<SourceNamespace.SourceName> sources = sourceList as List<SourceNamespace.SourceName>;
        List<TDestination> destination = new List<TDestination>();
        foreach (var source in sources)
        {
            Destination.Property.Mapping.List;
        }

        return destination;
    }

    public object ConvertToListMultiThreaded(object sourceList)
    {
        List<SourceNamespace.SourceName> sources = sourceList as List<SourceNamespace.SourceName>;
        ConcurrentBag<TDestination> destination = new ConcurrentBag<TDestination>();
        System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
        {
            Destination.Property.Mapping.List;
        });

        return destination.ToList<TDestination>();
    }

    public object ConvertToListDeepCopy(object sourceList)
    {
        List<SourceNamespace.SourceName> sources = sourceList as List<SourceNamespace.SourceName>;
        List<TDestination> destination = new List<TDestination>();
        foreach (var source in sources)
        {
            destination.Add(SimpleMapper.Mapper.MapDeep<SourceNamespace.SourceName, TDestination>(source) as TDestination);
        }

        return destination;
    }
    public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
    {
        List<SourceNamespace.SourceName> sources = sourceList as List<SourceNamespace.SourceName>;
        ConcurrentBag<TDestination> destination = new ConcurrentBag<TDestination>();
        System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
        {
            destination.Add(SimpleMapper.Mapper.MapDeep<SourceNamespace.SourceName, TDestination>(source) as TDestination);
        });

        return destination.ToList<TDestination>();
    }
}