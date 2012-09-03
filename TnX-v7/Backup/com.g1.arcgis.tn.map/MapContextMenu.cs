using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using com.g1.arcgis.map;
using GCommands;
using com.g1.arcgis.landprice;
using System.Windows.Forms;
using com.g1.arcgis.calculation;
using com.g1.arcgis.algorithm;

namespace com.g1.arcgis.tn.map
{
    public class MapContextMenu:IMapContextMenu
    {
        protected IToolbarMenu2 m_toolbarMenu = null;
        protected IEditPositionParamsView _editPosView;
        protected string[] _keyName;
        protected List<LandpriceViewPair> _lstView;
        protected ICalcMethodBuilderView _calcMethodBuilderView;

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
                                     new ItemDef("SymbolSelector.FeatureLayerSymbology", false, -1),
                                     new ItemDef("GCommands.OpenTable",false,-1),
                                     new ItemDef("GCommands.RemoveLayerInToc",false,-1),
                                     
                                   };

        public MapContextMenu(object hook)
        {
            m_toolbarMenu = new ToolbarMenuClass();
            m_toolbarMenu.SetHook(hook);
            _lstView = new List<LandpriceViewPair>();
            //AddItems();

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

        void IMapContextMenu.AddItem(object item, bool beginGroup, int subType)
        {
            try
            {
                object obj = item;
                if (item == null)
                {
                    MessageBox.Show("line 114 MapContextMenu");
                }
                ItemDef itemDef = new ItemDef(item.ToString(), beginGroup, subType);
                
                //obj = Activator.CreateInstance(Type.GetTypeFromProgID(itemDef.itemDef));
                if (obj is XemTatCaVungGiaDaCongBo)
                {
                    if (_keyName != null)
                    {
                        ((XemTatCaVungGiaDaCongBo)obj).SetKeyName(_keyName);
                    }
                    if (!(_lstView == null || _lstView.Count <= 0))
                    {
                        foreach (LandpriceViewPair p in _lstView)
                        {
                            if (p.Key == "giadatcongbo")
                            {
                                //MessageBox.Show(p.View.Config.NamApDung.ToString());
                                ((XemTatCaVungGiaDaCongBo)obj).SetView(p.View);
                            }
                        }
                    }
                }
                if (obj is XemTatCaVungGiaDaTinh)
                {
                    if (_keyName != null)
                    {
                        ((XemTatCaVungGiaDaTinh)obj).SetKeyName(_keyName);
                    }
                    if (!(_lstView == null || _lstView.Count <= 0))
                    {
                        foreach (LandpriceViewPair p in _lstView)
                        {
                            if (p.Key == "giadatdatinh")
                            {
                                //MessageBox.Show(p.View.Config.NamApDung.ToString());
                                ((XemTatCaVungGiaDaTinh)obj).SetView(p.View);
                            }
                        }
                    }
                }
                if (obj is SetHesoVitri)
                {
                    ((ICallerHskView)_editPosView).SetCalcMethodBuilderView(_calcMethodBuilderView);
                    ((SetHesoVitri)obj).View = _editPosView;
                    
                }
                m_toolbarMenu.AddItem(obj, subType, -1, beginGroup, esriCommandStyles.esriCommandStyleIconAndText);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(String.Format("line 111 MapContextMenu,ex when add item: \n{0}",ex.Message));
            }
        }

        void IMapContextMenu.PopupMenu(int X, int Y, int hWndParent)
        {
            m_toolbarMenu.PopupMenu(X, Y, hWndParent);
        }

        #endregion

        #region IMapContextMenu Members


        void IMapContextMenu.SetKeyName(params string[] name)
        {
            this._keyName = name;
        }

        #endregion

        #region IMapContextMenu Members


        void IMapContextMenu.SetLandPriceView(string key, ILandpriceView landpriceView)
        {
            _lstView.Add(new LandpriceViewPair(key, landpriceView));
        }

        #endregion

        #region IMapContextMenu Members


        IEditPositionParamsView IMapContextMenu.EditPosView
        {
            get
            {
                return _editPosView;
            }
            set
            {
                _editPosView = value;
            }
        }

        #endregion

        #region IMapContextMenu Members


        ICalcMethodBuilderView IMapContextMenu.CalcMethodBuilderView
        {
            get
            {
                return _calcMethodBuilderView;
            }
            set
            {
                _calcMethodBuilderView = value;
            }
        }

        #endregion
    }
}
