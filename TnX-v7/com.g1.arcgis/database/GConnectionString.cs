using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.database
{
    public class GConnectionString
    {
        private static GConnectionString meClass=null;
        private static string _serverName = "";
        private static string _TrustedConnectNonExpress = "server=truonghinh\\sqlserver;Trusted_Connection=yes;";
        private static string[,] _TrustedConnectNonExpressArray;
        private static string _TrustedConnectExpress="";
        private static string[,] _TrustedConnectExpressArray;

        public static string TRUSTED_CONNECT_NON_EXPRESS
        {
            get { return _TrustedConnectNonExpress; }
        }
        public static string TRUSTED_CONNECT_EXPRESS
        {
            get { return _TrustedConnectExpress; }
        }

        private GConnectionString()
        {
            _TrustedConnectExpress = @"Data Source=" + _serverName + ";Integrated Security=True;User Instance=True";
            _TrustedConnectNonExpressArray = new string[,] { { "server", "localhost" }, { "Trusted_Connection", "yes" } };
            _TrustedConnectExpressArray = new string[,] { { "Data Source", _serverName }, { "Integrated Security", "True" }, { "User Instance", "True" } };
        }

        public static GConnectionString CallMe(string server_name)
        {
            _serverName=server_name;
            if(meClass==null)
            {
                meClass=new GConnectionString();
            }
            return meClass;
        }

        public static void SetServerName(string server_name)
        {
            _serverName = server_name;
            _TrustedConnectExpress = @"Data Source=" + _serverName + ";Integrated Security=True;User Instance=True";
            _TrustedConnectExpressArray = new string[,] { { "Data Source", _serverName }, { "Integrated Security", "True" }, { "User Instance", "True" } };
        }

        public static string[,] TRUSTED_CONNECT_NON_EXPRESS_ARRAY
        {
            get { return _TrustedConnectNonExpressArray; }
        }

        public static string[,] TRUSTED_CONNECT_EXPRESS_ARRAY
        {
            get { return _TrustedConnectExpressArray; }
        }
    }
}
