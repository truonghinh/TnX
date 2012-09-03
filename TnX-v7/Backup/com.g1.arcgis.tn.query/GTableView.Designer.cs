namespace com.g1.arcgis.tn.query
{
    partial class GTableView
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
            this.grcAttributeTable = new DevExpress.XtraGrid.GridControl();
            this.grvAttributeTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bbiStartEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStopEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXoa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLuu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.grcAttributeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAttributeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grcAttributeTable
            // 
            this.grcAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcAttributeTable.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcAttributeTable.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcAttributeTable.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcAttributeTable.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcAttributeTable.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcAttributeTable.EmbeddedNavigator.TextStringFormat = "Hàng {0} / {1}";
            this.grcAttributeTable.Location = new System.Drawing.Point(0, 61);
            this.grcAttributeTable.MainView = this.grvAttributeTable;
            this.grcAttributeTable.Name = "grcAttributeTable";
            this.grcAttributeTable.Size = new System.Drawing.Size(555, 237);
            this.grcAttributeTable.TabIndex = 0;
            this.grcAttributeTable.UseEmbeddedNavigator = true;
            this.grcAttributeTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAttributeTable});
            // 
            // grvAttributeTable
            // 
            this.grvAttributeTable.GridControl = this.grcAttributeTable;
            this.grvAttributeTable.Name = "grvAttributeTable";
            this.grvAttributeTable.OptionsSelection.MultiSelect = true;
            this.grvAttributeTable.OptionsView.ColumnAutoWidth = false;
            this.grvAttributeTable.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvAttributeTable_RowClick);
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
            this.barSubItem1,
            this.bbiThem,
            this.bbiXoa,
            this.bbiLuu,
            this.bbiStartEdit,
            this.bbiStopEdit,
            this.bbiRefresh,
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(335, 158);
            this.bar1.FloatSize = new System.Drawing.Size(254, 39);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLuu),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh, true)});
            this.bar1.Text = "Tools";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Cập nhật";
            this.barSubItem1.Glyph = global::com.g1.arcgis.tn.query.Properties.Resources._2_24;
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStartEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiStopEdit)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bbiStartEdit
            // 
            this.bbiStartEdit.Caption = "Bắt đầu";
            this.bbiStartEdit.Id = 4;
            this.bbiStartEdit.Name = "bbiStartEdit";
            this.bbiStartEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStartEdit_ItemClick);
            // 
            // bbiStopEdit
            // 
            this.bbiStopEdit.Caption = "Kết thúc";
            this.bbiStopEdit.Id = 5;
            this.bbiStopEdit.Name = "bbiStopEdit";
            this.bbiStopEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStopEdit_ItemClick);
            // 
            // bbiThem
            // 
            this.bbiThem.Caption = "Thêm";
            this.bbiThem.Glyph = global::com.g1.arcgis.tn.query.Properties.Resources._112_24;
            this.bbiThem.Id = 1;
            this.bbiThem.Name = "bbiThem";
            this.bbiThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiThem_ItemClick);
            // 
            // bbiXoa
            // 
            this.bbiXoa.Caption = "Xóa";
            this.bbiXoa.Glyph = global::com.g1.arcgis.tn.query.Properties.Resources._118_24;
            this.bbiXoa.Id = 2;
            this.bbiXoa.Name = "bbiXoa";
            this.bbiXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiXoa_ItemClick);
            // 
            // bbiLuu
            // 
            this.bbiLuu.Caption = "Lưu";
            this.bbiLuu.Glyph = global::com.g1.arcgis.tn.query.Properties.Resources._7_24;
            this.bbiLuu.Id = 3;
            this.bbiLuu.Name = "bbiLuu";
            this.bbiLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLuu_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiRefresh.Caption = "Tải lại";
            this.bbiRefresh.Glyph = global::com.g1.arcgis.tn.query.Properties.Resources.refresh_24;
            this.bbiRefresh.Id = 6;
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(319, 176);
            this.bar2.FloatSize = new System.Drawing.Size(46, 29);
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
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
            this.barDockControlTop.Size = new System.Drawing.Size(555, 61);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 298);
            this.barDockControlBottom.Size = new System.Drawing.Size(555, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 61);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 237);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(555, 61);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 237);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // GTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcAttributeTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "GTableView";
            this.Size = new System.Drawing.Size(555, 321);
            ((System.ComponentModel.ISupportInitialize)(this.grcAttributeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAttributeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraGrid.GridControl grcAttributeTable;
        public DevExpress.XtraGrid.Views.Grid.GridView grvAttributeTable;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem bbiStartEdit;
        private DevExpress.XtraBars.BarButtonItem bbiStopEdit;
        private DevExpress.XtraBars.BarButtonItem bbiThem;
        private DevExpress.XtraBars.BarButtonItem bbiXoa;
        private DevExpress.XtraBars.BarButtonItem bbiLuu;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
