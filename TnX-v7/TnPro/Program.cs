using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using TNPro.TnForms;
using System.Security;
using System.IO;
using TNPro.PluginManagement;
using System.Threading;


namespace TNPro
{
    static class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new TNPro.LicenseInitializer();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DMSoft.SkinCrafter.Init();
            //DMSoft.SkinCrafter SkinOb = new DMSoft.SkinCrafter();
            //SkinOb.InitLicenKeys("SKINCRAFTER", "SKINCRAFTER.COM", "support@skincrafter.com", "DEMOSKINCRAFTERLICENCE");
            //SkinOb.InitDecoration(true);
            //SkinOb.LoadSkinFromFile("D:\\Zondar.skf");
            //SkinOb.ApplySkin();

            //ESRI License Initializer generated code.
            //cu
            //---------------------------------------
            //m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] {esriLicenseProductCode.esriLicenseProductCodeArcInfo},
            //new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork, esriLicenseExtensionCode.esriLicenseExtensionCodeSchematics, esriLicenseExtensionCode.esriLicenseExtensionCodeMLE, esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst, esriLicenseExtensionCode.esriLicenseExtensionCodeDataInteroperability, esriLicenseExtensionCode.esriLicenseExtensionCodeTracking });
            //=====================================
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);
            InitializeEngineLicense();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //FrmMain frmMain = FrmMain.frmMain;
            //FrmLogin frmLogin = FrmLogin.CallMe;
            //FrmMainMain frmMainMain = FrmMainMain.CallMe;
            //MainWindow m = new MainWindow();
            //Form3 a = new Form3();
            //FrmInit frmInit = FrmInit.CallMe;
            //FrmCash frm = FrmCash.CallMe;
            //Form5 fr = new Form5();
            //FrmTnMainRibbon frmMain = FrmTnMainRibbon.CallMe;
            ////FrmTnConnectToDatabase frmTnInit = FrmTnConnectToDatabase.CallMe;
            //FrmTnLogin frmLogin = FrmTnLogin.CallMe;
            //Application.Run(frmLogin);

            //extensible
            //try
            //{
                SubMain();
            //}
            //catch (SecurityException)
            //{
            //    MessageBox.Show("This application must be fully trusted to " +
            //       "implement plugin functionality. " +
            //       "Please run from a local drive.", "Insufficient Permissions");
            //}
            


            
            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
            //cu
            //m_AOLicenseInitializer.ShutdownApplication();
            //=========================================
            //SkinOb.DeInitDecoration();
            //DMSoft.SkinCrafter.Terminate();
        }
        private static void InitializeEngineLicense()
        {
            AoInitialize aoi = new AoInitializeClass();

            //Additional license choices can be included here.
            esriLicenseProductCode productCode =
                esriLicenseProductCode.esriLicenseProductCodeArcInfo;
            if (aoi.IsProductCodeAvailable(productCode) ==
                esriLicenseStatus.esriLicenseAvailable)
            {
                aoi.Initialize(productCode);
            }
        }
        static void SubMain()
        {
            InitPluginDirectories();
            //ExtensibleAppForm form = new ExtensibleAppForm();
            //FrmTnMainRibbon frmMain = FrmTnMainRibbon.CallMe;
            //FrmTnLogin frmLogin = FrmTnLogin.CallMe;
            FrmMainRibbonExtensible fr = new FrmMainRibbonExtensible();
            try
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(fr.LoadPlugins));
            }
            catch (SecurityException)
            {
                MessageBox.Show("This application must be fully trusted to " +
                   "implement plugin functionality. " +
                   "Please run from a local drive.", "Insufficient Permissions");
            }
            Application.ThreadException +=
               new ThreadExceptionEventHandler(OnThreadException);

            Application.Run(fr);
        }

        static void OnThreadException(
           Object sender, ThreadExceptionEventArgs args)
        {
            if (args.Exception is SecurityException)
            {
                MessageBox.Show("One of the plugins attempted an operation " +
                   "that was not allowed by security policy!",
                   "Bad Plugin Behavior Error");
            }
        }

        static void InitPluginDirectories()
        {
            String fullTrust = @"Plugins\Fulltrust";
            String semiTrust = @"Plugins\Semitrust";

            Directory.CreateDirectory(fullTrust);
            Directory.CreateDirectory(semiTrust);

            PluginManager.FullTrustPath = fullTrust;
            PluginManager.SemiTrustPath = semiTrust;
        }
    }
}