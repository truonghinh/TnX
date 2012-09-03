using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcHem:TnGeoDatabaseObject
    {
        private static TnFcHem meClass = null;
        private string _colTenHem = "tenhem";
        private string _colMaDuong = "maduong";
        private string _colGhiChu = "ghichu";
        private string _colDoRong = "dorong";
        private string _colVatLieu = "vatlieu";
        //private string _colGiaDat = "giadat";
        private string _colThongRaDuong = "thongraduong";
        private string _colMaHem = "mahem";
        private string _colHemPhu = "hemchinh";

        public string TEN_HEM { get { return _colTenHem; } set { _colTenHem = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string MA_HEM { get { return _colMaHem; } set { _colMaHem = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string DO_RONG { get { return _colDoRong; } set { _colDoRong = value; onColNameChanged(value); } }
        public string VAT_LIEU { get { return _colVatLieu; } set { _colVatLieu = value; onColNameChanged(value); } }
        //public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string THONG_RA_DUONG { get { return _colThongRaDuong; } set { _colThongRaDuong = value; onColNameChanged(value); } }
        public string HEM_CHINH { get { return _colHemPhu; } set { _colHemPhu = value; onColNameChanged(value); } }


        public static TnFcHem GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcHem(workspace);
            }
            return meClass;
        }
        private TnFcHem(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Hem;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colTenHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMaHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colDoRong));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colVatLieu));
            //_lstColWithIndex.Add(new TnColWithIndexPair(8, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(9, _colThongRaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(10, _colHemPhu));
        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaHem, "Mã hẻm" } });
            _fieldList.Add(new string[,] { { _colTenHem, "Tên hẻm" } });
            _fieldList.Add(new string[,] { { _colDoRong, "Độ rộng" } });
            _fieldList.Add(new string[,] { { _colVatLieu, "Vật liệu" } });
            _fieldList.Add(new string[,] { { _colHemPhu, "Mã hẻm chính" } });
            _fieldList.Add(new string[,] { { _colMaDuong, "Mã đường" } });
            _fieldList.Add(new string[,] { { _colThongRaDuong, "Thông ra đường" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
