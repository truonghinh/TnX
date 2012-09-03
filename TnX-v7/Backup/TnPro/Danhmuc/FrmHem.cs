using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.tn.map;
using com.g1.arcgis.map;

namespace TNPro.Danhmuc
{
    public partial class FrmHem : DevExpress.XtraEditors.XtraForm
    {
        #region member cho map
        IMapViewController _mapViewController;
        IMapView _mapView;
        ILayersView _layersView;
        IGMap _map;
        #endregion

        public FrmHem()
        {
            InitializeComponent();
            iniMapController();
        }
        private void iniMapController()
        {
            this._map = new GMap();
            this._mapView = (IMapView)this.gMapView1;
            this._layersView = (ILayersView)this.gLayersView1;
            this._mapViewController = new MapViewController(this._mapView, this._layersView, this._map);
        }

    }
}