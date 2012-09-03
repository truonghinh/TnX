using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using System.Data;
using com.g1.arcgis.database;


namespace com.g1.arcgis.database.versioning
{
    public class SdeVersionsTool : ISdeVersionInfo
    { 
        private static SdeVersionsTool meClass = null;
        private static string _sdeDefault = "sde.DEFAULT";
        private static string _dboDefault = "dbo.DEFAULT";
        private static string _sdeTN = "sde.TN";
        private static List<string> _listAllVersion = new List<string>();
        private static List<string> _listCurrentVersion = new List<string>();

        private SdeVersionsTool() { }

        public static SdeVersionsTool CallMe()
        {
            if (meClass == null)
            {
                meClass = new SdeVersionsTool();
            }
            return meClass;
        }

        public void ReconcileandPost(IVersion editVersion, IVersion targetVersion)
        {
            IMultiuserWorkspaceEdit muWorkspaceEdit = (IMultiuserWorkspaceEdit)editVersion;
            IWorkspaceEdit workspaceEdit = (IWorkspaceEdit2)editVersion;
            IVersionEdit4 versionEdit = (IVersionEdit4)workspaceEdit;

            if (muWorkspaceEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
            {
                muWorkspaceEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                //Reconcile with the target version.
                bool conflicts = versionEdit.Reconcile4(targetVersion.VersionName, true, false, false, false);
                if (conflicts) MessageBox.Show(" Conflicts Detected ");
                else MessageBox.Show(" No Conflicts Detected ");
                workspaceEdit.StartEditOperation();
                //Post to the target version.
                if (versionEdit.CanPost()) versionEdit.Post(targetVersion.VersionName);
                workspaceEdit.StopEditOperation();
                workspaceEdit.StopEditing(true);
            }
        }

        public void RegisterDataset(IDataset dataset)
        {
            IVersionedObject3 versionedObject = (IVersionedObject3)dataset;

            bool IsRegistered;
            bool IsMovingEditsToBase;
            
            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);
            try
            {
                if (IsRegistered)
                {
                    if (IsMovingEditsToBase)
                    {
                        //first unregister without compressing edits
                        versionedObject.UnRegisterAsVersioned3(false);

                        //then register as fully versioned
                        versionedObject.RegisterAsVersioned3(false);
                    }
                }
                else
                {
                    //registering as fully versioned
                    versionedObject.RegisterAsVersioned3(false);
                }
            }
            catch (Exception e) 
            { 
                //MessageBox.Show(string.Format("không thể đăng ký versioned cho {0} \n\n Có thể do lớp dữ liệu đã được đăng ký rồi, dùng Arccatalog để kiểm tra lại" + dataset.Name)); 
            }
        }

        

        public void RegisterDataset(IDataset dataset,bool compressDefault)
        {
            IVersionedObject3 versionedObject = (IVersionedObject3)dataset;

            bool IsRegistered;
            bool IsMovingEditsToBase;

            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);

            if (IsRegistered)
            {
                if (IsMovingEditsToBase)
                {
                    //first unregister without compressing edits
                    versionedObject.UnRegisterAsVersioned3(compressDefault);

                    //then register as fully versioned
                    versionedObject.RegisterAsVersioned3(false);
                }
            }
            else
            {
                //registering as fully versioned
                versionedObject.RegisterAsVersioned3(false);
            }
        }

