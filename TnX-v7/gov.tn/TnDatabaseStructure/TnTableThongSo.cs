using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableThongSo : TnGeoDatabaseObject
    {
         private static TnTableThongSo meClass = null;
        private string _colMaThongSo = "mathongso";
        private string _colTenThongSo = "tenthongso";
        private string _colMoTa = "mota";
        private string _colGiaTri = "giatri";
        private string _colGhiChu = "ghichu";

        public static TnTableThongSo GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableThongSo(workspace);
            }
            return meClass;
        }

        private TnTableThongSo(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Thong_So;

            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        public string MA_THONG_SO { get { return _colMaThongSo; } set { _colTenThongSo = value; onColNameChanged(value); } }
        public string TEN_THONG_SO { get { return _colTenThongSo; } set { _colTenThongSo = value; onColNameChanged(value); } }
        public string MO_TA { get { return _colMoTa; } set { _colMoTa = value; onColNameChanged(value); } }
        public string GIA_TRI { get { return _colGiaTri; } set { _colGiaTri = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaThongSo));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colTenThongSo));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMoTa));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGiaTri));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colGhiChu));

        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaThongSo, "Mã thông số" } });
            _fieldList.Add(new string[,] { { _colTenThongSo, "Tên thông số" } });
            _fieldList.Add(new string[,] { { _colGiaTri, "Giá trị" } });
            _fieldList.Add(new string[,] { { _colMoTa, "Mô tả" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
