using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Docking;

namespace TNPro
{
    class DockPanelMapControl:DockPanel
    {
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;

        private void InitializeComponent()
        {
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.Size = new System.Drawing.Size(75, 23);
            this.axMapControl1.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
