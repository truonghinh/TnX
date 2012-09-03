using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNPro.Quydinh
{
    public class TnTenQuyDinh
    {
        private static int _quyDinhChung = 0;
        private static int _giaDatNongNghiep = 1;
        private static int _giaDatONongThon = 2;
        private static int _giaDatODoThi = 3;
        private static int _giadatVungRanh = 4;

        public static int QUY_DINH_CHUNG { get { return _quyDinhChung; } }
        public static int GIA_DAT_NONG_NGHIEP { get { return _giaDatNongNghiep; } }
        public static int GIA_DAT_O_NONG_THON { get { return _giaDatONongThon; } }
        public static int GIA_DAT_O_DO_THI { get { return _giaDatODoThi; } }
        public static int GIA_DAT_VUNG_RANH { get { return _giadatVungRanh; } }
    }
}
