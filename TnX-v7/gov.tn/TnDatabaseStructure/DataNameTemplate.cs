using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public class DataNameTemplate
    {
        private static string _dbName="sde";
        private static string _shema = "sde";
        private static string _prefix = "sde.sde";
        public static string DbName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;
                _prefix = _dbName+"." + _shema;
            }
        }
        public static string Schema
        {
            get { return _shema; }
            set
            {
                _shema = value;
                _prefix = _dbName + "." + _shema;
            }
        }
        public static string Thua_Clip_50m
        {
            get { return _prefix+".thixa_thua_clip_50m"; }
        }
        public static string Thua_Clip_
        {
            get { return _prefix+".thixa_thua_clip_"; }
        }
        public static string Thua_Erase_
        {
            get { return _prefix + ".thixa_thua_erase_"; }
        }
        public static string Duong_Buffer_50m
        {
            get { return _prefix + ".thixa_duong_buffer_50"; }
        }
        public static string Duong_Buffer_
        {
            get { return _prefix + ".thixa_duong_buffer_"; }
        }
        public static string Hem_Buffer_
        {
            get { return _prefix + ".thixa_hem_buffer_"; }
        }
        public static string Duong_Buffer_100m
        {
            get { return _prefix + ".thixa_duong_buffer_100"; }
        }
        public static string Thua
        {
            get { return _prefix + ".thixa_thua"; }
        }

        public static string Duong
        {
            get { return _prefix + ".thixa_duong"; }
        }

        public static string Duong_Chinh_NongThon
        {
            get { return _prefix + ".thixa_duongchinh_nongthon"; }
        }

        public static string Ten_Duong
        {
            get { return _prefix + ".bangtenduong"; }
        }

        public static string Duong_Lich_Su
        {
            get { return _prefix + ".thixa_duong_lich_su"; }
        }

        public static string Gia_Dat_Duong
        {
            get { return _prefix + ".thixa_giadatduong"; }
        }

        public static string Hem
        {
            get { return _prefix + ".thixa_hem"; }
        }

        public static string Hem_Lich_Su
        {
            get { return _prefix + ".thixa_hem_lich_su"; }
        }

        public static string Thua_Gia_Dat
        {
            get { return _prefix + ".thixa_thua_giadat"; }
        }
        public static string Thua_Gia_Dat_Draft
        {
            get { return _prefix + ".thixa_thua_giadat_draft"; }
        }

        public static string Thua_Gia_Dat_Giap_Ranh
        {
            get { return _prefix + ".thua_giadat_pnn_nongthon"; }
        }

        public static string Thua_Gia_Dat_Nn
        {
            get { return _prefix + ".thua_giadat_nn"; }
        }

        public static string Thua_Lich_Su
        {
            get { return _prefix + ".thixa_thua_lich_su"; }
        }

        public static string Ranh_Xa_Line
        {
            get { return _prefix + ".thixa_ranhxa_line"; }
        }

        public static string Ranh_Xa_Poly
        {
            get { return _prefix + ".thixa_ranhxa_poly"; }
        }

        public static string Loai_Dat
        {
            get { return _prefix + ".bangloaidat"; }
        }

        public static string Gia_Dat_Pnn_Nongthon
        {
            get { return _prefix + ".giadat_pnn_nongthon"; }
        }

        public static string Vitri_Dat_Pnn_Nongthon
        {
            get { return _prefix + ".vitri_dat_pnn_nongthon"; }
        }

        public static string Gia_Dat_Nongnghiep
        {
            get { return _prefix + ".giadat_nongnghiep"; }
        }

        public static string Vitri_Dat_Nongnghiep
        {
            get { return _prefix + ".vitri_dat_nongnghiep"; }
        }

        public static string He_So_K
        {
            get { return _prefix + ".thixa_quydinh_heso_vitri"; }
        }

        public static string Thong_So
        {
            get { return _prefix + ".thixa_thongso"; }
        }

        public static string Ap_Dung_Thong_So
        {
            get { return _prefix + ".apdung_thongso"; }
        }

        public static string Trung_Tam_Xa
        {
            get { return _prefix + ".thixa_trungtam_xa"; }
        }

        public static string Khu_Dancu_Taptrung
        {
            get { return _prefix + ".thixa_khu_dc_taptrung"; }
        }

        public static string Ktvhxh
        {
            get { return _prefix + ".thixa_ktvhxh"; }
        }

        public static string Quydinh_Ktvhxh
        {
            get { return _prefix + ".thixa_quydinh_ktvhxh"; }
        }

        public static string Apdung_Quydinh_Ktvhxh
        {
            get { return _prefix + ".apdung_quydinh_ktvhxh"; }
        }

        public static string Gia_Hem
        {
            get { return _prefix + ".thixa_giadathem"; }
        }

        public static string Gia_Hem_Phu
        {
            get { return _prefix + ".thixa_giadathemphu"; }
        }

        public static string Hem_Clip_
        {
            get { return _prefix + ".thixa_hem_clip_"; }
        }
        public static string Hem_Erase_
        {
            get { return _prefix + ".thixa_hem_erase_"; }
        }
        public static string INFORMATION_SCHEMA_TABLES
        {
            get { return _dbName + ".INFORMATION_SCHEMA.TABLES"; }
        }
        public static string INFORMATION_SCHEMA_COLUMNS
        {
            get { return _dbName + ".INFORMATION_SCHEMA.COLUMNS"; }
        }
            public static string SDE_LAYERS
        {
            get { return _prefix + ".SDE_layers"; }
        }
    }
}
