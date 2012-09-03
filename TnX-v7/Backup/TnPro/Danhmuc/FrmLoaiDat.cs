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
    public partial class FrmLoaiDat : DevExpress.XtraEditors.XtraForm
    {
        private IEditTableView _edit;
        public FrmLoaiDat()
        {
            InitializeComponent();
            _edit = (IEditTableView)this.gTableView1;
            this.Load += new EventHandler(Frm_Load);
        }

        void Frm_Load(object sender, EventArgs e)
        {
            _edit.ExpectedTableName = DataNameTemplate.Loai_Dat;
            _edit.DbConnectOccur();
            setAliasFieldName();
        }

        private void setAliasFieldName()
        {
            List<string[,]> fieldList = new List<string[,]>();
            fieldList.Add(new string[,] { { "maloaidat", "Mã loại đất" } }); 
            fieldList.Add(new string[,] { { "tenloaidat", "Tên loại đất" } });
            fieldList.Add(new string[,] { { "datsxkd", "Đất sản xuất kinh doanh" } });
            fieldList.Add(new string[,] { { "nhomdat", "Nhóm đất" } });
            _edit.AliasFieldName = fieldList;
        }
    }
}