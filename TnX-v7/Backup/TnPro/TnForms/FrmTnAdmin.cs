using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TNPro.TnForms
{
    public partial class FrmTnAdmin : DevExpress.XtraEditors.XtraForm
    {
        public FrmTnAdmin()
        {
            InitializeComponent();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.CheckState == CheckState.Checked)
            {
                chkUser.CheckState = CheckState.Checked;
            }
        }
    }
}