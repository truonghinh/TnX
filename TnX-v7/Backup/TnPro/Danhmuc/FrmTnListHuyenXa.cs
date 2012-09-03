using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.esriSystem;

namespace TNPro.Danhmuc
{
    public sealed partial class FrmTnListHuyenXa : DevExpress.XtraEditors.XtraForm
    {
         public FrmTnListHuyenXa()
        {
            InitializeComponent();
            //SaveToolbarControlItems("c.txt");
        }
        #region Singleton

        //private static readonly FrmTnListHuyenXa meForm = new FrmTnListHuyenXa();
        //private static bool isShown = false;
        
        //private FrmTnListHuyenXa()
        //{
        //    InitializeComponent();
        //    SaveToolbarControlItems("c.txt");
        //}

        //public static FrmTnListHuyenXa CallMe
        //{
        //    get { return meForm; }
        //}
        //static FrmTnListHuyenXa()
        //{
            
        //    meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        //}

        //static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    e.Cancel = true;
        //    isShown = false;
        //    meForm.panelControl1.Hide();
        //    meForm.Hide();
        //}

        //public new void Show()
        //{
        //    if (isShown)
        //    {
        //        base.Show();
        //    }
        //    else
        //    {
        //        isShown = true;
        //        base.Show();
        //    }
        //}

        //public new void ShowDialog()
        //{
            
        //    if (isShown)
        //    {
        //        base.ShowDialog();
        //    }
        //    else
        //    {
                
        //        this.ResumeLayout(false);
        //        isShown = true;
        //        base.ShowDialog();

        //    }
        //    this.panelControl1.Show();
        //}

        #endregion

        private void SaveToolbarControlItems(string filePath)
        {
            //Create a MemoryBlobStream.
            IBlobStream blobStream = new MemoryBlobStreamClass();
            //Get the IStream interface.
            IStream stream = blobStream;
            //Save the ToolbarControl into the stream.
            axToolbarControl1.SaveItems(stream);
            //Save the stream to a file.
            blobStream.SaveToFile(filePath);
        }

        private void LoadToolbarControlItems(string filePath)
        {
            //Create a MemoryBlobStream.
            IBlobStream blobStream = new MemoryBlobStreamClass();
            //Get the IStream interface.
            IStream stream = blobStream;
            //Load the stream from the file.
            blobStream.LoadFromFile(filePath);
            //Load the stream into the ToolbarControl.
            axToolbarControl1.LoadItems(stream);
        }

        private void mnuMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dpnMap.Show();
        }
    }
}