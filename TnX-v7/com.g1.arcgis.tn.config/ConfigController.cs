using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.tn.config
{
    public class ConfigController:IConfigController
    {
        private ICurrentConfig _config;
        private IConfigView _view;
        private IConfigReader _reader;
        private IOpenConfigView _openView;
        private ISaveConfigView _saveView;

        public ConfigController(IConfigView view, ICurrentConfig config,IOpenConfigView openView)
        {
            this._config = config;
            this._view = view;
            this._openView = openView;
            this._reader = new ConfigReader(this._config);
        }

        public ConfigController(IConfigView view, ICurrentConfig config, ISaveConfigView saveView)
        {
            this._config = config;
            this._view = view;
            this._saveView = saveView;
            this._reader = new ConfigReader(this._config);
        }

        #region IConfigController Members

        void IConfigController.LoadConfig()
        {
            this._reader.Read(this._openView.FileName,this._openView.NewYear);
            this._openView.Close();
            this._view.LoadConfig();
            this._view.KeepFollow();
        }

        void IConfigController.SaveConfig()
        {
            _view.SaveConfig();
            this._reader.WriteOut(this._saveView.FileName, this._saveView.NewYear);
            this._saveView.Close();
        }

        void IConfigController.SaveAs()
        {
            throw new NotImplementedException();
        }

        void IConfigController.SetSaveView(ISaveConfigView saveView)
        {
            this._saveView = saveView;
        }

        void IConfigController.SetOpenView(IOpenConfigView openView)
        {
            this._openView = openView;
        }

        #endregion
    }
}
