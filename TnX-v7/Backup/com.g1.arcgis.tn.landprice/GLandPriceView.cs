using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.landprice;
using DevExpress.XtraBars.Docking;
using com.g1.arcgis.calculation;
using com.g1.arcgis.map;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.connection;
using gov.tn.TnDatabaseStructure;
using ESRI.ArcGIS.Carto;
using com.g1.arcgis.util.queryString;
using com.g1.arcgis.database;
using System.Runtime.InteropServices;
using com.g1.arcgis.edit;
using com.g1.arcgis.algorithm;
using com.g1.arcgis.tn.config;

namespace com.g1.arcgis.tn.landprice
{
    public partial class GLandPriceView : XtraUserControl,ILandpriceView,IEditView,ICalculationView,ICallerHskView
    {
        private double _landprice;
        private double _area;
        private double _landpriceWithArea;
        private object _mathua;
        private int _lockStatus;
        private object _thuaId;
        private ILandpriceController _controller;
        private ILandprice _engine;
        private XtraForm _containerForm;
        private DockPanel _containerDockpanel;
        private ICurrentConfig _conf;
        private List<ThuaGiaDatInfo> _thuaGiaDatInfo;
        private IMapView _mapView;
        private SdeConnection _conn;
        private ISdeConnectionInfo _sdeConn;
        private IFeatureWorkspace _fw;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        private IDataManager _dataManager;
        private string _tgdName = "";
        private string _landpriceName = "";
        private string _thuaName = "";
        private bool _isEditting = false;
        private bool _isSaved = true;
        private List<object[,]> _pairColValTgd = new List<object[,]>();
        private List<object[,]> _pairColValThua = new List<object[,]>();
        private object _currentThuaGiaDatId;
        private ICalcMethodBuilderView _calcMethodBuilder;
        private IInputParams _inputParams;
        private ICalculation _calc;
        private ICalculationView _calcView;
        private ICalculationController _calcController;
        private IExecutor _executor;
        private List<ICalculationMonitor> _lstMonitor;
        private ThuaGiaDatInfo _currentThuaGiaDatInfo;
        public GLandPriceView()
        {
            InitializeComponent();
            _engine = new GLandprice();
            _engine.SetView(this);
            _controller = new GLandpriceController(_engine,this);

            _mapView = this.gMapView1;
            //this._mapView.SetLandpriceView(this);
            _landpriceName = DataNameTemplate.Thua_Gia_Dat_Draft;
            this._inputParams = InputParams.CallMe();
        }

        private void setValue4InputParams()
        {
            findDetail(_currentThuaGiaDatInfo);
            _inputParams.CURRENT_CONFIG = _conf;
            _inputParams.TINH_THUA_RIENG_LE = 1;
            //_calc.AddMonitors(this._lstMonitor);
            //_inputParams.MA_XA=_thuaGiaDatInfo.
        }
        
        private void btnOption_Click(object sender, EventArgs e)
        {
            mnuOption.Show(System.Windows.Forms.Cursor.Position);
        }

        #region ILandpriceView Members

        double ILandpriceView.CurrentLandprice
        {
            get
            {
                return _landprice;
            }
            set
            {
                _landprice=value;
            }
        }

        double ILandpriceView.CurrentArea
        {
            get
            {
                return _area;
            }
            set
            {
                _area=value;
            }
        }

        double ILandpriceView.CurrentLandpriceWithArea
        {
            get
            {
                return _landpriceWithArea;
            }
            set
            {
                _landpriceWithArea=value;
            }
        }

        int ILandpriceView.CurrentLockStatus
        {
            get
            {
                return _lockStatus;
            }
            set
            {
                _lockStatus=value;
            }
        }


        void ILandpriceView.LoadForm()
        {
            _controller.LoadPrice();
        }

