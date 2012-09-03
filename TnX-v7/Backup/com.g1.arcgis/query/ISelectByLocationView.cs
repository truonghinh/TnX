using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;

namespace com.g1.arcgis.query
{
    public interface ISelectByLocationView
    {
        IMapControl4 MapControl { get; set; }
        void Show();
        void Close();
    }
}
