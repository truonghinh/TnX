namespace TNPro.Quydinh
{
    partial class FrmGiaDatPnnDt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gTableViewAllowCopy1 = new com.g1.arcgis.tn.query.GTableViewAllowCopy();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gLayersView1 = new com.g1.arcgis.tn.map.GLayersView();
            this.gMapView1 = new com.g1.arcgis.tn.map.GMapView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gTableViewAllowCopy1
            // 
            this.gTableViewAllowCopy1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gTableViewAllowCopy1.Location = new System.Drawing.Point(0, 0);
            this.gTableViewAllowCopy1.Name = "gTableViewAllowCopy1";
            this.gTableViewAllowCopy1.Size = new System.Drawing.Size(249, 424);
            this.gTableViewAllowCopy1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gMapView1);
            this.panelControl1.Controls.Add(this.splitterControl2);
            this.panelControl1.Controls.Add(this.gLayersView1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(254, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(648, 424);
            this.panelControl1.TabIndex = 1;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(249, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 424);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // gLayersView1
            // 
            this.gLayersView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gLayersView1.Location = new System.Drawing.Point(536, 2);
            this.gLayersView1.Name = "gLayersView1";
            this.gLayersView1.Size = new System.Drawing.Size(110, 420);
            this.gLayersView1.TabIndex = 0;
            // 
            // gMapView1
            // 
            this.gMapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapView1.Location = new System.Drawing.Point(2, 2);
            this.gMapView1.Name = "gMapView1";
            this.gMapView1.Size = new System.Drawing.Size(529, 420);
            this.gMapView1.TabIndex = 1;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl2.Location = new System.Drawing.Point(531, 2);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 420);
            this.splitterControl2.TabIndex = 2;
            this.splitterControl2.TabStop = false;
            // 
            // FrmGiaDatPnnDt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 424);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gTableViewAllowCopy1);
            this.Name = "FrmGiaDatPnnDt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giá đất phi nông nghiệp tại đô thị";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private com.g1.arcgis.tn.query.GTableViewAllowCopy gTableViewAllowCopy1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private com.g1.arcgis.tn.map.GMapView gMapView1;
        private com.g1.arcgis.tn.map.GLayersView gLayersView1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
    }
}