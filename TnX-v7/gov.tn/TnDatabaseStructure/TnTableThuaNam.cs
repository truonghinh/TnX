using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableThuaNam:TnGeoDatabaseObject
    {
        private static TnTableThuaNam meClass = null;

        private string _colMaThua = "mathua";
        private string _colNam = "nam";
        private string _colMaLoaiDat = "maloaidat";

        public static TnTableThuaNam GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableThuaNam(workspace);
            }
            return meClass;
        }

        private TnTableThuaNam(IWorkspace workspace)
            : base(workspace)
        {
            _name = "thua_nam";

            iniObject();
            InitIndex();
        }

        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string NAM { get { return _colNam; } set { _colNam = value; onColNameChanged(value); } }
        public string MA_LOAI_DAT { get { return _colMaLoaiDat; } set { _colMaLoaiDat = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaLoaiDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colNam));
        }
    }
}