        public IVersion CreateNewVersion(IVersionedWorkspace versionedWorkspace, string versionName, string parentVersionName)
        {
            IVersion newVersion = null;
            IVersion parentVersion = null;
            try
            {
                if (parentVersionName == "")
                {
                    parentVersion = versionedWorkspace.DefaultVersion;
                }
                else
                {
                    parentVersion = versionedWorkspace.FindVersion(parentVersionName);
                }
            }
            catch
            {
                MessageBox.Show("không tìm thấy version :" + parentVersionName);
            }

            try
            {
                /*
                *   Delete the version if it exists.
                */

                newVersion = versionedWorkspace.FindVersion(versionName);
                newVersion.Delete();
                newVersion = parentVersion.CreateVersion(versionName);
                //newVersion = new SeVersion(conn);
            }
            catch (Exception e)
            {
                //if( e.get.getSdeError() == IError.SE_VERSION_NOEXIST )
                try
                {
                    newVersion = parentVersion.CreateVersion(versionName);
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.ToString());
                }
            }
            newVersion.Access = esriVersionAccess.esriVersionAccessPublic;
            return newVersion;
        }

        public IVersion CreateNewVersion(IVersionedWorkspace versionedWorkspace, string versionName, string parentVersionName,esriVersionAccess access)
        {
            IVersion newVersion = null;
            IVersion parentVersion = null;
            try
            {
                if (parentVersionName == "")
                {
                    parentVersion = versionedWorkspace.DefaultVersion;
                }
                else
                {
                    parentVersion = versionedWorkspace.FindVersion(parentVersionName);
                }
            }
            catch
            {
                MessageBox.Show("không tìm thấy version :" + parentVersionName);
            }

            try
            {
                /*
                *   Delete the version if it exists.
                */

                newVersion = versionedWorkspace.FindVersion(versionName);
                newVersion.Delete();
                newVersion = parentVersion.CreateVersion(versionName);
                //newVersion = new SeVersion(conn);
            }
            catch (Exception e)
            {
                //if( e.get.getSdeError() == IError.SE_VERSION_NOEXIST )
                try
                {
                    newVersion = parentVersion.CreateVersion(versionName);
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.ToString());
                }
            }
            newVersion.Access=access;
            return newVersion;
        }

        public IVersion CreateNewVersion(IVersionedWorkspace versionedWorkspace, string versionName)
        {
            IVersion newVersion = null;
            IVersion parentVersion = null;
            try
            {
                /*
                *   Delete the version if it exists.
                */
                parentVersion = versionedWorkspace.DefaultVersion;
                newVersion = versionedWorkspace.FindVersion(versionName);
                newVersion.Delete();
                newVersion = parentVersion.CreateVersion(versionName);
                //newVersion = new SeVersion(conn);
            }
            catch (Exception e)
            {
                //if( e.get.getSdeError() == IError.SE_VERSION_NOEXIST )
                try
                {
                    newVersion = parentVersion.CreateVersion(versionName);
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.ToString());
                }
            }
            newVersion.Access = esriVersionAccess.esriVersionAccessPublic;
            return newVersion;
        }
        public IVersion CreateNewVersion(IVersionedWorkspace versionedWorkspace, string versionName,esriVersionAccess access)
        {
            IVersion newVersion = null;
            IVersion parentVersion = null;
            try
            {
                /*
                *   Delete the version if it exists.
                */
                parentVersion = versionedWorkspace.DefaultVersion;
                newVersion = versionedWorkspace.FindVersion(versionName);
                newVersion.Delete();
                newVersion = parentVersion.CreateVersion(versionName);
                //newVersion = new SeVersion(conn);
            }
            catch (Exception e)
            {
                //if( e.get.getSdeError() == IError.SE_VERSION_NOEXIST )
                try
                {
                    newVersion = parentVersion.CreateVersion(versionName);
                }
                catch (Exception se)
                {
                    MessageBox.Show(se.ToString());
                }
            }
            newVersion.Access = access;
            return newVersion;
        }

        public bool WorkspaceIsLocked(IWorkspace wsp)
        {
            IVersion dbversion = (IVersion)wsp;
            IEnumLockInfo enumLockInfo = dbversion.VersionLocks;
            enumLockInfo.Reset();

            ILockInfo lockInfo = enumLockInfo.Next();
            if (lockInfo == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region ISdeVersionInfo Members

        string ISdeVersionInfo.GetVersionName()
        {
            throw new NotImplementedException();
        }

        string ISdeVersionInfo.GetSdeDefaultVersionName()
        {
            return _sdeDefault;
        }

        string ISdeVersionInfo.GetDboDefaultVersionName()
        {
            return _dboDefault;
        }

        List<string> ISdeVersionInfo.GetAllVersions()
        {
            string sql = "select name from sde.sde.SDE_versions";
            List<string> versions = new List<string>();
            DataSet ds = new DataSet();
            IDataManager dataManager = new DataManager();
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
                    versions.Add("sde." + row[0].ToString());
                }
            }
            return versions;
        }

        DataSet ISdeVersionInfo.GetAllVersionsAsDataset(out List<string> versions, int is_express)
        {
            string sql = "select * from sde.sde.SDE_versions";
            //List<string> _versions = new List<string>();
            versions = new List<string>();
            DataSet ds = new DataSet();
            IDataManager dataManager = new DataManager();
            if (is_express == SQLServerVersion.IS_EXPRESS)
            {
                try
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.IS_EXPRESS, null, sql);
                }
                catch { }
            }
            else if (is_express == SQLServerVersion.NON_EXPRESS)
            {
                try
                {
                    ds = dataManager.TnQueryBySQL(SQLServerVersion.NON_EXPRESS, null, sql);
                }
                catch { }
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                versions.Add("sde." + row[0].ToString());
            }
            return ds;
        }

        #endregion

        #region ISdeVersionInfo Members


        bool ISdeVersionInfo.WorkspaceIsLocked(IWorkspace wsp)
        {
            throw new NotImplementedException();
        }

        void ISdeVersionInfo.RegisterDataset(IDataset dataset, bool compressDefault)
        {
            IVersionedObject3 versionedObject = (IVersionedObject3)dataset;

            bool IsRegistered;
            bool IsMovingEditsToBase;

            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);
            try
            {
                if (IsRegistered)
                {
                    if (IsMovingEditsToBase)
                    {
                        //first unregister without compressing edits
                        versionedObject.UnRegisterAsVersioned3(compressDefault);

                        //then register as fully versioned
                        versionedObject.RegisterAsVersioned3(false);
                    }
                }
                else
                {
                    //registering as fully versioned
                    versionedObject.RegisterAsVersioned3(false);
                }
            }
            catch (Exception e) 
            { 
                //MessageBox.Show("khong thể đăng ký versioned cho " + dataset.Name); 
            }
        }

        void ISdeVersionInfo.RegisterDataset(IDataset dataset)
        {
            IVersionedObject3 versionedObject = (IVersionedObject3)dataset;

            bool IsRegistered;
            bool IsMovingEditsToBase;

            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);
            try
            {
                if (IsRegistered)
                {
                    if (IsMovingEditsToBase)
                    {
                        //first unregister without compressing edits
                        versionedObject.UnRegisterAsVersioned3(false);

                        //then register as fully versioned
                        versionedObject.RegisterAsVersioned3(false);
                    }
                }
                else
                {
                    //registering as fully versioned
                    versionedObject.RegisterAsVersioned3(false);
                }
            }
            catch (Exception e) 
            { 
                //MessageBox.Show("khong thể đăng ký versioned cho " + dataset.Name); 
            }
        }

        void ISdeVersionInfo.RegisterDataset(IDataset dataset, bool compressDefault, bool moveToBase)
        {
            IVersionedObject3 versionedObject = (IVersionedObject3)dataset;

            bool IsRegistered;
            bool IsMovingEditsToBase;

            versionedObject.GetVersionRegistrationInfo(out IsRegistered, out IsMovingEditsToBase);
            try
            {
                if (IsRegistered)
                {
                    if (IsMovingEditsToBase)
                    {
                        //first unregister without compressing edits
                        versionedObject.UnRegisterAsVersioned3(compressDefault);

                        //then register as fully versioned
                        versionedObject.RegisterAsVersioned3(moveToBase);
                    }
                }
                else
                {
                    //registering as fully versioned
                    versionedObject.RegisterAsVersioned3(moveToBase);
                }
            }
            catch (Exception e) 
            { 
                //MessageBox.Show("khong thể đăng ký versioned cho " + dataset.Name); 
            }
        }

        #endregion
    }
}
