using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.database.versioning
{
    public interface ISdeVersionInfo
    {
        string GetVersionName();
        string GetSdeDefaultVersionName();
        string GetDboDefaultVersionName();
        List<string> GetAllVersions();
        DataSet GetAllVersionsAsDataset(out List<string> versions, int is_express);
        bool WorkspaceIsLocked(IWorkspace wsp);
        void RegisterDataset(IDataset dataset, bool compressDefault);
        void RegisterDataset(IDataset dataset);
        void RegisterDataset(IDataset dataset, bool compressDefault,bool moveToBase);
    }
}
