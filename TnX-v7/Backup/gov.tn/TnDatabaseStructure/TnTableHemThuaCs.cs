using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableHemThuaCs:TnGeoDatabaseObject
    {
        private static TnTableHemThuaCs meClass = null;

        private string _colMaHem = "mahem";
        private string _colMaThua = "mathua";
        private string _colNam = "nam";
        private string _colNamThua = "nam_thua";
        private string _colChieuSau = "chieusau";
        private string _colPhanTram = "phantram";
        private string _colDienTich = "dientich";
        private string _colGiaDat = "giadat";
        private string _colGhiChu = "ghichu";
        private string _colPtDoRong = "ptdorong";
        private string _colPtChieuSau = "ptchieusau";


        public static TnTableHemThuaCs GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableHemThuaCs(workspace);
            }
            return meClass;
        }

        private TnTableHemThuaCs(IWorkspace workspace)
            : base(workspace)
        {
            _name = "sde.hem_thua_chieusau";

            iniObject();
            InitIndex();
        }

        public string MA_HEM { get { return _colMaHem; } set { _colMaHem = value; onColNameChanged(value); } }
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string NAM { get { return _colNam; } set { _colNam = value; onColNameChanged(value); } }
        public string NAM_THUA { get { return _colNamThua; } set { _colNamThua = value; onColNameChanged(value); } }
        public string CHIEU_SAU { get { return _colChieuSau; } set { _colChieuSau = value; onColNameChanged(value); } }
        public string PHAN_TRAM { get { return _colPhanTram; } set { _colPhanTram = value; onColNameChanged(value); } }
        public string DIEN_TICH { get { return _colDienTich; } set { _colDienTich = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string PHAN_TRAM_DO_RONG { get { return _colPtDoRong; } set { _colPtDoRong = value; onColNameChanged(value); } }
        public string PHAN_TRAM_CHIEU_SAU { get { return _colPtChieuSau; } set { _colPtChieuSau = value; onColNameChanged(value); } }
        
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colNam));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colNamThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colChieuSau));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colPhanTram));
            _lstColWithIndex.Add(new TnColWithIndexPair(8, _colDienTich));
            _lstColWithIndex.Add(new TnColWithIndexPair(9, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(10, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(11, _colPtDoRong));
            _lstColWithIndex.Add(new TnColWithIndexPair(12, _colPtChieuSau));
        }
    }
}
