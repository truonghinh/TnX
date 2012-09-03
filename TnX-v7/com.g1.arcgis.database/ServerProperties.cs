using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace com.g1.arcgis.database
{
    public class ServerProperties
    {
        private static string serverName = String.Empty;
        private static string machineName = String.Empty;
        private static string sqlEdition = String.Empty;
        private static string sqlVersion = String.Empty;
        private static string serverNameSql = "select SERVERPROPERTY('servername')";
        private static string machineNameSql = "select SERVERPROPERTY('machinename')";
        private static string sqlEditionSql = "select SERVERPROPERTY('edition')";
        private static string sqlVersionSql = "select SERVERPROPERTY('productversion')";
        private static DataSet ds = new DataSet();

        private static IDataManager dataManager = new DataManager();

        public static string SERVER_NAME
        {
            get 
            {
                string sql = serverNameSql;
                try
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.IS_EXPRESS, null, sql);
                }
                catch
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.NON_EXPRESS, null, sql);
                }
                finally
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        serverName = row[0].ToString();
                    }
                }
                return serverName; 
            }
            //set { serverName = value; }
        }
        public static string SERVER_NAME_SQL
        {

            get {return serverNameSql; }
        }

        public static string MACHINE_NAME
        {
            get 
            {
                string sql = machineNameSql;
                try
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.NON_EXPRESS, null, sql);
                }
                catch
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.IS_EXPRESS, null, sql);
                }
                finally
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        machineName = row[0].ToString();
                    }
                }
                return machineName; 
            }
            //set { machineName = value; }
        }

        public static string MACHINE_NAME_SQL
        {
            get { return machineNameSql; }
        }

        public static string SQL_EDITION
        {
            get 
            {
                string sql = sqlEditionSql;
                try
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.IS_EXPRESS, null, sql);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.NON_EXPRESS, null, sql);
                }
                //finally
                //{
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    sqlEdition = row[0].ToString();
                    //}
                }
                return sqlEdition; 
            }
            //set { sqlEdition = value; }
        }

        public static string GetSQLEdition(int isExpress)
        {
            string sql = sqlEditionSql;
            try
            {
                ds = dataManager.TnQueryBySQL(isExpress, null, sql);
            }
            catch 
            {
                return null;
                //MessageBox.Show(e.ToString());
                //ds = dataManager.TnQueryBySQL(TnSQLServerVersion.NON_EXPRESS, null, sql);
            }
            //finally
            //{
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sqlEdition = row[0].ToString();
                //}
            }
            return sqlEdition;
        }

        public static string SQL_EDITION_SQL
        {
            get { return sqlEditionSql; }
        }


        public static string SQL_VERSION
        {
            get 
            {
                string sql = sqlVersionSql;
                try
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.IS_EXPRESS, null, sql);
                }
                catch
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.NON_EXPRESS, null, sql);
                }
                finally
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sqlVersion = row[0].ToString();
                    }
                }
                return sqlVersion; 
            }
            //set { sqlVersion = value; }
        }

        public static string SQL_VERSION_SQL
        {
            get { return sqlVersionSql; }
        }
    }
}
