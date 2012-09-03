using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.g1.arcgis.connection;
using com.g1.collection;
using System.Windows.Forms;
using System.Diagnostics;

namespace com.g1.arcgis.database
{
    public class Loader:ILoader
    {
        event LoaderFinishedEventHandler _finished;
        public virtual void onFinished(LoaderEventArg ea)
        {
            if (_finished != null)
                _finished(null/*this*/, ea);
        }
        private List<IReceiverView> _lstView = new List<IReceiverView>();
        private IDictionary<EnumG1ArcGisTnRecType, string> _dicTableName;
        private ISQLTable _sqlTable = SQLTable.CallMe;
        private ISqlUserInfo _sqlUser;
        //private XPair _pair;
        private string _sql="";
        #region ILoader Members
        public Loader() : this(null) { }
        public Loader(IReceiverView view)
        {
            if (view != null)
            {
                _lstView.Add(view);
            }
            
            _dicTableName = new Dictionary<EnumG1ArcGisTnRecType, string>();
        }
        void ILoader.Load(EnumG1ArcGisTnRecType type)
        {
            //*************
            //Lay connection info hien tai
            //SdeUserInfo va SqlUserInfo la static
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
            //ISqlConnectionInfo sqlConn = (ISqlConnectionInfo)sdeConn;

            //MessageBox.Show(sqlConn.GetSqlUserInfo().UserName);
            _sqlUser = sdeUser.GetSqlUserInfo();

            SqlDataReader reader = null;
            //_pair = new XPair();
            LoaderEventArg e=new LoaderEventArg(type);
            //MessageBox.Show(string.Format("line 39 Loader:--{0}, so luong view:{1}", _sql, _lstView.Count));
            try
            {
                if (_sqlTable.IsClosed())
                {
                    _sqlTable.SetUserInfo(_sqlUser.GetConnectionStringAsArray());
                    //MessageBox.Show(String.Format("line 59 Loader, ConnectionString={0}", _sqlUser.GetConnectionString()));
                    
                    _sqlTable.OpenConnection();
                }

                reader = _sqlTable.GetSqlCommand(_sql).ExecuteReader();
                //MessageBox.Show("line 49 Loader: --" + reader.HasRows.ToString() + "--" + _sql);
                //_pair.ClearPair();
                foreach (IReceiverView r in _lstView)
                {
                    r.ReceiveData(reader,type);
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

        void ILoader.Reload()
        {
            throw new NotImplementedException();
        }

        string ILoader.Sql
        {
            get
            {
                return _sql;
            }
            set
            {
                this._sql=value;
            }
        }

        void ILoader.AddReceiver(IReceiverView view)
        {
            if (view != null)
            {
                _lstView.Add(view);
            }
        }

        event LoaderFinishedEventHandler ILoader.Finished
        {
            add { this._finished+=value; }
            remove { this._finished -= value; }
        }

        IDictionary<EnumG1ArcGisTnRecType, string> ILoader.DicTableName
        {
            get
            {
                return this._dicTableName;
            }
            set
            {
                this._dicTableName = value;
            }
        }

        #endregion
    }
}
