using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace com.g1.arcgis.database
{
    public interface ISQLTable
    {
        void SetUserInfo(string[,] userInfo);
        bool UpdateData(string table,string column, object id, object value);
        bool UpdateDataUseAdapter();
        bool OpenConnection();
        bool CloseConnection();
        bool IsOpenning();
        bool IsClosed();
        string ConnectionStringPreview();
        string SqlPreview();
        DataTable GetDataTable(ref SqlDataAdapter adapter);
        DataTable GetDataTable(string sqlCommand);
        void BuildAdapter(out SqlDataAdapter adapter,string sql);
        SqlConnection GetConnection{get;}
        void OpenTrustConnection(int isExpress);
        SqlCommand GetSqlCommand(string sql);

    }
}
