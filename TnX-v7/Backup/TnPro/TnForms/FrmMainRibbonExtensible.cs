using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Collections;
using TNPro.PluginManagement;
using System.Security;
using ExtensibleAPI;
using System.IO;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using ESRI.ArcGIS.Geodatabase;

using ExtensionAPI;
//using com.g1.Controller.UiControl;
using com.g1.arcgis.tn.landprice;

//using gov.tn.TnDatabaseStructure;
using TNPro.Danhmuc;
using com.g1.arcgis.connection;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.calculation;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using com.g1.arcgis.database;
using com.g1.arcgis.tn.map;
using TNPro.Quydinh;
using com.g1.arcgis.landprice;
using com.g1.arcgis.edit;
using com.g1.arcgis.map;
using ESRI.ArcGIS.Carto;
using com.g1.arcgis.query;
//using GCommands;
using com.g1.arcgis.thematic;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.tn.config;
using com.g1.arcgis.attribute;
using com.g1.arcgis.tn.query;
using com.g1.arcgis.dataManagement;
using gov.tn.system;
using com.g1.arcgis.database.versioning;
using ESRI.ArcGIS.esriSystem;
using com.g1.arcgis.tn.algorithm;
using com.g1.arcgis.algorithm;
using com.g1.arcgis.tn.calculation.fulfil;
using TNPro.Properties;

namespace TNPro.TnForms
{
    public partial class FrmMainRibbonExtensible : DevExpress.XtraBars.Ribbon.RibbonForm,IMainSwitch,IConfigView,IParamSwitch
    {
        //ko dung singleton
        #region singleton
        //private static FrmMainRibbonExtensible meForm = new FrmMainRibbonExtensible();
        //private static bool isShown = false;
        //public static FrmMainRibbonExtensible CallMe()
        //{
        //    return meForm;
        //}

        //public new void Show()
        //{
        //    if (isShown)
        //    {
        //        base.Show();
        //    }
        //    else
        //    {
        //        base.Show();
        //        isShown = true;
        //    }

        //}

        //static FrmMainRibbonExtensible()
        //{
        //    meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        //}

        //static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Bạn muốn thoát khỏi chương trình", "Thoát", MessageBoxButtons.OKCancel);
        //    if (result == DialogResult.OK)
        //    {
        //        Application.ExitThread();
        //        Application.Exit();

        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //        isShown = false;
        //        meForm.Hide();
        //    }
        //}
        #endregion

        #region member
        private ITnTableName _tblName;
        private ITnFeatureClassName _fcName;
        //dung cho connection
        #region connection
        private static bool _isConnected = false;
        //private ISdeUserInfo _sdeUserInfo;
        //private ISqlUserInfo _sqlUserInfo;
        //private IUserInfoController _userInfoController;
        //private IConnectionInfoController _connectionController;
        //private IConnectionView _connView;
        #endregion

        //dung de tinh gia dat
        #region tinh gia dat
        ICalculation _calc;
        IInputParams _inputParams;
        ICalculationView _calcView;
        ICalculationController _calcController;

        ICalculationView _calcHemView;
        ICalculationController _calcHemController;
        #endregion

        //private ITnFeatureClassName _fcName;
        //dung de luu cac plugin
        #region member for plugin
        Hashtable instantiatedDocumentPluginTypes = new Hashtable();
        Hashtable instantiatedPageGroupPluginTypes = new Hashtable();
        Hashtable instantiatedBarButtonPluginTypes = new Hashtable();
        private BarButtonItem menuFileAddFullTrust;
        #endregion

        //danh cho xem gia dat
        #region member of xem gia dat
        private int _curRowSelected = 0;
        private string _curOid = "1";
        private GridView _currentGridView = null;
        private string _curTable = "";
        private static ITable tblPnnD;
        private static ITable tblPnnNt;
        private static ITable tblNn;
        private static ITable tblThua;
        private bool _lockedPrice = false;
        //private TnXemGiaDatController xemController;
        //private ILandpriceDetailView xemGiaDatView;
        private ILandpriceView _xemVungGiaDatTinh;
        private ILandpriceView _xemVungGiaDatCongBo;
        //IEditTableView _editGiadat;
        #endregion

        //danh cho ban do
        #region member for map
        IMapViewController _mapViewController;
        IMapView _mapView;
        ILayersView _layersView;
        IGMap _map;

        //IMapView _mapView4thua;
        //IGMap _map4Thua;
        //IMapViewController _mapController4Thua;
        //ILayersView _layersView4Thua;
        //Landprices _landPriceTool;
        private IMapContextMenu _mapContextMenu;
        IMapControl3 _mapControl;
        ITOCControl2 _tocControl;
        #endregion

        //danh cho cac quy dinh
        #region member for rule
        private ICurrentConfig _curConfig;
        private IOpenConfigView _openConfigView;
        private ISaveConfigView _saveConfigView;
        private List<IConfigView> _lstConfigView;

        private IConfigView _datNnConfigView;
        private IConfigView _datPnnntConfigView;
        private IConfigView _datPnnDtConfigView;
        private IConfigView _allConfigView;
        #endregion

        private ILandpriceView _calcLandView;
        private ILandpriceView _publicLandView;
        private IEditPositionParamsView _editPosView;

        #endregion

