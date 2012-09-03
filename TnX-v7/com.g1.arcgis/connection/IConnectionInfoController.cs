using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public interface IConnectionInfoController
    {
        void ReqConnect();
        void ReqDisConnect();
        bool IsConnecting();
        event ChangedEventHandler DoWork;
        
    }
}