        void ILandpriceView.LoadPrice()
        {
            if (_conn == null)
            {
                _conn = new SdeConnection();
                _sdeConn = (ISdeConnectionInfo)_conn;
                _fw = (IFeatureWorkspace)_sdeConn.Workspace;
                _fcName = new TnFeatureClassName(_sdeConn.Workspace);
                _tblName = new TnTableName(_sdeConn.Workspace);
                
            }
            //MessageBox.Show(string.Format("line 122 GLandPriceView layerCount={0}", _mapView.GetMapControl().LayerCount));
            //if (_mapView.GetMapControl().LayerCount == 0)
            //{
            //    MessageBox.Show(string.Format("line 125 GLandPriceView layerCount={0}", _mapView.GetMapControl().LayerCount));
            //    _tgdName = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat, _conf.NamApDung);
            //    IFeatureClass fc = _fw.OpenFeatureClass(_tgdName);
            //    IFeatureLayer fl = new FeatureLayerClass();
            //    fl.FeatureClass = fc;
            //    fl.Name = fc.AliasName;
            //    ILayer layer = (ILayer)fl;
            //    _mapView.AddLayer(layer);
            //}
            
            _controller.LoadPrice();
        }

        void ILandpriceView.Close()
        {
            if (this._containerForm != null)
            {
                this._containerForm.Close();
            }
            if (this._containerDockpanel != null)
            {
                this._containerDockpanel.Hide();
            }
        }

        void ILandpriceView.UpdateLandprice()
        {
            txtDonGia.EditValue=_landprice;
            txtGiaDat.EditValue = _landpriceWithArea;
        }

        void ILandpriceView.ShowDialog()
        {
            if (this._containerForm != null)
            {
                this._containerForm.ShowDialog();
            }
        }

        void ILandpriceView.Show()
        {
            if (this._containerForm != null)
            {
                this._containerForm.Show();
            }
            if (this._containerDockpanel != null)
            {
                this._containerDockpanel.Show();
            }
        }

        void ILandpriceView.SetContainer(XtraForm form)
        {
            this._containerForm=form;
        }

        void ILandpriceView.SetContainer(DevExpress.XtraBars.Docking.DockPanel dockpanel)
        {
            this._containerDockpanel=dockpanel;
        }


        #endregion

        #region ILandpriceView Members

        ICurrentConfig ILandpriceView.Config
        {
            get
            {
                return _conf;
            }
            set
            {
               _conf=value;
            }
        }

        object ILandpriceView.CurrentMathua
        {
            get
            {
                return _mathua;
            }
            set
            {
                _mathua=value;
            }
        }

        object ILandpriceView.CurrentThuaId
        {
            get
            {
               return _thuaId;
            }
            set
            {
                _thuaId=value;
            }
        }

        #endregion

        #region ILandpriceView Members


        void ILandpriceView.UpDate(List<ThuaGiaDatInfo> giaDatInfo)
        {
            
            if (giaDatInfo == null || giaDatInfo.Count == 0)
            {
                //MessageBox.Show("line 269 GLandpriceView, count=" + giaDatInfo.Count.ToString());
                ((ILandpriceView)this).ClearAll();
                return;
            }
            _thuaGiaDatInfo=giaDatInfo;
            _tgdName = string.Format("{0}_{1}", _landpriceName, _conf.NamApDung);
            _thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, _conf.NamApDung);
            _fcName.FC_THUA_GIADAT.NAME = _tgdName;
            _fcName.FC_THUA_GIADAT.InitIndex();
            _fcName.FC_THUA.NAME = _thuaName;
            _fcName.FC_THUA.InitIndex();
            object[] oids = new object[giaDatInfo.Count];
            int i=0;
            //MessageBox.Show(String.Format("line 201 - GLandPriceView: {0}_{1}", _thuaGiaDatInfo.Count, _thuaGiaDatInfo[0].Oid));
            if (_mapView.GetMapControl().LayerCount == 0)
            {
                _mapView.AddLayer(_thuaName, _tgdName);
            }
            lbxCacVungGia.Items.Clear();
            foreach (ThuaGiaDatInfo thua in _thuaGiaDatInfo)
            {
                lbxCacVungGia.Items.Add(thua.Oid);
                oids[i] = thua.Mathua;
                i++;
            }
            
