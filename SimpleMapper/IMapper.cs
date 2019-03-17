using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    interface IMapper
    {
        #region Object Map
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TDestination : class;
        TDestination Map<TSource, TDestination>(TSource source) where TDestination : class, new();
        TDestination MapDeep<TSource, TDestination>(TSource source) where TDestination : class, new();
        #endregion

        #region Collection Map
        TDestination MapListDeep<TSource, TDestination>(TSource source) where TDestination : class, new();
        TDestination MapListDeepParallel<TSource, TDestination>(TSource source) where TDestination : class, new();
        TDestination MapList<TSource, TDestination>(TSource source) where TDestination : class, new();
        TDestination MapListParallel<TSource, TDestination>(TSource source) where TDestination : class, new();
        #endregion
    }
}