        #region constructor
        public FrmMainRibbonExtensible()
        {
            
            InitializeComponent();
            //_fcName=new TnFeatureClassName()
            //this.dpnTinhGiaDatAll.
            initFiles();
            iniConnectionMvc();
            
            iniMapController();
            initParams();
            setupControllers();

            _calcLandView = FrmLandPriceInfo.CallMe.GetView();
            _publicLandView = FrmLandPriceInfoPublic.CallMe.GetView();
            _calcLandView.SetCalcMethodBuilderView(FrmCalcMethodBuilder.CallMe.GetView());
            _publicLandView.SetCalcMethodBuilderView(FrmCalcMethodBuilder.CallMe.GetView());

            _calcMoniorForAtt = (ICalculationMonitor)this.gCalculatingView1;
            _executorForAtt = new Executor(_calcMoniorForAtt);
            _calcControllerForAtt = new CalculationController();
        }

        private void initFiles()
        {
            //khoi tao file cac thong so tinh gia
            try
            {
                _curConfig = CurrentConfig.CallMe();
                IConfigReader confReader = new ConfigReader(_curConfig);
                confReader.CreateDefaultConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("line 219 Main: ex="+ex.ToString());
            }
        }

        private void iniMapController()
        {
            this._map = new GMap() ;
            this._mapView = (IMapView)this.gMapView1;
            this._layersView = (ILayersView)this.gLayersView1;
            this._mapView.SetParentDockControl(this.dpnMap4Thua);
            //FrmLandPriceInfo frmLandPriceView = FrmLandPriceInfo.CallMe;
            _xemVungGiaDatTinh = FrmLandPriceInfo.CallMe.GetView();
            _xemVungGiaDatTinh.Config = CurrentConfig.CallMe();
            _xemVungGiaDatCongBo = FrmLandPriceInfoPublic.CallMe.GetView();
            _xemVungGiaDatCongBo.Config = CurrentConfig.CallMe();
            this._mapView.SetLandpriceView("giadatcongbo", _xemVungGiaDatCongBo);
            this._mapView.SetLandpriceView("giadatdatinh",_xemVungGiaDatTinh);
            this._mapView.SetCalcMethodBuilderView(FrmCalcMethodBuilder.CallMe.GetView());

            _editPosView = FrmSetPositionParam.CallMe;
            _mapView.EditPosView = _editPosView;

            this._mapViewController = new MapViewController(this._mapView, this._layersView, this._map);
            
            this._mapControl=(IMapControl3)this._map.GetHook();
            this._tocControl = this._layersView.GetTocControl();
            
            //this._map4Thua = new GMap();
            //this._mapView4thua = this.gMapView1 as IMapView;
            //this._mapView4thua.SetParentDockControl(this.dpnMap4Thua);
            
            //this._layersView4Thua = this.gLayersView1 as ILayersView;
            //this._mapController4Thua = new MapViewController(this._mapView4thua, this._layersView4Thua, this._map4Thua);
            //this._mapView4thua.SetController(this._mapController4Thua);

            //_landPriceTool = new Landprices();
            //_landPriceTool.XemGiaDat += new Landprices.XemGiaDatEventHandler(landPriceTool_Changed);
            //_mapContextMenu = new MapContextMenu(_mapControl);
            //_mapContextMenu.AddItem(_landPriceTool, false, -1);
            //this._mapView.ContextMenu.AddItem(_landPriceTool,false,-1);
        }

        private string _mathua4LandPrice = "";
        void landPriceTool_Changed(object sender, EventArgs e)
        {
            //_mathua4LandPrice = _landPriceTool.GetMaThua();
            //MessageBox.Show(string.Format("so luong select:{0}",m_mapControl.Map.SelectionCount));
            //ISelection l = m_mapControl.Map.;
            ESRI.ArcGIS.esriSystem.UID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            IEnumLayer layers = ((IMapControl3)_map.GetHook()).Map.get_Layers(null, false);
            ILayer layer = null;
            IFeatureLayer ftl = new FeatureLayerClass();
            ISelectionSet sls = null;
            IFeatureSelection fts = null;
            int c = 0;
            if (layers.Next() == null)
            {
                MessageBox.Show(string.Format("ko co layer: {0}", ((IMapControl3)_map.GetHook()).Map.LayerCount));
            }

            //while ((layer = layers.Next()) != null)
            //{
            //    ftl=(IFeatureLayer)layer;
            //    fts=(IFeatureSelection)ftl;
            //    c=fts.SelectionSet.Count;
            //    if (c != 0)
            //    {
            //        MessageBox.Show(string.Format("layer:{0}, selected:{1}", ftl.FeatureClass.AliasName, c));
            //    }
            //}
            //xemGiaDatView.MaThua = _mathua4LandPrice;
            //xemGiaDatView.Show();
            //xemGiaDatView.Query();

        }

        private void iniConnectionMvc()
        {
            
        }

