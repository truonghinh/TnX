using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFcThuaGiadatGiapranh : TnGeoDatabaseObject
    {
        private static TnFcThuaGiadatGiapranh meClass = null;

        private string _colMaThua = "mathua";
        private string _colMaRanhXa = "maranhxa";
        private string _colMaXa1 = "maxa1";
        private string _colMaXa2 = "maxa2";
        private string _colGiadat = "giadat";
       
        public string MA_THUA { get { return _colMaThua; } set { _colMaThua = value; onColNameChanged(value); } }
        public string MA_RANH_XA { get { return _colMaRanhXa; } set { _colMaRanhXa = value; onColNameChanged(value); } }
        public string MA_XA_1 { get { return _colMaXa1; } set { _colMaXa1 = value; onColNameChanged(value); } }
        public string MA_XA_2 { get { return _colMaXa2; } set { _colMaXa2 = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiadat; } set { _colGiadat = value; onColNameChanged(value); } }

        public static TnFcThuaGiadatGiapranh GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnFcThuaGiadatGiapranh(workspace);
            }
            return meClass;
        }
        private TnFcThuaGiadatGiapranh(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Thua_Gia_Dat_Giap_Ranh;
            //_featureClass = _featureWorkspace.OpenFeatureClass(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }
        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaThua));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaRanhXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colMaXa1));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colMaXa2));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colGiadat));
        }
    }
}
