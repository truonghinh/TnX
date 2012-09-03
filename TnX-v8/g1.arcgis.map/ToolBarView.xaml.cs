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
    /// Interaction logic for ToolBarView.xaml
    /// </summary>
    public partial class ToolBarView : UserControl,IToolBarView
    {
        private AxToolbarControl _toolbarControl;
        private IMapView _mapView;
        public ToolBarView()
        {
            InitializeComponent();
        }

        #region IToolBarView Members

        void IToolBarView.SetBuddyView(IMapView mapView)
        {
            _mapView = mapView;
            _toolbarControl.SetBuddyControl(mapView.MapControl);
        }

        #endregion
    }
}
