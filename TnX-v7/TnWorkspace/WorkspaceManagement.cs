using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Data.SqlClient;

namespace TnWorkspace
{
    public class WorkspaceManagement
    {
        public IWorkspace CreateWorkspaceGdbFile(string path, string name, string type)
        {
            try
            {
                IWorkspace wp;
                IWorkspaceName wpn;
                IName nwp;
                IWorkspaceFactory2 wspf;
                Directory.CreateDirectory(path);
                path = path + "\\";
                switch (type)
                {
                    case "mdb":
                        wspf = new AccessWorkspaceFactoryClass();
                        name = name + ".mdb";
                        break;
                    case "shp":
                        wspf = new ShapefileWorkspaceFactoryClass();
                        break;
                    default:
                        wspf = new ShapefileWorkspaceFactoryClass();
                        break;
                }
                wpn = wspf.Create(path, name, null, 0);
                nwp = (IName)wpn;
                wp = (IWorkspace)nwp.Open();
                return wp;
            }
            catch { return null; }
        }
        public IWorkspace CreateWorkspaceSDE(string server, string instance, string database, string version, string user, string password)
        {
            IWorkspaceFactory workspaceFactory = new SdeWorkspaceFactoryClass();
            IPropertySet propertySet = new PropertySetClass();
            //create version for editting
            //TnUtilities utilities = new TnUtilities();
            IWorkspace workspace = null;
            //utilities.StartService("esri_sde", 2000);

            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);

            propertySet.SetProperty("VERSION", version);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            //if (authentication_mode != "OSA" && authentication_mode != "osa")
            //{
            //    propertySet.SetProperty("USER", user);
            //    propertySet.SetProperty("PASSWORD", password);
            //}
            //else if (authentication_mode == "OSA" || authentication_mode == "osa")
            //{
            //    propertySet.SetProperty("AUTHENTICATION_MODE", authentication_mode);
            //}
            //else
            //{
            //    MessageBox.Show("Chua xac dinh duoc Authentication_mode");
            //}
            //if (version == "sde.DEFAULT")
            //{
            //    Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.SdeWorkspaceFactory");
            //    workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
            //}
            //if (version == "dbo.DEFAULT")
            //{
            //    propertySet.SetProperty("VERSION", version);
            //}
            //else
            //{
            Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.SdeWorkspaceFactory");
            workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
            //}
            try
            {
                workspace = workspaceFactory.Open(propertySet, 0);
            }
            catch (Exception ex){MessageBox.Show(string.Format("line 94 WorkspaceManagement:\n {0}",ex)); }
            //if (workspace.IsBeingEdited() != true)
            //{
            //    workspaceEdit.StartEditing(true);
            //    workspaceEdit.StartEditOperation();
            //}
            return workspace;
        }

        // dataServerName parameter should be in "<machine_name>\\<sql_instance>" format
        public IWorkspace CreatePersonalOrWorkgroupArcSdeWorkspace(String dataServerName,string dbName, string version)
        {
            // Create a data server manager object.
            IDataServerManager dataServerManager = new DataServerManagerClass();
            IWorkspace workspace=null;
            // Set the server name and connect to the server.
            dataServerManager.ServerName = dataServerName;
            dataServerManager.Connect();

            // Cast to the admin interface, check permissions, and create the geodatabase.
            IDataServerManagerAdmin dataServerManagerAdmin = (IDataServerManagerAdmin)dataServerManager;
            if (dataServerManagerAdmin.IsConnectedUserAdministrator)
            {
                // Create a Name object to open the workspace.
                IWorkspaceName workspaceName = dataServerManagerAdmin.CreateWorkspaceName(
                    dbName, "VERSION", version);
                IName name = (IName)workspaceName;
                workspace = (IWorkspace)name.Open();
            }
            return workspace;
        }

