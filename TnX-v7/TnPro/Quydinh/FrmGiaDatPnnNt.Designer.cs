namespace TNPro.Quydinh
{
    partial class FrmGiaDatPnnNt
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
            this.gTableViewAllowCopy1 = new com.g1.arcgis.tn.query.GTableViewAllowCopy();
            this.SuspendLayout();
            // 
            // gTableViewAllowCopy1
            // 
            this.gTableViewAllowCopy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTableViewAllowCopy1.Location = new System.Drawing.Point(0, 0);
            this.gTableViewAllowCopy1.Name = "gTableViewAllowCopy1";
            this.gTableViewAllowCopy1.Size = new System.Drawing.Size(517, 407);
            this.gTableViewAllowCopy1.TabIndex = 0;
            // 
            // FrmGiaDatPnnNt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 407);
            this.Controls.Add(this.gTableViewAllowCopy1);
            this.Name = "FrmGiaDatPnnNt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giá đất ở tại nông thôn";
            this.ResumeLayout(false);

        }

        #endregion

        private com.g1.arcgis.tn.query.GTableViewAllowCopy gTableViewAllowCopy1;
    }
}