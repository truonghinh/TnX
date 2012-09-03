using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.query
{
    public interface IInfoForQuerySql
    {
        string MaThuaSql { get; set; }
        string ChuSoHuuSql { get; set; }
        string DiaChiSql { get; set; }
        string SoToSql { get; set; }
        string SoThuaSql { get; set; }
        string LoaiDatSql { get; set; }
        string SoMatTienSql { get; set; }
        string SoMatHemSql { get; set; }
        string NamSql { get; set; }
        string SoCachTinhsql { get; set; }
        string CachTinhSql { get; set; }
        string DienTichSql { get; set; }
        string XaSql { get; set; }
        string ViTriSql { get; set; }
        string KhuVucSql { get; set; }
        string GiaDatSql { get; set; }
    }
}
