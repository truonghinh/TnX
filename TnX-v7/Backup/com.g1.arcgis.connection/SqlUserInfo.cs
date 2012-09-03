using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public class SqlUserInfo:UserInfo,ISqlUserInfo
    {
        protected string _db = "";
        protected string _instance = "";

        #region ISqlUserInfo Members

        string ISqlUserInfo.Db
        {
            get
            {
                return this._db;
            }
            set
            {
                this._db=value;
            }
        }

        string ISqlUserInfo.Instance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IUserInfo Members

        void IUserInfo.GetInfo(string fileName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        string IUserInfo.UserName
        {
            get
            {
                return this._user;
            }
            set
            {
                this._user=value;
            }
        }

        #endregion

        #region IUserInfo Members

        string[,] IUserInfo.GetConnectionStringAsArray()
        {
            return new string[,] { { "Data Source", _server }, { "User Id", _user }, { "Password", _pass }, { "Initial Catalog", _db } };
        }

        #endregion

        #region IUserInfo Members

        string IUserInfo.GetConnectionString()
        {
            string[,] user_info = ((IUserInfo)this).GetConnectionStringAsArray();
            string result = "";
            for (int i = 0; i < user_info.Length / 2; i++)
            {
                result += user_info[i, 0] + "=" + user_info[i, 1];
                result += ";";
            }
            return result;
        }

        #endregion
    }
}
