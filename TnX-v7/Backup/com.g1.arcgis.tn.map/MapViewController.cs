using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using com.g1.arcgis.map;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.tn.map
{
    public class MapViewController:IMapViewController
    {
        
        private IMapView _mapView;
        private ILayersView _layersView;
        private IGMap _map;

        public MapViewController(IMapView map_view, ILayersView layers_view,IGMap map)
        {
            this._mapView = map_view;
            this._layersView = layers_view;
            this._map = map;
            this._layersView.SetMapBuddy(map_view.GetMapObject());
            this._map.SetHook(map_view.GetMapObject());
        }

        public MapViewController(IMapView map_view, IGMap map)
        {
            this._mapView = map_view;
            //this._layersView = layers_view;
            this._map = map;
            //this._layersView.SetMapBuddy(map_view.GetMapObject());
            this._map.SetHook(map_view.GetMapObject());
        }

        #region IMapViewController Members
        void IMapViewController.AddLayer(params ILayer[] layer)
        {
            _map.AddLayer(layer);
        }

        void IMapViewController.AddLayers(List<ILayer> layers)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.OpenMxd()
        {
            
            this._map.OpenMxd();
        }

        void IMapViewController.CloseMxd()
        {
            this._map.CloseMxd();
        }

        void IMapViewController.SaveMxd()
        {
            this._map.SaveMxd();
        }

        void IMapViewController.SetUpBuddies()
        {
            this._layersView.SetMapBuddy(this._mapView.GetMapObject());
        }

        void IMapViewController.SelectFeature()
        {
            this._map.SelectFeature();
        }

        void IMapViewController.ClearSelected()
        {
            this._map.ClearSelected();
        }

        void IMapViewController.ZoomIn()
        {
            this._map.ZoomIn();
        }

        void IMapViewController.ZoomOut()
        {
            this._map.ZoomOut();
        }

        void IMapViewController.ZoomToSelected()
        {
            //this._map.Oid = this._mapView.Oid;
            this._map.Ma = this._mapView.Ma;
            this._map.CreateSelectionSet();
            this._map.ZoomToSelected();
        }

        void IMapViewController.FullExtent()
        {
            this._map.FullExtent();
        }

        void IMapViewController.ZoomBackWard()
        {
            this._map.ZoomBackWard();
        }

        void IMapViewController.ZoomForWard()
        {
            this._map.ZoomForWard();
        }

        void IMapViewController.Pan()
        {
            this._map.Pan();
        }

        void IMapViewController.AddData()
        {
            this._map.AddData();
        }

        void IMapViewController.SaveAsMxd()
        {
            this._map.SaveAsMxd();
        }

        void IMapViewController.CreateNewMxd()
        {
            this._map.CreateNewMxd();
        }

        #endregion

        #region IMapViewController Members


        void IMapViewController.ZoomToSelectId(string layerName, params object[] oid)
        {
            _map.ZoomToSelectId(layerName, oid);
        }

        void IMapViewController.ZoomToSelectMa(string layerName, string fieldName, params object[] key)
        {
            _map.ZoomToSelectMa(layerName, fieldName, key);
        }

        void IMapViewController.ZoomToSelectSelectionSet(string layerName, ISelectionSet selectionSet)
        {
            _map.ZoomToSelectSelectionSet(layerName, selectionSet);
        }

        void IMapViewController.ZoomToSelectQueryString(string layerName, string condiction)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectQueryFilter(string layerName, IQueryFilter qrf)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectQueryByLayer(string layerName, IQueryByLayer qrf)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectEvaluableQueryString(string layerName, string evalString)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectId(int layerIndex, params object[] oid)
        {
            _map.ZoomToSelectId(layerIndex, oid);
        }

        void IMapViewController.ZoomToSelectMa(int layerIndex, string fieldName, params object[] key)
        {
            _map.ZoomToSelectMa(layerIndex, fieldName, key);
        }

        void IMapViewController.ZoomToSelectSelectionSet(int layerIndex, ISelectionSet selectionSet)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectQueryString(int layerIndex, string condiction)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectQueryFilter(int layerIndex, IQueryFilter qrf)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectQueryByLayer(int layerIndex, IQueryByLayer qrf)
        {
            throw new NotImplementedException();
        }

        void IMapViewController.ZoomToSelectEvaluableQueryString(int layerIndex, string evalString)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMapViewController Members


        void IMapViewController.AddLayer(params string[] layers)
        {
            _map.AddLayer(layers);
        }

        #endregion

        #region IMapViewController Members


        void IMapViewController.SelectByLocation()
        {
            _map.SelectByLocation();
        }

        #endregion
    }
}
