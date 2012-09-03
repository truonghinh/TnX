namespace TNPro.TnForms
{
    partial class FrmTnAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTnAdmin));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.chkUser = new DevExpress.XtraEditors.CheckEdit();
            this.chkAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Controls.Add(this.simpleButton3);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.chkUser);
            this.groupControl1.Controls.Add(this.chkAdmin);
            this.groupControl1.Controls.Add(this.comboBoxEdit1);
            this.groupControl1.Controls.Add(this.textEdit3);
            this.groupControl1.Controls.Add(this.textEdit2);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(383, 217);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin người sử dụng";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Image = global::TNPro.Properties.Resources.close_24;
            this.simpleButton4.Location = new System.Drawing.Point(289, 174);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(86, 25);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "Đóng";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Image = global::TNPro.Properties.Resources.delete_user_24;
            this.simpleButton3.Location = new System.Drawing.Point(197, 174);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(86, 25);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "Xóa";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::TNPro.Properties.Resources.add_user_24;
            this.simpleButton2.Location = new System.Drawing.Point(105, 174);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(86, 25);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Thêm mới";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::TNPro.Properties.Resources._46_24;
            this.simpleButton1.Location = new System.Drawing.Point(13, 174);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 25);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Chỉnh sửa";
            // 
            // chkUser
            // 
            this.chkUser.Location = new System.Drawing.Point(229, 137);
            this.chkUser.Name = "chkUser";
            this.chkUser.Properties.Caption = "Người sử dụng";
            this.chkUser.Size = new System.Drawing.Size(101, 19);
            this.chkUser.TabIndex = 3;
            // 
            // chkAdmin
            // 
            this.chkAdmin.EditValue = true;
            this.chkAdmin.Location = new System.Drawing.Point(112, 137);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Properties.Caption = "Quản trị hệ thống";
            this.chkAdmin.Size = new System.Drawing.Size(111, 19);
            this.chkAdmin.TabIndex = 3;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "Admin";
            this.comboBoxEdit1.Location = new System.Drawing.Point(114, 33);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(257, 20);
            this.comboBoxEdit1.TabIndex = 2;
            // 
            // textEdit3
            // 
            this.textEdit3.EditValue = "123";
            this.textEdit3.Location = new System.Drawing.Point(114, 111);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.PasswordChar = '*';
            this.textEdit3.Size = new System.Drawing.Size(257, 20);
            this.textEdit3.TabIndex = 1;
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "123";
            this.textEdit2.Location = new System.Drawing.Point(114, 85);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(257, 20);
            this.textEdit2.TabIndex = 1;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "Admin";
            this.textEdit1.Location = new System.Drawing.Point(114, 59);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(257, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 114);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(91, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Xác nhận mật khẩu";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên đầy đủ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // FrmTnAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 217);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTnAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkUser;
        private DevExpress.XtraEditors.CheckEdit chkAdmin;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}