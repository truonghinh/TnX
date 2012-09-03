namespace com.g1.arcgis.tn.calculation
{
    partial class GCalculationHemView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Hẻm chính sâu dưới 100m");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Hẻm chính sâu từ 100-200m");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Hẻm chính sâu trên 200m");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Hẻm phụ sâu dưới 100m");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Hẻm phụ sâu từ 100-200m");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Hẻm phụ sâu trên 200m");
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
            this.groupControl4.Text = "Chọn loại hẻm";
            // 
            // tvcLoaiThua
            // 
            this.tvcLoaiThua.CheckBoxes = true;
            this.tvcLoaiThua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvcLoaiThua.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvcLoaiThua.Location = new System.Drawing.Point(2, 22);
            this.tvcLoaiThua.Name = "tvcLoaiThua";
            treeNode1.Name = "nHemDuoi100";
            treeNode1.Tag = "101";
            treeNode1.Text = "Hẻm chính sâu dưới 100m";
            treeNode2.Name = "nHem100_200";
            treeNode2.Tag = "102";
            treeNode2.Text = "Hẻm chính sâu từ 100-200m";
            treeNode3.Name = "nHemTren200";
            treeNode3.Tag = "103";
            treeNode3.Text = "Hẻm chính sâu trên 200m";
            treeNode4.Name = "Node1";
            treeNode4.Tag = "104";
            treeNode4.Text = "Hẻm phụ sâu dưới 100m";
            treeNode5.Name = "Node2";
            treeNode5.Tag = "105";
            treeNode5.Text = "Hẻm phụ sâu từ 100-200m";
            treeNode6.Name = "Node3";
            treeNode6.Tag = "106";
            treeNode6.Text = "Hẻm phụ sâu trên 200m";
            this.tvcLoaiThua.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
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
            // GCalculationHemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl3);
            this.Name = "GCalculationHemView";
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
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private TnControlLib.TnTreeViewCheckBox tvcLoaiThua;
    }
}
