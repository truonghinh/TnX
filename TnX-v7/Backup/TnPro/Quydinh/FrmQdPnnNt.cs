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
    public partial class FrmQdPnnNt : FrmQuyDinh,IConfigView
    {
        private static FrmQdPnnNt _meForm = new FrmQdPnnNt();
        private static bool isShown = false;
        private FrmQdPnnNt()
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
        public static FrmQdPnnNt CallMe()
        {
            if(_meForm==null)
            {
                _meForm = new FrmQdPnnNt();
            }
            return _meForm;
        }
        static FrmQdPnnNt()
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
            this.spnDBKUbnd_truong_cho_tramyt.EditValue = _curConfig.DBKUbnd_truong_cho_tramyt;
            this.spnDBufferMepDuongVt1.EditValue = _curConfig.DBufferMepDuongPnntVt1;
            this.spnDBufferMepDuongVt2.EditValue = _curConfig.DBufferMepDuongPnntVt2;
            this.spnDCachDmgt_chodm.EditValue = _curConfig.DCachDmgt_chodm;
            this.spnDCachRgTmdv_dl_cn_cx_ktck.EditValue = _curConfig.DCachRgTmdv_dl_cn_cx_ktck;
            this.spnDVt2Kv1.EditValue = _curConfig.DVt2Kv1;
            this.spnBkKhuDcttKv2.EditValue = _curConfig.DBkTimKdcttKv2;
            this.spnBkKhuDcttKv3.EditValue = _curConfig.DBkTimKdcttKv3;
            this.txtNam.Caption = _curConfig.NamApDung;
            this.spnPGiaDatSxkd.EditValue = _curConfig.PGiaDatSxkdnt;
            if (_curConfig.BTinhThuaDoiDien == 0)
            {
                this.chkBTinhThuaDoiDien.CheckState = CheckState.Unchecked;
            }
            else
            {
                this.chkBTinhThuaDoiDien.CheckState = CheckState.Checked;
            }

        }

        void IConfigView.SaveConfig()
        {
            _curConfig.PGiaDatSxkddt = double.Parse(this.spnPGiaDatSxkd.EditValue.ToString());
            _curConfig.DBKUbnd_truong_cho_tramyt = double.Parse(this.spnDBKUbnd_truong_cho_tramyt.EditValue.ToString());
            _curConfig.DBufferMepDuongPnntVt1 = double.Parse(this.spnDBufferMepDuongVt1.EditValue.ToString());
            _curConfig.DBufferMepDuongPnntVt2 = double.Parse(this.spnDBufferMepDuongVt2.EditValue.ToString());
            _curConfig.DCachDmgt_chodm = double.Parse(this.spnDCachDmgt_chodm.EditValue.ToString());
            _curConfig.DCachRgTmdv_dl_cn_cx_ktck = double.Parse(this.spnDCachRgTmdv_dl_cn_cx_ktck.EditValue.ToString());
            _curConfig.DVt2Kv1 = double.Parse(this.spnDVt2Kv1.EditValue.ToString());
            _curConfig.DBkTimKdcttKv2 = double.Parse(this.spnBkKhuDcttKv2.EditValue.ToString());
            _curConfig.DBkTimKdcttKv3 = double.Parse(this.spnBkKhuDcttKv3.EditValue.ToString());
            if (this.chkBTinhThuaDoiDien.CheckState == CheckState.Unchecked)
            {
                _curConfig.BTinhThuaDoiDien = 0;
            }
            else
            {
                _curConfig.BTinhThuaDoiDien = 1;
            }
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
                if (conf.GetType() == this.GetType())
                {
                    continue;
                }
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