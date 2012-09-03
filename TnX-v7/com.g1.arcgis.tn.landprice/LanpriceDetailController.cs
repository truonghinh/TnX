using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
//using TnModels;
using ExtensionAPI;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using com.g1.arcgis.tn.map;
using com.g1.arcgis.landprice;
using com.g1.arcgis.map;
//using ESRI.ArcGIS.Controls;

namespace com.g1.arcgis.tn.landprice
{
    public class LandpriceDetailController:ILandpriceDetailController
    {
        #region member
        private ILandpriceDetailView _view;
        private ILandpriceDetail _model;
        private IMapView _map;
        //private IMapControl3 _mapControl;
        #endregion

        #region constructor
        public LandpriceDetailController(ILandpriceDetailView view, ILandpriceDetail model)
            : this(view, model, null)
        {
        }

        public LandpriceDetailController(ILandpriceDetailView view, ILandpriceDetail model,IMapView map)
        {
            this._view = view;
            this._model = model;
            this._map = map;
            //_mapControl = mapControl;
            _view.AddRowClickEvent(grv_RowClick);
        }

        private void grv_RowClick(object sender, RowClickEventArgs e)
        {
            MessageBox.Show(string.Format("name:{0}", ((GridView)sender).Name));
        }
        #endregion

        #region ILandpriceDetailController Members

        void ILandpriceDetailController.ShowDetail()
        {
            throw new NotImplementedException();
        }

        void ILandpriceDetailController.ShowLocation()
        {
            throw new NotImplementedException();
        }

        void ILandpriceDetailController.LockPrices()
        {
            throw new NotImplementedException();
        }

        void ILandpriceDetailController.ReCalculate()
        {
            throw new NotImplementedException();
        }

        void ILandpriceDetailController.ShowHistory()
        {
            throw new NotImplementedException();
        }

        void ILandpriceDetailController.ShowQuery()
        {
            throw new NotImplementedException();
        }

        void ILandpriceDetailController.ShowAddvance()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
