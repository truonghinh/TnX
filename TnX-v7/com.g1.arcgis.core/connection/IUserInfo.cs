using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.core
{
    public interface IUserInfo
    {
        string Server { get; set; }
        string User { get; set; }
        string Pass { get; set; }
        string SavePass { get; set; }
        void SetInfo();
        void GetInfo();
    }
}
