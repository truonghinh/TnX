using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using com.g1.arcgis.database;
using com.g1.collection;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.connection;
using com.g1.arcgis.tn.calculation.fulfil;
using gov.tn.system;
using com.g1.arcgis.tn.config;
namespace com.g1.arcgis.tn.calculation
{
    public partial class GCalculationHemView : DevExpress.XtraEditors.XtraUserControl, ICalculationView, IReceiverView, IDatabaseInteractive
    {
        //dung de tinh gia dat
        #region tinh gia dat
        private IInputParams _inputParams;
        private ICurrentConfig _currentConfig;
        private ICalculation _calc;
        private ICalculationView _calcView;
        private ICalculationController _calcController;
        private ICalculationMonitor _monitor;
        private List<ICalculationMonitor> _lstMonitor;

        #endregion

        //dung de load du lieu
        private ILoader _loader;
        private ILoaderController _loaderController;
        private string _sql = "";
        private IDictionary<EnumG1ArcGisTnRecType, string> _dicSql;
        private IDictionary<EnumG1ArcGisTnRecType, string> _dicTableName;
        private IDictionary<EnumG1ArcGisTnRecType, string> _dicColsName;
        private IDictionary<EnumG1ArcGisTnRecType, string> _dicColsNameInWhereClause;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        private static XPair _lstXa;
        private static XPair _lstDuong;
        private static XPair _lstDoanDuong;
        public GCalculationHemView()
        {
            InitializeComponent();
            this._lstMonitor = new List<ICalculationMonitor>();
            //_fcName = new TnFeatureClassName();
            _dicSql = new Dictionary<EnumG1ArcGisTnRecType, string>();
            //_dicSql.Add(EnumG1ArcGisTnRecType.Doanduong, string.Format("select {0},{1},{2} from {3} where {4}=N'{5}'", _fcName.FC_DUONG.MA_DUONG, _fcName.FC_DUONG.BAT_DAU, _fcName.FC_DUONG.KET_THUC, "sde.thixa_duong", _fcName.FC_DUONG.TEN_DUONG, v));
            //_dicSql.Add(EnumG1ArcGisTnRecType.Doanduong, );
            //_sql = string.Format("select {0},{1},{2} from {3} where {4}='a'", _fcName.FC_DUONG.MA_DUONG, _fcName.FC_DUONG.BAT_DAU, _fcName.FC_DUONG.KET_THUC, "sde.thixa_duong", _fcName.FC_DUONG.TEN_DUONG);
            //_dicSql.Add(EnumG1ArcGisTnRecType.Doanduong, "");
            //_dicSql.Add(EnumG1ArcGisTnRecType.Duong, string.Format("select distinct {0} from {1}", _fcName.FC_DUONG.TEN_DUONG, "sde.thixa_duong"));
            //_dicSql.Add(EnumG1ArcGisTnRecType.Huyen, "");
            //_dicSql.Add(EnumG1ArcGisTnRecType.Xa, string.Format("select {0},{1} from {2}", _fcName.FC_RANH_XA_POLY.MA_XA, _fcName.FC_RANH_XA_POLY.TEN_XA, "sde.THIXA_XAPOLY"));
            _dicSql.Add(EnumG1ArcGisTnRecType.Doanduong, "");
            _dicSql.Add(EnumG1ArcGisTnRecType.Duong, "");
            _dicSql.Add(EnumG1ArcGisTnRecType.Huyen, "");
            _dicSql.Add(EnumG1ArcGisTnRecType.Xa, "");

            _loader = new Loader(this);
            _loader.Finished += new LoaderFinishedEventHandler(loader_Finished);
            _loaderController = new LoaderController(this, _loader);
            this.btnCloseFrmTinhAll.Click += new EventHandler(btnCloseFrmTinhAll_Click);
            this.cbxDuong.Click += new EventHandler(cbxDuong_Click);
            this.cbxXa.Click += new EventHandler(cbxXa_Click);
            this.cbxDoanDuong.Click += new EventHandler(cbxDoanDuong_Click);
        }
        void cbxDoanDuong_Click(object sender, EventArgs e)
        {
            if (cbxDoanDuong.Properties.Items.Count == 0)
            {
                putValueIntoCbxDoanDuong();
            }
        }

