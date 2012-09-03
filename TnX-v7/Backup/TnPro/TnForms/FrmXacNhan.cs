using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.landprice;

namespace TNPro.TnForms
{
    public partial class FrmXacNhan : DevExpress.XtraEditors.XtraForm,IXacNhan
    {
        private IParamSwitch _switch;
        public FrmXacNhan()
        {
            InitializeComponent();
        }

        #region IXacNhan Members

        void IXacNhan.ShowDialog()
        {
            this.ShowDialog();
        }

        #endregion

        #region IXacNhan Members


        void IXacNhan.SetSwitch(IParamSwitch param)
        {
            _switch = param;
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            _switch.TurnOn();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _switch.TurnOff();
        }
    }
}