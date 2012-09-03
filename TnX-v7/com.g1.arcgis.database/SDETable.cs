using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.ADF;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using com.g1.arcgis.connection;
using com.g1.arcgis.edit;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.database
{
    public struct GDataRow
    {
        private int oid;
        private object oidValue;
        private int rowHandle;
        private int column;
        private string columnName;
        private object cellValue;
        //private bool isComited;
        private List<object[,]> pairColVal;
        
        public GDataRow(int row_handle)
        {
            oid = 0;
            oidValue = -1;
            rowHandle = row_handle;
            column = 0;
            columnName = String.Empty;
            cellValue = 0;
            pairColVal = new List<object[,]>();
        }
        public int OID { get { return oid; } set { oid = value; } }
        public object OID_VALUE { get { return oidValue; } set { oidValue = value; } }
        public int ROW_HANDLE { get { return rowHandle; } set { rowHandle = value; } }
        public int COLUMN { get { return column; } set { column = value; } }
        public string COLUMN_NAME { get { return columnName; } set { columnName = value; } }
        public object CELL_VALUE { get { return cellValue; } set { cellValue = value; } }
        //public bool IS_COMITED { get { return isComited; } set { cellValue = value; } }
        public List<object[,]> PAIR_OF_COL_VAL { get { return pairColVal; } set { pairColVal = value; } }

        public void AddPairColval(int col, object val)
        {
            pairColVal.Add(new object[,] { {col, val} });
        }
    }
    public class SDETable:ISDETableEditor,ISDETableQuery
    {
        private ITable _table = null;
        private IWorkspace _workspace = null;
        private IWorkspaceEdit _workspaceEdit = null;
        private IMultiuserWorkspaceEdit multiWspEdit = null;
        private bool _undoable = true;
        private IRow _currentRow = null;



        private List<GDataRow> _lstCacheNewData = new List<GDataRow>();
        private List<GDataRow> _lstCacheUpdateData = new List<GDataRow>();
        private List<GDataRow> _lstCacheDelData = new List<GDataRow>();

        //_flagCache dung de chon truong hop cacheData:
        //0:new, 1:update, -1:delete
        private List<int> _newRowsCached = new List<int>();
        public SDETable()
        {

        }
        public SDETable(ITable table, IWorkspace workspace)
        {
            _table = table;
           
            _workspace = workspace;
            _workspaceEdit = (IWorkspaceEdit)_workspace;
            multiWspEdit = (IMultiuserWorkspaceEdit)_workspace;
        }

        public SDETable(ITable table, IWorkspaceEdit workspaceEdit)
        {
            _table = table;
            _workspaceEdit = workspaceEdit;
            
        } 

        public bool InsertNewRow(ITable table,IWorkspaceEdit workspace)
        {
            using (ComReleaser comReleaser = new ComReleaser())
            {
                try
                {
                    multiWspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                    workspace.StartEditOperation();
                    _currentRow = table.CreateRow();
                    _currentRow.Store();
                    workspace.StopEditOperation();
                    workspace.StopEditing(true);
                    return true;
                }
                catch {
                    workspace.StopEditOperation();
                    workspace.StopEditing(false);
                    return false; }
                
            }
            
        }

        

        #region ITnSDETableEditor Members

        bool ISDETableEditor.AddRow()
        {

            try
            {
                //if (!_workspaceEdit.IsBeingEdited())
                //    return false;

                //_workspaceEdit.StartEditing(true);
                //multiWspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMNonVersioned);
                //_workspaceEdit.StartEditOperation();
                _currentRow = _table.CreateRow();
                
                
                //_workspaceEdit.StopEditOperation();
                //_workspaceEdit.StopEditing(true);

                //_workspaceEdit.StartEditing(_redoable);


                return true;
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); return false; }

        }

        void ISDETableEditor.SetValue(string oid,int col, object value)
        {
            IQueryFilter qrf = new QueryFilterClass();
            qrf.WhereClause = "objectid='" + oid+"'";
            ICursor cur = _table.Update(qrf, false);
            IRow row = cur.NextRow();
            while (row != null)
            {
                row.set_Value(col, value);
                row.Store();
                row = cur.NextRow();
            }
        }

        void ISDETableEditor.SetValue(string oid, string col, object value)
        {
            if (!_workspaceEdit.IsBeingEdited())
                return;
            _workspaceEdit.StartEditOperation();
            IQueryFilter qrf = new QueryFilterClass();
            qrf.WhereClause = "objectid='" + oid + "'";
            ICursor cur = _table.Update(qrf, false);
            IRow row = cur.NextRow();
            while (row != null)
            {
                row.set_Value(row.Fields.FindField(col), value);
                row.Store();
                row = cur.NextRow();
            }
            _workspaceEdit.StopEditOperation();
        }

        void ISDETableEditor.StartEditing(bool redoable)
        {
            _undoable = redoable;
            //multiWspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
            //_workspaceEdit.StartEditOperation();
            try
            {
                _workspaceEdit.StartEditing(redoable);
            }
            catch (Exception ex) { return; }
            //_workspaceEdit.StartEditOperation();
        }

        void ISDETableEditor.StopEditing(bool saveEdit)
        {
            //_workspaceEdit.StopEditOperation();
            try
            {
                _workspaceEdit.StopEditing(saveEdit);
            }
            catch (COMException comExc)
            {
                if (comExc.ErrorCode == (int)fdoError.FDO_E_VERSION_REDEFINED)
                {
                    // Get the version name.
                    IVersion version = (IVersion)_workspace;
                    String versionName = version.VersionName;

                    // Reconcile the version. Modify this code to reconcile and handle conflicts
                    // in a manner appropriate for the specific application.
                    IVersionEdit4 versionEdit4 = (IVersionEdit4)_workspace;
                    versionEdit4.Reconcile4(versionName, true, false, true, true);

                    // Stop the edit session.
                    _workspaceEdit.StopEditing(true);
                }
                else
                {
                    // A different error has occurred. Handle in an appropriate way for the application.
                    _workspaceEdit.StopEditing(false);
                }
            }
            clearCache();

        }

        void ISDETableEditor.SaveEdit()
        {
            try
            {
                if (!_workspaceEdit.IsBeingEdited())
                {
                    
                    return;
                }
                //MessageBox.Show("edit");
                //kiem tra co doi tuong trong cache
                ((ISDETableEditor)this).StartEditOperation();
                try
                {
                    createNewRows();
                    updateRows();
                    deleteRows();
                    ((ISDETableEditor)this).StopEditOperation();
                    ((ISDETableEditor)this).StopEditing(true);
                }
                catch (Exception ex)
                {
                    ((ISDETableEditor)this).StopEditOperation();
                    ((ISDETableEditor)this).StopEditing(false);
                }
                finally
                {
                    ((ISDETableEditor)this).StartEditing(_undoable);
                }
                //_workspaceEdit.StopEditing(true);
                //_workspaceEdit.StartEditing(_redoable);



                //_workspaceEdit.StartEditOperation();
                //_workspaceEdit.StopEditing(true);
                //_workspaceEdit.StartEditing(_redoable);
                //_workspaceEdit.StartEditOperation();
            }
            catch (Exception e) {
                ((ISDETableEditor)this).StopEditOperation();
                ((ISDETableEditor)this).StopEditing(false); 
                MessageBox.Show(e.ToString());
            }
        }

        ITable ISDETableEditor.GetCurrentTable()
        {
            return _table;
            
        }

        bool ISDETableEditor.IsEditing()
        {
            return _workspaceEdit.IsBeingEdited();
        }

        void ISDETableEditor.DeleteRow(string row)
        {
            //_workspaceEdit.StartEditOperation();
            //IQueryFilter qrf=new QueryFilterClass();
            //qrf.WhereClause="objectid="+row;
            ////_workspaceEdit.StartEditOperation();
            //_table.DeleteSearchedRows(qrf);
            //_workspaceEdit.StopEditOperation();
            ////_workspaceEdit.StopEditing(true);
            ////_workspaceEdit.StartEditing(_redoable);
            ////_workspaceEdit.StartEditOperation();

            deleteRows();
        }


        void ISDETableEditor.Refresh()
        {
            
        }

        void ISDETableEditor.StartEditOperation()
        {
            _workspaceEdit.StartEditOperation();
        }

        void ISDETableEditor.StopEditOperation()
        {
            _workspaceEdit.StopEditOperation();
        }

        void ISDETableEditor.StartEditing(esriMultiuserEditSessionMode editSessionMode)
        {
            if (multiWspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
            {
                if (_workspaceEdit.IsBeingEdited())
                {
                    //MessageBox.Show("line 313 SdeTable, edited");
                    _workspaceEdit.StopEditOperation();
                    _workspaceEdit.StopEditing(false);
                }
                multiWspEdit.StartMultiuserEditing(editSessionMode);
            }
            else
            {
                _workspaceEdit.StartEditing(true);
            }
        }

        void ISDETableEditor.Undo()
        {
            _workspaceEdit.UndoEditOperation();
        }

        bool ISDETableEditor.CheckRowExist(int oid)
        {
            try
            {
                IRow r = null;
                r = _table.GetRow(oid);
                if (r == null)
                    return false;
                return true;
            }
            catch { return false; }

        }


        void ISDETableEditor.SetValue(int col, object value)
        {
            _currentRow.set_Value(col, value);
        }

        void ISDETableEditor.StoreRow()
        {
            _currentRow.Store();
        }


        object ISDETableEditor.CreateNewRow()
        {
            _currentRow = _table.CreateRow();
            return _currentRow.get_Value(0);
        }


        void ISDETableEditor.CreateNewRowCache(string oid, int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.OID_VALUE=oid;
            newRow.ROW_HANDLE=rowHandle;
            _lstCacheNewData.Add(newRow);
        }

        void ISDETableEditor.CreateNewRowCache(int oid, int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.OID_VALUE = oid;
            newRow.ROW_HANDLE = rowHandle;
            _lstCacheNewData.Add(newRow);
        }

        void ISDETableEditor.CreateUpdateCache(string oid, int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.OID_VALUE = oid;
            newRow.ROW_HANDLE = rowHandle;
            _lstCacheUpdateData.Add(newRow);
        }

        void ISDETableEditor.CreateUpdateCache(int oid, int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.OID_VALUE = oid;
            newRow.ROW_HANDLE = rowHandle;
            _lstCacheUpdateData.Add(newRow);
        }

        void ISDETableEditor.CreateDelCache(int oid, int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.OID_VALUE = oid;
            newRow.ROW_HANDLE = rowHandle;
            _lstCacheDelData.Add(newRow);
        }

        void ISDETableEditor.CreateDelCache(string oid, int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.OID_VALUE = oid;
            newRow.ROW_HANDLE = rowHandle;
            _lstCacheDelData.Add(newRow);
        }

        void ISDETableEditor.CacheData(object oidValue, int rowHandle, List<object[,]> pair_ColVal,EnumTypeOfEdit type)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            int i = -1;
            int len = pair_ColVal.Count;
            switch (type)
            {
                case EnumTypeOfEdit.NEW: //create new
                    i = -1;
                    foreach (GDataRow r in _lstCacheNewData)
                    {
                        if (r.ROW_HANDLE == rowHandle)
                        {
                            
                            i = _lstCacheNewData.IndexOf(r);

                            break;
                        }
                    }
                    if (_lstCacheNewData.Count != 0 && i!=-1)
                    {
                        _lstCacheNewData.RemoveAt(i);
                    }
                    newRow.OID_VALUE = oidValue;
                    newRow.ROW_HANDLE = rowHandle;
                    //newRow.PAIR_OF_COL_VAL = pair_ColVal; <--- ko duoc su dung: gan reference
                    
                    for (int k = 0; k < len; k++)
                    {
                        
                        newRow.PAIR_OF_COL_VAL.Add( pair_ColVal[k]);
                    }
                    _lstCacheNewData.Add(newRow);

                    break;
                case EnumTypeOfEdit.UPDATE: //update
                    i = -1;
                    //MessageBox.Show(oidValue.ToString());
                    foreach (GDataRow r in _lstCacheUpdateData)
                    {
                        if (r.OID_VALUE == oidValue)
                        {
                            //MessageBox.Show("truoc: "+_lstCacheUpdateData.Count.ToString());
                            i = _lstCacheUpdateData.IndexOf(r);
                            //MessageBox.Show("sau: "+_lstCacheUpdateData.Count.ToString()+"--"+i.ToString());
                            break;
                        }
                    }
                    if (_lstCacheUpdateData.Count != 0 && i!=-1)
                    {
                        //MessageBox.Show("truoc remove");
                        _lstCacheUpdateData.RemoveAt(i);
                        //MessageBox.Show("sau remove");
                    }
                    newRow.OID_VALUE = oidValue;
                    newRow.ROW_HANDLE = rowHandle;
                    for (int k = 0; k < len; k++)
                    {
                        newRow.PAIR_OF_COL_VAL.Add(pair_ColVal[k]);
                    }
                    _lstCacheUpdateData.Add(newRow);
                    
                    break;
                case EnumTypeOfEdit.DELETE: //delete
                    i = -1;
                    foreach (GDataRow r in _lstCacheDelData)
                    {
                        if (r.OID_VALUE == oidValue)
                        {
                            i = _lstCacheDelData.IndexOf(r);
                            break;
                        }
                    }
                    if (_lstCacheDelData.Count != 0 && i!=-1)
                    {
                        
                        _lstCacheDelData.RemoveAt(i);
                        //MessageBox.Show("hang new:" + _lstCacheNewData.Count.ToString());
                    }
                    newRow.OID_VALUE = oidValue;
                    //newRow.ROW_HANDLE = rowHandle;
                    
                    //for (int k = 0; k < len; k++)
                    //{
                    //    newRow.PAIR_OF_COL_VAL.Add(pair_ColVal[k]);
                    //}
                    _lstCacheDelData.Add(newRow);
                    break;
                default: break;
            }
        }

        //void ITnSDETableEditor.CacheData(object oidValue, int rowHandle, string column, object cellValue)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private void createNewRows()
        {
            IRow newRow;
            if (_lstCacheNewData.Count == 0)
            {
                //MessageBox.Show(_lstCacheNewData.Count.ToString());
                return;
            }
            //MessageBox.Show(_lstCacheNewData.Count.ToString());
            int i=0;
            int col=0;
            //MessageBox.Show(_lstCacheNewData.Count.ToString());

            foreach (GDataRow r in _lstCacheNewData)
            {
                newRow = _table.CreateRow();
                for(int j=0;j<r.PAIR_OF_COL_VAL.Count;j++)
                {
                    col=int.Parse(r.PAIR_OF_COL_VAL[j][0,0].ToString());
                    newRow.set_Value(col, r.PAIR_OF_COL_VAL[j][0, 1]);
                    //MessageBox.Show(col.ToString() + "--" + r.PAIR_OF_COL_VAL[j][0, 1]);
                }
                newRow.Store();
                i++;
            }
            //((ITnSDETableEditor)this).StopEditOperation();
            //((ITnSDETableEditor)this).StopEditing(true);
            //((ITnSDETableEditor)this).StartEditing(_redoable);

        }
        private void deleteRows()
        {
            if (_lstCacheDelData.Count == 0)
                return;
            IQueryFilter qrf = new QueryFilterClass();
            //qrf.WhereClause = "objectid=";
            string dk = String.Empty;
            string oid = String.Empty;
            int i = 0;
            foreach (GDataRow r in _lstCacheDelData)
            {
                oid = r.OID_VALUE.ToString();
                if (i == 0)
                {
                    dk = "objectid=" + oid;
                    i++;
                }
                dk += " or objectid=" + oid;
            }
            qrf.WhereClause = dk;
            _table.DeleteSearchedRows(qrf);
        }

        private void updateRows()
        {
            if (_lstCacheUpdateData.Count == 0)
            {
                return;
            }
            IRow row=null;
            int col = 0;
            int oid=0;
            //MessageBox.Show("so luong dong can update: "+_lstCacheUpdateData.Count.ToString());
            foreach (GDataRow r in _lstCacheUpdateData)
            {
                if (r.PAIR_OF_COL_VAL.Count == 0)
                    continue;
                //MessageBox.Show("dong r "+r.PAIR_OF_COL_VAL.Count);
                //MessageBox.Show("--"+r.PAIR_OF_COL_VAL[1][0,1]);
                oid=int.Parse(r.OID_VALUE.ToString());

                //MessageBox.Show(oid.ToString());
                try
                {
                    row = _table.GetRow(oid);
                    for (int j = 0; j < r.PAIR_OF_COL_VAL.Count; j++)
                    {
                        col = int.Parse(r.PAIR_OF_COL_VAL[j][0, 0].ToString());
                        //MessageBox.Show(col.ToString() + "--" + r.PAIR_OF_COL_VAL[j][0, 1]);
                        row.set_Value(col, r.PAIR_OF_COL_VAL[j][0, 1]);
                        
                    }
                }
                catch (Exception e1) { MessageBox.Show(string.Format("col:{0} \n {2}",col,e1.ToString())); }
                row.Store();
            }
        }

        private void clearCache()
        {
            _lstCacheNewData.Clear();
            _lstCacheUpdateData.Clear();
            _lstCacheDelData.Clear();
            _newRowsCached.Clear();
        }

        #region ITnSDETableEditor Members


        void ISDETableEditor.CreateNewRowCache(int rowHandle)
        {
            GDataRow newRow = new GDataRow(rowHandle);
            newRow.ROW_HANDLE = rowHandle;
            _lstCacheNewData.Add(newRow);
            _newRowsCached.Add(rowHandle);
        }

        List<int> ISDETableEditor.GetNewRowsCached()
        {
            return _newRowsCached;
        }

        #endregion

        #region ITnSDETableQuery Members

        List<string> ISDETableQuery.GetLayersAndTables()
        {
            List<string> result = new List<string>();
            string sql = "select table_name from "+DataNameTemplate.INFORMATION_SCHEMA_TABLES+" tab where tab.TABLE_NAME in (select cols.TABLE_NAME from "+DataNameTemplate.INFORMATION_SCHEMA_COLUMNS+" cols where cols.COLUMN_NAME='objectid')";
            string connectionString = String.Empty;
            //connetionString = GConnectionString.TRUSTED_CONNECT_EXPRESS;
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
            ISqlUserInfo sqlUser = sdeUser.GetSqlUserInfo();
            //IUserInfo userInfo = (IUserInfo)sqlUser;
            connectionString = sqlUser.GetConnectionString();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command=new SqlCommand(sql,connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
            }
            catch
            {
                //connectionString = GConnectionString.TRUSTED_CONNECT_NON_EXPRESS;
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    SqlCommand command=new SqlCommand(sql,connection);;
                //    connection.Open();
                //    SqlDataReader reader = command.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        result.Add(reader.GetString(0));
                //    }
                //}
                //return null;
            }
            return result;
        }

        List<string> ISDETableQuery.GetLayers()
        {
            List<string> result = new List<string>();
            string sql = "select table_name from " + DataNameTemplate.INFORMATION_SCHEMA_TABLES + " tab where tab.TABLE_NAME in (select cols.TABLE_NAME from " + DataNameTemplate.INFORMATION_SCHEMA_COLUMNS + " cols where cols.COLUMN_NAME='Shape') ORDER BY table_name";
            string connectionString = String.Empty;
            //connetionString = GConnectionString.TRUSTED_CONNECT_EXPRESS;
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
            ISqlUserInfo sqlUser = sdeUser.GetSqlUserInfo();
            //IUserInfo userInfo = (IUserInfo)sqlUser;
            connectionString = sqlUser.GetConnectionString();
            //MessageBox.Show(string.Format("line 647 SDETable string={0}", connectionString));
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
            }
            catch
            {
                //connectionString = GConnectionString.TRUSTED_CONNECT_NON_EXPRESS;
                //using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    SqlCommand command = new SqlCommand(sql, connection); ;
                //    connection.Open();
                //    SqlDataReader reader = command.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        result.Add(reader.GetString(0));
                //    }
                //}
                //return null;
            }
            return result;
        }

        List<string> ISDETableQuery.GetTable()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ITnSDETableEditor Members


        void ISDETableEditor.ClearUpdateCached()
        {
            _lstCacheUpdateData.Clear();
        }

        #endregion

        #region ISDETableEditor Members


        void ISDETableEditor.AbortEditOperation()
        {
            _workspaceEdit.AbortEditOperation();

        }

        #endregion

    }
}
