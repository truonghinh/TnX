namespace TNPro.Quydinh
{
    partial class FrmThongSoQuyDinh
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
            this.gParamsView1 = new com.g1.arcgis.tn.algorithm.GParamsView();
            this.gTableView1 = new com.g1.arcgis.tn.query.GTableView();
            this.SuspendLayout();
            // 
            // gParamsView1
            // 
            this.gParamsView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gParamsView1.Location = new System.Drawing.Point(297, 53);
            this.gParamsView1.Name = "gParamsView1";
            this.gParamsView1.Size = new System.Drawing.Size(310, 294);
            this.gParamsView1.TabIndex = 0;
            // 
            // gTableView1
            // 
            this.gTableView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTableView1.Location = new System.Drawing.Point(0, 53);
            this.gTableView1.Name = "gTableView1";
            this.gTableView1.Size = new System.Drawing.Size(297, 294);
            this.gTableView1.TabIndex = 2;
            // 
            // FrmThongSoQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 372);
            this.Controls.Add(this.gTableView1);
            this.Controls.Add(this.gParamsView1);
            this.MinimumSize = new System.Drawing.Size(623, 410);
            this.Name = "FrmThongSoQuyDinh";
            this.ShowIcon = false;
            this.Text = "Thông số quy định tính giá";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmThongSoQuyDinh_FormClosing);
            this.Controls.SetChildIndex(this.gParamsView1, 0);
            this.Controls.SetChildIndex(this.gTableView1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private com.g1.arcgis.tn.algorithm.GParamsView gParamsView1;
        private com.g1.arcgis.tn.query.GTableView gTableView1;
    }
}