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
using GCommands;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using SymbolSelector;
//using SymbolSelector;

namespace com.g1.arcgis.tn.map
{
    public partial class GLayersView : DevExpress.XtraEditors.XtraUserControl,ILayersView
    {
        private ITOCControl2 _tocControl;
        private ITocContextMenu _tocContextMenu;
        private RemoveLayerInToc _removeLayer;
        //private FeatureLayerSymbology _layerSym;
        private Labelor _labelor;
        private IMapControl4 _mapControl;
        public GLayersView()
        {
            InitializeComponent();
            this._tocControl = (ITOCControl2)this.axTOCControl1.Object;
            this.axTOCControl1.EnableLayerDragDrop = true;
            _removeLayer = new RemoveLayerInToc();
            _labelor = new Labelor();
            //_layerSym = new FeatureLayerSymbology();
        }

        #region ILayersView Members

        void ILayersView.SetMapBuddy(object map_buddy)
        {
            _mapControl = (IMapControl4)map_buddy;
            this.axTOCControl1.SetBuddyControl(map_buddy);
            _tocContextMenu = new TocContextMenu(map_buddy);
            _tocContextMenu.AddItem(_labelor, false, -1);
            _tocContextMenu.AddItem(_removeLayer, false, -1);
            //_tocContextMenu.AddItem(_layerSym, false, -1);

        }

        IMapView ILayersView.GetMapView()
        {
            throw new NotImplementedException();
        }

        object ILayersView.GetMapBuddy()
        {
            return this._tocControl.Buddy;
        }

        void ILayersView.Refresh()
        {
            this._tocControl.ActiveView.Refresh();
        }

        ITOCControl2 ILayersView.GetTocControl()
        {
            return _tocControl;
        }

        #endregion

        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            ILayer layer = null;
            object other = null;
            object index = null;
            IBasicMap map = null;
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            IDataset dataset = (IDataset)layer;
            IFeatureLayer fl = (IFeatureLayer)layer;
            if (e.button == 2)
            {
                if (null == layer || !(layer is IFeatureLayer))
                {
                    return;
                }
                _mapControl.CustomProperty = layer;
                this._tocContextMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);

            }
        }
    }
}
