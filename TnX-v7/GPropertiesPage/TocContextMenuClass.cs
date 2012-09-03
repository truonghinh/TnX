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
using System.Runtime.InteropServices;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;

namespace MapControlAppPropertyPage
{
  
  /// <summary>
  /// Context menu class hosting ArcObject commands
  /// </summary>
  public class TocContextMenuClass
  {
    //class members
    //the underlying toolbarMenu that will be used
    protected IToolbarMenu2 m_toolbarMenu = null;

    //a data-structure used in order to store and manage item definitions
    private struct ItemDef
    {
      //public members
      public string itemDef;
      public bool group;
      public int subType;

      //constructor
      public ItemDef(string itd, bool grp, int subtype)
      {
        itemDef = itd;
        group = grp;
        subType = subtype;
      }
    };

    //array of item definitions with will be used to create the commends for the context menu
    private ItemDef[] m_itemDefs = {
                                     new ItemDef("SymbolSelector.FeatureLayerSymbology", false, -1)
                                   };


    /// <summary>
    /// class constructor
    /// </summary>
    /// <param name="hook"></param>
    public TocContextMenuClass(object hook)
    {
      m_toolbarMenu = new ToolbarMenuClass();
      m_toolbarMenu.SetHook(hook);

      AddItems();

    }

    /// <summary>
    /// popup the context menu at the given location
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="hWndParent"></param>
    public void PopupMenu(int X, int Y, int hWndParent)
    {
      m_toolbarMenu.PopupMenu(X, Y, hWndParent);
    }

    /// <summary>
    /// add the items from the ItemDef array to the menu
    /// </summary>
    private void AddItems()
    {
      try
      {
        object obj = null;
        foreach (ItemDef item in m_itemDefs)
        {
          try
          {
            obj = Activator.CreateInstance(Type.GetTypeFromProgID(item.itemDef));
          }
          catch
          {
            continue;
          }

          m_toolbarMenu.AddItem(obj, item.subType, -1, item.group, esriCommandStyles.esriCommandStyleIconAndText);
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Trace.WriteLine(ex.Message);
      }
    }


    /// <summary>
    /// Incase that the user would want to add an item at runtime
    /// </summary>
    /// <param name="item"></param>
    /// <param name="beginGroup"></param>
    /// <param name="subType"></param>
    public void AddItem(object item, bool beginGroup, int subType)
    {
      m_toolbarMenu.AddItem(item, subType, -1, beginGroup, esriCommandStyles.esriCommandStyleIconAndText);
    }
  }
}
