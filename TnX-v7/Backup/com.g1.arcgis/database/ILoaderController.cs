using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.database
{
    public interface ILoaderController
    {
        void ReqLoad(EnumG1ArcGisTnRecType type);
        void ReqReload();
    }
}
