using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.tn.calculation;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;

namespace TNPro.Quydinh
{
    public partial class FrmQdPnnDt : FrmQuyDinh,IConfigView
    {
        private static FrmQdPnnDt _meForm = new FrmQdPnnDt();
        private static bool isShown = false;

        private FrmQdPnnDt()
        {
            InitializeComponent();
            _curConfig = CurrentConfig.CallMe();
            this._openConfigView = new FrmTnOpenParams();
            this._openConfigView.SetConfigView(this);
            this._saveConfigView = new FrmTnSaveParams();
            this._saveConfigView.SetConfigView(this);
            ((IConfigView)this).SetOpenAndSaveView(this._openConfigView, this._saveConfigView);
        }

        #region singleton
        public static FrmQdPnnDt CallMe()
        {
            if(_meForm==null)
            {
                _meForm = new FrmQdPnnDt();
            }
            return _meForm;
        }
        static FrmQdPnnDt()
        {
            _meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            _meForm.Hide();
        }

        public new void ShowDialog()
        {
            if (isShown)
            {
                base.ShowDialog();
            }
            else
            {
                base.ShowDialog();
                isShown = true;
            }
        }
        public new void Show()
        {
            if (isShown)
            {
                base.Show();
            }
            else
            {
                base.Show();
                isShown = true;
            }
        }
        #endregion

        #region IConfigView Members

        void IConfigView.LoadConfig()
        {
            this.spnDBufferMatTien.EditValue = _curConfig.DBufferMattien;
            this.spnDBufferMathem.EditValue = _curConfig.DBufferMathem;
            this.spnDKhoangCach50mMatTien.EditValue = _curConfig.DKhoangCach50mMatTien;
            this.spnGiaMinDt4.EditValue = _curConfig.GToiThieuDoThiLoai4;
            this.spnGiaMinDt5.EditValue = _curConfig.GToiThieuDoThiLoai5;
            this.spnPDatSau50m.EditValue = _curConfig.PDatSau50mMatTien;
            this.spnPHemChinhRongDuoi3_5m.EditValue = _curConfig.PHemChinhRongDuoi3_5m;
            this.spnPHemChinhRongTren3_5m.EditValue = _curConfig.PHemChinhRongTren3_5m;
            this.spnPHemChinhRongTren6m.EditValue = _curConfig.PHemChinhRongTren6m;
            this.spnPHemPhuRongDuoi3_5m.EditValue = _curConfig.PHemPhuRongDuoi3_5m;
            this.spnPHemPhuRongTren3_5m.EditValue = _curConfig.PHemPhuRongTren3_5m;
            this.spnPHemPhuRongTren6m.EditValue = _curConfig.PHemPhuRongTren6m;
            this.spnPHemSauDuoi100m.EditValue = _curConfig.PHemSauDuoi100m;
            this.spnPHemSauDuoi200m.EditValue = _curConfig.PHemSauDuoi200m;
            this.spnPHemSauTren200m.EditValue = _curConfig.PHemSauTren200m;
            this.txtNam.Caption = _curConfig.NamApDung;
            this.spnPGiaDatSxkd.EditValue = _curConfig.PGiaDatSxkddt;
        }

        void IConfigView.SaveConfig()
        {
            _curConfig.DBufferMattien = double.Parse(this.spnDBufferMatTien.EditValue.ToString());
            _curConfig.DBufferMathem = double.Parse(this.spnDBufferMathem.EditValue.ToString());
            _curConfig.DKhoangCach50mMatTien = double.Parse(this.spnDKhoangCach50mMatTien.EditValue.ToString());
            _curConfig.GToiThieuDoThiLoai4 = double.Parse(this.spnGiaMinDt4.EditValue.ToString());
            _curConfig.GToiThieuDoThiLoai5 = double.Parse(this.spnGiaMinDt5.EditValue.ToString());
            _curConfig.PDatSau50mMatTien = double.Parse(this.spnPDatSau50m.EditValue.ToString());
            _curConfig.PHemChinhRongDuoi3_5m = double.Parse(this.spnPHemChinhRongDuoi3_5m.EditValue.ToString());
            _curConfig.PHemChinhRongTren3_5m = double.Parse(this.spnPHemChinhRongTren3_5m.EditValue.ToString());
            _curConfig.PHemChinhRongTren6m = double.Parse(this.spnPHemChinhRongTren6m.EditValue.ToString());
            _curConfig.PHemPhuRongDuoi3_5m = double.Parse(this.spnPHemPhuRongDuoi3_5m.EditValue.ToString());
            _curConfig.PHemPhuRongTren3_5m = double.Parse(this.spnPHemPhuRongTren3_5m.EditValue.ToString());
            _curConfig.PHemPhuRongTren6m = double.Parse(this.spnPHemPhuRongTren6m.EditValue.ToString());
            _curConfig.PHemSauDuoi100m = double.Parse(this.spnPHemSauDuoi100m.EditValue.ToString());
            _curConfig.PHemSauDuoi200m = double.Parse(this.spnPHemSauDuoi200m.EditValue.ToString());
            _curConfig.PHemSauTren200m = double.Parse(this.spnPHemSauTren200m.EditValue.ToString());
            _curConfig.PGiaDatSxkddt = double.Parse(this.spnPGiaDatSxkd.EditValue.ToString());
            _curConfig.NamApDung = this.txtNam.Caption;


        }

        void IConfigView.SetOpenAndSaveView(IOpenConfigView openView, ISaveConfigView saveView)
        {
            this._openConfigView = openView;
            this._saveConfigView = saveView;
        }

        void IConfigView.SetBuddy(List<IConfigView> buddies)
        {
            this._lstConfigView = buddies;
        }

        void IConfigView.ShowDialog()
        {
            this.ShowDialog();
        }

        void IConfigView.KeepFollow()
        {
            foreach (IConfigView conf in _lstConfigView)
            {
                //if (conf.GetType() == this.GetType())
                //{
                //    continue;
                //}
                conf.LoadConfig();
            }
        }

        void IConfigView.Show()
        {
            this.Show();
        }

        #endregion
    }
}