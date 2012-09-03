using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Controls;

namespace g1.arcgis.map
{
    /// <summary>
    /// Interaction logic for TocView.xaml
    /// </summary>
    public partial class TocView : UserControl,ITocView
    {
        private AxTOCControl _tocControl;
        private IMapView _mapView;
        public TocView()
        {
            InitializeComponent();
        }

        void CreateEngineControls()
        {
            _tocControl = new AxTOCControl();
            tocHost.Child = _tocControl;
        }

        #region ITocView Members

        void ITocView.SetBuddyView(IMapView mapView)
        {
            _mapView = mapView;
            _tocControl.SetBuddyControl(mapView.MapControl);
        }

        #endregion
    }
}
