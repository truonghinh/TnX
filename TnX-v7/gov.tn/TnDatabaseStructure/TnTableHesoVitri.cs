using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableHesoVitri : TnGeoDatabaseObject
    {
        private static TnTableHesoVitri meClass = null;
        private string _colHesoVitri = "hesovitri";
        private string _colMota = "mota";
        private string _colQuytac = "quytac";
        private string _colCachtinh = "cachtinh";
        private string _colCachghi = "mota_ct";
        private string _colGhichu = "ghichu";
        private string _colCachtinhDongia = "cachtinhdg";

        public static TnTableHesoVitri GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableHesoVitri(workspace);
            }
            return meClass;
        }

        private TnTableHesoVitri(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.He_So_K;
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        public string HE_SO_VI_TRI { get { return _colHesoVitri; } set { _colHesoVitri = value; onColNameChanged(value); } }
        public string MO_TA { get { return _colMota; } set { _colMota = value; onColNameChanged(value); } }
        public string QUY_TAC { get { return _colQuytac; } set { _colQuytac = value; onColNameChanged(value); } }
        public string CACH_TINH { get { return _colCachtinh; } set { _colCachtinh = value; onColNameChanged(value); } }
        public string CACH_GHI { get { return _colCachghi; } set { _colCachghi = value; onColNameChanged(value); } }
        public string CACH_TINH_DON_GIA { get { return _colCachtinhDongia; } set { _colCachtinhDongia = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhichu; } set { _colGhichu = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colHesoVitri));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMota));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colQuytac));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colCachtinh));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colGhichu));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colCachtinhDongia));
            _lstColWithIndex.Add(new TnColWithIndexPair(8, _colCachghi));
        }

        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colHesoVitri, "Hệ số" } });
            _fieldList.Add(new string[,] { { _colMota, "Mô tả" } });
            _fieldList.Add(new string[,] { { _colQuytac, "Quy tắc" } });
            _fieldList.Add(new string[,] { { _colCachtinhDongia, "Công thức tính đơn giá" } });
            _fieldList.Add(new string[,] { { _colCachtinh, "Công thức tính giá" } });
            _fieldList.Add(new string[,] { { _colCachghi, "Mô tả cách tính" } });
            _fieldList.Add(new string[,] { { _colGhichu, "Ghi chú" } });
        }
    }
}
