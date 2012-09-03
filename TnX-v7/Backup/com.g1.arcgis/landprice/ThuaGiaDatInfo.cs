using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.landprice
{
    public class ThuaGiaDatInfo
    {
        private object _oid;

        public object Oid
        {
            get { return _oid; }
            set { _oid = value; }
        }
        private object _mathua;

        public object Mathua
        {
            get { return _mathua; }
            set { _mathua = value; }
        }
        private object _maduong;

        public object Maduong
        {
            get { return _maduong; }
            set { _maduong = value; }
        }
        private object _mahem;

        public object Mahem
        {
            get { return _mahem; }
            set { _mahem = value; }
        }
        private object _maktvhxh;

        public object Maktvhxh
        {
            get { return _maktvhxh; }
            set { _maktvhxh = value; }
        }
        private object _makhudc;

        public object Makhudc
        {
            get { return _makhudc; }
            set { _makhudc = value; }
        }
        private object _mattx;

        public object Mattx
        {
            get { return _mattx; }
            set { _mattx = value; }
        }
        private object _hesovitri;

        public object Hesovitri
        {
            get { return _hesovitri; }
            set { _hesovitri = value; }
        }
        private object _dongia;

        public object Dongia
        {
            get { return _dongia; }
            set { _dongia = value; }
        }
        private object _giadat;

        public object Giadat
        {
            get { return _giadat; }
            set { _giadat = value; }
        }
        private object _dientich;

        public object Dientich
        {
            get { return _dientich; }
            set { _dientich = value; }
        }
        private object _dientichpl;

        public object Dientichpl
        {
            get { return _dientichpl; }
            set { _dientichpl = value; }
        }
        private object _somattien;

        public object Somattien
        {
            get { return _somattien; }
            set { _somattien = value; }
        }
        private object _somathem;

        public object Somathem
        {
            get { return _somathem; }
            set { _somathem = value; }
        }
        private object _cachtinh;

        public object Cachtinh
        {
            get { return _cachtinh; }
            set { _cachtinh = value; }
        }
        private object _socachtinh;

        public object Socachtinh
        {
            get { return _socachtinh; }
            set { _socachtinh = value; }
        }
        private object _ghichu;

        public object Ghichu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }

        private object _khoagia;

        public object Khoagia
        {
            get { return _khoagia; }
            set { 
                _khoagia = value;
                if (_khoagia != null)
                {
                    if ((int)Khoagia == 0)
                    {
                        _khoagiaTudong= 0;
                        _khoagiaTay = 0;
                    }
                    else if ((int)Khoagia == 1)
                    {
                        _khoagiaTudong = 1;
                        _khoagiaTay = 0;
                    }
                    else
                    {
                        _khoagiaTudong = 1;
                        _khoagiaTay = 1;
                    }
                }
            }
        }
        private object _khoagiaTudong;

        public object KhoagiaTudong
        {
            get {return _khoagiaTudong; }
            //set { _khoagiaTudong = value; }
        }
        private object _khoagiaTay;

        public object KhoagiaTay
        {
            get { return _khoagiaTay; }
            //set { _khoagiaTay = value; }
        }

        private object _khoavitri;

        public object KhoaVitri
        {
            get { return _khoavitri; }
            set { _khoavitri = value; }
        }

    }
}
