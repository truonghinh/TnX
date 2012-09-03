using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
using ESRI.ArcGIS.Controls;
using com.g1.arcgis.query;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.connection;
using gov.tn;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.thematic
{
    public partial class ThematicView : DevExpress.XtraEditors.XtraUserControl,IThematicView,IJoinView
    {
        private Control _parentControl;
        private DockPanel _parentDock;
        private XtraForm _parentForm;
        private int _indexLayer;
        private string _fieldName;
        private int _breakCount;
        private double _minValue;
        private double _maxValue;
        private string _thuaName;
        private string _giadatName;
        private IThematicController _controller;
        private IThematic _thematic;
        private IMapControl3 _mapControl;
        private ITOCControl2 _tocControl;

        private string _table4JoinName;
        private string _layer4JoinName;
        private ITable _table4Join;
        private esriJoinType _type;
        private esriRelCardinality _cardinality;
        private string _joinFieldOnLayer;
        private string _joinFieldOnTable;
        private IFeatureLayer _layer4Join;
        private string _filterClause;
        private IFeatureLayer _giadatLayer;

        public ThematicView()
        {
            InitializeComponent();
            
        }

        #region IThematicView Members

        int IThematicView.IndexLayer
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

        string IThematicView.FieldName
        {
            get
            {
                return _fieldName;
            }
            set
            {
                _fieldName=value;
            }
        }

        int IThematicView.BreakCount
        {
            get
            {
                return _breakCount;
            }
            set
            {
                _breakCount=value;
            }
        }

        double IThematicView.MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue=value;
            }
        }

        double IThematicView.MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue=value;
            }
        }

        void IThematicView.Render()
        {
            throw new NotImplementedException();
        }

        void IThematicView.SetParent(Control parent)
        {
            _parentControl = parent;
            
        }

        void IThematicView.SetParent(DockPanel parent)
        {
            _parentDock = parent;
        }

        void IThematicView.SetParent(Form parent)
        {
            
        }

        void IThematicView.SetParent(XtraForm parent)
        {
            this._parentForm = parent;
        }

        void IThematicView.SetMapControl(IMapControl3 mapControl)
        {
            _mapControl = mapControl;
            _thematic = new Thematic(_mapControl);
            
            
        }

        void IThematicView.SetTocControl(ITOCControl2 tocControl)
        {
            _tocControl = tocControl;
            _thematic.SetTocControl(_tocControl);
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            _indexLayer = 0;
            
            _breakCount = int.Parse(txtBreakCount.EditValue.ToString());
            _maxValue = double.Parse(txtMax.EditValue.ToString());
            _minValue = double.Parse(txtMin.EditValue.ToString());
            _thuaName = DataNameTemplate.Thua_Gia_Dat;
            int intloaidat = cbxLoaiDat.SelectedIndex;
            string strLoaiDat = "";
            string tblGiaDat = "";
            switch (intloaidat)
            {
                case 0:
                    tblGiaDat =DataNameTemplate.Thua_Gia_Dat;
                    //strLoaiDat = "Đất nông nghiệp";
                    break;
                case 1:
                    tblGiaDat = DataNameTemplate.Thua_Gia_Dat;
                    strLoaiDat = "Đất phi nông nghiệp tại đô thị";
                    break;
                case 2:
                    tblGiaDat = DataNameTemplate.Thua_Gia_Dat;
                    strLoaiDat = "Đất phi nông nghiệp tại nông thôn";
                    break;
                default:
                    tblGiaDat = DataNameTemplate.Thua_Gia_Dat;
                    strLoaiDat = "Đất nông nghiệp";
                    break;
            }
            _giadatName = string.Format("{0}_{1}",tblGiaDat,spnNam.EditValue);

            int fieldName = cbxField.SelectedIndex;
            switch (fieldName)
            {
                case 0:
                    _fieldName = string.Format("{0}.{1}", _giadatName, "giadat");
                    break;
                case 1:
                    _fieldName = string.Format("{0}.{1}", _giadatName, "dongia");
                    break;
                default:
                    _fieldName = string.Format("{0}.{1}", _giadatName, "dongia");
                    break;
            }

            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            //ITable giadatTable = fw.OpenTable(_giadatName);
            _giadatLayer=new FeatureLayerClass();
            string tgdName = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat, spnNam.EditValue);
            _giadatLayer.FeatureClass = fw.OpenFeatureClass(tgdName);
            _giadatLayer.Name = string.Format("{0} năm {1}", "Giá đất", spnNam.EditValue);
            //IFeatureLayer flThua = (IFeatureLayer)_mapControl.get_Layer(_indexLayer);

            _joinFieldOnLayer = "mathua";
            _joinFieldOnTable = "mathua";
            //_layer4Join = flThua;
            //_table4Join = giadatTable;
            int joinType = cbxType.SelectedIndex;
            switch (joinType)
            {
                case 0:
                    _type = esriJoinType.esriLeftInnerJoin;
                    break;
                case 1:
                    _type = esriJoinType.esriLeftOuterJoin;
                    break;
                default:
                    _type = esriJoinType.esriLeftInnerJoin;
                    break;
            }
            _cardinality = esriRelCardinality.esriRelCardinalityOneToMany;
            

            _controller = new ThematicController(_thematic, this);
            _controller.SingleRender() ;
            closeParent();
        }

        #region IJoinView Members

        void IJoinView.Perform()
        {
            throw new NotImplementedException();
        }

        string IJoinView.LayerName
        {
            get
            {
                return "";
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IJoinView.TableName
        {
            get
            {
                return _table4JoinName;
            }
            set
            {
                _table4JoinName=value;
            }
        }

        esriJoinType IJoinView.Type
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

        string IJoinView.JoinFieldOnLayer
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

        string IJoinView.JoinFieldOnTable
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

        esriRelCardinality IJoinView.Cardinality
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

        IFeatureLayer IJoinView.FeatureLayer
        {
            get
            {
                return _layer4Join;
            }
            set
            {
                _layer4Join=value;
            }
        }

        ITable IJoinView.Table
        {
            get
            {
                return _table4Join;
            }
            set
            {
                _table4Join=value;
            }
        }

        int IJoinView.IndexLayer
        {
            get
            {
                return this._indexLayer;
            }
            set
            {
                _indexLayer=value;
            }
        }

        #endregion

        private void closeParent()
        {
            if (_parentForm != null)
            {
                _parentForm.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closeParent();
        }

        #region IJoinView Members


        string IJoinView.FilterClause
        {
            get
            {
                return _filterClause;
            }
            set
            {
                _filterClause = value;
            }
        }

        #endregion

        #region IThematicView Members


        IFeatureLayer IThematicView.Layer
        {
            get
            {
                return _giadatLayer;
            }
            set
            {
                _giadatLayer=value;
            }
        }

        #endregion
    }
}
