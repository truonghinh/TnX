using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public interface IUserInfoController
    {
        /// <summary>
        /// Doc thong tin user tu file xml va gan vao cac textbox
        /// </summary>
        void ReqGetUserInfo(string fileName);
        /// <summary>
        /// ghi thong tin user vao file xml
        /// </summary>
        void ReqSetUserInfo(string fileName);
        void ReqCacheUserInfo();
        void SetModel(IUserInfo userInfo);
        void SetModel(ISdeUserInfo userInfo);
        void SetModel(ISqlUserInfo userInfo);
        //void SetView(ISdeConnectionView connView);
    }
}
