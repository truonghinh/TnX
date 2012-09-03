using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.tn.config
{
    public class InputParams:IParams,IInputParams
    {
        private static InputParams meClass = null;
        private ICurrentConfig conf;
        //private string _nam = "2011";
        private string _maxa = "1";
        private string _tenduong = "";
        private string _maduong = "";
        private string[] _mathuaArr = null;
        private object _mathuaRiengle = "";
        private string[] _loaidat = null;
        private bool _overwriteAtt = false;
        private double _bufferDistanceMatTien = 1;
        private double _bufferDistance50m = 50;
        private double _bufferDistance100m = 100;
        private double _bufferDistance200m = 200;
        private object _hesok;
        private int _isTinhThuaRiengLe=0;
        private object _oidThuaRiengLe;

        //public string NAM { get { return _nam; } set { _nam = value; } }
        string IInputParams.MA_XA { get { return _maxa; } set { _maxa = value; } }
        string IInputParams.TEN_DUONG { get { return _tenduong; } set { _tenduong = value; } }
        string IInputParams.MA_DUONG { get { return _maduong; } set { _maduong = value; } }
        object IInputParams.MA_THUA_RIENG_LE { get { return _mathuaRiengle; } set { _mathuaRiengle = value; } }
        string[] IInputParams.MA_THUA_ARRAY { get { return _mathuaArr; } set { _mathuaArr = value; } }
        string[] IInputParams.LOAI_DAT { get { return _loaidat; } set { _loaidat = value; } }
        bool IInputParams.OVER_WRITE_ATT { get { return _overwriteAtt; } set { _overwriteAtt = value; } }
        double IInputParams.BUFFER_DISTANCE_MAT_TIEN { get { return _bufferDistanceMatTien; } set { _bufferDistanceMatTien = value; } }
        double IInputParams.BUFFER_DISTANCE_50M { get { return _bufferDistance50m; } set { _bufferDistance50m = value; } }
        double IInputParams.BUFFER_DISTANCE_100M { get { return _bufferDistance100m; } set { _bufferDistance100m = value; } }
        double IInputParams.BUFFER_DISTANCE_200M { get { return _bufferDistance200m; } set { _bufferDistance200m = value; } }
        ICurrentConfig IInputParams.CURRENT_CONFIG { get { return conf; } set { conf = value; } }

        public static InputParams CallMe()
        {
            if (meClass == null)
            {
                meClass = new InputParams();
            }
            return meClass;
        }
        private InputParams() { conf = CurrentConfig.CallMe() as ICurrentConfig; }



        #region IParams Members

        IInputParams IParams.GetInputParams()
        {
            return (IInputParams)this;
        }

        ICurrentConfig IParams.GetCurrentConfig()
        {
            return conf;
        }

        #endregion



        #region IInputParams Members


        object IInputParams.He_SO_VI_TRI
        {
            get
            {
                return _hesok;
            }
            set
            {
                _hesok = value;
            }
        }

        #endregion

        #region IInputParams Members


        int IInputParams.TINH_THUA_RIENG_LE
        {
            get
            {
                return _isTinhThuaRiengLe;
            }
            set
            {
                _isTinhThuaRiengLe = value;
            }
        }

        #endregion

        #region IInputParams Members


        object IInputParams.OID_THUA_RIENG_LE
        {
            get
            {
                return _oidThuaRiengLe;
            }
            set
            {
                _oidThuaRiengLe = value;
            }
        }

        #endregion
    }
}
