using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFeatureClassName:ITnFeatureClassName
    {
        private IWorkspace _workspace;
        #region Fields
        private static TnFcThua _fcThua;
        private static TnFcDuong _fcDuong;
        private static TnFcHem _fcHem;
        private static TnFcRanhXaPoly _fcXaPl;
        private static TnFcRanhXaLine _fcXaLn;
        private static TnFcKtvhxh _fcKtvhxh;
        private static TnFcThuaGiaDat _fcThuaGiaDat;
        private static TnFcThuaGiaDatDraft _fcThuaGiaDatDraft;
        private static TnFcTrungTamXa _fcTrungTamXa;
        private static TnFcDuongChinhNongThon _fcDuongChinhNt;
        private static TnFcGiaDatHem _fcGiaDatHem;
        private static TnFcGiaDatHemPhu _fcGiaDatHemPhu;
        #region Cac layer duoc dung de tinh toan
        //private static string tn_thua = "tn_thua";
        //private static string sde_tn_thua = "sde.tn_thua";
        //private static string tn_duong = "thixa_duong";
        //private static string sde_tn_duong = "sde.tn_duong";
        //private static string tn_duong_giadat = "tn_duong_giadat";
        //private static string sde_tn_duong_giadat = "sde.tn_duong_giadat";
        //private static string tn_hem = "thixa_hem";
        //private static string sde_tn_hem = "sde.tn_hem";
        //private static string tn_xa = "thixa_xapoly";
        //private static string sde_tn_xa = "sde.thixa_xapoly";

        //private static string _duong = "thixa_duong";
        
        //private static string _duong_buffer_1m = "thixa_duong_buffer_1m";
        //private static string _duong_buffer_50m = "thixa_duong_buffer_50m";
        //private static string _duong_buffer_100m = "thixa_duong_buffer_100m";
        //private static string _duong_buffer_200m = "thixa_duong_buffer_200m";
        

        //private static string _thua = "thixa_thua";

        //private static string _hem = "thixa_hem";
        //private static string _hem_buffer_1m = "thixa_hem_buffer_1m";
        //private static string _hem_layer_buffer_1m = "thixa_hem_layer_buffer_1m";
        //private static string _hem_buffer_1m_crt_frm_layer = "thixa_hem_buffer_1m_selected";

        #endregion Cac layer duoc dung de tinh toan

        #region Cac table
        //private static string _thixa_xapoly = "thixa_xapoly";

        #endregion

        #region Cac featureClass sinh ra trong qua trinh tinh toan
        //private static string hem_buffer_1m = "hem_buffer_1m";
        //private static string hem_layer_buffer_1m = "hem_layer_buffer_1m";
        //private static string hem_buffer_1m_crt_frm_layer = "hem_buffer_1m_selected";
        #endregion Cac featureClass sinh ra trong qua trinh tinh toan

        #endregion Fields

        #region Properties

        #region Cac table

        //public static string THIXA_XAPOLY
        //{
        //    get { return _thixa_xapoly; }
        //    set { if (_thixa_xapoly == value) return; _thixa_xapoly = value; }
        //}
        #endregion

        #region Cac layer duoc dung de tinh toan
        //public static string THUA { get { return _thua; } set { _thua = value; } }
        //public static string SDE_THUA { get { return "sde." + _thua; } set { sde_tn_thua = value; _thua = getName(sde_tn_thua); } }
        //public static string DUONG { get { return _duong; } set { _duong = value; } }

        //public static string SDE_DUONG { get { return "sde." + tn_duong; } set { sde_tn_duong = value; tn_duong = getName(sde_tn_duong); } }
        //public static string DUONG_GIADAT { get { return tn_duong_giadat; } set { tn_duong_giadat = value; } }
        //public static string SDE_DUONG_GIADAT { get { return "sde." + tn_duong_giadat; } set { sde_tn_duong_giadat = value; tn_duong_giadat = getName(sde_tn_duong_giadat); } }
        //public static string HEM { get { return tn_hem; } set { tn_hem = value; } }
        //public static string SDE_HEM { get { return "sde." + tn_hem; } set { sde_tn_hem = value; tn_hem = getName(sde_tn_hem); } }
        //public static string XA { get { return tn_xa; } set { tn_xa = value; } }
        //public static string SDE_XA { get { return "sde." + tn_xa; } set { sde_tn_xa = value; tn_xa = getName(sde_tn_xa); } }
        #endregion Cac layer duoc dung de tinh toan
        
        #region Cac featureClass sinh ra trong qua trinh tinh toan

        //public static string DUONG_BUFFER_1M { get { return _duong_buffer_1m; } set { _duong_buffer_1m = value; } }
        //public static string DUONG_BUFFER_50M { get { return _duong_buffer_50m; } set { _duong_buffer_50m = value; } }
        //public static string DUONG_BUFFER_100M { get { return _duong_buffer_100m; } set { _duong_buffer_100m = value; } }
        //public static string DUONG_BUFFER_200M { get { return _duong_buffer_200m; } set { _duong_buffer_200m = value; } }

        //public static string HEM_BUFFER_1M { get { return _hem_buffer_1m; } set { _hem_buffer_1m = value; } }
        //public static string HEM_LAYER_BUFFER_1M { get { return _hem_layer_buffer_1m; } set { _hem_layer_buffer_1m = value; } }
        //public static string HEM_BUFFER_1M_CREATED_FROM_LAYER { get { return _hem_buffer_1m_crt_frm_layer; } set { _hem_buffer_1m_crt_frm_layer = value; } }
        #endregion Cac featureClass sinh ra trong qua trinh tinh toan

        #endregion Properties

        TnFcDuong ITnFeatureClassName.FC_DUONG { get { _fcDuong = TnFcDuong.GetMe(_workspace); return _fcDuong; } }
        TnFcThua ITnFeatureClassName.FC_THUA { get { _fcThua = TnFcThua.GetMe(_workspace); return _fcThua; } }
        TnFcHem ITnFeatureClassName.FC_HEM { get { _fcHem = TnFcHem.GetMe(_workspace); return _fcHem; } }
        TnFcRanhXaPoly ITnFeatureClassName.FC_RANH_XA_POLY { get { _fcXaPl = TnFcRanhXaPoly.GetMe(_workspace); return _fcXaPl; } }
        TnFcRanhXaLine ITnFeatureClassName.FC_RANH_XA_LINE { get { _fcXaLn = TnFcRanhXaLine.GetMe(_workspace); return _fcXaLn; } }
        TnFcKtvhxh ITnFeatureClassName.FC_KTVHXH { get { _fcKtvhxh = TnFcKtvhxh.GetMe(_workspace); return _fcKtvhxh; } }
        TnFcThuaGiaDat ITnFeatureClassName.FC_THUA_GIADAT { get { _fcThuaGiaDat = TnFcThuaGiaDat.GetMe(_workspace); return _fcThuaGiaDat; } }
        TnFcThuaGiaDatDraft ITnFeatureClassName.FC_THUA_GIADAT_DRAFT { get { _fcThuaGiaDatDraft = TnFcThuaGiaDatDraft.GetMe(_workspace); return _fcThuaGiaDatDraft; } }
        TnFcTrungTamXa ITnFeatureClassName.FC_TRUNG_TAM_XA { get { _fcTrungTamXa = TnFcTrungTamXa.GetMe(_workspace); return _fcTrungTamXa; } }
        TnFcDuongChinhNongThon ITnFeatureClassName.FC_DUONG_CHINH_NONG_THON { get { _fcDuongChinhNt = TnFcDuongChinhNongThon.GetMe(_workspace); return _fcDuongChinhNt; } }
        TnFcGiaDatHem ITnFeatureClassName.FC_GIA_DAT_HEM { get { _fcGiaDatHem = TnFcGiaDatHem.GetMe(_workspace); return _fcGiaDatHem; } }
        TnFcGiaDatHemPhu ITnFeatureClassName.FC_GIA_DAT_HEM_PHU { get { _fcGiaDatHemPhu = TnFcGiaDatHemPhu.GetMe(_workspace); return _fcGiaDatHemPhu; } }
        #region Methods
        private static string getName(string sde_name)
        {
            string name = String.Empty;
            string[] array = sde_name.Split(',');
            name = array.GetValue(1).ToString();
            return name;
        }
        #endregion Methods

        public TnFeatureClassName(IWorkspace workspace)
        {
            _workspace = workspace;
            //_fcThua = TnFcThua.GetMe(workspace);
            //_fcDuong = TnFcDuong.GetMe(workspace);
            //_fcXa = TnFcXa.GetMe(workspace);
            //_fcKtvhxh = TnFcKtvhxh.GetMe(workspace);
            //_fcHem = TnFcHem.GetMe(workspace);
            //_fcThuaGiaDat = TnFcThuaGiaDat.GetMe(workspace);
        }
    }
}
