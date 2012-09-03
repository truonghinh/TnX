using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using com.g1.arcgis.map;
using com.g1.arcgis.tn.map;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.tn.config;
using com.g1.arcgis.calculation;

namespace TNPro.Quydinh
{
    public partial class FrmGiaDatPnnDt : DevExpress.XtraEditors.XtraForm
    {
        private IEditTableView _edit;
        private IMapViewController _mapController;
        IMapView _mapView;
        IGMap _map;
        ILayersView _layersView;
        private ITnTableName _tblName;
        ICurrentConfig _curConfig;
        public FrmGiaDatPnnDt()
        {
            InitializeComponent();
            _curConfig = CurrentConfig.CallMe();
            _edit = (IEditTableView)this.gTableViewAllowCopy1;
            this.Load += new EventHandler(Frm_Load);
            initMap();
        }

        private void initMap()
        {
            this._map = new GMap();
            this._mapView = this.gMapView1 as IMapView;

            this._layersView = this.gLayersView1 as ILayersView;
            this._mapController = new MapViewController(this._mapView, this._layersView, this._map);
            this._mapView.SetController(this._mapController);
        }

        void Frm_Load(object sender, EventArgs e)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            this._tblName = new TnTableName(sdeConn.Workspace);
            string giadatduongName = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Duong, _curConfig.NamApDung);
            _tblName.GIA_DAT_DUONG.NAME = giadatduongName;
            _tblName.GIA_DAT_DUONG.InitIndex();
            _edit.ExpectedTableName = giadatduongName;
            
            _edit.DbConnectOccur();
            _edit.AliasFieldName = _tblName.GIA_DAT_DUONG.ALIAS_FIELD_LIST;
            //setAliasFieldName();

            showMap();
        }

        private void showMap()
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            string thuaLayer = string.Format("{0}_{1}", DataNameTemplate.Thua, _curConfig.NamApDung);
            string duongLayer = string.Format("{0}", DataNameTemplate.Duong);
            IFeatureClass fcThua=null;
            try
            {
                fcThua = fw.OpenFeatureClass(thuaLayer);
            }
            catch (Exception ex) { }
            IFeatureLayer flThua = new FeatureLayerClass();
            flThua.FeatureClass = fcThua;
            ILayer layerThua = (ILayer)flThua;
            IFeatureClass fcDuong=null;
            try
            {
                fcDuong = fw.OpenFeatureClass(duongLayer);
            }
            catch (Exception ex) { }
            IFeatureLayer flDuong = new FeatureLayerClass();
            flDuong.FeatureClass = fcDuong;
            ILayer layerDuong = (ILayer)flDuong;
            layerDuong.Name = fcDuong.AliasName;
            layerThua.Name = fcThua.AliasName;

            _mapController.AddLayer(flDuong);
        }

        //private void setAliasFieldName()
        //{
        //    List<string[,]> fieldList = new List<string[,]>();
        //    fieldList.Add(new string[,] { { "giadat", "Giá đất" } });
        //    fieldList.Add(new string[,] { { "maduong_", "Mã đường" } });
        //    fieldList.Add(new string[,] { { "ghichu", "Ghi chú" } });
            
            
        //    _edit.AliasFieldName = fieldList;
        //}
    }
}