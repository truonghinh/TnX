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
    public partial class FrmQdNongNghiep : FrmQuyDinh,IConfigView
    {
        private static FrmQdNongNghiep _meForm = new FrmQdNongNghiep();
        private static bool isShown = false;
        private FrmQdNongNghiep():base()
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
        public static FrmQdNongNghiep CallMe()
        {
            if(_meForm==null)
            {
                _meForm = new FrmQdNongNghiep();
            }
            return _meForm;
        }
        static FrmQdNongNghiep()
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
            ((IConfigView)this).LoadConfig();
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
            ((IConfigView)this).LoadConfig();
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
            this.spnDBufferMepDuongVt1.EditValue=_curConfig.DBufferMepDuongNnVt1;
            this.spnDBufferMepDuongVt2.EditValue = _curConfig.DBufferMepDuongNnVt2;
            this.spnDRongDuongVitri1Nn.EditValue = _curConfig.DRongDuongVitri1Nn;
            this.spnDRongDuongVitri2Nn.EditValue = _curConfig.DRongDuongVitri2NnMax;
            this.spnDSauDuongVitri1Nn.EditValue = _curConfig.DSauDuongVitri1Nn;
            this.spnDSauDuongVitri2Nn.EditValue = _curConfig.DSauDuongVitri2Nn;
            this.spnDSauDuongVitri2Nn2.EditValue = _curConfig.DSauDuongVitri2Nn2;
            this.txtNam.Caption = _curConfig.NamApDung;
            
        }

        void IConfigView.SaveConfig()
        {
            
            _curConfig.DBufferMepDuongNnVt1 = double.Parse(this.spnDBufferMepDuongVt1.EditValue.ToString());
            _curConfig.DBufferMepDuongNnVt2=double.Parse(this.spnDBufferMepDuongVt2.EditValue.ToString()) ;
            _curConfig.DRongDuongVitri1Nn = double.Parse(this.spnDRongDuongVitri1Nn.EditValue.ToString());
            _curConfig.DRongDuongVitri2NnMax = double.Parse(this.spnDRongDuongVitri2Nn.EditValue.ToString());
            _curConfig.DSauDuongVitri1Nn = double.Parse(this.spnDSauDuongVitri1Nn.EditValue.ToString());
            _curConfig.DSauDuongVitri2Nn = double.Parse(this.spnDSauDuongVitri2Nn.EditValue.ToString());
            _curConfig.DSauDuongVitri2Nn2 = double.Parse(this.spnDSauDuongVitri2Nn2.EditValue.ToString());
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
            //MessageBox.Show(_lstConfigView.Count.ToString());
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