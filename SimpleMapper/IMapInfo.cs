using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    internal interface IMapInfo
    {
        Type SourceType { get; }
        Type DestinationType { get; }

        Type Mapper { get; set; }
        string SourceCodeTSource { get; set; }
        string SourceCodeTDestination { get; set; }
        IMappable Instance { get; set; }
        string DestinationNamespace { get; }

        string SourceNamespace { get; }
    }
}
