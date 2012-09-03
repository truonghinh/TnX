//-----------------------------------------------------------------------------
// <copyright file="ExtensionAPI.cs">
//     Copyright (c) 2003 Jason Clark.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;


// The BUILDFROMVS #if is necessary because VS annoying builds from a different
// directory then the one in which the .cs file and .snk file are located
//#if BUILDFROMVS
//[assembly:AssemblyKeyFileAttribute("tnkey.snk")]
//#else
//[assembly:AssemblyKeyFileAttribute("tnkey.snk")]
//#endif

// API Criteria and binding bits for sample plug-ins
namespace ExtensibleAPI{
   public interface IToolBarProvider{
      ToolBarButton[] GetToolbarButtons();
      void OnToolBarButtonClick(Object Sender, ToolBarButtonClickEventArgs args);
   }

   public interface IMenuProvider{
      MenuItem[] GetMenuItems();
   }
   public interface IPageGroupProvider
   {
       RibbonPageGroup[] GetPageGroups();
   }
   public interface IBarButtonProvider
   {
       BarButtonItem[] GetBarButtons();
   }
   
   public abstract class PluginForm:XtraForm{
   }
   public abstract class PluginDockPanel : DockPanel
   {
   }
   public abstract class PluginPageGroup : RibbonPageGroup { }
   public abstract class PluginBarButton : BarButtonItem { }
}