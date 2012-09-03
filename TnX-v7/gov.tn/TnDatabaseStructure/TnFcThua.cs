using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcThua:TnGeoDatabaseObject
    {
        //private IWorkspace _workspace;
        //private IFeatureWorkspace _featureWorkspace;
        //private IFeatureClass _featureClass;
        //private string _name = "thixa_thua";
        //private string _colOid = "OBJECTID";
        private static TnFcThua meClass = null;
        private string _colSoTo = "soto";
        private string _colSoThua = "sothua";
        private string _colLoaiDat = "maloaidat_";
        private string _colDienTich = "dientich";
        private string _colTenChu = "chusohuu";
        private string _colDiaChi = "diachi";
        private string _colGhiChu = "ghichu";
        private string _colMaThua = "mathua";
        private string _colMaXa = "maxa_";
        private string _colGiaDat = "giadat";
        private string _colSoMatTien = "somattien";
        private string _colSoMatHem = "somathem";
        private string _colSoCachTinh = "socachtinh";
        private string _colMaDuong = "maduong_";
        //private string _colMaVung = "mavung";
        //private string _colHeSoK = "hesok";
        private string _colLocked = "locked";

        //private int _colOidIndex = 0;
        //private int _colSoToIndex = 0;
        //private int _colSoThuaIndex = 0;
        //private int _colLoaiDatIndex = 0;
        //private int _colDienTichIndex = 0;
        //private int _colTenChuIndex = 0;
        //private int _colDiaChiIndex = 0;
        //private int _colGhiChuIndex = 0;
        //private int _colMaThuaIndex = 0;
        //private int _colMaXaIndex = 0;
        //private int _colMaVungIndex = 0;
        //private int _colShapeIndex = 0;
        
        public string SO_TO { get { return _colSoTo; } set { _colSoTo = value; onColNameChanged(value); } }
        public string SO_THUA { get { return _colSoThua; } set { _colSoThua = value; onColNameChanged(value); } }
        public string LOAI_DAT { get { return _colLoaiDat; } set { _colLoaiDat = value; onColNameChanged(value); } }
        public string DIEN_TICH { get { return _colDienTich; } set { _colDienTich = value; onColNameChanged(value); } }
        public string TEN_CHU { get { return _colTenChu; } set { _colTenChu = value; onColNameChanged(value); } }
        public string DIA_CHI { get { return _colDiaChi; } set { _colDiaChi = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string MA_XA { get { return _colMaXa; } set { _colMaXa = value; onColNameChanged(value); } }
        public string SO_MAT_TIEN { get { return _colSoMatTien; } set { _colSoMatTien = value; onColNameChanged(value); } }
        public string SO_MAT_HEM { get { return _colSoMatHem; } set { _colSoMatHem = value; onColNameChanged(value); } }
        public string SO_CACH_TINH { get { return _colSoCachTinh; } set { _colSoCachTinh = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        //public string HE_SO_K { get { return _colHeSoK; } set { _colHeSoK = value; onColNameChanged(value); } }
        public string LOCKED { get { return _colLocked; } set { _colLocked = value; onColNameChanged(value); } }

        
        //public int SO_TO_INDEX { get { return _colSoToIndex; } }
        //public int SO_THUA_INDEX { get { return _colSoThuaIndex; } }
        //public int LOAI_DAT_INDEX { get { return _colLoaiDatIndex; } }
        //public int DIEN_TICH_INDEX { get { return _colDienTichIndex; } }
        //public int TEN_CHU_INDEX { get { return _colTenChuIndex; } }
        //public int DIA_CHI_INDEX { get { return _colDiaChiIndex; } }
        //public int GHI_CHU_INDEX { get { return _colGhiChuIndex; } }
        //public int MA_THUA_INDEX { get { return _colMaThuaIndex; } }
        //public int MA_XA_INDEX { get { return _colMaXaIndex; } }
        //public int MA_VUNG_INDEX { get { return _colMaVungIndex; } }

        public static TnFcThua GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcThua(workspace);
            }
            return meClass;
        }
        private TnFcThua(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Thua;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colDiaChi));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colDienTich));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colLoaiDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(8, _colMaXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(9, _colSoThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(10, _colSoTo));
            _lstColWithIndex.Add(new TnColWithIndexPair(11, _colTenChu));
            //_lstColWithIndex.Add(new TnColWithIndexPair(12, _colHeSoK));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colLocked));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colSoCachTinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colSoMatHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(13, _colSoMatTien));
        }
        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaThua, "Mã thửa" } });
            _fieldList.Add(new string[,] { { _colGiaDat, "Giá đất" } });
            _fieldList.Add(new string[,] { { _colSoTo, "Số tờ" } });
            _fieldList.Add(new string[,] { { _colSoThua, "Số thửa" } });
            _fieldList.Add(new string[,] { { _colTenChu, "Tên chủ" } });
            _fieldList.Add(new string[,] { { _colDiaChi, "Địa chỉ" } });
            _fieldList.Add(new string[,] { { _colLoaiDat, "Loại đất" } });
            _fieldList.Add(new string[,] { { _colMaXa, "Mã xã" } });
            _fieldList.Add(new string[,] { { _colDienTich, "Diện tích" } });
            _fieldList.Add(new string[,] { { _colMaDuong, "Mã đường" } });
            _fieldList.Add(new string[,] { { _colSoCachTinh, "Số Cách tính" } });
            _fieldList.Add(new string[,] { { _colSoMatTien, "Số mặt tiền" } });
            _fieldList.Add(new string[,] { { _colSoMatHem, "Số mặt hẻm" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
            
        }
    }
}
