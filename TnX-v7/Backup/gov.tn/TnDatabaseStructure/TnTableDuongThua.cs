using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableDuongThua:TnGeoDatabaseObject
    {
        private static TnTableDuongThua meClass = null;
        private string _colMaThua = "mathua";
        private string _colMaDuong = "maduong";
        private string _colNam = "nam";
        private string _colNamThua = "nam_thua";
        private string _colQuanHe = "quanhe";
        //private IWorkspace _workspace;
        //private IFeatureWorkspace _featureWorkspace;

        public static TnTableDuongThua GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableDuongThua(workspace);
            }
            return meClass;
        }

        private TnTableDuongThua(IWorkspace workspace)
            : base(workspace)
        {
            _name = "sde.duong_thua";

            iniObject();
            InitIndex();
        }

        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string MA_DUONG { get { return _colMaDuong; } set { _colMaDuong = value; onColNameChanged(value); } }
        public string NAM { get { return _colNam; } set { _colNam = value; onColNameChanged(value); } }
        public string NAM_THUA { get { return _colNamThua; } set { _colNamThua = value; onColNameChanged(value); } }
        public string QUAN_HE { get { return _colQuanHe; } set { _colQuanHe = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaDuong));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colNam));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colNamThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colQuanHe));
        }
    }
}
