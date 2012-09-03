namespace com.g1.arcgis.thematic
{
    partial class ThematicView
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
            this.txtBreakCount = new DevExpress.XtraEditors.TextEdit();
            this.txtMax = new DevExpress.XtraEditors.TextEdit();
            this.txtMin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.spnNam = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cbxType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.cbxLoaiDat = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLoaiDat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBreakCount
            // 
            this.txtBreakCount.EditValue = ((short)(5));
            this.txtBreakCount.Location = new System.Drawing.Point(131, 101);
            this.txtBreakCount.Name = "txtBreakCount";
            this.txtBreakCount.Properties.NullText = "1";
            this.txtBreakCount.Properties.NullValuePrompt = "1";
            this.txtBreakCount.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtBreakCount.Size = new System.Drawing.Size(100, 20);
            this.txtBreakCount.TabIndex = 14;
            // 
            // txtMax
            // 
            this.txtMax.EditValue = new decimal(new int[] {
            7200000,
            0,
            0,
            0});
            this.txtMax.Location = new System.Drawing.Point(131, 75);
            this.txtMax.Name = "txtMax";
            this.txtMax.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMax.Properties.DisplayFormat.FormatString = "0,000.0";
            this.txtMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMax.Properties.NullText = "1";
            this.txtMax.Properties.NullValuePrompt = "1";
            this.txtMax.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtMax.Size = new System.Drawing.Size(100, 20);
            this.txtMax.TabIndex = 13;
            // 
            // txtMin
            // 
            this.txtMin.EditValue = new decimal(new int[] {
            3000000,
            0,
            0,
            0});
            this.txtMin.Location = new System.Drawing.Point(131, 49);
            this.txtMin.Name = "txtMin";
            this.txtMin.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtMin.Properties.DisplayFormat.FormatString = "0,000.0";
            this.txtMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMin.Properties.NullText = "0";
            this.txtMin.Properties.NullValuePrompt = "0";
            this.txtMin.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtMin.Size = new System.Drawing.Size(100, 20);
            this.txtMin.TabIndex = 12;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(47, 130);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Giá trị hiển thị:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(47, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Số khoảng chia:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(47, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Giá trị lớn nhất:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Giá trị nhỏ nhất:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(47, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(156, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // spnNam
            // 
            this.spnNam.EditValue = new decimal(new int[] {
            2012,
            0,
            0,
            0});
            this.spnNam.Location = new System.Drawing.Point(131, 23);
            this.spnNam.Name = "spnNam";
            this.spnNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnNam.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.spnNam.Size = new System.Drawing.Size(59, 20);
            this.spnNam.TabIndex = 17;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(47, 26);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(25, 13);
            this.labelControl11.TabIndex = 4;
            this.labelControl11.Text = "Năm:";
            // 
            // cbxType
            // 
            this.cbxType.EditValue = "Chỉ hiển thị các thửa có giá";
            this.cbxType.Location = new System.Drawing.Point(47, 179);
            this.cbxType.Name = "cbxType";
            this.cbxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxType.Properties.Items.AddRange(new object[] {
            "Chỉ hiển thị các thửa có giá",
            "Hiển thị tất cả các thửa"});
            this.cbxType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxType.Size = new System.Drawing.Size(184, 20);
            this.cbxType.TabIndex = 18;
            this.cbxType.Visible = false;
            // 
            // cbxField
            // 
            this.cbxField.EditValue = "Giá đất";
            this.cbxField.Location = new System.Drawing.Point(131, 127);
            this.cbxField.Name = "cbxField";
            this.cbxField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxField.Properties.Items.AddRange(new object[] {
            "Giá đất",
            "Đơn giá"});
            this.cbxField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxField.Size = new System.Drawing.Size(100, 20);
            this.cbxField.TabIndex = 18;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(47, 156);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(42, 13);
            this.labelControl12.TabIndex = 7;
            this.labelControl12.Text = "Loại đất:";
            this.labelControl12.Visible = false;
            // 
            // cbxLoaiDat
            // 
            this.cbxLoaiDat.EditValue = "Nông nghiệp";
            this.cbxLoaiDat.Location = new System.Drawing.Point(131, 153);
            this.cbxLoaiDat.Name = "cbxLoaiDat";
            this.cbxLoaiDat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxLoaiDat.Properties.Items.AddRange(new object[] {
            "Nông nghiệp",
            "Phi nông nghiệp tại đô thị",
            "Phi nông nghiệp tại nông thôn"});
            this.cbxLoaiDat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxLoaiDat.Size = new System.Drawing.Size(100, 20);
            this.cbxLoaiDat.TabIndex = 18;
            this.cbxLoaiDat.Visible = false;
            // 
            // ThematicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxLoaiDat);
            this.Controls.Add(this.cbxField);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.spnNam);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBreakCount);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "ThematicView";
            this.Size = new System.Drawing.Size(274, 289);
            ((System.ComponentModel.ISupportInitialize)(this.txtBreakCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLoaiDat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBreakCount;
        private DevExpress.XtraEditors.TextEdit txtMax;
        private DevExpress.XtraEditors.TextEdit txtMin;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SpinEdit spnNam;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.ComboBoxEdit cbxType;
        private DevExpress.XtraEditors.ComboBoxEdit cbxField;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.ComboBoxEdit cbxLoaiDat;
    }
}
