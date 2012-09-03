using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace TnControlLib
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] 
    public partial class TnGroupBox : UserControl
    {
        protected string _caption = "";

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; this.lblCaption.Text = _caption; }
        }

        public TnGroupBox()
        {
            InitializeComponent();
        }
    }
}
