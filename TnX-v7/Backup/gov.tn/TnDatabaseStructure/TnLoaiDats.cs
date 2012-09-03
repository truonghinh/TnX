using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public class TnLoaiDats
    {
        public static string[] NONG_NGHIEP
        {
            get
            {
                string[] ld = new String[] { "LUC", "LUK", "BHK", "COC", "NHK", "LNC", "LNQ", "LNK", "RSN", "RST", "RSK", "RSM", "TSL", "TSN" };
                return ld;
            }
        }

        public static string[] NN_TRONG_LUA_NUOC
        {
            get
            {
                string[] ld = new String[] { "LUC","LUK" };
                return ld;
            }
        }

        public static string[] NN_TRONG_CAY_HANG_NAM
        {
            get
            {
                string[] ld = new String[] { "BHK","COC","NHK" };
                return ld;
            }
        }
        public static string[] NN_TRONG_CAY_LAU_NAM
        {
            get
            {
                string[] ld = new String[] { "LNC", "LNQ", "LNK" };
                return ld;
            }
        }

        public static string[] NN_RUNG_SAN_XUAT
        {
            get
            {
                string[] ld = new String[] { "RSN", "RST", "RSK","RSM" };
                return ld;
            }
        }

        public static string[] NN_NUOI_TRONG_THUY_SAN
        {
            get
            {
                string[] ld = new String[] { "TSL", "TSN" };
                return ld;
            }
        }

        public static string[] PHI_NONG_NGHIEP
        {
            get
            {
                string[] ld = new String[] { "ODT", "ONT", "SKC", "SKX", "TSC", "TSK" };
                return ld;
            }
        }

        public static string[] PHI_NONG_NGHIEP_DOTHI
        {
            get
            {
                string[] ld = new String[] { "ODT", "SKC", "SKX", "TSC", "TSK" };
                return ld;
            }
        }

        public static string[] PHI_NONG_NGHIEP_NONGTHON
        {
            get
            {
                string[] ld = new String[] { "ONT", "SKC", "SKX", "TSC", "TSK" };
                return ld;
            }
        }



        public static string[] PNN_O_DT
        {
            get
            {
                string[] ld = new String[] { "ODT","TSC","TSK" };
                return ld;
            }
        }

        public static string[] PNN_O_NT
        {
            get
            {
                string[] ld = new String[] { "ONT", "TSC", "TSK" };
                return ld;
            }
        }
        public static string[] PNN_SX_KD
        {
            get
            {
                string[] ld = new String[] { "SKC","SKX" };
                return ld;
            }
        }
    }
}
