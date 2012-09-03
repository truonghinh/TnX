using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableQuyDinh
    {
        private string _name = "quydinh";
        private string _colOid = "OBJECTID";
        private string _colMaQuyDinh = "maquydinh";
        private string _colTenQuyDinh = "tenquydinh";
        private string _colNamApDung = "namapdung";
        private string _colGiaTri = "giatri";
        private string _colGhiChu = "ghichu";

        public string NAME { get { return _name; } set { _name = value; } }
        public string OID { get { return _colOid; } set { _colOid = value; } }
        public string MA_QUY_DINH { get { return _colMaQuyDinh; } set { _colMaQuyDinh = value; } }
        public string TEN_QUY_DINH { get { return _colTenQuyDinh; } set { _colTenQuyDinh = value; } }
        public string NAM_AP_DUNG { get { return _colNamApDung; } set { _colNamApDung = value; } }
        public string GIA_TRI { get { return _colGiaTri; } set { _colGiaTri = value; } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; } }
    }
}
