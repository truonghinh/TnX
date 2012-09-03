using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;

namespace com.g1.arcgis.map
{
    public interface ILayersView
    {
        void SetMapBuddy(object map_buddy);
        IMapView GetMapView();
        object GetMapBuddy();
        void Refresh();
        ITOCControl2 GetTocControl();
    }
}
