using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.database
{
    public class LoaderController:ILoaderController
    {
        private ILoader _loader;
        private IReceiverView _view;

        public LoaderController(IReceiverView view, ILoader loader)
        {
            this._view = view;
            this._loader = loader;
        }
        #region ILoaderController Members

        void ILoaderController.ReqLoad(EnumG1ArcGisTnRecType type)
        {
            _loader.Sql = _view.DicSQL[type];
            _loader.Load(type);
        }

        void ILoaderController.ReqReload()
        {
            _loader.Reload();
        }

        #endregion
    }
}
