using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.database;


namespace TNPro.Check
{
    public class TnRoles
    {
        private static TnRoles meClass = null;
        private static int curRole = 0;
        private static readonly int adminRole = 1;
        private static readonly int userRole = 0;
        private static List<string> _lstCurUsers;

        public static int AdminRole { get { return adminRole; } }
        public static int UserRole { get { return userRole; } }
        

        private DataSet users;
        private ISQLTable sqlTable;
        public int CurRole
        {
            get { return curRole; }
            set { curRole = value; }
        }

        public static TnRoles CallMe()
        {
            if (meClass == null)
            {
                meClass = new TnRoles();
            }
            return meClass;
        }

        private TnRoles()
        {
            users = new DataSet();
            sqlTable=SQLTable.CallMe;
            _lstCurUsers = new List<string>();
        }

        public List<string> ListUsers { get { return _lstCurUsers; } }

        public void LoadUsers(int isExpress)
        {
            
            try
            {
                if (sqlTable.IsClosed())
                {
                    sqlTable.SetUserInfo(null);
                    sqlTable.OpenConnection();
                }
                string q = "select username from sde.sde.USERS";
                SqlDataReader reader = sqlTable.GetSqlCommand(q).ExecuteReader();
                //MessageBox.Show(reader.HasRows.ToString());
                while (reader.Read())
                {
                    
                    if (reader.HasRows)
                    {
                        _lstCurUsers.Add(reader.GetValue(0).ToString());
                    }
                }


            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
    }
}
