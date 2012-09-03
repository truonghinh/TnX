using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TNPro.Danhmuc
{
    class TnListLayers4Calc
    {
        private static TnListLayers4Calc meClass = new TnListLayers4Calc();
        //featureclass
        private string _thua = "thixa_thua";
        private string _duong = "thixa_duong";
        private string _xa = "thixa_xapoly";
        private string _xaLine = "thixa_xaline";
        private string _hem = "thixa_hem";
        private string _hemChinh = "thixa_hem_hemchinh";
        private string _ktvhxh = "thixa_ktvhxh";
        //table
        private string _duongThua = "duong_thua";
        private string _giaDatDuong = "giadatduong";
        private string _giaDatNongNghiep = "giadatnongnghiep";
        private string _giaDatONongThon = "giadatonongthon";

        private string _duong_buffer_1m = "thixa_duong_buffer_1m";
        private string _duong_buffer_50m = "thixa_duong_buffer_50m";
        private string _duong_buffer_100m = "thixa_duong_buffer_100m";
        private string _duong_buffer_200m = "thixa_duong_buffer_200m";
        private string _hem_buffer_1m = "thixa_hem_buffer_1m";
        private string _hem_layer_buffer_1m = "thixa_hem_layer_buffer_1m";
        private string _hem_buffer_1m_crt_frm_layer = "thixa_hem_buffer_1m_selected";
        
        
        private string[,] _listLayers;

        public static TnListLayers4Calc CallMe
        {
            get { return meClass; }
        }

        public string Thua
        {
            get { return _thua; }
            set { _thua = value; }
        }

        public string Duong
        {
            get { return _duong; }
            set { _duong = value; }
        }

        public string Hem
        {
            get { return _hem; }
            set { _hem = value; }
        }

        public string Xa
        {
            get { return _xa; }
            set { _xa = value; }
        }

        public string Ktvhxh
        {
            get { return _ktvhxh; }
            set { _ktvhxh = value; }
        }

        public string DUONG_BUFFER_1M { get { return _duong_buffer_1m; } set { _duong_buffer_1m = value; } }
        public string DUONG_BUFFER_50M { get { return _duong_buffer_50m; } set { _duong_buffer_50m = value; } }
        public string DUONG_BUFFER_100M { get { return _duong_buffer_100m; } set { _duong_buffer_100m = value; } }
        public string DUONG_BUFFER_200M { get { return _duong_buffer_200m; } set { _duong_buffer_200m = value; } }

        public string HEM_BUFFER_1M { get { return _hem_buffer_1m; } set { _hem_buffer_1m = value; } }
        public string HEM_LAYER_BUFFER_1M { get { return _hem_layer_buffer_1m; } set { _hem_layer_buffer_1m = value; } }
        public string HEM_BUFFER_1M_CREATED_FROM_LAYER { get { return _hem_buffer_1m_crt_frm_layer; } set { _hem_buffer_1m_crt_frm_layer = value; } }

        public void SetLayers(string[,] layers)
        {
            _listLayers = layers;
            _thua = _listLayers[0, 1];
            _duong = _listLayers[1, 1];
            _hem = _listLayers[2, 1];
            _duong_buffer_1m = _listLayers[3, 1];
            _duong_buffer_50m = _listLayers[4, 1];
            _duong_buffer_100m = _listLayers[5, 1];
            _duong_buffer_200m = _listLayers[6, 1];
            _hem_buffer_1m = _listLayers[7, 1];
            _hem_layer_buffer_1m = _listLayers[8, 1];
            _hem_buffer_1m_crt_frm_layer = _listLayers[9, 1];
        }

        public void SetLayers(string thua_dat,string duong_gt,string hem,string xa,string ktvhxh)
        {
            //_listLayers = layers;
            _thua = thua_dat;
            _duong = duong_gt;
            _hem = hem;
            _ktvhxh = ktvhxh;
            
        }

        public string[,] GetLayers()
        {
            if (_thua.Equals(String.Empty) || _duong.Equals(String.Empty) || _hem.Equals(String.Empty))
                return null;
            _listLayers = new string[,] {{"thua",_thua},{"duong",_duong},{"hem",_hem},{"duong_buffer_1m",_duong_buffer_1m},
            {"duong_buffer_50m",_duong_buffer_50m},{"duong_buffer_100m",_duong_buffer_100m},{"duong_buffer_200m",_duong_buffer_200m},
            {"hem_buffer_1m",_hem_buffer_1m},{"hem_layer_buffer_1m",_hem_layer_buffer_1m},{"hem_buffer_1m_crt_frm_layer",_hem_buffer_1m_crt_frm_layer}};
            return _listLayers;
        }
    }
}
