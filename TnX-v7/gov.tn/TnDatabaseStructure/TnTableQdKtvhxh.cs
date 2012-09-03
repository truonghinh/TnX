using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableQdKtvhxh:TnGeoDatabaseObject
    {
        private static TnTableQdKtvhxh meClass = null;

        private string _colMaKtvhxh = "maktvhxh";
        private string _colKhuVuc = "makhuvuc";
        private string _colViTri = "vitri";

        public string MA_KTVHXH { get { return _colMaKtvhxh; } set { _colMaKtvhxh = value; onColNameChanged(value); } }
        public string KHU_VUC { get { return _colKhuVuc; } set { _colKhuVuc = value; onColNameChanged(value); } }
        public string VI_TRI { get { return _colViTri; } set { _colViTri = value; onColNameChanged(value); } }

        public static TnTableQdKtvhxh GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableQdKtvhxh(workspace);
            }
            return meClass;
        }

        private TnTableQdKtvhxh(IWorkspace workspace)
            : base(workspace)
        {
            _name = "sde.quydinh_ktvhxh";
            //_table = _featureWorkspace.OpenTable(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaKtvhxh));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colKhuVuc));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colViTri));
        }
    }
}
