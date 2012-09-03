namespace TNPro.Quydinh
{
    partial class FrmTnOpenParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTnOpenParams));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spnNam = new DevExpress.XtraEditors.SpinEdit();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.spnNam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(73, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Mở cho năm:";
            // 
            // spnNam
            // 
            this.spnNam.EditValue = new decimal(new int[] {
            2011,
            0,
            0,
            0});
            this.spnNam.Location = new System.Drawing.Point(149, 26);
            this.spnNam.Name = "spnNam";
            this.spnNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnNam.Size = new System.Drawing.Size(58, 20);
            this.spnNam.TabIndex = 8;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(56, 68);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 28);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Mở";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(149, 68);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmTnOpenParams
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(293, 118);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.spnNam);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTnOpenParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mở Các thông số quy định";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.spnNam.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spnNam;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}