namespace com.g1.arcgis.tn.calculation.algorithm
{
    partial class AlgorithmPage
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tính giá");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tìm thửa, xét từng thửa", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Xét từng đường băng qua xã", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Lưu giá đất");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lưu cách tính giá");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Xét từng xã", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.navThemThuatToan = new DevExpress.XtraNavBar.NavBarControl();
            this.ngrTimDuong = new DevExpress.XtraNavBar.NavBarGroup();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.rbxThuaToanApDung = new System.Windows.Forms.RichTextBox();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnMacDinh = new DevExpress.XtraEditors.SimpleButton();
            this.bntHelp = new DevExpress.XtraEditors.SimpleButton();
            this.lbxThuatToanCucBo = new DevExpress.XtraEditors.ListBoxControl();
            this.ngrTimKtvhxh = new DevExpress.XtraNavBar.NavBarGroup();
            this.ngrTimThua = new DevExpress.XtraNavBar.NavBarGroup();
            this.ngrCongThuc = new DevExpress.XtraNavBar.NavBarGroup();
            this.nitTimDuongGt = new DevExpress.XtraNavBar.NavBarItem();
            this.nitTimHemChinh = new DevExpress.XtraNavBar.NavBarItem();
            this.nitTimHemPhu = new DevExpress.XtraNavBar.NavBarItem();
            this.trvKhungThuatToan = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navThemThuatToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxThuatToanCucBo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.trvKhungThuatToan);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(141, 251);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Khung thuật toán";
            // 
            // navThemThuatToan
            // 
            this.navThemThuatToan.ActiveGroup = this.ngrTimDuong;
            this.navThemThuatToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navThemThuatToan.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.ngrTimDuong,
            this.ngrTimKtvhxh,
            this.ngrTimThua,
            this.ngrCongThuc});
            this.navThemThuatToan.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nitTimDuongGt,
            this.nitTimHemChinh,
            this.nitTimHemPhu});
            this.navThemThuatToan.Location = new System.Drawing.Point(2, 22);
            this.navThemThuatToan.Name = "navThemThuatToan";
            this.navThemThuatToan.OptionsNavPane.ExpandedWidth = 171;
            this.navThemThuatToan.Size = new System.Drawing.Size(196, 227);
            this.navThemThuatToan.TabIndex = 1;
            this.navThemThuatToan.Text = "navBarControl1";
            // 
            // ngrTimDuong
            // 
            this.ngrTimDuong.Caption = "Thuật toán tìm đường";
            this.ngrTimDuong.Expanded = true;
            this.ngrTimDuong.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nitTimDuongGt),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nitTimHemChinh),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nitTimHemPhu)});
            this.ngrTimDuong.Name = "ngrTimDuong";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.rbxThuaToanApDung);
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 256);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(666, 161);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Thuật toán áp dụng";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.bntHelp);
            this.panelControl1.Controls.Add(this.btnMacDinh);
            this.panelControl1.Controls.Add(this.btnHuy);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 126);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(662, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 251);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(666, 5);
            this.splitterControl1.TabIndex = 3;
            this.splitterControl1.TabStop = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(141, 0);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 251);
            this.splitterControl2.TabIndex = 4;
            this.splitterControl2.TabStop = false;
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl3.Location = new System.Drawing.Point(461, 0);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(5, 251);
            this.splitterControl3.TabIndex = 5;
            this.splitterControl3.TabStop = false;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lbxThuatToanCucBo);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(146, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(315, 251);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Tùy chỉnh thuật toán cục bộ";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.navThemThuatToan);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl4.Location = new System.Drawing.Point(466, 0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(200, 251);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "Thêm thuật toán";
            // 
            // rbxThuaToanApDung
            // 
            this.rbxThuaToanApDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbxThuaToanApDung.Location = new System.Drawing.Point(2, 22);
            this.rbxThuaToanApDung.Name = "rbxThuaToanApDung";
            this.rbxThuaToanApDung.Size = new System.Drawing.Size(662, 104);
            this.rbxThuaToanApDung.TabIndex = 1;
            this.rbxThuaToanApDung.Text = "";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(582, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 28);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(501, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 28);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            // 
            // btnMacDinh
            // 
            this.btnMacDinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMacDinh.Location = new System.Drawing.Point(420, 3);
            this.btnMacDinh.Name = "btnMacDinh";
            this.btnMacDinh.Size = new System.Drawing.Size(75, 28);
            this.btnMacDinh.TabIndex = 0;
            this.btnMacDinh.Text = "Mặc định";
            // 
            // bntHelp
            // 
            this.bntHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntHelp.Location = new System.Drawing.Point(5, 3);
            this.bntHelp.Name = "bntHelp";
            this.bntHelp.Size = new System.Drawing.Size(75, 28);
            this.bntHelp.TabIndex = 0;
            this.bntHelp.Text = "Trợ giúp";
            // 
            // lbxThuatToanCucBo
            // 
            this.lbxThuatToanCucBo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxThuatToanCucBo.Location = new System.Drawing.Point(2, 22);
            this.lbxThuatToanCucBo.Name = "lbxThuatToanCucBo";
            this.lbxThuatToanCucBo.Size = new System.Drawing.Size(311, 227);
            this.lbxThuatToanCucBo.TabIndex = 0;
            // 
            // ngrTimKtvhxh
            // 
            this.ngrTimKtvhxh.Caption = "Thuật toán tìm điểm Ktvhxh";
            this.ngrTimKtvhxh.Expanded = true;
            this.ngrTimKtvhxh.Name = "ngrTimKtvhxh";
            // 
            // ngrTimThua
            // 
            this.ngrTimThua.Caption = "Thuật toán tìm thửa";
            this.ngrTimThua.Expanded = true;
            this.ngrTimThua.Name = "ngrTimThua";
            // 
            // ngrCongThuc
            // 
            this.ngrCongThuc.Caption = "Công thức tính giá";
            this.ngrCongThuc.Name = "ngrCongThuc";
            // 
            // nitTimDuongGt
            // 
            this.nitTimDuongGt.Caption = "Tìm đường giao thông";
            this.nitTimDuongGt.Name = "nitTimDuongGt";
            // 
            // nitTimHemChinh
            // 
            this.nitTimHemChinh.Caption = "Tìm hẻm chính";
            this.nitTimHemChinh.Name = "nitTimHemChinh";
            // 
            // nitTimHemPhu
            // 
            this.nitTimHemPhu.Caption = "Tìm hẻm phụ";
            this.nitTimHemPhu.Name = "nitTimHemPhu";
            // 
            // trvKhungThuatToan
            // 
            this.trvKhungThuatToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvKhungThuatToan.Location = new System.Drawing.Point(2, 22);
            this.trvKhungThuatToan.Name = "trvKhungThuatToan";
            treeNode1.Name = "nodTinhGia";
            treeNode1.Text = "Tính giá";
            treeNode2.Name = "nodXetThua";
            treeNode2.Text = "Tìm thửa, xét từng thửa";
            treeNode3.Name = "nodXetDuong";
            treeNode3.Text = "Xét từng đường băng qua xã";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Lưu giá đất";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Lưu cách tính giá";
            treeNode6.Name = "nodXetXa";
            treeNode6.Text = "Xét từng xã";
            this.trvKhungThuatToan.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.trvKhungThuatToan.Size = new System.Drawing.Size(137, 227);
            this.trvKhungThuatToan.TabIndex = 2;
            // 
            // AlgorithmPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.splitterControl3);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl2);
            this.Name = "AlgorithmPage";
            this.Size = new System.Drawing.Size(666, 417);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navThemThuatToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxThuatToanCucBo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraNavBar.NavBarControl navThemThuatToan;
        private DevExpress.XtraNavBar.NavBarGroup ngrTimDuong;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.RichTextBox rbxThuaToanApDung;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.SimpleButton bntHelp;
        private DevExpress.XtraEditors.SimpleButton btnMacDinh;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.ListBoxControl lbxThuatToanCucBo;
        private DevExpress.XtraNavBar.NavBarGroup ngrTimKtvhxh;
        private DevExpress.XtraNavBar.NavBarGroup ngrTimThua;
        private DevExpress.XtraNavBar.NavBarGroup ngrCongThuc;
        private DevExpress.XtraNavBar.NavBarItem nitTimDuongGt;
        private DevExpress.XtraNavBar.NavBarItem nitTimHemChinh;
        private DevExpress.XtraNavBar.NavBarItem nitTimHemPhu;
        public System.Windows.Forms.TreeView trvKhungThuatToan;
    }
}
