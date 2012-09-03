using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace g1.tn.param
{
    public interface ICurrentConfig
    {
        void SetValue(string name, object value);
        object GetValue(string name);
        /// <summary>
        /// Năm áp dụng
        /// </summary>
        string NamApDung { get; set; }
        /// <summary>
        /// Cho phép người dùng áp giá
        /// </summary>
        int ChoPhepApGia { get; set; }

        //===================================================================
        //==== tham số cho thửa phi nông nghiệp đô thị====================
        //===================================================================

        #region thua phi nong nghiep do thi
        /// <summary>
        /// --nn--
        /// phan tram tinh gia dat sxkd o dt (nam 2011: 90%)
        /// </summary>
        double PGiaDatSxkddt { get; set; }
        /// <summary>
        /// --nn--
        /// Khoang cach buffer de tim thua tiep giap duong (nam 2011: 1m)
        /// </summary>
        double DBufferMattien { get; set; }
        /// <summary>
        /// --nn--
        /// Khoang cach buffer de tim thua tiep giap duong (nam 2011: 1m)
        /// </summary>
        double DBufferMathem { get; set; }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 2 mặt tiền (năm 2011:1.2)
        /// </summary>
        /// <value>get value</value>
        /// aaaaaa
        double K2MatTien { get; set; }
        //string K2MatTien { get { return "K2MatTien"; } }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 3 mặt tiền (năm 2011:1.3)
        /// </summary>
        double K3MatTien { get; set; }
        /// <summary>
        /// --pndt--
        /// Hệ số nhân thêm khi thửa có 4 mặt tiền (năm 2011:1.4)
        /// </summary>
        double K4MatTien { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng trên 6m (năm 2011: 40%)
        /// </summary>
        double PHemChinhRongTren6m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng từ 3.5m đến 6m (năm 2011: 30%)
        /// </summary>
        double PHemChinhRongTren3_5m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng dưới 3.5m (năm 2011: 20%)
        /// </summary>
        double PHemChinhRongDuoi3_5m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng trên 6m (năm 2011: 40%)
        /// </summary>
        double PHemPhuRongTren6m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng từ 3.5m đến 6m (năm 2011: 30%)
        /// </summary>
        double PHemPhuRongTren3_5m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá cho hẻm có độ rộng dưới 3.5m (năm 2011: 20%)
        /// </summary>
        double PHemPhuRongDuoi3_5m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm từ mét thứ 1 đến mét thứ 100 của hẻm (năm 2011: 100%)
        /// </summary>
        double PHemSauDuoi100m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm sâu từ 100m đến 200m trong hẻm (năm 2011: 80%)
        /// </summary>
        double PHemSauDuoi200m { get; set; }
        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất nằm sâu trên 200m trong hẻm (năm 2011: 60%)
        /// </summary>
        double PHemSauTren200m { get; set; }
        /// <summary>
        /// --pndt--
        /// Khoảng cách để phần đất được tính vào giới hạn 50m sau thử mặt tiền (năm 2011: 50)
        /// </summary>
        double DKhoangCach50mMatTien { get; set; }

        /// <summary>
        /// --pndt--
        /// Phần trăm tính giá đất sau 50 thửa mặt tiền đườn phố (năm 2011: 30%)
        /// </summary>
        double PDatSau50mMatTien { get; set; }
        /// <summary>
        /// --pndt--
        /// Giá đất tối thiểu tại đô thị loại 4 (năm 2011: 100,000)
        /// </summary>
        double GToiThieuDoThiLoai4 { get; set; }
        /// <summary>
        /// --pndt--
        /// Giá đất tối thiểu tại đô thị loại 5 (năm 2011: 80,000)
        /// </summary>
        double GToiThieuDoThiLoai5 { get; set; }
        #endregion

        //===================================================================
        //==== tham số cho thửa nông nghiệp====================
        //===================================================================

        #region thua nong nghiep
        /// <summary>
        /// --nn--
        /// Khoang cach buffer de tim thua tiep giap duong (nam 2011: 1m)
        /// </summary>
        double DBufferMepDuongNnVt1 { get; set; }
        /// <summary>
        /// --nn--
        /// Khoang cach buffer de tim thua tiep giap duong (nam 2011: 1m)
        /// </summary>
        double DBufferMepDuongNnVt2 { get; set; }
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:9)
        /// </summary>
        double DRongDuongVitri1Nn { get; set; }
        /// <summary>
        /// --nn--
        /// Độ sâu nền đường tối đa để thửa đất nông nghiệp thuộc vị trí 1 (năm 2011:100)
        /// </summary>
        double DSauDuongVitri1Nn { get; set; }

        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:9)
        /// </summary>
        double DRongDuongVitri2NnMax { get; set; }
        /// <summary>
        /// --nn--
        /// Độ rộng nền đường tối thiểu để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:3)
        /// </summary>
        double DRongDuongVitri2NnMin { get; set; }
        /// <summary>
        /// --nn--
        /// Độ sâu nền đường tối đa để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:100)
        /// </summary>
        double DSauDuongVitri2Nn { get; set; }
        /// <summary>
        /// --nn--
        /// Độ sâu tối đa tính từ sau thửa nông nghiệp vị trí 1 
        /// để thửa đất nông nghiệp thuộc vị trí 2 (năm 2011:200)
        /// </summary>
        double DSauDuongVitri2Nn2 { get; set; }
        #endregion

        //===================================================================
        //==== tham số cho thửa phi nông nghiệp nông thôn====================
        //===================================================================

        #region thua phi nong nghiep nong thon
        /// <summary>
        /// --nn--
        /// phan tram tinh gia dat sxkd o nt (nam 2011: 90%)
        /// </summary>
        double PGiaDatSxkdnt { get; set; }
        /// <summary>
        /// --nn--
        /// Bán kính tìm khu dân cư tập trung khu vực 2 (nam 2011: 100m)
        /// </summary>
        double DBkTimKdcttKv2 { get; set; }
        /// <summary>
        /// --nn--
        /// Bán kính tìm khu dân cư tập trung khu vực 3 (nam 2011: 100m)
        /// </summary>
        double DBkTimKdcttKv3 { get; set; }
        /// <summary>
        /// --nn--
        /// Khoang cach buffer de tim thua tiep giap duong (nam 2011: 1m)
        /// </summary>
        double DBufferMepDuongPnntVt1 { get; set; }
        /// <summary>
        /// --nn--
        /// Khoang cach buffer de tim thua tiep giap duong (nam 2011: 1m)
        /// </summary>
        double DBufferMepDuongPnntVt2 { get; set; }
        /// <summary>
        /// --pnnt--
        /// Phần trăm tính giá cho đất phi nông nghiệp tại nông thôn 
        /// nằm từ mét thứ 1 đến mét thứ 100 của thửa đất (năm 2011: 100)
        /// </summary>
        double PPnnNtDuoi100m { get; set; }
        /// <summary>
        /// --pnnt--
        /// Phần trăm tính giá cho đất phi nông nghiệp tại nông thôn 
        /// nằm từ mét thứ 100 tiếp theo của thửa đất (năm 2011: 50)
        /// </summary>
        double PPnnNtTren100m { get; set; }
        /// <summary>
        /// --pnnt--
        /// Bán kính tính từ UBND xã, trường học, chợ, trạm y tế 
        /// theo đường giao thông chính
        /// mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        double DBKUbnd_truong_cho_tramyt { get; set; }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tính từ ranh giới của khu thương mại dịch vụ, khu du lịch
        /// khu công nghiệp, khu chế xuất, khu kinh tế cửa khẩu
        /// theo đường giao thông chính mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        double DCachRgTmdv_dl_cn_cx_ktck { get; set; }
        /// <summary>
        /// --pnnt--
        /// Có tính hay không tính các thửa đất đối diện 
        /// với các khu thương mại dịch vụ, khu du lịch
        /// khu công nghiệp, khu chế xuất, khu kinh tế cửa khẩu
        /// là thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:1 (có)) (chấp nhận giá trị 1 hoặc 0)
        /// </summary>
        int BTinhThuaDoiDien { get; set; }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tính từ trung tâm đầu mối giao thông
        /// chợ đầu mối theo tuyến đường giao thông chính
        /// mà trong đó thửa pnnnt thuộc vị trí 1 khu vực 1
        /// (năm 2011:500m)
        /// </summary>
        double DCachDmgt_chodm { get; set; }
        /// <summary>
        /// --pnnt--
        /// Khoảng cách tối đa tính từ giáp thửa pnnnt thuộc vị trí 1
        /// theo đuòng giao thông chính mà trong đó
        /// các thửa có mặt tiền tiếp giáp đường gtc
        /// thuộc vị trí 2 khu vực 1
        /// (năm 2011:1000m)
        /// </summary>
        double DVt2Kv1 { get; set; }
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
        double DGrDatNn { get; set; }
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất phi nông nghiệp ở nông thôn
        /// (năm 2011:200m)
        /// </summary>
        double DGrDatPnnNt { get; set; }
        /// <summary>
        /// --gr--
        /// Khoảng cách tối đa xác định từ đường phân địa giới hành chính
        /// giữa các huyện, thị xã vào sâu mỗi huyện,thị xã
        /// đối với đất phi nông nghiệp ở nông thôn
        /// (năm 2011:100m)
        /// </summary>
        double DGrDatPnnDt { get; set; }
        #endregion
    }
}
