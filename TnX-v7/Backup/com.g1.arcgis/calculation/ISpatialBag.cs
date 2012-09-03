using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.calculation
{
    public interface ISpatialBag:IVisitorBag
    {
        IFeatureLayer ResultFeatureLayer { get; set; }
        IFeatureLayer FromFeatureLayer { get; set; }
        IFeatureLayer ByFeatureLayer { get; set; }
        IFeatureSelection ResultFeatureSelection { get; set; }
        ISelectionSet ResultSelectionSet { get; set; }
    }
}
