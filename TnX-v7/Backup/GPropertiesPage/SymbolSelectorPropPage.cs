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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;

namespace SymbolSelector
{
  [Guid("795FC5F5-4365-4cce-99C4-B5A3DDD1060A")]
  [ComVisible(true)]
  [ProgId("SymbolSelector.SymbolSelectorPropPage")]
  [ClassInterface(ClassInterfaceType.None)]
  public partial class SymbolSelectorPropPage : PropertyPage
  {
    //private AxMapControl m_axMapPreview = null;
    private AxSymbologyControl m_axSymbologyControl = null;
    public IStyleGalleryItem m_styleGalleryItem;


    public SymbolSelectorPropPage()
    {
      InitializeComponent();

      this.CreateControl();
    }

    protected override void OnPageDeactivate()
    {
      base.OnPageDeactivate();

      //unwire the OnItemSelected event
      m_axSymbologyControl.OnItemSelected -= new ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(OnItemSelected);

      //dispose the control
      m_axSymbologyControl.Dispose();
      m_axSymbologyControl = null;
    }

    protected override void OnPageApply()
    {
      base.OnPageApply();

      PropertySheet propSheet = Objects[0] as PropertySheet;

      IFeatureLayer layer = propSheet.FeatureLayer;
      if (null == layer)
        return;

      if (m_styleGalleryItem == null) return;

      IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)layer;

      //Create a new renderer
      ISimpleRenderer simpleRenderer = new SimpleRendererClass();
      //Set its symbol from the styleGalleryItem
      simpleRenderer.Symbol = (ISymbol)m_styleGalleryItem.Item;
      //Set the renderer into the geoFeatureLayer
      geoFeatureLayer.Renderer = (IFeatureRenderer)simpleRenderer;

      //Make the PropertyPage class fire an event notifying that the layer's renderer has changed
      propSheet.FireFeatureLayerRendererChanged();
    }

    protected override void OnPageActivate(IntPtr hWndParent, Rectangle Rect, bool bModal)
    {
      try
      {
        base.OnPageActivate(hWndParent, Rect, bModal);

        LoadStyle();
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex.Message);
      }
    }

    private void SetFeatureClassStyle(esriSymbologyStyleClass styleClass, ISymbol symbol)
    {
      m_styleGalleryItem = null;

      //Get and set the style class
      m_axSymbologyControl.StyleClass = styleClass;
      ISymbologyStyleClass symbologyStyleClass = m_axSymbologyControl.GetStyleClass(styleClass);

      //Create a new server style gallery item with its style set
      IStyleGalleryItem styleGalleryItem = new ServerStyleGalleryItem();
      styleGalleryItem.Item = symbol;
      styleGalleryItem.Name = "mySymbol";

      //Add the item to the style class and select it
      symbologyStyleClass.AddItem(styleGalleryItem, 0);
      symbologyStyleClass.SelectItem(0);
    }

    private string ReadRegistry(string sKey)
    {
      //Open the subkey for reading
      Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey, true);
      if (rk == null) return "";
      // Get the data from a specified item in the key.
      return (string)rk.GetValue("InstallDir");
    }

    private void PreviewImage()
    {
      //Get and set the style class 
      ISymbologyStyleClass symbologyStyleClass = m_axSymbologyControl.GetStyleClass(m_axSymbologyControl.StyleClass);

      //Preview an image of the symbol
      stdole.IPictureDisp picture = symbologyStyleClass.PreviewItem(m_styleGalleryItem, pictureBox1.Width, pictureBox1.Height);
      System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
      pictureBox1.Image = image;
    }

    private void OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
    {
      //Preview the selected item
      m_styleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
      PreviewImage();

      //set the dirty flag
      if (!IsPageActivating)
        PageIsDirty = true;
    }

    private void SymbolSelectorPropPage_Shown(object sender, EventArgs e)
    {
      m_axSymbologyControl = new AxSymbologyControl();
      m_axSymbologyControl.Parent = this;
      m_axSymbologyControl.SetBounds(16, 38, 298, 369);
      m_axSymbologyControl.Refresh();
      m_axSymbologyControl.Update();
      m_axSymbologyControl.OnItemSelected += new ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(OnItemSelected);

      LoadStyle();
    }

    private void LoadStyle()
    {
      try
      {
        if (null == m_axSymbologyControl)
          return;

        PropertySheet propSheet = Objects[0] as PropertySheet;

        IFeatureLayer layer = propSheet.FeatureLayer;
        if (null == layer)
          return;

        //Get the ArcGIS install location
        string sInstall = ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");

        //Load the ESRI.ServerStyle file into the SymbologyControl
        m_axSymbologyControl.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");

        IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)layer;
        ISimpleRenderer simpleRenderer = (ISimpleRenderer)geoFeatureLayer.Renderer;

        //set SymbologyStyle based upon feature type
        switch (layer.FeatureClass.ShapeType)
        {
          case esriGeometryType.esriGeometryPoint:
            SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassMarkerSymbols, simpleRenderer.Symbol);
            break;
          case esriGeometryType.esriGeometryPolyline:
            SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassLineSymbols, simpleRenderer.Symbol);
            break;
          case esriGeometryType.esriGeometryPolygon:
            SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols, simpleRenderer.Symbol);
            break;
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex.Message);
      }
    }

    private void btnMoreSymbols_Click(object sender, EventArgs e)
    {
      //load all available styles from the registry
      //Get the ArcGIS install location
      string sInstall = ReadRegistry("SOFTWARE\\ESRI\\CoreRuntime");
      string path = System.IO.Path.Combine(sInstall, "Styles");

      string[] styleNames = System.IO.Directory.GetFiles(path, "*.ServerStyle");

      MenuItem[] items = new MenuItem[styleNames.Length + 1];

      for (int i = 0; i < styleNames.Length; i++)
      {
        items[i] = new MenuItem(System.IO.Path.GetFileNameWithoutExtension( styleNames[i] ));
        //add the path as the item's name
        items[i].Name = styleNames[i];
        items[i].Click += new EventHandler(SymbolSelectorPropPage_Click);
      }
      items[styleNames.Length] = new MenuItem("More...", new EventHandler(AddStyleFromFile));

      ContextMenu menu = new ContextMenu(items);
      menu.Show(this, btnMoreSymbols.Location);
    }

    void SymbolSelectorPropPage_Click(object sender, EventArgs e)
    {
      MenuItem selectedItem = (MenuItem)sender;
      
      //Load the style file into the SymbologyControl
      m_axSymbologyControl.LoadStyleFile(selectedItem.Name);
      m_axSymbologyControl.Refresh();
    }

    void AddStyleFromFile(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.CheckPathExists = true;
      ofd.CheckFileExists = true;
      ofd.RestoreDirectory = true;
      ofd.Multiselect = false;
      ofd.Title = "Select Style file";
      ofd.Filter = "ESRI Style Set Files (*.ServerStyle)|*.ServerStyle";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        //Load the style file into the SymbologyControl
        m_axSymbologyControl.LoadStyleFile(ofd.FileName);
        m_axSymbologyControl.Refresh();
      }

    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      m_axSymbologyControl.Clear();
      LoadStyle();
      m_axSymbologyControl.Refresh();
    }
  }
}