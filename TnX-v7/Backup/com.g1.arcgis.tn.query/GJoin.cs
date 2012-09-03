using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace com.g1.arcgis.tn.query
{
    public class GJoin:IJoin
    {
        private esriJoinType _type;
        private string _filterClause;
        private string _layerName;
        private string _tableName;
        private string _joinFieldOnLayer;
        private string _joinFieldOnTable;
        private esriRelCardinality _cardinality;
        private IFeatureLayer _featureLayer;
        private ITable _table;
        private IGeoFeatureLayer _geoFeatureLayer;
        private IDisplayRelationshipClass _dspRel;
        private IMemoryRelationshipClassFactory _memRelFact;
        private IRelationshipClass _relClass;
        private IRelationshipClassCollectionEdit _relClassEdit;
        private int _indexLayer;
        #region IJoin Members

        void IJoin.Perform()
        {
            _relClassEdit = (IRelationshipClassCollectionEdit)_featureLayer;
            _relClassEdit.RemoveAllRelationshipClasses();

            _geoFeatureLayer = (IGeoFeatureLayer)_featureLayer;
            
            _dspRel = (IDisplayRelationshipClass)_geoFeatureLayer;

            _memRelFact = new MemoryRelationshipClassFactoryClass();
            
            IObjectClass tblObj = (IObjectClass)_table;
            _relClass = _memRelFact.Open("test", _geoFeatureLayer.FeatureClass, _joinFieldOnLayer, tblObj, _joinFieldOnTable,
                "Forwards", "Backwards", _cardinality);
            _dspRel.DisplayRelationshipClass(_relClass, _type);
            
        }

        string IJoin.LayerName
        {
            get
            {
                return _layerName;
            }
            set
            {
                _layerName=value;
            }
        }

        string IJoin.TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName=value;
            }
        }

        esriJoinType IJoin.Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type=value;
            }
        }

        string IJoin.JoinFieldOnLayer
        {
            get
            {
                return _joinFieldOnLayer;
            }
            set
            {
                _joinFieldOnLayer=value;
            }
        }

        string IJoin.JoinFieldOnTable
        {
            get
            {
                return _joinFieldOnTable;
            }
            set
            {
                _joinFieldOnTable=value;
            }
        }

        esriRelCardinality IJoin.Cardinality
        {
            get
            {
                return _cardinality;
            }
            set
            {
                _cardinality=value;
            }
        }

        #endregion

        #region IJoin Members


        IFeatureLayer IJoin.FeatureLayer
        {
            get
            {
                return this._featureLayer;
            }
            set
            {
                _featureLayer=value;
            }
        }

        #endregion

        #region IJoin Members


        ITable IJoin.Table
        {
            get
            {
                return _table;
            }
            set
            {
                _table=value;
            }
        }

        #endregion

        #region IJoin Members


        int IJoin.IndexLayer
        {
            get
            {
                return _indexLayer;
            }
            set
            {
                _indexLayer=value;
            }
        }

        string IJoin.FilterClause
        {
            get
            {
                return _filterClause;
            }
            set
            {
                _filterClause=value;
            }
        }

        #endregion
    }
}
