using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using com.g1.arcgis.calculation;

namespace gov.tn.TnDatabaseStructure
{
    public abstract class TnGeoDatabaseObject
    {
        protected IWorkspace _workspace;
        protected IFeatureWorkspace _featureWorkspace;
        protected ITable _table=null;
        protected IFeatureClass _featureClass=null;
        protected List<TnColWithIndexPair> _lstColWithIndex;
        protected List<string[,]> _fieldList = new List<string[,]>();

        protected string _name = "";
        //protected TnColWithIndexPair _colOid;
        //protected TnColWithIndexPair _colShape;

        protected string _colOid = "OBJECTID";
        protected string _colShape = "Shape";
        protected int _colOidIndex = 0;
        protected int _colShapeIndex = 0;

        protected bool _loaded = false;

        public string NAME { get { return _name; } set { _name = value; } }
        public string OID { get { return _colOid; } set { _colOid = value; onColNameChanged(value); } }
        public string SHAPE { get { return _colShape; } set { _colShape = value; onColNameChanged(value); } }
        public List<string[,]> ALIAS_FIELD_LIST { get { return _fieldList; } set { _fieldList = value; } }
        //public int OID_INDEX { get { return _colOidIndex; } }
        //public int SHAPE_INDEX { get { return _colShapeIndex; } }

        public TnGeoDatabaseObject(IWorkspace workspace)
        {
            _workspace = workspace;
            _featureWorkspace = (IFeatureWorkspace)_workspace;
            _lstColWithIndex = new List<TnColWithIndexPair>();
            //iniObject();
            //InitIndex();
            //setAliasFieldsName();
        }

        protected virtual void iniObject()
        {
            _lstColWithIndex.Add(new TnColWithIndexPair(0, _colOid));
            _lstColWithIndex.Add(new TnColWithIndexPair(1, _colShape));
        }

        protected virtual void setAliasFieldsName()
        {

        }

        public void SetAliasFieldsName()
        {
            setAliasFieldsName();
        }

        private void loadFeature()
        {
            
            if (this._table == null)
            {
                try
                {

                    this._featureClass = _featureWorkspace.OpenFeatureClass(this._name);
                    _loaded = true;
                }
                catch(Exception ex) { _loaded = false; }
            }
            if (_featureClass == null)
            {
                try
                {
                    this._table = _featureWorkspace.OpenTable(this._name);
                    _loaded = true;
                }
                catch(Exception ex) { _loaded = false; }
                
            }
        }

        public void InitIndex()
        {
            loadFeature();
            if(_lstColWithIndex.Count==0){return;}
            //MessageBox.Show(_featureClass.AliasName);
            foreach (TnColWithIndexPair o in _lstColWithIndex)
            {
                if (_table == null && _featureClass!=null)
                {
                    o.Index = _featureClass.Fields.FindField(o.ColName);
                    //MessageBox.Show(string.Format("index={0},name={1}",o.Index,o.ColName));
                }
                
                else if (_featureClass == null && _table!=null)
                {
                    o.Index = _table.Fields.FindField(o.ColName);
                }
                //MessageBox.Show(string.Format("index={0},name={1}", o.Index, o.ColName));
            }
        }

        protected void onColNameChanged(string newName)
        {
            if (!_loaded)
            {
                loadFeature();
            }
            if (_lstColWithIndex.Count == 0) { return; }
            foreach (TnColWithIndexPair o in _lstColWithIndex)
            {
                if (o.ColName == newName)
                {
                    if (_table == null)
                    {
                        o.Index = _featureClass.Fields.FindField(o.ColName);
                    }
                    if (_featureClass == null)
                    {
                        o.Index = _table.Fields.FindField(o.ColName);
                    }
                    return;
                }
            }

        }

        public int GetIndex(string colName)
        {
            
            int index = -1;
            if (_lstColWithIndex.Count == 0) { return index; }
            foreach (TnColWithIndexPair o in _lstColWithIndex)
            {
                if (o.ColName == colName)
                {
                    index = o.Index;
                    return index;
                }
            }
            return index;
        }
    }
}
