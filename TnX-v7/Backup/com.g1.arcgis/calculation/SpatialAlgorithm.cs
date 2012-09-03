using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.calculation
{
    public class SpatialAlgorithm:Algorithm
    {
        protected IFeatureLayer _fromLayer;
        protected IFeatureLayer _byLayer;
        protected IQueryByLayer _queryByLayer;
        protected IFeatureLayer _resultLayer;
        protected ISelectionSet _resultSelectionSet;
        protected IFeatureSelection _resultFeatureSelection;
    }
}
