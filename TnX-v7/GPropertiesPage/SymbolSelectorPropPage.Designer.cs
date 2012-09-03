// Copyright 2008 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.
// 

namespace SymbolSelector
{
  partial class SymbolSelectorPropPage
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
      this.label1 = new System.Windows.Forms.Label();
      this.gprPreview = new System.Windows.Forms.GroupBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnMoreSymbols = new System.Windows.Forms.Button();
      this.btnReset = new System.Windows.Forms.Button();
      this.gprPreview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 13);
      this.label1.TabIndex = 2;
      // 
      // gprPreview
      // 
      this.gprPreview.Controls.Add(this.pictureBox1);
      this.gprPreview.Location = new System.Drawing.Point(331, 38);
      this.gprPreview.Name = "gprPreview";
      this.gprPreview.Size = new System.Drawing.Size(149, 142);
      this.gprPreview.TabIndex = 4;
      this.gprPreview.TabStop = false;
      this.gprPreview.Text = "Preview";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(6, 19);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(137, 117);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // btnMoreSymbols
      // 
      this.btnMoreSymbols.Location = new System.Drawing.Point(331, 233);
      this.btnMoreSymbols.Name = "btnMoreSymbols";
      this.btnMoreSymbols.Size = new System.Drawing.Size(149, 28);
      this.btnMoreSymbols.TabIndex = 5;
      this.btnMoreSymbols.Text = "More Symbols";
      this.btnMoreSymbols.UseVisualStyleBackColor = true;
      this.btnMoreSymbols.Click += new System.EventHandler(this.btnMoreSymbols_Click);
      // 
      // btnReset
      // 
      this.btnReset.Location = new System.Drawing.Point(331, 268);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(149, 23);
      this.btnReset.TabIndex = 6;
      this.btnReset.Text = "Reset";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // SymbolSelectorPropPage
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 419);
      this.Controls.Add(this.btnReset);
      this.Controls.Add(this.btnMoreSymbols);
      this.Controls.Add(this.gprPreview);
      this.Controls.Add(this.label1);
      this.Name = "SymbolSelectorPropPage";
      this.Text = "Symbol Selector";
      this.TopMost = true;
      this.Shown += new System.EventHandler(this.SymbolSelectorPropPage_Shown);
      this.gprPreview.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox gprPreview;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btnMoreSymbols;
    private System.Windows.Forms.Button btnReset;
  }
}