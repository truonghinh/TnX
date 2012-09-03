using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcRanhXaPoly:TnGeoDatabaseObject
    {
        private static TnFcRanhXaPoly meClass = null;

        private string _colMaXa = "maxa";
        private string _colTenXa = "tenxa";
        private string _colMaLoaiXa = "loaixa";
        private string _colMaHuyen = "mahuyen_";
        private string _colLoaiDoThi = "dothi";
        private string _colGhiChu = "ghichu";
       
        public string MA_XA { get { return _colMaXa; } set { _colMaXa = value; onColNameChanged(value); } }
        public string TEN_XA { get { return _colTenXa; } set { _colTenXa = value; onColNameChanged(value); } }
        public string MA_LOAI_XA { get { return _colMaLoaiXa; } set { _colMaLoaiXa = value; onColNameChanged(value); } }
        public string MA_HUYEN { get { return _colMaHuyen; } set { _colMaHuyen = value; onColNameChanged(value); } }
        public string LOAI_DO_THI { get { return _colLoaiDoThi; } set { _colLoaiDoThi = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public static TnFcRanhXaPoly GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcRanhXaPoly(workspace);
            }
            return meClass;
        }
        private TnFcRanhXaPoly(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Ranh_Xa_Poly;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colTenXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMaLoaiXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colMaHuyen));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colLoaiDoThi));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colGhiChu));
        }
        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaXa, "Mã xã" } });
            _fieldList.Add(new string[,] { { _colTenXa, "Tên xã" } });
            _fieldList.Add(new string[,] { { _colMaLoaiXa, "Loại xã" } });
            _fieldList.Add(new string[,] { { _colLoaiDoThi, "Loại đô thị" } });
            _fieldList.Add(new string[,] { { _colMaHuyen, "Mã huyện" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
