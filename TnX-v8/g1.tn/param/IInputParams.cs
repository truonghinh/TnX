using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace g1.tn.param
{
    public interface IInputParams
    {
        string MA_XA { get; set; }
        string TEN_DUONG { get; set; }
        string MA_DUONG { get; set; }
        object MA_THUA_RIENG_LE { get; set; }
        string[] MA_THUA_ARRAY { get; set; }
        string[] LOAI_DAT { get; set; }
        bool OVER_WRITE_ATT { get; set; }
        double BUFFER_DISTANCE_MAT_TIEN { get; set; }
        double BUFFER_DISTANCE_50M { get; set; }
        double BUFFER_DISTANCE_100M { get; set; }
        double BUFFER_DISTANCE_200M { get; set; }
        ICurrentConfig CURRENT_CONFIG { get; set; }
        object He_SO_VI_TRI { get; set; }
        object OID_THUA_RIENG_LE { get; set; }
        /// <summary>
        /// Thong so cho biet trang thai tinh
        /// <para>0:tinh cho cac thua theo duong</para>
        /// <para>1:Da biet hsk, chi tinh gia</para>
        /// <para>2:chua biet hsk, da biet cac thong tin khac,tim hsk va tinh gia</para>
        /// </summary>
        int TINH_THUA_RIENG_LE { get; set; }
    }
}
