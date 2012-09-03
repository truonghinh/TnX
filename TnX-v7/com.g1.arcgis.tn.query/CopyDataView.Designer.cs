namespace com.g1.arcgis.tn.query
{
    partial class CopyDataView
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbxFromYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spnToYear = new DevExpress.XtraEditors.SpinEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbxFromYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnToYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ năm:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(149, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Sang năm:";
            // 
            // cbxFromYear
            // 
            this.cbxFromYear.Location = new System.Drawing.Point(49, 21);
            this.cbxFromYear.Name = "cbxFromYear";
            this.cbxFromYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxFromYear.Size = new System.Drawing.Size(67, 20);
            this.cbxFromYear.TabIndex = 1;
            // 
            // spnToYear
            // 
            this.spnToYear.EditValue = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            this.spnToYear.Location = new System.Drawing.Point(206, 21);
            this.spnToYear.Name = "spnToYear";
            this.spnToYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnToYear.Size = new System.Drawing.Size(67, 20);
            this.spnToYear.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(162, 61);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(49, 61);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Sao chép";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // CopyDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 94);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.spnToYear);
            this.Controls.Add(this.cbxFromYear);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "CopyDataView";
            this.ShowIcon = false;
            this.Text = "Sao chép bảng giá";
            ((System.ComponentModel.ISupportInitialize)(this.cbxFromYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnToYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbxFromYear;
        private DevExpress.XtraEditors.SpinEdit spnToYear;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
    }
}
