using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.core
{
    public interface ISdeConnectionView
    {
        void Update(ISdeUserInfo userInfo);
        void GetUserInfos();
        void RenderInfos();
    }
}
