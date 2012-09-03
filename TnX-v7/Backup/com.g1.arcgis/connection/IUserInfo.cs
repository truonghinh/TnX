using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public interface IUserInfo
    {
        string Server { get; set; }
        string UserName { get; set; }
        string Pass { get; set; }
        string SavePass { get; set; }
        void SetInfo(string fileName);
        void GetInfo(string fileName);
        string[,] GetConnectionStringAsArray();
        string GetConnectionString();
    }
}
