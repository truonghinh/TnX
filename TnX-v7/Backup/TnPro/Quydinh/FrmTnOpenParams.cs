using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using System.Threading;
using gov.tn.system;
using com.g1.arcgis.tn.calculation;
using com.g1.arcgis.tn.config;

namespace TNPro.Quydinh
{
    public partial class FrmTnOpenParams : DevExpress.XtraEditors.XtraForm,IOpenConfigView
    {
        private IConfigView _configView;
        private ICurrentConfig _currentConfig;
        private IConfigController _configController;
        private string _fileName = "";
        private string _newYear="";
        private string _currentYear="";
        public FrmTnOpenParams()
        {
            InitializeComponent();
            this._currentConfig = CurrentConfig.CallMe();
            //this.spnNam.EditValue = int.Parse(_currentYear);
            //this.txtPath.Text = TnSystemFileName.PARAMS;
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //FrmTnQuydinhTinhgia.CallMe.loadConfigParam(spinEdit1.EditValue.ToString());
            //FrmTnQuydinhTinhgia.CallMe.putParamIntoForm();
            this._configController = new ConfigController(this._configView, this._currentConfig, this);
            this._fileName = TnSystemFileName.PARAMS;
            this._newYear = spnNam.EditValue.ToString();
            this._configController.LoadConfig();
            this.Close();
            //Thread t = new Thread(loadConfig);
            //t.Start();
            //t.Join();
            //this._configView.LoadConfig();
        }

        private void loadConfig()
        {
            this._configController.LoadConfig();
        }

        #region IOpenConfigView Members

        void IOpenConfigView.ShowDialog()
        {
            this.ShowDialog();
        }

        void IOpenConfigView.SetConfigView(IConfigView configView)
        {
            this._configView=configView;
        }

        string IOpenConfigView.FileName
        {
            get
            {
                return this._fileName;
            }
            set
            {
                this._fileName = value;
            }
        }

        string IOpenConfigView.NewYear
        {
            get
            {
                return this._newYear;
            }
            set
            {
                this._newYear=value;
            }
        }

        #endregion

        #region IOpenConfigView Members


        void IOpenConfigView.Close()
        {

            this.Close();
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region IOpenConfigView Members


        string IOpenConfigView.CurrentYear
        {
            get
            {
                return _currentYear;
            }
            set
            {
                _currentYear=value;
            }
        }

        #endregion
    }
}