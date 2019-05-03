using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace EntityMapper
{
    internal class MapInfo<TSource, TDestination> : IMapInfo
    //where TSource : class
    //where TDestination : class
    {
        public List<Action<TSource, TDestination>> CustomMappings { get; } = new List<Action<TSource, TDestination>>();
        public List<string> PropertiesToIgnoreList = new List<string>();
        public Type SourceType { get { return typeof(TSource); } }
        public Type DestinationType { get { return typeof(TDestination); } }

        public Type Mapper { get; set; }
        public IMappable Instance { get; set; }
        public string SourceCodeTSource { get; set; }
        public string SourceCodeTDestination { get; set; }
        public void AddCustomMapping(Action<TSource, TDestination> customMapping)
        {
            CustomMappings.Add(customMapping);
        }
        public void AddCustomMappings(params Action<TSource, TDestination>[] customMappings)
        {
            CustomMappings.AddRange(customMappings);
        }
        public void ExecuteCustomMappings(TSource source, TDestination destionation)
        {
            foreach(var option in CustomMappings)
            {
                option(source, destionation);
            }
        }

        public void Ignore(params string[] propertyName)
        {
            //Expression<Action<PropertyInfo>> lambda = prop => PropertiesToIgnoreList.Add(prop);
            //propertyToIgnore.Compile().Invoke(prop);
            PropertiesToIgnoreList.AddRange(propertyName);
        }

        public List<string> PropertiesToIgnore()
        {
            return PropertiesToIgnoreList;
        }

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
