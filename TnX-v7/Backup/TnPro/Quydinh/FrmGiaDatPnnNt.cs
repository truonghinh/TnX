using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.connection;

namespace TNPro.Quydinh
{
    public partial class FrmGiaDatPnnNt : DevExpress.XtraEditors.XtraForm
    {
        private IEditTableView _edit;
        ICurrentConfig _curConfig;
        private ITnTableName _tblName;
        public FrmGiaDatPnnNt()
        {
            InitializeComponent();
            _curConfig = CurrentConfig.CallMe();
            _edit = (IEditTableView)this.gTableViewAllowCopy1;
            this.Load += new EventHandler(Frm_Load);
        }

        void Frm_Load(object sender, EventArgs e)
        {
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            this._tblName = new TnTableName(sdeConn.Workspace);
            string giadatNnName = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Pnn_Nongthon, _curConfig.NamApDung);
            this._tblName.GIA_DAT_O_NONGTHON.NAME = giadatNnName;
            this._tblName.GIA_DAT_O_NONGTHON.InitIndex();
            _edit.ExpectedTableName = giadatNnName;
            
            _edit.DbConnectOccur();
            _edit.AliasFieldName = _tblName.GIA_DAT_O_NONGTHON.ALIAS_FIELD_LIST;
            //setAliasFieldName();
        }

        private void setAliasFieldName()
        {
            List<string[,]> fieldList = new List<string[,]>();
            
            fieldList.Add(new string[,] { { "giadat", "Giá đất" } });
            fieldList.Add(new string[,] { { "maloaidat", "Loại đất" } });
            fieldList.Add(new string[,] { { "vitri", "Vị trí" } });
            fieldList.Add(new string[,] { { "khuvuc", "Khu vực" } });
            fieldList.Add(new string[,] { { "loaixa", "Loại xã" } });
            fieldList.Add(new string[,] { { "ghichu", "Ghi chú" } });
            
            _edit.AliasFieldName = fieldList;
        }
    }
}