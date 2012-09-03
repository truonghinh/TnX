using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;

namespace AsYetUnnamed
{
	public class Form1 : System.Windows.Forms.Form
	{
		#region form control declarations
		private System.ComponentModel.Container components = null;		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtRowIndex;
		private System.Windows.Forms.TextBox txtColumnName;
		private System.Windows.Forms.TextBox txtColumnIndex;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox txtValueMember;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblValueMember;
		private System.Windows.Forms.TextBox txtValueIndex;
		private System.Windows.Forms.Label lblValueIndex;
		private System.Windows.Forms.TextBox txtTextIndex;
		private System.Windows.Forms.Label lblTextIndex;
		private System.Windows.Forms.TextBox txtTextMember;
		private System.Windows.Forms.Label lblTextMember;
		private System.Windows.Forms.TextBox txtColumnCount;
		private System.Windows.Forms.Label lblColumnCount;
		private System.Windows.Forms.Label label6;
		#endregion

		private DataSet ds;
		private AsYetUnnamed.MultiColumnListBox listBox1;

		public Form1()
		{
			InitializeComponent();
			
			ResourceManager rm = new ResourceManager("AsYetUnnamed.MCListBox",Assembly.GetExecutingAssembly());			
			
			// Uncomment if you do not have a Local Pubs Sql Database
			// Then comment out the next 4 lines afterwards
			ds = DataArray.ToDataSet(new object[,]{
														{"Row0, col0",	"Row0, col1"	,1},
														{"Row00, col0",	"Row1, col1"	,new object()},
														{"Row1, col0",	"Row2, col1"	,"Some String"},
														{"Row1a, col0",	"Row3, col1"	,Rectangle.Empty},
														{"row1aa,col0",	"Row4, col1"	,1},
														{"row0, col0",	"Row5, col1"	,1},
														{"pow0, col0",	"Row6, col1"	,1},
														{"Row7, col0",	"Row7, col1"	,new ExampleClass()},
														{"Row8, col0",	"Row8, col1"	,(Bitmap)rm.GetObject("StopLight")}
													});
			
			//ds = new DataSet();			
			//SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM pub_info","SERVER=localhost;database=pubs;trusted_connection=yes");				
			//da.Fill(ds);
			//listBox1.ItemHeight = 50;
			
			textBox3.Text = ds.GetXml();
			
			listBox1.ColumnWidths[0] = 100;
			listBox1.ColumnWidths[1] = 420;
			listBox1.ColumnWidths[2] = 300;

			listBox1.DataSource = ds.Tables[0];
			
			listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
			txtValueIndex.Validated += new EventHandler(txtMembersChanged);
			txtValueMember.Validated += new EventHandler(txtMembersChanged);
			txtTextIndex.Validated += new EventHandler(txtMembersChanged);
			txtValueIndex.Validated += new EventHandler(txtMembersChanged);
			txtColumnCount.Validated += new EventHandler(txtMembersChanged);
			listBox1.DrawItem += new DrawItemEventHandler(drawLBItem);
			listBox1.DrawSubItem += new DrawSubItemEventHandler(drawLBSubItem);
			listBox1.MeasureSubItem += new MeasureSubItemEventHandler(measureLBItem);

			//listBox1.DrawMode = DrawMode.OwnerDrawVariable;

			
		}

		#region owner draw event handlers - To enable set listBox1.DrawMode to something other than Normal
		private void measureLBItem(object sender, MeasureSubItemEventArgs e)
		{
			MultiColumnListBox lb = (MultiColumnListBox)sender;
			SizeF s = e.Graphics.MeasureString("O",lb.Font);
			e.ItemWidth = (int)s.Width;
			e.ItemHeight = (int)s.Height+4;			
		}
		
		private void drawLBItem(object sender,DrawItemEventArgs e)
		{
			Rectangle smallBounds = e.Bounds;
			smallBounds.Inflate(-1,-1);

			if((e.State & DrawItemState.Selected) == DrawItemState.Selected)				
				e.Graphics.FillRectangle(new SolidBrush(ControlPaint.LightLight(SystemColors.Highlight)),e.Bounds);
			else
				e.Graphics.FillRectangle(SystemBrushes.Window,e.Bounds);

			if((e.State & DrawItemState.Focus) == DrawItemState.Focus)
				e.Graphics.DrawRectangle(new Pen(ControlPaint.Light(SystemColors.Highlight),.1f),e.Bounds.Left,e.Bounds.Top,e.Bounds.Width-1,e.Bounds.Height-1);
		}

		private void drawLBSubItem(object sender,DrawSubItemEventArgs e)
		{
			if(e.SubIndex == ((MultiColumnListBox)sender).TextIndex && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
				e.Graphics.FillRectangle(new SolidBrush(SystemColors.ControlLight),e.Bounds);
			
			e.Graphics.DrawString(((MultiColumnListBox)sender).GetItemAt(e.Index,e.SubIndex).ToString(),e.Font,new SolidBrush(e.ForeColor),e.Bounds.Left,e.Bounds.Top+2);
		}
		#endregion

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			label1.Text = "Text: " + listBox1.Text;
			try
			{
				label2.Text = "Value: " + listBox1.Value.ToString();
			}
			catch(Exception ex)
			{
			}
		}

