using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcDuongChinhNongThon:TnGeoDatabaseObject
    {
        private static TnFcDuongChinhNongThon meClass = null;

        private string _colMaDuong = "maduong";
        private string _colTenDuong = "tenduong";
        private string _colVatLieu = "vatlieu";
        private string _colGhiChu = "ghichu";
        //private string _colGiadat = "giadat";
       
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string TEN_DUONG { get { return _colTenDuong; } set { _colTenDuong = value; onColNameChanged(value); } }
        public string VAT_LIEU { get { return _colVatLieu; } set { _colVatLieu = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        //public string GIA_DAT { get { return _colGiadat; } set { _colGiadat = value; onColNameChanged(value); } }

        public static TnFcDuongChinhNongThon GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcDuongChinhNongThon(workspace);
            }
            return meClass;
        }
        private TnFcDuongChinhNongThon(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Duong_Chinh_NongThon;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            this.setAliasFieldsName();
        }
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colTenDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colVatLieu));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGhiChu));
            //_lstColWithIndex.Add(new TnColWithIndexPair(6, _colGiadat));
        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colVatLieu, "Mã đường" } });
            _fieldList.Add(new string[,] { { _colTenDuong, "Tên đường" } });
            _fieldList.Add(new string[,] { { _colVatLieu, "Vật liệu" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