        void cbxXa_Click(object sender, EventArgs e)
        {
            if (cbxXa.Properties.Items.Count == 0)
            {
                putValueIntoCbxXa();
            }
        }

        void cbxDuong_Click(object sender, EventArgs e)
        {
            if (cbxDuong.Properties.Items.Count == 0)
            {
                putValueIntoCbxDuong();
            }
        }


        //sau khi truy van xong, loader se cap nhat vao view
        void loader_Finished(object sender, LoaderEventArg e)
        {
            //MessageBox.Show("line 49 CalculationView:-- "+e.ToString());
            if (e._type == EnumG1ArcGisTnRecType.Doanduong)
            {
                putValueIntoCbxDoanDuong();
            }
            else if (e._type == EnumG1ArcGisTnRecType.Duong)
            {
                putValueIntoCbxDuong();
                //MessageBox.Show("dang load duong");
            }
            else if (e._type == EnumG1ArcGisTnRecType.Huyen)
            {

            }
            else if (e._type == EnumG1ArcGisTnRecType.Xa)
            {
                putValueIntoCbxXa();
            }
        }

        #region ICalculationView Members

        ICurrentConfig ICalculationView.CurrentConfig
        {
            get
            {
                return this._currentConfig;
            }
            set
            {
                this._currentConfig = value; ;
            }
        }

        void ICalculationView.GetParams()
        {
            throw new NotImplementedException();
        }

        IInputParams ICalculationView.InputParams
        {
            get
            {
                return this._inputParams;
            }
            set
            {
                this._inputParams = value;
            }
        }

        void ICalculationView.SetParams()
        {
            throw new NotImplementedException();
        }

        void ICalculationView.Start()
        {
            //this._loaderController.ReqLoad();
        }

        void ICalculationView.Stop()
        {
            throw new NotImplementedException();
        }

        void ICalculationView.SetInputParams(IInputParams input)
        {
            this._inputParams = input;
        }

        #endregion

        #region IReceiverView Members

        void IReceiverView.Load(EnumG1ArcGisTnRecType type)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            _fcName = new TnFeatureClassName(sdeConn.Workspace);
            _tblName = new TnTableName(sdeConn.Workspace);
            //if (type == EnumG1ArcGisTnRecType.Duong)
            //{
            //    this._dicSql[type]=string.Format("select distinct {0} from {1}", this._dicColsName[type], this._dicTableName[type]);
            //}
            //else if (type == EnumG1ArcGisTnRecType.Doanduong)
            //{
            //    string.Format("select {0},{1},{2} from {3} where {4}=N'{5}'", _fcName.FC_DUONG.MA_DUONG, _fcName.FC_DUONG.BAT_DAU, _fcName.FC_DUONG.KET_THUC, "sde.thixa_duong", _dicColsNameInWhereClause[type], cbxDuong.Text);
            //}
            _dicSql[EnumG1ArcGisTnRecType.Doanduong] = string.Format("select {0},{1},{2} from {3} where {4}=N'{5}'", _tblName.TEN_DUONG.MA_DUONG, _tblName.TEN_DUONG.BAT_DAU, _tblName.TEN_DUONG.KET_THUC, DataNameTemplate.Ten_Duong, _tblName.TEN_DUONG.TEN_DUONG, cbxDuong.Text);
            //_dicSql.Add(EnumG1ArcGisTnRecType.Doanduong, );
            //_sql = string.Format("select {0},{1},{2} from {3} where {4}='a'", _fcName.FC_DUONG.MA_DUONG, _fcName.FC_DUONG.BAT_DAU, _fcName.FC_DUONG.KET_THUC, "sde.thixa_duong", _fcName.FC_DUONG.TEN_DUONG);
            //_dicSql.Add(EnumG1ArcGisTnRecType.Doanduong, "");
            _dicSql[EnumG1ArcGisTnRecType.Duong] = string.Format("select distinct {0} from {1}", _tblName.TEN_DUONG.TEN_DUONG, DataNameTemplate.Ten_Duong);
            //_dicSql.Add(EnumG1ArcGisTnRecType.Huyen, "");
            _dicSql[EnumG1ArcGisTnRecType.Xa] = string.Format("select {0},{1} from {2}", _fcName.FC_RANH_XA_POLY.MA_XA, _fcName.FC_RANH_XA_POLY.TEN_XA, DataNameTemplate.Ranh_Xa_Poly);
            //MessageBox.Show("line 126 CalculationView --" + type.ToString() + "\n " + _dicSql[EnumG1ArcGisTnRecType.Duong]);
            _loaderController.ReqLoad(type);
        }

