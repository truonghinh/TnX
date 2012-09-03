using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.system
{
    public class TnSystemFileName
    {
        private static string _userInfoFile = "userInfo.tnx";
        private static string _layers4Calc = "layersForCalc.tnx";
        private static string _sqlserverInfo = "sqlInfo.tnx";
        private static string _connectToSde = "sdeConnection.tnx";
        private static string _sdeService = "sdeServiceName.tnx";
        private static readonly string _params = "TnXParams.tnx";
        private static readonly string _config = "TnXConfig.tnx";

        public static string PARAMS
        {
            get { return _params; }
        }

        public static string UserInfoFile
        {
            get { return _userInfoFile; }
            set { if (_userInfoFile == value) return; _userInfoFile = value; }
        }

        public static string Layers4Calc
        {
            get { return _layers4Calc; }
            set { if (_layers4Calc == value) return; _layers4Calc = value; }
        }

        public static string SqlInfoFile
        {
            get { return _sqlserverInfo; }
            set { if (_sqlserverInfo == value) return; _sqlserverInfo = value; }
        }

        public static string ConnectToSde
        {
            get { return _connectToSde; }
            set { if (_connectToSde == value) return; _connectToSde = value; }
        }

        public static string SdeService
        {
            get { return _sdeService; }
            set { if (_sdeService == value) return; _sdeService = value; }
        }

        public static string Config
        {
            get { return _config; }
        }
        public static string UserInfo { get { return "userinfo.tnx"; } }
    }
}
