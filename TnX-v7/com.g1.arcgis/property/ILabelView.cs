using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace com.g1.arcgis.property
{
    public interface ILabelView
    {
        void Show();
        void Close();
        IFeatureLayer MyLayer { get; set; }
        IMapControl4 MyMapControl { get; set; }
    }
}
