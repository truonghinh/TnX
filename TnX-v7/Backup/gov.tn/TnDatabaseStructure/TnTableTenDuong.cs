using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableTenDuong : TnGeoDatabaseObject
    {
        private static TnTableTenDuong meClass=null;

        private string _colTenDuong = "tenduong";
        private string _colMaDuong = "maduong_";
        private string _colGhiChu = "ghichu";
        private string _colBatDau = "batdau";
        private string _colKetThuc = "ketthuc";


        //public string OID { get { return _colOid; } set { _colOid = value; } }
        public string TEN_DUONG { get { return _colTenDuong; } set { _colTenDuong = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        //public string MA_HUYEN { get { return _colMaHuyen; } set { _colMaHuyen = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string BAT_DAU { get { return _colBatDau; } set { _colBatDau = value; onColNameChanged(value); } }
        public string KET_THUC { get { return _colKetThuc; } set { _colKetThuc = value; onColNameChanged(value); } }

        public static TnTableTenDuong GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableTenDuong(workspace);
            }
            return meClass;
        }
        private TnTableTenDuong(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Ten_Duong;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(1, _colTenDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colBatDau));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colKetThuc));

        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaDuong, "Mã đường" } });
            _fieldList.Add(new string[,] { { _colTenDuong, "Tên đường" } });
            _fieldList.Add(new string[,] { { _colBatDau, "Bắt đầu" } });
            _fieldList.Add(new string[,] { { _colKetThuc, "Kết thúc" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
