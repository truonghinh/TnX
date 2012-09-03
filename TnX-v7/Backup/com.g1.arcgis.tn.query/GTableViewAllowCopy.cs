using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.query;
using com.g1.arcgis.edit;
using com.g1.arcgis.database;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
using System.Data.OleDb;
using DevExpress.XtraBars.Docking;
using com.g1.arcgis.landprice;

namespace com.g1.arcgis.tn.query
{
    public partial class GTableViewAllowCopy : DevExpress.XtraEditors.XtraUserControl, IAttributeQueryView, IEditTableView
    {
        //private DockPanel _parent;
        private ISDETableEditor _sdeEditor;
        private ISQLTable sqlTable = SQLTable.CallMe;
        private bool _isSaveed;
        private int _newRowHandle;
        private int _prevRowHandle;
        private bool _isConnected;
        private bool _isCurRowChangeValue;
        private string _tableName = "";
        private List<object[,]> _valOfCurRow;
        private string _oid = "";
        private string _shape="";
        private string _shpArea = "";
        private string _shpLenght = "";
        private OleDbDataAdapter _oAdapter;
        private DataSet _dataset = new DataSet();
        private bool _allowAddRow=true;
        private bool _allowDeleteRows = true;
        private List<string[,]> _aliasFieldName;
        public GTableViewAllowCopy()
        {
            InitializeComponent();
            //this.grvAttributeTable.OptionsBehavior.Editable = false;
            this._valOfCurRow = new List<object[,]>();
            this._aliasFieldName = new List<string[,]>();
            this._oid = "OBJECTID";
            this._shape = "Shape";
            this._shpArea = "Shape.area";
            this._shpLenght = "Shape.lenght";
            this._isCurRowChangeValue = false;
            this._isSaveed = true;
            this._isConnected = false;
            this.grvAttributeTable.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(grvAttributeTable_InitNewRow);
            this.grvAttributeTable.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(grvAttributeTable_FocusedRowChanged);
            this.grvAttributeTable.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(grvAttributeTable_CellValueChanged);
            switchStopEdit();
        }

        void grvAttributeTable_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._isSaveed = false;
            this._isCurRowChangeValue = true;
        }

        private void loadData(string table)
        {

            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            ISqlUserInfo _user = sdeConn.GetSqlUserInfo();
            try
            {
                _oAdapter = new OleDbDataAdapter("select * from " + table, sdeConn.GetOleDbConnection());
                _dataset.Reset();
                _oAdapter.Fill(_dataset);
                this.grcAttributeTable.DataSource = _dataset.Tables[0];
            }
            catch { }

            hide2Cols();
            //try
            //{
            //    if (sqlTable.IsClosed())
            //    {
            //        sqlTable.SetUserInfo(_user.GetConnectionStringAsArray());
            //        sqlTable.OpenConnection();
            //    }
            //    string sql = "select * from " + table;

            //    using (SqlDataAdapter adap = new SqlDataAdapter(sql, sqlTable.GetConnection))
            //    {
            //        DataTable t = new DataTable();
            //        adap.Fill(t);
            //        this.grcAttributeTable.DataSource = t;
            //        //grvLoaiXa.Columns.ColumnByFieldName(_tableName.LOAI_XA.OID).Visible = false;
            //        //gridView1.Columns.ColumnByName("duocchon").ColumnEdit = this.repositoryItemCheckEdit1;
            //    }
            //}
            //catch { }
        }

        private void hide2Cols()
        {
            GridColumn oidCol = this.grvAttributeTable.Columns.ColumnByFieldName(this._oid);
            GridColumn shpCol = this.grvAttributeTable.Columns.ColumnByFieldName(this._shape);
            GridColumn areaCol = this.grvAttributeTable.Columns.ColumnByFieldName(this._shpArea);
            GridColumn lenCol = this.grvAttributeTable.Columns.ColumnByFieldName(this._shpLenght);
            if (oidCol!=null)
            {
                oidCol.Visible = false;
            }
            if (shpCol != null)
            {
                shpCol.Visible = false;
            }
            if (areaCol != null)
            {
                areaCol.Visible = false;
            }
            if (lenCol != null)
            {
                lenCol.Visible = false;
            }
        }

