namespace com.g1.arcgis.tn.landprice
{
    partial class FrmLandPriceInfo
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
            this.gLandPriceView1 = new com.g1.arcgis.tn.landprice.GLandPriceView();
            this.SuspendLayout();
            // 
            // gLandPriceView1
            // 
            this.gLandPriceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gLandPriceView1.Location = new System.Drawing.Point(0, 0);
            this.gLandPriceView1.Name = "gLandPriceView1";
            this.gLandPriceView1.Size = new System.Drawing.Size(688, 548);
            this.gLandPriceView1.TabIndex = 0;
            // 
            // FrmLandPriceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 548);
            this.Controls.Add(this.gLandPriceView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLandPriceInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các vùng giá đất tính được";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private GLandPriceView gLandPriceView1;

        //private GLandPriceView gLandPriceView1;
    }
}