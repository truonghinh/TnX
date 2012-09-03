using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcRanhXaLine : TnGeoDatabaseObject
    {
        private static TnFcRanhXaLine meClass = null;

        private string _colMaRanhXa = "maxa";
        private string _colMaXa1 = "maxa1";
        private string _colMaXa2 = "maxa2";
        private string _colGhiChu = "ghichu";
       
        public string MA_RANH_XA { get { return _colMaRanhXa; } set { _colMaRanhXa = value; onColNameChanged(value); } }
        public string MA_XA_1 { get { return _colMaXa1; } set { _colMaXa1 = value; onColNameChanged(value); } }
        public string MA_XA_2 { get { return _colMaXa2; } set { _colMaXa2 = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public static TnFcRanhXaLine GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcRanhXaLine(workspace);
            }
            return meClass;
        }
        private TnFcRanhXaLine(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Ranh_Xa_Line;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaRanhXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaXa1));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMaXa2));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colGhiChu));
        }
        protected override void setAliasFieldsName()
        {
            _fieldList.Add(new string[,] { { _colMaRanhXa, "Mã ranh xã" } });
            _fieldList.Add(new string[,] { { _colMaXa1, "Mã xã 1" } });
            _fieldList.Add(new string[,] { { _colMaXa2, "Mã xã 2" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