        private void addEditValueLoaiXa(int row)
        {
            this._valOfCurRow.Clear();
            for (int i = 0; i < this.grvAttributeTable.Columns.Count; i++)
            {
                if (this.grvAttributeTable.Columns[i].FieldName == this._oid)
                {
                    continue;
                }
                this._valOfCurRow.Add(new object[,] { { i, this.grvAttributeTable.GetRowCellValue(row, this.grvAttributeTable.Columns[i].FieldName) } });

            }

        }

        private void addEditValueLoaiXa(int row,params ColValPair[] modify)
        {
            this._valOfCurRow.Clear();
            int len=modify.Length;
            
            string field = "";
            for (int i = 0; i < this.grvAttributeTable.Columns.Count; i++)
            {
                field = this.grvAttributeTable.Columns[i].FieldName;
                bool flag = false;
                if ( field== this._oid)
                {
                    continue;
                }
                for (int j = 0; j < len;j++ )
                {
                    if (field == modify[j].ColName)
                    {
                        this._valOfCurRow.Add(new object[,] { { i, modify[j].ColValue } });
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    this._valOfCurRow.Add(new object[,] { { i, this.grvAttributeTable.GetRowCellValue(row, this.grvAttributeTable.Columns[i].FieldName) } });
                }

            }

        }

        void grvAttributeTable_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //MessageBox.Show(e.PrevFocusedRowHandle.ToString());
            int max = e.PrevFocusedRowHandle - 1;
            this._prevRowHandle = e.PrevFocusedRowHandle;
            if (max.CompareTo(10000000) == 1 || this._prevRowHandle < 0)
            {
                this._prevRowHandle = this.grvAttributeTable.RowCount - 1;
            }
            //MessageBox.Show(this._isCurRowChangeValue.ToString());
            if (this._isCurRowChangeValue)
            {
                //MessageBox.Show(string.Format("hang cap nhat:{0}", this._prevRowHandle));
                addEditValueLoaiXa(this._prevRowHandle);

                foreach (int i in _sdeEditor.GetNewRowsCached())
                {
                    //MessageBox.Show(i.ToString() + "--" + e.RowHandle.ToString());
                    //Neu hang vua roi khoi la hang moi
                    if (this._prevRowHandle == i)
                    {
                        //MessageBox.Show(string.Format("cot {0},{1}", _valOfCurRow[0][0, 0], _valOfCurRow[0][0, 1]));
                        //MessageBox.Show(string.Format("hang da luu cache:{0}", i));
                        //MessageBox.Show(_curRowVal[1][0,1]+"---"+_curRowVal)
                        this._sdeEditor.CacheData("", this._prevRowHandle, this._valOfCurRow, EnumTypeOfEdit.NEW);
                        //barStaticItem2.Caption = _curRowVal[0][0, 1].ToString() + _curRowVal[1][0, 1].ToString();
                        this._isCurRowChangeValue = false;
                        return;
                    }

                }
                //MessageBox.Show(string.Format("cap nhat hang cu:{0}", this._prevRowHandle));
                //neu hang vua roi khoi ko phai la hang moi --> update
                this._sdeEditor.CacheData(this.grvAttributeTable.GetRowCellValue(this._prevRowHandle, this._oid), this._prevRowHandle, this._valOfCurRow, EnumTypeOfEdit.UPDATE);
            }
            this._isCurRowChangeValue = false;

        }

