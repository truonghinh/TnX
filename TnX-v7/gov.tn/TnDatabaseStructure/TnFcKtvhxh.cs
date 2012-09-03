using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcKtvhxh:TnGeoDatabaseObject
    {
        private static TnFcKtvhxh meClass = null;
        private string _colTen = "tenktvhxh";
        private string _colMa = "maktvhxh";
        private string _colGhiChu = "ghichu";

        public string TEN_KTVHXH { get { return _colTen; } set { _colTen = value; onColNameChanged(value); } }
        public string MA_KTVHXH { get { return _colMa; } set { _colMa = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }

        public static TnFcKtvhxh GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcKtvhxh(workspace);
            }
            return meClass;
        }
        private TnFcKtvhxh(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Ktvhxh;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colTen));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMa));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colGhiChu));
        }
        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMa, "Mã KTVHXH" } });
            _fieldList.Add(new string[,] { { _colTen, "Tên KTVHXH" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
