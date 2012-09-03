using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableLoaiXa:TnGeoDatabaseObject
    {
        private static TnTableLoaiXa meClass = null;

        private string _colMaLoaiXa = "maloaixa";
        private string _colTenLoaiXa = "tenloaixa";

        public string MA_LOAI_XA { get { return _colMaLoaiXa; } set { _colMaLoaiXa = value; onColNameChanged(value); } }
        public string TEN_LOAI_XA { get { return _colTenLoaiXa; } set { _colTenLoaiXa = value; onColNameChanged(value); } }

        public static TnTableLoaiXa GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableLoaiXa(workspace);
            }
            return meClass;
        }

        private TnTableLoaiXa(IWorkspace workspace)
            : base(workspace)
        {
            _name = "sde.loaixa";
            //_table = _featureWorkspace.OpenTable(_name);
            iniObject();
            InitIndex();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaLoaiXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colTenLoaiXa));
        }
    }
}
