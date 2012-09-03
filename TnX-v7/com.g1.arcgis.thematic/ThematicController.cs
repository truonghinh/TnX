using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using com.g1.arcgis.tn.query;

namespace com.g1.arcgis.thematic
{
    public class ThematicController:IThematicController
    {
        private IThematic _thematic;
        private IThematicView _view;
        private IJoin _join;
        private IJoinView _joinView;
        private IJoinController _joinController;

        public ThematicController(IThematic thematic, IThematicView view)
        {
            _thematic = thematic;
            _view = view;
        }

        #region IThematicController Members

        void IThematicController.SingleRender()
        {
            _thematic.BreakCount = _view.BreakCount;
            _thematic.FieldName = _view.FieldName;
            //_thematic.IndexLayer = _view.IndexLayer;
            _thematic.Layer = _view.Layer;
            _thematic.MaxValue = _view.MaxValue;
            _thematic.MinValue = _view.MinValue;
            _thematic.SingleRender();
        }

        #endregion

        #region IThematicController Members


        void IThematicController.JoinedRender()
        {
            _joinView = (IJoinView)_view;
            _join = new GJoin();
            _joinController = new GJoinController(_join, _joinView);
            _joinController.Perform();

            _thematic.Layer = _joinView.FeatureLayer;
            _thematic.BreakCount = _view.BreakCount;
            _thematic.FieldName = _view.FieldName;
            _thematic.IndexLayer = _view.IndexLayer;
            _thematic.MaxValue = _view.MaxValue;
            _thematic.MinValue = _view.MinValue;
            
            _thematic.JoinRender();
        }

        #endregion
    }
}
