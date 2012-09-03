using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    public interface IConnectionView
    {
        void Update(IUserInfo userInfo);
        string Server { get; set; }
        //string ServerSde { get; set; }
        string UserName {get;set;}
        string Pass {get;set;}
        string Db { get; set; }
        string Instance { get; set; }
        string Version { get; set; }
        string Sde_service { get; set; }
        string SavePass { get; set; }
        void Connect();
        void Disconnect();
        bool IsConnecting();
        void CloseView();
        void NotifyConnectionStatus();
        /// <summary>
        /// Add From main to disable/enable others button when connection occure
        /// </summary>
        /// <param name="mainSwitch"></param>
        void AddMainSwitch(IMainSwitch mainSwitch);
        void ShowDialog();
    }
}
