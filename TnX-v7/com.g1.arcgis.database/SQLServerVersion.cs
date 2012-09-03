using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.database
{
    public class SQLServerVersion
    {
        private static int _isExpress = 0;
        private static int _nonExpress = 1;
        private static int _currentVersion = 1;
        private static SQLServerVersion meClass = new SQLServerVersion();

        private SQLServerVersion()
        {

        }

        public static SQLServerVersion CallMe
        {
            get { return meClass; }
        }

        public static int IS_EXPRESS
        {
            get
            {
                return _isExpress;
            }
        }
        public static int NON_EXPRESS
        {
            get { return _nonExpress; }
        }

        public void SetCurrentVersion(int version)
        {
            if(version != 0 && version!=1)
                return;
            if (version == _currentVersion)
                return;
            _currentVersion = version;
        }
        public int GetCurrentVersion()
        {
            return _currentVersion;
        }
    }
}
