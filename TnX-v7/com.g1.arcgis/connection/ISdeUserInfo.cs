using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public interface ISdeUserInfo:IUserInfo
    {
        string Db { get; set; }
        string Instance { get; set; }
        string ServerSde { get; }
        string Version { get; set; }
        string Sde_service { get; set; }
        ISqlUserInfo GetSqlUserInfo();
    }
}
