using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Docking;

namespace com.g1.arcgis.control
{
    public interface IGControl
    {
        void SetParentDockControl(DockPanel parent);
        void Show();
        void Hide();
    }
}
