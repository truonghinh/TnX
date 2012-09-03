using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableUsers:TnGeoDatabaseObject
    {
        private static TnTableUsers meClass = null;
        private string _colQuanTri = "quantri";
        private string _colSuDung = "sudung";
        private string _colUserName = "username";
        private string _colPass = "password";

        public string QUAN_TRI { get { return _colQuanTri; } set { _colQuanTri = value; onColNameChanged(value); } }
        public string SU_DUNG { get { return _colSuDung; } set { _colSuDung = value; onColNameChanged(value); } }
        public string USER_NAME { get { return _colUserName; } set { _colUserName = value; onColNameChanged(value); } }
        public string PASS { get { return _colPass; } set { _colPass = value; onColNameChanged(value); } }

        public static TnTableUsers GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableUsers(workspace);
            }
            return meClass;
        }

        private TnTableUsers(IWorkspace workspace)
            : base(workspace)
        {
            _name = "users";
            //_table = _featureWorkspace.OpenTable(_name);
            iniObject();
            InitIndex();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colUserName));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colPass));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colQuanTri));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colSuDung));
        }
    }
}
