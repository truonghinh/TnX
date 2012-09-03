namespace com.g1.arcgis.dataManagement
{
    partial class FrmDeleteLayers
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnTrogiup = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuyet = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.chkbLayers = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblLayersCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkbLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblLayersCount);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnTrogiup);
            this.panelControl1.Controls.Add(this.btnDuyet);
            this.panelControl1.Controls.Add(this.btnThem);
            this.panelControl1.Controls.Add(this.btnDong);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 232);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(489, 44);
            this.panelControl1.TabIndex = 0;
            // 
            // btnTrogiup
            // 
            this.btnTrogiup.Location = new System.Drawing.Point(12, 9);
            this.btnTrogiup.Name = "btnTrogiup";
            this.btnTrogiup.Size = new System.Drawing.Size(75, 23);
            this.btnTrogiup.TabIndex = 1;
            this.btnTrogiup.Text = "Trợ giúp";
            // 
            // btnDuyet
            // 
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.Location = new System.Drawing.Point(207, 9);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(75, 23);
            this.btnDuyet.TabIndex = 0;
            this.btnDuyet.Text = "...";
            this.btnDuyet.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(288, 9);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Xóa";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(402, 9);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            // 
            // chkbLayers
            // 
            this.chkbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbLayers.Location = new System.Drawing.Point(2, 22);
            this.chkbLayers.Name = "chkbLayers";
            this.chkbLayers.Size = new System.Drawing.Size(485, 208);
            this.chkbLayers.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkbLayers);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(489, 232);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "SDE:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(104, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Số lượng:";
            // 
            // lblLayersCount
            // 
            this.lblLayersCount.Location = new System.Drawing.Point(156, 14);
            this.lblLayersCount.Name = "lblLayersCount";
            this.lblLayersCount.Size = new System.Drawing.Size(4, 13);
            this.lblLayersCount.TabIndex = 3;
            this.lblLayersCount.Text = ".";
            // 
            // FrmDeleteLayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 276);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(505, 314);
            this.Name = "FrmDeleteLayers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Xóa lớp dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkbLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkbLayers;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnTrogiup;
        private DevExpress.XtraEditors.SimpleButton btnDuyet;
        private DevExpress.XtraEditors.LabelControl lblLayersCount;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}