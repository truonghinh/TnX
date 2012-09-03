using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using gov.tn.system;
using com.g1.arcgis.tn.calculation;
using com.g1.arcgis.tn.config;

namespace TNPro.Quydinh
{
    public partial class FrmTnSaveParams : DevExpress.XtraEditors.XtraForm,ISaveConfigView
    {
        private IConfigView _configView;
        private ICurrentConfig _currentConfig;
        private IConfigController _configController;
        private IOpenConfigView _openView;
        private string _fileName = "";
        private string _currentYear = "";
        private string _newYear = "";
        public FrmTnSaveParams()
        {
            InitializeComponent();
            this._currentConfig = CurrentConfig.CallMe();
            _openView = new FrmTnOpenParams();

            //spnNam.EditValue = int.Parse(_currentYear);
            //this.txtPath.Text = TnSystemFileName.PARAMS;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this._configController = new ConfigController(this._configView, this._currentConfig, this);
            this._configController.SetOpenView(_openView);
            this._fileName = TnSystemFileName.PARAMS;
            this._newYear = spnNam.EditValue.ToString();
            this._configController.SaveConfig();
            _openView.NewYear = this._newYear;
            _openView.FileName = this._fileName;
            this._configController.LoadConfig();
            //this._configController.o
            this.Close();
        }

        #region ISaveConfigView Members

        void ISaveConfigView.ShowDialog()
        {
            this.ShowDialog();
        }

        void ISaveConfigView.Close()
        {
            this.Close();
        }

        string ISaveConfigView.FileName
        {
            get
            {
                return this._fileName;
            }
            set
            {
                this._fileName=value;
            }
        }

        string ISaveConfigView.CurrentYear
        {
            get
            {
                return this._currentYear;
            }
            set
            {
                this._currentYear=value;
            }
        }

        string ISaveConfigView.NewYear
        {
            get
            {
                return this._newYear;
            }
            set
            {
                this._newYear = value;
            }
        }

        void ISaveConfigView.SetConfigView(IConfigView configView)
        {
            this._configView=configView;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}