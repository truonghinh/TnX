using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.connection
{
    //public delegate void ChangedEventHandler(object sender, EventArgs e);
    public class SdeConnectionController:IConnectionInfoController
    {
        
        event ChangedEventHandler _changed;
        protected virtual void OnChanged(EventArgs e)
        {
            if (_changed != null)
                _changed(this, e);
        }
        private ISdeConnectionInfo _sdeConn;
        private IConnectionView _sdeConnView;

        public SdeConnectionController(ISdeConnectionInfo sdeConn, IConnectionView sdeConnView)
        {
            this._sdeConn = sdeConn;
            this._sdeConnView = sdeConnView;
        }
        #region IConnectionInfoController Members

        bool IConnectionInfoController.IsConnecting()
        {
            return this._sdeConn.IsConnecting;
        }

        void IConnectionInfoController.ReqConnect()
        {
            this._sdeConn.CreateSdeWorkspace();
            OnChanged(EventArgs.Empty);
            this._sdeConnView.NotifyConnectionStatus();
            if (this._sdeConn.IsConnecting)
            {
                this._sdeConnView.CloseView();
            }
        }

        void IConnectionInfoController.ReqDisConnect()
        {
            OnChanged(EventArgs.Empty);
        }

        #endregion

        #region IConnectionInfoController Members

        event ChangedEventHandler IConnectionInfoController.DoWork
        {
            add { this._changed+=value; }
            remove { this._changed -= value; }
        }

        #endregion
    }
}
