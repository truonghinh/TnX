using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;
using com.g1.arcgis.map;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.connection;
using com.g1.arcgis.util.queryString;
using com.g1.arcgis.util.comparation;
using GCommands;
//using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.map
{
    public class GMap:IGMap
    {
        private object _hook;
        private IMapControl3 _mapHook;
        private string _oid;
        private string _ma;
        #region IGMap Members

        void IGMap.AddLayers(List<ILayer> layers)
        {
            throw new NotImplementedException();
        }

        void IGMap.OpenMxd()
        {
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.CloseMxd()
        {
            IMapDocument mapDoc = new MapDocumentClass();
            mapDoc.Open(this._mapHook.DocumentFilename, string.Empty);
            mapDoc.Close();
            
        }

        void IGMap.SaveMxd()
        {
            if (this._mapHook.CheckMxFile(this._mapHook.DocumentFilename))
            {
                //string a=((IMapDocument)this._mapHook).DocumentFilename;
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(this._mapHook.DocumentFilename, string.Empty);
                
                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(this._mapHook.DocumentFilename))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)this._mapHook.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        void IGMap.SetUpBuddies()
        {
            throw new NotImplementedException();
        }

        object IGMap.GetHook()
        {
            return this._hook;
        }

        void IGMap.SetHook(object hook)
        {
            this._hook = hook;
            this._mapHook = (IMapControl3)hook;
        }

        void IGMap.SelectFeature()
        {
            ICommand command = new ControlsSelectFeaturesTool();
            command.OnCreate(this._hook);
            (this._mapHook).CurrentTool = (ITool)command;
        }

        void IGMap.ClearSelected()
        {
            ICommand command = new ControlsClearSelectionCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.ZoomIn()
        {
            ICommand command = new ControlsMapZoomInToolClass();
            command.OnCreate(this._hook);
            (this._mapHook).CurrentTool = (ITool)command;
        }

        void IGMap.ZoomOut()
        {
            
            ICommand command = new ControlsMapZoomOutToolClass();
            command.OnCreate(this._hook);
            (this._mapHook).CurrentTool = (ITool)command;
        }

        void IGMap.ZoomToSelected()
        {
            ICommand command = new ControlsZoomToSelectedCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.FullExtent()
        {
            ICommand command = new ControlsMapFullExtentCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.ZoomBackWard()
        {
            ICommand command = new ControlsMapZoomToLastExtentBackCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.ZoomForWard()
        {
            ICommand command = new ControlsMapZoomToLastExtentForwardCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.Pan()
        {
            ICommand command = new ControlsMapPanToolClass();
            command.OnCreate(this._hook);
            (this._mapHook).CurrentTool = (ITool)command;
        }

        void IGMap.AddData()
        {
            ICommand command = new ControlsAddDataCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.SaveAsMxd()
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        void IGMap.CreateNewMxd()
        {
            IMapDocument mapDoc = (IMapDocument)this._hook;
            mapDoc.New("new mxd");
        }

        string IGMap.Oid
        {
            get
            {
                return this._oid;
            }
            set
            {
                this._oid=value;
            }
        }

        void IGMap.CreateSelectionSet()
        {
            SdeConnection conn=new SdeConnection();
            ISdeConnectionInfo sdeConn=(ISdeConnectionInfo)conn;
            
            ILayer l=this._mapHook.get_Layer(0);
            IFeatureLayer fl = (IFeatureLayer)l;
            IFeatureClass fc = fl.FeatureClass;
            IQueryFilter qrf = new QueryFilterClass();
            //MessageBox.Show(_ma);
            qrf.WhereClause = string.Format("{0}='{1}'", "mathua", _ma);
            ISelectionSet sls= fc.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
            IFeatureSelection fts = (IFeatureSelection)fl;
            fts.SelectionSet = sls;
        }

        string IGMap.Ma
        {
            get
            {
                return this._ma;
            }
            set
            {
                this._ma=value;
            }
        }

        void IGMap.AddLayer(params ILayer[] layer)
        {
            for (int i = 0; i < layer.Length; i++)
            {
                _mapHook.AddLayer(layer[i], 0);
            }
        }

        void IGMap.AddLayer(params string[] layer)
        {
            IFeatureClass fc = null;
            
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            for (int i = 0; i < layer.Length; i++)
            {
                fc = fw.OpenFeatureClass(layer[i]);
                IFeatureLayer fl=new FeatureLayerClass();
                fl.FeatureClass = fc;
                fl.Name = fc.AliasName;
                ILayer l = (ILayer)fl;
                _mapHook.AddLayer(l, 0);
            }
        }

        void IGMap.AddLayers(List<string> layers)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectId(string layerName, params object[] oid)
        {
            bool hasLayer=false;
            int c=this._mapHook.LayerCount;
            if(c==0)
            {
                return;
            }
            string name="";
            IFeatureClass fc = null;
            IFeatureLayer fl=null;
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw=(IFeatureWorkspace)sdeConn.Workspace;
            string queryString=QueryStringBuilder.CreateOrQueryString("OBJECTID",oid);
            //MessageBox.Show(string.Format("line 253 GMap queryString={0}", queryString));
            //MessageBox.Show(string.Format("line 254 GMap layerCount={0}", c));
            for(int i=0;i<c;i++)
            {
                fl=(IFeatureLayer)this._mapHook.get_Layer(i);
                
                name=fl.FeatureClass.AliasName;
                //MessageBox.Show(string.Format("line 260 GMap name={0} - layername={1}", name,layerName));
                if (Compare.Compare2SdeLayerName(name,layerName)==0)
                {
                    hasLayer = true;
                    //MessageBox.Show(string.Format("line 261 GMap layername={0}", name));
                    fc = fl.FeatureClass; 
                    break;
                }
            }
            if (!hasLayer)
            {
                try
                {
                    fc = fw.OpenFeatureClass(layerName);
                }
                catch (Exception)
                {
                    return;
                }
                fl = new FeatureLayerClass();
                fl.FeatureClass = fc;
                fl.Name = fc.AliasName;
                ILayer layer = (ILayer)fl;
                this._mapHook.AddLayer(layer, 0);
            }
            if (fl == null)
            {
                //MessageBox.Show(string.Format("line 285 GMap"));
                return;
            }
            IQueryFilter qrf = new QueryFilterClass();
            qrf.WhereClause = queryString;
            //MessageBox.Show(string.Format("line 290 GMap, qrf={0}",queryString));
            ISelectionSet sls = fc.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
            IFeatureSelection fts = (IFeatureSelection)fl;
            fts.SelectionSet = sls;
            //MessageBox.Show(string.Format("selection count={0}", sls.Count));
            _mapHook.ActiveView.Refresh();

            ((IGMap)this).ZoomToSelected();
            
        }

        void IGMap.ZoomToSelectMa(string layerName, string fieldName, params object[] key)
        {
            bool hasLayer = false;
            int c = this._mapHook.LayerCount;
            if (c == 0)
            {
                return;
            }
            IFeatureClass fc = null;
            IFeatureLayer fl = null;
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            string name = "";
            string queryString = QueryStringBuilder.CreateOrQueryString(fieldName, key);
            for (int i = 0; i < c; i++)
            {
                fl = (IFeatureLayer)this._mapHook.get_Layer(i);

                name = fl.FeatureClass.AliasName;
                //MessageBox.Show(string.Format("line 260 GMap name={0} - layername={1}", name,layerName));
                if (Compare.Compare2SdeLayerName(name, layerName) == 0)
                {
                    hasLayer = true;
                    //MessageBox.Show(string.Format("line 261 GMap layername={0}", name));
                    fc = fl.FeatureClass;
                    break;
                }
            }
            if (!hasLayer)
            {
                try
                {
                    fc = fw.OpenFeatureClass(layerName);
                }
                catch (Exception)
                {
                    return;
                }
                fl = new FeatureLayerClass();
                fl.FeatureClass = fc;
                fl.Name = fc.AliasName;
                ILayer layer = (ILayer)fl;
                this._mapHook.AddLayer(layer, 0);
            }
            if (fl == null)
            {
                //MessageBox.Show(string.Format("line 285 GMap"));
                return;
            }
            IQueryFilter qrf = new QueryFilterClass();
            qrf.WhereClause = queryString;
            //MessageBox.Show(string.Format("line 290 GMap, qrf={0}",queryString));
            ISelectionSet sls = fc.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
            IFeatureSelection fts = (IFeatureSelection)fl;
            fts.SelectionSet = sls;
            //MessageBox.Show(string.Format("selection count={0}", sls.Count));
            _mapHook.ActiveView.Refresh();
            ((IGMap)this).ZoomToSelected();
        }

        void IGMap.ZoomToSelectSelectionSet(string layerName, ISelectionSet selectionSet)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectQueryString(string layerName, string condiction)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectQueryFilter(string layerName, IQueryFilter qrf)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectQueryByLayer(string layerName, IQueryByLayer qrf)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectEvaluableQueryString(string layerName, string evalString)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectId(int layerIndex, params object[] oid)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectMa(int layerIndex, string fieldName, params object[] key)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectSelectionSet(int layerIndex, ISelectionSet selectionSet)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectQueryString(int layerIndex, string condiction)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectQueryFilter(int layerIndex, IQueryFilter qrf)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectQueryByLayer(int layerIndex, IQueryByLayer qrf)
        {
            throw new NotImplementedException();
        }

        void IGMap.ZoomToSelectEvaluableQueryString(int layerIndex, string evalString)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IGMap Members


        void IGMap.Identify()
        {
            
            ICommand command = new ControlsMapIdentifyToolClass();
            command.OnCreate(this._hook);
            (this._mapHook).CurrentTool = (ITool)command;
        }

        void IGMap.SelectByGraphic()
        {
            ICommand command = new ControlsSelectByGraphicsCommandClass();
            command.OnCreate(this._hook);
            (this._mapHook).CurrentTool = (ITool)command;
        }

        #endregion

        #region IGMap Members


        void IGMap.SelectByLocation()
        {
            ICommand command = new GSelectByLocation();
            command.OnCreate(this._hook);
            command.OnClick();
        }

        #endregion
    }
}
