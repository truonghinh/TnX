using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.connection;

namespace gov.tn
{
    public class TnThuaInfo
    {
        private ITnTableName _tableName;
        private ITnFeatureClassName _fcName;
        #region member
        private string _chuSoHuu;

        public string ChuSoHuu
        {
            get { return _chuSoHuu; }
            set { _chuSoHuu = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _soTo;

        public string SoTo
        {
            get { return _soTo; }
            set { _soTo = value; }
        }
        private string _soThua;

        public string SoThua
        {
            get { return _soThua; }
            set { _soThua = value; }
        }
        private string _loaiDat;

        public string LoaiDat
        {
            get { return _loaiDat; }
            set { _loaiDat = value; }
        }
        private string _soMatTien;

        public string SoMatTien
        {
            get { return _soMatTien; }
            set { _soMatTien = value; }
        }
        private string _soMatHem;

        public string SoMatHem
        {
            get { return _soMatHem; }
            set { _soMatHem = value; }
        }
        private string _giaDat;

        public string GiaDat
        {
            get { return _giaDat; }
            set { _giaDat = value; }
        }
        private string _nam;

        public string Nam
        {
            get { return _nam; }
            set { _nam = value; }
        }
        private string _soCachTinh;

        public string SoCachTinh
        {
            get { return _soCachTinh; }
            set { _soCachTinh = value; }
        }
        private string _cachTinh;

        public string CachTinh
        {
            get { return _cachTinh; }
            set { _cachTinh = value; }
        }
        #endregion

        #region sql
        public string ChuSoHuuSql
        {
            get { if (_chuSoHuu != "")return string.Format("{0}={1}",_fcName.FC_THUA.TEN_CHU,_chuSoHuu); else return ""; }

        }

        public string DiaChiSql
        {
            get { if (_diaChi != "")return string.Format("{0}={1}", _fcName.FC_THUA.DIA_CHI, _diaChi); else return ""; }
            set { _diaChi = value; }
        }

        public string SoToSql
        {
            get { if (_soTo != "")return string.Format("{0}={1}", _fcName.FC_THUA.SO_TO, _soTo); else return ""; }

        }

        public string SoThuaSql
        {
            get { if (_soThua != "")return string.Format("{0}={1}", _fcName.FC_THUA.SO_THUA, _soThua); else return ""; }

        }

        public string LoaiDatSql
        {
            get { if (_loaiDat != "")return string.Format("{0}={1}", _fcName.FC_THUA.LOAI_DAT, _loaiDat); else return ""; }

        }

        public string SoMatTienSql
        {
            get { if (_soMatTien != "")return string.Format("{0}={1}", _tableName.THUA_GIADAT_PNN_DOTHI.SO_MAT_TIEN, _soMatTien); else return ""; }

        }

        public string SoMatHemSql
        {
            get { if (_soMatHem != "")return string.Format("{0}={1}", _tableName.THUA_GIADAT_PNN_DOTHI.SO_MAT_HEM, _soMatHem); else return ""; }
        }

        public string GiaDatSql
        {
            get { if (_giaDat != "")return string.Format("{0}={1}", _tableName.THUA_GIADAT_PNN_DOTHI.GIA_DAT, _giaDat); else return ""; }

        }

        public string NamSql
        {
            get { if (_nam != "")return string.Format("{0}={1}", "nam", _nam); else return ""; }
        }

        public string SoCachTinhSql
        {
            get { if (_soCachTinh != "")return string.Format("{0}={1}", _tableName.THUA_GIADAT_PNN_DOTHI.SO_CACH_TINH, _soCachTinh); else return ""; }
        }

        public string CachTinhSql
        {
            get { if (_cachTinh != "")return string.Format("{0}={1}", _tableName.THUA_GIADAT_PNN_DOTHI.CACH_TINH, _cachTinh); else return ""; }
        }
        #endregion

        public TnThuaInfo() { }
        public TnThuaInfo(string nam, string chusohuu, string diachi, string loaidat, string giadat,
            string soto, string sothua, string somattien,string somathem, string socachtinh)
        {
            //*************
            //Lay connection info hien tai
            //SdeUserInfo va SqlUserInfo la static
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            _tableName = new TnTableName(sdeConn.Workspace);
            _fcName = new TnFeatureClassName(sdeConn.Workspace);

            _nam = nam;
            _chuSoHuu = chusohuu;
            _diaChi = diachi;
            _loaiDat = loaidat;
            _giaDat = giadat;
            _soTo = soto;
            _soThua = sothua;
            _soMatTien = somattien;
            _soMatHem = somathem;
            _soCachTinh = socachtinh;
        }

        //public TnThuaInfo(): this("", "", "", "", "", "", "", "", "", "") { }
        public TnThuaInfo(string nam) : this(nam, "", "", "", "", "", "", "", "", "") { }
        public TnThuaInfo(string nam,string chusohuu) : this(nam, chusohuu, "", "", "", "", "", "", "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi) : this(nam, chusohuu, diachi, "", "", "", "", "", "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi,string loaidat) : this(nam, chusohuu, diachi, loaidat, "", "", "", "", "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi, string loaidat,string giadat) : this(nam, chusohuu, diachi, loaidat, giadat, "", "", "", "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi, string loaidat, string giadat, string soto) : this(nam, chusohuu, diachi, loaidat,giadat, soto, "", "", "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi, string loaidat, string giadat, string soto, string sothua) : this(nam, chusohuu, diachi, loaidat, giadat, soto, sothua,  "", "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi, string loaidat, string giadat, string soto, string sothua, string somattien) : this(nam, chusohuu, diachi, loaidat, giadat, soto, sothua, somattien, "", "") { }
        public TnThuaInfo(string nam, string chusohuu, string diachi, string loaidat, string giadat, string soto, string sothua, string somattien, string somathem) : this(nam, chusohuu, diachi, loaidat, giadat, soto, sothua, somattien, somathem, "") { }
    }
}
