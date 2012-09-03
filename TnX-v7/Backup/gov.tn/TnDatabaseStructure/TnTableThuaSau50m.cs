using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableThuaSau50m:TnGeoDatabaseObject
    {
        private static TnTableThuaSau50m meClass = null;

        private string _colStt = "stt";
        private string _colMaThua = "mathua";
        private string _colNam = "nam";
        private string _colNamThua = "nam_thua";
        private string _colKhoangCach = "khoangcach";
        private string _colPhanTram = "phantram";
        private string _colDienTich = "dientich";

        public static TnTableThuaSau50m GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableThuaSau50m(workspace);
            }
            return meClass;
        }

        private TnTableThuaSau50m(IWorkspace workspace)
            : base(workspace)
        {
            _name = "thua_sau_50m";

            iniObject();
            InitIndex();
        }

        public string STT { get { return _colStt; } set { _colStt = value; onColNameChanged(value); } }
        public string NAM_THUA { get { return _colNamThua; } set { _colNamThua = value; onColNameChanged(value); } }
        public string DIENTICH { get { return _colDienTich; } set { _colDienTich = value; onColNameChanged(value); } }
        public string KHOANG_CACH { get { return _colKhoangCach; } set { _colKhoangCach = value; onColNameChanged(value); } }
        public string PHAN_TRAM { get { return _colPhanTram; } set { _colPhanTram = value; onColNameChanged(value); } }
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string NAM { get { return _colNam; } set { _colNam = value; onColNameChanged(value); } }
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colStt));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colNamThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colDienTich));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colKhoangCach));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colPhanTram));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(8, _colNam));
        }

    }
}
