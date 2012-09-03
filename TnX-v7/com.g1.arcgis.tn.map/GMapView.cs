using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Controls;
using com.g1.arcgis.map;
using DevExpress.XtraBars.Docking;
using GCommands;
using com.g1.arcgis.landprice;
using com.g1.arcgis.tn.config;
using ESRI.ArcGIS.Carto;
//using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.attribute;
using com.g1.arcgis.database;
using com.g1.arcgis.edit;
using com.g1.arcgis.calculation;
using com.g1.arcgis.algorithm;

namespace com.g1.arcgis.tn.map
{
    public partial class GMapView : DevExpress.XtraEditors.XtraUserControl, IMapView
    {
        private DockPanel _parent;
        private IMapControl4 _mapControl;
        private string _oid;
        private string _ma;
        private IMapViewController _controller;
        private IGMap _map;
        private IMapContextMenu _mapContextMenu;
        //private ITocContextMenu _tocContextMenu;
        private OpenLandDetailCmd _landDetailCmd;
        private ILandpriceView _landPriceView;
        private ILandpriceView _landPricePublishedView;
        //private Landprices _landPriceTool;
        private XemTatCaVungGiaDaTinh _xemVungGiaDaTinh;
        private XemTatCaVungGiaDaCongBo _xemVungGiaDaCongBo;
        private OpenTable _moBangThuocTinh;
        private RemoveLayerInToc _removeLayer;
        private IEditPositionParamsView _editPosView;
        private SetHesoVitri _setHeSoViTri;
        private ICalcMethodBuilderView _calcMethodBuilderView;
        public GMapView()
        {
            InitializeComponent();
            _mapControl = (IMapControl4)this.axMapControl1.Object;
            
            _map = new GMap();
            _map.SetHook(_mapControl);
            //_landDetailCmd = new OpenLandDetailCmd();
            //_landDetailCmd.SetMaThuaFieldName("mathua_");
            //_landDetailCmd.XemThongTin += _landDetailCmd_XemThongTin;
            _xemVungGiaDaCongBo = new XemTatCaVungGiaDaCongBo();
            _xemVungGiaDaTinh = new XemTatCaVungGiaDaTinh();
            _setHeSoViTri = new SetHesoVitri();
            //_moBangThuocTinh = new OpenTable();
            //_removeLayer = new RemoveLayerInToc();
            

            //_xemVungGiaDaTinh.XemVungGiaDat += new XemTatCaVungGiaDaTinh.XemGiaDatEventHandler(_xemVungGiaDaTinh_XemVungGiaDat);
            //_xemVungGiaDaCongBo.XemVungGiaDat += _xemVungGiaDaCongBo_XemVungGiaDat;
            //_moBangThuocTinh.OpenAttributeTable += new OpenTable.OpenTableEventHandler(_moBangThuocTinh_OpenAttributeTable);

            _mapContextMenu = new MapContextMenu(_mapControl);
            _mapContextMenu.SetKeyName("mathua","_mathua");
            
            //_mapContextMenu.SetLandPriceView("giadatcongbo", _landPriceView);
            //_tocContextMenu = new TocContextMenu(_mapControl);
            //_mapContextMenu.AddItem(_xemVungGiaDaCongBo, false, -1);
            //_contextMenu.AddItem(_landPriceTool, false, -1);
            //_mapContextMenu.AddItem(_xemVungGiaDaTinh, false, -1);
            //_landPriceTool = new Landprices();
            ////_landPriceTool.SetMaThuaFieldName("mathua_");
            //_landPriceTool.XemGiaDat += new Landprices.XemGiaDatEventHandler(_landPriceTool_XemGiaDat);
            
            //_mapContextMenu.AddItem()

            //_tocContextMenu.AddItem(_removeLayer, false, -1);
            _controller = new MapViewController(this, _map);
            //this._map = new GMap();
            //this._mapView = (IMapView)this;
            //this._layersView = (ILayersView)this.dpnLayers;
            //this._mapViewController = new MapViewController(this._mapView, this._layersView, this._map);
        }