            //string dk = QueryStringBuilder.CreateOrQueryString("OBJECTID", oids);
            //string dk=string.Format("{0}='{1}'",)
            //string layer = _dataManager.TnCreateFeatureLayer(DataNameTemplate.Thua_Gia_Dat, "vung_gia_thua", _sdeConn.Environment, dk);

        }

        #endregion

        private void lbxCacVungGia_Click(object sender, EventArgs e)
        {
            _tgdName = string.Format("{0}_{1}", _landpriceName, _conf.NamApDung);
            _thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, _conf.NamApDung);
            _fcName.FC_THUA_GIADAT.NAME = _tgdName;
            _fcName.FC_THUA_GIADAT.InitIndex();
            _fcName.FC_THUA.NAME = _thuaName;
            _fcName.FC_THUA.InitIndex();
            //MessageBox.Show(string.Format("line 241 GLandpriceView {0}", _thuaGiaDatInfo.Count));
            foreach (ThuaGiaDatInfo thua in _thuaGiaDatInfo)
            {
                if (thua.Oid.ToString() == ((ListBoxControl)sender).Text)
                {
                    //MessageBox.Show(string.Format("line 254 GLandPriceView"));
                    _currentThuaGiaDatInfo = thua;
                    txtGiaDat.EditValue = thua.Giadat;
                    txtDonGia.EditValue = thua.Dongia;
                    txtDienTich.EditValue = thua.Dientichpl;
                    if ((int)thua.KhoagiaTay == 0)
                    {
                        chkKhoaTay.CheckState = CheckState.Unchecked;
                        mniKhoaGiaTay.CheckState = CheckState.Unchecked;
                        
                    }
                    else
                    {
                        chkKhoaTuDong.CheckState=CheckState.Checked;
                        mniKhoaGiaTuDong.CheckState = CheckState.Checked;
                    }
                    if ((int)thua.KhoagiaTudong == 0)
                    {
                        chkKhoaTuDong.CheckState = CheckState.Unchecked;
                        mniKhoaGiaTuDong.CheckState = CheckState.Unchecked;
                    }
                    else 
                    { 
                        chkKhoaTuDong.CheckState = CheckState.Checked;
                        mniKhoaGiaTuDong.CheckState = CheckState.Checked;
                    }

                    if ((int)thua.KhoaVitri == 0)
                    {
                        chkKhoaViTri.CheckState = CheckState.Unchecked;
                    }
                    else
                    {
                        chkKhoaViTri.CheckState = CheckState.Checked;
                    }
                    

                    //_mapView.Oid = thua.Oid.ToString() ;
                    _mapView.ZoomToSelectId(_tgdName, thua.Oid);

                    #region ghi vao cac chi tiet
                    txtMaThua.EditValue = thua.Mathua;
                    txtHeSoViTri.EditValue = thua.Hesovitri;
                    rtbCachTinh.Text = thua.Cachtinh.ToString();
                    if (chkTruyTim.CheckState == CheckState.Checked)
                    {
                        findDetail(thua);
                    }
                    #endregion
                    break;
                }
            }
        }

        private void findDetail(ThuaGiaDatInfo thuaInfo)
        {
            //MessageBox.Show(string.Format("line 307 GLandPriceView mathua={0}", thuaInfo.Mathua));
            _tgdName = string.Format("{0}_{1}", _landpriceName, _conf.NamApDung);
            _thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, _conf.NamApDung);
            _fcName.FC_THUA_GIADAT.NAME = _tgdName;
            _fcName.FC_THUA_GIADAT.InitIndex();
            _fcName.FC_THUA.NAME = _thuaName;
            _fcName.FC_THUA.InitIndex();
            object maxa=0;
            object diachi = "";
            object tenchu = "";
            IQueryFilter qrf = new QueryFilterClass();
            //MessageBox.Show(string.Format("line 330 GLandPriceView thua={0}", _thuaName));
            qrf.WhereClause=string.Format("{0}='{1}'",_fcName.FC_THUA.MA_THUA,thuaInfo.Mathua);
            #region tim trong bang thua
            IFeatureClass thuaFc = _fw.OpenFeatureClass(_thuaName);
            IFeatureCursor thuaFcur = thuaFc.Search(qrf, false);
            IFeature thuaFt = null;
            try
            {
                if ((thuaFt = thuaFcur.NextFeature()) != null)
                {
                    
                    maxa=thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_XA));
                    
                    txtLoaiDat.EditValue = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOAI_DAT));
                    txtDiaChi.EditValue = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.DIA_CHI));
                    txtChuSoHuu.EditValue=thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.TEN_CHU));
                    //MessageBox.Show("line 344 GLandPriceView tenchu="+tenchu.ToString());

                    //MessageBox.Show(string.Format("line 344 GLandPriceView maxa={0},loaidatindex={1}", maxa, thuaFt.Fields.FindField(_fcName.FC_THUA.LOAI_DAT)));
                }
            }
            catch (Exception e1) { MessageBox.Show(string.Format("line 324 GLandPriceView, e={0}", e1)); }

            //finally { Marshal.ReleaseComObject(thuaFcur); }
            #endregion

            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_RANH_XA_POLY.MA_XA, maxa);
            #region tim trong bang xa
            IFeatureClass xaFc = _fw.OpenFeatureClass(DataNameTemplate.Ranh_Xa_Poly);
            IFeatureCursor xaFcur = xaFc.Search(qrf, false);
            IFeature xaFt = null;
            try
            {
                if ((xaFt = xaFcur.NextFeature()) != null)
                {
                    //MessageBox.Show(string.Format("line 338 GLandPriceView, maxa={0}", maxa));
                    txtXa.Text = xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.TEN_XA)).ToString();
                }
            }
            catch (Exception e1) { MessageBox.Show(string.Format("line 340 GLandPriceView, e={0}", e1)); }
            finally { Marshal.ReleaseComObject(xaFcur); }
            #endregion

            qrf.WhereClause = string.Format("{0}='{1}'", _tblName.TEN_DUONG.MA_DUONG, thuaInfo.Maduong);
            //MessageBox.Show(string.Format("line 347 GLandPriceView, maxa={0}", thuaInfo.Maduong));
            #region tim trong bang ten duong
            ITable duongTb = _fw.OpenTable(DataNameTemplate.Ten_Duong);
            ICursor duongCur = duongTb.Search(qrf, false);
            IRow duongRow = null;
            //object tenduong = "";
            try
            {
                if ((duongRow = duongCur.NextRow()) != null)
                {
                    txtTenDuong.Text = duongRow.get_Value(duongRow.Fields.FindField(_tblName.TEN_DUONG.TEN_DUONG)).ToString();
                    //MessageBox.Show(string.Format("line 347 GLandPriceView, tenduong={0}", tenduong));
                }
            }
            catch (Exception e1) { MessageBox.Show(string.Format("line 356 GLandPriceView, e={0}", e1)); }
            finally { Marshal.ReleaseComObject(duongCur); }
            #endregion

            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, thuaInfo.Mahem);
            //MessageBox.Show(string.Format("line 364 GLandPriceView, maxa={0}", thuaInfo.Mahem));
            #region tim trong bang hem
            IFeatureClass hemFc = _fw.OpenFeatureClass(DataNameTemplate.Hem);
            IFeatureCursor hemFcur = hemFc.Search(qrf, false);
            IFeature hemFt = null;
            try
            {
                if ((hemFt = hemFcur.NextFeature()) != null)
                {
                    txtTenHem.EditValue = hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.TEN_HEM));
                }
            }
            catch { }
            finally { Marshal.ReleaseComObject(hemFcur); }
            #endregion

            //qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_KTVHXH.MA_KTVHXH, thuaInfo.Mattx);
            //#region tim trong bang trung tam xa
            //IFeatureClass ttxaFc = _fw.OpenFeatureClass(DataNameTemplate.Trung_Tam_Xa);
            //IFeatureCursor ttxaFcur = ttxaFc.Search(qrf, false);
            //IFeature ttxaFt = null;
            //try
            //{
            //    while ((ttxaFt = ttxaFcur.NextFeature()) != null)
            //    {

            //    }
            //}
            //catch { }
            //finally { Marshal.ReleaseComObject(ttxaFcur); }
            //#endregion

            _inputParams.MA_XA = maxa.ToString() ;
            _inputParams.MA_DUONG = thuaInfo.Maduong.ToString();
            _inputParams.OVER_WRITE_ATT = true;
            _inputParams.He_SO_VI_TRI = thuaInfo.Hesovitri;
            _inputParams.MA_THUA_RIENG_LE = thuaInfo.Mathua;
            _inputParams.OID_THUA_RIENG_LE = this.lbxCacVungGia.SelectedItem;
        }

        #region ILandpriceView Members


        void ILandpriceView.LoadPriceFromOid()
        {
            throw new NotImplementedException();
        }

        void ILandpriceView.LoadPriceFromKey()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILandpriceView Members


        string ILandpriceView.LandpriceTableName
        {
            get
            {
                return _landpriceName;
            }
            set
            {
                _landpriceName=value;
            }
        }

        #endregion

        private void chkKhoaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(chkKhoaTuDong.CheckState.ToString());
            //_controller.LockAutoMethod();
            occurEditValue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this._isEditting)
            {
                ((ILandpriceView)this).StopEdit();
            }
            this._containerForm.Close();
        }

        private void mniBatDau_Click(object sender, EventArgs e)
        {
            ((ILandpriceView)this).StartEdit();
        }

        private void mniLuu_Click(object sender, EventArgs e)
        {
            ((ILandpriceView)this).SaveEdit();
        }

        private void mniKetThuc_Click(object sender, EventArgs e)
        {
            ((ILandpriceView)this).StopEdit();
        }
        private void startEdit()
        {
            txtHeSoViTri.Properties.ReadOnly = false;
            txtDonGia.Properties.ReadOnly = false;
            txtGiaDat.Properties.ReadOnly = false;
            txtDienTich.Properties.ReadOnly = false;
            chkKhoaTuDong.Properties.ReadOnly = false;
            chkKhoaTay.Properties.ReadOnly = false;
            chkKhoaViTri.Properties.ReadOnly = false;
            mniBatDau.Enabled = false;
            //mniLuu.Enabled = true;
            mniKetThuc.Enabled = true;

            mniKhoaGiaTay.Enabled = true;
            mniKhoaGiaTuDong.Enabled = true;
            mniLbxXoaVungGia.Enabled = true;
            //mniLockAuto.Enabled = true;
            //mniLockAll.Enabled = true;
            //mniUnlock.Enabled = true;
            mniXoaVungGia.Enabled = true;
        }
        private void stopEdit()
        {
            //if (_isSaved)
            //{
            txtHeSoViTri.Properties.ReadOnly = true;
                txtDonGia.Properties.ReadOnly = true;
                txtGiaDat.Properties.ReadOnly = true;
                txtDienTich.Properties.ReadOnly = true;
                chkKhoaTuDong.Properties.ReadOnly = true;
                chkKhoaTay.Properties.ReadOnly = true;
                chkKhoaViTri.Properties.ReadOnly = true;
                mniBatDau.Enabled = true;
                mniLuu.Enabled = false;
                mniKetThuc.Enabled = false;
                mniKhoaGiaTay.Enabled = false;
                mniKhoaGiaTuDong.Enabled = false;
                mniLbxXoaVungGia.Enabled = false;
                //mniLockAuto.Enabled = false;
                //mniLockAll.Enabled = false;
                //mniUnlock.Enabled = false;
                mniXoaVungGia.Enabled = false;

                btnHuy.Enabled = false;
            //}
            //else
            //{
            //    FrmSaveEditQuestion frm = new FrmSaveEditQuestion();
            //    frm.Show();
            //}
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            cmnCapNhat.Show(System.Windows.Forms.Cursor.Position);
        }

        #region ILandpriceView Members


        void ILandpriceView.StartEdit()
        {
            _controller.StartEdit();
            startEdit();
            _isEditting = true;
            _isSaved = false;
        }

        void ILandpriceView.SaveEdit()
        {
            //MessageBox.Show("line 608 GlandpriceView, hsk=" + txtHeSoViTri.EditValue.ToString());
            this.Cursor = Cursors.AppStarting;
            if (_pairColValThua.Count > 0)
            {
                _pairColValThua.Clear();
            }
            if (_pairColValTgd.Count > 0)
            {
                _pairColValTgd.Clear();
            }
            _currentThuaGiaDatId = lbxCacVungGia.SelectedItem;
            _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.DON_GIA), txtDonGia.EditValue } });
            _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.DIEN_TICH_PHAP_LY), txtDienTich.EditValue } });
            _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.GIA_DAT), txtGiaDat.EditValue } });
            _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.HE_SO_K), txtHeSoViTri.EditValue } });
            if (chkKhoaTay.CheckState != CheckState.Unchecked)
            {
                _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.LOCKED), 2 } });
            }
            else if (chkKhoaTuDong.CheckState != CheckState.Unchecked)
            {
                _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.LOCKED), 1 } });
            }
            else
            {
                _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.LOCKED), 0 } });
            }
            if (chkKhoaViTri.CheckState != CheckState.Unchecked)
            {
                _pairColValTgd.Add(new object[,] { { _fcName.FC_THUA.GetIndex(_fcName.FC_THUA.LOCKED), 1 } });
            }
            else
            {
                _pairColValThua.Add(new object[,] { { _fcName.FC_THUA.GetIndex(_fcName.FC_THUA.LOCKED), 0 } });
            }
            _controller.SaveEdit();
            _isSaved = true;
            mniLuu.Enabled = false;
            btnHuy.Enabled = false;
            this.Cursor = Cursors.Arrow;
        }

        void ILandpriceView.StopEdit()
        {
            //khong thay doi vi tri
            if (_isSaved)
            {
                stopEdit();
                _controller.StopEdit();
            }
            else
            {
                FrmSaveEditQuestion frm = new FrmSaveEditQuestion();
                frm.SetView(this);
                frm.Show();
                
            }
            
            _isEditting = false;
        }

        #endregion

        #region IEditView Members

        void IEditView.Close()
        {
            ((ILandpriceView)this).Close();
        }

        void IEditView.SaveEdit()
        {
            ((ILandpriceView)this).SaveEdit();
        }

        void IEditView.StopEdit()
        {
            ((ILandpriceView)this).StopEdit();
        }

        void IEditView.StartEdit()
        {
            ((ILandpriceView)this).StartEdit();
        }

        void IEditView.StopEditWithoutSaving()
        {
            ((ILandpriceView)this).StopEditWithoutSaving();
        }

        #endregion

        #region ILandpriceView Members


        void ILandpriceView.StopEditWithoutSaving()
        {
            //ko thay doi vi tri
            _controller.StopEditWithoutSaving();
            stopEdit();
            _isSaved = true;
            _isEditting = false;
        }

        #endregion

        #region ILandpriceView Members


        bool ILandpriceView.IsSaved
        {
            get
            {
                return _isSaved;
            }
            set
            {
                _isSaved = value;
            }
        }

        bool ILandpriceView.IsEditting
        {
            get
            {
                return _isEditting;
            }
            set
            {
                _isEditting = value;
            }
        }

        #endregion

        #region IEditView Members


        bool IEditView.IsSaved
        {
            get
            {
                return _isSaved;
            }
            set
            {
                _isSaved = value;
            }
        }

        bool IEditView.IsEditting
        {
            get
            {
                return _isEditting;
            }
            set
            {
                _isEditting = value;
            }
        }

        #endregion

        #region ILandpriceView Members


        List<object[,]> ILandpriceView.ListOfValueThuaGiaDat
        {
            get
            {
                return _pairColValTgd;
            }
            set
            {
                _pairColValTgd=value;
            }
        }

        List<object[,]> ILandpriceView.ListOfValueThua
        {
            get
            {
                return _pairColValThua;
            }
            set
            {
                _pairColValThua=value;
            }
        }

        #endregion

        #region ILandpriceView Members


        object ILandpriceView.CurrentThuaGiaDatId
        {
            get
            {
                return _currentThuaGiaDatId;
            }
            set
            {
                _currentThuaGiaDatId=value;
            }
        }

        #endregion

        private void mniReload_Click(object sender, EventArgs e)
        {
            ((ILandpriceView)this).LoadPrice();
        }

        private void chkKhoaTay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhoaTay.CheckState != CheckState.Unchecked)
            {
                chkKhoaTuDong.CheckState = CheckState.Checked;
            }
            occurEditValue();
        }

        private void occurEditValue()
        {
            mniLuu.Enabled=true;
            btnHuy.Enabled = true;
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            occurEditValue();
        }

        private void chkKhoaViTri_CheckedChanged(object sender, EventArgs e)
        {
            occurEditValue();
        }

        private void txtDienTich_EditValueChanged(object sender, EventArgs e)
        {
            occurEditValue();
        }

        private void txtGiaDat_EditValueChanged(object sender, EventArgs e)
        {
            occurEditValue();
        }

        private void btnLookupHesok_Click(object sender, EventArgs e)
        {
            if (_calcMethodBuilder == null)
            {
                return;
            }
            _calcMethodBuilder.SetCallerView(this);
            _calcMethodBuilder.SetVisibleBtnChonHesoK(true);
            _calcMethodBuilder.ShowDialog();
        }



        #region ILandpriceView Members


        void ILandpriceView.SetCalcMethodBuilderView(ICalcMethodBuilderView view)
        {
            this._calcMethodBuilder = view;
            this._calcMethodBuilder.SetLandPriceView(this);
        }

        #endregion

        #region ILandpriceView Members


        IMapView ILandpriceView.MapView
        {
            get
            {
                return this._mapView;
            }
            set
            {
                this._mapView = value;
            }
        }

        #endregion

        private void mniKhoaGiaTuDong_CheckedChanged(object sender, EventArgs e)
        {
            chkKhoaTuDong.CheckState = mniKhoaGiaTuDong.CheckState;
            occurEditValue();
            
        }

        private void mniKhoaGiaTay_CheckStateChanged(object sender, EventArgs e)
        {
            chkKhoaTay.CheckState = mniKhoaGiaTay.CheckState;
            if (mniKhoaGiaTay.CheckState != CheckState.Unchecked)
            {
                mniKhoaGiaTuDong.CheckState = CheckState.Checked;
            }
            occurEditValue();
        }

        private void chkThua_CheckStateChanged(object sender, EventArgs e)
        {
            _mapView.GetMapControl().Map.get_Layer(1).Visible = chkGia.Checked;
            _mapView.GetMapControl().ActiveView.Refresh();
        }

        private void chkGia_CheckedChanged(object sender, EventArgs e)
        {
            _mapView.GetMapControl().Map.get_Layer(0).Visible = chkGia.Checked;
            _mapView.GetMapControl().ActiveView.Refresh();
        }

        private void mniLbxXoaVungGia_Click(object sender, EventArgs e)
        {
            xoaVungGia(lbxCacVungGia.SelectedItem);
        }
        private void xoaVungGia(object oid)
        {
            _engine.Remove(oid);
            lbxCacVungGia.Items.RemoveAt(lbxCacVungGia.SelectedIndex);
        }

        private void mniXoaVungGia_Click(object sender, EventArgs e)
        {
            xoaVungGia(lbxCacVungGia.SelectedItem);
        }

        private void mniReCalcCurPos_Click(object sender, EventArgs e)
        {
            if (_executor == null || _inputParams==null || _calcController==null)
            {
                return;
            }
            try
            {
                _calc = (ICalculation)_executor;
                _calcView = (ICalculationView)this;
                setValue4InputParams();
                _calcController.SetCalculation(_calc);
                _calcController.SetView(_calcView);
                foreach (ICalculationMonitor m in _calc.Monitors)
                {
                    m.Show();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("line 977 GLandpriceView ex=",ex.ToString());
            }
            _calcController.ReqStart();
            //_calcView.SetInputParams(_inputParams);
        }

        #region ILandpriceView Members


        void ILandpriceView.SetHesoK(object hsk)
        {
            if (_isEditting)
            {
                
                this.txtHeSoViTri.EditValue = hsk;
                //MessageBox.Show(txtHeSoViTri.EditValue.ToString());
            }
        }

        #endregion

        #region ICalculationView Members

        void ICalculationView.Start()
        {
            throw new NotImplementedException();
        }

        void ICalculationView.Stop()
        {
            throw new NotImplementedException();
        }

        void ICalculationView.SetParams()
        {
            throw new NotImplementedException();
        }

        void ICalculationView.GetParams()
        {
            throw new NotImplementedException();
        }

        IInputParams ICalculationView.InputParams
        {
            get
            {
                return _inputParams;
            }
            set
            {
                _inputParams = value;
            }
        }

        ICurrentConfig ICalculationView.CurrentConfig
        {
            get
            {
                return _conf;
            }
            set
            {
                _conf = value;
            }
        }

        void ICalculationView.SetInputParams(IInputParams input)
        {
            _inputParams = input;
        }

        List<object> ICalculationView.Tasks
        {
            get { 
                List<object> lst= new List<object>();
                //int task;
                //bool re = int.TryParse(_inputParams.He_SO_VI_TRI.ToString(),out task);
                //if(!re)
                //{
                //    task=-1;
                //}
                //lst.Add(TasksPool.CallMe().FindTaskFromHsk(task));
                lst.Add(0);
                return lst;
            }
        }

        void ICalculationView.AddMonitor(ICalculationMonitor monitor)
        {
            throw new NotImplementedException();
        }

        void ICalculationView.AddMonitors(List<ICalculationMonitor> monitors)
        {
            throw new NotImplementedException();
        }

        int ICalculationView.MonitorCount()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ILandpriceView Members


        IExecutor ILandpriceView.Excutor
        {
            get
            {
                return this._executor;
            }
            set
            {
                this._executor = value;
            }
        }

        #endregion

        #region ILandpriceView Members


        ICalculationController ILandpriceView.CalcController
        {
            get
            {
                return this._calcController;
            }
            set
            {
                _calcController = value;
            }
        }

        #endregion

        #region ILandpriceView Members


        void ILandpriceView.IsAllowRecalcPoistion(bool arg)
        {
            //mniReCalcCurPos.Visible = arg;
            mniReCalcNewPos.Visible = arg;
        }

        #endregion

        private void txtHeSoViTri_EditValueChanged(object sender, EventArgs e)
        {
            occurEditValue();
        }

        private void mniRefresh_Click(object sender, EventArgs e)
        {
            ((ILandpriceView)this).LoadPrice();
        }

        #region ILandpriceView Members


        void ILandpriceView.ClearAll()
        {
            txtChuSoHuu.EditValue = "";
            txtDiaChi.EditValue = "";
            txtDienTich.EditValue = 0;
            txtDonGia.EditValue = 0;
            txtGiaDat.EditValue = 0;
            txtHeSoViTri.EditValue = "";
            txtHuyen.EditValue = "";
            txtKhuDc.EditValue = "";
            txtKtvhxh.EditValue = "";
            txtLoaiCapNhat.EditValue = "";
            txtLoaiDat.EditValue = "";
            txtMaThua.EditValue = "";
            txtNgayCapNhat.EditValue = "";
            txtNguoCapNhat.EditValue = "";
            txtTenDuong.EditValue = "";
            txtTenHem.EditValue = "";
            txtTtx.EditValue = "";
            txtXa.EditValue = "";
            rtbCachTinh.Text = "";
            lbxCacVungGia.Items.Clear();
            _mapView.GetMapControl().Map.ClearLayers();
            _mapView.GetMapControl().ActiveView.Refresh();
        }

        #endregion

        #region ICallerHskView Members

        void ICallerHskView.SetHsk(object hsk)
        {
            if (_isEditting)
            {
                this.txtHeSoViTri.EditValue = hsk;
                //MessageBox.Show(txtHeSoViTri.EditValue.ToString());
            }
        }

        #endregion

        #region ICallerHskView Members


        void ICallerHskView.SetCalcMethodBuilderView(ICalcMethodBuilderView view)
        {
            _calcMethodBuilder = view;
        }

        #endregion
    }
}
