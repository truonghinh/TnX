using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
//using TnLibConst.Database;
using gov.tn.TnDatabaseStructure;

namespace TNPro.Check
{
    class TnCheck
    {
        private static TnCheck meClass = null;
        private static bool _connectToDatabase = false;
        private static IWorkspace _workspace;
        private ITnTableName _tblName;
        private ITnFeatureClassName _fcName;
        private List<string> _lstLackLayer=new List<string>();
        private List<string> _lstFullLayer = new List<string>();

        public bool ConnectToDatabase
        {
            get { return _connectToDatabase; }
            set { _connectToDatabase = value; }
        }

        private TnCheck() { }

        public static TnCheck GetMe()
        {
            if (meClass == null)
            {
                meClass = new TnCheck();
            }
            return meClass;
        }

        public void SetWorkspace(IWorkspace workspace)
        {
            _workspace = workspace;
            _tblName = new TnTableName(workspace);
            _fcName = new TnFeatureClassName(workspace);
        }

        public void CheckDatabase4Calc()
        {
            IFeatureWorkspace fw = (IFeatureWorkspace)_workspace;
            //kiem tra cac lop can thiet cho viec tinh toan
            //featureclass: thua,duong,hem,ktvhxh,xa
            //table: giadatduong,tgd_pnn_dt,tgd_pnn_nt,tgd_nn,
            //loaidat,loaixa,thua_nam,duong_thua,giadatnongnghiep,
            //hem_thua_cs,thua_sau50m,giadatonongthon
            _lstFullLayer.Add(_fcName.FC_THUA.NAME);
            _lstFullLayer.Add(_fcName.FC_DUONG.NAME);
            _lstFullLayer.Add(_fcName.FC_HEM.NAME);
            _lstFullLayer.Add(_fcName.FC_RANH_XA_POLY.NAME);
            _lstFullLayer.Add(_fcName.FC_KTVHXH.NAME);
            _lstFullLayer.Add(_tblName.DUONG_THUA.NAME);
            _lstFullLayer.Add(_tblName.GIA_DAT_NONGNGHIEP.NAME);
            _lstFullLayer.Add(_tblName.LOAI_XA.NAME);
            _lstFullLayer.Add(_tblName.THUA_GIADAT_NN.NAME);
            _lstFullLayer.Add(_tblName.THUA_GIADAT_PNN_DOTHI.NAME);
            //_lstFullLayer.Add(_tblName.DUONG_THUA.NAME);
            //_lstFullLayer.Add(_tblName.DUONG_THUA.NAME);
            //_lstFullLayer.Add(_tblName.DUONG_THUA.NAME);
            //_lstFullLayer.Add(_tblName.DUONG_THUA.NAME);
            IFeatureClass fc=null;
            foreach (string s in _lstFullLayer)
            {
                try
                {
                    fc = fw.OpenFeatureClass(s);
                    if (fc == null)
                    {
                        _lstLackLayer.Add(s);
                    }
                }
                catch
                {
                    _lstLackLayer.Add(s);
                }
            }
        }

        public List<string> GetLackLayers()
        {
            return _lstLackLayer;
        }

        public List<string> GetFullLayers()
        {
            return _lstFullLayer;
        }
    }
}
