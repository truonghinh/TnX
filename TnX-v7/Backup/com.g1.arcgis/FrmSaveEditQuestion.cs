using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;

namespace com.g1.arcgis
{
    public partial class FrmSaveEditQuestion : DevExpress.XtraEditors.XtraForm
    {
        private IEditView _view;
        public FrmSaveEditQuestion()
        {
            InitializeComponent();
        }

        public void SetView(IEditView view)
        {
            _view = view;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
            //_view.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            //_view.SaveEdit();
            _view.IsSaved = true;
            _view.StopEdit();
            this.Close();
            //_view.Close();
            this.Cursor = Cursors.Arrow;
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            _view.IsSaved = true;
            _view.StopEditWithoutSaving();
            this.Close();
            //_view.Close();
            this.Cursor = Cursors.Arrow;
        }
    }
}