		private void txtMembersChanged(object sender,EventArgs e)
		{
			SetListBoxProperties();
		}

		private void SetListBoxProperties()
		{
			try
			{
				listBox1.ValueIndex = int.Parse(txtValueIndex.Text);
			}
			catch(FormatException ex)
			{
				txtValueIndex.Text = "-1";
				listBox1.ValueIndex = int.Parse(txtValueIndex.Text);
			}
			listBox1.ValueMember = txtValueMember.Text;

			try
			{
				listBox1.TextIndex = int.Parse(txtTextIndex.Text);
			}
			catch(FormatException ex)
			{
				txtTextIndex.Text = "-1";
				listBox1.TextIndex = int.Parse(txtTextIndex.Text);
			}
			listBox1.TextMember = txtTextMember.Text;

			try
			{
				listBox1.ColumnCount = int.Parse(txtColumnCount.Text);
			}
			catch(FormatException ex)
			{
				txtColumnCount.Text = "-1";
				listBox1.ColumnCount = int.Parse(txtColumnCount.Text);
			}

		}
		#region standard VS Designer code - nothing special
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new AsYetUnnamed.MultiColumnListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRowIndex = new System.Windows.Forms.TextBox();
			this.txtColumnName = new System.Windows.Forms.TextBox();
			this.txtColumnIndex = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtValueMember = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblValueMember = new System.Windows.Forms.Label();
			this.txtValueIndex = new System.Windows.Forms.TextBox();
			this.lblValueIndex = new System.Windows.Forms.Label();
			this.txtTextIndex = new System.Windows.Forms.TextBox();
			this.lblTextIndex = new System.Windows.Forms.Label();
			this.txtTextMember = new System.Windows.Forms.TextBox();
			this.lblTextMember = new System.Windows.Forms.Label();
			this.txtColumnCount = new System.Windows.Forms.TextBox();
			this.lblColumnCount = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.listBox1.ColumnCount = 0;
			this.listBox1.ColumnWidth = 75;
			this.listBox1.HorizontalScrollbar = true;
			this.listBox1.Location = new System.Drawing.Point(16, 24);
			this.listBox1.MatchBufferTimeOut = 1000;
			this.listBox1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.ColpleteBestMatch;
			this.listBox1.Name = "listBox1";
			this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBox1.Size = new System.Drawing.Size(472, 17);
			this.listBox1.TabIndex = 0;
			this.listBox1.TextIndex = -1;
			this.listBox1.TextMember = null;
			this.listBox1.ValueIndex = -1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Text:";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(256, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(256, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Value:";
			// 
			// txtRowIndex
			// 
			this.txtRowIndex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtRowIndex.Location = new System.Drawing.Point(16, 32);
			this.txtRowIndex.Name = "txtRowIndex";
			this.txtRowIndex.TabIndex = 5;
			this.txtRowIndex.Text = "";
			// 
			// txtColumnName
			// 
			this.txtColumnName.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtColumnName.Location = new System.Drawing.Point(136, 32);
			this.txtColumnName.Name = "txtColumnName";
			this.txtColumnName.TabIndex = 6;
			this.txtColumnName.Text = "";
			// 
			// txtColumnIndex
			// 
			this.txtColumnIndex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtColumnIndex.Location = new System.Drawing.Point(256, 32);
			this.txtColumnIndex.Name = "txtColumnIndex";
			this.txtColumnIndex.TabIndex = 7;
			this.txtColumnIndex.Text = "";
			// 
			// label3
			// 
			this.label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.TabIndex = 8;
			this.label3.Text = "rowIndex";
			// 
			// label4
			// 
			this.label4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label4.Location = new System.Drawing.Point(136, 16);
			this.label4.Name = "label4";
			this.label4.TabIndex = 9;
			this.label4.Text = "columnName";
			// 
			// label5
			// 
			this.label5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label5.Location = new System.Drawing.Point(256, 16);
			this.label5.Name = "label5";
			this.label5.TabIndex = 10;
			this.label5.Text = "columnIndex";
			// 
			// button1
			// 
			this.button1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.button1.Location = new System.Drawing.Point(16, 64);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(344, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "GetItemAt(rowIndex, columnName)";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.button2.Location = new System.Drawing.Point(16, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(344, 23);
			this.button2.TabIndex = 12;
			this.button2.Text = "GetItemAt(rowIndex, columnIndex)";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.button3.Location = new System.Drawing.Point(16, 112);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(344, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "GetItemAt(columnName)";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.button4.Location = new System.Drawing.Point(16, 136);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(344, 23);
			this.button4.TabIndex = 14;
			this.button4.Text = "GetItemAt(columnIndex)";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBox3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(392, 64);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox3.Size = new System.Drawing.Size(104, 264);
			this.textBox3.TabIndex = 15;
			this.textBox3.Text = "";
			this.textBox3.WordWrap = false;
			// 
			// txtValueMember
			// 
			this.txtValueMember.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtValueMember.Location = new System.Drawing.Point(16, 72);
			this.txtValueMember.Name = "txtValueMember";
			this.txtValueMember.TabIndex = 16;
			this.txtValueMember.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button2,
																					this.txtRowIndex,
																					this.button4,
																					this.txtColumnName,
																					this.button3,
																					this.txtColumnIndex,
																					this.button1,
																					this.label3,
																					this.label4,
																					this.label5});
			this.groupBox1.Location = new System.Drawing.Point(16, 152);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 176);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "GetItemAt()";
			// 
			// lblValueMember
			// 
			this.lblValueMember.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.lblValueMember.Location = new System.Drawing.Point(16, 56);
			this.lblValueMember.Name = "lblValueMember";
			this.lblValueMember.TabIndex = 19;
			this.lblValueMember.Text = "ValueMember";
			// 
			// txtValueIndex
			// 
			this.txtValueIndex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtValueIndex.Location = new System.Drawing.Point(136, 72);
			this.txtValueIndex.Name = "txtValueIndex";
			this.txtValueIndex.TabIndex = 20;
			this.txtValueIndex.Text = "";
			// 
			// lblValueIndex
			// 
			this.lblValueIndex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.lblValueIndex.Location = new System.Drawing.Point(136, 56);
			this.lblValueIndex.Name = "lblValueIndex";
			this.lblValueIndex.TabIndex = 21;
			this.lblValueIndex.Text = "ValueIndex";
			// 
			// txtTextIndex
			// 
			this.txtTextIndex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtTextIndex.Location = new System.Drawing.Point(136, 120);
			this.txtTextIndex.Name = "txtTextIndex";
			this.txtTextIndex.TabIndex = 24;
			this.txtTextIndex.Text = "";
			// 
			// lblTextIndex
			// 
			this.lblTextIndex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.lblTextIndex.Location = new System.Drawing.Point(136, 104);
			this.lblTextIndex.Name = "lblTextIndex";
			this.lblTextIndex.TabIndex = 25;
			this.lblTextIndex.Text = "TextIndex";
			// 
			// txtTextMember
			// 
			this.txtTextMember.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtTextMember.Location = new System.Drawing.Point(16, 120);
			this.txtTextMember.Name = "txtTextMember";
			this.txtTextMember.TabIndex = 22;
			this.txtTextMember.Text = "";
			// 
			// lblTextMember
			// 
			this.lblTextMember.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.lblTextMember.Location = new System.Drawing.Point(16, 104);
			this.lblTextMember.Name = "lblTextMember";
			this.lblTextMember.TabIndex = 23;
			this.lblTextMember.Text = "TextMember";
			// 
			// txtColumnCount
			// 
			this.txtColumnCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.txtColumnCount.Location = new System.Drawing.Point(264, 104);
			this.txtColumnCount.Name = "txtColumnCount";
			this.txtColumnCount.TabIndex = 26;
			this.txtColumnCount.Text = "";
			// 
			// lblColumnCount
			// 
			this.lblColumnCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.lblColumnCount.Location = new System.Drawing.Point(264, 88);
			this.lblColumnCount.Name = "lblColumnCount";
			this.lblColumnCount.TabIndex = 27;
			this.lblColumnCount.Text = "ColumnCount";
			// 
			// label6
			// 
			this.label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.label6.Location = new System.Drawing.Point(392, 48);
			this.label6.Name = "label6";
			this.label6.TabIndex = 28;
			this.label6.Text = "DataSource:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(504, 339);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtColumnCount,
																		  this.lblColumnCount,
																		  this.txtTextIndex,
																		  this.lblTextIndex,
																		  this.txtTextMember,
																		  this.lblTextMember,
																		  this.txtValueIndex,
																		  this.lblValueIndex,
																		  this.groupBox1,
																		  this.txtValueMember,
																		  this.textBox3,
																		  this.listBox1,
																		  this.label2,
																		  this.label1,
																		  this.lblValueMember,
																		  this.label6});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.MinimumSize = new System.Drawing.Size(512, 368);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
				#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(listBox1.GetItemAt(int.Parse(txtRowIndex.Text),txtColumnName.Text).ToString());
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(listBox1.GetItemAt(int.Parse(txtRowIndex.Text),int.Parse(txtColumnIndex.Text)).ToString());
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(listBox1.GetItemAt(txtColumnName.Text).ToString());
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(listBox1.GetItemAt(int.Parse(txtColumnIndex.Text)).ToString());
		}

		
	}

	public class ExampleClass
	{
		public override string ToString()
		{
			return "Hello from ExampleClass!!";
		}
	}	
}
