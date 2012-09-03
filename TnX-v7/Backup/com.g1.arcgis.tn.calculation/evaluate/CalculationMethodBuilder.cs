using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using gov.tn.system;

namespace com.g1.arcgis.tn.calculation.evaluate
{
    public class CalculationMethodBuilder
    {
        #region fields
        object _loaidat;
        object _giaduong;
        object _tenduong;
        object _batdau;
        object _ketthuc;
        object _cachTinhDonGia;
        object _cachTinh;
        object _giadatNn;
        object _dorongHem;
        object _tenHem;
        object _loaiXa;
        ICurrentConfig _config;
        #endregion

        #region properties
        public object TenHem
        {
            get { return _tenHem; }
            set { _tenHem = value; }
        }
        public object LoaiXa
        {
            get { return _loaiXa; }
            set { _loaiXa = value; }
        }
        public object DoRongHem
        {
            get { return _dorongHem; }
            set { _dorongHem = value; }
        }
        public object LoaiDat
        {
            get { return _loaidat; }
            set { _loaidat = value; }
        }
        public object GiaDuong
        {
            get { return _giaduong; }
            set { _giaduong = value; }
        }
        public object TenDuong
        {
            get { return _tenduong; }
            set { _tenduong = value; }
        }
        public object BatDau
        {
            get { return _batdau; }
            set { _batdau = value; }
        }
        public object KetThuc
        {
            get { return _ketthuc; }
            set { _ketthuc = value; }
        }
        public object CachTinhDonGia
        {
            get { return _cachTinhDonGia; }
            set { _cachTinhDonGia = value; }
        }
        public object CachTinh
        {
            get { return _cachTinh; }
            set { _cachTinh = value; }
        }
        public object GiaDatNN
        {
            get { return _giadatNn; }
            set { _giadatNn = value; }
        }
        public ICurrentConfig Config
        {
            get { return _config; }
            set { _config = value; }
        }
        #endregion

