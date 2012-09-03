using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnUtilities;
using AMS.Profile;

namespace com.g1.arcgis.connection
{
    public class UserInfoController:IUserInfoController
    {
        private ISqlUserInfo _sqlUserInfo;
        private ISdeUserInfo _sdeUserInfo;
        private IConnectionView _connectionView;
        public UserInfoController(ISdeUserInfo userInfo, IConnectionView connView)
        {
            this._sdeUserInfo = userInfo;
            this._connectionView = connView;
        }
        #region IUserInfoController Members

        void IUserInfoController.ReqGetUserInfo(string fileName)
        {
            this._sdeUserInfo.GetInfo(fileName);

            this._connectionView.Db = this._sdeUserInfo.Db;
            this._connectionView.Instance = this._sdeUserInfo.Instance;
            this._connectionView.Pass = this._sdeUserInfo.Pass;
            this._connectionView.Sde_service = this._sdeUserInfo.Sde_service;
            this._connectionView.UserName = this._sdeUserInfo.UserName;
            this._connectionView.Version = this._sdeUserInfo.Version;
            this._connectionView.SavePass = this._sdeUserInfo.SavePass;
            this._connectionView.Server = this._sdeUserInfo.Server;
        }

        void IUserInfoController.ReqSetUserInfo(string fileName)
        {
            this._sdeUserInfo.Db = this._connectionView.Db;
            this._sdeUserInfo.Instance = this._connectionView.Instance;
            this._sdeUserInfo.Pass = this._connectionView.Pass;
            this._sdeUserInfo.Sde_service = this._connectionView.Sde_service;
            this._sdeUserInfo.UserName = this._connectionView.UserName;
            this._sdeUserInfo.Version = this._connectionView.Version;
            this._sdeUserInfo.SavePass = this._connectionView.SavePass;
            this._sdeUserInfo.Server = this._connectionView.Server;

            this._sdeUserInfo.SetInfo(fileName);
        }

        void IUserInfoController.SetModel(ISqlUserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        void IUserInfoController.SetModel(ISdeUserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        void IUserInfoController.SetModel(IUserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        void IUserInfoController.ReqCacheUserInfo()
        {
            this._sdeUserInfo.Db = this._connectionView.Db;
            this._sdeUserInfo.Instance = this._connectionView.Instance;
            this._sdeUserInfo.Pass = this._connectionView.Pass;
            this._sdeUserInfo.Sde_service = this._connectionView.Sde_service;
            this._sdeUserInfo.UserName = this._connectionView.UserName;
            this._sdeUserInfo.Version = this._connectionView.Version;
            this._sdeUserInfo.SavePass = this._connectionView.SavePass;
            this._sdeUserInfo.Server = this._connectionView.Server;
        }

        #endregion
    }
}
