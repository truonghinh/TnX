using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.query
{
    public interface IInfoForQuery
    {
        #region member

        string MaThua { get; set; }
        string ChuSoHuu { get; set; }
        string DiaChi{ get; set; }
        string SoTo{ get; set; }
        string SoThua{ get; set; }
        string LoaiDat{ get; set; }
        string SoMatTien{ get; set; }
        string SoMatHem{ get; set; }
        string Nam{ get; set; }
        string SoCachTinh{ get; set; }
        string CachTinh { get; set; }
        string DienTich { get; set; }
        string Xa { get; set; }
        string ViTri { get; set; }
        string KhuVuc { get; set; }
        string GiaDat { get; set; }
        void SetWorkspace(IWorkspace wsp);
        #endregion
    }
}
