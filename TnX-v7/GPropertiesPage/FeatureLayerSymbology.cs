// Copyright 2008 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See use restrictions at <your ArcGIS install location>/developerkit/userestrictions.txt.
// 

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Messaging;
using System.Windows.Forms;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;

namespace SymbolSelector
{
  /// <summary>
  /// Summary description for FeatureLayerSymbology.
  /// </summary>
  [Guid("256bd27b-6e24-4cf5-bc5b-46ea93dc952a")]
  [ClassInterface(ClassInterfaceType.None)]
  [ProgId("SymbolSelector.FeatureLayerSymbology")]
  public sealed class FeatureLayerSymbology : BaseCommand
  {
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
      ControlsCommands.Register(regKey);

    }
    /// <summary>
    /// Required method for ArcGIS Component Category unregistration -
    /// Do not modify the contents of this method with the code editor.
    /// </summary>
    private static void ArcGISCategoryUnregistration(Type registerType)
    {
      string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
      ControlsCommands.Unregister(regKey);

    }

    #endregion
    #endregion

    private IHookHelper m_pHookHelper = null;

    public FeatureLayerSymbology()
    {
      base.m_category = "property";
      base.m_caption = "Chọn màu";
      base.m_message = "Show FeatureLayer symbol properties";
      base.m_toolTip = "Thay đổi màu cho lớp bản đồ";
      base.m_name = "property_FeatureLayerSymbology";// base.m_category + "_" + "TN";// base.m_caption;

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
      if (m_pHookHelper == null)
        m_pHookHelper = new HookHelperClass();

      m_pHookHelper.Hook = hook;
    }

    /// <summary>
    /// Occurs when this command is clicked
    /// </summary>
    public override void OnClick()
    {
      try
      {
        IMapControl4 mapControl = null;

        if (m_pHookHelper.Hook is IMapControl4)
          mapControl = (IMapControl4)m_pHookHelper.Hook;
        else if (m_pHookHelper.Hook is IToolbarControl2)
        {
          IToolbarControl2 toolbarControl = (IToolbarControl2)m_pHookHelper.Hook;
          mapControl = (IMapControl4)toolbarControl.Buddy;
        }

        if (null == mapControl.CustomProperty || !(mapControl.CustomProperty is IFeatureLayer))
          return;

        IFeatureLayer featureLayer = (IFeatureLayer)mapControl.CustomProperty;


        //Launch the layer's properties
        Type typ;
        object obj;
        Guid[] g;

        // METHOD 1: Instantiating a COM object and displaying its property pages
        // ONLY WORKS ON TRUE COM OBJECTS!  .NET objects that have rolled their own
        // ISpecifyPropertyPages implementation will error out when you try to cast
        // the instantiated object to your own ISpecifyPropertyPages implementation.

        // Get the typeinfo for the ActiveX common dialog control
        typ = Type.GetTypeFromProgID("MSComDlg.CommonDialog");

        // Create an instance of the control.  We pass it to the property frame function
        // so the property pages have an object from which to get current settings and apply
        // new settings.
        obj = Activator.CreateInstance(typ);
        // This handy function calls IPersistStreamInit->New on COM objects to initialize them
        ActiveXMessageFormatter.InitStreamedObject(obj);

        // Get the property pages for the control using the direct CAUUID method
        // This only works for true COM objects and I demonstrate it here only
        // to show how it is done.  Use the static method
        // PropertyPage.GetPagesForType() method for real-world use.
        ISpecifyPropertyPages pag = (ISpecifyPropertyPages)obj;
        CAUUID cau = new CAUUID(0);
        pag.GetPages(ref cau);
        g = cau.GetPages();

        // Instantiating a .NET object and displaying its property pages
        // WORKS ON ALL OBJECTS, .NET or COM    

        // Create an instance of the .NET control, MyUserControl
        typ = Type.GetTypeFromProgID("SymbolSelector.PropertySheet");

        // Retrieve the pages for the control
        g = PropertyPage.GetPagesForType(typ);

        // Create an instance of the control that we can give to the property pages
        obj = Activator.CreateInstance(typ);

        ((SymbolSelector.PropertySheet)obj).OnFeatureLayerRendererChanged += new FeatureLayerRendererChanged(OnFeatureLayerRendererChanged);

        //add the yahoo layer to the property-sheet control
        ((SymbolSelector.PropertySheet)obj).FeatureLayer = featureLayer;

        // Display the OLE Property page for the control
        object[] items = new object[] { obj };

        PropertyPage.CreatePropertyFrame(IntPtr.Zero, 500, 500, "FeatureLayer Symbology", items, g);
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex.Message);
      }
    }

    void OnFeatureLayerRendererChanged(object sender, EventArgs args)
    {
      m_pHookHelper.ActiveView.ContentsChanged();

      //Refresh the display
      m_pHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_pHookHelper.ActiveView.ScreenDisplay.DisplayTransformation.FittedBounds);
      m_pHookHelper.ActiveView.ScreenDisplay.UpdateWindow();
    }

    #endregion
  }
}
