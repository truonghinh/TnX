using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.calculation
{
    public interface ISpatialAlgrorithm:IAlgorithm
    {
        void SetLayers(IFeatureLayer fromLayer, IFeatureLayer byLayer);
        IFeatureLayer FromLayer { get; set; }
        IFeatureLayer ByLayer { get; set; }
        void SetMethod(esriLayerSelectionMethod method);
        void IsUseSelected(bool useSelected);
        void SetResultType(esriSelectionResultEnum resultType);
        void SetBufferDistance(double buffer);
        IFeatureLayer GetResultLayer();
        ISelectionSet GetResultSelectionSet();
        ISelectionSet Execute();
        IFeatureClass FromFeatureClass { get; set; }
        IFeatureClass ByFeatureClass { get; set; }
    }
}
