using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.core
{
    public interface ISdeUserInfo:ISqlUserInfo
    {
        string Version { get; set; }
        string Sde_service { get; set; }
        
    }
}
