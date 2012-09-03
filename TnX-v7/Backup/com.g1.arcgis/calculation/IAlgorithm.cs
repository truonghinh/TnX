using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;

namespace com.g1.arcgis.calculation
{
    public interface IAlgorithm
    {
        string Name { get; set; }
        void Execute();
        void SetResultLayer(IFeatureLayer resultLayer);
    }
}
