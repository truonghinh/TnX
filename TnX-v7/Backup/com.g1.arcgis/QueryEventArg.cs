using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis
{
    public class QueryEventArg:EventArgs
    {
        public object Data;
        public QueryEventArg()
            : base()
        { }
    }
}
