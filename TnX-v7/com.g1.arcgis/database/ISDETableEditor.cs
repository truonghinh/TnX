using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.edit;

namespace com.g1.arcgis.database
{
    public interface ISDETableEditor
    {
        bool AddRow();
        void SetValue(int col, object value);
        void StoreRow();
        void DeleteRow(string row);
        void SetValue(string oid,int col, object value);
        void SetValue(string oid, string col, object value);
        void StartEditing(bool redoable);
        void StartEditing(esriMultiuserEditSessionMode editSessionMode);
        void StartEditOperation();
        void StopEditOperation();
        void StopEditing(bool saveEdit);
        void SaveEdit();
        void AbortEditOperation();
        ITable GetCurrentTable();
        bool IsEditing();
        void Refresh();
        void Undo();
        bool CheckRowExist(int oid);
        object CreateNewRow();

        void CreateNewRowCache(int rowHandle);
        void CreateNewRowCache(string oid, int rowHandle);
        void CreateNewRowCache(int oid, int rowHandle);
        void CreateUpdateCache(string oid, int rowHandle);
        void CreateUpdateCache(int oid, int rowHandle);
        void CreateDelCache(int oid, int rowHandle);
        void CreateDelCache(string oid, int rowHandle);
        void CacheData(object oidValue, int rowHandle, List<object[,]> pairColVal,EnumTypeOfEdit type);
        List<int> GetNewRowsCached();

        void ClearUpdateCached();
        //void CacheData(object oidValue, int rowHandle, string column, object cellValue);
        //void InitCache(int colCount);
        
    }
}