        void grvAttributeTable_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this._newRowHandle = e.RowHandle;
            //MessageBox.Show(string.Format("hang vua tao2:{0}", this._newRowHandle));
        }

        #region IAttributeQueryView Members

        void IAttributeQueryView.Excute()
        {
            throw new NotImplementedException();
        }

        void IAttributeQueryView.ExcuteForDataSet()
        {
            throw new NotImplementedException();
        }

        void IAttributeQueryView.ReceiveResult(System.Data.SqlClient.SqlDataReader data, EnumTypeOfResult type)
        {
            throw new NotImplementedException();
        }

        void IAttributeQueryView.ReceiveResult(DataSet data)
        {
            throw new NotImplementedException();
        }

        string IAttributeQueryView.SelectSqlCommand
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IAttributeQueryView.SqlCommand
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IAttributeQueryView.UpdateThuaInfo()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEditTableView Members

        void IEditTableView.CreateNewRow()
        {
            this._isSaveed = false;
            //chu y ko duoc dao thu tu cua 2 dong sau
            this._sdeEditor.CreateNewRowCache(this.grvAttributeTable.RowCount);
            this.grvAttributeTable.AddNewRow();
            this._newRowHandle = this.grvAttributeTable.FocusedRowHandle;
            //MessageBox.Show(string.Format("hang vua tao1:{0}",this._newRowHandle));
        }

        void IEditTableView.DeleteRow()
        {
            this._isSaveed = false;
            int row = this.grvAttributeTable.GetSelectedRows()[0];
            string oid = this.grvAttributeTable.GetDataRow(row)[this._oid].ToString();
            this._sdeEditor.CreateDelCache(oid, 0);
            this.grvAttributeTable.DeleteRow(row);
        }

        void IEditTableView.DeleteRows()
        {
            this._isSaveed = false;
            int[] rows = this.grvAttributeTable.GetSelectedRows();
            string oid = "";
            for (int i = 0; i < rows.Length; i++)
            {
                oid = this.grvAttributeTable.GetDataRow(rows[i])[this._oid].ToString();
                this._sdeEditor.CreateDelCache(oid, 0);
            }
            this.grvAttributeTable.DeleteSelectedRows();
        }

        void IEditTableView.SaveEdit()
        {
            this._sdeEditor.SaveEdit();
            this._isSaveed = true;
            ((IEditTableView)this).Refresh();
        }

        void IEditTableView.StartEdit()
        {
            this._sdeEditor.StartEditing(true);
            
            switchStartEdit();
        }

        

        void IEditTableView.StopEdit()
        {
            DialogResult result;
            if (!this._isSaveed)
            {
                result = MessageBox.Show("Lưu cập nhật", "Ngưng cập nhật", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this._sdeEditor.SaveEdit();
                    this._sdeEditor.StopEditing(true);
                }
                else if (result == DialogResult.No)
                {
                    this._sdeEditor.StopEditing(false);
                }
            }
            this._isSaveed = true;
            switchStopEdit();
            
            ((IEditTableView)this).Refresh();
        }

        #region switch start stop

        private void switchStartEdit()
        {
            this.grvAttributeTable.OptionsBehavior.Editable = true;
            this.grvAttributeTable.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvAttributeTable.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.bbiStartEdit.Enabled = false;
            this.bbiStopEdit.Enabled = true;
            this.bbiLuu.Enabled = true;
            this.bbiThem.Enabled = this._allowAddRow;
            this.bbiXoa.Enabled = this._allowDeleteRows;
        }

        private void switchStopEdit()
        {
            this.grvAttributeTable.OptionsBehavior.Editable = false;
            this.grvAttributeTable.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvAttributeTable.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.bbiStartEdit.Enabled = true;
            this.bbiStopEdit.Enabled = false;
            this.bbiLuu.Enabled = false;
            this.bbiThem.Enabled = false;
            this.bbiXoa.Enabled = false;
        }

        #endregion

        void IEditTableView.DbConnectOccur()
        {

            _isConnected = true;
            if (this._tableName == "")
            {
                return;
            }
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            ITable table = null;
            try
            {
                table = fw.OpenTable(this._tableName);
                loadData(this._tableName);
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Không tìm thấy bảng {0}", this._tableName));
                return;
            }
            this._sdeEditor = new SDETable(table, sdeConn.Workspace);
        }

        void IEditTableView.DbDisConnectOccur()
        {
            ((IEditTableView)this).StopEdit();
        }

        string IEditTableView.ExpectedTableName
        {
            get
            {
                return this._tableName;
            }
            set
            {
                this._tableName = value;
            }
        }

        void IEditTableView.AddNewField(string name)
        {
            //GridColumn grcol= this.grvAttributeTable.Columns.AddField(name);
            GridColumn grcol = new GridColumn();
            grcol.FieldName = "hello";
            grcol.Caption = "hello";
            this.grvAttributeTable.Columns.Add(grcol);
            grcol.VisibleIndex = 0;
            grcol.Visible = true;
            //MessageBox.Show(this.grvAttributeTable.Columns.Count.ToString());
        }

        void IEditTableView.Refresh()
        {
            try
            {
                _dataset.Reset();
                _oAdapter.Fill(_dataset);
                this.grcAttributeTable.DataSource = _dataset.Tables[0];
            }
            catch { }
        }

        #endregion

        private void bbiStartEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((IEditTableView)this).StartEdit();
        }

        private void bbiStopEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((IEditTableView)this).StopEdit();
        }

        private void bbiThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((IEditTableView)this).CreateNewRow();
        }

        private void bbiXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((IEditTableView)this).DeleteRows();
        }

        private void bbiLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((IEditTableView)this).SaveEdit();
            //this.bbiLuu.Enabled = false;
        }

        #region IEditTableView Members


        bool IEditTableView.AllowAddNewRow
        {
            get
            {
                return this._allowAddRow;
            }
            set
            {
                this._allowAddRow=value;
            }
        }

        bool IEditTableView.AllowDeleteRows
        {
            get
            {
                return this._allowDeleteRows;
            }
            set
            {
                this._allowDeleteRows=value;
            }
        }

        #endregion

        #region IEditTableView Members


        List<string[,]> IEditTableView.AliasFieldName
        {
            get
            {
                return this._aliasFieldName;
            }
            set
            {
                int c=this.grvAttributeTable.Columns.Count;
                for (int i = 0; i < c; i++)
                {
                    this.grvAttributeTable.Columns[i].Visible = false;
                }
                this._aliasFieldName = value;
                int j = 1;
                foreach (string[,] fi in this._aliasFieldName)
                {
                    try
                    {
                        this.grvAttributeTable.Columns.ColumnByFieldName(fi[0, 0]).Caption = fi[0, 1];
                        this.grvAttributeTable.Columns.ColumnByFieldName(fi[0, 0]).Visible = true;
                        this.grvAttributeTable.Columns.ColumnByFieldName(fi[0, 0]).VisibleIndex = j;
                    }
                    catch { continue; }
                    finally
                    {
                        j++;
                    }
                }
                //hide2Cols();
            }
        }

        #endregion

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ((IEditTableView)this).Refresh();
        }

        #region IEditTableView Members


        bool IEditTableView.IsBarAllowCopyEnable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        private void bbiCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ICopyDataView cp = new CopyDataView(this);
            cp.Data =(DataTable)this.grcAttributeTable.DataSource;
            cp.ShowDialog();
        }

        #region IEditTableView Members


        void IEditTableView.RefreshView()
        {
            this.grvAttributeTable.RefreshData();
            //MessageBox.Show(grvAttributeTable.RowCount.ToString());
        }

        #endregion

        #region IEditTableView Members


        void IEditTableView.CreateNewRowCache()
        {
            this._isSaveed = false;
            this._sdeEditor.CreateNewRowCache(this.grvAttributeTable.RowCount);
        }

        #endregion

        #region IEditTableView Members


        void IEditTableView.CacheData4NewRow(int rowHandle)
        {
            this._sdeEditor.CreateNewRowCache(rowHandle);
            addEditValueLoaiXa(rowHandle);
            this._sdeEditor.CacheData("", rowHandle, this._valOfCurRow, EnumTypeOfEdit.NEW);
        }

        #endregion

        #region IEditTableView Members


        void IEditTableView.CacheData4NewRow(int rowHandle, params ColValPair[] modify)
        {
            this._sdeEditor.CreateNewRowCache(rowHandle);
            addEditValueLoaiXa(rowHandle,modify);
            this._sdeEditor.CacheData("", rowHandle, this._valOfCurRow, EnumTypeOfEdit.NEW);
        }

        #endregion

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        #region IEditTableView Members


        bool IEditTableView.IsEditing()
        {
            throw new NotImplementedException();
        }

        bool IEditTableView.IsSaveEdited()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEditTableView Members


        void IEditTableView.SetContextMenuType(int type)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAttributeQueryView Members


        void IAttributeQueryView.SetMapView(com.g1.arcgis.map.IMapView mapView)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAttributeQueryView Members


        void IAttributeQueryView.SetDetailView(ILandpriceView calcView, ILandpriceView publicView)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEditTableView Members


        void IEditTableView.SetRowCellValue(int row, string column, object value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEditTableView Members


        event EditTableEventHandler IEditTableView.Editing
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        #endregion
    }
}
