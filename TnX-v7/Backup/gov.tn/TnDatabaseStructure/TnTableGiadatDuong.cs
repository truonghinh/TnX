using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableGiadatDuong:TnGeoDatabaseObject
    {
        private static TnTableGiadatDuong meClass = null;

        private string _colMaDuong = "maduong_";
        private string _colNam = "namapdung";
        private string _colLoaiDuong = "loaiduong";
        private string _colBatDau = "batdau";
        private string _colKetThuc = "ketthuc";
        private string _colGiaDat = "giadat";
        private string _colGhiChu = "ghichu";

        public static TnTableGiadatDuong GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableGiadatDuong(workspace);
            }
            return meClass;
        }

        private TnTableGiadatDuong(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Gia_Dat_Duong;

            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string NAM { get { return _colNam; } set { _colNam = value; onColNameChanged(value); } }
        public string LOAI_DUONG { get { return _colLoaiDuong; } set { _colLoaiDuong = value; onColNameChanged(value); } }
        public string BAT_DAU { get { return _colBatDau; } set { _colBatDau = value; onColNameChanged(value); } }
        public string KET_THUC { get { return _colKetThuc; } set { _colKetThuc = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            //_lstColWithIndex.Add(new TnColWithIndexPair(2, _colLoaiDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaDuong));
            //_lstColWithIndex.Add(new TnColWithIndexPair(4, _colNam));
            //_lstColWithIndex.Add(new TnColWithIndexPair(5, _colBatDau));
            //_lstColWithIndex.Add(new TnColWithIndexPair(6, _colKetThuc));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(8, _colGhiChu));
        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colGiaDat, "Giá đất" } });
            _fieldList.Add(new string[,] { { _colMaDuong, "Mã đường" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
