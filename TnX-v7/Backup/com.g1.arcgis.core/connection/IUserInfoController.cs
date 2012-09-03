using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.core
{
    public interface IUserInfoController
    {
        void ReqGetUserInfo();
        void ReqSetUserInfo();
        void SetModel(IUserInfo userInfo);
        void SetModel(ISdeUserInfo userInfo);
        void SetModel(ISqlUserInfo userInfo);
        void SetView(ISdeConnectionView connView);
    }
}
