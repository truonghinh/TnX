using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.database
{
    public interface IFeatureClassManager
    {
        void DeleteFeatureClass(IDataset data);
        void DeleteFcInSde(string data);
    }
}
