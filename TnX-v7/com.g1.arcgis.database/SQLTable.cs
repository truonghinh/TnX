using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using com.g1.arcgis.connection;

namespace com.g1.arcgis.database
{
    public sealed class SQLTable:ISQLTable
    {
        private static string[,] _arrUserInfo = null;
        private static string connectionString = null;
        private static SqlConnection connection;
        private SqlCommand command;
        private static bool _connectionStatus = false;
        private static bool _isOpening = false;
        private static bool _isClose = true;
        private static SQLTable meClass=new SQLTable();
        private string sql = String.Empty;
        private DataTable t = new DataTable();

        private SQLTable()
        {
            _arrUserInfo = null;
        }
        public static SQLTable CallMe
        {
            get { return meClass; }
        }

        //public TnSQLTable(string[,] userInfo)
        //{
        //    _arrUserInfo = userInfo;
        //}

        #region ITnSQLTable Members

        bool ISQLTable.UpdateData(string table,string column, object id, object value)
        {
            if (_arrUserInfo == null || _connectionStatus==false) 
                return false;
            
            sql = "update " + table + " set ";
            sql += column + " = " + "N'" + value + "'";
            sql += " where objectid = " + "N'" + id + "'";
            int i = 0;

            string sqlCmd = null;
            sqlCmd = sql;

            try
            {
                
                command = new SqlCommand(sqlCmd, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                

                //this.dgvTable.DataSource = ds.Tables[0];


                //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //{
                //    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);

                //}
            }
            catch
            {
                return false;
            }
            return true;
        }

        bool ISQLTable.OpenConnection()
        {
            try
            {
                connection.Open();
                _connectionStatus = true;
                return true;
            }
            catch { return false; }
        }

        bool ISQLTable.CloseConnection()
        {
            try
            {
                connection.Close();
                _connectionStatus = false;
                return true;
            }
            catch { return false; }
        }

        bool ISQLTable.IsOpenning()
        {
            return _connectionStatus;
        }

        bool ISQLTable.IsClosed()
        {
            return !_connectionStatus;
        }

        void ISQLTable.SetUserInfo(string[,] userInfo)
        {
            //if (userInfo != null)
            //{
            //    _arrUserInfo = userInfo;
            //    int l = _arrUserInfo.Length / 2;
            //    for (int j = 0; j < l; j++)
            //    {
            //        if (j == 4)
            //            break;
            //        connetionString += _arrUserInfo[j, 0] + "=" + _arrUserInfo[j, 1];
            //        if (j < l - 1)
            //        {
            //            connetionString += ";";
            //        }
            //    }
            //}
            //else
            //{
            //    connetionString = GConnectionString.TRUSTED_CONNECT_NON_EXPRESS;
            //}
            //connetionString = "Server=ht-laptop;Database=sde,Uid=sde,Pwd=sde";//"Data Source=ht-laptop;Initial Catalog=sde;User ID=sde;Password=sde";
            //sql = "select * from tn_thua";
            //MessageBox.Show(connetionString);
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
            ISqlUserInfo sqlUser = sdeUser.GetSqlUserInfo();
            //IUserInfo userInfo = (IUserInfo)sqlUser;
            connectionString = sqlUser.GetConnectionString();
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception e)
            { MessageBox.Show("line 131 - TnSQLTable"+e.InnerException.ToString()); }
        }

        string ISQLTable.ConnectionStringPreview()
        {
            return connectionString;
        }

        string ISQLTable.SqlPreview()
        {
            return sql;
        }

        DataTable ISQLTable.GetDataTable(ref SqlDataAdapter adapter)
        {
            adapter.Fill(t);
            return t;
        }

        bool ISQLTable.UpdateDataUseAdapter()
        {
            //try
            //{
            //    adapter.Update(t);
            //    return true;
            //}
            //catch { return false; }
            return false;
        }


        void ISQLTable.BuildAdapter(out SqlDataAdapter adapter, string sql)
        {
            this.sql = sql;
            adapter = new SqlDataAdapter(sql, connection);
        }

        DataTable ISQLTable.GetDataTable(string sqlCommand)
        {
            if (_arrUserInfo == null || _connectionStatus == false)
                return null;

            sql = sqlCommand;

            try
            {

                command = new SqlCommand(sql, connection);
                //command.;
                command.Dispose();


                //this.dgvTable.DataSource = ds.Tables[0];


                //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //{
                //    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);

                //}
            }
            catch
            {
                return null;
            }
            return null;
        }

        SqlConnection ISQLTable.GetConnection
        {
            get { return connection; }
        }


        void ISQLTable.OpenTrustConnection(int isExpress)
        {
            connectionString = GConnectionString.TRUSTED_CONNECT_EXPRESS;
            connection = new SqlConnection(connectionString);
        }

        SqlCommand ISQLTable.GetSqlCommand(string sql)
        {
            command = new SqlCommand(sql, connection);
            return command;
        }

        #endregion
    }
}
