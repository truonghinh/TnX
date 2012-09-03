//-----------------------------------------------------------------------------
// <copyright file="ExtensionAPI.cs">
//     Copyright (c) 2003 Jason Clark.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//[assembly:AssemblyVersionAttribute("1.0.0.0")]

// The BUILDFROMVS #if is necessary because VS annoying builds from a different
// directory then the one in which the .cs file and .snk file are located
#if BUILDFROMVS
[assembly:AssemblyKeyFileAttribute("tnkey.snk")]
#else
[assembly:AssemblyKeyFileAttribute("keys.snk")]
#endif

// API Criteria and binding bits for sample plug-ins
namespace ExtensionDevExpressFormAPI
{
   public interface IToolBarProvider{
      ToolBarButton[] GetToolbarButtons();
      void OnToolBarButtonClick(Object Sender, ToolBarButtonClickEventArgs args);
   }

   public interface IMenuProvider{
      MenuItem[] GetMenuItems();
   }

   public abstract class PluginForm : XtraForm
   {
   }
}