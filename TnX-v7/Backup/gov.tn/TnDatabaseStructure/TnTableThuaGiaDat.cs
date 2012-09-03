using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableThuaGiaDat : TnGeoDatabaseObject
    {
        private static TnTableThuaGiaDat meClass = null;

        private string _colMaThua = "mathua_";
        private string _colMaDuong = "maduong_";
        private string _colMaHem = "mahem_";
        private string _colGiaDat = "giadat";
        private string _colSoMatTien = "somattien";
        private string _colSoMatHem = "somathem";
        private string _colHeSoK = "hesovitri_";
        private string _colSoCachTinh = "socachtinh";
        private string _colDienTich = "Shape.area";
        private string _colCachTinh = "cachtinh";
        private string _colLocked = "khoagia";
        private string _colGhiChu = "ghichu";
        private string _colMaTtx = "mattx_";
        private string _colMaKhuDc = "makhudc_";
        private string _colMaKtvhxh = "maktvhxh_";
        private string _colDonGia = "dongia";
        private string _colDienTichPhapLy = "dientichpl";

        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string MA_HEM { get { return _colMaHem; } set { _colMaHem = value; onColNameChanged(value); } }
        public string SO_MAT_TIEN { get { return _colSoMatTien; } set { _colSoMatTien = value; onColNameChanged(value); } }
        public string SO_MAT_HEM { get { return _colSoMatHem; } set { _colSoMatHem = value; onColNameChanged(value); } }
        public string HE_SO_K { get { return _colHeSoK; } set { _colHeSoK = value; onColNameChanged(value); } }
        public string SO_CACH_TINH { get { return _colSoCachTinh; } set { _colSoCachTinh = value; onColNameChanged(value); } }
        public string DIEN_TICH { get { return _colDienTich; } set { _colDienTich = value; onColNameChanged(value); } }
        public string CACH_TINH { get { return _colCachTinh; } set { _colCachTinh = value; onColNameChanged(value); } }
        public string LOCKED { get { return _colLocked; } set { _colLocked = value; onColNameChanged(value); } }
        public string MA_TRUNG_TAM_XA { get { return _colMaTtx; } set { _colMaTtx = value; onColNameChanged(value); } }
        public string MA_KHU_DC { get { return _colMaKhuDc; } set { _colMaKhuDc = value; onColNameChanged(value); } }
        public string MA_KTVHXH { get { return _colMaKtvhxh; } set { _colMaKtvhxh = value; onColNameChanged(value); } }
        public string DON_GIA { get { return _colDonGia; } set { _colDonGia = value; onColNameChanged(value); } }
        public string DIEN_TICH_PHAP_LY { get { return _colDienTichPhapLy; } set { _colDienTichPhapLy = value; onColNameChanged(value); } }

        public static TnTableThuaGiaDat GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableThuaGiaDat(workspace);
            }
            return meClass;
        }

        private TnTableThuaGiaDat(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Thua_Gia_Dat;
            //_table = _featureWorkspace.OpenTable(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
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
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colDienTich));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(9, _colHeSoK));
            _lstColWithIndex.Add(new TnColWithIndexPair(10, _colLocked));
            _lstColWithIndex.Add(new TnColWithIndexPair(11, _colMaHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colSoCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(14, _colSoMatHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(15, _colSoMatTien));
            _lstColWithIndex.Add(new TnColWithIndexPair(19, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colMaTtx));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colMaKtvhxh));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colMaKhuDc));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colDonGia));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colDienTichPhapLy));
        }
    }
}
