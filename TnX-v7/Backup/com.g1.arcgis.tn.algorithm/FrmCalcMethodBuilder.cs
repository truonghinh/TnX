using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using com.g1.arcgis.algorithm;


namespace com.g1.arcgis.tn.algorithm
{
    public partial class FrmCalcMethodBuilder : DevExpress.XtraEditors.XtraForm,IFrmMethodBuilderView
    {
        private static FrmCalcMethodBuilder _meForm = new FrmCalcMethodBuilder();
        private static bool isShown = false;
        private IFrmParamsEditorView _paramsEditorView;
        private FrmCalcMethodBuilder()
        {
            InitializeComponent();
            ((ICalcMethodBuilderView)this.gCalcMethodBuilderView1).SetContainer(this);
            this.Load += new EventHandler(FrmCalcMethodBuilder_Load);
            
        }

        #region singleton
        public static FrmCalcMethodBuilder CallMe
        {
            get {
                if (_meForm == null)
                {
                    _meForm = new FrmCalcMethodBuilder();
                }
                return _meForm; }
        }
        static FrmCalcMethodBuilder()
        {
            _meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            ((ICalcMethodBuilderView)_meForm.gCalcMethodBuilderView1).SetVisibleBtnChonHesoK(false);
            _meForm.Hide();
        }

        public new void ShowDialog()
        {
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
        
        void FrmCalcMethodBuilder_Load(object sender, EventArgs e)
        {
            ((ICalcMethodBuilderView)gCalcMethodBuilderView1).Show();
        }

        #region IFrmMethodBuilderView Members

        void IFrmMethodBuilderView.Show()
        {
            this.Show();
        }

        void IFrmMethodBuilderView.ShowDialog()
        {
            this.ShowDialog();
        }

        void IFrmMethodBuilderView.Close()
        {
            
            this.Close();
        }

        #endregion

        public ICalcMethodBuilderView GetView()
        {
            return this.gCalcMethodBuilderView1;
        }

        #region IFrmMethodBuilderView Members


        void IFrmMethodBuilderView.SetParamsEditorView(IFrmParamsEditorView frmParamsEditorView)
        {
            _paramsEditorView = frmParamsEditorView;
            ((ICalcMethodBuilderView)this.gCalcMethodBuilderView1).ParamsEditorView = frmParamsEditorView;
        }

        #endregion

        #region IFrmMethodBuilderView Members


        

        #endregion

        #region IFrmMethodBuilderView Members


        ICalcMethodBuilderView IFrmMethodBuilderView.GetView()
        {
            return this.gCalcMethodBuilderView1;
        }

        #endregion
    }
}