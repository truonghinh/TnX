namespace com.g1.arcgis.tn.algorithm
{
    partial class FrmCalcMethodBuilder
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
            this.gCalcMethodBuilderView1 = new com.g1.arcgis.tn.algorithm.GCalcMethodBuilderView();
            this.SuspendLayout();
            // 
            // gCalcMethodBuilderView1
            // 
            this.gCalcMethodBuilderView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCalcMethodBuilderView1.Location = new System.Drawing.Point(0, 0);
            this.gCalcMethodBuilderView1.Name = "gCalcMethodBuilderView1";
            this.gCalcMethodBuilderView1.Size = new System.Drawing.Size(888, 483);
            this.gCalcMethodBuilderView1.TabIndex = 0;
            // 
            // FrmCalcMethodBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 483);
            this.Controls.Add(this.gCalcMethodBuilderView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCalcMethodBuilder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xây dựng thuật toán tính giá";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private GCalcMethodBuilderView gCalcMethodBuilderView1;
    }
}