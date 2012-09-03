using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.tn.config
{
    public class TnTasks
    {
        //dat nong nghiep
        public static readonly int tinhThuaNnVt1TronThua = 1;
        public static readonly int tinhThuaNnVt1Hon100m = 2;
        public static readonly int tinhThuaNnVt2Th1TronThua = 3;
        public static readonly int tinhThuaNnVt2Th1Hon100m = 4;
        public static readonly int tinhThuaNnVt2Th2TronThua = 5;
        public static readonly int tinhThuaNnVt2Th2Hon100m = 6;
        public static readonly int tinhThuaNnVt3 = 7;

        //dat phi nong nghiep nong thon
        public static readonly int tinhThuaPnnNtVt1Kv1 = 8;
        public static readonly int tinhThuaPnnNtVt2Kv1 = 9;
        public static readonly int tinhThuaPnnNtVt3Kv1 = 10;
        public static readonly int tinhThuaPnnNtVt1Kv2 = 11;
        public static readonly int tinhThuaPnnNtVt2Kv2 = 12;
        public static readonly int tinhThuaPnnNtVt3Kv2 = 13;
        public static readonly int tinhThuaPnnNtVt1Kv3 = 14;
        public static readonly int tinhThuaPnnNtVt2Kv3 = 15;
        public static readonly int tinhThuaPnnNtVt3Kv3 = 16;
        public static readonly int tinhThuaPnnNtMtTronThua = 17;
        public static readonly int tinhThuaPnnNtMtHon50m = 18;
        public static readonly int tinhThuaPnnNtMtHon100m = 19;
        public static readonly int tinhThuaPnnNtMtSau50_100m = 20;
        public static readonly int tinhThuaPnnNtMtSau100m = 21;

        //dat phi nong nghiep do thi
        public static readonly int tinhThuaMatTienTronThua = 22;
        public static readonly int tinhThuaMatTienHon50m = 23;
        public static readonly int tinhThuaSau50m = 24;
        

        public static readonly int tinhThuaHcDuoi100mTronThua = 25;
        public static readonly int tinhThuaHcDuoi100mKoTronThua = 26;
        public static readonly int tinhThuaHc100_200mTronThua = 27;
        public static readonly int tinhThuaHc100_200mKoTtGan100 = 28;
        public static readonly int tinhThuaHc100_200mKoTtGan200 = 29;
        public static readonly int tinhThuaHcHon200mTronThua = 30;
        public static readonly int tinhThuaHcHon200mKoTronThua = 31;

        public static readonly int tinhThuaHpDuoi100mTronThua = 32;
        public static readonly int tinhThuaHpDuoi100mKoTronThua = 33;
        public static readonly int tinhThuaHp100_200mTronThua = 34;
        public static readonly int tinhThuaHp100_200mKoTtGan100 = 35;
        public static readonly int tinhThuaHp100_200mKoTtGan200 = 36;
        public static readonly int tinhThuaHpHon200mTronThua = 37;
        public static readonly int tinhThuaHpHon200mKoTronThua = 38;

        public static readonly int tinhThuaRiengLe = 0;

        public static readonly int tinhHemSauDuoi100m=101;
        public static readonly int tinhHemSau100_200m = 102;
        public static readonly int tinhHemSauTren200m = 103;
        public static readonly int tinhHemPhuSauDuoi100m=104;
        public static readonly int tinhHemPhuSau100_200m = 105;
        public static readonly int tinhHemPhuSauTren200m = 106;

        public static readonly int tinhThuaHcTuGiaHem = 110;
        public static readonly int tinhThuaHpTuGiaHem = 111;
        //public static readonly int tinhThuaMattien = 0;
        //private static int tinhThuaMattienVaThuaHem = 2;
        //private static int tinhThuaHem = 3;
        //private static int tinhThuaHemChinh = 4;
        //private static int tinhThuaHemPhu = 5;
        //private static int tinhThuaRiengLe = 18;
        //private static int tinhThuaNongnghiep = 20;
        //private static int tinhThuaPnnNt = 21;
        //private static int tinhThuaPnnNtKv1 = 22;
        //private static int tinhThuaPnnNtKv2 = 23;
        //private static int tinhThuaPnnNtKv3 = 24;
        //private static int tinhThuaPnnDt = 25;
        //private static int tinhThuaPnn = 26;
        
        //private static int tinhThuaHemChinh_100m = 28;
        //private static int tinhThuaHemChinh_100_200m = 29;
        
        //private static int tinhThuaHemChinh100_200_m = 31;
        //private static int tinhThuaHemChinh200_m = 32;
        //private static int tinhThuaHemChinhTren200m = 33;

        //private static int tinhThuaHemPhuDuoi100m = 34;
        //private static int tinhThuaHemPhuDuoi200m = 35;
        //private static int tinhThuaHemPhuTren200m = 36;
        //private static int tinhThuaHemPhu100_200m = 37;
        //private static int tinhThuaHemPhu200_m = 38;
        

        private static int init = -1;
        private static int text = 200;

        public static int Init
        {
            get { return init; }
        }
        public static int Test
        {
            get { return text; }
        }

        //public static int THUA_MAT_TIEN
        //{
        //    get { return tinhThuaMattien; }
        //}

        //public static int THUA_MAT_TIEN_MO_RONG
        //{
        //    get { return tinhThuaMatTienHon50m; }
        //}

        //public static int THUA_MAT_TIEN_TRON
        //{
        //    get { return tinhThuaMatTienTronThua; }
        //}
        //public static int THUA_SAU_50M
        //{
        //    get { return tinhThuaSau50m; }
        //}

        //public static int THUA_HEM
        //{
        //    get { return tinhThuaHem; }
        //}
        //public static int THUA_HEM_CHINH
        //{
        //    get { return tinhThuaHemChinh; }
        //}
        //public static int THUA_HEM_CHINH_DUOI_100
        //{
        //    get { return tinhThuaHcDuoi100mTronThua; }
        //}
        //public static int THUA_HEM_CHINH_100_200_1S
        //{
        //    get { return tinhThuaHemChinh_100_200m; }
        //}
        //public static int THUA_HEM_CHINH_100_200_2S
        //{
        //    get { return tinhThuaHemChinh100_200_m; }
        //}
        //public static int THUA_HEM_CHINH_100_200
        //{
        //    get { return tinhThuaHc100_200mTronThua; }
        //}
        //public static int THUA_HEM_CHINH_100
        //{
        //    get { return tinhThuaHemChinh_100m; }
        //}
        //public static int THUA_HEM_CHINH_200_
        //{
        //    get { return tinhThuaHemChinh200_m; }
        //}
        //public static int THUA_HEM_CHINH_TREN_200
        //{
        //    get { return tinhThuaHemChinhTren200m; }
        //}

        //public static int THUA_HEM_PHU
        //{
        //    get { return tinhThuaHemPhu; }
        //}

        //public static int THUA_MAT_TIEN_VA_HEM
        //{
        //    get { return tinhThuaMattienVaThuaHem; }
        //}

        //public static int THUA_NONG_NGHIEP_VT1
        //{
        //    get { return tinhThuaNnVt1TronThua; }
        //}
        //public static int THUA_NONG_NGHIEP_VT1_1S
        //{
        //    get { return tinhThuaNnVt1Hon100m; }
        //}
        //public static int THUA_NONG_NGHIEP_VT2
        //{
        //    get { return tinhThuaNnVt2Th1TronThua; }
        //}
        //public static int THUA_NONG_NGHIEP_VT2_1S
        //{
        //    get { return tinhThuaNnVt2Th1Hon100m; }
        //}
        //public static int THUA_NONG_NGHIEP_VT2_2S
        //{
        //    get { return tinhThuaNnVt2Th2TronThua; }
        //}
        //public static int THUA_NONG_NGHIEP_VT2_3S
        //{
        //    get { return tinhThuaNnVt2Th2Hon100m; }
        //}

        //public static int THUA_NONG_NGHIEP_VT3
        //{
        //    get { return tinhThuaNnVt3; }
        //}

        //public static int THUA_PNN_NT_VT1_KV1
        //{
        //    get { return tinhThuaPnnNtVt1Kv1; }
        //}
        //public static int THUA_PNN_NT_VT2_KV1
        //{
        //    get { return tinhThuaPnnNtVt2Kv1; }
        //}
        //public static int THUA_PNN_NT_VT3_KV1
        //{
        //    get { return tinhThuaPnnNtVt3Kv1; }
        //}
        //public static int THUA_PNN_NT_VT1_KV2
        //{
        //    get { return tinhThuaPnnNtVt1Kv2; }
        //}
        //public static int THUA_PNN_NT_VT2_KV2
        //{
        //    get { return tinhThuaPnnNtVt2Kv2; }
        //}
        //public static int THUA_PNN_NT_VT3_KV2
        //{
        //    get { return tinhThuaPnnNtVt3Kv2; }
        //}
        //public static int THUA_PNN_NT_VT1_KV3
        //{
        //    get { return tinhThuaPnnNtVt1Kv3; }
        //}
        //public static int THUA_PNN_NT_VT2_KV3
        //{
        //    get { return tinhThuaPnnNtVt2Kv3; }
        //}
        //public static int THUA_PNN_NT_VT3_KV3
        //{
        //    get { return tinhThuaPnnNtVt3Kv3; }
        //}

        //public static int THUA_RIENG_LE
        //{
        //    get { return tinhThuaRiengLe; }
        //}

        //public static int THUA_PNN_NT
        //{
        //    get { return tinhThuaPnnNt; }
        //}

        //public static int THUA_PNN_NT_KV1
        //{
        //    get { return tinhThuaPnnNtKv1; }
        //}
        //public static int THUA_PNN_NT_KV2
        //{
        //    get { return tinhThuaPnnNtVt1Kv2; }
        //}
        //public static int THUA_PNN_NT_KV3
        //{
        //    get { return tinhThuaPnnNtVt1Kv3; }
        //}
        //public static int THUA_PNN_DT
        //{
        //    get { return tinhThuaPnnDt; }
        //}

        //public static int THUA_PNN
        //{
        //    get { return tinhThuaPnn; }
        //}
    }
}
