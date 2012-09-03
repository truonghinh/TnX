using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace com.g1.arcgis.database.versioning
{
    public partial class FrmVerifyRegisterVersioned : DevExpress.XtraEditors.XtraForm
    {
        private bool _ok;
        private bool _showAgain;
        public FrmVerifyRegisterVersioned()
        {
            InitializeComponent();
        }

        public bool ShowAgain
        {
            get { return _showAgain; }
        }

        public bool OK
        {
            get { return _ok; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _ok = true;
            
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _ok = false;
            this.Close();
        }
    }
}