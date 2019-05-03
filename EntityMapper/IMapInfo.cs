using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EntityMapper
{
    public interface IMapInfo
    {
        Type SourceType { get; }
        Type DestinationType { get; }

        Type Mapper { get; set; }
        string SourceCodeTSource { get; set; }
        string SourceCodeTDestination { get; set; }
        IMappable Instance { get; set; }
        string DestinationNamespace { get; }

        string SourceNamespace { get; }
        //void AddCustomMapping<TSource, TDestination>(Action<TSource, TDestination> options);
        List<string> PropertiesToIgnore();
    }
}
