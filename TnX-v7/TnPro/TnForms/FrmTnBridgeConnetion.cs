using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.connection;

namespace TNPro.TnForms
{
    public partial class FrmTnBridgeConnetion : DevExpress.XtraEditors.XtraForm
    {
        private static readonly FrmTnBridgeConnetion meForm = new FrmTnBridgeConnetion();
        private static bool isShown = false;
        private IMainSwitch _mainForm;
        private FrmTnBridgeConnetion()
        {
            InitializeComponent();
        }

        public static FrmTnBridgeConnetion CallMe
        {
            get { return meForm; }
        }
        static FrmTnBridgeConnetion()
        {
            meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            meForm.Hide();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            FrmConnection frm = FrmConnection.CallMe;
            IConnectionView connView = (IConnectionView)frm;
            connView.AddMainSwitch(_mainForm);
            connView.ShowDialog();
            this.Close();
        }

        public void SetMainView(IMainSwitch mainForm)
        {
            _mainForm = mainForm;
            
        }
    }
}