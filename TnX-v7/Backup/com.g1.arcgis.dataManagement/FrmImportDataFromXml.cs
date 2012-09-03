using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.connection;
using ExtensibleAPI;

namespace com.g1.arcgis.dataManagement
{
    public partial class FrmImportDataFromXml : DevExpress.XtraEditors.XtraForm
    {
        public FrmImportDataFromXml()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = (ISdeConnectionInfo)conn;
            TranferDatabase.ImportFromXml(sdeConn.Workspace, txtFileName.Text, false);
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xml file (*.xml)|*.xml";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            dialog.Title = "Chọn file XML";
            dialog.Multiselect = false;

            DialogResult ret = STAShowDialog(dialog);
            if (ret == DialogResult.OK)
            {
                txtFileName.Text= dialog.FileName;
            }
        }

        private DialogResult STAShowDialog(FileDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}