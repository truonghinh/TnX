using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using gov.tn.system;

namespace com.g1.arcgis.tn.config
{
    /// <summary>
    /// Lưu các hệ số theo quy định tính giá. Mỗi lần ứng dụng chạy, lớp này sẽ đọc từ file TnXConfig.tnx
    /// </summary>
    public class CurrentConfig:ICurrentConfig
    {
        private static CurrentConfig meClass =null;
        private Dictionary<string, object> _dicParams;
        public static CurrentConfig CallMe()
        {
            if (meClass == null)
            {
                meClass = new CurrentConfig();
            }
            return meClass;
        }
        private CurrentConfig()
        {
            _dicParams = new Dictionary<string, object>();
            _dicParams.Add(TnConfig.Param.BTinhThuaDoiDien, _bTinhThuaDoiDien);
        }

        private static string _namApDung = "2012";
        private static int _bChoPhepApGia = 1;
        //--pnndt--
        private static double _dBufferMattien = 1;
        private static double _dBufferMathem = 1;
        private static double _k2MatTien = 1.2;
        private static double _k3MatTien = 1.3;
        private static double _k4MatTien = 1.4;
        private static double _pHemChinhRongTren6m = 0.4;
        private static double _pHemChinhRongTren3_5m = 0.3;
        private static double _pHemChinhRongDuoi3_5m = 0.2;
        private static double _pHemPhuRongTren6m = 0.7;
        private static double _pHemPhuRongTren3_5m = 0.6;
        private static double _pHemPhuRongDuoi3_5m = 0.4;
        private static double _pHemSauDuoi100m = 1;
        private static double _pHemSauDuoi200m = 0.8;
        private static double _pHemSauTren200m = 0.6;
        private static double _dKhoangCach50mMatTien = 50;
        private static double _pDatSau50mMatTien = 0.3;
        private static double _gToiThieuDoThiLoai4 = 100000;
        private static double _gToiThieuDoThiLoai5 = 80000;
        private static double _pGiaDatSxkdDt = 0.9;

        //--pnnnt--
        private static double _dBkTimKhudcttKv2 = 100;
        private static double _dBkTimKhudcttKv3 = 100;
        private static double _dBufferMepDuongPnnntVt1 = 1;
        private static double _dBufferMepDuongPnnntVt2 = 1;
        private static double _pPnnNtDuoi100m = 1;
        private static double _pPnnNtTren100m = 0.5;
        private static double _dBKUbnd_truong_cho_tramyt = 500;
        private static double _dCachRgTmdv_dl_cn_cx_ktck = 500;
        private static int _bTinhThuaDoiDien = 1;
        private static double _dCachDmgt_chodm = 500;
        private static double _dVt2Kv1 = 1000;
        private static double _pGiaDatSxkdNt = 0.8;

        //--nong nghiep
        private static double _dBufferMepDuongNnVt1 = 1;
        private static double _dBufferMepDuongNnVt2 = 1;
        private static double _dRongDuongVitri1Nn = 9;
        private static double _dSauDuongVitri1Nn = 100;
        private static double _dRongDuongVitri2NnMax = 9;
        private static double _dRongDuongVitri2NnMin = 3;
        private static double _dSauDuongVitri2Nn = 100;
        private static double _dSauDuongVitri2Nn2 = 200;

        //--giap ranh
        private static double _dGrDatNn = 300;
        private static double _dGrDatPnnNt = 200;
        private static double _dGrDatPnnDt = 100;

        /// <summary>
        /// Năm áp dụng
        /// </summary>
        string ICurrentConfig.NamApDung { get { return _namApDung; } set { _namApDung = value; } }
        /// <summary>
        /// Cho phép người dùng áp giá
        /// </summary>
        int ICurrentConfig.ChoPhepApGia { get { return _bChoPhepApGia; } set { _bChoPhepApGia = value; } }

        //===================================================================
        //==== tham số cho thửa phi nông nghiệp đô thị====================
        //===================================================================

