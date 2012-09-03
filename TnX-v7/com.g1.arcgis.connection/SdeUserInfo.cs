using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnUtilities;
using AMS.Profile;
using gov.tn.system;

namespace com.g1.arcgis.connection
{
    public class SdeUserInfo:SqlUserInfo,ISdeUserInfo
    {
        protected string _serverSde = "";
        protected string _version = "";
        protected string _sde_service = "";
        
        #region ISdeUserInfo Members

        string ISdeUserInfo.Sde_service
        {
            get
            {
                return this._sde_service;
            }
            set
            {
                this._sde_service=value;
            }
        }

        string ISdeUserInfo.Version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value ;
            }
        }

        #endregion


        #region IUserInfo Members

        void IUserInfo.GetInfo(string fileName)
        {
            //ITnUtilitiesFile fileUtil = new UtilitiesBox();
            Xml userProfile;
            userProfile = new Xml(fileName);

            this._server = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.Server, "server");
            this._user = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.User,"username");
            this._pass = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.Pass,"pass");
            this._db = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.Database,"database");
            this._instance = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.Instance,"instance");
            this._version = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.Version,"sde.DEFAULT");
            this._sde_service = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.ServiceName,"sde");
            this._savePass = (String)userProfile.GetValue(TnConfig.Sde.Name, TnConfig.Sde.SavePass,"false");
            //TnConnectionInfo.CallMe.SetUserInfo(server, user, pass, db, instance, version);
        }

        string IUserInfo.Pass
        {
            get
            {
                return this._pass;
            }
            set
            {
                this._pass=value;
            }
        }

        string IUserInfo.SavePass
        {
            get
            {
                return this._savePass;
            }
            set
            {
                this._savePass=value;
            }
        }

        string IUserInfo.Server
        {
            get
            {
                return this._server;
            }
            set
            {
                this._server=value;
            }
        }

        void IUserInfo.SetInfo(string fileName)
        {
            string pass4File = "";
            using (IEncrypt encrypt = new TnEncrypt())
            {
                string _key = "tn";
                pass4File = encrypt.Encrypt(this._pass, _key, true);
            }
            Xml sdeUserInfo = new Xml(TnSystemFileName.UserInfoFile);
            using (sdeUserInfo.Buffer(true))
            {
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.Server, this._server);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.User, this._user);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.Pass, pass4File);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.Instance, this._instance);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.Database, this._db);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.Version, this._version);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.ServiceName, this._sde_service);
                sdeUserInfo.SetValue(TnConfig.Sde.Name, TnConfig.Sde.SavePass, this._savePass);
            }
        }

        string IUserInfo.UserName
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user = value;
            }
        }

        string ISdeUserInfo.ServerSde
        {
            get
            {
                int len = this._server.IndexOf('\\');
                if (len <= 0)
                    this._serverSde = this._server;
                else
                    this._serverSde = this._server.Substring(0, len);
                return this._serverSde;
            }
            //set
            //{
            //    this._serverSde=value;
            //}
        }

        string[,] IUserInfo.GetConnectionStringAsArray()
        {
            return new string[,] { { "server", _serverSde }, { "uid", _user }, { "pwd", _pass }, { "database", _db }, { "instance", _instance }, { "version", _version } };
        }

        #endregion

        #region IUserInfo Members

        string IUserInfo.GetConnectionString()
        {
            string[,] user_info = ((ISdeUserInfo)this).GetConnectionStringAsArray();
            string result = "";
            for (int i = 0; i < user_info.Length / 2; i++)
            {
                result += user_info[i, 0] + "=" + user_info[i, 1];
                result += ";";
            }
            return result;
        }

        #endregion

        #region ISdeUserInfo Members

        ISqlUserInfo ISdeUserInfo.GetSqlUserInfo()
        {
            ISqlUserInfo userInfo = new SqlUserInfo();
            userInfo.Db = _db;
            userInfo.Pass = _pass;
            userInfo.Server = _server;
            userInfo.SavePass = _savePass;
            userInfo.UserName = _user;
            return userInfo;
        }

        #endregion

        #region ISdeUserInfo Members

        string ISdeUserInfo.Db
        {
            get
            {
                return this._db;
            }
            set
            {
                this._db = value ;
            }
        }

        string ISdeUserInfo.Instance
        {
            get
            {
                return this._instance;
            }
            set
            {
                this._instance=value;
            }
        }

        #endregion
    }
}
