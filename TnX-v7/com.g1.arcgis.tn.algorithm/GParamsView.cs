using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.algorithm;
using com.g1.arcgis.edit;

namespace com.g1.arcgis.tn.algorithm
{
    public partial class GParamsView : DevExpress.XtraEditors.XtraUserControl,IParamsEditorView
    {
        IFrmParamsEditorView _container;
        string _bufferTen = "#";
        string _bufferMota = "#";
        object _bufferGiatri = "#";
        private int _curRow=0;
        private object _currentParam;
        private IEditTableView _hook;
        public GParamsView()
        {
            InitializeComponent();
            
        }

        

        #region IParamsView Members

        void IParamsEditorView.SetContainer(IFrmParamsEditorView form)
        {
            this._container = form;
        }

        void IParamsEditorView.Show()
        {
            if (this._container == null)
            {
                return;
            }
            this._container.Show();
        }

        void IParamsEditorView.ShowDialog()
        {
            if (this._container == null)
            {
                return;
            }
            this._container.ShowDialog();
        }

        void IParamsEditorView.Close()
        {
            if (this._container == null)
            {
                return;
            }
            this._container.Close();
        }

        void IParamsEditorView.Hide()
        {
            if (this._container == null)
            {
                return;
            }
            this._container.Hide();
        }

        object IParamsEditorView.GetParams()
        {
            return this._currentParam;
        }

        #endregion


        #region IParamsEditorView Members


        void IParamsEditorView.SetTextes(string ten, string mota, object giatri)
        {
            this.txtTen.Text = ten;
            this.memMoTa.Text = mota;
            this.txtGiaTri.EditValue = giatri;

            _bufferTen = ten;
            _bufferMota = mota;
            _bufferGiatri = giatri;
            
        }

        #endregion

        #region IParamsEditorView Members


        void IParamsEditorView.SetHook(IEditTableView hook)
        {
            this._hook = hook;
        }

        #endregion

        private void btnGhiVaoBang_Click(object sender, EventArgs e)
        {
            _hook.SetRowCellValue(_curRow, "tenthongso", txtTen.Text);
            _hook.SetRowCellValue(_curRow, "mota", memMoTa.Text);
            _hook.SetRowCellValue(_curRow, "giatri", txtGiaTri.EditValue);
        }

        #region IParamsEditorView Members


        int IParamsEditorView.CurrentRow
        {
            get
            {
                return this._curRow;
            }
            set
            {
                this._curRow=value;
            }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtTen.Text = _bufferTen;
                this.memMoTa.Text = _bufferMota;
                this.txtGiaTri.EditValue = _bufferGiatri;
            }
            catch { }
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            _currentParam = txtTen.Text;
            _container.Param = _currentParam;
            _container.Close();
        }

        #region IParamsEditorView Members


        void IParamsEditorView.SetUseBtnVisible(bool arg)
        {
            btnUse.Visible = arg;
        }

        #endregion
    }
}
