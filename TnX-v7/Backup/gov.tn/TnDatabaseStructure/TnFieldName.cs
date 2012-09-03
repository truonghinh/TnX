using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public class TnFieldName
    {
        
        #region Fields

        //fields cua bang hem
        #region Hem
        private static string hem_sodgc = "sodgc"; //so duong chinh
        private static string hem_sohmc = "sohmc"; //so hem chinh
        private static string hem_tendgc = "tendgc"; //ten duong chinh
        private static string hem_tenhmc = "tenhmc"; //ten hem chinh
        private static string hem_hemchinh = "hemchinh";//hem chinh: 1-hem chinh; 2-hem phu
        private static string hem_mahem = "mahem"; //mahem
        private static string hem_tenhem = "tenhem"; //ten hem
        private static string hem_giadathem = "giadat"; //giadat cua hem
        private static string hem_ghichuhem = "ghichu";//ghi chu
        private static string hem_maduongh = "maduong"; //ma duong
        private static string hem_tenduongh = "tenhem";//ten hem
        private static string hem_madgc = "hemphu"; //ma duong chinh
        #endregion Hem

        //fields cua bang duong
        #region Duong
        private static string duong_giadatduong = "giadat"; //giadat cua duong
        private static string duong_tenduong = "tenduong"; //ten duong
        private static string duong_maduong = "maduong"; //ma duong
        #endregion Duong

        //fields cua bang thua
        #region Thua
        private static string thua_somattien = "somattien";//so mat tien
        private static string thua_dongia = "dongia"; //don gia
        private static string thua_giadatthua = "giadat"; //giadat
        private static string thua_mahemt = "mahem";//ma hem
        private static string thua_maduongt = "maduong"; //ma duong
        private static string thua_soto = "soto"; //so to
        private static string thua_sothua = "sothua";//so thua
        private static string thua_loaidat = "loaidat"; //loaidat
        private static string thua_tenchu = "tenchu"; //ten chu
        private static string thua_diachi = "diachi"; //diachi
        private static string thua_khuvuc = "khuvuc";//khuvuc
        private static string thua_dientichtong = "dientich"; //dientich
        private static string thua_dientichpl = "dientichpl";//dien tich pl
        private static string thua_locked = "locked"; //locked
        private static string thua_kdat = "kdat";//kdat
        private static string thua_socachtinh = "socachtinh";//so cach tinh
        private static string thua_cachtinh = "cachtinh";//cach tinh
        private static string thua_ghichuthua = "ghichu"; //ghi chu
        private static string thua_dientichmt = "dientich1"; //dien tich cua phan thua mat tien
        private static string thua_dientichsau50 = "dientich2"; //dien tich cua phan thua sau mat tien 50m
        private static string thua_giadatmt = "giadat1";//gia dat cua phan thua mat tien
        private static string thua_giadatsau50 = "giadat2"; //giadat cua phan thua sau mattien 50m
        private static string thua_somathem = "somathem"; //so mat hem
        #endregion Thua

        #endregion Fields

        #region Properties

        #region Thua
        public static string THUA_SO_MAT_TIEN { get { return thua_somattien; } }
        public static string THUA_SO_MAT_HEM { get { return thua_somathem; } }
        public static string THUA_DON_GIA { get { return thua_dongia; } }
        public static string THUA_GIA_DAT { get { return thua_giadatthua; } }
        public static string THUA_MA_HEM { get { return thua_mahemt; } }
        public static string THUA_MA_DUONG { get { return thua_maduongt; } }
        public static string THUA_SO_TO { get { return thua_soto; } }
        public static string THUA_SO_THUA { get { return thua_sothua; } }
        public static string THUA_LOAI_DAT { get { return thua_loaidat; } }
        public static string THUA_TEN_CHU { get { return thua_tenchu; } }
        public static string THUA_DIA_CHI { get { return thua_diachi; } }
        public static string THUA_KHU_VUC { get { return thua_khuvuc; } }
        public static string THUA_DIEN_TICH_TONG { get { return thua_dientichtong; } }
        public static string THUA_DIEN_TICH_PL { get { return thua_dientichpl; } }
        public static string THUA_LOCKED { get { return thua_locked; } }
        public static string THUA_SO_CACH_TINH { get { return thua_socachtinh; } }
        public static string THUA_CACH_TINH { get { return thua_cachtinh; } }
        public static string THUA_GHI_CHU { get { return thua_ghichuthua; } }
        public static string THUA_K_DAT { get { return thua_kdat; } }
        public static string THUA_DIEN_TICH_MAT_TIEN { get { return thua_dientichmt; } }
        public static string THUA_DIEN_TICH_SAU_50M { get { return thua_dientichsau50; } }
        public static string THUA_GIA_DAT_MAT_TIEN { get { return thua_giadatmt; } }
        public static string THUA_GIA_DAT_SAU_50M { get { return thua_giadatsau50; } }
        #endregion Thua

        #region Duong
        public static string DUONG_GIA_DAT { get { return duong_giadatduong; } }
        public static string DUONG_TEN_DUONG { get { return duong_tenduong; } }
        public static string DUONG_MA_DUONG { get { return duong_maduong; } }
        #endregion Duong

        #region Hem
        public static string HEM_GIA_DAT { get { return hem_giadathem; } }
        public static string HEM_SO_DUONG_CHINH { get { return hem_sodgc; } }
        public static string HEM_SO_HEM_CHINH { get { return hem_sohmc; } }
        public static string HEM_TEN_DUONG_CHINH { get { return hem_tendgc; } }
        public static string HEM_MA_DUONG_CHINH { get { return hem_madgc; } }
        public static string HEM_TEN_HEM_CHINH { get { return hem_tenhmc; } }
        public static string HEM_HEM_CHINH { get { return hem_hemchinh; } }
        public static string HEM_MA_HEM { get { return hem_mahem; } }
        public static string HEM_TEN_HEM { get { return hem_tenhem; } }
        public static string HEM_GHI_CHU { get { return hem_ghichuhem; } }
        #endregion Hem

        #endregion Properties
    }
}
