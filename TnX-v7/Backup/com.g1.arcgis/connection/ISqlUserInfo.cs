using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public interface ISqlUserInfo:IUserInfo
    {
        string Db { get; set; }
        string Instance { get; set; }
    }
}
