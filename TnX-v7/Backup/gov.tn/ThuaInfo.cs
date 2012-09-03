using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.query;
using gov.tn.TnDatabaseStructure;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn
{
    public class ThuaInfo:IInfoForQuery,IInfoForQuerySql
    {
        #region member
        private ITnTableName _tableName;
        private ITnFeatureClassName _fcName;
        private IWorkspace _wsp;

        private string _mathua;
        private string _chuSoHuu;
        private string _diaChi;
        private string _soTo;
        private string _soThua;
        private string _loaiDat;
        private string _soMatTien;
        private string _soMatHem;
        private string _nam;
        private string _soCachTinh;
        private string _giaDat;
        private string _cachTinh;
        private string _viTri;
        private string _khuVuc;
        private string _dientich;
        private string _xa;
        #endregion

        public ThuaInfo() : this(null) { }
        public ThuaInfo(IWorkspace wsp)
        {
            if (wsp != null)
            {
                _fcName = new TnFeatureClassName(wsp);
                _tableName = new TnTableName(wsp);
            }
        }

        #region IInfoForQuery Members

        string IInfoForQuery.MaThua
        {
            get { return _mathua; }
            set { _mathua = value; }
        }

        string IInfoForQuery.CachTinh
        {
            get { return _cachTinh; }
            set { _cachTinh = value; }
        }

        string IInfoForQuery.ChuSoHuu
        {
            get { return _chuSoHuu; }
            set { _chuSoHuu = value; }
        }

        string IInfoForQuery.DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        string IInfoForQuery.DienTich
        {
            get { return _dientich; }
            set { _dientich = value; }
        }

        string IInfoForQuery.KhuVuc
        {
            get { return _khuVuc; }
            set { _khuVuc = value; }
        }

        string IInfoForQuery.LoaiDat
        {
            get { return _loaiDat; }
            set { _loaiDat = value; }
        }

        string IInfoForQuery.Nam
        {
            get { return _nam; }
            set { _nam = value; }
        }

        string IInfoForQuery.SoCachTinh
        {
            get { return _soCachTinh; }
            set { _soCachTinh = value; }
        }

        string IInfoForQuery.SoMatHem
        {
            get { return _soMatHem; }
            set { _soMatHem = value; }
        }

        string IInfoForQuery.SoMatTien
        {
            get { return _soMatTien; }
            set { _soMatTien = value; }
        }

        string IInfoForQuery.SoThua
        {
            get { return _soThua; }
            set { _soThua = value; }
        }

        string IInfoForQuery.SoTo
        {
            get { return _soTo; }
            set { _soTo = value; }
        }

        string IInfoForQuery.ViTri
        {
            get { return _viTri; }
            set { _viTri = value; }
        }

        string IInfoForQuery.Xa
        {
            get { return _xa; }
            set { _xa = value; }
        }

        string IInfoForQuery.GiaDat
        {
            get { return _giaDat; }
            set { _giaDat = value; }
        }

        #endregion

        #region IInfoForQuerySql Members

        string IInfoForQuerySql.CachTinhSql
        {
            get
            {
                if (_cachTinh != "")
                {
                    return string.Format("{0} like N'%{1}%'", _tableName.THUA_GIADAT_NN.CACH_TINH, _cachTinh);
                }
                else
                {
                    return "";
                }

            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.ChuSoHuuSql
        {
            get
            {
                if (_chuSoHuu != "")
                {
                    return string.Format("{0} like N'%{1}%'", _fcName.FC_THUA.TEN_CHU, _chuSoHuu);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.DiaChiSql
        {
            get
            {
                if (_diaChi != "")
                {
                    return string.Format("{0} like N'%{1}%'", _fcName.FC_THUA.DIA_CHI, _diaChi);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //chu y dien tich dau so sanh da o trong _dientich
        string IInfoForQuerySql.DienTichSql
        {
            get
            {
                if (_dientich != "")
                {
                    return string.Format("{0}{1}", _fcName.FC_THUA.DIEN_TICH, _dientich);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.GiaDatSql
        {
            get
            {
                if (_giaDat != "")
                {
                    return string.Format("{0}{1}", _tableName.THUA_GIADAT_NN.GIA_DAT, _giaDat);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.KhuVucSql
        {
            get
            {
                if (_khuVuc != "")
                {
                    return string.Format("{0}='{1}'", _tableName.THUA_GIADAT_PNN_NONGTHON.MA_KHU_VUC, _khuVuc);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.LoaiDatSql
        {
            get
            {
                if (_loaiDat != "")
                {
                    return string.Format("{0}='{1}'", _fcName.FC_THUA.LOAI_DAT, _loaiDat);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.NamSql
        {
            get
            {
                if (_nam != "")
                {
                    return string.Format("{0}='{1}'", _tableName.THUA_GIADAT_NN.NAM_AP_DUNG, _nam);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.SoCachTinhsql
        {
            get
            {
                if (_soCachTinh != "")
                {
                    return string.Format("{0}='{1}'", _tableName.THUA_GIADAT_NN.SO_CACH_TINH, _soCachTinh);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.SoMatHemSql
        {
            get
            {
                if (_soMatHem != "")
                {
                    return string.Format("{0}{1}", _tableName.THUA_GIADAT_PNN_DOTHI.SO_MAT_HEM, _soMatHem);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.SoMatTienSql
        {
            get
            {
                if (_soMatTien != "")
                {
                    return string.Format("{0}{1}", _tableName.THUA_GIADAT_PNN_DOTHI.SO_MAT_TIEN, _soMatTien);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.SoThuaSql
        {
            get
            {
                if (_soThua != "")
                {
                    return string.Format("{0}='{1}'", _fcName.FC_THUA.SO_THUA, _soThua);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.SoToSql
        {
            get
            {
                if (_soTo != "")
                {
                    return string.Format("{0}='{1}'", _fcName.FC_THUA.SO_TO, _soTo);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.ViTriSql
        {
            get
            {
                if (_viTri != "")
                {
                    return string.Format("{0}='{1}'", _tableName.THUA_GIADAT_NN.VI_TRI, _viTri);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IInfoForQuerySql.XaSql
        {
            get
            {
                if (_xa != "")
                {
                    return string.Format("{0} like N'%{1}%'", _fcName.FC_RANH_XA_POLY.TEN_XA, _xa);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IInfoForQuery Members


        void IInfoForQuery.SetWorkspace(IWorkspace wsp)
        {
            this._wsp=wsp;
            this._fcName = new TnFeatureClassName(wsp);
            this._tableName = new TnTableName(wsp);
        }

        #endregion

        #region IInfoForQuerySql Members


        string IInfoForQuerySql.MaThuaSql
        {
            get
            {
                if (_mathua != "")
                {
                    return string.Format("{0} like '%{1}%'", _fcName.FC_THUA.MA_THUA, _mathua);
                }
                else
                {
                    return "";
                }
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
