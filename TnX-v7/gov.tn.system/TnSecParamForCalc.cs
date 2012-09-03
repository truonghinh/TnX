using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.system
{
    /// <summary>
    /// Class
    /// </summary>
    public class TnSecParamForCalc
    {
        private static TnSecParamForCalc meClass = null;
        private List<string> _params;
        public static TnSecParamForCalc CallMe()
        {
            if (meClass == null)
            {
                meClass = new TnSecParamForCalc();
                
            }
            return meClass;
        }
        private TnSecParamForCalc() 
        {
            _params = new List<string>();
            _params.Add("nam");
            _params.Add("ApGia");
            _params.Add("DBufferMattien");
            _params.Add("DBufferMathem");
            _params.Add("K2MatTien");
            _params.Add("K3MatTien");
            _params.Add("K4MatTien");
            _params.Add("PHemChinhRongTren6m");
            _params.Add("PHemChinhRongTren3_5m");
            _params.Add("PHemChinhRongDuoi3_5m");
            _params.Add("PHemPhuRongTren6m");
            _params.Add("PHemPhuRongTren3_5m");
            _params.Add("PHemPhuRongDuoi3_5m");
            _params.Add("PHemSauDuoi100m");
            _params.Add("PHemSauDuoi200m");
            _params.Add("PHemSauTren200m");
            _params.Add("DKhoangCach50mMatTien");
            _params.Add("PDatSau50mMatTien");
            _params.Add("GToiThieuDoThiLoai4");
            _params.Add("GToiThieuDoThiLoai5");
            _params.Add("DBufferMepDuongNnVt1");
            _params.Add("DBufferMepDuongNnVt2");
            _params.Add("DRongDuongVitri1Nn");
            _params.Add("DSauDuongVitri1Nn");
            _params.Add("DRongDuongVitri2Nn");
            _params.Add("DSauDuongVitri2Nn");
            _params.Add("DBufferMepDuongPnntVt1");
            _params.Add("DBufferMepDuongPnntVt2");
            _params.Add("DBkTimKdcttKv2");
            _params.Add("DBkTimKdcttKv3");
            _params.Add("PPnnNtDuoi100m");
            _params.Add("PPnnNtTren100m");
            _params.Add("DBKUbnd_truong_cho_tramyt");
            _params.Add("DCachRgTmdl_cn_cx_ktck");
            _params.Add("BTinhThuaDoiDien");
            _params.Add("DCachDmgt_chodm");
            _params.Add("DVt2Kv1");
            _params.Add("DGrDatNn");
            _params.Add("DGrDatPnnNt");
            _params.Add("DGrDatPnnDt");
        }
        /// <summary>
        /// Tên section trong file config
        /// </summary>
        public string Name { get { return "param"; } }

        /// <summary>
        /// Năm áp dụng
        /// </summary>
        public string NamApDung { get { return "nam"; } }

        /// <summary>
        /// Cho phép người dùng áp giá
        /// </summary>
        public string ChoPhepApGia { get { return "ApGia"; } }

        //===================================================================
        //==== tham số cho thửa phi nông nghiệp đô thị====================
        //===================================================================
        #region thua phi nong nghiep do thi
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 2 mặt tiền (năm 2011:1.2)
        /// </summary>
        /// <value>get value</value>
        /// aaaaaa
        public string DBufferMattien { get { return "DBufferMattien"; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 2 mặt tiền (năm 2011:1.2)
        /// </summary>
        /// <value>get value</value>
        /// aaaaaa
        public string DBufferMathem { get { return "DBufferMathem"; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 2 mặt tiền (năm 2011:1.2)
        /// </summary>
        /// <value>get value</value>
        /// aaaaaa
        public string K2MatTien { get { return "K2MatTien"; } }
        //public string K2MatTien { get { return "K2MatTien"; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 3 mặt tiền (năm 2011:1.3)
        /// </summary>
        public string K3MatTien { get { return "K3MatTien"; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 4 mặt tiền (năm 2011:1.4)
        /// </summary>
        public string K4MatTien { get { return "K4MatTien"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng trên 6m (năm 2011: 40%)
        /// </summary>
        public string PHemChinhRongTren6m { get { return "PHemChinhRongTren6m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng từ 3.5m đến 6m (năm 2011: 30%)
        /// </summary>
        public string PHemChinhRongTren3_5m { get { return "PHemChinhRongTren3_5m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng dưới 3.5m (năm 2011: 20%)
        /// </summary>
        public string PHemChinhRongDuoi3_5m { get { return "PHemChinhRongDuoi3_5m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng trên 6m (năm 2011: 40%)
        /// </summary>
        public string PHemPhuRongTren6m { get { return "PHemPhuRongTren6m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng từ 3.5m đến 6m (năm 2011: 30%)
        /// </summary>
        public string PHemPhuRongTren3_5m { get { return "PHemPhuRongTren3_5m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng dưới 3.5m (năm 2011: 20%)
        /// </summary>
        public string PHemPhuRongDuoi3_5m { get { return "PHemPhuRongDuoi3_5m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm từ mét thứ 1 đến mét thứ 100 của hẻm (năm 2011: 100%)
        /// </summary>
        public string PHemSauDuoi100m { get { return "PHemSauDuoi100m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm sâu từ 100m đến 200m trong hẻm (năm 2011: 80%)
        /// </summary>
        public string PHemSauDuoi200m { get { return "PHemSauDuoi200m"; } }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm sâu trên 200m trong hẻm (năm 2011: 60%)
        /// </summary>
        public string PHemSauTren200m { get { return "PHemSauTren200m"; } }
        /// <summary>
        /// --pndt--
        /// Khoảng cách để phần đất được tính vào giới hạn 50m sau thử mặt tiền (năm 2011: 50)
        /// </summary>
        public string DKhoangCach50mMatTien { get { return "DKhoangCach50mMatTien"; } }

        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất sau 50 thửa mặt tiền đườn phố (năm 2011: 30%)
        /// </summary>
        public string PDatSau50mMatTien { get { return "PDatSau50mMatTien"; } }
        /// <summary>
        /// --pndt--
        /// Giá đất tối thiểu tại đô thị loại 4 (năm 2011: 100,000)
        /// </summary>
        public string GToiThieuDoThiLoai4 { get { return "GToiThieuDoThiLoai4"; } }
        /// <summary>
        /// --pndt--
        /// Giá đất tối thiểu tại đô thị loại 5 (năm 2011: 80,000)
        /// </summary>
        public string GToiThieuDoThiLoai5 { get { return "GToiThieuDoThiLoai5"; } }
        #endregion
        //===================================================================
        //==== tham số cho thửa nông nghiệp====================
        //===================================================================
        #region thua nong nghiep
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:9)
        /// </summary>
        public string DBufferMepDuongNnVt1 { get { return "DBufferMepDuongNnVt1"; } }
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:9)
        /// </summary>
        public string DBufferMepDuongNnVt2 { get { return "DBufferMepDuongNnVt2"; } }
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:9)
        /// </summary>
        public string DRongDuongVitri1Nn { get { return "DRongDuongVitri1Nn"; } }
        /// <summary>
        /// --nn--
        /// Độ sâu nền đường tối đa để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:100)
        /// </summary>
        public string DSauDuongVitri1Nn { get { return "DSauDuongVitri1Nn"; } }

        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:9)
        /// </summary>
        public string DRongDuongVitri2Nn { get { return "DRongDuongVitri2Nn"; } }
        /// <summary>
        /// --nn--
        /// Độ sâu nền đường tối đa để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:100)
        /// </summary>
        public string DSauDuongVitri2Nn { get { return "DSauDuongVitri2Nn"; } }
        /// <summary>
        /// --nn--
        /// Độ sâu tối đa tính từ sau thửa nông nghiệp vị trí 1 
        /// để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:200)
        /// </summary>
        public string DSauDuongVitri2Nn2 { get { return "DSauDuongVitri2Nn2"; } }
        #endregion

        //===================================================================
        //==== tham số cho thửa phi nông nghiệp nông thôn====================
        //===================================================================
        /// <summary>
        /// --pnnt--
        /// khoảng cách buffer tìm thửa tiếp giáp (năm 2011: 1)
        /// </summary>
        public string DBufferMepDuongPnntVt1 { get { return "DBufferMepDuongPnntVt1"; } }
        /// <summary>
        /// --pnnt--
        /// khoảng cách buffer tìm thửa tiếp giáp (năm 2011: 1)
        /// </summary>
        public string DBufferMepDuongPnntVt2 { get { return "DBufferMepDuongPnntVt2"; } }
        /// <summary>
        /// --pnnt--
        /// khoảng cách buffer tìm thửa tiếp giáp (năm 2011: 1)
        /// </summary>
        public string DBkTimKdcttKv2 { get { return "DBkTimKdcttKv2"; } }
        /// <summary>
        /// --pnnt--
        /// khoảng cách buffer tìm thửa tiếp giáp (năm 2011: 1)
        /// </summary>
        public string DBkTimKdcttKv3 { get { return "DBkTimKdcttKv3"; } }
        /// <summary>
        /// --pnnt--
        /// Phần trăm tính giá cho đất phi nông nghiệp tại nông thôn 
        /// nằm từ mét thứ 1 đến mét thứ 100 của thửa đất (năm 2011: 100)
        /// </summary>
        public string PPnnNtDuoi100m { get { return "PPnnNtDuoi100m"; } }
        /// <summary>
        /// --pnnt--
        /// Phần trăm tính giá cho đất phi nông nghiệp tại nông thôn 
        /// nằm từ mét thứ 100 tiếp theo của thửa đất (năm 2011: 50)
        /// </summary>
        public string PPnnNtTren100m { get { return "PPnnNtTren100m"; } }
        /// <summary>
        /// --pnnt--
        /// Bán kính tính từ UBND xã, trường học, chợ, trạm y tế 
        /// theo đường giao thông chính
        /// mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        public string DBKUbnd_truong_cho_tramyt { get { return "DBKUbnd_truong_cho_tramyt"; } }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tính từ ranh giới của khu thương mại dịch vụ, khu du lịch
        /// khu công nghiệp, khu chế xuất, khu kinh tế cửa khẩu
        /// theo đường giao thông chính mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        public string DCachRgTmdv_dl_cn_cx_ktck { get { return "DCachRgTmdl_cn_cx_ktck"; } }
        /// <summary>
        /// --pnnt--
        /// Có tính hay không tính các thửa đất đối diện 
        /// với các khu thương mại dịch vụ, khu du lịch
        /// khu công nghiệp, khu chế xuất, khu kinh tế cửa khẩu
        /// là thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:1 (có)) (chấp nhận giá trị 1 hoặc 0)
        /// </summary>
        public string BTinhThuaDoiDien { get { return "BTinhThuaDoiDien"; } }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tính từ trung tâm đầu mối giao thông
        /// chợ đầu mối theo tuyến đường giao thông chính
        /// mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        public string DCachDmgt_chodm { get { return "DCachDmgt_chodm"; } }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tối đa tính từ giáp thửa pnnnt thuộc vị trí 1
        /// theo đuòng giao thông chính mà trong đó
        /// các thửa có mặt tiền tiếp giáp đường gtc
        /// thuộc vị trí 2 khu vực 1
        /// (năm 2011:1000m)
        /// </summary>
        public string DVt2Kv1 { get { return "DVt2Kv1"; } }

        //===================================================================
        //==== tham số cho khu vực giáp ranh====================
        //===================================================================
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất nông nghiệp
        /// (năm 2011:300m)
        /// </summary>
        public string DGrDatNn { get { return "DGrDatNn"; } }
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất phi nông nghiệp ở nông thôn
        /// (năm 2011:200m)
        /// </summary>
        public string DGrDatPnnNt { get { return "DGrDatPnnNt"; } }
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất phi nông nghiệp ở nông thôn
        /// (năm 2011:100m)
        /// </summary>
        public string DGrDatPnnDt { get { return "DGrDatPnnDt"; } }
    }
}
