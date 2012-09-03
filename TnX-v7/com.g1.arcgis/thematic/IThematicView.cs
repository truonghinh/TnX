using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace com.g1.arcgis.thematic
{
    public interface IThematicView
    {
        int IndexLayer { get; set; }
        string FieldName { get; set; }
        int BreakCount { get; set; }
        double MinValue { get; set; }
        double MaxValue { get; set; }
        void Render();
        void SetParent(Control parent);
        void SetParent(DockPanel parent);
        void SetParent(Form parent);
        void SetParent(XtraForm parent);
        void SetMapControl(IMapControl3 mapControl);
        void SetTocControl(ITOCControl2 tocControl);
        IFeatureLayer Layer { get; set; }
    }
}
