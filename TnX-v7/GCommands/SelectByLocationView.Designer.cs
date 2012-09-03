namespace GCommands
{
    partial class SelectByLocationView
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
            this.cbxResultType = new System.Windows.Forms.ComboBox();
            this.lstInputLayer = new System.Windows.Forms.CheckedListBox();
            this.cbxMethod = new System.Windows.Forms.ComboBox();
            this.cbxSelectLayer = new System.Windows.Forms.ComboBox();
            this.txtBuffer = new System.Windows.Forms.TextBox();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkUseSelected = new System.Windows.Forms.CheckBox();
            this.chkApplyBuffer = new System.Windows.Forms.CheckBox();
            this.lblSelectLayer = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSelectedFeture = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxResultType
            // 
            this.cbxResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResultType.FormattingEnabled = true;
            this.cbxResultType.Items.AddRange(new object[] {
            "Chọn mới (New)",
            "Chọn thêm (Add)",
            "Loại bỏ (Subtract)",
            "Chọn từ (And)",
            "Chọn thêm có loại trừ (Xor)"});
            this.cbxResultType.Location = new System.Drawing.Point(12, 34);
            this.cbxResultType.Name = "cbxResultType";
            this.cbxResultType.Size = new System.Drawing.Size(362, 21);
            this.cbxResultType.TabIndex = 0;
            // 
            // lstInputLayer
            // 
            this.lstInputLayer.FormattingEnabled = true;
            this.lstInputLayer.Location = new System.Drawing.Point(12, 75);
            this.lstInputLayer.Name = "lstInputLayer";
            this.lstInputLayer.Size = new System.Drawing.Size(362, 94);
            this.lstInputLayer.TabIndex = 1;
            // 
            // cbxMethod
            // 
            this.cbxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMethod.FormattingEnabled = true;
            this.cbxMethod.Items.AddRange(new object[] {
            "Giao nhau (Intersects)",
            "Nằm trong (Withins)",
            "Chứa đựng (Contains)"});
            this.cbxMethod.Location = new System.Drawing.Point(11, 191);
            this.cbxMethod.Name = "cbxMethod";
            this.cbxMethod.Size = new System.Drawing.Size(363, 21);
            this.cbxMethod.TabIndex = 2;
            // 
            // cbxSelectLayer
            // 
            this.cbxSelectLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectLayer.FormattingEnabled = true;
            this.cbxSelectLayer.Location = new System.Drawing.Point(11, 231);
            this.cbxSelectLayer.Name = "cbxSelectLayer";
            this.cbxSelectLayer.Size = new System.Drawing.Size(363, 21);
            this.cbxSelectLayer.TabIndex = 2;
            this.cbxSelectLayer.SelectedIndexChanged += new System.EventHandler(this.cbxSelectLayer_SelectedIndexChanged);
            // 
            // txtBuffer
            // 
            this.txtBuffer.Location = new System.Drawing.Point(11, 304);
            this.txtBuffer.Name = "txtBuffer";
            this.txtBuffer.Size = new System.Drawing.Size(100, 20);
            this.txtBuffer.TabIndex = 3;
            // 
            // cbxUnit
            // 
            this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Items.AddRange(new object[] {
            "Centimeters (cm)",
            "Decimeters (dm)",
            "Meters (m)",
            "Kilometers (km)"});
            this.cbxUnit.Location = new System.Drawing.Point(117, 304);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(121, 21);
            this.cbxUnit.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(299, 339);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chọn các đối tượng theo quan hệ không gian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Các đối tượng thuộc lớp sau:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "có quan hệ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "với các đối tượng thuộc lớp";
            // 
            // chkUseSelected
            // 
            this.chkUseSelected.AutoSize = true;
            this.chkUseSelected.Location = new System.Drawing.Point(11, 258);
            this.chkUseSelected.Name = "chkUseSelected";
            this.chkUseSelected.Size = new System.Drawing.Size(190, 17);
            this.chkUseSelected.TabIndex = 8;
            this.chkUseSelected.Text = "Sử dụng các đối tượng được chọn";
            this.chkUseSelected.UseVisualStyleBackColor = true;
            // 
            // chkApplyBuffer
            // 
            this.chkApplyBuffer.AutoSize = true;
            this.chkApplyBuffer.Location = new System.Drawing.Point(11, 281);
            this.chkApplyBuffer.Name = "chkApplyBuffer";
            this.chkApplyBuffer.Size = new System.Drawing.Size(206, 17);
            this.chkApplyBuffer.TabIndex = 8;
            this.chkApplyBuffer.Text = "Có buffer cho các đối tượng thuộc lớp";
            this.chkApplyBuffer.UseVisualStyleBackColor = true;
            // 
            // lblSelectLayer
            // 
            this.lblSelectLayer.AutoSize = true;
            this.lblSelectLayer.Location = new System.Drawing.Point(212, 282);
            this.lblSelectLayer.Name = "lblSelectLayer";
            this.lblSelectLayer.Size = new System.Drawing.Size(0, 13);
            this.lblSelectLayer.TabIndex = 9;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(218, 339);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Thử";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(137, 339);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Chấp nhận";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(11, 339);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Trợ giúp";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "(";
            // 
            // lblSelectedFeture
            // 
            this.lblSelectedFeture.AutoSize = true;
            this.lblSelectedFeture.Location = new System.Drawing.Point(19, 0);
            this.lblSelectedFeture.Name = "lblSelectedFeture";
            this.lblSelectedFeture.Size = new System.Drawing.Size(13, 13);
            this.lblSelectedFeture.TabIndex = 11;
            this.lblSelectedFeture.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "đối tượng)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.lblSelectedFeture);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(207, 258);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(167, 21);
            this.flowLayoutPanel1.TabIndex = 13;
            this.flowLayoutPanel1.Visible = false;
            // 
            // SelectByLocationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 374);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblSelectLayer);
            this.Controls.Add(this.chkApplyBuffer);
            this.Controls.Add(this.chkUseSelected);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBuffer);
            this.Controls.Add(this.cbxUnit);
            this.Controls.Add(this.cbxSelectLayer);
            this.Controls.Add(this.cbxMethod);
            this.Controls.Add(this.lstInputLayer);
            this.Controls.Add(this.cbxResultType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectByLocationView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectByLocationView";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxResultType;
        private System.Windows.Forms.CheckedListBox lstInputLayer;
        private System.Windows.Forms.ComboBox cbxMethod;
        private System.Windows.Forms.ComboBox cbxSelectLayer;
        private System.Windows.Forms.TextBox txtBuffer;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkUseSelected;
        private System.Windows.Forms.CheckBox chkApplyBuffer;
        private System.Windows.Forms.Label lblSelectLayer;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSelectedFeture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}