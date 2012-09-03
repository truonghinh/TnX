using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableLoaiDat:TnGeoDatabaseObject
    {
        private static TnTableLoaiDat meClass = null;
        private string _colMaLoaiDat = "maloaidat";
        private string _colTenLoaiDat = "tenloaidat";

        public static TnTableLoaiDat GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableLoaiDat(workspace);
            }
            return meClass;
        }

        private TnTableLoaiDat(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Loai_Dat;

            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        public string MA_LOAI_DAT { get { return _colMaLoaiDat; } set { _colMaLoaiDat = value; onColNameChanged(value); } }
        public string TEN_LOAI_DAT { get { return _colTenLoaiDat; } set { _colTenLoaiDat = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaLoaiDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colTenLoaiDat));
        }
    }
}
