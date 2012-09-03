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

namespace TNPro.Danhmuc
{
    public partial class FrmHem2 : DevExpress.XtraEditors.XtraForm
    {
        private IEditTableView _edit;
        private IMapViewController _mapController;
        IMapView _mapView;
        IGMap _map;
        ILayersView _layersView;
        public FrmHem2()
        {
            InitializeComponent();
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
            _edit.ExpectedTableName = "sde.thixa_hem";
            _edit.DbConnectOccur();
            setAliasFieldName();

            showMap();
        }

        private void showMap()
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            IFeatureClass fcHem = fw.OpenFeatureClass("sde.thixa_hem");
            IFeatureLayer flHem = new FeatureLayerClass();
            flHem.FeatureClass = fcHem;
            ILayer layerThua = (ILayer)flHem;
            IFeatureClass fcDuong = fw.OpenFeatureClass("sde.thixa_duong");
            IFeatureLayer flDuong = new FeatureLayerClass();
            flDuong.FeatureClass = fcDuong;
            ILayer layerDuong = (ILayer)flDuong;
            layerDuong.Name = fcDuong.AliasName;
            layerThua.Name = fcHem.AliasName;

            _mapController.AddLayer(flHem);
            _mapController.AddLayer(flDuong);
        }

        private void setAliasFieldName()
        {
            List<string[,]> fieldList = new List<string[,]>();
            fieldList.Add(new string[,] { { "mahem", "mã hẻm" } });
            fieldList.Add(new string[,] { { "tenhem", "Tên hẻm" } });
            fieldList.Add(new string[,] { { "dorong", "Độ rộng" } });
            fieldList.Add(new string[,] { { "vatlieu", "Vật liệu" } });
            fieldList.Add(new string[,] { { "maduong", "mã đường" } });
            fieldList.Add(new string[,] { { "thongraduong", "Thông ra đường" } });
            fieldList.Add(new string[,] { { "hemphu", "hẻm phụ" } });
            fieldList.Add(new string[,] { { "ghichu", "Ghi chú" } });
            _edit.AliasFieldName = fieldList;
        }
    }
}