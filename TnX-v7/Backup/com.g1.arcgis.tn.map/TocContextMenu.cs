using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.map;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using GCommands;
using com.g1.arcgis.property;

namespace com.g1.arcgis.tn.map
{
    public class TocContextMenu:ITocContextMenu
    {
        protected IToolbarMenu2 m_toolbarMenu = null;

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
        //private ItemDef[] m_itemDefs = {
        //                             new ItemDef("SymbolSelector.FeatureLayerSymbology", false, -1),
        //                             new ItemDef("GCommands.OpenTable",false,-1),
        //                             new ItemDef("GCommands.RemoveLayerInToc",false,-1),
                                     
        //                           };
        private ItemDef[] m_itemDefs = { new ItemDef("SymbolSelector.FeatureLayerSymbology", false, -1) };
        public TocContextMenu(object hook)
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
        //public void PopupMenu(int X, int Y, int hWndParent)
        //{
        //    m_toolbarMenu.PopupMenu(X, Y, hWndParent);
        //}

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
        //public void AddItem(object item, bool beginGroup, int subType)
        //{
            
        //}

        #region IMapContextMenu Members

        void ITocContextMenu.AddItem(object item, bool beginGroup, int subType)
        {
            try
            {
                object obj = item;
                ItemDef itemDef = new ItemDef(item.ToString(), beginGroup, subType);
                //obj = Activator.CreateInstance(Type.GetTypeFromProgID(itemDef.itemDef));
                if (obj is Labelor)
                {
                    ILabelView lb= GPropertiesView.CallMe;
                    ((Labelor)obj).LabelView = lb;
                }
                m_toolbarMenu.AddItem(obj, subType, -1, beginGroup, esriCommandStyles.esriCommandStyleIconAndText);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }

        void ITocContextMenu.PopupMenu(int X, int Y, int hWndParent)
        {
            m_toolbarMenu.PopupMenu(X, Y, hWndParent);
        }

        #endregion
    }
}
