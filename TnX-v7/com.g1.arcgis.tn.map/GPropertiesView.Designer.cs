namespace com.g1.arcgis.tn.map
{
    partial class GPropertiesView
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLayer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.clrColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spnSize = new DevExpress.XtraEditors.SpinEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.chkIShow = new DevExpress.XtraEditors.CheckEdit();
            this.cbxField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnTry = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clrColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIShow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên lớp:";
            // 
            // txtLayer
            // 
            this.txtLayer.Location = new System.Drawing.Point(106, 41);
            this.txtLayer.Name = "txtLayer";
            this.txtLayer.Properties.ReadOnly = true;
            this.txtLayer.Size = new System.Drawing.Size(189, 20);
            this.txtLayer.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Cột hiển thị nhãn:";
            // 
            // clrColor
            // 
            this.clrColor.EditValue = System.Drawing.Color.Empty;
            this.clrColor.Location = new System.Drawing.Point(106, 106);
            this.clrColor.Name = "clrColor";
            this.clrColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clrColor.Size = new System.Drawing.Size(100, 20);
            this.clrColor.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 109);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Màu chữ:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Cỡ chữ:";
            // 
            // spnSize
            // 
            this.spnSize.EditValue = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.spnSize.Location = new System.Drawing.Point(106, 141);
            this.spnSize.Name = "spnSize";
            this.spnSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnSize.Properties.Mask.EditMask = "0 px";
            this.spnSize.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.spnSize.Size = new System.Drawing.Size(67, 20);
            this.spnSize.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(221, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(120, 17);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Chấp nhận";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(321, 239);
            this.xtraTabControl1.TabIndex = 10;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.chkIShow);
            this.xtraTabPage1.Controls.Add(this.cbxField);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtLayer);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.spnSize);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.clrColor);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(315, 212);
            this.xtraTabPage1.Text = "Hiển thị nhãn";
            // 
            // chkIShow
            // 
            this.chkIShow.Location = new System.Drawing.Point(12, 11);
            this.chkIShow.Name = "chkIShow";
            this.chkIShow.Properties.Caption = "Hiển thị";
            this.chkIShow.Size = new System.Drawing.Size(75, 19);
            this.chkIShow.TabIndex = 9;
            // 
            // cbxField
            // 
            this.cbxField.Location = new System.Drawing.Point(106, 74);
            this.cbxField.Name = "cbxField";
            this.cbxField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxField.Size = new System.Drawing.Size(189, 20);
            this.cbxField.TabIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnTry);
            this.panelControl1.Controls.Add(this.btnOk);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 239);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(321, 57);
            this.panelControl1.TabIndex = 11;
            // 
            // btnTry
            // 
            this.btnTry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTry.Location = new System.Drawing.Point(24, 17);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(75, 28);
            this.btnTry.TabIndex = 9;
            this.btnTry.Text = "Gán thử";
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);
            // 
            // GPropertiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 296);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "GPropertiesView";
            this.ShowIcon = false;
            this.Text = "Tùy chỉnh lớp bản đồ";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.txtLayer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clrColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIShow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLayer;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ColorEdit clrColor;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spnSize;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnTry;
        private DevExpress.XtraEditors.ComboBoxEdit cbxField;
        private DevExpress.XtraEditors.CheckEdit chkIShow;
    }
}