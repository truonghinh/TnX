using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.tn.calculation
{
    public partial class FrmQuyDinh : DevExpress.XtraEditors.XtraForm
    {
        protected IOpenConfigView _openConfigView;
        protected ISaveConfigView _saveConfigView;
        protected ICurrentConfig _curConfig;
        protected List<IConfigView> _lstConfigView;
        protected string _currentYear="";
        public FrmQuyDinh()
        {
            InitializeComponent();
        }

        private void bbiOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._openConfigView.CurrentYear = this._currentYear;
            this._openConfigView.ShowDialog();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._saveConfigView.CurrentYear = this._currentYear;
            this._saveConfigView.ShowDialog();
        }

    }
}