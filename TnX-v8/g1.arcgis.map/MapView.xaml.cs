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
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        AxMapControl mapControl;
        AxToolbarControl toolbarControl;
        AxTOCControl tocControl;
        public MapView()
        {
            InitializeComponent();
            CreateEngineControls();
        }

        void CreateEngineControls()
        {
            //set Engine controls to the child of each hosts 
            mapControl = new AxMapControl();
            mapHost.Child = mapControl;

            toolbarControl = new AxToolbarControl();
            toolbarHost.Child = toolbarControl;

            tocControl = new AxTOCControl();
            tocHost.Child = tocControl;
        }

        private void LoadMap()
        {
            //Buddy up controls
            tocControl.SetBuddyControl(mapControl);
            toolbarControl.SetBuddyControl(mapControl);

            //add command and tools to the toolbar
            toolbarControl.AddItem("esriControls.ControlsOpenDocCommand");
            toolbarControl.AddItem("esriControls.ControlsAddDataCommand");
            toolbarControl.AddItem("esriControls.ControlsSaveAsDocCommand");
            toolbarControl.AddItem("esriControls.ControlsMapNavigationToolbar");
            toolbarControl.AddItem("esriControls.ControlsMapIdentifyTool");

            //set controls' properties
            toolbarControl.BackColor = System.Drawing.Color.FromArgb(245, 245, 220);

            //wire up events
            mapControl.OnMouseMove += new IMapControlEvents2_Ax_OnMouseMoveEventHandler(mapControl_OnMouseMove);

            //mapControl.LoadMxFile("D:\\Untitled.mxd");
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMap();

        }

        private void mapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            textBlock1.Text = " X,Y Coordinates on Map: " + string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), mapControl.MapUnits.ToString().Substring(4));
        }
    }
}
