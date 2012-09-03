using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.calculation
{
    public class VisitorBag:ISpatialBag
    {
        private IFeatureLayer _resultLayer;
        private IFeatureLayer _fromLayer;
        private IFeatureLayer _byLayer;
        private IFeatureSelection _featureSelection;
        private ISelectionSet _selectionSet;
        #region IVisitorBag Members

        ESRI.ArcGIS.Carto.IFeatureLayer ISpatialBag.ResultFeatureLayer
        {
            get
            {
                return this._resultLayer;
            }
            set
            {
                this._resultLayer = value;
            }
        }

        ESRI.ArcGIS.Carto.IFeatureSelection ISpatialBag.ResultFeatureSelection
        {
            get
            {
                return this._featureSelection;
            }
            set
            {
                this._featureSelection = value;
            }
        }

        ESRI.ArcGIS.Geodatabase.ISelectionSet ISpatialBag.ResultSelectionSet
        {
            get
            {
                return this._selectionSet;
            }
            set
            {
                this._selectionSet = value;
            }
        }

        #endregion

        #region ISpatialBag Members


        IFeatureLayer ISpatialBag.FromFeatureLayer
        {
            get
            {
                return this._fromLayer;
            }
            set
            {
                this._fromLayer=value;
            }
        }

        IFeatureLayer ISpatialBag.ByFeatureLayer
        {
            get
            {
                return this._byLayer;
            }
            set
            {
                this._byLayer=value;
            }
        }

        #endregion
    }
}
