using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using com.g1.arcgis.landprice;
using System.Collections.Generic;

namespace GCommands
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout, ArcScene/SceneControl
    /// or ArcGlobe/GlobeControl
    /// </summary>
    [Guid("f923efb7-daa4-441f-b0f5-4dc40a72a781")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("GCommands.XemTatCaVungGiaDaCongBo")]
    public class XemTatCaVungGiaDaCongBo : BaseCommand
    {
        protected string[] _keyNames;
        protected List<ILandpriceView> _views;
        public delegate void XemGiaDatEventHandler(object sender, LandEventArgs e);

        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            GMxCommands.Register(regKey);
            MxCommands.Register(regKey);
            SxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            GMxCommands.Unregister(regKey);
            MxCommands.Unregister(regKey);
            SxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        public event XemGiaDatEventHandler XemVungGiaDat;
        #region OnChanged
        /// <summary>
        /// Triggers the Changed event.
        /// </summary>
        public virtual void OnChanged(LandEventArgs ea)
        {
            //MessageBox.Show("line 84 XemVunggiaCongbo");
            if (XemVungGiaDat != null)
            {
                XemVungGiaDat(null/*this*/, ea);
            }
            else
            {
                //MessageBox.Show("line 91 null");
            }
        }
        #endregion

        private IHookHelper m_hookHelper = null;
        private IGlobeHookHelper m_globeHookHelper = null;
        private ISceneHookHelper m_sceneHookHelper = null;
        private string nameOfMaThua = "mathua";
        private string mathua = "";

        public XemTatCaVungGiaDaCongBo()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "GCmd"; //localizable text
            base.m_caption = "Xem thông tin vùng giá đã công bố";  //localizable text
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl, " +
                             "ArcScene/SceneControl, ArcGlobe/GlobeControl";   //localizable text 
            base.m_toolTip = "";  //localizable text 
            base.m_name = "GCmd_AllLandpricesPublished";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overriden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            // Test the hook that calls this command and disable if nothing is valid
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }
            if (m_hookHelper == null)
            {
                //Can be scene or globe
                try
                {
                    m_sceneHookHelper = new SceneHookHelperClass();
                    m_sceneHookHelper.Hook = hook;
                    if (m_sceneHookHelper.ActiveViewer == null)
                    {
                        m_sceneHookHelper = null;
                    }
                }
                catch
                {
                    m_sceneHookHelper = null;
                }

                if (m_sceneHookHelper == null)
                {
                    //Can be globe
                    try
                    {
                        m_globeHookHelper = new GlobeHookHelperClass();
                        m_globeHookHelper.Hook = hook;
                        if (m_globeHookHelper.ActiveViewer == null)
                        {
                            m_globeHookHelper = null;
                        }
                    }
                    catch
                    {
                        m_globeHookHelper = null;
                    }
                }
            }

            if (m_globeHookHelper == null && m_sceneHookHelper == null && m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            //TODO: Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            //MessageBox.Show("line 203 xemgia.., view=" + _keyNames[0]);
            if (_views == null)
            {
                
                return;
            }
            //MessageBox.Show("line 203 xemgia.., view=" + _views[0].Config.NamApDung.ToString());
            IMapControl4 mapControl = null;
            LandEventArgs evt = new LandEventArgs();
            try
            {
                //MessageBox.Show("line 201 XemVunggiaCongbo");
                if (m_hookHelper.Hook is IMapControl4)
                {
                    //MessageBox.Show("line 204 XemVunggiaCongbo");
                    mapControl = (IMapControl4)m_hookHelper.Hook;
                }
                else if (m_hookHelper.Hook is IToolbarControl2)
                {
                    IToolbarControl2 toolbarControl = (IToolbarControl2)m_hookHelper.Hook;
                    mapControl = (IMapControl4)toolbarControl.Buddy;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("line 216 XemVunggiaCongbo, ex when click "+ex.Message);
            }
            //MessageBox.Show("line 204 XemVunggiaCongbo");
            if (m_hookHelper != null)
            {
                //TODO: Add Map/PageLayout related logic
                //MessageBox.Show(this.Name);
                IEnumFeature numFeature = (IEnumFeature)mapControl.ActiveView.FocusMap.FeatureSelection;
                //MessageBox.Show("line 224 num=" + mapControl.Map.LayerCount.ToString());
                IFeature feature=null;
                try
                {
                    feature = numFeature.Next();
                }
                catch (Exception ex) { MessageBox.Show("line 238 ex="+ex.ToString()); }

                if (feature == null)
                {
                    MessageBox.Show("line 242 XemTatCaVungGiaDaCongBo null");
                }
                //MessageBox.Show(feature.get_Value(feature.Fields.FindField(nameOfMaThua)).ToString());
                int index = feature.Fields.FindField("mathua");
                if (index == -1)
                {
                    index = feature.Fields.FindField("mathua_");
                }
                mathua = feature.get_Value(index).ToString();
                evt.Mathua = mathua;
                foreach (ILandpriceView p in _views)
                {
                    p.CurrentMathua = mathua;
                    //_view.Config = CurrentConfig.CallMe();
                    p.Show();
                    p.LoadPrice();
                }
                
                OnChanged(evt);
            }
            else if (m_sceneHookHelper != null)
            {
                //TODO: Add Scene related logic
            }
            else if (m_globeHookHelper != null)
            {
                //TODO: Add Globe related logic
            }
        }

        #endregion

        public void SetMaThuaFieldName(string ma_thua_field)
        {
            nameOfMaThua = ma_thua_field;
        }
        public string GetMaThua()
        {
            return mathua;
        }

        public void SetKeyName(params string[] name)
        {
            _keyNames = name;
        }
        public void SetView(ILandpriceView view)
        {
            if (_views == null)
            {
                _views = new List<ILandpriceView>();
            }
            _views.Add(view);
        }
    }
}
