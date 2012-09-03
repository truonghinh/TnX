using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.database;

namespace com.g1.arcgis
{
    public class LoaderEventArg:EventArgs
    {
        public EnumG1ArcGisTnRecType _type;
        public LoaderEventArg(EnumG1ArcGisTnRecType type)
        {
            this._type = type;
        }
    }
}
