using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using com.g1.arcgis.database;
using com.g1.arcgis.connection;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;

namespace com.g1.arcgis.tn.query
{
    public class QueryThua:IQueryThua
    {
        private object _type;
        private IInfoForQuery _info;
        private ISQLTable _sqlTable;
        private ISqlUserInfo _sqlUser;
        private List<IQueryThuaView> _views;
        private BackgroundWorker _bwk;
        event QueryFinishedEventHandler _finished;
        event QueryingEventHandler _querying;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        private ICurrentConfig _config;

        private String _nameOfThua;

        public virtual void onFinished(QueryEventArg ea)
        {
            if (_finished != null)
                _finished(null/*this*/, ea);
        }

        public virtual void onQuerying(QueryEventArg ea)
        {
            if (_querying != null)
                _querying(null/*this*/, ea);
        }

        public QueryThua() : this(null) { }

        public QueryThua(IQueryThuaView view)
        {
            _views = new List<IQueryThuaView>();
            _views.Add(view);
            _sqlTable = SQLTable.CallMe;
            this._bwk = new BackgroundWorker();
            this._bwk.DoWork += new DoWorkEventHandler(_bwk_DoWork);
            this._config = CurrentConfig.CallMe();
        }

        void _bwk_DoWork(object sender, DoWorkEventArgs e)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            //ISqlConnectionInfo sqlConn = (ISqlConnectionInfo)sdeConn;
            ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
            _fcName = new TnFeatureClassName(sdeConn.Workspace);
            _tblName = new TnTableName(sdeConn.Workspace);
            _sqlUser = sdeUser.GetSqlUserInfo();
            
            SqlDataReader reader = null;
            SqlDataAdapter adapter = null;
            DataSet dataSet = new DataSet();
            QueryEventArg qrEvt = new QueryEventArg();