        void _moBangThuocTinh_OpenAttributeTable(object sender, AttributeEventArgs e)
        {
            IEditTableView tableView = new BaseTableView();
            //tableView.ExpectedTableName=
            //IAttributeView attView = new FrmAttribute();
            //attView.SetParent(this);
            //string tableName = string.Format("{0}_{1}", DataNameTemplate.Thua, _curConfig.NamApDung);
            //attView.SetTitle(tableName);
            //attView.SetTableName(tableName);
            //attView.SetAliasFieldsName(_fcName.FC_THUA.ALIAS_FIELD_LIST);
            //attView.SetMapView(this._mapView);
            //attView.Show();
        }

        private void _xemVungGiaDaCongBo_XemVungGiaDat(object sender, LandEventArgs e)
        {
            //MessageBox.Show("line 93 GMapView" + e.Mathua.ToString());
            _landPriceView.CurrentMathua = e.Mathua;
            _landPriceView.Config = CurrentConfig.CallMe();
            _landPriceView.Show();
            _landPriceView.LoadPrice();
        }

        void _xemVungGiaDaTinh_XemVungGiaDat(object sender, LandEventArgs e)
        {
            //MessageBox.Show("line 102 GMapView"+e.Mathua.ToString());
            _landPriceView.CurrentMathua = e.Mathua;
            _landPriceView.Config = CurrentConfig.CallMe();
            _landPriceView.Show();
            _landPriceView.LoadPrice();
        }

        void _landPriceTool_XemGiaDat(object sender, EventArgs e)
        {
            //MessageBox.Show("line 72 GMapView");
            _landPriceView.CurrentMathua = _xemVungGiaDaTinh.GetMaThua();
            _landPriceView.Config = CurrentConfig.CallMe();
            _landPriceView.Show();
            _landPriceView.LoadPrice();
        }

        void _landDetailCmd_XemThongTin(object sender, LandEventArgs e)
        {
            //MessageBox.Show(string.Format("line 49 - GMapView {0}", e.Mathua));
            //if (_landPriceView != null)
            //{
            
                _landPricePublishedView.CurrentMathua = e.Mathua;
                _landPricePublishedView.Config = CurrentConfig.CallMe();
                _landPricePublishedView.Show();
                _landPricePublishedView.LoadPrice();
            //}
        }

        

        #region IGControl Members

        void com.g1.arcgis.control.IGControl.SetParentDockControl(DevExpress.XtraBars.Docking.DockPanel parent)
        {
            this._parent=parent;
        }

        void com.g1.arcgis.control.IGControl.Show()
        {
            this._parent.Show();
        }

        void com.g1.arcgis.control.IGControl.Hide()
        {
            this._parent.Hide();
        }

        #endregion

        #region IMapView Members

        IMapControl3 IMapView.GetMapControl()
        {
            return this._mapControl;
        }

        object IMapView.GetMapObject()
        {
            return this.axMapControl1.Object;
        }

