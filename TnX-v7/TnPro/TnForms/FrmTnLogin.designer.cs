namespace TNPro.TnForms
{
    partial class FrmTnLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTnLogin));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.bgwLogin = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadUsers = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadParams = new System.ComponentModel.BackgroundWorker();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelControl1.Location = new System.Drawing.Point(26, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên đăng nhập:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelControl2.Location = new System.Drawing.Point(26, 105);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mật khẩu:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "Admin";
            this.textEdit1.Location = new System.Drawing.Point(150, 58);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Size = new System.Drawing.Size(176, 21);
            this.textEdit1.TabIndex = 1;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "123";
            this.textEdit2.Location = new System.Drawing.Point(150, 103);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.textEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(176, 21);
            this.textEdit2.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::TNPro.Properties.Resources.login_24;
            this.simpleButton1.Location = new System.Drawing.Point(149, 147);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 27);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Đăng nhập";
            this.simpleButton1.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::TNPro.Properties.Resources.close_24;
            this.btnExit.Location = new System.Drawing.Point(241, 147);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 27);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(24, 155);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.AliceBlue;
            this.checkEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit1.Properties.Caption = "Nhớ mật khẩu";
            this.checkEdit1.Size = new System.Drawing.Size(100, 19);
            this.checkEdit1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Technic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Location = new System.Drawing.Point(480, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 17);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bgwLogin
            // 
            this.bgwLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLogin_DoWork);
            // 
            // bgwLoadUsers
            // 
            this.bgwLoadUsers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadUsers_DoWork);
            this.bgwLoadUsers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadUsers_RunWorkerCompleted);
            // 
            // bgwLoadParams
            // 
            this.bgwLoadParams.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadParams_DoWork);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(241, 194);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // FrmTnLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::TNPro.Properties.Resources.login2_500_375;
            this.ClientSize = new System.Drawing.Size(500, 375);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTnLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.ComponentModel.BackgroundWorker bgwLogin;
        private System.ComponentModel.BackgroundWorker bgwLoadUsers;
        private System.ComponentModel.BackgroundWorker bgwLoadParams;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}