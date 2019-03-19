using System;
using System.Collections.Generic;
using System.Text;

namespace EntityMapper
{
    public interface IMappable
    {
        #region Properties
        object Source { get; set; }
        object Destination { get; set; }
        #endregion

        #region Object Map
        object ConvertTo();
        object ConvertToDeepCopy();
        object ConvertTo(object source, object destination);
        object ConvertFromSourceToDest();
        #endregion

        #region Collection Map
        object ConvertToList(object sourceList);
        object ConvertToListMultiThreaded(object sourceList);
        object ConvertToListDeepCopy(object sourceList);
        object ConvertToListMiltiTreadedDeepCopy(object sourceList);
        #endregion

    }
}
