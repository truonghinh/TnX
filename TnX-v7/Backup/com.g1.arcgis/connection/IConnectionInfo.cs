using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Data.OleDb;

namespace com.g1.arcgis.connection
{
    public interface IConnectionInfo
    {
        IUserInfo GetUserInfo();
        OleDbConnection GetOleDbConnection();
    }
}
