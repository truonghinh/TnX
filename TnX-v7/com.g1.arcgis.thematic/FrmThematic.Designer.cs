namespace com.g1.arcgis.thematic
{
    partial class FrmThematic
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
            this.thematicView1 = new com.g1.arcgis.thematic.ThematicView();
            this.SuspendLayout();
            // 
            // thematicView1
            // 
            this.thematicView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thematicView1.Location = new System.Drawing.Point(0, 0);
            this.thematicView1.Name = "thematicView1";
            this.thematicView1.Size = new System.Drawing.Size(277, 285);
            this.thematicView1.TabIndex = 0;
            // 
            // FrmThematic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 285);
            this.Controls.Add(this.thematicView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmThematic";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo bản đồ giá đất";
            this.ResumeLayout(false);

        }

        #endregion

        private ThematicView thematicView1;
    }
}