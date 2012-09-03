using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableLoaiLopDulieu
    {
        private string _name = "loai_lop_dulieu";
        private string _colOid = "OBJECTID";
        private string _colTenLop = "ten";
        private string _colLoaiFile = "loaifile";
        private string _colLoaiDulieu = "loailop";
        //private string _colDuocChon="duocchon";

        public string NAME { get { return _name; } }
        public string OID { get { return _colOid; } }
        public string TEN_LOP { get { return _colTenLop; } }
        public string LOAI_FILE { get { return _colLoaiFile; } }
        public string LOAI_DU_LIEU { get { return _colLoaiDulieu; } }
        //public string DUOC_CHON { get { return _colDuocChon; } }
    }
}
