using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcDuong:TnGeoDatabaseObject
    {
        private static TnFcDuong meClass=null;
        //private string _colOid = "objectid";
        //private string _nameBuffer50m = "thixa_duong_buffer_50m";
        //private string _colTenDuong = "tenduong";
        private string _colMaDuong = "maduong";
        //private string _colMaHuyen = "mahuyen";
        private string _colGhiChu = "ghichu";
        private string _colDoRong = "dorong";
        private string _colVatLieu = "vatlieu";
        //private string _colBatDau = "batdau";
        //private string _colKetThuc = "ketthuc";
        //private string _colDuongChinh = "duongchinh";
        //private string _colKvDothi = "kvdothi";
        private string _colPhanloai = "phanloai";
        private string _colLoaiDuongPho = "loaidgpho";
        //private string _colShape = "Shape";

        //public string OID { get { return _colOid; } set { _colOid = value; } }
        //public string TEN_DUONG { get { return _colTenDuong; } set { _colTenDuong = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        //public string MA_HUYEN { get { return _colMaHuyen; } set { _colMaHuyen = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string DO_RONG { get { return _colDoRong; } set { _colDoRong = value; onColNameChanged(value); } }
        public string VAT_LIEU { get { return _colVatLieu; } set { _colVatLieu = value; onColNameChanged(value); } }
        //public string BAT_DAU { get { return _colBatDau; } set { _colBatDau = value; onColNameChanged(value); } }
        //public string KET_THUC { get { return _colKetThuc; } set { _colKetThuc = value; onColNameChanged(value); } }
        //public string DUONG_CHINH { get { return _colDuongChinh; } set { _colDuongChinh = value; onColNameChanged(value); } }
        //public string NAME_BUFFER_50M { get { return _nameBuffer50m; } set { _nameBuffer50m = value; onColNameChanged(value); } }
        //public string KHU_VUC_DO_THI { get { return _colKvDothi; } set { _colKvDothi = value; onColNameChanged(value); } }
        public string PHAN_LOAI { get { return _colPhanloai; } set { _colPhanloai = value; onColNameChanged(value); } }
        public string LOAI_DUONG_PHO { get { return _colLoaiDuongPho; } set { _colLoaiDuongPho = value; onColNameChanged(value); } }
        public static TnFcDuong GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcDuong(workspace);
            }
            return meClass;
        }
        private TnFcDuong(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Duong;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            //_lstColWithIndex.Add(new TnColWithIndexPair(1, _colTenDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colLoaiDuongPho));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colDoRong));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colVatLieu));
            //_lstColWithIndex.Add(new TnColWithIndexPair(8, _colBatDau));
            //_lstColWithIndex.Add(new TnColWithIndexPair(9, _colKetThuc));
            //_lstColWithIndex.Add(new TnColWithIndexPair(10, _colDuongChinh));
            //_lstColWithIndex.Add(new TnColWithIndexPair(11, _colKvDothi));
            _lstColWithIndex.Add(new TnColWithIndexPair(12, _colPhanloai));
        }
        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaDuong, "Mã đường" } });
            //_fieldList.Add(new string[,] { { _colTenDuong, "Tên đường" } });
            _fieldList.Add(new string[,] { { _colDoRong, "Độ rộng" } });
            _fieldList.Add(new string[,] { { _colVatLieu, "Vật liệu" } });
            _fieldList.Add(new string[,] { { _colPhanloai, "Phân loại" } });
            _fieldList.Add(new string[,] { { _colLoaiDuongPho, "Loại đường phố" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
