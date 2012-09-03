using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;
using gov.tn.TnDatabaseStructure;
using DevExpress.XtraGrid.Views.Grid;
//using com.g1.arcgis.calculation;
using com.g1.arcgis.algorithm;
using com.g1.arcgis.landprice;
using com.g1.arcgis.calculation;
using com.g1.arcgis.connection;

namespace com.g1.arcgis.tn.algorithm
{
    public partial class GCalcMethodBuilderView : DevExpress.XtraEditors.XtraUserControl,ICalcMethodBuilderView
    {
        private XtraForm _container;
        private IEditTableView _editHesoVitri;
        private int _currentRowHandle = 0;
        private string _bufferHesoVitri="#";
        private string _bufferMota = "#";
        private string _bufferGhichu = "#";
        private string _bufferQuyTac = "#";
        private string _bufferCachTinhDonGia = "#";
        private string _bufferCachTinhGia = "#";
        private string _bufferCachGhi = "#";
        private RichTextBox _currentRichTextBox;
        private ILandpriceView _landpriceView;
        private IFrmParamsEditorView _paramsEditorView;
        private ITnTableName _tblName;
        private ICallerHskView _caller;
        private object _hsk;
        private object _param;
        public GCalcMethodBuilderView()
        {
            InitializeComponent();
            _editHesoVitri = (IEditTableView)this.gTableView1;
            this.gTableView1.grvAttributeTable.RowClick += new RowClickEventHandler(grvAttributeTable_RowClick);
            this.gTableView1.grvAttributeTable.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(grvAttributeTable_FocusedRowChanged);
        }

