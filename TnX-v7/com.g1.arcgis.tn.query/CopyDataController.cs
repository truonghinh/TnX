using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;

namespace com.g1.arcgis.tn.query
{
    public class CopyDataController:ICopyDataController
    {
        private ICopyDataView _view;
        private ICopyData _copy;

        public CopyDataController(ICopyData copy, ICopyDataView copyView)
        {
            this._copy = copy;
            this._view = copyView;
        }

        #region ICopyDataController Members

        void ICopyDataController.Copy()
        {
            _copy.Data=_view.Data;
            _copy.FromYear = _view.FromYear;
            _copy.ToYear = _view.ToYear;
            _copy.Copy();
        }

        #endregion
    }
}
