namespace com.g1.arcgis.tn.query
{
    partial class FrmAttribute
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
            this.gTableView1 = new com.g1.arcgis.tn.query.GTableView();
            this.SuspendLayout();
            // 
            // gTableView1
            // 
            this.gTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTableView1.Location = new System.Drawing.Point(0, 0);
            this.gTableView1.Name = "gTableView1";
            this.gTableView1.Size = new System.Drawing.Size(411, 299);
            this.gTableView1.TabIndex = 0;
            // 
            // FrmAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 299);
            this.Controls.Add(this.gTableView1);
            this.Name = "FrmAttribute";
            this.Text = "Bảng thuộc tính";
            this.ResumeLayout(false);

        }

        #endregion

        private GTableView gTableView1;

    }
}