        #region thua phi nong nghiep do thi
        /// <summary>
        /// --pndt--
        /// Khoảng cách buffer tìm thửa mặt tiền (năm 2011:1)
        /// </summary>
        double ICurrentConfig.PGiaDatSxkddt { get { return _pGiaDatSxkdDt; } set { _pGiaDatSxkdDt = value; } }
        /// <summary>
        /// --pndt--
        /// Khoảng cách buffer tìm thửa mặt tiền (năm 2011:1)
        /// </summary>
        double ICurrentConfig.DBufferMattien { get { return _dBufferMattien; } set { _dBufferMattien = value; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 3 mặt tiền (năm 2011:1.3)
        /// </summary>
        double ICurrentConfig.DBufferMathem { get { return _dBufferMathem; } set { _dBufferMathem = value; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 2 mặt tiền (năm 2011:1.2)
        /// </summary>
        /// <value>get value</value>
        double ICurrentConfig.K2MatTien { get { return _k2MatTien; } set { _k2MatTien = value; } }
        //string K2MatTien { get { return "K2MatTien"; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 3 mặt tiền (năm 2011:1.3)
        /// </summary>
        double ICurrentConfig.K3MatTien { get { return _k3MatTien; } set { _k3MatTien = value; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 4 mặt tiền (năm 2011:1.4)
        /// </summary>
        double ICurrentConfig.K4MatTien { get { return _k4MatTien; } set { _k4MatTien = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng trên 6m (năm 2011: 40%)
        /// </summary>
        double ICurrentConfig.PHemChinhRongTren6m { get { return _pHemChinhRongTren6m; } set { _pHemChinhRongTren6m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng từ 3.5m đến 6m (năm 2011: 30%)
        /// </summary>
        double ICurrentConfig.PHemChinhRongTren3_5m { get { return _pHemChinhRongTren3_5m; } set { _pHemChinhRongTren3_5m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng dưới 3.5m (năm 2011: 20%)
        /// </summary>
        double ICurrentConfig.PHemChinhRongDuoi3_5m { get { return _pHemChinhRongDuoi3_5m; } set { _pHemChinhRongDuoi3_5m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng trên 6m (năm 2011: 40%)
        /// </summary>
        double ICurrentConfig.PHemPhuRongTren6m { get { return _pHemPhuRongTren6m; } set { _pHemPhuRongTren6m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng từ 3.5m đến 6m (năm 2011: 30%)
        /// </summary>
        double ICurrentConfig.PHemPhuRongTren3_5m { get { return _pHemPhuRongTren3_5m; } set { _pHemPhuRongTren3_5m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng dưới 3.5m (năm 2011: 20%)
        /// </summary>
        double ICurrentConfig.PHemPhuRongDuoi3_5m { get { return _pHemPhuRongDuoi3_5m; } set { _pHemPhuRongDuoi3_5m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm từ mét thứ 1 đến mét thứ 100 của hẻm (năm 2011: 100%)
        /// </summary>
        double ICurrentConfig.PHemSauDuoi100m { get { return _pHemSauDuoi100m; } set { _pHemSauDuoi100m = value; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm sâu từ 100m đến 200m trong hẻm (năm 2011: 80%)
        /// </summary>
        double ICurrentConfig.PHemSauDuoi200m { get { return _pHemSauDuoi200m; } set { _pHemSauDuoi200m = value; } } 
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm sâu trên 200m trong hẻm (năm 2011: 60%)
        /// </summary>
        double ICurrentConfig.PHemSauTren200m { get { return _pHemSauTren200m; } set { _pHemSauTren200m = value; } }
        /// <summary>
        /// --pndt--
        /// Khoảng cách để phần đất được tính vào giới hạn 50m sau thử mặt tiền (năm 2011: 50)
        /// </summary>
        double ICurrentConfig.DKhoangCach50mMatTien { get { return _dKhoangCach50mMatTien; } set { _dKhoangCach50mMatTien = value; } }

        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất sau 50 thửa mặt tiền đườn phố (năm 2011: 30%)
        /// </summary>
        double ICurrentConfig.PDatSau50mMatTien { get { return _pDatSau50mMatTien; } set { _pDatSau50mMatTien = value; } }
        /// <summary>
        /// --pndt--
        /// Giá đất tối thiểu tại đô thị loại 4 (năm 2011: 100,000)
        /// </summary>
        double ICurrentConfig.GToiThieuDoThiLoai4 { get { return _gToiThieuDoThiLoai4; } set { _gToiThieuDoThiLoai4 = value; } }
        /// <summary>
        /// --pndt--
        /// Giá đất tối thiểu tại đô thị loại 5 (năm 2011: 80,000)
        /// </summary>
        double ICurrentConfig.GToiThieuDoThiLoai5 { get { return _gToiThieuDoThiLoai5; } set { _gToiThieuDoThiLoai5 = value; } }
        #endregion

        //===================================================================
        //==== tham số cho thửa nông nghiệp====================
        //===================================================================

        #region thua nong nghiep
        double ICurrentConfig.DBufferMepDuongNnVt1 { get { return _dBufferMepDuongNnVt1; } set { _dBufferMepDuongNnVt1 = value; } }
        double ICurrentConfig.DBufferMepDuongNnVt2 { get { return _dBufferMepDuongNnVt2; } set { _dBufferMepDuongNnVt2 = value; } }
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:9)
        /// </summary>
        double ICurrentConfig.DRongDuongVitri1Nn { get { return _dRongDuongVitri1Nn; } set { _dRongDuongVitri1Nn = value; } }
        /// <summary>
        /// --nn--
        /// Độ sâu nền đường tối đa để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:100)
        /// </summary>
        double ICurrentConfig.DSauDuongVitri1Nn { get { return _dSauDuongVitri1Nn; } set { _dSauDuongVitri1Nn = value; } }

        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:9)
        /// </summary>
        double ICurrentConfig.DRongDuongVitri2NnMax { get { return _dRongDuongVitri2NnMax; } set { _dRongDuongVitri2NnMax = value; } }
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:9)
        /// </summary>
        double ICurrentConfig.DRongDuongVitri2NnMin { get { return _dRongDuongVitri2NnMin; } set { _dRongDuongVitri2NnMin = value; } }
        /// <summary>
        /// --nn--
        /// Độ sâu nền đường tối đa để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:100)
        /// </summary>
        double ICurrentConfig.DSauDuongVitri2Nn { get { return _dSauDuongVitri2Nn; } set { _dSauDuongVitri2Nn = value; } }
        /// <summary>
        /// --nn--
        /// Độ sâu tối đa tính từ sau thửa nông nghiệp vị trí 1 
        /// để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:200)
        /// </summary>
        double ICurrentConfig.DSauDuongVitri2Nn2 { get { return _dSauDuongVitri2Nn2; } set { _dSauDuongVitri2Nn2 = value; } }
        #endregion

        //===================================================================
        //==== tham số cho thửa phi nông nghiệp nông thôn====================
        //===================================================================

        #region thua phi nong nghiep nong thon
        double ICurrentConfig.PGiaDatSxkdnt { get { return _pGiaDatSxkdNt; } set { _pGiaDatSxkdNt = value; } }
        double ICurrentConfig.DBufferMepDuongPnntVt1 { get { return _dBufferMepDuongPnnntVt1; } set { _dBufferMepDuongPnnntVt1 = value; } }
        double ICurrentConfig.DBufferMepDuongPnntVt2 { get { return _dBufferMepDuongPnnntVt2; } set { _dBufferMepDuongPnnntVt2 = value; } }
        double ICurrentConfig.DBkTimKdcttKv2 { get { return _dBkTimKhudcttKv2; } set { _dBkTimKhudcttKv2 = value; } }
        double ICurrentConfig.DBkTimKdcttKv3 { get { return _dBkTimKhudcttKv3; } set { _dBkTimKhudcttKv3 = value; } }
        /// <summary>
        /// --pnnt--
        /// Phần trăm tính giá cho đất phi nông nghiệp tại nông thôn 
        /// nằm từ mét thứ 1 đến mét thứ 100 của thửa đất (năm 2011: 100)
        /// </summary>
        double ICurrentConfig.PPnnNtDuoi100m { get { return _pPnnNtDuoi100m; } set { _pPnnNtDuoi100m = value; } }
        /// <summary>
        /// --pnnt--
        /// Phần trăm tính giá cho đất phi nông nghiệp tại nông thôn 
        /// nằm từ mét thứ 100 tiếp theo của thửa đất (năm 2011: 50)
        /// </summary>
        double ICurrentConfig.PPnnNtTren100m { get { return _pPnnNtTren100m; } set { _pPnnNtTren100m = value; } }
        /// <summary>
        /// --pnnt--
        /// Bán kính tính từ UBND xã, trường học, chợ, trạm y tế 
        /// theo đường giao thông chính
        /// mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        double ICurrentConfig.DBKUbnd_truong_cho_tramyt { get { return _dBKUbnd_truong_cho_tramyt; } set { _dBKUbnd_truong_cho_tramyt = value; } }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tính từ ranh giới của khu thương mại dịch vụ, khu du lịch
        /// khu công nghiệp, khu chế xuất, khu kinh tế cửa khẩu
        /// theo đường giao thông chính mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        double ICurrentConfig.DCachRgTmdv_dl_cn_cx_ktck { get { return _dCachRgTmdv_dl_cn_cx_ktck; } set { _dCachRgTmdv_dl_cn_cx_ktck = value; } }
        /// <summary>
        /// --pnnt--
        /// Có tính hay không tính các thửa đất đối diện 
        /// với các khu thương mại dịch vụ, khu du lịch
        /// khu công nghiệp, khu chế xuất, khu kinh tế cửa khẩu
        /// là thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:1 (có)) (chấp nhận giá trị 1 hoặc 0)
        /// </summary>
        int ICurrentConfig.BTinhThuaDoiDien { get { return _bTinhThuaDoiDien; } set { _bTinhThuaDoiDien = value; } }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tính từ trung tâm đầu mối giao thông
        /// chợ đầu mối theo tuyến đường giao thông chính
        /// mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        double ICurrentConfig.DCachDmgt_chodm { get { return _dCachDmgt_chodm; } set { _dCachDmgt_chodm = value; } }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tối đa tính từ giáp thửa pnnnt thuộc vị trí 1
        /// theo đuòng giao thông chính mà trong đó
        /// các thửa có mặt tiền tiếp giáp đường gtc
        /// thuộc vị trí 2 khu vực 1
        /// (năm 2011:1000m)
        /// </summary>
        double ICurrentConfig.DVt2Kv1 { get { return _dVt2Kv1; } set { _dVt2Kv1 = value; } }
        #endregion

        //===================================================================
        //==== tham số cho khu vực giáp ranh====================
        //===================================================================

        #region dat giap ranh
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất nông nghiệp
        /// (năm 2011:300m)
        /// </summary>
        double ICurrentConfig.DGrDatNn { get { return _dGrDatNn; } set { _dGrDatNn = value; } }
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất phi nông nghiệp ở nông thôn
        /// (năm 2011:200m)
        /// </summary>
        double ICurrentConfig.DGrDatPnnNt { get { return _dGrDatPnnNt; } set { _dGrDatPnnNt = value; } }
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất phi nông nghiệp ở nông thôn
        /// (năm 2011:100m)
        /// </summary>
        double ICurrentConfig.DGrDatPnnDt { get { return _dGrDatPnnDt; } set { _dGrDatPnnDt = value; } }
        #endregion

        #region ICurrentConfig Members

        void ICurrentConfig.SetValue(string name, object value)
        {
            if (_dicParams.ContainsKey(name))
            {
                _dicParams[name] = value;
            }
            else
            {
                _dicParams.Add(name, value);
            }
        }

        object ICurrentConfig.GetValue(string name)
        {
            return _dicParams[name];
        }

        #endregion
    }
}
