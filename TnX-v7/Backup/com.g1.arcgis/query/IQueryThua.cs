using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.query
{
    public interface IQueryThua
    {
        object TypeOfQuery { get; set; }
        void Query();
        IInfoForQuery Info { get; set; }
        event QueryFinishedEventHandler Finished;
        event QueryingEventHandler Querying;
    }
}
