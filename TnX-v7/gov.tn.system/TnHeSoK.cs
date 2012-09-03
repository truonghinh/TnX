using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.system
{
    public class TnHeSoK
    {
        public static readonly int KhongXacDinh = 0;

        public static readonly int ttt = 3010;
        public static readonly int DatChuaXacDinhDt = 3000;
        public static readonly int DatOMtTtDt = 3010;
        public static readonly int DatOMatTienHon50mDt = 3011;
        public static readonly int DatOSauMatTien50mDt = 3020;
        public static readonly int DatSxkdMatTienTronThuaDt = 4010;
        public static readonly int DatSxkdMatTienHon50mDt = 4011;
        public static readonly int DatSxkdSauMatTien50mDt = 4020;
        public static readonly int DatONnMatTienTronThuaDt = 5010;
        public static readonly int DatONnMatTienHon50mDt = 5011;
        public static readonly int DatONnSauMatTien50m = 5020;
        //public static readonly int DatOSxkdMatTien = 6010;
        //public static readonly int DatOSxkdMatTienMoRongDt = 6011;
        //public static readonly int DatOSxkdSauMatTien50m = 6020;

        public static readonly int DatOHemChinhR6mS100mTronThua = 3111;
        public static readonly int DatOHemChinhR6mS100mKoTronThua = 3112;
        public static readonly int DatOHemChinhR6mS100_200mTronThua = 3113;
        public static readonly int DatOHemChinhR6mS100_200mKoTronThuaGan100 = 3114;
        public static readonly int DatOHemChinhR6mS100_200mKoTronThuaGan200 = 3115;
        public static readonly int DatOHemChinhR6mS200mTronThua = 3116;
        public static readonly int DatOHemChinhR6mS200mKoTronThua = 3117;

        public static readonly int DatOHemChinhR3_6mS100mTronThua = 3121;
        public static readonly int DatOHemChinhR3_6mS100mKoTronThua = 3122;
        public static readonly int DatOHemChinhR3_6mS100_200mTronThua = 3123;
        public static readonly int DatOHemChinhR3_6mS100_200mKoTronThuaGan100 = 3124;
        public static readonly int DatOHemChinhR3_6mS100_200mKoTronThuaGan200 = 3125;
        public static readonly int DatOHemChinhR3_6mS200mTronThua = 3126;
        public static readonly int DatOHemChinhR3_6mS200mKoTronThua = 3127;

        public static readonly int DatOHemChinhR3mS100mTronThua = 3131;
        public static readonly int DatOHemChinhR3mS100mKoTronThua = 3132;
        public static readonly int DatOHemChinhR3mS100_200mTronThua = 3133;
        public static readonly int DatOHemChinhR3mS100_200mKoTronThuaGan100 = 3134;
        public static readonly int DatOHemChinhR3mS100_200mKoTronThuaGan200 = 3135;
        public static readonly int DatOHemChinhR3mS200mTronThua = 3136;
        public static readonly int DatOHemChinhR3mS200mKoTronThua = 3137;

        public static readonly int DatSxkdHemChinhR6mS100mTronThua = 4111;
        public static readonly int DatSxkdHemChinhR6mS100mKoTronThua = 4112;
        public static readonly int DatSxkdHemChinhR6mS100_200mTronThua = 4113;
        public static readonly int DatSxkdHemChinhR6mS100_200mKoTronThuaGan100 = 4114;
        public static readonly int DatSxkdHemChinhR6mS100_200mKoTronThuaGan200 = 4115;
        public static readonly int DatSxkdHemChinhR6mS200mTronThua = 4116;
        public static readonly int DatSxkdHemChinhR6mS200mKoTronThua = 4117;

        public static readonly int DatSxkdHemChinhR3_6mS100mTronThua = 4121;
        public static readonly int DatSxkdHemChinhR3_6mS100mKoTronThua = 4122;
        public static readonly int DatSxkdHemChinhR3_6mS100_200mTronThua = 4123;
        public static readonly int DatSxkdHemChinhR3_6mS100_200mKoTronThuaGan100 = 4124;
        public static readonly int DatSxkdHemChinhR3_6mS100_200mKoTronThuaGan200 = 4125;
        public static readonly int DatSxkdHemChinhR3_6mS200mTronThua = 4126;
        public static readonly int DatSxkdHemChinhR3_6mS200mKoTronThua = 4127;

        public static readonly int DatSxkdHemChinhR3mS100mTronThua = 4131;
        public static readonly int DatSxkdHemChinhR3mS100mKoTronThua = 4132;
        public static readonly int DatSxkdHemChinhR3mS100_200mTronThua = 4133;
        public static readonly int DatSxkdHemChinhR3mS100_200mKoTronThuaGan100 = 4134;
        public static readonly int DatSxkdHemChinhR3mS100_200mKoTronThuaGan200 = 4135;
        public static readonly int DatSxkdHemChinhR3mS200mTronThua = 4136;
        public static readonly int DatSxkdHemChinhR3mS200mKoTronThua = 4137;

        public static readonly int DatONnHemChinhR6mS100mTronThua = 5111;
        public static readonly int DatONnHemChinhR6mS100mKoTronThua = 5112;
        public static readonly int DatONnHemChinhR6mS100_200mTronThua = 5113;
        public static readonly int DatONnHemChinhR6mS100_200mKoTronThuaGan100 = 5114;
        public static readonly int DatONnHemChinhR6mS100_200mKoTronThuaGan200 = 5115;
        public static readonly int DatONnHemChinhR6mS200mTronThua = 5116;
        public static readonly int DatONnHemChinhR6mS200mKoTronThua = 5117;

        public static readonly int DatONnHemChinhR3_6mS100mTronThua = 5121;
        public static readonly int DatONnHemChinhR3_6mS100mKoTronThua = 5122;
        public static readonly int DatONnHemChinhR3_6mS100_200mTronThua = 5123;
        public static readonly int DatONnHemChinhR3_6mS100_200mKoTronThuaGan100 = 5124;
        public static readonly int DatONnHemChinhR3_6mS100_200mKoTronThuaGan200 = 5125;
        public static readonly int DatONnHemChinhR3_6mS200mTronThua = 5126;
        public static readonly int DatONnHemChinhR3_6mS200mKoTronThua = 5127;

        public static readonly int DatONnHemChinhR3mS100mTronThua = 5131;
        public static readonly int DatONnHemChinhR3mS100mKoTronThua = 5132;
        public static readonly int DatONnHemChinhR3mS100_200mTronThua = 5133;
        public static readonly int DatONnHemChinhR3mS100_200mKoTronThuaGan100 = 5134;
        public static readonly int DatONnHemChinhR3mS100_200mKoTronThuaGan200 = 5135;
        public static readonly int DatONnHemChinhR3mS200mTronThua = 5136;
        public static readonly int DatONnHemChinhR3mS200mKoTronThua = 5137;

        public static readonly int DatOHemPhuR6mS100mTronThua = 3211;
        public static readonly int DatOHemPhuR6mS100mKoTronThua = 3212;
        public static readonly int DatOHemPhuR6mS100_200mTronThua = 3213;
        public static readonly int DatOHemPhuR6mS100_200mKoTronThuaGan100 = 3214;
        public static readonly int DatOHemPhuR6mS100_200mKoTronThuaGan200 = 3215;
        public static readonly int DatOHemPhuR6mS200mTronThua = 3216;
        public static readonly int DatOHemPhuR6mS200mKoTronThua = 3217;

        public static readonly int DatOHemPhuR3_6mS100mTronThua = 3221;
        public static readonly int DatOHemPhuR3_6mS100mKoTronThua = 3222;
        public static readonly int DatOHemPhuR3_6mS100_200mTronThua = 3223;
        public static readonly int DatOHemPhuR3_6mS100_200mKoTronThuaGan100 = 3224;
        public static readonly int DatOHemPhuR3_6mS100_200mKoTronThuaGan200 = 3225;
        public static readonly int DatOHemPhuR3_6mS200mTronThua = 3226;
        public static readonly int DatOHemPhuR3_6mS200mKoTronThua = 3227;

        public static readonly int DatOHemPhuR3mS100mTronThua = 3231;
        public static readonly int DatOHemPhuR3mS100mKoTronThua = 3232;
        public static readonly int DatOHemPhuR3mS100_200mTronThua = 3233;
        public static readonly int DatOHemPhuR3mS100_200mKoTronThuaGan100 = 3234;
        public static readonly int DatOHemPhuR3mS100_200mKoTronThuaGan200 = 3235;
        public static readonly int DatOHemPhuR3mS200mTronThua = 3236;
        public static readonly int DatOHemPhuR3mS200mKoTronThua = 3237;

        public static readonly int DatSxkdHemPhuR6mS100mTronThua = 4211;
        public static readonly int DatSxkdHemPhuR6mS100mKoTronThua = 4212;
        public static readonly int DatSxkdHemPhuR6mS100_200mTronThua = 4213;
        public static readonly int DatSxkdHemPhuR6mS100_200mKoTronThuaGan100 = 4214;
        public static readonly int DatSxkdHemPhuR6mS100_200mKoTronThuaGan200 = 4215;
        public static readonly int DatSxkdHemPhuR6mS200mTronThua = 4216;
        public static readonly int DatSxkdHemPhuR6mS200mKoTronThua = 4217;

        public static readonly int DatSxkdHemPhuR3_6mS100mTronThua = 4221;
        public static readonly int DatSxkdHemPhuR3_6mS100mKoTronThua = 4222;
        public static readonly int DatSxkdHemPhuR3_6mS100_200mTronThua = 4223;
        public static readonly int DatSxkdHemPhuR3_6mS100_200mKoTronThuaGan100 = 4224;
        public static readonly int DatSxkdHemPhuR3_6mS100_200mKoTronThuaGan200 = 4225;
        public static readonly int DatSxkdHemPhuR3_6mS200mTronThua = 4226;
        public static readonly int DatSxkdHemPhuR3_6mS200mKoTronThua = 4227;

        public static readonly int DatSxkdHemPhuR3mS100mTronThua = 4231;
        public static readonly int DatSxkdHemPhuR3mS100mKoTronThua = 4232;
        public static readonly int DatSxkdHemPhuR3mS100_200mTronThua = 4233;
        public static readonly int DatSxkdHemPhuR3mS100_200mKoTronThuaGan100 = 4234;
        public static readonly int DatSxkdHemPhuR3mS100_200mKoTronThuaGan200 = 4235;
        public static readonly int DatSxkdHemPhuR3mS200mTronThua = 4236;
        public static readonly int DatSxkdHemPhuR3mS200mKoTronThua = 4237;

        public static readonly int DatONnHemPhuR6mS100mTronThua = 5211;
        public static readonly int DatONnHemPhuR6mS100mKoTronThua = 5212;
        public static readonly int DatONnHemPhuR6mS100_200mTronThua = 5213;
        public static readonly int DatONnHemPhuR6mS100_200mKoTronThuaGan100 = 5214;
        public static readonly int DatONnHemPhuR6mS100_200mKoTronThuaGan200 = 5215;
        public static readonly int DatONnHemPhuR6mS200mTronThua = 5216;
        public static readonly int DatONnHemPhuR6mS200mKoTronThua = 5217;

        public static readonly int DatONnHemPhuR3_6mS100mTronThua = 5221;
        public static readonly int DatONnHemPhuR3_6mS100mKoTronThua = 5222;
        public static readonly int DatONnHemPhuR3_6mS100_200mTronThua = 5223;
        public static readonly int DatONnHemPhuR3_6mS100_200mKoTronThuaGan100 = 5224;
        public static readonly int DatONnHemPhuR3_6mS100_200mKoTronThuaGan200 = 5225;
        public static readonly int DatONnHemPhuR3_6mS200mTronThua = 5226;
        public static readonly int DatONnHemPhuR3_6mS200mKoTronThua = 5227;

        public static readonly int DatONnHemPhuR3mS100mTronThua = 5231;
        public static readonly int DatONnHemPhuR3mS100mKoTronThua = 5232;
        public static readonly int DatONnHemPhuR3mS100_200mTronThua = 5233;
        public static readonly int DatONnHemPhuR3mS100_200mKoTronThuaGan100 = 5234;
        public static readonly int DatONnHemPhuR3mS100_200mKoTronThuaGan200 = 5235;
        public static readonly int DatONnHemPhuR3mS200mTronThua = 5236;
        public static readonly int DatONnHemPhuR3mS200mKoTronThua = 5237;

        //public static readonly int DatOSxkdHemChinhR6mS100m = 6111;
        //public static readonly int DatOSxkdHemChinhR6mS100_200m = 6112;
        //public static readonly int DatOSxkdHemChinhR6mS200m = 6113;
        //public static readonly int DatOSxkdHemChinhR3_6mS100m = 6121;
        //public static readonly int DatOSxkdHemChinhR3_6mS100_200m = 6122;
        //public static readonly int DatOSxkdHemChinhR3_6mS200m = 6123;
        //public static readonly int DatOSxkdHemChinhR3mS100m = 6131;
        //public static readonly int DatOSxkdHemChinhR3mS100_200m = 6132;
        //public static readonly int DatOSxkdHemChinhR3mS200m = 6133;

        //public static readonly int DatOHemPhuSau100mTronThua = 3201;
        //public static readonly int DatOHemPhuSau100_200mTronThua = 3202;
        //public static readonly int DatOHemPhuSau200mTronThua = 3203;


        //public static readonly int DatSxkdHemPhuSau100mTronThua = 3201;
        //public static readonly int DatSxkdHemPhuSau100_200mTronThua = 3202;
        //public static readonly int DatSxkdHemPhuSau200mTronThua = 3203;

        public static readonly int DatNongNghiepVt1 = 1010;
        public static readonly int DatNongNghiepVt1Hon100m = 1011;
        public static readonly int DatNongNghiepVt2Th1 = 1020;
        public static readonly int DatNongNghiepVt2Th1Hon100m = 1021;
        public static readonly int DatNongNghiepVt2Th2 = 1022;
        public static readonly int DatNongNghiepVt2Th2Hon100m = 1023;
        public static readonly int DatNongNghiepVt3 = 1030;

        public static readonly int DatOPnnKv1Vt1 = 2110;
        public static readonly int DatOPnnKv1Vt2 = 2120;
        public static readonly int DatOPnnKv1Vt3 = 2130;
        public static readonly int DatOPnnKv2Vt1 = 2210;
        public static readonly int DatOPnnKv2Vt2 = 2220;
        public static readonly int DatOPnnKv2Vt3 = 2230;
        public static readonly int DatOPnnKv3Vt1 = 2310;
        public static readonly int DatOPnnKv3Vt2 = 2320;
        public static readonly int DatOPnnKv3Vt3 = 2330;
        public static readonly int DatSxkdPnnKv1Vt1 = 2111;
        public static readonly int DatSxkdPnnKv1Vt2 = 2121;
        public static readonly int DatSxkdPnnKv1Vt3 = 2131;
        public static readonly int DatSxkdPnnKv2Vt1 = 2211;
        public static readonly int DatSxkdPnnKv2Vt2 = 2221;
        public static readonly int DatSxkdPnnKv2Vt3 = 2231;
        public static readonly int DatSxkdPnnKv3Vt1 = 2311;
        public static readonly int DatSxkdPnnKv3Vt2 = 2321;
        public static readonly int DatSxkdPnnKv3Vt3 = 2331;
        public static readonly int DatONnPnnKv1Vt1 = 2112;
        public static readonly int DatONnPnnKv1Vt2 = 2122;
        public static readonly int DatONnPnnKv1Vt3 = 2132;
        public static readonly int DatONnPnnKv2Vt1 = 2212;
        public static readonly int DatONnPnnKv2Vt2 = 2222;
        public static readonly int DatONnPnnKv2Vt3 = 2232;
        public static readonly int DatONnPnnKv3Vt1 = 2312;
        public static readonly int DatONnPnnKv3Vt2 = 2322;
        public static readonly int DatONnPnnKv3Vt3 = 2332;
        public static readonly int DatOSxkdPnnKv1Vt1 = 2113;
        public static readonly int DatOSxkdPnnKv1Vt2 = 2123;
        public static readonly int DatOSxkdPnnKv1Vt3 = 2133;
        public static readonly int DatOSxkdPnnKv2Vt1 = 2213;
        public static readonly int DatOSxkdPnnKv2Vt2 = 2223;
        public static readonly int DatOSxkdPnnKv2Vt3 = 2233;
        public static readonly int DatOSxkdPnnKv3Vt1 = 2313;
        public static readonly int DatOSxkdPnnKv3Vt2 = 2323;
        public static readonly int DatOSxkdPnnKv3Vt3 = 2333;

        public static readonly int DatOMatTienTronThuaNt = 2010;
        public static readonly int DatOMatTienHon50mNt = 2020;
        public static readonly int DatOSau50mNt = 2030;
        public static readonly int DatSxkdMatTienTronThuaNt = 2011;
        public static readonly int DatSxkdMatTien50_100mNt = 2021;
        public static readonly int DatSxkdMatTienHon100mNt = 2031;
        public static readonly int DatSxkdSau50_100mNt = 2041;
        public static readonly int DatSxkdSau100mNt = 2051;
        public static readonly int DatONnMatTienTronThuaNt = 2012;
        public static readonly int DatONnMatTienHon50mNt = 2022;
        public static readonly int DatONnSau50mNt = 2032;

        public static readonly int DatHemChinh = 31;
        public static readonly int DatHemPhu = 32;
        public static readonly int DatOHemChinhSau100m = 1;
        public static readonly int DatHemChinhSau100_200m = 1;
    }
}
