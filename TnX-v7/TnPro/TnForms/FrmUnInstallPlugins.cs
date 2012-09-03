using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using TNPro.PluginManagement;

namespace TNPro.TnForms
{
    public partial class FrmUnInstallPlugins : DevExpress.XtraEditors.XtraForm
    {
        private FileInfo[] rgFiles;
        public FrmUnInstallPlugins()
        {
            InitializeComponent();
        }

        private void FrmUnInstallPlugins_Load(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(PluginManager.FullTrustPath);
            rgFiles = info.GetFiles("*.dll");
            foreach (FileInfo fi in rgFiles)
            {
                string name = fi.Name.Substring(0, fi.Name.Length - 4);
                this.listBoxControl1.Items.Add(name);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.BaseListBoxControl.SelectedItemCollection selected = this.listBoxControl1.SelectedItems;
            int c = selected.Count;
            foreach (object o in selected)
            {
                removePluginExisted(o.ToString());
                listBoxControl1.Items.Remove(o);
            }
        }

        private bool isPluginExisted(string name)
        {
            foreach (FileInfo fi in rgFiles)
            {
                string nameW = string.Format("{0}.dll",name);
                if (string.Compare(fi.Name, nameW) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool removePluginExisted(string name)
        {
            foreach (FileInfo fi in rgFiles)
            {
                string nameW = string.Format("{0}.dll", name);
                if (string.Compare(fi.Name, nameW) == 0)
                {
                    fi.Delete();
                    return true;
                }
            }
            return false;
        }
    }
}