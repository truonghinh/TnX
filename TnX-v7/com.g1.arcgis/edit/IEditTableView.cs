using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.edit
{
    public interface IEditTableView
    {
        void StartEdit();
        void StopEdit();
        void SaveEdit();
        void CreateNewRow();
        void DeleteRow();
        void DeleteRows();
        void DbConnectOccur();
        void DbDisConnectOccur();
        string ExpectedTableName { get; set; }
        void AddNewField(string name);
        void Refresh();
        bool AllowAddNewRow { get; set; }
        bool AllowDeleteRows { get; set; }
        List<string[,]> AliasFieldName { get; set; }
        bool IsBarAllowCopyEnable { get; set; }
        void RefreshView();
        void CreateNewRowCache();
        void CacheData4NewRow(int rowHandle);
        void CacheData4NewRow(int rowHandle, params ColValPair[] modify);
        bool IsEditing();
        bool IsSaveEdited();
        void SetContextMenuType(int type);
        void SetRowCellValue(int row, string column, object value);
        event EditTableEventHandler Editing;
    }
}