        public string GetMethodString(string hesok)
        {
            string result = "";
            int hsk;
            bool ch = int.TryParse(hesok, out hsk);
            if (!ch)
            {
                hsk = 0;
            }

            #region dat nong nghiep
            if (hsk == TnHeSoK.DatNongNghiepVt1)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 1) (giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat,_giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt1Hon100m)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 1) (giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt2Th1)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 2) (giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt2Th1Hon100m)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 2) (giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt2Th2)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 2) (giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt2Th2Hon100m)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 2) (giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt3)
            {
                result = string.Format("Đất nông nghiệp ({0}) (vị trí 3)(giá đất nn ={1}), tiếp giáp đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion
            
            #region dat phi nong nghiep nong thon
            #region dat o
            else if (hsk == TnHeSoK.DatOPnnKv1Vt1)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 1, vị trí 1. Giá đất = {2}", _loaidat,  _loaiXa, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOPnnKv1Vt2)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 1, vị trí 2. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOPnnKv1Vt3)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 1, vị trí 3. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOPnnKv2Vt1)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 2, vị trí 1. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatOPnnKv2Vt2)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 2, vị trí 2. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatOPnnKv2Vt3)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 2, vị trí 3. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatOPnnKv3Vt1)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 3, vị trí 1. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatOPnnKv3Vt2)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 3, vị trí 2. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatOPnnKv3Vt3)
            {
                result = string.Format("Đất ở tại nông thôn ({0}), thuộc xã loại {1}, khu vực 3, vị trí 3. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            #endregion
            #region dat o + nn
            else if (hsk == TnHeSoK.DatONnPnnKv1Vt1)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 1, vị trí 1. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnPnnKv1Vt2)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 1, vị trí 2. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnPnnKv1Vt3)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 1, vị trí 3. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnPnnKv2Vt1)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 2, vị trí 1. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatONnPnnKv2Vt2)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 2, vị trí 2. Giá đất = {3}", _loaidat, _giadatNn, _loaiXa, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatONnPnnKv2Vt3)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 2, vị trí 3. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatONnPnnKv3Vt1)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 3, vị trí 1. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatONnPnnKv3Vt2)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 3, vị trí 2. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatONnPnnKv3Vt3)
            {
                result = string.Format("Đất ở có đất nông nghiệp tại nông thôn ({0}),(giá đất nn ={1}), thuộc xã loại {2}, khu vực 3, vị trí 3. Giá đất = {3}", _loaidat,_giadatNn, _loaiXa, _cachTinh);
            }
            #endregion
            #region dat sxkd
            else if (hsk == TnHeSoK.DatSxkdPnnKv1Vt1)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 1, vị trí 1. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv1Vt2)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 1, vị trí 2. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv1Vt3)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 1, vị trí 3. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv2Vt1)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 2, vị trí 1. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv2Vt2)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 2, vị trí 2. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv2Vt3)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 2, vị trí 3. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv3Vt1)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 3, vị trí 1. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv3Vt2)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 3, vị trí 2. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdPnnKv3Vt3)
            {
                result = string.Format("Đất sxkd tại nông thôn ({0}), thuộc xã loại {1}, khu vực 3, vị trí 3. Giá đất = {2}", _loaidat, _loaiXa, _cachTinhDonGia);
            }
            #endregion
            #endregion

            #region dat mat tien do thi
            else if (hsk == TnHeSoK.DatOMtTtDt)
            {
                result = string.Format("Đất ở đô thị ({0}), mặt tiền đường {1} (giá={2}) đoạn từ {3} đến {4}. Giá đất = {5}", _loaidat, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatChuaXacDinhDt)
            {
                result = string.Format("Đất chưa xác định vị trí tại đô thị ({0}), giá đất tối thiểu={1}. Giá đất = {2}", _loaidat, _config.GToiThieuDoThiLoai4, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdMatTienTronThuaDt)
            {
                result = string.Format("Đất sxkd tại đô thị ({0}) (hệ số ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _config.PGiaDatSxkddt, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatONnMatTienTronThuaDt)
            {
                result = string.Format("Đất ở tại đô thị có đất nông nghiệp ({0}) (giá đất nn ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatOMatTienHon50mDt)
            {
                result = string.Format("Đất ở đô thị ({0}), mặt tiền đường {1} (giá={2}) đoạn từ {3} đến {4}. Giá đất = {5}", _loaidat, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatONnMatTienHon50mDt)
            {
                result = string.Format("Đất ở tại đô thị có đất nông nghiệp ({0}) (giá đất nn ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinh);
            }
            else if (hsk == TnHeSoK.DatSxkdMatTienTronThuaDt)
            {
                result = string.Format("Đất sxkd tại đô thị ({0}) (hệ số ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _config.PGiaDatSxkddt, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion

            #region dat sau mat tien 50m do thi
            else if (hsk == TnHeSoK.DatOSauMatTien50mDt)
            {
                result = string.Format("Đất ở đô thị ({0}), sau 50m mặt tiền đường {1} (giá={2}) đoạn từ {3} đến {4}. Giá đất = {5}", _loaidat, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdSauMatTien50mDt)
            {
                result = string.Format("Đất sxkd tại đô thị ({0}) (hệ số ={1}), sau 50m mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _config.PGiaDatSxkddt, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatONnSauMatTien50m)
            {
                result = string.Format("Đất ở tại đô thị có đất nông nghiệp ({0}) (giá đất nn ={1}), sau 50m mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", _loaidat, _giadatNn, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinh);
            }
            #endregion

            #region dat hem chinh <100m
            else if (hsk == TnHeSoK.DatOHemChinhR6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} <100m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat,_tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemChinhR3mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} <100m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemChinhR3_6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} <100m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }

            else if (hsk == TnHeSoK.DatONnHemChinhR6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemChinhR3mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemChinhR3_6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR6mS100mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR3mS100mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR3_6mS100mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion

            #region dat hem chinh >100m,<200m
            else if (hsk == TnHeSoK.DatOHemChinhR6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} 100m-200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemChinhR3mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} 100_200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemChinhR3_6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} 100_200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }

            else if (hsk == TnHeSoK.DatONnHemChinhR6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemChinhR3mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemChinhR3_6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR6mS100_200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR3mS100_200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR3_6mS100_200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} 100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion

            #region dat hem chinh >200m
            else if (hsk == TnHeSoK.DatOHemChinhR6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} >200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemChinhR3mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} >200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemChinhR3_6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm chính ({1},rộng {2}m) \n cách đường {3} >200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }

            else if (hsk == TnHeSoK.DatONnHemChinhR6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemChinhR3mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemChinhR3_6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR6mS200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR3mS200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemChinhR3_6mS200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm chính ({2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion

            #region dat hem phu <100m
            else if (hsk == TnHeSoK.DatOHemPhuR6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} <100m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemPhuR3mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} <100m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemPhuR3_6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} <100m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }

            else if (hsk == TnHeSoK.DatONnHemPhuR6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemPhuR3mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemPhuR3_6mS100mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR6mS100mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR3mS100mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR3_6mS100mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion

            #region dat hem phu >100m,<200m
            else if (hsk == TnHeSoK.DatOHemPhuR6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} 100m-200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemPhuR3mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} 100_200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemPhuR3_6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} 100_200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }

            else if (hsk == TnHeSoK.DatONnHemPhuR6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemPhuR3mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm chính (của hẻm {2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemPhuR3_6mS100_200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR6mS100_200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR3mS100_200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} <100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR3_6mS100_200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} 100_200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion

            #region dat hem phu >200m
            else if (hsk == TnHeSoK.DatOHemPhuR6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} >200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemPhuR3mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} >200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatOHemPhuR3_6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị ({0}), trong hẻm phụ (của hẻm {1},rộng {2}m) \n cách đường {3} >200m (giá={4}) đoạn từ {5} đến {6}. Giá đất = {7}", _loaidat, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }

            else if (hsk == TnHeSoK.DatONnHemPhuR6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemPhuR3mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatONnHemPhuR3_6mS200mTronThua)
            {
                result = string.Format("Đất ở đô thị có đất nông nghiệp ({0}) (giá đất nn={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _giadatNn, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
                //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR6mS200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR3mS200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            else if (hsk == TnHeSoK.DatSxkdHemPhuR3_6mS200mTronThua)
            {
                result = string.Format("Đất sxkd đô thị ({0}) (Hệ số ={1}), trong hẻm phụ (của hẻm {2},rộng {3}m) \n cách đường {4} >200m (giá={5}) đoạn từ {6} đến {7}. Giá đất = {8}", _loaidat, _config.PGiaDatSxkddt, _tenHem, _dorongHem, _tenduong, _giaduong, _batdau, _ketthuc, _cachTinhDonGia);
            }
            #endregion
            return result;
        }
    }
}
