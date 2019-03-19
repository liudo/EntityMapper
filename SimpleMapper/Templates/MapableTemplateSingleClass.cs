public class SourceName_TDestination : SourceNamespace.SourceName, IMappable
{
    #region Properties
    public object Source { get; set; }
    public object Destination { get; set; }
    #endregion

    #region Object Map
    public object ConvertTo()
    {
        return ConvertToInternal(this.Source as SourceNamespace.SourceName, new TDestination());
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
        return ConvertToInternal(sourceObject as SourceNamespace.SourceName, destinationObject as TDestination);
    }
    public object ConvertFromSourceToDest()
    {
        return ConvertToInternal(this.Source as SourceNamespace.SourceName, this.Destination as TDestination);
    }
    #endregion

    #region Collection Map
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
            destination.Add(EntityMapper.Mapper.Current.MapDeep<SourceNamespace.SourceName, TDestination>(source) as TDestination);
        }

        return destination;
    }
    public object ConvertToListMiltiTreadedDeepCopy(object sourceList)
    {
        List<SourceNamespace.SourceName> sources = sourceList as List<SourceNamespace.SourceName>;
        ConcurrentBag<TDestination> destination = new ConcurrentBag<TDestination>();
        System.Threading.Tasks.Parallel.ForEach(sources, (source) =>
        {
            destination.Add(EntityMapper.Mapper.Current.MapDeep<SourceNamespace.SourceName, TDestination>(source) as TDestination);
        });

        return destination.ToList<TDestination>();
    }
    #endregion

    #region Internal Methods
    internal TDestination ConvertToInternal(SourceNamespace.SourceName source, TDestination destination)
    {
        Destination.Property.Mapping;
        return destination;
    }
    #endregion
}