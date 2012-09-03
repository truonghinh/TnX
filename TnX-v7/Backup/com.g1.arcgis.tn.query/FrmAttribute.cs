using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;
using com.g1.arcgis.attribute;
using com.g1.arcgis.map;
using com.g1.arcgis.query;
using com.g1.arcgis.landprice;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.tn.query
{
    public partial class FrmAttribute : DevExpress.XtraEditors.XtraForm,IAttributeView
    {
        private IEditTableView _edit;
        private string _name;
        private IMapView _mapView;
        private ICalculationController _calcController;
        private IExecutor _executor;

        public FrmAttribute()
        {
            InitializeComponent();
            _edit = (IEditTableView)this.gTableView1;
            _edit.SetContextMenuType(G1TypeOfContextMenu.HAS_MAP_AND_CALC);
        }

        #region IAttributeView Members

        void IAttributeView.Show()
        {
            this.Show();
        }

        void IAttributeView.Close()
        {
            this.Close();
        }

        void IAttributeView.SetParent(DevExpress.XtraBars.Ribbon.RibbonForm parent)
        {
            this.MdiParent = parent;
        }

        void IAttributeView.SetTableName(string name)
        {
            this._name = name;
            _edit.ExpectedTableName = this._name;
            _edit.DbConnectOccur();
        }

        void IAttributeView.SetAliasFieldsName(List<string[,]> fields)
        {
            _edit.AliasFieldName = fields;
        }

        void IAttributeView.SetMapView(IMapView mapview)
        {
            _mapView = mapview;
            IAttributeQueryView att = (IAttributeQueryView)_edit;
            att.SetMapView(mapview);
            
        }

        void IAttributeView.SetTitle(string title)
        {
            this.Text = title;
        }

        #endregion

        #region IAttributeView Members


        IAttributeQueryView IAttributeView.GetView()
        {
            return this.gTableView1;
        }

        #endregion

        #region IAttributeView Members


        void IAttributeView.SetDetailView(ILandpriceView calcView, ILandpriceView publicView)
        {
            calcView.CalcController = _calcController;
            calcView.Excutor = _executor;
            publicView.CalcController = _calcController;
            publicView.Excutor = _executor;
            ((IAttributeQueryView)this.gTableView1).SetDetailView(calcView, publicView);
        }

        #endregion

        #region IAttributeView Members


        IExecutor IAttributeView.Executor
        {
            get
            {
                return this._executor;
            }
            set
            {
                _executor = value;
            }
        }

        ICalculationController IAttributeView.CalcController
        {
            get
            {
                return this._calcController;
            }
            set
            {
                this._calcController = value;
            }
        }

        #endregion
    }
}