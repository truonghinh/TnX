using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcTrungTamXa:TnGeoDatabaseObject
    {
        private static TnFcTrungTamXa meClass = null;

        private string _colMaTtx = "mattx";
        private string _colTenTtx = "tenttx";
        private string _colMaXa = "maxa_";
        private string _colGhiChu = "ghichu";
        //private string _colGiadat = "giadat";
       
        public string MA { get { return _colMaTtx; } set { _colMaTtx = value; onColNameChanged(value); } }
        public string TEN_TTX { get { return _colTenTtx; } set { _colTenTtx = value; onColNameChanged(value); } }
        public string MA_XA { get { return _colMaXa; } set { _colMaXa = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        //public string GIA_DAT { get { return _colGiadat; } set { _colGiadat = value; onColNameChanged(value); } }

        public static TnFcTrungTamXa GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcTrungTamXa(workspace);
            }
            return meClass;
        }
        private TnFcTrungTamXa(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Trung_Tam_Xa;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            this.setAliasFieldsName();
        }
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaTtx));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colTenTtx));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMaXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGhiChu));
            //_lstColWithIndex.Add(new TnColWithIndexPair(6, _colGiadat));
        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaXa, "Mã TT xã" } });
            _fieldList.Add(new string[,] { { _colTenTtx, "Tên TT xã" } });
            _fieldList.Add(new string[,] { { _colMaXa, "Mã xã" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
