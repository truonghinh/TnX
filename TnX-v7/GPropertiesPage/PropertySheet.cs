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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using ESRI.ArcGIS.Carto;

namespace SymbolSelector
{
  //delegate for the OnFeatureLayerRendererChanged event
  public delegate void FeatureLayerRendererChanged(object sender, EventArgs args);

  /// <summary>
  /// PropertySheet class which serves as the manager for the PropertyPages
  /// </summary>
  [Guid("1065420E-E725-4109-A038-66201784DFB9")]
  [ComVisible(true)]
  [ProgId("SymbolSelector.PropertySheet")]
  [ClassInterface(ClassInterfaceType.None)]
  public partial class PropertySheet : UserControl, IProvideObjectHandle, ISpecifyPropertyPages
  {
    
    private IFeatureLayer m_featureLayer;

    //an event which gets fired when the page has applied change to the layer's renderer
    public event FeatureLayerRendererChanged OnFeatureLayerRendererChanged;

    #region Constructor
    public PropertySheet()
    {
      InitializeComponent();
    }
    #endregion

    #region IProvideObjectHandle Members

    /// <summary>
    /// Wraps marshal-by-value object references, allowing them to be returned through an indirection.
    /// </summary>
    public System.Runtime.Remoting.ObjectHandle ObjectHandle
    {
      get { return new ObjectHandle(this); }
    }

    #endregion

    #region ISpecifyPropertyPages Members

    /// <summary>
    /// ills an array of CLSIDs for each property page that can be displayed in this object's property sheet.
    /// </summary>
    /// <param name="pPages">Pointer to a caller-allocated CAUUID structure that must be initialized and filled before returning.</param>
    public void GetPages(ref CAUUID pPages)
    {
      Guid[] g = new Guid[1];

      g[0] = typeof(SymbolSelectorPropPage).GUID;
      pPages.SetPages(g);
    }

    #endregion

    /// <summary>
    /// the FeatureLayer which connects the PropertySheet to the actual layer
    /// </summary>
    public IFeatureLayer FeatureLayer
    {
      get { return m_featureLayer; }
      set { m_featureLayer = value; }
    }

    /// <summary>
    /// Fires an event to notify the listener that the layer's renderer has benn changed
    /// </summary>
    public void FireFeatureLayerRendererChanged()
    {
      if (null != OnFeatureLayerRendererChanged)
        OnFeatureLayerRendererChanged(this, new EventArgs());
    }
  }
}