        void grvAttributeTable_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _currentRowHandle = e.FocusedRowHandle;
            if (!(_currentRowHandle+1 > 0))
            {
                _currentRowHandle = 1;
            }
            try
            {
                this.rtbQuytac.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns["quytac"]).ToString();
                this.rtbMota.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns["mota"]).ToString();
                this.rtbGhichu.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns["ghichu"]).ToString();
                this.txtHesoVitri.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns["hesovitri"]).ToString();
                this.rtbCachtinhGia.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns["cachtinh"]).ToString();
                this.rtbCachtinhDongia.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns["cachtinhdg"]).ToString();
                this.rtbCachGhi.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns[_tblName.HESO_VITRI.CACH_GHI]).ToString();
            }
            catch(Exception ex) { }
            _bufferGhichu = this.rtbGhichu.Text;
            _bufferHesoVitri = this.txtHesoVitri.Text;
            _bufferMota = this.rtbMota.Text;
            _bufferQuyTac = this.rtbQuytac.Text;
            _bufferCachTinhDonGia = this.rtbCachtinhDongia.Text;
            _bufferCachTinhGia = this.rtbCachtinhGia.Text;
            _bufferCachGhi = rtbCachGhi.Text;
        }

        void grvAttributeTable_RowClick(object sender, RowClickEventArgs e)
        {
            //_currentRowHandle = e.RowHandle;
            //this.rtbQuytac.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(e.RowHandle, gTableView1.grvAttributeTable.Columns["quytac"]).ToString();
            //this.rtbMota.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(e.RowHandle, gTableView1.grvAttributeTable.Columns["mota"]).ToString();
            //this.rtbGhichu.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(e.RowHandle, gTableView1.grvAttributeTable.Columns["ghichu"]).ToString();
            //this.txtHesoVitri.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(e.RowHandle, gTableView1.grvAttributeTable.Columns["hesovitri"]).ToString();
            //this.rtbCachtinhGia.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(e.RowHandle, gTableView1.grvAttributeTable.Columns["cachtinh"]).ToString();
            //this.rtbCachtinhDongia.Text = this.gTableView1.grvAttributeTable.GetRowCellValue(e.RowHandle, gTableView1.grvAttributeTable.Columns["cachtinhdg"]).ToString();

            //_bufferGhichu = this.rtbGhichu.Text;
            //_bufferHesoVitri = this.txtHesoVitri.Text;
            //_bufferMota = this.rtbMota.Text;
            //_bufferQuyTac = this.rtbQuytac.Text;
            //_bufferCachTinhDonGia=this.rtbCachtinhDongia.Text;
            //_bufferCachTinhGia=this.rtbCachtinhGia.Text;
        }

        private void nbiChongLop_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiChonThuaTheoDuong.Tag.ToString());
        }

        private void insertTextIntoRichTextBox(string text)
        {
            if (_currentRichTextBox == null)
            {
                return;
            }
            var insertText = text;
            var selectionIndex = this._currentRichTextBox.SelectionStart;
            this._currentRichTextBox.Text = this._currentRichTextBox.Text.Insert(selectionIndex, insertText);
            this._currentRichTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void setAliasFieldName()
        {
            //List<string[,]> fieldList = new List<string[,]>();
            //fieldList.Add(new string[,] { { "hesovitri", "Hệ số vị trí" } });
            //fieldList.Add(new string[,] { { "mota", "Mô tả" } });
            //fieldList.Add(new string[,] { { "quytac", "Quy tắc" } });
            //fieldList.Add(new string[,] { { "cachtinhdg", "Cách tính đơn giá" } });
            //fieldList.Add(new string[,] { { "cachtinh", "Cách tính theo diện tích" } });
            //fieldList.Add(new string[,] { { "ghichu", "Ghi chú" } });
            _editHesoVitri.AliasFieldName = _tblName.HESO_VITRI.ALIAS_FIELD_LIST;
        }

        private void loadData()
        {
            _editHesoVitri.ExpectedTableName = DataNameTemplate.He_So_K;
            
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            _tblName = new TnTableName(sdeConn.Workspace);
            _editHesoVitri.DbConnectOccur();
            setAliasFieldName();
        }

        #region ICalcMethodBuilderView Members

        void ICalcMethodBuilderView.SetContainer(XtraForm form)
        {
            this._container=form;
        }

        void ICalcMethodBuilderView.Show()
        {
            if (_container != null)
            {
                _container.Show();
            }
            loadData();
        }

        

        void ICalcMethodBuilderView.ShowDialog()
        {
            if (_container != null)
            {
                _container.ShowDialog();
            }
            loadData();
        }

        void ICalcMethodBuilderView.Close()
        {
            if (_container != null)
            {
                _container.Close();
            }
        }

        void ICalcMethodBuilderView.Hide()
        {
            if (_container != null)
            {
                _container.Hide();
            }
        }

        #endregion

        private void nbiIntersect_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiIntersect.Tag.ToString());
        }

        private void nbiContainedBy_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiContainedBy.Tag.ToString());
        }

        private void nbiNewSelection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiNewSelection.Tag.ToString());
        }

        private void nbiAddSelection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiAddSelection.Tag.ToString());
        }

        private void nbiAndSelection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiAndSelection.Tag.ToString());
        }

        private void nbiSubtractSelection_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiSubtractSelection.Tag.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, "quytac", rtbQuytac.Text);
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, "ghichu", rtbGhichu.Text);
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, "mota", rtbMota.Text);
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, "hesovitri", txtHesoVitri.Text);
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, "cachtinh", rtbCachtinhGia.Text);
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, "cachtinhdg", rtbCachtinhDongia.Text);
            this.gTableView1.grvAttributeTable.SetRowCellValue(_currentRowHandle, _tblName.HESO_VITRI.CACH_GHI, rtbCachGhi.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //if (_bufferGhichu != "#")
            //{
                rtbGhichu.Text = _bufferGhichu;
            //}
            //if (_bufferHesoVitri != "#")
            //{
                txtHesoVitri.Text = _bufferHesoVitri;
            //}
            //if (_bufferMota != "#")
            //{
                rtbMota.Text = _bufferMota;
            //}
            //if (_bufferQuyTac != "#")
            //{
                rtbQuytac.Text = _bufferQuyTac;
            rtbCachtinhDongia.Text=_bufferCachTinhDonGia;
            rtbCachtinhGia.Text=_bufferCachTinhGia;
            rtbCachGhi.Text = _bufferCachGhi;
            //}
            //_bufferGhichu = "#";
            //_bufferHesoVitri = "#";
            //_bufferMota = "#";
            //_bufferQuyTac = "#";
        }

        private void rtbMota_TextChanged(object sender, EventArgs e)
        {

        }

        private void nbiGiaDatDuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiGiaDatDuong.Tag.ToString());
        }

        private void nbiDienTich_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiDienTich.Tag.ToString());
        }

        private void nbiHesoDatSxkd_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiGiaDatNongNghiep.Tag.ToString());
        }

        private void rtbQuytac_MouseDown(object sender, MouseEventArgs e)
        {
            _currentRichTextBox = rtbQuytac;
        }

        private void rtbCachtinhDongia_MouseDown(object sender, MouseEventArgs e)
        {
            _currentRichTextBox = rtbCachtinhDongia;
        }

        private void rtbCachtinhGia_MouseDown(object sender, MouseEventArgs e)
        {
            _currentRichTextBox = rtbCachtinhGia;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((ICalcMethodBuilderView)this).Close();
        }

        private void nbiThen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiThen.Tag.ToString());
        }

        #region ICalcMethodBuilderView Members


        object ICalcMethodBuilderView.GetHesoK()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void btnGetHsk_Click(object sender, EventArgs e)
        {
            this._hsk = this.txtHesoVitri.Text;
            //MessageBox.Show(_landpriceView.ToString());
            if (_caller != null)
            {
                _caller.SetHsk(this._hsk);
                //_landpriceView.SetHesoK(this._hsk);
                ((ICalcMethodBuilderView)this).Close();
            }
            
            
            
        }

        #region ICalcMethodBuilderView Members


        void ICalcMethodBuilderView.SetVisibleBtnChonHesoK(bool arg)
        {
            this.btnGetHsk.Visible = arg;
        }

        #endregion

        #region ICalcMethodBuilderView Members


        void ICalcMethodBuilderView.SetLandPriceView(ILandpriceView view)
        {
            this._landpriceView = view;
        }

        #endregion

        private void nbiMoreParams_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if(_paramsEditorView!=null)
            {
                _paramsEditorView.SetUseBtnVisible(true);
                _paramsEditorView.ShowDialog();
            }
        }

        #region
        IFrmParamsEditorView ICalcMethodBuilderView.ParamsEditorView
        {
            get
            {
                return _paramsEditorView;
            }
            set
            {
                _paramsEditorView = value;
                _paramsEditorView.Hook = this;
            }
        }

        #endregion

        #region ICalcMethodBuilderView Members


        object ICalcMethodBuilderView.Param
        {
            get
            {
                return _param;
            }
            set
            {
                _param = value;
                insertTextIntoRichTextBox("["+_param.ToString()+"]");
            }
        }

        #endregion

        private void rtbCachGhi_MouseDown(object sender, MouseEventArgs e)
        {
            _currentRichTextBox = rtbCachGhi;
        }

        #region ICalcMethodBuilderView Members


        void ICalcMethodBuilderView.SetCallerView(ICallerHskView view)
        {
            _caller = view;
        }

        #endregion

        private void nbiGiaDatHemChinh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            insertTextIntoRichTextBox(nbiGiaDatHemChinh.Tag.ToString());
        }
    }
}
