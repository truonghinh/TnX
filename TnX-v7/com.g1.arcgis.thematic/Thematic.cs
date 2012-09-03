using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.thematic
{
    public class Thematic : IThematic
    {
        #region map
        private IMapControl3 _mapControl;
        private ITOCControl2 _tocControl;
        private int _indexLayer;
        private string _fieldName;
        private int _breakCount;
        private double _minValue;
        private double _maxValue;
        private double _interval;
        private double _currentValue;
        private IFeatureLayer _ftLayer;
        private IFeatureClass _ftClass;
        private ITable _table;
        #endregion

        #region member for render
        private IClassBreaksRenderer _renderer;
        private IEnumColors _enumColors;
        private IColorRamp _colorRamp;
        private ISimpleFillSymbol _symbol;
        private IGeoFeatureLayer _geoFeatureLayer;
        private IClassifyGEN _classify;
        private ITableHistogram _tableHistogram;
        private IAlgorithmicColorRamp _algClrRamp;
        private IHsvColor _colorFrom;
        private IHsvColor _colorTo;
        private IClassBreaksUIProperties _classBreakPro;


        #endregion
        //private IHistogram

        public Thematic() : this(null) { }

        public Thematic(IMapControl3 mapControl)
        {
            if (mapControl != null)
            {
                this._mapControl = mapControl;
            }
            _renderer = new ClassBreaksRendererClass();
            _classify = new QuantileClass();
            _tableHistogram = new BasicTableHistogramClass();
            _colorFrom = new HsvColorClass();
            _colorTo = new HsvColorClass();
            _algClrRamp = new AlgorithmicColorRampClass();
        }

        #region IThematic Members

        void IThematic.SingleRender()
        {
            //_ftLayer = (IFeatureLayer)_mapControl.get_Layer(0);
            _geoFeatureLayer = (IGeoFeatureLayer)_ftLayer;
            _ftClass = _ftLayer.FeatureClass;
            _table = (ITable)_ftClass;

            _interval = (this._maxValue - this._minValue) / this._breakCount;

            _renderer.Field = _fieldName;
            _renderer.BreakCount = _breakCount;
            _renderer.SortClassesAscending = true;

            _colorFrom.Hue = 60;
            _colorFrom.Saturation = 100;
            _colorFrom.Value = 96;

            _colorTo.Hue = 0;
            _colorTo.Saturation = 100;
            _colorTo.Value = 96;

            _algClrRamp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            _algClrRamp.FromColor = _colorFrom;
            _algClrRamp.ToColor = _colorTo;
            _algClrRamp.Size = _breakCount;
            bool ok;
            _algClrRamp.CreateRamp(out ok);
            _enumColors = _algClrRamp.Colors;

            IColor pColor;
            _currentValue = _minValue;//_renderer.MinimumBreak;

            for (int breakIndex = 0; breakIndex < _breakCount; breakIndex++)
            {

                pColor = _enumColors.Next();
                _symbol = new SimpleFillSymbolClass();
                _symbol.Color = pColor;
                _symbol.Style = esriSimpleFillStyle.esriSFSSolid;

                _renderer.set_Break(breakIndex, _currentValue);

                _renderer.set_Symbol(breakIndex, (ISymbol)_symbol);
                _currentValue += _interval;
            }
            _mapControl.AddLayer(_ftLayer,0);
            _geoFeatureLayer.Renderer = (IFeatureRenderer)_renderer;
            _mapControl.ActiveView.Refresh();
            _tocControl.Update();
            //_tableHistogram.Field = _fieldName;
            //_tableHistogram.Table = _table;

            //_classify.
        }

        int IThematic.IndexLayer
        {
            get
            {
                return _indexLayer;
            }
            set
            {
                _indexLayer = value;
            }
        }

        string IThematic.FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName = value;
            }
        }

        int IThematic.BreakCount
        {
            get
            {
                return _breakCount;
            }
            set
            {
                _breakCount = value;
            }
        }

        void IThematic.SetMapControl(IMapControl3 mapControl)
        {
            this._mapControl = mapControl;
        }

        void IThematic.SetTocControl(ITOCControl2 tocControl)
        {
            this._tocControl = tocControl;
        }

        double IThematic.MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue=value;
            }
        }

        double IThematic.MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue=value;
            }
        }

        void IThematic.JoinRender()
        {
            //_ftLayer = (IFeatureLayer)_mapControl.get_Layer(_indexLayer);
            _geoFeatureLayer = (IGeoFeatureLayer)_ftLayer;
            _ftClass = _ftLayer.FeatureClass;
            _table = (ITable)_ftClass;

            _interval = (this._maxValue - this._minValue) / (this._breakCount-1);

            _renderer.Field = _fieldName;
            _renderer.BreakCount = _breakCount;
            _renderer.SortClassesAscending = true;

            _colorFrom.Hue = 60;
            _colorFrom.Saturation = 100;
            _colorFrom.Value = 96;

            _colorTo.Hue = 0;
            _colorTo.Saturation = 100;
            _colorTo.Value = 96;

            _algClrRamp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            _algClrRamp.FromColor = _colorFrom;
            _algClrRamp.ToColor = _colorTo;
            _algClrRamp.Size = _breakCount;
            bool ok;
            _algClrRamp.CreateRamp(out ok);
            _enumColors = _algClrRamp.Colors;

            IColor pColor;
            _currentValue = _minValue;//_renderer.MinimumBreak;

            for (int breakIndex = 0; breakIndex < _breakCount; breakIndex++)
            {

                pColor = _enumColors.Next();
                _symbol = new SimpleFillSymbolClass { Color = pColor, Style = esriSimpleFillStyle.esriSFSSolid };

                _renderer.set_Break(breakIndex, _currentValue);

                _renderer.set_Symbol(breakIndex, (ISymbol)_symbol);
                _currentValue += _interval;
            }
            _geoFeatureLayer.Renderer = (IFeatureRenderer)_renderer;
            _mapControl.ActiveView.Refresh();
            ILayer lyr=(ILayer)_ftLayer;
            _mapControl.AddLayer(lyr,0);
            _tocControl.Update();
        }

        IFeatureLayer IThematic.Layer
        {
            get
            {
                return _ftLayer;
            }
            set
            {
                _ftLayer=value;
            }
        }

        #endregion
    }
}