        string IMapView.Oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                this._oid=value;
            }
        }

        void IMapView.AddLayer(params ILayer[] layer)
        {
            this._controller.AddLayer(layer);
        }

        void IMapView.ZoomToSelect()
        {
            this._controller.ZoomToSelected();
        }

        void IMapView.SetController(IMapViewController controller)
        {
            this._controller = controller;
        }

        string IMapView.Ma
        {
            get
            {
                return this._ma;
            }
            set
            {
                this._ma = value;
            }
        }

        //void IMapView.SetContextMenu(IMapContextMenu contextMenu)
        //{
        //    this._contextMenu = contextMenu;
        //}

        #endregion

        #region private function

        private void bbiPan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.Pan();
        }

        private void bbiZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.ZoomIn();
        }

        private void bbiZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.ZoomOut();
        }

        private void bbiFullExtent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.FullExtent();
        }

        private void bbiBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.ZoomBackWard();
        }

        private void bbiNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.ZoomForWard();
        }

        private void bbiSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.SelectFeature();
        }

        private void bbiClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.ClearSelected();
        }

        private void bbiZoomToSelected_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.ZoomToSelected();
        }

        

        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 2)
            {
                this._mapContextMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);

            }
        }
        #endregion



        #region IMapView Members


        void IMapView.SetLandpriceView(string key,ILandpriceView landpriceView)
        {
            if (key == "giadatdatinh")
            {
                _landPriceView = landpriceView;
                _mapContextMenu.SetLandPriceView(key, _landPriceView);
                _mapContextMenu.AddItem(_xemVungGiaDaTinh, false, -1);
            }
            else if (key == "giadatcongbo")
            {
                _landPricePublishedView = landpriceView;
                _mapContextMenu.SetLandPriceView("giadatcongbo", _landPricePublishedView);
                _mapContextMenu.AddItem(_xemVungGiaDaCongBo, false, -1);
            }
            //_landPriceView.Config = CurrentConfig.CallMe();
        }

        #endregion

        #region IMapView Members


        IMapContextMenu IMapView.ContextMenu
        {
            get
            {
                return _mapContextMenu;
            }
            set
            {
                _mapContextMenu = value;
            }
        }

        #endregion

        #region IMapView Members


        void IMapView.AddLayer(params string[] layer)
        {
            _controller.AddLayer(layer);
        }

        void IMapView.ZoomToSelectId(string layerName, params object[] oid)
        {
            _controller.ZoomToSelectId(layerName, oid);
        }

        void IMapView.ZoomToSelectMa(string layerName,string fieldName, params object[] key)
        {
            _controller.ZoomToSelectMa(layerName, fieldName, key);
        }

        void IMapView.ZoomToSelectSelectionSet(string layerName, ESRI.ArcGIS.Geodatabase.ISelectionSet selectionSet)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectQueryString(string layerName, string condiction)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectQueryFilter(string layerName, ESRI.ArcGIS.Geodatabase.IQueryFilter qrf)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectQueryByLayer(string layerName, ESRI.ArcGIS.Carto.IQueryByLayer qrf)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectEvaluableQueryString(string layerName, string evalString)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectId(int layerIndex, params object[] oid)
        {
            _controller.ZoomToSelectId(layerIndex, oid);
        }

        void IMapView.ZoomToSelectMa(int layerIndex,string fieldName, params object[] key)
        {
            _controller.ZoomToSelectMa(layerIndex, fieldName, key);
        }

        void IMapView.ZoomToSelectSelectionSet(int layerIndex, ESRI.ArcGIS.Geodatabase.ISelectionSet selectionSet)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectQueryString(int layerIndex, string condiction)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectQueryFilter(int layerIndex, ESRI.ArcGIS.Geodatabase.IQueryFilter qrf)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectQueryByLayer(int layerIndex, ESRI.ArcGIS.Carto.IQueryByLayer qrf)
        {
            throw new NotImplementedException();
        }

        void IMapView.ZoomToSelectEvaluableQueryString(int layerIndex, string evalString)
        {
            throw new NotImplementedException();
        }

        void IMapView.AddLayer(List<ILayer> layers)
        {
            throw new NotImplementedException();
        }

        void IMapView.AddLayer(List<string> layers)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMapView Members


        void IMapView.SetLandpricePublishedView(ILandpriceView view)
        {
            _landPricePublishedView = view;
        }

        #endregion

        #region IMapView Members


        IEditPositionParamsView IMapView.EditPosView
        {
            get
            {
                return _editPosView;
            }
            set
            {
                _editPosView = value;
                _mapContextMenu.CalcMethodBuilderView = _calcMethodBuilderView;
                _mapContextMenu.EditPosView = _editPosView;
                _mapContextMenu.AddItem(_setHeSoViTri, false, -1);
            }
        }

        #endregion

        private void bbiIdentify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.Identify();
        }

        private void bbiSelectByGraphic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _map.SelectByGraphic();
        }

        #region IMapView Members


        void IMapView.SetCalcMethodBuilderView(ICalcMethodBuilderView view)
        {
            _calcMethodBuilderView = view;
        }

        #endregion
    }
}
