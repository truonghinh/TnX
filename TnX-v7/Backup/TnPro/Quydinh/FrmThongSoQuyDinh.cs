using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.algorithm;
using com.g1.arcgis.edit;
using com.g1.arcgis.tn.calculation;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;

namespace TNPro.Quydinh
{
    public partial class FrmThongSoQuyDinh : FrmQuyDinh, IConfigView,IFrmParamsEditorView
    {
        private IEditTableView _edit;
        IParamsEditorView _paramView;
        private static bool isShown = false;
        private int _currentRowHandle = 0;
        private static FrmThongSoQuyDinh _meForm=new FrmThongSoQuyDinh();
        private object _param;
        private ICalcMethodBuilderView _hook;
        private FrmThongSoQuyDinh()
        {
            InitializeComponent();
            
            _edit = (IEditTableView)this.gTableView1;
            _edit.SetContextMenuType(G1TypeOfContextMenu.NORMAL);
            _paramView = this.gParamsView1;
            _paramView.SetContainer(this);
            _paramView.SetHook(_edit);
            this.gTableView1.grvAttributeTable.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(grvAttributeTable_FocusedRowChanged);

            _curConfig = CurrentConfig.CallMe();
            this._openConfigView = new FrmTnOpenParams();
            this._openConfigView.SetConfigView(this);
            this._saveConfigView = new FrmTnSaveParams();
            this._saveConfigView.SetConfigView(this);
            ((IConfigView)this).SetOpenAndSaveView(this._openConfigView, this._saveConfigView);
        }

        private void loadData()
        {
            if (_curConfig == null)
            {
                return;
            }
            string n = DataNameTemplate.Thong_So + "_" + _curConfig.NamApDung;
            _edit.ExpectedTableName = n;
            //MessageBox.Show(string.Format("line 36 FrmThongso, n={0}",n));
            try
            {
                _edit.DbConnectOccur();
                setAliasFieldName();
            }
            catch { }
        }

        private void setAliasFieldName()
        {
            List<string[,]> fieldList = new List<string[,]>();
            fieldList.Add(new string[,] { { "tenthongso", "Tên thông số" } });
            fieldList.Add(new string[,] { { "mota", "Mô tả" } });
            fieldList.Add(new string[,] { { "giatri", "Giá trị" } });
            fieldList.Add(new string[,] { { "ghichu", "Ghi chú" } });
            _edit.AliasFieldName = fieldList;
        }

        void grvAttributeTable_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _currentRowHandle = e.FocusedRowHandle;
            if (!(_currentRowHandle + 1 > 0))
            {
                _currentRowHandle = 1;
            }
            try
            {
                string ten = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns.ColumnByFieldName("tenthongso")).ToString();
                string mota = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns.ColumnByFieldName("mota")).ToString();
                object giatri = this.gTableView1.grvAttributeTable.GetRowCellValue(_currentRowHandle, gTableView1.grvAttributeTable.Columns.ColumnByFieldName("giatri"));


                _paramView.SetTextes(ten, mota, giatri);
            }
            catch { }
            _paramView.CurrentRow = _currentRowHandle;
        }

        #region singleton
        public static FrmThongSoQuyDinh CallMe
        {
            get {
                if (_meForm == null)
                {
                    _meForm = new FrmThongSoQuyDinh();
                }
                return _meForm; }
        }

        static FrmThongSoQuyDinh()
        {
            _meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            _meForm.Hide();
        }

        public new void ShowDialog()
        {
            loadData();
            if (isShown)
            {
                base.ShowDialog();
            }
            else
            {
                isShown = true;
                base.ShowDialog();
            }
            
        }

        public new void Show()
        {
            loadData();
            if (isShown)
            {
                base.Show();
            }
            else
            {
                isShown = true;
                base.Show();
            }
            
        }
        #endregion

        public IParamsEditorView GetView()
        {
            return gParamsView1;
        }

        public void SetConfig(ICurrentConfig conf)
        {
            this._curConfig = conf;
        }



        #region IConfigView Members

        void IConfigView.LoadConfig()
        {
            loadData();
        }

        void IConfigView.SaveConfig()
        {
            throw new NotImplementedException();
        }

        void IConfigView.SetOpenAndSaveView(IOpenConfigView openView, ISaveConfigView saveView)
        {
            this._openConfigView = openView;
            this._saveConfigView = saveView;
        }

        void IConfigView.SetBuddy(List<IConfigView> buddies)
        {
            this._lstConfigView = buddies;
        }

        void IConfigView.ShowDialog()
        {
            this.ShowDialog();
        }

        void IConfigView.KeepFollow()
        {
            foreach (IConfigView conf in _lstConfigView)
            {
                //if (conf.GetType() == this.GetType())
                //{
                //    continue;
                //}
                conf.LoadConfig();
            }
        }

        void IConfigView.Show()
        {
            this.Show();
        }

        #endregion

        #region IFrmParamsEditorView Members

        void IFrmParamsEditorView.Show()
        {
            this.Show();
        }

        void IFrmParamsEditorView.ShowDialog()
        {
            this.ShowDialog();
        }

        void IFrmParamsEditorView.Close()
        {
            this.Close();
        }

        IParamsEditorView IFrmParamsEditorView.ParamsEditorView
        {
            get
            {
                return _paramView;
            }
            set
            {
                _paramView = value;
            }
        }

        object IFrmParamsEditorView.Param
        {
            get
            {
                return _param;
            }
            set
            {
                _param = value;
                _hook.Param = _param;
            }
        }

        #endregion

        #region IFrmParamsEditorView Members


        void IFrmParamsEditorView.Hide()
        {
            this.Hide();
        }

        #endregion

        private void FrmThongSoQuyDinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((IParamsEditorView)gParamsView1).SetUseBtnVisible(false);
        }

        #region IFrmParamsEditorView Members


        void IFrmParamsEditorView.SetUseBtnVisible(bool arg)
        {
            ((IParamsEditorView)gParamsView1).SetUseBtnVisible(arg);
        }

        #endregion

        #region IFrmParamsEditorView Members


        ICalcMethodBuilderView IFrmParamsEditorView.Hook
        {
            get
            {
                return _hook;
            }
            set
            {
                _hook = value;
            }
        }

        #endregion
    }
}