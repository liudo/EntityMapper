using System;

namespace SimpleMapper
{
    internal class MapInfo<TSource, TDestination> : IMapInfo
    {
        public Type SourceType { get { return typeof(TSource); } }
        public Type DestinationType { get { return typeof(TDestination); } }

        public Type Mapper { get; set; }
        public IMapableInternal Instance { get; set; }
        public string SourceCodeTSource { get; set; }
        public string SourceCodeTDestination { get; set; }

        public string DestinationNamespace
        {
            get
            {
                return DestinationType.Namespace;
            }
        }

        public string SourceNamespace
        {
            get
            {
                return SourceType.Namespace;
            }
        }

    }
}
