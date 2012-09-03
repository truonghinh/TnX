using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.connection;
using gov.tn.system;
using gov.tn.TnDatabaseStructure;
using TNPro.Properties;

namespace TNPro.TnForms
{
    public partial class FrmConnection : DevExpress.XtraEditors.XtraForm,IConnectionView,ICurrentConnectionStatus
    {
        private bool _connectionOk = false;
        private string _sdeServiceName = "";
        private ISdeUserInfo _sdeUserInfo;
        private ISqlUserInfo _sqlUserInfo;
        private IUserInfoController _userInfoController;
        private IConnectionInfoController _connectionController;
        private IConnectionView _connView;
        private ISdeConnectionInfo _connSde;
        private IMainSwitch _mainSwitch;

        private static readonly FrmConnection meForm = new FrmConnection();
        private static bool isShown = false;
        private FrmConnection()
        {
            InitializeComponent();
            iniMvc();
            loadUserInfo();
        }

        #region singleton
        public static FrmConnection CallMe
        {
            get { return meForm; }
        }
        static FrmConnection()
        {
            meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            meForm.Hide();
        }

        public new void ShowDialog()
        {
            if (isShown)
            {
                base.ShowDialog();
            }
            else
            {
                isShown = true;
                base.ShowDialog();
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
                isShown = true;
                base.Show();
            }
        }
        #endregion

        private void loadUserInfo()
        {
            _userInfoController.ReqGetUserInfo(TnSystemFileName.UserInfoFile);
        }

        private void iniMvc()
        {
            //_connView = (IConnectionView)this;
            this._sdeUserInfo = new SdeUserInfo();
            this._userInfoController = new UserInfoController(_sdeUserInfo, this);
            this._connSde = new SdeConnection(this._sdeUserInfo);
            this._connectionController = new SdeConnectionController(this._connSde, this);
            this._connectionController.DoWork += new com.g1.arcgis.ChangedEventHandler(_connectionController_DoWork);
            //FrmMainRibbonExtensible fr = new FrmMainRibbonExtensible();

            //_mainSwitch = (IMainSwitch)fr;

        }

        void _connectionController_DoWork(object sender, EventArgs e)
        {
            if (this._connSde.IsConnecting)
            {
                
                DataNameTemplate.DbName = _sdeUserInfo.Db;
                //MessageBox.Show(DataNameTemplate.DbName);
                _mainSwitch.TurnOn();
            }
            else
            {
                _mainSwitch.TurnOff();
            }

        }

        #region IConnectionView Members

        void IConnectionView.Update(IUserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        string IConnectionView.Server
        {
            get
            {
                return this.txeMayChu.Text;
            }
            set
            {
                this.txeMayChu.Text = value;
            }
        }

        string IConnectionView.UserName
        {
            get
            {
                return this.txeNguoiDung.Text;
            }
            set
            {
                this.txeNguoiDung.Text = value;
            }
        }

        string IConnectionView.Pass
        {
            get
            {
                return this.txeMatKhau.Text;
            }
            set
            {
                this.txeMatKhau.Text = value;
            }
        }

        string IConnectionView.Db
        {
            get
            {
                return this.txeDatabase.Text;
            }
            set
            {
                this.txeDatabase.Text = value;
            }
        }

        string IConnectionView.Instance
        {
            get
            {
                return this.txeInstance.Text;
            }
            set
            {
                this.txeInstance.Text = value;
            }
        }

        string IConnectionView.Version
        {
            get
            {
                return this.cbeVersion.Text;
            }
            set
            {
                this.cbeVersion.Text = value;
            }
        }

        string IConnectionView.Sde_service
        {
            get
            {
                return this.txeSdeService.Text;
            }
            set
            {
                this.txeSdeService.Text = value;
            }
        }

        string IConnectionView.SavePass
        {
            get
            {
                return this.chkRememberPass.CheckState.ToString();
            }
            set
            {
                bool ch;
                bool r;
                r = Boolean.TryParse(value, out ch);
                if (!r)
                {
                    ch = false;
                }
                if (ch)
                {
                    this.chkRememberPass.CheckState = CheckState.Checked;
                }
                else
                {
                    this.chkRememberPass.CheckState = CheckState.Unchecked;
                }
            }
        }

        void IConnectionView.Connect()
        {
            throw new NotImplementedException();
        }

        void IConnectionView.Disconnect()
        {
            throw new NotImplementedException();
        }

        bool IConnectionView.IsConnecting()
        {
            throw new NotImplementedException();
        }

        void IConnectionView.CloseView()
        {
            this.Close();
        }

        void IConnectionView.NotifyConnectionStatus()
        {
            if (!this._connSde.IsConnecting)
            {
                MessageBox.Show(string.Format("khong ket noi duoc:\nserver:{0}, user:{1}, db:{2}, instance:{3}", this._sdeUserInfo.Server,
                    this._sdeUserInfo.UserName, this._sdeUserInfo.Db, this._sdeUserInfo.Instance));
                this.btnDisconnect.Enabled = false;
                this.btnDangNhap.Enabled = true;
                //this.btnOpenByFile.Enabled = true;
                this.Text = "Kết nối cơ sở dữ liệu - chưa kết nối";
            }
            else
            {
                this.btnDisconnect.Enabled = true;
                this.btnDangNhap.Enabled = false;
                //this.btnOpenByFile.Enabled = false;
                this.Text = "Kết nối cơ sở dữ liệu - đã kết nối";
            }
            this.Cursor = Cursors.Arrow;
            //repositoryItemMarqueeProgressBar1.MarqueeAnimationSpeed = 1000;
        }

        void IConnectionView.AddMainSwitch(IMainSwitch mainSwitch)
        {
            this._mainSwitch = mainSwitch;
        }

        #endregion

        #region ICurrentConnectionStatus Members

        bool ICurrentConnectionStatus.IsConnecting()
        {
            return _connectionController.IsConnecting();
        }

        #endregion

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(TnSystemFileName.UserInfoFile);
            this.btnDangNhap.Enabled = false;
            this.btnDisconnect.Enabled = false;

            this._userInfoController.ReqSetUserInfo(TnSystemFileName.UserInfoFile);
            //this._userInfoController.ReqCacheUserInfo();
            this._connectionController.ReqConnect();
            //this.btnOpenByFile.Enabled = false;
            
            //bgwCreateWorkspace.RunWorkerAsync();
        }

        #region IConnectionView Members


        void IConnectionView.ShowDialog()
        {
            this.ShowDialog();
        }

        #endregion

        private void bgwCreateWorkspace_DoWork(object sender, DoWorkEventArgs e)
        {
            this._userInfoController.ReqSetUserInfo(TnSystemFileName.UserInfoFile);
            //this._connectionController.ReqConnect();
            //this._connectionController.IsConnecting();
        }

        private void bgwCreateWorkspace_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._userInfoController.ReqCacheUserInfo();
            this._connectionController.ReqConnect();
            
            
        }

        private void chkSQLEdition_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSQLEdition.Checked)
            {
                txeInstance.Text = "sde:sqlserver:" + txeMayChu.Text;
            }
            else
            {
                txeInstance.Text = "";
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("ngat");
        }
    }
}