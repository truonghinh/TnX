using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableTgdPnnNt:TnGeoDatabaseObject
    {
        private static TnTableTgdPnnNt meClass = null;

        private string _colMaLoaiXa = "maloaixa";
        private string _colMaThua = "mathua";
        private string _colMlxKvx = "malx_kvx";
        private string _colNamApDung = "namapdung";
        private string _colMaKhuVuc = "makhuvuc";
        private string _colViTri = "vitri";
        //private string _colMaLoaiDat = "loaidat";
        private string _colGiaDat = "giadat";
        private string _colStt = "stt";
        private string _colMaDuong = "maduong";
        private string _colMaKtvhxh = "maktvhxh";
        //private string _colNamDuong = "nam_duong";
        private string _colDienTich = "dientich";
        private string _colCachTinh = "cachtinh";
        private string _colSoCachTinh = "socachtinh";
        private string _colLocked = "locked";
        private string _colHeSoK = "hesok";
        private string _colGhiChu = "ghichu";
        private string _colDonGia = "dongia";
        private string _colMaXa = "maxa";

        public static TnTableTgdPnnNt GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableTgdPnnNt(workspace);
            }
            return meClass;
        }

        private TnTableTgdPnnNt(IWorkspace workspace)
            : base(workspace)
        {
            _name = "thua_giadat_pnn_nongthon";

            iniObject();
            InitIndex();
        }

        public string MA_LOAI_XA { get { return _colMaLoaiXa; } set { _colMaLoaiXa = value; onColNameChanged(value); } }
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string MA_LX_KVX { get { return _colMlxKvx; } set { _colMlxKvx = value; onColNameChanged(value); } }
        public string NAM_AP_DUNG { get { return _colNamApDung; } set { _colNamApDung = value; onColNameChanged(value); } }
        public string MA_KHU_VUC { get { return _colMaKhuVuc; } set { _colMaKhuVuc = value; onColNameChanged(value); } }
        public string VI_TRI { get { return _colViTri; } set { _colViTri = value; onColNameChanged(value); } }
        //public string MA_LOAI_DAT { get { return _colMaLoaiDat; } set { _colMaLoaiDat = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string STT { get { return _colStt; } set { _colStt = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string MA_KTVHXH { get { return _colMaKtvhxh; } set { _colMaKtvhxh = value; onColNameChanged(value); } }
        //public string NAM_DUONG { get { return _colNamDuong; } set { _colNamDuong = value; onColNameChanged(value); } }
        public string DIEN_TICH { get { return _colDienTich; } set { _colDienTich = value; onColNameChanged(value); } }
        public string LOCKED { get { return _colLocked; } set { _colLocked = value; onColNameChanged(value); } }
        public string HE_SO_K { get { return _colHeSoK; } set { _colHeSoK = value; onColNameChanged(value); } }
        public string SO_CACH_TINH { get { return _colSoCachTinh; } set { _colSoCachTinh = value; onColNameChanged(value); } }
        public string CACH_TINH { get { return _colCachTinh; } set { _colCachTinh = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string DONGIA { get { return _colDonGia; } set { _colDonGia = value; onColNameChanged(value); } }
        public string MA_XA { get { return _colMaXa; } set { _colMaXa = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaLoaiXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMlxKvx));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colNamApDung));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colMaKhuVuc));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colViTri));
            //_lstColWithIndex.Add(new TnColWithIndexPair(8, _colMaLoaiDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(9, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(10, _colStt));
            _lstColWithIndex.Add(new TnColWithIndexPair(11, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(12, _colMaKtvhxh));
            //_lstColWithIndex.Add(new TnColWithIndexPair(13, _colNamDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(14, _colDienTich));
            _lstColWithIndex.Add(new TnColWithIndexPair(15, _colLocked));
            _lstColWithIndex.Add(new TnColWithIndexPair(16, _colSoCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(17, _colHeSoK));
            _lstColWithIndex.Add(new TnColWithIndexPair(18, _colCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(19, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(20, _colDonGia));
            _lstColWithIndex.Add(new TnColWithIndexPair(21, _colMaXa));
        }
    }
}