        private void setupControllers()
        {
            //xemGiaDatView = this.gTableLandPriceView1 as ILandpriceDetailView;
            //xemGiaDatView.SetGridViews(this.grvTgdNn, this.grvTgdPnnNt, this.grvTgdPnnDt);
            //TnThongTinThuaDat thongTinThua = new TnThongTinThuaDat() ;
            //xemController=new TnXemGiaDatController(xemGiaDatView,thongTinThua);
            //xemGiaDatView.SetParentControl(this.dpnXemGiaDatTatCa);
            //xemGiaDatView.SetTablesName("sde.thua_giadat_nn", "sde.thua_giadat_pnn_nongthon", "sde.thua_giadat_pnn_dothi");
            //_editGiadat = (IEditTableView)xemGiaDatView;
            //xemGiaDatView.SetMapView(this._mapView4thua);

            _calcView = (ICalculationView)this.gCalculationView1;

            ((ICalculationMonitor)this.gCalculatingView1).SetParentControl(dpnDangTinhGiaTatCa);
            ((ICalculationMonitor)this.gCalculatingView1).SetDetailView(FrmLandPriceInfo.CallMe.GetView(),FrmLandPriceInfoPublic.CallMe.GetView());
            //((ICalculationMonitor)this.gCalculatingView1).SetDetailView(xemGiaDatView);
            if (_calcView.MonitorCount() == 0)
            {
                _calcView.AddMonitor((ICalculationMonitor)this.gCalculatingView1);
            }

            //gan ban do cho form tim kiem
            ((IQueryThuaView)gQueryInfoThuaView1).SetMapView(this._mapView);
            //((IQueryThuaView)gQueryInfoThuaView1).SetLandpriceView(this.xemGiaDatView);

            _calcHemView = (ICalculationView)this.gCalculationHemView1;
            if (_calcHemView.MonitorCount() == 0)
            {
                _calcHemView.AddMonitor((ICalculationMonitor)this.gCalculatingView1);
            }
        }
        #endregion

        #region plugins
        public void LoadPlugins(object data)
        {
            LoadPluginsHelper(PluginTrustLevel.Full);
            try
            {
                LoadPluginsHelper(PluginTrustLevel.Semi);
            }
            catch (SecurityException) { }
        }

        void LoadPluginsHelper(PluginTrustLevel level)
        {
            Type[] types;
            types = PluginManager.LoadPluginTypes(
               level, PluginCriteria.Interface,
               typeof(IPageGroupProvider));

            InstantiateUIElements(types, instantiatedPageGroupPluginTypes,
               new UpdateUICallback(UpdatePageGroup), true);

            types = PluginManager.LoadPluginTypes(
               level, PluginCriteria.Interface,
               typeof(IBarButtonProvider));

            InstantiateUIElements(types, instantiatedBarButtonPluginTypes,
               new UpdateUICallback(UpdateBarButton), true);

            //types = PluginManager.LoadPluginTypes(
            //   level, PluginCriteria.BaseClass,
            //   typeof(DocumentForm));

            //InstantiateUIElements(types, instantiatedDocumentPluginTypes,
            //   new UpdateUICallback(UpdateDocument), false);
        }

        private void InstantiateUIElements(Type[] menuProviderTypes,
      Hashtable keys, UpdateUICallback callback, Boolean instantiate)
        {
            foreach (Type t in menuProviderTypes)
            {
                if (!keys.ContainsKey(t))
                {
                    keys.Add(t, null);
                    object provider;
                    if (instantiate)
                    {
                        provider = PluginManager.CreateInstance(t);
                    }
                    else
                    {
                        provider = t;
                    }
                    BeginInvoke(callback, new object[] { provider });
                }
            }
        }
        delegate void UpdateUICallback(object provider);
        private void UpdatePageGroup(object provider)
        {
            this.rbpExtension.Groups.AddRange(((IPageGroupProvider)provider).GetPageGroups());
            //menuMain.MenuItems.AddRange(
            //   ((IMenuProvider)provider).GetMenuItems());
        }

        private void UpdateBarButton(object parameter)
        {
            IBarButtonProvider provider = (IBarButtonProvider)parameter;
            //this.SuspendLayout();
            //int l = provider.GetBarButtons().Length;
            //for (int i = 0; i < l; i++)
            //{
            //    provider.GetBarButtons()[i].LargeGlyph = global::TNPro.Properties.Resources.plugin_template_48;
            //}
            this.rpgExtPlugins.ItemLinks.AddRange(provider.GetBarButtons());
            //this.ResumeLayout(false);
            //ToolBar bar = new ToolBar();
            //bar.Buttons.AddRange(provider.GetBarButtons());
            //bar.ButtonClick += new ToolBarButtonClickEventHandler(
            //   provider.OnToolBarButtonClick);
            //bar.Dock = DockStyle.Top;
            //bar.Enabled = true;
            //Controls.Add(bar);
        }

