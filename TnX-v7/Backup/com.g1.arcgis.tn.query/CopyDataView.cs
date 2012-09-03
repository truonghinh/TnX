using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.query;
using com.g1.arcgis.edit;


namespace com.g1.arcgis.tn.query
{
    public partial class CopyDataView : DevExpress.XtraEditors.XtraForm, ICopyDataView
    {
        DataTable _data=null;
        ICopyData _copy;
        ICopyDataController _controller;
        IEditTableView _editor;
        private string _fromYear;
        private string _toYear;

        public CopyDataView(IEditTableView editor)
        {
            InitializeComponent();
            _copy = new CopyData();
            _copy.SetView(this);
            _controller = new CopyDataController(_copy, this);
            _editor = editor;
        }

        #region ICopyDataView Members

        void ICopyDataView.Show()
        {
            this.Show();
        }

        void ICopyDataView.ShowDialog()
        {
            this.ShowDialog();
        }

        void ICopyDataView.Close()
        {
            this.Close();
        }

        void ICopyDataView.Copy()
        {
            if (_data != null)
            {
                _controller.Copy();
            }
        }

        DataTable ICopyDataView.Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value; ;
            }
        }

        void ICopyDataView.Update()
        {
            _editor.SaveEdit();
            _editor.RefreshView();
            
        }

        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            ((ICopyDataView)this).FromYear = cbxFromYear.Text;
            ((ICopyDataView)this).ToYear = spnToYear.Text;
            ((ICopyDataView)this).Copy();
        }

        #region ICopyDataView Members


        IEditTableView ICopyDataView.Editor
        {
            get
            {
                return this._editor;
            }
            set
            {
                this._editor=value;
            }
        }

        #endregion

        #region ICopyDataView Members


        void ICopyDataView.Paste(int rowHandle)
        {
            //_editor.CreateNewRowCache();
            _editor.CacheData4NewRow(rowHandle);
        }

        void ICopyDataView.Paste(int rowHandle, params ColValPair[] modify)
        {
            //_editor.CreateNewRowCache();
            _editor.CacheData4NewRow(rowHandle,modify);
        }

        #endregion

        #region ICopyDataView Members


        string ICopyDataView.FromYear
        {
            get
            {
                return this._fromYear;
            }
            set
            {
                this._fromYear=value;
            }
        }

        string ICopyDataView.ToYear
        {
            get
            {
                return this._toYear;
            }
            set
            {
                this._toYear=value;
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
