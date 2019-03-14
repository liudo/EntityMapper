using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMapper
{
    public interface IMapable<TDestination>
    {
        TDestination ConvertTo();
    }

    public interface IMapableInternal {
        object ConvertTo();
        object ConvertToDeepCopy();
        object ConvertTo(object source, object destination);
        object ConvertFromSourceToDest();

        object ConvertToList(object sourceList);
        object ConvertToListMultiThreaded(object sourceList);
        object ConvertToListDeepCopy(object sourceList);
        object ConvertToListMiltiTreadedDeepCopy(object sourceList);

        object Source { get; set; }
        object Destination { get; set; }
    }
}
