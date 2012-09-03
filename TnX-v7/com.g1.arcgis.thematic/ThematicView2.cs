using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using com.g1.arcgis.map;
using com.g1.arcgis.tn.map;

namespace com.g1.arcgis.thematic
{
    public partial class ThematicView2 : DevExpress.XtraEditors.XtraForm
    {
        IMapViewController _mapController;
        IMapViewController _mapViewController;
        IMapView _mapView;
        ILayersView _layersView;
        IGMap _map;
        public ThematicView2()
        {
            InitializeComponent();
            this._map = new GMap();
            this._mapView = (IMapView)this.gMapView1;
            this._layersView = (ILayersView)this.gLayersView1;
            this._mapView.SetParentDockControl(this.dockPanel1);
            this._mapViewController = new MapViewController(this._mapView, this._layersView, this._map);
            this.Load += new EventHandler(ThematicView2_Load);
        }

        void ThematicView2_Load(object sender, EventArgs e)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            IFeatureClass fcThua = fw.OpenFeatureClass("sde.thixa_thua");
            IFeatureLayer flThua = new FeatureLayerClass();
            flThua.FeatureClass = fcThua;
            ILayer layerThua = (ILayer)flThua;
            IFeatureClass fcDuong = fw.OpenFeatureClass("sde.thixa_duong");
            IFeatureLayer flDuong = new FeatureLayerClass();
            flDuong.FeatureClass = fcDuong;
            ILayer layerDuong = (ILayer)flDuong;
            layerDuong.Name = fcDuong.AliasName;
            layerThua.Name = fcThua.AliasName;

            _mapController.AddLayer(layerDuong);
            _mapController.AddLayer(layerThua);
        }

        private void bbiThematic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmThematic frmThematic = new FrmThematic();
            frmThematic.ShowDialog();
        }

    }
}