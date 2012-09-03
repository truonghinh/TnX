using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableTgdPnnDt:TnGeoDatabaseObject
    {
        private static TnTableTgdPnnDt meClass = null;
        private string _colMaThua = "mathua";
        private string _colNamApDung = "namapdung";
        private string _colNamThua = "nam_thua";
        private string _colMaLoaiXa = "maloaixa";
        private string _colMaKhuVuc = "makhuvuc";
        private string _colMaDuong = "maduong";
        //private string _colNamDuong = "nam_duong";
        private string _colMaHem = "mahem";
        private string _colGiaDat = "giadat";
        private string _colSoMatTien = "somattien";
        private string _colSoMatHem = "somathem";
        private string _colHeSoK = "hesok";
        private string _colSoCachTinh = "socachtinh";
        private string _colDienTich = "dientich";
        //private string _colGiaDatTg = "giadattg";
        private string _colCachTinh = "cachtinh";
        private string _colLocked = "locked";
        private string _colGhiChu = "ghichu";
        private string _colViTri = "vitri";
        private string _colDonGia = "dongia";
        private string _colMaXa = "maxa";
        private string _colDienTichSau50m = "dtsau50m";

        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string NAM_AP_DUNG { get { return _colNamApDung; } set { _colNamApDung = value; onColNameChanged(value); } }
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string NAM_THUA { get { return _colNamThua; } set { _colNamThua = value; onColNameChanged(value); } }
        public string MA_LOAI_XA { get { return _colMaLoaiXa; } set { _colMaLoaiXa = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string MA_KHU_VUC { get { return _colMaKhuVuc; } set { _colMaKhuVuc = value; onColNameChanged(value); } }
        //public string NAM_DUONG { get { return _colNamDuong; } set { _colNamDuong = value; onColNameChanged(value); } }
        public string MA_HEM { get { return _colMaHem; } set { _colMaHem = value; onColNameChanged(value); } }
        public string SO_MAT_TIEN { get { return _colSoMatTien; } set { _colSoMatTien = value; onColNameChanged(value); } }
        public string SO_MAT_HEM { get { return _colSoMatHem; } set { _colSoMatHem = value; onColNameChanged(value); } }
        public string HE_SO_K { get { return _colHeSoK; } set { _colHeSoK = value; onColNameChanged(value); } }
        public string SO_CACH_TINH { get { return _colSoCachTinh; } set { _colSoCachTinh = value; onColNameChanged(value); } }
        public string DIEN_TICH { get { return _colDienTich; } set { _colDienTich = value; onColNameChanged(value); } }
        //public string GIA_DAT_TONG { get { return _colGiaDatTg; } set { _colGiaDatTg = value; onColNameChanged(value); } }
        public string CACH_TINH { get { return _colCachTinh; } set { _colCachTinh = value; onColNameChanged(value); } }
        public string LOCKED { get { return _colLocked; } set { _colLocked = value; onColNameChanged(value); } }
        public string VI_TRI { get { return _colViTri; } set { _colViTri = value; onColNameChanged(value); } }
        public string DONGIA { get { return _colDonGia; } set { _colDonGia = value; onColNameChanged(value); } }
        public string MA_XA { get { return _colMaXa; } set { _colMaXa = value; onColNameChanged(value); } }
        public string DIEN_TICH_SAU_50M { get { return _colDienTichSau50m; } set { _colDienTichSau50m = value; onColNameChanged(value); } }

        public static TnTableTgdPnnDt GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableTgdPnnDt(workspace);
            }
            return meClass;
        }

        private TnTableTgdPnnDt(IWorkspace workspace)
            : base(workspace)
        {
            _name = "sde.thua_giadat_pnn_dothi";
            //_table = _featureWorkspace.OpenTable(_name);
            iniObject();
            InitIndex();
        }

        //private void initListCol()
        //{
        //    _lstColIndex.Add(new object[] { _colCachTinhIndex, _colCachTinh });
        //    _lstColIndex.Add(new object[] { _colDienTichTgIndex, _colDienTichTg });
        //    _lstColIndex.Add(new object[] { _colCachTinhIndex, _colCachTinh });
        //    _lstColIndex.Add(new object[] { _colGhiChuIndex, _colGhiChu });
        //}

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colNamApDung));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colDienTich));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colGiaDat));
            //_lstColWithIndex.Add(new TnColWithIndexPair(8, _colGiaDatTg));
            _lstColWithIndex.Add(new TnColWithIndexPair(9, _colHeSoK));
            _lstColWithIndex.Add(new TnColWithIndexPair(10, _colLocked));
            _lstColWithIndex.Add(new TnColWithIndexPair(11, _colMaHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(12, _colMaKhuVuc));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colSoCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(14, _colSoMatHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(15, _colSoMatTien));
            _lstColWithIndex.Add(new TnColWithIndexPair(16, _colNamThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(17, _colMaLoaiXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(18, _colViTri));
            _lstColWithIndex.Add(new TnColWithIndexPair(19, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(20, _colDonGia));
            _lstColWithIndex.Add(new TnColWithIndexPair(21, _colMaXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(22, _colDienTichSau50m));
        }
    }
}
