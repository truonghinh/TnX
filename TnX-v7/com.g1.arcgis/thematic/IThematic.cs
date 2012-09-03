using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace com.g1.arcgis.thematic
{
    public interface IThematic
    {
        void SingleRender();
        void JoinRender();
        int IndexLayer { get; set; }
        string FieldName { get; set; }
        int BreakCount { get; set; }
        double MinValue { get; set; }
        double MaxValue { get; set; }
        void SetMapControl(IMapControl3 mapControl);
        void SetTocControl(ITOCControl2 tocControl);
        IFeatureLayer Layer { get; set; }
        
    }
}
