namespace TNPro.Danhmuc
{
    partial class FrmHem
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnHem = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dpnMap = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer3 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer4 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpnDuong = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gTableView2 = new com.g1.arcgis.tn.query.GTableView();
            this.dpnHemChinh = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gTableView3 = new com.g1.arcgis.tn.query.GTableView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gTableView1 = new com.g1.arcgis.tn.query.GTableView();
            this.gMapView1 = new com.g1.arcgis.tn.map.GMapView();
            this.gLayersView1 = new com.g1.arcgis.tn.map.GLayersView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dpnHem.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dpnMap.SuspendLayout();
            this.controlContainer3.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.controlContainer4.SuspendLayout();
            this.dpnDuong.SuspendLayout();
            this.controlContainer2.SuspendLayout();
            this.dpnHemChinh.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 0;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1005, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 508);
            this.barDockControlBottom.Size = new System.Drawing.Size(1005, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 457);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1005, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 457);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnHem});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1,
            this.dpnDuong,
            this.dpnHemChinh});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpnHem
            // 
            this.dpnHem.Controls.Add(this.dockPanel1_Container);
            this.dpnHem.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpnHem.ID = new System.Guid("bda16149-0bae-42a4-9960-38aa8b3cd48d");
            this.dpnHem.Location = new System.Drawing.Point(0, 0);
            this.dpnHem.Name = "dpnHem";
            this.dpnHem.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpnHem.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnHem.SavedIndex = 1;
            this.dpnHem.Size = new System.Drawing.Size(267, 189);
            this.dpnHem.Text = "Hẻm";
            this.dpnHem.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(259, 162);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dockPanel1;
            this.panelContainer1.Controls.Add(this.dockPanel1);
            this.panelContainer1.Controls.Add(this.dpnMap);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("ac5d33fa-c8fa-4d9a-abe6-c5aa04728cc7");
            this.panelContainer1.Location = new System.Drawing.Point(664, 51);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(341, 200);
            this.panelContainer1.Size = new System.Drawing.Size(341, 457);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dpnMap
            // 
            this.dpnMap.Controls.Add(this.controlContainer3);
            this.dpnMap.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dpnMap.FloatVertical = true;
            this.dpnMap.ID = new System.Guid("e4f12c19-a5ce-4393-8dbb-473a224d9206");
            this.dpnMap.Location = new System.Drawing.Point(4, 23);
            this.dpnMap.Name = "dpnMap";
            this.dpnMap.OriginalSize = new System.Drawing.Size(182, 403);
            this.dpnMap.Size = new System.Drawing.Size(333, 403);
            this.dpnMap.Text = "Bản đồ";
            // 
            // controlContainer3
            // 
            this.controlContainer3.Controls.Add(this.gMapView1);
            this.controlContainer3.Location = new System.Drawing.Point(0, 0);
            this.controlContainer3.Name = "controlContainer3";
            this.controlContainer3.Size = new System.Drawing.Size(333, 403);
            this.controlContainer3.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.controlContainer4);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("2de3b877-a4b3-4bad-a587-f2a50bc5471d");
            this.dockPanel1.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(182, 403);
            this.dockPanel1.Size = new System.Drawing.Size(333, 403);
            this.dockPanel1.Text = "Các lớp bản đồ";
            // 
            // controlContainer4
            // 
            this.controlContainer4.Controls.Add(this.gLayersView1);
            this.controlContainer4.Location = new System.Drawing.Point(0, 0);
            this.controlContainer4.Name = "controlContainer4";
            this.controlContainer4.Size = new System.Drawing.Size(333, 403);
            this.controlContainer4.TabIndex = 0;
            // 
            // dpnDuong
            // 
            this.dpnDuong.Controls.Add(this.controlContainer2);
            this.dpnDuong.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpnDuong.ID = new System.Guid("df2133c9-6b01-496f-a530-c7f38d0b9178");
            this.dpnDuong.Location = new System.Drawing.Point(344, 51);
            this.dpnDuong.Name = "dpnDuong";
            this.dpnDuong.OriginalSize = new System.Drawing.Size(320, 200);
            this.dpnDuong.Size = new System.Drawing.Size(320, 457);
            this.dpnDuong.Text = "Đường giao thông";
            // 
            // controlContainer2
            // 
            this.controlContainer2.Controls.Add(this.gTableView2);
            this.controlContainer2.Location = new System.Drawing.Point(4, 23);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(312, 430);
            this.controlContainer2.TabIndex = 0;
            // 
            // gTableView2
            // 
            this.gTableView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTableView2.Location = new System.Drawing.Point(0, 0);
            this.gTableView2.Name = "gTableView2";
            this.gTableView2.Size = new System.Drawing.Size(312, 430);
            this.gTableView2.TabIndex = 0;
            // 
            // dpnHemChinh
            // 
            this.dpnHemChinh.Controls.Add(this.controlContainer1);
            this.dpnHemChinh.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dpnHemChinh.FloatVertical = true;
            this.dpnHemChinh.ID = new System.Guid("e7d381ef-e93b-485b-b3fb-086dc19cd9aa");
            this.dpnHemChinh.Location = new System.Drawing.Point(0, 299);
            this.dpnHemChinh.Name = "dpnHemChinh";
            this.dpnHemChinh.OriginalSize = new System.Drawing.Size(267, 209);
            this.dpnHemChinh.Size = new System.Drawing.Size(344, 209);
            this.dpnHemChinh.Text = "Hẻm chính";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.gTableView3);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(336, 182);
            this.controlContainer1.TabIndex = 0;
            // 
            // gTableView3
            // 
            this.gTableView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTableView3.Location = new System.Drawing.Point(0, 0);
            this.gTableView3.Name = "gTableView3";
            this.gTableView3.Size = new System.Drawing.Size(336, 182);
            this.gTableView3.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gTableView1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 51);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(344, 248);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Hẻm";
            // 
            // gTableView1
            // 
            this.gTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTableView1.Location = new System.Drawing.Point(2, 22);
            this.gTableView1.Name = "gTableView1";
            this.gTableView1.Size = new System.Drawing.Size(340, 224);
            this.gTableView1.TabIndex = 0;
            // 
            // gMapView1
            // 
            this.gMapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapView1.Location = new System.Drawing.Point(0, 0);
            this.gMapView1.Name = "gMapView1";
            this.gMapView1.Size = new System.Drawing.Size(333, 403);
            this.gMapView1.TabIndex = 0;
            // 
            // gLayersView1
            // 
            this.gLayersView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gLayersView1.Location = new System.Drawing.Point(0, 0);
            this.gLayersView1.Name = "gLayersView1";
            this.gLayersView1.Size = new System.Drawing.Size(333, 403);
            this.gLayersView1.TabIndex = 0;
            // 
            // FrmHem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 531);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dpnHemChinh);
            this.Controls.Add(this.dpnDuong);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmHem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHem";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dpnHem.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dpnMap.ResumeLayout(false);
            this.controlContainer3.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.controlContainer4.ResumeLayout(false);
            this.dpnDuong.ResumeLayout(false);
            this.controlContainer2.ResumeLayout(false);
            this.dpnHemChinh.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dpnDuong;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private DevExpress.XtraBars.Docking.DockPanel dpnHem;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpnHemChinh;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private com.g1.arcgis.tn.query.GTableView gTableView1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dpnMap;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer3;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer4;
        private com.g1.arcgis.tn.query.GTableView gTableView3;
        private com.g1.arcgis.tn.query.GTableView gTableView2;
        private com.g1.arcgis.tn.map.GLayersView gLayersView1;
        private com.g1.arcgis.tn.map.GMapView gMapView1;
    }
}