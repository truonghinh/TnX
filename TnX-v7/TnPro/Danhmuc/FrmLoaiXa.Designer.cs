using com.g1.arcgis.tn.query;
namespace TNPro.Danhmuc
{
    partial class FrmLoaiXa
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
            this.tblXa = new com.g1.arcgis.tn.query.GTableView();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnLoaiXa = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tblLoaiXa = new com.g1.arcgis.tn.query.GTableView();
            this.dpnXa = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dpnLoaiXa.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.dpnXa.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tblXa
            // 
            this.tblXa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblXa.Location = new System.Drawing.Point(0, 0);
            this.tblXa.Name = "tblXa";
            this.tblXa.Size = new System.Drawing.Size(294, 303);
            this.tblXa.TabIndex = 0;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnXa,
            this.dpnLoaiXa});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpnLoaiXa
            // 
            this.dpnLoaiXa.Controls.Add(this.controlContainer1);
            this.dpnLoaiXa.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnLoaiXa.ID = new System.Guid("abfa85b2-a360-4354-9eab-3c799d73dfc5");
            this.dpnLoaiXa.Location = new System.Drawing.Point(302, 51);
            this.dpnLoaiXa.Name = "dpnLoaiXa";
            this.dpnLoaiXa.OriginalSize = new System.Drawing.Size(277, 200);
            this.dpnLoaiXa.Size = new System.Drawing.Size(277, 330);
            this.dpnLoaiXa.Text = "Loại xã";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.tblLoaiXa);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(269, 303);
            this.controlContainer1.TabIndex = 0;
            // 
            // tblLoaiXa
            // 
            this.tblLoaiXa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLoaiXa.Location = new System.Drawing.Point(0, 0);
            this.tblLoaiXa.Name = "tblLoaiXa";
            this.tblLoaiXa.Size = new System.Drawing.Size(269, 303);
            this.tblLoaiXa.TabIndex = 0;
            // 
            // dpnXa
            // 
            this.dpnXa.Controls.Add(this.dockPanel1_Container);
            this.dpnXa.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnXa.FloatSize = new System.Drawing.Size(463, 337);
            this.dpnXa.ID = new System.Guid("f5a16943-a78e-48b4-a9be-3538a339e442");
            this.dpnXa.Location = new System.Drawing.Point(0, 51);
            this.dpnXa.Name = "dpnXa";
            this.dpnXa.OriginalSize = new System.Drawing.Size(302, 200);
            this.dpnXa.Size = new System.Drawing.Size(302, 330);
            this.dpnXa.Text = "Ranh giới xã";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tblXa);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(294, 303);
            this.dockPanel1_Container.TabIndex = 0;
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ranh giới xã";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Loại xã";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem3.Caption = "Trợ giúp";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
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
            this.barDockControlTop.Size = new System.Drawing.Size(579, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 381);
            this.barDockControlBottom.Size = new System.Drawing.Size(579, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 330);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(579, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 330);
            // 
            // FrmLoaiXa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 404);
            this.Controls.Add(this.dpnLoaiXa);
            this.Controls.Add(this.dpnXa);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmLoaiXa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLoaiXa";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dpnLoaiXa.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.dpnXa.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GTableView tblXa;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dpnXa;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Docking.DockPanel dpnLoaiXa;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private GTableView tblLoaiXa;


        //private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        //private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        //private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
    }
}