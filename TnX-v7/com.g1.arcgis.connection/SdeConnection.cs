using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnUtilities;
using ESRI.ArcGIS.Geodatabase;
using TnWorkspace;
using System.Windows.Forms;
using System.Data.OleDb;
using gov.tn.system;
using ESRI.ArcGIS.esriSystem;

namespace com.g1.arcgis.connection
{
    public class SdeConnection:ISdeConnectionInfo
    {
        

        private static IWorkspace _workspace;
        private static string _environment;
        private static ISdeUserInfo _sdeUser;
        private static ISqlUserInfo _sqlUser;
        private static IWorkspaceName _workspaceName;

        public SdeConnection() { }
        public SdeConnection(ISdeUserInfo sdeUser)
        {
            //_workspace = null;
            _sdeUser = sdeUser;
            _sqlUser = sdeUser.GetSqlUserInfo();
        }

        #region IConnectionInfo Members

        IWorkspace ISdeConnectionInfo.CreateSdeWorkspace(ISdeUserInfo sdeUserInfo)
        {
            
            try
            {
                UtilitiesBox.StartService(sdeUserInfo.Sde_service, 3000);
                //UtilitiesBox.StartService("MSSQLSERVER", 3000);
                WorkspaceManagement wspm = new WorkspaceManagement();
                _workspace = wspm.CreateWorkspaceSDE(sdeUserInfo.ServerSde, sdeUserInfo.Instance, sdeUserInfo.Db, sdeUserInfo.Version, sdeUserInfo.UserName, sdeUserInfo.Pass);
                _environment = String.Format("Database Connections/Connection to {0}.sde", sdeUserInfo.ServerSde);
                _workspaceName = wspm.CreateConnectionFile(sdeUserInfo.Server, sdeUserInfo.Instance, sdeUserInfo.UserName, sdeUserInfo.Pass, sdeUserInfo.Db, sdeUserInfo.Version,TnSystemTempPath.ConnectionFileFullPath);
                //MessageBox.Show("line 44 SdeConnection, path=" + _workspaceName.PathName);
                return _workspace;
                //IWorkspace wsp = wspm.CreateWorkspaceSDE("froxtal-pc", "5152", "sde", "sde.DEFAULT", "sde", "arcsde");
                //if (wsp != null)
                //{
                //    TnConnectionInfo.CallMe.SetSDEWorkspace(wsp);
                //    _connectionOk = true;
                //}
                //else
                //{
                //    _connectionOk = false;
                //}


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString());}

            return _workspace;
        }

        IWorkspace ISdeConnectionInfo.Workspace
        {
            get
            {
                return _workspace;
            }
            set
            {
                _workspace = value;
            }
        }

        bool ISdeConnectionInfo.IsConnecting
        {
            get
            {
                if (_workspace != null)
                {
                    return true;
                }
                else return false;
            }
        }

        IWorkspace ISdeConnectionInfo.CreateSdeWorkspace()
        {
            if (_sdeUser != null)
            {
                try
                {
                    //MessageBox.Show(string.Format("line 90 SdeConnection:sde service:{0}", _sdeUser.Sde_service));
                    UtilitiesBox.StartService(_sdeUser.Sde_service, 5000);
                    //UtilitiesBox.StartService("MSSQLSERVER", 3000);
                    WorkspaceManagement wspm = new WorkspaceManagement();
                    //_workspace = wspm.CreateWorkspaceSDE(_sdeUser.ServerSde, _sdeUser.Instance, _sdeUser.Db, _sdeUser.Version, _sdeUser.UserName, _sdeUser.Pass);
                    //_environment = String.Format("Database Connections/Connection to {0}.sde", _sdeUser.ServerSde);
                    string path=TnSystemTempPath.ConnectionFilePath;
                    try
                    {
                        if (System.IO.File.Exists("c:/tn/temp/tn.sde"))
                        {
                            System.IO.File.Delete("c:/tn/temp/tn.sde");
                        }
                    }
                    catch { }

                    _workspaceName = wspm.CreateConnectionFile(_sdeUser.Server, _sdeUser.Instance, _sdeUser.UserName, _sdeUser.Pass, _sdeUser.Db, _sdeUser.Version, "c:/tn/temp/","tn.sde");
                    _environment = "c:/tn/temp/tn.sde";
                    _workspace = (IWorkspace)((IName)_workspaceName).Open();
                    
                    //MessageBox.Show("line 100 SdeConnection, path=" + _workspaceName.PathName);
                    return _workspace;

                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                return _workspace;
            }
            return null;
        }
        #endregion


        #region ISdeConnectionInfo Members


        ISdeUserInfo ISdeConnectionInfo.GetSdeUserInfo()
        {
            return _sdeUser;
        }

        #endregion

        #region ISqlConnectionInfo Members

        ISqlUserInfo ISqlConnectionInfo.GetSqlUserInfo()
        {
            return _sqlUser;
        }

        #endregion

        #region IConnectionInfo Members

        IUserInfo IConnectionInfo.GetUserInfo()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IConnectionInfo Members

        System.Data.OleDb.OleDbConnection IConnectionInfo.GetOleDbConnection()
        {
            string c = "Provider=ESRI.GeoDB.OleDB.1;Location={0};Data Source={1};User Id={2};Password={3};" + "Extended Properties=workspacetype=esriDataSourcesGDB.SdeWorkspaceFactory.1;Geometry={4};Instance={5};Version={6}";
            string con = String.Format(c, _sdeUser.ServerSde, _sdeUser.Db, _sdeUser.UserName, _sdeUser.Pass, "WKB", _sdeUser.Instance, _sdeUser.Version);
            OleDbConnection sdeCon = new OleDbConnection();
            sdeCon.ConnectionString = con;
            return sdeCon;
        }

        string ISdeConnectionInfo.Environment
        {
            get
            {
                return _environment;
            }
            set
            {
                _environment = value ;
            }
        }

        #endregion

        #region ISdeConnectionInfo Members


        IWorkspaceName ISdeConnectionInfo.WorkspaceName
        {
            get
            {
                return _workspaceName;
            }
            set
            {
                _workspaceName = value;
            }
        }

        #endregion
    }
}
