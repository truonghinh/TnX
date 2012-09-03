using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;
using gov.tn.TnDatabaseStructure;

namespace TNPro.Danhmuc
{
    public partial class FrmLoaiXa : DevExpress.XtraEditors.XtraForm
    {
        private IEditTableView _editXa;
        //private IEditTableView _editLoaiXa;
        public FrmLoaiXa()
        {
            InitializeComponent();
            _editXa = (IEditTableView)this.tblXa;
            _editXa.AllowAddNewRow = false;
            _editXa.AllowDeleteRows = false;
            //_editLoaiXa = (IEditTableView)this.tblLoaiXa;
            this.Load += new EventHandler(FrmLoaiXa_Load);
        }

        void FrmLoaiXa_Load(object sender, EventArgs e)
        {
            _editXa.ExpectedTableName = DataNameTemplate.Ranh_Xa_Poly;
            _editXa.DbConnectOccur();
            //_editLoaiXa.ExpectedTableName = "sde.loaixa";
            //_editLoaiXa.DbConnectOccur();

            setAliasFieldNameXa();
            //setAliasFieldNameLoaiXa();
        }

        private void setAliasFieldNameXa()
        {
            List<string[,]> xaList = new List<string[,]>();
            xaList.Add(new string[,] { { "maxa", "Mã xã" } });
            xaList.Add(new string[,] { { "tenxa", "Tên xã" } });
            xaList.Add(new string[,] { { "mahuyen", "Mã Huyện" } });
            xaList.Add(new string[,] { { "loaidothi", "Loại đô thị" } });
            xaList.Add(new string[,] { { "maloaixa", "Mã loại xã" } });
            _editXa.AliasFieldName = xaList;
        }

        private void setAliasFieldNameLoaiXa()
        {
            List<string[,]> xaList = new List<string[,]>();
            xaList.Add(new string[,] { { "maloaixa", "Mã loại xã" } });
            xaList.Add(new string[,] { { "tenloaixa", "Tên loại xã" } });
            //_editLoaiXa.AliasFieldName = xaList;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.dpnXa.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.dpnLoaiXa.Show();
        }
    }
}