using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using com.g1.arcgis.control;
using com.g1.arcgis.landprice;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.calculation;
using com.g1.arcgis.algorithm;

namespace com.g1.arcgis.map
{
    public interface IMapView:IGControl
    {
        IMapControl3 GetMapControl();
        object GetMapObject();
        string Oid { get; set; }
        string Ma { get; set; }
        void AddLayer(params ILayer[] layer);
        void AddLayer(params string[] layer);
        void AddLayer(List<ILayer> layers);
        void AddLayer(List<string> layers);
        void ZoomToSelect();
        void ZoomToSelectId(string layerName,params object[] oid);
        void ZoomToSelectMa(string layerName,string fieldName,params object[] key);
        void ZoomToSelectSelectionSet(string layerName,ISelectionSet selectionSet);
        void ZoomToSelectQueryString(string layerName, string condiction);
        void ZoomToSelectQueryFilter(string layerName, IQueryFilter qrf);
        void ZoomToSelectQueryByLayer(string layerName, IQueryByLayer qrf);
        void ZoomToSelectEvaluableQueryString(string layerName, string evalString);
        void ZoomToSelectId(int layerIndex, params object[] oid);
        void ZoomToSelectMa(int layerIndex,string fieldName, params object[] key);
        void ZoomToSelectSelectionSet(int layerIndex, ISelectionSet selectionSet);
        void ZoomToSelectQueryString(int layerIndex, string condiction);
        void ZoomToSelectQueryFilter(int layerIndex, IQueryFilter qrf);
        void ZoomToSelectQueryByLayer(int layerIndex, IQueryByLayer qrf);
        void ZoomToSelectEvaluableQueryString(int layerIndex, string evalString);
        void SetController(IMapViewController controller);
        //void SetContextMenu(IMapContextMenu contextMenu);
        void SetLandpriceView(string key,ILandpriceView landpriceView);
        void SetLandpricePublishedView(ILandpriceView view);
        IMapContextMenu ContextMenu { get; set; }
        IEditPositionParamsView EditPosView { get; set; }
        void SetCalcMethodBuilderView(ICalcMethodBuilderView view);
    }
}
