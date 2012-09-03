using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using com.g1.arcgis.connection;
//using com.g1.GSdeToolBox.Database;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using gov.tn;
using com.g1.arcgis.database;

namespace com.g1.arcgis.tn.query
{
    public class AttributeQuery:IInfoQuery
    {
        private ISQLTable _sqlTable;
        private ISqlUserInfo _sqlUser;
        private string _sql = "";
        private string _selectSql = "";
        private List<IAttributeQueryView> _views;
        private TnThuaInfo _thuaInfo;

        event QueryFinishedEventHandler _finished;
        public virtual void onFinished(QueryEventArg ea)
        {
            if (_finished != null)
                _finished(null/*this*/, ea);
        }

        public AttributeQuery() : this(null) { }

        public AttributeQuery(IAttributeQueryView view)
        {
            this._sqlTable = SQLTable.CallMe;
            this._views = new List<IAttributeQueryView>();
            if (view != null)
            {
                this._views.Add(view);
            }
        }

        #region IAttributeQuery Members

        void IAttributeQuery.AddReceiver(IAttributeQueryView receiver)
        {
            throw new NotImplementedException();
        }

        void IAttributeQuery.Excute()
        {
            //*************
            //Lay connection info hien tai
            //SdeUserInfo va SqlUserInfo la static
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            ISqlConnectionInfo sqlConn = (ISqlConnectionInfo)sdeConn;
            _sqlUser = sqlConn.GetSqlUserInfo();

            SqlDataReader reader = null;
            QueryEventArg e = new QueryEventArg();

            try
            {
                if (_sqlTable.IsClosed())
                {
                    _sqlTable.SetUserInfo(_sqlUser.GetConnectionStringAsArray());
                    _sqlTable.OpenConnection();
                }

                reader = _sqlTable.GetSqlCommand(_sql).ExecuteReader();
                //MessageBox.Show("line 49 Loader: --" + reader.HasRows.ToString() + "--" + _sql);
                //_pair.ClearPair();
                foreach (IAttributeQueryView r in _views)
                {
                    r.ReceiveResult(reader,EnumTypeOfResult.Thua);
                }
                reader.Close();
                _sqlTable.CloseConnection();
                onFinished(e);

            }
            catch (Exception e1)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                _sqlTable.CloseConnection();
                //MessageBox.Show("line 67 - Loader \n" + e1.ToString());
            }
        }

        event QueryFinishedEventHandler IAttributeQuery.Finished
        {
            add { this._finished+=value; }
            remove { this._finished -= value; }
        }

        string IAttributeQuery.SqlCommand
        {
            get
            {
                return this._sql;
            }
            set
            {
                this._sql=value;
            }
        }

        void IAttributeQuery.ExcuteForDataSet()
        {
            try
            {
                SdeConnection conn = new SdeConnection();
                ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
                OleDbDataAdapter oAdapter = new OleDbDataAdapter(this._selectSql, sdeConn.GetOleDbConnection());
                DataSet dataset = new DataSet();
                oAdapter.Fill(dataset);
                foreach (IAttributeQueryView r in _views)
                {
                    r.ReceiveResult(dataset);
                }
            }
            catch
            { }
        }

        string IAttributeQuery.SelectSqlCommand
        {
            get
            {
                return this._selectSql;
            }
            set
            {
                this._selectSql=value;
            }
        }

        #endregion

        #region IInfoQuery Members

        TnThuaInfo IInfoQuery.ThuaInfo
        {
            get
            {
                return this._thuaInfo;
            }
            set
            {
                this._thuaInfo = value;
            }
        }

        #endregion
    }
}
