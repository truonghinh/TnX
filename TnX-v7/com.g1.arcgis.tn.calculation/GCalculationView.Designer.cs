namespace com.g1.arcgis.tn.calculation
{
    partial class GCalculationView
    {
        #region member
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.CheckEdit chkOverWrite;
        private DevExpress.XtraEditors.SpinEdit spnNam;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.CheckEdit chkCalcAll;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.ComboBoxEdit cbxDoanDuong;
        private DevExpress.XtraEditors.ComboBoxEdit cbxDuong;
        private DevExpress.XtraEditors.ComboBoxEdit cbxXa;
        private DevExpress.XtraEditors.ComboBoxEdit cbxHuyen;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private TnControlLib.TnTreeViewCheckBox tvcLoaiThua;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl3;
        private DevExpress.XtraEditors.SimpleButton btnOptionCalcView;
        private DevExpress.XtraEditors.SimpleButton btnTinhFrmAll;
        private DevExpress.XtraEditors.SimpleButton btnCloseFrmTinhAll;
        //private DevExpress.XtraBars.Docking.ControlContainer controlContainer7;
        //private DevExpress.XtraBars.Docking.DockPanel panelContainer1;

        #endregion
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Vị trí 1 (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Vị trí 1 (thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Vị trí 2 (trường hợp 1, trọn thửa)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Vị trí 2 (trường hợp 1, thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Vị trí 2 (trường hợp 2, trọn thửa)");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Vị trí 2 (trường hợp 2, thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Vị trí 3");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Đất nông nghiệp", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Vị trí 1");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Vị trí 2");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Vị trí 3");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Khu vực 1", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Vị trí 1");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Vị trí 2");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Vị trí 3");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Khu vực 2", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Vị trí 1");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Vị trí 2");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Vị trí 3");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Khu vực 3", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Đất mặt tiền (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Đất mặt tiền (thửa dài hơn 50m)");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Đất mặt tiền (thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Đất sau 50m-100m mặt tiền");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Đất sau 100m mặt tiền");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Đất phi nông nghiệp nông thôn", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode16,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Đất mặt tiền trọn");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Đất mặt tiền của thửa dài hơn 50m");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Đất sau 50m của thửa mặt tiền");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Đất mặt tiền", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Sâu dưới 100m (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Sâu dưới 100m (thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Sâu từ 100m - 200m (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Sâu từ 100m - 200m (thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Sâu từ 100m - 200m (thửa dài hơn 200m)");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Sâu trên 200m (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Sâu trên 200m (thửa dài hơn 200m)");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Tính từ giá hẻm chính");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Hẻm chính", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Sâu dưới 100m (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Sâu từ 100m-200m (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Sâu dưới 100m (thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Sâu từ 100m-200m (thửa dài hơn 100m)");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Sâu từ 100m-200m (thửa dài hơn 200m)");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Sâu trên 200m (trọn thửa)");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Sâu trên 200m (thửa dài hơn 200m)");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Tính từ giá hẻm phụ");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("Hẻm phụ", new System.Windows.Forms.TreeNode[] {
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45,
            treeNode46,
            treeNode47});
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Đất trong hẻm", new System.Windows.Forms.TreeNode[] {
            treeNode39,
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Đất phi nông nghiệp đô thị", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode49});
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Đất phi nông nghiệp", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode50});
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.tvcLoaiThua = new TnControlLib.TnTreeViewCheckBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControl3 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.chkOverWrite = new DevExpress.XtraEditors.CheckEdit();
            this.chkCalcAll = new DevExpress.XtraEditors.CheckEdit();
            this.spnNam = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.cbxHuyen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.cbxXa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.cbxDuong = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxDoanDuong = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnOptionCalcView = new DevExpress.XtraEditors.SimpleButton();
            this.btnTinhFrmAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloseFrmTinhAll = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniOpenStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.xtraScrollableControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkOverWrite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCalcAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxHuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxXa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDoanDuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.groupControl4);
            this.groupControl2.Controls.Add(this.panelControl4);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.MinimumSize = new System.Drawing.Size(350, 247);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(363, 330);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Chọn khu vực tính";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.tvcLoaiThua);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(2, 164);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(359, 164);
            this.groupControl4.TabIndex = 1;
            this.groupControl4.Text = "Chọn loại đất";
            // 
            // tvcLoaiThua
            // 
            this.tvcLoaiThua.CheckBoxes = true;
            this.tvcLoaiThua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvcLoaiThua.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvcLoaiThua.Location = new System.Drawing.Point(2, 22);
            this.tvcLoaiThua.Name = "tvcLoaiThua";
            treeNode1.Name = "nThuaNnVt1";
            treeNode1.Tag = "1";
            treeNode1.Text = "Vị trí 1 (trọn thửa)";
            treeNode2.Name = "nThuaNnVt1_";
            treeNode2.Tag = "2";
            treeNode2.Text = "Vị trí 1 (thửa dài hơn 100m)";
            treeNode3.Name = "nThuaNnVt2Th1";
            treeNode3.Tag = "3";
            treeNode3.Text = "Vị trí 2 (trường hợp 1, trọn thửa)";
            treeNode4.Name = "nThuaNnVt2Th1_";
            treeNode4.Tag = "4";
            treeNode4.Text = "Vị trí 2 (trường hợp 1, thửa dài hơn 100m)";
            treeNode5.Name = "nThuaNnVt2Th2";
            treeNode5.Tag = "5";
            treeNode5.Text = "Vị trí 2 (trường hợp 2, trọn thửa)";
            treeNode6.Name = "nThuaNnVt2Th2_";
            treeNode6.Tag = "6";
            treeNode6.Text = "Vị trí 2 (trường hợp 2, thửa dài hơn 100m)";
            treeNode7.Name = "nThuaNnVt3";
            treeNode7.Tag = "7";
            treeNode7.Text = "Vị trí 3";
            treeNode8.Name = "nThuaNn";
            treeNode8.Tag = "";
            treeNode8.Text = "Đất nông nghiệp";
            treeNode9.Name = "nThuaPnnNtVt1Kv1";
            treeNode9.Tag = "8";
            treeNode9.Text = "Vị trí 1";
            treeNode10.Name = "nThuaPnnNtVt2Kv1";
            treeNode10.Tag = "9";
            treeNode10.Text = "Vị trí 2";
            treeNode11.Name = "nThuaPnnNtVt3Kv1";
            treeNode11.Tag = "10";
            treeNode11.Text = "Vị trí 3";
            treeNode12.Name = "nThuaPnnNtKv1";
            treeNode12.Tag = "";
            treeNode12.Text = "Khu vực 1";
            treeNode13.Name = "nThuaPnnNtVt1Kv2";
            treeNode13.Tag = "11";
            treeNode13.Text = "Vị trí 1";
            treeNode14.Name = "nThuaPnnNtVt2Kv2";
            treeNode14.Tag = "12";
            treeNode14.Text = "Vị trí 2";
            treeNode15.Name = "nThuaPnnNtVt3Kv2";
            treeNode15.Tag = "13";
            treeNode15.Text = "Vị trí 3";
            treeNode16.Name = "nThuaPnnNtKv2";
            treeNode16.Tag = "";
            treeNode16.Text = "Khu vực 2";
            treeNode17.Name = "nThuaPnnNtVt1Kv3";
            treeNode17.Tag = "14";
            treeNode17.Text = "Vị trí 1";
            treeNode18.Name = "nThuaPnnNtVt2Kv3";
            treeNode18.Tag = "15";
            treeNode18.Text = "Vị trí 2";
            treeNode19.Name = "nThuaPnnNtVt3Kv3";
            treeNode19.Tag = "16";
            treeNode19.Text = "Vị trí 3";
            treeNode20.Name = "nThuaPnnNtKv3";
            treeNode20.Tag = "";
            treeNode20.Text = "Khu vực 3";
            treeNode21.Name = "Node1";
            treeNode21.Tag = "17";
            treeNode21.Text = "Đất mặt tiền (trọn thửa)";
            treeNode22.Name = "Node3";
            treeNode22.Tag = "18";
            treeNode22.Text = "Đất mặt tiền (thửa dài hơn 50m)";
            treeNode23.Name = "Node0";
            treeNode23.Tag = "19";
            treeNode23.Text = "Đất mặt tiền (thửa dài hơn 100m)";
            treeNode24.Name = "Node4";
            treeNode24.Tag = "20";
            treeNode24.Text = "Đất sau 50m-100m mặt tiền";
            treeNode25.Name = "Node1";
            treeNode25.Tag = "21";
            treeNode25.Text = "Đất sau 100m mặt tiền";
            treeNode26.Name = "nThuaPnnNt";
            treeNode26.Tag = "";
            treeNode26.Text = "Đất phi nông nghiệp nông thôn";
            treeNode27.Name = "nThuaMatTienTron";
            treeNode27.Tag = "22";
            treeNode27.Text = "Đất mặt tiền trọn";
            treeNode28.Name = "nThuaMatTienMorong";
            treeNode28.Tag = "23";
            treeNode28.Text = "Đất mặt tiền của thửa dài hơn 50m";
            treeNode29.Name = "nThuaMatTienSau50m";
            treeNode29.Tag = "24";
            treeNode29.Text = "Đất sau 50m của thửa mặt tiền";
            treeNode30.Name = "nThuaMatTien";
            treeNode30.Tag = "";
            treeNode30.Text = "Đất mặt tiền";
            treeNode31.Name = "Node0";
            treeNode31.Tag = "25";
            treeNode31.Text = "Sâu dưới 100m (trọn thửa)";
            treeNode32.Name = "Node1";
            treeNode32.Tag = "26";
            treeNode32.Text = "Sâu dưới 100m (thửa dài hơn 100m)";
            treeNode33.Name = "Node0";
            treeNode33.Tag = "27";
            treeNode33.Text = "Sâu từ 100m - 200m (trọn thửa)";
            treeNode34.Name = "Node1";
            treeNode34.Tag = "28";
            treeNode34.Text = "Sâu từ 100m - 200m (thửa dài hơn 100m)";
            treeNode35.Name = "Node2";
            treeNode35.Tag = "29";
            treeNode35.Text = "Sâu từ 100m - 200m (thửa dài hơn 200m)";
            treeNode36.Name = "Node2";
            treeNode36.Tag = "30";
            treeNode36.Text = "Sâu trên 200m (trọn thửa)";
            treeNode37.Name = "Node3";
            treeNode37.Tag = "31";
            treeNode37.Text = "Sâu trên 200m (thửa dài hơn 200m)";
            treeNode38.Name = "Node0";
            treeNode38.Tag = "110";
            treeNode38.Text = "Tính từ giá hẻm chính";
            treeNode39.Name = "nThuaHemChinh";
            treeNode39.Tag = "";
            treeNode39.Text = "Hẻm chính";
            treeNode40.Name = "Node3";
            treeNode40.Tag = "32";
            treeNode40.Text = "Sâu dưới 100m (trọn thửa)";
            treeNode41.Name = "Node4";
            treeNode41.Tag = "33";
            treeNode41.Text = "Sâu từ 100m-200m (trọn thửa)";
            treeNode42.Name = "Node5";
            treeNode42.Tag = "34";
            treeNode42.Text = "Sâu dưới 100m (thửa dài hơn 100m)";
            treeNode43.Name = "Node6";
            treeNode43.Tag = "35";
            treeNode43.Text = "Sâu từ 100m-200m (thửa dài hơn 100m)";
            treeNode44.Name = "Node7";
            treeNode44.Tag = "36";
            treeNode44.Text = "Sâu từ 100m-200m (thửa dài hơn 200m)";
            treeNode45.Name = "Node8";
            treeNode45.Tag = "37";
            treeNode45.Text = "Sâu trên 200m (trọn thửa)";
            treeNode46.Name = "Node9";
            treeNode46.Tag = "38";
            treeNode46.Text = "Sâu trên 200m (thửa dài hơn 200m)";
            treeNode47.Name = "Node0";
            treeNode47.Tag = "111";
            treeNode47.Text = "Tính từ giá hẻm phụ";
            treeNode48.Name = "nThuaHemPhu";
            treeNode48.Tag = "";
            treeNode48.Text = "Hẻm phụ";
            treeNode49.Name = "nThuaHem";
            treeNode49.Tag = "";
            treeNode49.Text = "Đất trong hẻm";
            treeNode50.Name = "nThuaPnnDt";
            treeNode50.Tag = "";
            treeNode50.Text = "Đất phi nông nghiệp đô thị";
            treeNode51.Name = "nThuaPnn";
            treeNode51.Tag = "";
            treeNode51.Text = "Đất phi nông nghiệp";
            this.tvcLoaiThua.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode51});
            this.tvcLoaiThua.Size = new System.Drawing.Size(355, 140);
            this.tvcLoaiThua.TabIndex = 1;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.xtraScrollableControl3);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 22);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(359, 142);
            this.panelControl4.TabIndex = 0;
            // 
            // xtraScrollableControl3
            // 
            this.xtraScrollableControl3.Controls.Add(this.chkOverWrite);
            this.xtraScrollableControl3.Controls.Add(this.chkCalcAll);
            this.xtraScrollableControl3.Controls.Add(this.spnNam);
            this.xtraScrollableControl3.Controls.Add(this.labelControl21);
            this.xtraScrollableControl3.Controls.Add(this.labelControl17);
            this.xtraScrollableControl3.Controls.Add(this.labelControl20);
            this.xtraScrollableControl3.Controls.Add(this.cbxHuyen);
            this.xtraScrollableControl3.Controls.Add(this.labelControl18);
            this.xtraScrollableControl3.Controls.Add(this.cbxXa);
            this.xtraScrollableControl3.Controls.Add(this.labelControl19);
            this.xtraScrollableControl3.Controls.Add(this.cbxDuong);
            this.xtraScrollableControl3.Controls.Add(this.cbxDoanDuong);
            this.xtraScrollableControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl3.Location = new System.Drawing.Point(2, 2);
            this.xtraScrollableControl3.Name = "xtraScrollableControl3";
            this.xtraScrollableControl3.Size = new System.Drawing.Size(355, 138);
            this.xtraScrollableControl3.TabIndex = 18;
            // 
            // chkOverWrite
            // 
            this.chkOverWrite.EditValue = true;
            this.chkOverWrite.Location = new System.Drawing.Point(138, 3);
            this.chkOverWrite.Name = "chkOverWrite";
            this.chkOverWrite.Properties.Caption = "Cập nhật thông tin";
            this.chkOverWrite.Size = new System.Drawing.Size(120, 19);
            this.chkOverWrite.TabIndex = 17;
            this.chkOverWrite.Visible = false;
            // 
            // chkCalcAll
            // 
            this.chkCalcAll.Location = new System.Drawing.Point(1, 3);
            this.chkCalcAll.Name = "chkCalcAll";
            this.chkCalcAll.Properties.Caption = "Tính cho toàn bộ thửa";
            this.chkCalcAll.Size = new System.Drawing.Size(131, 19);
            this.chkCalcAll.TabIndex = 6;
            this.chkCalcAll.Visible = false;
            // 
            // spnNam
            // 
            this.spnNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spnNam.EditValue = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            this.spnNam.Enabled = false;
            this.spnNam.Location = new System.Drawing.Point(298, 3);
            this.spnNam.Name = "spnNam";
            this.spnNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnNam.Size = new System.Drawing.Size(50, 20);
            this.spnNam.TabIndex = 16;
            this.spnNam.Visible = false;
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(7, 83);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(79, 13);
            this.labelControl21.TabIndex = 14;
            this.labelControl21.Text = "Tính theo đường";
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl17.Location = new System.Drawing.Point(271, 6);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(21, 13);
            this.labelControl17.TabIndex = 15;
            this.labelControl17.Text = "Năm";
            this.labelControl17.Visible = false;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(7, 109);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(106, 13);
            this.labelControl20.TabIndex = 11;
            this.labelControl20.Text = "Tính theo đoạn đường";
            // 
            // cbxHuyen
            // 
            this.cbxHuyen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxHuyen.EditValue = "TX Tây Ninh";
            this.cbxHuyen.Location = new System.Drawing.Point(119, 28);
            this.cbxHuyen.Name = "cbxHuyen";
            this.cbxHuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxHuyen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxHuyen.Size = new System.Drawing.Size(229, 20);
            this.cbxHuyen.TabIndex = 10;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(7, 57);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(60, 13);
            this.labelControl18.TabIndex = 13;
            this.labelControl18.Text = "Tính theo xã";
            // 
            // cbxXa
            // 
            this.cbxXa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxXa.Location = new System.Drawing.Point(119, 54);
            this.cbxXa.Name = "cbxXa";
            this.cbxXa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxXa.Size = new System.Drawing.Size(229, 20);
            this.cbxXa.TabIndex = 9;
            this.cbxXa.SelectedIndexChanged += new System.EventHandler(this.cbxXa_SelectedIndexChanged);
            this.cbxXa.Click += new System.EventHandler(this.cbxXa_Click);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(7, 31);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(78, 13);
            this.labelControl19.TabIndex = 12;
            this.labelControl19.Text = "Tính theo huyện";
            // 
            // cbxDuong
            // 
            this.cbxDuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDuong.Location = new System.Drawing.Point(119, 80);
            this.cbxDuong.Name = "cbxDuong";
            this.cbxDuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxDuong.Size = new System.Drawing.Size(229, 20);
            this.cbxDuong.TabIndex = 7;
            this.cbxDuong.SelectedIndexChanged += new System.EventHandler(this.cbxDuong_SelectedIndexChanged);
            this.cbxDuong.Click += new System.EventHandler(this.cbxDuong_Click);
            // 
            // cbxDoanDuong
            // 
            this.cbxDoanDuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDoanDuong.Location = new System.Drawing.Point(119, 106);
            this.cbxDoanDuong.Name = "cbxDoanDuong";
            this.cbxDoanDuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxDoanDuong.Size = new System.Drawing.Size(229, 20);
            this.cbxDoanDuong.TabIndex = 8;
            this.cbxDoanDuong.SelectedIndexChanged += new System.EventHandler(this.cbxDoanDuong_SelectedIndexChanged);
            this.cbxDoanDuong.Click += new System.EventHandler(this.cbxDoanDuong_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnOptionCalcView);
            this.panelControl3.Controls.Add(this.btnTinhFrmAll);
            this.panelControl3.Controls.Add(this.btnCloseFrmTinhAll);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 330);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(363, 35);
            this.panelControl3.TabIndex = 0;
            // 
            // btnOptionCalcView
            // 
            this.btnOptionCalcView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptionCalcView.Location = new System.Drawing.Point(8, 4);
            this.btnOptionCalcView.Name = "btnOptionCalcView";
            this.btnOptionCalcView.Size = new System.Drawing.Size(75, 28);
            this.btnOptionCalcView.TabIndex = 0;
            this.btnOptionCalcView.Text = "Trợ giúp";
            this.btnOptionCalcView.Click += new System.EventHandler(this.btnOptionCalcView_Click);
            // 
            // btnTinhFrmAll
            // 
            this.btnTinhFrmAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhFrmAll.Location = new System.Drawing.Point(196, 4);
            this.btnTinhFrmAll.Name = "btnTinhFrmAll";
            this.btnTinhFrmAll.Size = new System.Drawing.Size(75, 28);
            this.btnTinhFrmAll.TabIndex = 0;
            this.btnTinhFrmAll.Text = "Tính";
            this.btnTinhFrmAll.Click += new System.EventHandler(this.btnTinhFrmAll_Click);
            // 
            // btnCloseFrmTinhAll
            // 
            this.btnCloseFrmTinhAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseFrmTinhAll.Location = new System.Drawing.Point(277, 4);
            this.btnCloseFrmTinhAll.Name = "btnCloseFrmTinhAll";
            this.btnCloseFrmTinhAll.Size = new System.Drawing.Size(75, 28);
            this.btnCloseFrmTinhAll.TabIndex = 0;
            this.btnCloseFrmTinhAll.Text = "Đóng";
            this.btnCloseFrmTinhAll.Click += new System.EventHandler(this.btnCloseFrmTinhAll_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOpenStatus,
            this.mniHelp});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 48);
            // 
            // mniOpenStatus
            // 
            this.mniOpenStatus.Name = "mniOpenStatus";
            this.mniOpenStatus.Size = new System.Drawing.Size(192, 22);
            this.mniOpenStatus.Text = "Mở trạng thái vừa tính";
            this.mniOpenStatus.Click += new System.EventHandler(this.mniOpenStatus_Click);
            // 
            // mniHelp
            // 
            this.mniHelp.Name = "mniHelp";
            this.mniHelp.Size = new System.Drawing.Size(192, 22);
            this.mniHelp.Text = "Trợ giúp";
            // 
            // GCalculationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl3);
            this.Name = "GCalculationView";
            this.Size = new System.Drawing.Size(363, 365);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.xtraScrollableControl3.ResumeLayout(false);
            this.xtraScrollableControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkOverWrite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCalcAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxHuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxXa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDoanDuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniOpenStatus;
        private System.Windows.Forms.ToolStripMenuItem mniHelp;
    }
}
