using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.dataManagement
{
    public class FeatureClassManagement
    {
        public static void DeleteFeatureClass(IDataset data)
        {
            if (data.CanDelete())
            {
                data.Delete();
            }
        }
    }
}
