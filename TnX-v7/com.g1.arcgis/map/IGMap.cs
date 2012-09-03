using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.map
{
    public interface IGMap
    {
        void SetHook(object hook);
        object GetHook();
        void AddLayer(params ILayer[] layer);
        void AddLayers(List<ILayer> layers);
        void AddLayer(params string[] layer);
        void AddLayers(List<string> layers);
        void OpenMxd();
        void CloseMxd();
        void SaveMxd();
        void SaveAsMxd();
        void CreateNewMxd();
        void SetUpBuddies();
        void SelectFeature();
        void ClearSelected();
        void ZoomIn();
        void ZoomOut();
        void ZoomToSelected();
        void FullExtent();
        void ZoomBackWard();
        void ZoomForWard();
        void Pan();
        void AddData();
        void Identify();
        void SelectByGraphic();
        string Oid { get; set; }
        string Ma { get; set; }
        void CreateSelectionSet();
        void ZoomToSelectId(string layerName, params object[] oid);
        void ZoomToSelectMa(string layerName,string fieldName, params object[] key);
        void ZoomToSelectSelectionSet(string layerName, ISelectionSet selectionSet);
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
        void SelectByLocation();
    }
}
