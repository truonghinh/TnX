using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;

namespace com.g1.arcgis.tn.query
{
    public class GJoinController:IJoinController
    {
        private IJoin _join;
        private IJoinView _view;

        public GJoinController(IJoin join, IJoinView view)
        {
            _join = join;
            _view = view;
        }

        #region IJoinController Members

        void IJoinController.Perform()
        {
            _join.Cardinality=_view.Cardinality;
            _join.FeatureLayer = _view.FeatureLayer;
            _join.JoinFieldOnLayer = _view.JoinFieldOnLayer;
            _join.JoinFieldOnTable = _view.JoinFieldOnTable;
            _join.LayerName = _view.LayerName;
            _join.Table = _view.Table;
            _join.TableName = _view.TableName;
            _join.Type = _view.Type;

            _join.Perform();
        }

        #endregion
    }
}