            _nameOfThua = String.Format("{0}_{1}", DataNameTemplate.Thua, _config.NamApDung);
            if (_sqlTable.IsClosed())
            {
                _sqlTable.SetUserInfo(_sqlUser.GetConnectionStringAsArray());
                _sqlTable.OpenConnection();
            }
            int t = 0;
            bool rs = int.TryParse(_type.ToString(), out t);
            if (!rs)
            {
                t = 0;
            }
            IInfoForQuerySql infoSql = (IInfoForQuerySql)_info;
            string selectSql = string.Format("select * from {0} where ",_nameOfThua);
            string whereClause = "";
            List<string> lstSql = new List<string>();
            string maxa = "0";
            int c = 0;
            switch (t)
            {
                //truy van uniq, so to,so thua,dia chi,ten chu
                case 0:
                    #region Tim uniq
                    //kiem tra 1 trong cac gia tri sau
                    //xa,chusohuu,dia chi,soto,sothua
                    //neu ="" thi bo qua, neu ko thi them vao sql and
                    qrEvt.Data = "Đang tìm ...";
                    onQuerying(qrEvt);
                    if (_info.Xa != "")
                    {
                        //tim trong bang xa, lay ma xa theo ten xa

                        #region tim ma xa
                        string sqlxa = "";
                        sqlxa = string.Format("select maxa from {0} where {1}",DataNameTemplate.Ranh_Xa_Poly, infoSql.XaSql);
                        
                        //adapter = new SqlDataAdapter(_sqlTable.GetSqlCommand(sqlxa));
                        //adapter.Fill(dataSet);
                        reader = _sqlTable.GetSqlCommand(sqlxa).ExecuteReader();
                        if (reader != null)
                        {
                            if (reader.HasRows)
                            {
                                //lay 1 ma xa
                                if (reader.Read())
                                {
                                    
                                    maxa = reader.GetValue(0).ToString();
                                    //MessageBox.Show(String.Format("line 119 QueryThua {0}", maxa));
                                }
                            }
                        }
                        else
                        {
                            maxa = "0";
                        }
                        reader.Close();
                        #endregion

                        //tim cac thua

                        lstSql.Add(string.Format("{0}='{1}'", _fcName.FC_THUA.MA_XA, maxa));
                    }
                    if (_info.ChuSoHuu != "")
                    {
                        lstSql.Add(string.Format(infoSql.ChuSoHuuSql));
                    }
                    if (_info.DiaChi != "")
                    {
                        lstSql.Add(string.Format(infoSql.DiaChiSql));
                    }
                    if (_info.SoTo != "")
                    {
                        lstSql.Add(string.Format(infoSql.SoToSql));
                    }
                    if (_info.SoThua != "")
                    {
                        lstSql.Add(string.Format(infoSql.SoThuaSql));
                    }
                    if (_info.MaThua != "")
                    {
                        lstSql.Add(string.Format(infoSql.MaThuaSql));
                    }
                    //ghep cac sql
                    //c = lstSql.Count;
                    //if (c > 0)
                    //{
                    //    whereClause += string.Format("{0}", lstSql[0]);
                    //    for (int i = 1; i < c; i++)
                    //    {
                    //        whereClause += string.Format(" and {0}", lstSql[i]);
                    //    }
                    //    selectSql = selectSql + whereClause;
                    //    adapter = new SqlDataAdapter(_sqlTable.GetSqlCommand(selectSql));
                    //    adapter.Fill(dataSet);
                    //    //MessageBox.Show(selectSql);
                    //    //reader = _sqlTable.GetSqlCommand(whereClause).ExecuteReader();
                    //    //if (reader.HasRows)
                    //    //{
                    //    foreach (IQueryThuaView v in _views)
                    //    {
                    //        v.GetResult(dataSet);
                    //    }
                    //    //}
                    //    //reader.Close();
                    //}
                    //qrEvt.Data = "Đã tìm xong";
                    //onFinished(qrEvt);
                    break;
                    #endregion

                //tim theo loai dat,so mat tien,..
                case 1:
                    #region tim theo loai dat,...
                    //xet loai dat de biet xet trong bang gia dat nao
                    if (_info.LoaiDat != "")
                    {
                        lstSql.Add(string.Format(infoSql.LoaiDatSql));
                    }
                    if (_info.SoMatTien != "")
                    {
                        lstSql.Add(string.Format(infoSql.SoMatTienSql));
                    }
                    if (_info.SoTo != "")
                    {
                        lstSql.Add(string.Format(infoSql.SoToSql));
                    }
                    if (_info.SoThua != "")
                    {
                        lstSql.Add(string.Format(infoSql.SoThuaSql));
                    }
                    #endregion
                    break;
                case 2:
                    //tim theo vi tri
                    #region tim theo vi tri

                    #endregion
                    break;
                case 3:
                    //tim theo dien tich
                    #region tim theo dien tich
                    if (_info.DienTich != "")
                    {
                        lstSql.Add(string.Format(infoSql.DienTichSql));
                    }
                    #endregion
                    break;
                default:
                    break;
            }
            c = lstSql.Count;
            if (c > 0)
            {
                whereClause += string.Format("{0}", lstSql[0]);
                for (int i = 1; i < c; i++)
                {
                    whereClause += string.Format(" and {0}", lstSql[i]);
                }
                selectSql = selectSql + whereClause;
                adapter = new SqlDataAdapter(_sqlTable.GetSqlCommand(selectSql));
                adapter.Fill(dataSet);
                //MessageBox.Show(selectSql);
                //reader = _sqlTable.GetSqlCommand(whereClause).ExecuteReader();
                //if (reader.HasRows)
                //{
                foreach (IQueryThuaView v in _views)
                {
                    v.GetResult(dataSet);
                }
                //}
                //reader.Close();
            }
            qrEvt.Data = "Đã tìm xong";
            onFinished(qrEvt);

            _sqlTable.CloseConnection();
        }

        #region IQueryThua Members

        object IQueryThua.TypeOfQuery
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type=value;
            }
        }

        void IQueryThua.Query()
        {
            if (!_bwk.IsBusy)
            {
                _bwk.RunWorkerAsync();
            }
            
        }

        IInfoForQuery IQueryThua.Info
        {
            get
            {
                return this._info;
            }
            set
            {
                this._info=value;
            }
        }

        event QueryFinishedEventHandler IQueryThua.Finished
        {
            add { this._finished+=value; }
            remove { this._finished-=value; }
        }

        event QueryingEventHandler IQueryThua.Querying
        {
            add { this._querying+=value; }
            remove { this._querying-=value; }
        }

        #endregion
    }
}
