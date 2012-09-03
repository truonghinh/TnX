using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.connection
{
    public interface ISdeConnectionInfo:ISqlConnectionInfo
    {
        IWorkspace Workspace { get; set; }
        string Environment { get; set; }
        IWorkspace CreateSdeWorkspace(ISdeUserInfo sdeUserInfo);
        IWorkspace CreateSdeWorkspace();
        bool IsConnecting { get; }
        ISdeUserInfo GetSdeUserInfo();
        IWorkspaceName WorkspaceName { get; set; }
    }
}