        private void UpdateDocument(object parameter)
        {
            //MenuItem item = new TypeMenuItem((Type)parameter, this);
            //menuFileNew.MenuItems.Add(item);
            //menuFileNew.Enabled = true;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
         //   PluginTrustLevel level =
         //(sender == this.menuFileAddFullTrust) ? PluginTrustLevel.Full : PluginTrustLevel.Semi;
            String[] dlls = InstallPluginDLLs(PluginTrustLevel.Full);
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadPlugins));
        }
        //#region Lien quan den plugin
        private String[] InstallPluginDLLs(PluginTrustLevel trustLevel)
        {
            // File dialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plugin Files (*.dll)|*.dll";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            String copyToPath;
            if (trustLevel == PluginTrustLevel.Full)
            {
                copyToPath = PluginManager.FullTrustPath;
                dialog.Title = "Select Plugin DLL to Install Fully-Trusted";
            }
            else
            {
                copyToPath = PluginManager.SemiTrustPath;
                dialog.Title = "Select Plugin DLL to Install Semi-Trusted";
            }
            dialog.Multiselect = true;

            ArrayList list = new ArrayList();
            DialogResult ret = STAShowDialog(dialog);
            if (ret == DialogResult.OK)
            {
                foreach (String dll in dialog.FileNames)
                {
                    String name = Path.GetFileName(dll);
                    if (!PluginAlreadyInstalled(name))
                    {
                        try
                        {
                            File.Copy(dll, Path.Combine(copyToPath, name));
                            list.Add(name);
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Unable to install dll: " + dll, "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Plugin dll already installed. To uninstall," +
                           " delete the .dll file from the Plugins directory.",
                           "Plugin Already Installed");
                    }
                }
            }
            return (String[])list.ToArray(typeof(String));
        }

        private Boolean PluginAlreadyInstalled(String dllFilename)
        {
            Boolean exists = false;
            String testFile = Path.Combine(PluginManager.FullTrustPath, dllFilename);
            exists = exists || File.Exists(testFile);
            testFile = Path.Combine(PluginManager.SemiTrustPath, dllFilename);
            exists = exists || File.Exists(testFile);
            return exists;
        }
        #endregion

        private IExecutor _executorForAtt;
        private ICalculationController _calcControllerForAtt;
        private ICalculationMonitor _calcMoniorForAtt;

        //Dung de hien thi dialog trong thread
        private DialogResult STAShowDialog(FileDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //BarButtonItem b1=new BarButtonItem();
            //BarButtonItem[] b=new BarButtonItem[]{b1};
            //this.rpgExtension.ItemLinks.AddRange(b);
            FrmUnInstallPlugins frmUn = new FrmUnInstallPlugins();
            frmUn.ShowDialog();
        }

        private void bbiXemGiaDat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!_isConnected)
            //{
            //    FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
            //    frb.ShowDialog();
            //    return;
            //}
            //xemGiaDatView.Show();
            FrmLandPriceInfo frm = FrmLandPriceInfo.CallMe;
            frm.ShowDialog();
        }
        
        private void grvTgdPnnDt_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //_currentGridView = grvTgdPnnNt;
            //_curRowSelected = e.RowHandle;
            //_curTable = _tableName.THUA_GIADAT_PNN_NONGTHON.NAME;
            //_curOid = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.OID]).ToString();
            //int lockedPrice=0;
            //bool result = int.TryParse(grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.LOCKED]).ToString(), out lockedPrice);
            //if (!result)
            //{
            //    lockedPrice = 0;
            //}
            //if (lockedPrice == 0)
            //{
            //    _lockedPrice = false;
            //    btnLock.ImageIndex = 0;
            //}
            //else
            //{
            //    _lockedPrice = true;
            //    btnLock.ImageIndex = 1;
            //}
            ////lay gia tri ma thua
            ////DataRow row= grvGiadatNongNghiep.GetDataRow(e.RowHandle);
            //string mathua = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.MA_THUA]).ToString();
            //string maduong = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.MA_DUONG]).ToString();
            //string nam = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.NAM_AP_DUNG]).ToString();
            //string socachtinh = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.SO_CACH_TINH]).ToString();
            //string cachtinh = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.CACH_TINH]).ToString();
            //string vitri = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.VI_TRI]).ToString();
            ////string khuvuc = grvGiadatNongNghiep.GetRowCellValue(e.RowHandle, grvGiadatNongNghiep.Columns[_tableName.THUA_GIADAT_NN]).ToString();
            //string dientich = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.DIEN_TICH]).ToString();
            //string giadat = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.GIA_DAT]).ToString();
            //string khuvuc = grvTgdPnnNt.GetRowCellValue(e.RowHandle, grvTgdPnnNt.Columns[_tableName.THUA_GIADAT_PNN_NONGTHON.MA_KHU_VUC]).ToString();
            //string[] cachtinhArr = cachtinh.Split('$');
            //string cachtinhSplited = "";
            //txtNam.Text = nam;
            //txtSoCachTinh.Text = socachtinh;
            //txtDienTich.Text = dientich;
            //txtViTri.Text = vitri;
            //txtGiaDat.Text = giadat;
            //txtKhuVuc.Text = khuvuc;
            //int i = 1;
            ////int len=cachtinhArr
            //foreach (string s in cachtinhArr)
            //{
            //    if (s.Length < 3)
            //    {
            //        continue;
            //    }
            //    cachtinhSplited += string.Format("{0}.{1}\n", i, s);
            //    i++;
            //}
            //rtbCachTinh.Text = cachtinhSplited;
        }

        #region ITnXemGiaDatView Members

        public void AddRowClickEvent(RowClickEventHandler evt)
        {
            //grvTgdPnnDt.RowClick += evt;
            //grvTgdNn.RowClick += evt;
            //grvTgdPnnNt.RowClick += evt;
        }

        #endregion

        #region cac su kien nut o muc he thong
        private void bbiConnectToDb_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FrmTnConnectToDatabase frmConn = FrmTnConnectToDatabase.CallMe;
            FrmConnection frm = FrmConnection.CallMe;
            IConnectionView connView = (IConnectionView)frm;
            connView.AddMainSwitch(this);
            connView.ShowDialog();
        }

        private void bbiAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTnAdmin frmAdmin = new FrmTnAdmin();
            frmAdmin.ShowDialog();
        }

        private void bbiChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTnThaydoiMatkhau frmChangePass = new FrmTnThaydoiMatkhau();
            frmChangePass.ShowDialog();
        }
        #endregion

        #region cac su kien nut cho muc danh muc
        private void bbiLoaiXa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //FrmTnListLoaiXa frmLoaiXa = FrmTnListLoaiXa.CallMe;
            FrmLoaiXa frmLoaiXa = new FrmLoaiXa();
            frmLoaiXa.ShowDialog();
        }

        private void bbiHem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmHem2 frmHem = new FrmHem2();
            frmHem.ShowDialog();

            //test
            //if (_isConnected)
            //{
            //    TestForm t = new TestForm();
            //    t.Show();
            //}
        }

        private void bbiLoaiDat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmLoaiDat ld = new FrmLoaiDat();
            ld.ShowDialog();
        }

        private void bbiKtvhxh_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FrmTnKtvhxh frmK=
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }
        #endregion

        #region form ConnectionDatabase

        #endregion

        #region IMainSwitch Members

        void IMainSwitch.TurnOff()
        {
            _isConnected=false;

            turnOffQuyDinh();
        }

        void IMainSwitch.TurnOn()
        {
            //ISdeConnectionInfo conn = new SdeConnection();
            //_fcName = new TnFeatureClassName(conn.Workspace);
            _isConnected=true;

            //turnOnQuyDinh();
            //((IDatabaseInteractive)this.dpnTinhGiaDatAll).TnFcName = _fcName;
            ((IReceiverView)this.gCalculationView1).Load(EnumG1ArcGisTnRecType.Xa);
            ((IReceiverView)this.gCalculationView1).Load(EnumG1ArcGisTnRecType.Duong);
            ((IReceiverView)this.gCalculationHemView1).Load(EnumG1ArcGisTnRecType.Xa);
            ((IReceiverView)this.gCalculationHemView1).Load(EnumG1ArcGisTnRecType.Duong);
            //load gia dat

            //_editGiadat.DbConnectOccur();

            //turnOnMaps();
            turnOnData();

            registerVersionedForAllLayer();
            //turnOnPanelTinhGiaAll();
        }

        private void registerVersionedForAllLayer()
        {
            if (!Settings.Default.ShowRegisterVersioned)
            {
                return;
            }
            FrmVerifyRegisterVersioned frm = new FrmVerifyRegisterVersioned();
            frm.ShowDialog();
            if (frm.ShowAgain)
            {
                Settings.Default.ShowRegisterVersioned = true;
            }
            else
            {
                Settings.Default.ShowRegisterVersioned = false;
            }
            Settings.Default.Save();
            if (!frm.OK)
            {
                MessageBox.Show("Bạn chưa đăng ký versioned cho dữ liệu");
                return;
            }
            ISdeVersionInfo _version;
            _version = SdeVersionsTool.CallMe();
            SdeConnection conn=new SdeConnection();
            ISdeConnectionInfo sdeConn=(ISdeConnectionInfo)conn;

            ISDETableQuery qrf = new SDETable();
            List<string> layers = qrf.GetLayersAndTables();
            foreach (string s in layers)
            {
                try
                {
                    ITable table = ((IFeatureWorkspace)sdeConn.Workspace).OpenTable(s);
                    _version.RegisterDataset((IDataset)table, true, true);
                }
                catch (Exception ex) { continue; }
            }
        }

        private void turnOnData()
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            _fcName = new TnFeatureClassName(sdeConn.Workspace);
            _tblName = new TnTableName(sdeConn.Workspace);
        }

        private void turnOnMaps()
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            string thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, this._curConfig.NamApDung);
            IFeatureClass fcThua = null;
            try
            {
                fcThua = fw.OpenFeatureClass(thuaName);
            }
            catch (Exception ex) { return; }
            IFeatureLayer flThua = new FeatureLayerClass();
            flThua.FeatureClass = fcThua;
            ILayer layerThua = (ILayer)flThua;
            IFeatureClass fcDuong = null;
            try
            {
                fcDuong = fw.OpenFeatureClass(DataNameTemplate.Duong);
            }
            catch (Exception ex) { return; }
            IFeatureLayer flDuong = new FeatureLayerClass();
            flDuong.FeatureClass = fcDuong;
            ILayer layerDuong = (ILayer)flDuong;
            layerDuong.Name = fcDuong.AliasName;
            layerThua.Name = fcThua.AliasName;
           
            _mapViewController.AddLayer(layerDuong);
            _mapViewController.AddLayer(layerThua);
        }

        private void turnOnPanelTinhGiaAll()
        {
            //string.Format("select {0},{1} from {2}.{3}", _fcName.FC_XA.MA_XA, _fcName.FC_XA.TEN_XA, TnConnectionInfo.DATABASE, "sde.THIXA_XAPOLY"));
            //((IReceiverView)this.dpnTinhGiaDatAll).SetTableName(EnumG1ArcGisTnRecType.Doanduong,)
            //((IReceiverView)this.dpnTinhGiaDatAll).SetSql(EnumG1ArcGisTnRecType.Duong,
            //    string.Format("select distinct {0} from {1}", _fcName.FC_DUONG.TEN_DUONG, "sde.thixa_duong"));
            //((IReceiverView)this.dpnTinhGiaDatAll).SetSql(EnumG1ArcGisTnRecType.Doanduong,
            //    string.Format("select {0},{1},{2} from {3} where {4}=N'{5}'", _fcName.FC_DUONG.MA_DUONG, _fcName.FC_DUONG.BAT_DAU, _fcName.FC_DUONG.KET_THUC, "sde.thixa_duong", _fcName.FC_DUONG.TEN_DUONG, v));
            //((IReceiverView)this.dpnTinhGiaDatAll).SetSql(EnumG1ArcGisTnRecType.Xa,
            //    string.Format("select {0},{1} from {2}", _fcName.FC_XA.MA_XA, _fcName.FC_XA.TEN_XA, "sde.THIXA_XAPOLY"));
            ////((IReceiverView)this.dpnTinhGiaDatAll).Sql = string.Format("select distinct {0} from {1}", _fcName.FC_DUONG.TEN_DUONG, "sde.thixa_duong");

            ((IReceiverView)this.gCalculationView1).Load(EnumG1ArcGisTnRecType.Duong);

        }

        private void turnOnQuyDinh()
        {
            this.beiK2MatTien.Edit.ReadOnly = false;
            this.spnK2MatTien.ReadOnly = false;
            this.spnK3MatTien.ReadOnly = false;
            this.spnK4MatTien.ReadOnly = false;
            this.spnGrDatNn.ReadOnly = false;
            this.spnGrDatPnnNt.ReadOnly = false;
            this.spnGrDatPnnDt.ReadOnly = false;
            //MessageBox.Show(this.spnK2MatTien.ReadOnly.ToString());
        }

        private void turnOffQuyDinh()
        {
            
            this.spnK2MatTien.ReadOnly = true;
            this.spnK3MatTien.ReadOnly = true;
            this.spnK4MatTien.ReadOnly = true;
            this.spnGrDatNn.ReadOnly = true;
            this.spnGrDatPnnNt.ReadOnly = true;
            this.spnGrDatPnnDt.ReadOnly = true;
        }

        #endregion

        #region su kien click cho muc cong cu

        private void bbiTimThuaBaseInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //dpnTimKiemTheoThua.Show();
            dpnTimKiemTheoThua2.Show();
        }

        private void bbiTimThuaTheoDuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void bbiThuaChon_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void bbiThuaNongNghiep_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void bbiThuaPnn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void bbiThuaPnnDt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void bbiThuaPnnNt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void bbiTinhHet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }

        private void rpgTinhGiaDat_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //MessageBox.Show(((ICalculationView)this.gCalculationView1).MonitorCount().ToString());
            
            
            dpnTinhGiaDatTatCa.Show();
        }

        private void rpgTimKiem_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }
        #endregion

        #region su kien click cho muc quy dinh

        private void initParams()
        {
            //_curConfig = CurrentConfig.CallMe();
            this._openConfigView = new FrmTnOpenParams();
            this._openConfigView.SetConfigView(this);
            this._saveConfigView = new FrmTnSaveParams();
            this._saveConfigView.SetConfigView(this);
            ((IConfigView)this).SetOpenAndSaveView(this._openConfigView, this._saveConfigView);

            _datNnConfigView = FrmQdNongNghiep.CallMe();
            _datPnnDtConfigView = FrmQdPnnDt.CallMe();
            _datPnnntConfigView = FrmQdPnnNt.CallMe();
            _allConfigView = FrmThongSoQuyDinh.CallMe;
            List<IConfigView> lst4Nn=new List<IConfigView>();
            List<IConfigView> lst4PnnNt = new List<IConfigView>();
            List<IConfigView> lst4PnnDt = new List<IConfigView>();
            List<IConfigView> lst4This = new List<IConfigView>();
            List<IConfigView> lst4All = new List<IConfigView>();
            IConfigView _this = this as IConfigView;
            lst4Nn.Add(_this);
            lst4Nn.Add(_datPnnDtConfigView);
            lst4Nn.Add(_datPnnntConfigView);
            lst4Nn.Add(_allConfigView);
            _datNnConfigView.SetBuddy(lst4Nn);

            lst4PnnNt.Add(_this);
            lst4PnnNt.Add(_datNnConfigView);
            lst4PnnNt.Add(_datPnnDtConfigView);
            lst4PnnNt.Add(_allConfigView);
            _datPnnntConfigView.SetBuddy(lst4PnnNt);

            lst4PnnDt.Add(_this);
            lst4PnnDt.Add(_datNnConfigView);
            lst4PnnDt.Add(_datPnnntConfigView);
            lst4PnnDt.Add(_allConfigView);
            _datPnnDtConfigView.SetBuddy(lst4PnnDt);

            lst4All.Add(_this);
            lst4All.Add(_datNnConfigView);
            lst4All.Add(_datPnnntConfigView);
            lst4All.Add(_datPnnDtConfigView);
            _allConfigView.SetBuddy(lst4All);

            lst4This.Add(_datPnnntConfigView);
            lst4This.Add(_datPnnDtConfigView);
            lst4This.Add(_datNnConfigView);
            lst4This.Add(_allConfigView);
            ((IConfigView)this).SetBuddy(lst4This);

           
        }

        private void bbiQdTinhGiaDatNn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            
            _datNnConfigView.ShowDialog();
        }

        private void bbiQdTinhGiaDatPnnDt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            
            _datPnnDtConfigView.ShowDialog();
        }

        private void bbiQdTinhGiaDatPnnNt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            
            _datPnnntConfigView.ShowDialog();
        }

        private void bbiMoQuyDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            this._openConfigView.ShowDialog();
        }

        private void bbiLuuBangQD_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            this._saveConfigView.ShowDialog();
        }

        private void bbiLuuBanSaoQd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
        }
        #endregion

        #region su kien thay doi khu vuc tinh

        private void cbxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxXa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxDoanDuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region su kien tren cac nut cua dpnTinhGiaDatAll

        private void btnTinhFrmAll_Click(object sender, EventArgs e)
        {
            //_calc=new Calculation

            //setValue4InputParams();
            //_calcView.SetInputParams(_inputParams);
            //_calcController = new CalculationController(_calcView, _calc);
            //_calcController.ReqStart();
        }


        private void btnCloseFrmTinhAll_Click(object sender, EventArgs e)
        {

        }

        private void btnHelpFrmAll_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region cac su kien cho muc ban do

        private void bbiAddLayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmAddLayers frmA = new FrmAddLayers();
            frmA.SetMapView(this._mapView);
            frmA.ShowDialog();
        }

        private void bbiBanDoGiaDat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ICommand command = new ControlsOpenDocCommandClass();
            //command.OnCreate(m_mapControl.Object);
            //command.OnClick();
            FrmThematic frmThematic = new FrmThematic();
            frmThematic.SetControls(_mapControl, _tocControl);
            frmThematic.ShowDialog();
            
        }

        private void bbiOpenMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._layersView.SetMapBuddy(this._mapView.GetMapObject());
            this._mapViewController.OpenMxd();           
        }

        private void bbiLayersW_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.dpnLayers.Show();
        }

        private void bbiSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.SelectFeature();
        }

        private void bbiClearSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.ClearSelected();
        }

        private void bbiZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.ZoomIn();
        }

        private void bbiZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.ZoomOut();
        }

        private void bbiFullExtent_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.FullExtent();
        }

        private void bbiSpan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.Pan();
        }

        private void bbiBackward_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.ZoomBackWard();
        }

        private void bbiForward_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.ZoomForWard();
        }

        private void bbiZoomToSelected_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.ZoomToSelected();
        }

        private void bbiSaveMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.SaveMxd();
        }

        private void bbiSaveAsMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.SaveAsMxd();
        }

        private void bbiNewMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.CreateNewMxd();
        }

        private void bbiCloseMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._mapViewController.CloseMxd();
        }

        #endregion

        private void bbiAlgorithm_ItemClick(object sender, ItemClickEventArgs e)
        {
            com.g1.arcgis.tn.calculation.XtraForm1 fr1 = new com.g1.arcgis.tn.calculation.XtraForm1();
            fr1.Show();
        }

        //public class MainSwitch : IMainSwitch
        //{

        //    #region IMainSwitch Members

        //    void IMainSwitch.TurnOff()
        //    {
                
        //        throw new NotImplementedException();
        //    }

        //    void IMainSwitch.TurnOn()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    #endregion
        //}

        #region IConfigView Members

        void IConfigView.LoadConfig()
        {
            this.beiK2MatTien.EditValue = _curConfig.K2MatTien;
            this.beiK3MatTien.EditValue = _curConfig.K3MatTien;
            this.beiK4MatTien.EditValue = _curConfig.K4MatTien;
            this.beiGrDatPnnNt.EditValue = _curConfig.DGrDatPnnNt;
            this.beiGrDatNn.EditValue = _curConfig.DGrDatNn;
            this.beiGrDatPnnDt.EditValue = _curConfig.DGrDatPnnDt;
            if (_curConfig.ChoPhepApGia != 0)
            {
                
                this.beiChoPhepApGia.EditValue = true;
            }
            else
            {
                this.beiChoPhepApGia.EditValue = false;
            }
            this.beiNamApDung.EditValue = _curConfig.NamApDung;
            this.txtStNam.EditValue = _curConfig.NamApDung;
            //MessageBox.Show(_curConfig.NamApDung);
            
        }

        void IConfigView.SaveConfig()
        {
            _curConfig.K2MatTien = double.Parse(this.beiK2MatTien.EditValue.ToString());
            _curConfig.K3MatTien = double.Parse(this.beiK3MatTien.EditValue.ToString());
            _curConfig.K4MatTien = double.Parse(this.beiK4MatTien.EditValue.ToString());
            _curConfig.DGrDatNn = double.Parse(this.beiGrDatNn.EditValue.ToString());
            _curConfig.DGrDatPnnDt = double.Parse(this.beiGrDatPnnDt.EditValue.ToString());
            _curConfig.DGrDatPnnNt = double.Parse(this.beiGrDatPnnNt.EditValue.ToString());
        }

        void IConfigView.SetOpenAndSaveView(IOpenConfigView openView, ISaveConfigView saveView)
        {
            this._openConfigView = openView;
            this._saveConfigView = saveView;
        }

        #endregion

        #region IConfigView Members


        void IConfigView.SetBuddy(List<IConfigView> buddies)
        {
            this._lstConfigView = buddies;
        }

        #endregion

        #region IConfigView Members


        void IConfigView.ShowDialog()
        {
            throw new NotImplementedException();
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

        #endregion

        #region IConfigView Members


        void IConfigView.Show()
        {
            //this.Show();
        }

        #endregion

        private void bbiGiaDatNn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmGiaDatNn giadatNn = new FrmGiaDatNn();
            giadatNn.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Form1 fr = new Form1();
            //fr.Show();
        }

        private void bbiEditParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            IXacNhan xn = new FrmXacNhan();
            xn.SetSwitch(this);
            xn.ShowDialog();
        }

        #region IParamSwitch Members

        void IParamSwitch.TurnOn()
        {
            turnOnQuyDinh();
        }

        void IParamSwitch.TurnOff()
        {
            turnOffQuyDinh();
        }

        #endregion

        private void bbiGiaDatPnnNt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmGiaDatPnnNt giadatNn = new FrmGiaDatPnnNt();
            giadatNn.ShowDialog();
        }

        private void bbiGiaDatPnnDt_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmGiaDatPnnDt giadatNn = new FrmGiaDatPnnDt();
            giadatNn.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiHesoVitri_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            ((IFrmMethodBuilderView)FrmCalcMethodBuilder.CallMe).SetParamsEditorView(FrmThongSoQuyDinh.CallMe);
            FrmCalcMethodBuilder.CallMe.ShowDialog();
            //builder.ShowDialog();
        }

        private void bbiTinhGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //MessageBox.Show(((ICalculationView)this.gCalculationView1).MonitorCount().ToString());


            dpnTinhGiaDatTatCa.Show();
        }

        #region mo cac bang thuoc tinh
        private void btnOpenLandpriceTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tgdName=string.Format("{0}_{1}",DataNameTemplate.Thua_Gia_Dat,_curConfig.NamApDung);
            attView.SetTitle(tgdName);
            attView.SetTableName(tgdName);
            attView.SetAliasFieldsName(_fcName.FC_THUA_GIADAT.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.CalcController = _calcControllerForAtt;
            attView.Executor = _executorForAtt;
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void btnOpenThuaTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}_{1}", DataNameTemplate.Thua, _curConfig.NamApDung);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_THUA.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.CalcController = _calcControllerForAtt;
            attView.Executor = _executorForAtt;
            attView.SetDetailView(_calcLandView, _publicLandView);


            attView.Show();
        }

        private void btnOpenDuongTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}", DataNameTemplate.Duong);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_DUONG.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void btnOpenHemTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}", DataNameTemplate.Hem);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_HEM.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void btnOpenXaPlTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}", DataNameTemplate.Ranh_Xa_Poly);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_RANH_XA_POLY.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        #endregion

        private void btnOpenKtvhxhTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}", DataNameTemplate.Ktvhxh);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_KTVHXH.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void btnOpenXaLiTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}", DataNameTemplate.Ranh_Xa_Line);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_RANH_XA_LINE.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void btnOpenTenDuongTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}", DataNameTemplate.Ten_Duong);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_tblName.TEN_DUONG.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void bbiImportFromXml_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmImportDataFromXml frm = new FrmImportDataFromXml();
            frm.ShowDialog();
            //SdeConnection conn=new SdeConnection();
            //ISdeConnectionInfo sdeConn=(ISdeConnectionInfo)conn;
            //string xmlDataFile = string.Format("{0}/{1}", "C:/tn/temp", "SDE_20120606.XML");
            //TranferDatabase.ImportFromXml(sdeConn.Workspace, xmlDataFile, false);
        }

        private void bbiRegisterVersioned_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //FrmImportDataFromXml frm = new FrmImportDataFromXml();
            registerVersionedForAllLayer();
        }

        private void bbiDeletFeatureClass_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            FrmDeleteLayers frm = new FrmDeleteLayers();
            frm.ShowDialog();
            
        }
        private static LicenseInitializer m_AOLicenseInitializer;
        private void FrmMainRibbonExtensible_Load(object sender, EventArgs e)
        {
            m_AOLicenseInitializer = new LicenseInitializer();
            //MessageBox.Show(string.Format("line 1568 Main: license:{0}", m_AOLicenseInitializer.InitializedProduct.ToString()));
            if (!m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeArcInfo }))
            {
                //MessageBox.Show(string.Format("line 1568 Main: license:{0}", m_AOLicenseInitializer.InitializedProduct.ToString()));
                Application.Exit();
            }
        }

        private void rpgThuaPnnNhieuMt_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            //if (!_isConnected)
            //{
            //    FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
            //    frb.SetMainView(this);
            //    frb.ShowDialog();
            //    return;
            //}
            //IParamsEditorView paramView = FrmThongSoQuyDinh.CallMe.GetView();
        }

        private void bbiAllParams_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //((IFrmParamsEditorView)_allConfigView).
            _allConfigView.ShowDialog();
            //FrmThongSoQuyDinh.CallMe.SetConfig(this._curConfig);
            //FrmThongSoQuyDinh.CallMe.ShowDialog();
        }

        private void btnBangGiaTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tgdName = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, _curConfig.NamApDung);
            attView.SetTitle(tgdName);
            attView.SetTableName(tgdName);
            attView.SetAliasFieldsName(_fcName.FC_THUA_GIADAT_DRAFT.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.CalcController = _calcControllerForAtt;
            attView.Executor = _executorForAtt;
            attView.SetDetailView(_calcLandView, _publicLandView);

            

            attView.Show();
        }

        private void bbiTinhGiaHem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            //MessageBox.Show(((ICalculationView)this.gCalculationView1).MonitorCount().ToString());


            dpnTinhGiaHemChinh.Show();
        }

        private void btnSelectByLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            _mapViewController.SelectByLocation();
        }

        private void btnGiaDatHemChinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem,_curConfig.NamApDung);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_GIA_DAT_HEM.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }

        private void btnGiaDatHemPhu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_isConnected)
            {
                FrmTnBridgeConnetion frb = FrmTnBridgeConnetion.CallMe;
                frb.SetMainView(this);
                frb.ShowDialog();
                return;
            }
            IAttributeView attView = new FrmAttribute();
            attView.SetParent(this);
            string tableName = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem_Phu, _curConfig.NamApDung);
            attView.SetTitle(tableName);
            attView.SetTableName(tableName);
            attView.SetAliasFieldsName(_fcName.FC_GIA_DAT_HEM_PHU.ALIAS_FIELD_LIST);
            attView.SetMapView(this._mapView);
            attView.SetDetailView(_calcLandView, _publicLandView);
            attView.Show();
        }
    }
    
}