namespace com.g1.arcgis.tn.map
{
    partial class GMapView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GMapView));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbiSelect = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFullExtent = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBack = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNext = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClear = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomToSelected = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiIdentify = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSelectByGraphic = new DevExpress.XtraBars.BarButtonItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
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
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiSelect,
            this.bbiPan,
            this.bbiZoomIn,
            this.bbiZoomOut,
            this.bbiFullExtent,
            this.bbiBack,
            this.bbiNext,
            this.bbiClear,
            this.bbiZoomToSelected,
            this.barButtonItem10,
            this.bbiIdentify,
            this.bbiSelectByGraphic});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSelect),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPan),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiZoomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFullExtent),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBack),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiZoomToSelected),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIdentify)});
            this.bar1.Offset = 1;
            this.bar1.Text = "Tools";
            // 
            // bbiSelect
            // 
            this.bbiSelect.Caption = "Chọn đối tượng";
            this.bbiSelect.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.select_16;
            this.bbiSelect.Id = 0;
            this.bbiSelect.Name = "bbiSelect";
            this.bbiSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSelect_ItemClick);
            // 
            // bbiPan
            // 
            this.bbiPan.Caption = "Di chuyển";
            this.bbiPan.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.hand_16;
            this.bbiPan.Id = 1;
            this.bbiPan.Name = "bbiPan";
            this.bbiPan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPan_ItemClick);
            // 
            // bbiZoomIn
            // 
            this.bbiZoomIn.Caption = "Phóng to";
            this.bbiZoomIn.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.zoom_in_16;
            this.bbiZoomIn.Id = 2;
            this.bbiZoomIn.Name = "bbiZoomIn";
            this.bbiZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomIn_ItemClick);
            // 
            // bbiZoomOut
            // 
            this.bbiZoomOut.Caption = "Thu nhỏ";
            this.bbiZoomOut.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.zoom_out_16;
            this.bbiZoomOut.Id = 3;
            this.bbiZoomOut.Name = "bbiZoomOut";
            this.bbiZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomOut_ItemClick);
            // 
            // bbiFullExtent
            // 
            this.bbiFullExtent.Caption = "Toàn cảnh";
            this.bbiFullExtent.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.zoom_extent_16;
            this.bbiFullExtent.Id = 4;
            this.bbiFullExtent.Name = "bbiFullExtent";
            this.bbiFullExtent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFullExtent_ItemClick);
            // 
            // bbiBack
            // 
            this.bbiBack.Caption = "Về trước";
            this.bbiBack.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.back_icon_16;
            this.bbiBack.Id = 5;
            this.bbiBack.Name = "bbiBack";
            this.bbiBack.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBack_ItemClick);
            // 
            // bbiNext
            // 
            this.bbiNext.Caption = "Về sau";
            this.bbiNext.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.forward_icon_16;
            this.bbiNext.Id = 6;
            this.bbiNext.Name = "bbiNext";
            this.bbiNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNext_ItemClick);
            // 
            // bbiClear
            // 
            this.bbiClear.Caption = "Bỏ chọn";
            this.bbiClear.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.clearSelection_icon_16;
            this.bbiClear.Id = 7;
            this.bbiClear.Name = "bbiClear";
            this.bbiClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClear_ItemClick);
            // 
            // bbiZoomToSelected
            // 
            this.bbiZoomToSelected.Caption = "Phóng tới đối tượng";
            this.bbiZoomToSelected.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.zoomToSelected_icon_16;
            this.bbiZoomToSelected.Id = 8;
            this.bbiZoomToSelected.Name = "bbiZoomToSelected";
            this.bbiZoomToSelected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomToSelected_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem10)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Công cụ";
            this.barButtonItem10.Id = 9;
            this.barButtonItem10.Name = "barButtonItem10";
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
            this.barDockControlTop.Size = new System.Drawing.Size(639, 53);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 427);
            this.barDockControlBottom.Size = new System.Drawing.Size(639, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 53);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 374);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(639, 53);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 374);
            // 
            // bbiIdentify
            // 
            this.bbiIdentify.Caption = "Identify";
            this.bbiIdentify.Glyph = global::com.g1.arcgis.tn.map.Properties.Resources.info_16;
            this.bbiIdentify.Id = 10;
            this.bbiIdentify.Name = "bbiIdentify";
            this.bbiIdentify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiIdentify_ItemClick);
            // 
            // bbiSelectByGraphic
            // 
            this.bbiSelectByGraphic.Caption = "selectByGraphic";
            this.bbiSelectByGraphic.Id = 11;
            this.bbiSelectByGraphic.Name = "bbiSelectByGraphic";
            this.bbiSelectByGraphic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSelectByGraphic_ItemClick);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(639, 374);
            this.axMapControl1.TabIndex = 4;
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(556, 74);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // GMapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GMapView";
            this.Size = new System.Drawing.Size(639, 450);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiSelect;
        private DevExpress.XtraBars.BarButtonItem bbiPan;
        private DevExpress.XtraBars.BarButtonItem bbiZoomIn;
        private DevExpress.XtraBars.BarButtonItem bbiZoomOut;
        private DevExpress.XtraBars.BarButtonItem bbiFullExtent;
        private DevExpress.XtraBars.BarButtonItem bbiBack;
        private DevExpress.XtraBars.BarButtonItem bbiNext;
        private DevExpress.XtraBars.BarButtonItem bbiClear;
        private DevExpress.XtraBars.BarButtonItem bbiZoomToSelected;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem bbiIdentify;
        private DevExpress.XtraBars.BarButtonItem bbiSelectByGraphic;
    }
}
