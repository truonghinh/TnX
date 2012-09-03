using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcGiaDatHemPhu : TnGeoDatabaseObject
    {
        private static TnFcGiaDatHemPhu meClass = null;
        private string _colLocked = "khoagia";
        private string _colGhiChu = "ghichu";
        private string _colGiaDat = "giadat";
        private string _colMaHem = "mahem_";
        private string _colHeSo = "vitri";
        private string _colMaHemChinh = "mahemchinh_";
        private string _colMaDuong = "maduong_";

        public string LOCKED { get { return _colLocked; } set { _colLocked = value; onColNameChanged(value); } }
        public string MA_HEM { get { return _colMaHem; } set { _colMaHem = value; onColNameChanged(value); } }
        public string MA_HEM_CHINH { get { return _colMaHemChinh; } set { _colMaHemChinh = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }
        public string HE_SO { get { return _colHeSo; } set { _colHeSo = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }

        public static TnFcGiaDatHemPhu GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcGiaDatHemPhu(workspace);
            }
            return meClass;
        }
        private TnFcGiaDatHemPhu(IWorkspace workspace)
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

            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaHem));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colLocked));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colMaHemChinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colHeSo));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colMaDuong));
        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaHem, "Mã hẻm" } });

            _fieldList.Add(new string[,] { { _colGiaDat, "Giá đất" } });
            _fieldList.Add(new string[,] { { _colHeSo, "Hệ số" } });
            _fieldList.Add(new string[,] { { _colLocked, "Khóa giá" } });
            _fieldList.Add(new string[,] { { _colMaHemChinh, "Mã hẻm chính" } });
            _fieldList.Add(new string[,] { { _colMaDuong, "Mã đường" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}