        public IFeatureClass OpenFeatureClassFromFileMdb(string path, string name)
        {
            IWorkspaceFactory2 mdbWspf = new AccessWorkspaceFactoryClass();
            IWorkspace wsp;
            IFeatureWorkspace fwsp;

            wsp = mdbWspf.OpenFromFile(path, 0);
            fwsp = (IFeatureWorkspace)wsp;
            return fwsp.OpenFeatureClass(name);
        }
        public IFeatureClass OpenFeatureClassFromSDE(IWorkspace workspace, string featureClass)
        {
            IFeatureWorkspace fwsp = (IFeatureWorkspace)workspace;
            return fwsp.OpenFeatureClass(featureClass);
        }
        /// <summary>
        /// kiem tra layer co ton tai ko, ko ho tro table
        /// .Dang bi loi
        /// </summary>
        /// <param name="user_info"></param>
        /// <param name="layer_name"></param>
        /// <returns></returns>
        public bool CheckLayerExist(string[,] user_info, string layer_name)
        {
            string strConnection = "";
            string sql = "SELECT * FROM sde.sde.SDE_table_registry WHERE table_name='" + layer_name + "'";

            for (int i = 0; i < user_info.Length /2; i++)
            {
                strConnection += user_info[i, 0] + "=" + user_info[i, 1];
                strConnection += ";";
            }
            SqlConnection conn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int a = 0;
            bool result = false;
            do
            {
                if (reader.HasRows)
                {
                    result = true;
                    break;
                    //while (reader.Read())
                    //{
                    //MessageBox.Show(sql);
                    //MessageBox.Show(result.ToString());
                    //}
                }
            } while (reader.NextResult());
            //MessageBox.Show(result.ToString());
            
            return result;
            
        }
        /// <summary>
        /// tạo file connection *.sde
        /// </summary>
        /// <param name="server"></param>
        /// <param name="instance"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <param name="version"></param>
        /// <param name="sdePathWithSlash">c:\\temp\\</param>
        /// <param name="sdeFileName">Sample.sde</param>
        /// <returns></returns>
        public IWorkspaceName CreateConnectionFile(string server, string instance, string
    user, string password, string database, string version,string sdePathWithSlash,string sdeFileName)
        {
            IPropertySet propertySet = new PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            propertySet.SetProperty("VERSION", version);
            IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new
                SdeWorkspaceFactoryClass();
            return workspaceFactory.Create(sdePathWithSlash, sdeFileName, propertySet, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="instance"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="database"></param>
        /// <param name="version"></param>
        /// <param name="sdeFullPath">c:\\temp\\Sample.sde</param>
        /// <returns></returns>
        public IWorkspaceName CreateConnectionFile(string server, string instance, string
    user, string password, string database, string version, string sdeFullPath)
        {
            if (sdeFullPath == null)
            {

            }
            string sdePathWithSlash = "";
            string sdeFileName = "";
            string[] pathSplit = sdeFullPath.Split('\\');
            sdePathWithSlash = pathSplit[0] + "\\\\" + pathSplit[1] + "\\\\";
            sdeFileName = pathSplit[2];
            MessageBox.Show("line 231 WspM "+sdePathWithSlash + "--" + sdeFileName);
            IPropertySet propertySet = new PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            propertySet.SetProperty("VERSION", version);
            IWorkspaceFactory2 workspaceFactory = (IWorkspaceFactory2)new
                SdeWorkspaceFactoryClass();
            return workspaceFactory.Create(sdePathWithSlash, sdeFileName, propertySet, 0);
        }

        /// <summary>
        /// Kết nối với server bằng file *.sde
        /// </summary>
        /// <param name="connectionFile">C:\\myData\\Sample.sde</param>
        /// <returns></returns>
        public IWorkspace ArcSdeWorkspaceFromFile(String connectionFile)
        {
            IWorkspaceFactory workspaceFactory = new SdeWorkspaceFactoryClass();
            return workspaceFactory.OpenFromFile(connectionFile, 0);
        }



    }
}