        void IReceiverView.ReceiveData(System.Data.SqlClient.SqlDataReader data, EnumG1ArcGisTnRecType type)
        {
            //MessageBox.Show(string.Format("line 169 CalculationView, fild count={0},isclose{1}", data.FieldCount, data.IsClosed));
            #region load doan duong
            _lstDoanDuong = new XPair();
            if (type == EnumG1ArcGisTnRecType.Doanduong)
            {

                string doanduong = "";
                string batdau = "";
                string ketthuc = "";
                while (data.Read())
                {

                    if (data.HasRows)
                    {
                        if (data.IsDBNull(1))
                        {
                            batdau = "...";
                        }
                        else
                        {
                            batdau = data.GetString(1);
                        }
                        if (data.IsDBNull(2))
                        {
                            ketthuc = "...";
                        }
                        else
                        {
                            ketthuc = data.GetString(2);
                        }
                        doanduong = string.Format("Từ {0} đền {1}", batdau, ketthuc);
                        _lstDoanDuong.NewPair(int.Parse(data.GetValue(0).ToString()), doanduong);
                    }
                }
            }
            #endregion

            #region load duong
            else if (type == EnumG1ArcGisTnRecType.Duong)
            {
                _lstDuong = new XPair();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        _lstDuong.NewPair(0, data.GetString(0));
                    }
                }
                //MessageBox.Show(string.Format("line 178 CalculationView, lstDuong cout:{0}", _lstDuong.ListPair.Count));
            }
            #endregion

            #region load xa
            else if (type == EnumG1ArcGisTnRecType.Xa)
            {
                _lstXa = new XPair();
                while (data.Read())
                {

                    if (data.HasRows)
                    {
                        _lstXa.NewPair(int.Parse(data.GetValue(0).ToString()), data.GetString(1));
                    }
                }
            }
            #endregion
        }

        void IReceiverView.Reload()
        {
            throw new NotImplementedException();
        }

        string IReceiverView.Sql
        {
            get
            {
                return this._sql;
            }
            set
            {
                this._sql = value;
            }
        }

        #endregion

        #region su kien thay doi khu vuc tinh

        private void cbxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxXa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxXa.Text != "...")
            {
                cbxDoanDuong.SelectedIndex = 0;
                cbxDuong.SelectedIndex = 1;
            }
        }

        private void cbxDoanDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDoanDuong.Text != ".Tất cả.")
            {
                //cbxDuong.Text = "...";
                cbxXa.Text = "...";
            }
        }

        //Neu duong thay doi thi load lai doan duong
        private void cbxDuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDuong.Text == ".Tất cả." || cbxDuong.Text == "...")
            {
                //cbxDoanDuong.Properties.Items.Clear();
                //cbxDoanDuong.Properties.Items.Add(".Tất cả.");
                cbxDoanDuong.SelectedIndex = 0;
            }
            else
            {
                cbxXa.Text = "...";
                _dicSql[EnumG1ArcGisTnRecType.Doanduong] = string.Format("select {0},{1},{2} from {3} where {4}=N'{5}'", _tblName.TEN_DUONG.MA_DUONG, _tblName.TEN_DUONG.BAT_DAU, _tblName.TEN_DUONG.KET_THUC, DataNameTemplate.Ten_Duong, _tblName.TEN_DUONG.TEN_DUONG, cbxDuong.Text);
                ((IReceiverView)this).Load(EnumG1ArcGisTnRecType.Doanduong);
            }


        }

        private void btnHelpFrmAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("help me");
        }

        private void btnTinhFrmAll_Click(object sender, EventArgs e)
        {
            _calc = new Executor();
            _calcView = (ICalculationView)this;
            //con cai dat config
            //...
            setValue4InputParams();
            _calcView.SetInputParams(_inputParams);

            //CalculatingMonitor f = new CalculatingMonitor();
            _calc.AddMonitors(this._lstMonitor);
            _calcController = new CalculationController(_calcView, _calc);
            //MessageBox.Show("bat dau tinh");
            //MessageBox.Show(_lstMonitor.Count.ToString());
            foreach (ICalculationMonitor m in this._lstMonitor)
            {

                m.Show();

            }
            //MessageBox.Show(string.Format("GCalculationView - so luong monitor:{0}", _lstMonitor.Count));
            _calcController.ReqStart();

        }

        private void setValue4InputParams()
        {
            this._inputParams = InputParams.CallMe();
            this._currentConfig = CurrentConfig.CallMe();
            _inputParams.TINH_THUA_RIENG_LE = 0;
            if (cbxXa.Text == ".Tất cả.")
            {
                _inputParams.MA_XA = "*";
            }
            else
            {
                _inputParams.MA_XA = _lstXa.FindId(cbxXa.Text).ToString();
            }
            if (cbxDuong.Text == ".Tất cả.")
            {
                _inputParams.TEN_DUONG = "*";
            }
            else
            {
                _inputParams.TEN_DUONG = cbxDuong.Text;
            }
            if (cbxDoanDuong.Text == ".Tất cả.")
            {
                _inputParams.MA_DUONG = "-1";
            }
            else
            {
                _inputParams.MA_DUONG = _lstDoanDuong.FindId(cbxDoanDuong.SelectedIndex - 1).ToString();
            }
            //_currentConfig.NamApDung = spnNam.EditValue.ToString();
            //_inputParams.CURRENT_CONFIG.NamApDung = spnNam.EditValue.ToString();
            //MessageBox.Show(string.Format("maxa={0}, tenduong={1},maduong={2}", _inputParams.MA_XA, _inputParams.TEN_DUONG, _inputParams.MA_DUONG));
            if (chkOverWrite.CheckState == CheckState.Checked)
            {
                _inputParams.OVER_WRITE_ATT = true;
            }
            else if (chkOverWrite.CheckState == CheckState.Unchecked)
            {
                _inputParams.OVER_WRITE_ATT = false;
            }

            //lay curentconfig
            //IConfigReader configReader = new ConfigReader(_currentConfig);
            //configReader.Read(TnSystemFileName.PARAMS, spnNam.EditValue.ToString());
            //MessageBox.Show(_currentConfig.DBufferMattien.ToString());
            //MessageBox.Show(_inputParams.CURRENT_CONFIG.DBufferMattien.ToString());
        }

        #endregion

        private void putValueIntoCbxDoanDuong()
        {
            if (_lstDoanDuong == null)
            {
                return;
            }
            cbxDoanDuong.Properties.Items.Clear();
            cbxDoanDuong.Properties.Items.Add(".Tất cả.");
            foreach (XPair.pair x in _lstDoanDuong.ListPair)
            {
                cbxDoanDuong.Properties.Items.Add(x.Name);
            }
            cbxDoanDuong.SelectedIndex = 0;
            cbxDoanDuong.Properties.Sorted = true;
        }

        private void putValueIntoCbxDuong()
        {
            //MessageBox.Show("dang load duong");
            //this.SuspendLayout();
            //this.controlContainer7.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            //this.groupControl2.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            //this.groupControl4.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            //this.panelControl4.SuspendLayout();
            //this.xtraScrollableControl3.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.cbxDuong.Properties)).BeginInit();
            //this.Show();
            if (_lstDuong == null)
            {
                return;
            }
            cbxDuong.Properties.Items.Clear();
            cbxDuong.Properties.Items.Add("...");
            cbxDuong.Properties.Items.Add(".Tất cả.");
            foreach (XPair.pair x in _lstDuong.ListPair)
            {
                cbxDuong.Properties.Items.Add(x.Name);
            }
            cbxDuong.SelectedIndex = 0;
            cbxDuong.Properties.Sorted = true;

            cbxDoanDuong.Properties.Items.Clear();
            cbxDoanDuong.Properties.Items.Add(".Tất cả.");
            //this.ResumeLayout(false);
            //this.controlContainer7.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            //this.groupControl2.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            //this.groupControl4.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            //this.panelControl4.ResumeLayout(false);
            //this.xtraScrollableControl3.ResumeLayout(false);
            //this.xtraScrollableControl3.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this.cbxDuong.Properties)).EndInit();
        }

        private void putValueIntoCbxXa()
        {

            if (_lstXa == null)
            {
                return;
            }
            cbxXa.Properties.Items.Clear();
            cbxXa.Properties.Items.Add("...");
            cbxXa.Properties.Items.Add(".Tất cả.");
            foreach (XPair.pair p in _lstXa.ListPair)
            {
                cbxXa.Properties.Items.Add(p.Name);
            }
            cbxXa.SelectedIndex = 1;
            cbxXa.Properties.Sorted = true;


        }

        private void btnCloseFrmTinhAll_Click(object sender, EventArgs e)
        {
            //cbxDuong.Properties.Items.Add("...");
            //cbxXa.SelectedIndex = 1;
            putValueIntoCbxDuong();
        }


        #region IReceiverView Members

        IDictionary<EnumG1ArcGisTnRecType, string> IReceiverView.DicSQL
        {
            get { return this._dicSql; }
        }

        void IReceiverView.SetSql(EnumG1ArcGisTnRecType type, string sql)
        {
            _dicSql[type] = sql;
        }

        void IReceiverView.SetTableName(EnumG1ArcGisTnRecType type, string tableName)
        {
            _dicTableName[type] = tableName;
        }

        IDictionary<EnumG1ArcGisTnRecType, string> IReceiverView.DicTableName
        {
            get { return this._dicTableName; }
        }

        IDictionary<EnumG1ArcGisTnRecType, string> IReceiverView.DicColsName
        {
            get { return this._dicColsName; }
        }

        void IReceiverView.SetColsName(EnumG1ArcGisTnRecType type, string colsName)
        {
            this._dicColsName[type] = colsName;
        }

        IDictionary<EnumG1ArcGisTnRecType, string> IReceiverView.DicColsNameInWhereClause
        {
            get { return this._dicColsNameInWhereClause; }
        }

        void IReceiverView.SetColsNameInWhereClause(EnumG1ArcGisTnRecType type, string colsName)
        {
            this._dicColsNameInWhereClause[type] = colsName;
        }

        #endregion

        #region IDatabaseInteractive Members

        ITnFeatureClassName IDatabaseInteractive.TnFcName
        {
            get
            {
                return this._fcName;
            }
            set
            {
                this._fcName = value;
            }
        }

        ITnTableName IDatabaseInteractive.TnTbName
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICalculationView Members


        List<object> ICalculationView.Tasks
        {
            get
            {
                return this.tvcLoaiThua.ListNodeChecked;
            }
        }

        #endregion

        #region ICalculationView Members

        void ICalculationView.AddMonitor(ICalculationMonitor monitor)
        {
            //this._monitor = monitor;

            //if (this._lstMonitor.Exists(existMonitor))
            //{
            //    return;
            //}
            //else
            //{

            this._lstMonitor.Add(monitor);
            //}
        }
        private bool existMonitor()
        {
            if (this._lstMonitor.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (ICalculationMonitor m in this._lstMonitor)
                {
                    if (_monitor.Name == m.Name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        #endregion

        #region ICalculationView Members


        void ICalculationView.AddMonitors(List<ICalculationMonitor> monitors)
        {
            this._lstMonitor = monitors;
        }

        #endregion


        #region ICalculationView Members


        int ICalculationView.MonitorCount()
        {
            return this._lstMonitor.Count;
        }

        #endregion

        private void btnOptionCalcView_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show(Cursor.Position);
        }

        private void mniOpenStatus_Click(object sender, EventArgs e)
        {
            if (this._lstMonitor.Count == 0)
            {
                return;
            }
            foreach (ICalculationMonitor m in this._lstMonitor)
            {
                if (m == null)
                {
                    continue;
                }
                m.Show();

            }
        }
    }
}
