using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableName:ITnTableName
    {
        private IWorkspace _workspace;
        private static TnTableLoaiLopDulieu _tblLoaiLopDuLieu=new TnTableLoaiLopDulieu();
        private static string _loaiLayer = "loai_lop_dulieu";

        private static TnTableGiadatDuong _tblGiadatDuong;
        private static TnTableDuongThua _tblDuongThua;
        private static TnTableLoaiXa _tblLoaiXa;
        private static TnTableLoaiDat _tblLoaiDat;
        private static TnTableQuyDinh _tblQuyDinh = new TnTableQuyDinh();
        private static TnTableHemThuaCs _tblHemThuaCs;
        private static TnTableGiaDatONt _tblGiaDatONt;
        private static TnTableGiaDatNongNghiep _tblGiaDatNn;
        private static TnTableThuaNam _tblThuaNam;
        private static TnTableThuaSau50m _tblThuaSau50m;
        private static TnTableTgdPnnNt _tblTgdPnnNt;
        private static TnTableTgdPnnDt _tblTgdPnnDt;
        private static TnTableTgdNn _tblTgdNn;
        private static TnTableUsers _tblUsers;
        private static TnTableQdKtvhxh _tblQdKtvhxh;
        private static TnTableTenDuong _tblTenDuong;
        private static TnTableThuaGiaDat _tblThuaGiaDat;
        private static TnTableHesoVitri _tblHeSoViTri;
        private static TnTableThongSo _tblThongSo;
        //private static 
        TnTableLoaiLopDulieu ITnTableName.LOAI_LOP_DU_LIEU
        {
            get { return _tblLoaiLopDuLieu; }
        }

        TnTableUsers ITnTableName.USERS { get { _tblUsers = TnTableUsers.GetMe(_workspace); return _tblUsers; } }
        TnTableQdKtvhxh ITnTableName.QD_KTVHXH { get { _tblQdKtvhxh = TnTableQdKtvhxh.GetMe(_workspace); return _tblQdKtvhxh; } }
        TnTableGiadatDuong ITnTableName.GIA_DAT_DUONG { get { _tblGiadatDuong = TnTableGiadatDuong.GetMe(_workspace); return _tblGiadatDuong; } }
        TnTableDuongThua ITnTableName.DUONG_THUA { get { _tblDuongThua = TnTableDuongThua.GetMe(_workspace); return _tblDuongThua; } }
        TnTableLoaiXa ITnTableName.LOAI_XA { get { _tblLoaiXa = TnTableLoaiXa.GetMe(_workspace); return _tblLoaiXa; } }
        TnTableLoaiDat ITnTableName.LOAI_DAT { get { _tblLoaiDat = TnTableLoaiDat.GetMe(_workspace); return _tblLoaiDat; } }
        TnTableQuyDinh ITnTableName.QUY_DINH { get { return _tblQuyDinh; } }
        TnTableHemThuaCs ITnTableName.HEM_THUA_CHIEUSAU { get { _tblHemThuaCs = TnTableHemThuaCs.GetMe(_workspace); return _tblHemThuaCs; } }
        TnTableGiaDatONt ITnTableName.GIA_DAT_O_NONGTHON { get { _tblGiaDatONt = TnTableGiaDatONt.GetMe(_workspace); return _tblGiaDatONt; } }
        TnTableGiaDatNongNghiep ITnTableName.GIA_DAT_NONGNGHIEP { get { _tblGiaDatNn = TnTableGiaDatNongNghiep.GetMe(_workspace); return _tblGiaDatNn; } }
        TnTableThuaNam ITnTableName.THUA_NAM { get { _tblThuaNam = TnTableThuaNam.GetMe(_workspace); return _tblThuaNam; } }
        TnTableThuaSau50m ITnTableName.THUA_SAU_50M { get { _tblThuaSau50m = TnTableThuaSau50m.GetMe(_workspace); return _tblThuaSau50m; } }
        TnTableTgdPnnNt ITnTableName.THUA_GIADAT_PNN_NONGTHON { get { _tblTgdPnnNt = TnTableTgdPnnNt.GetMe(_workspace); return _tblTgdPnnNt; } }
        TnTableTgdPnnDt ITnTableName.THUA_GIADAT_PNN_DOTHI { get { _tblTgdPnnDt = TnTableTgdPnnDt.GetMe(_workspace); return _tblTgdPnnDt; } }
        TnTableTgdNn ITnTableName.THUA_GIADAT_NN { get { _tblTgdNn = TnTableTgdNn.GetMe(_workspace); return _tblTgdNn; } }
        TnTableTenDuong ITnTableName.TEN_DUONG { get { _tblTenDuong = TnTableTenDuong.GetMe(_workspace); return _tblTenDuong; } }
        TnTableThuaGiaDat ITnTableName.THUA_GIADAT { get { _tblThuaGiaDat = TnTableThuaGiaDat.GetMe(_workspace); return _tblThuaGiaDat; } }
        TnTableHesoVitri ITnTableName.HESO_VITRI { get { _tblHeSoViTri = TnTableHesoVitri.GetMe(_workspace); return _tblHeSoViTri; } }
        TnTableThongSo ITnTableName.THONG_SO { get { _tblThongSo = TnTableThongSo.GetMe(_workspace); return _tblThongSo; } }
        //public static string LOAI_LOP_DULIEU
        //{
        //    get { return TnTableName._loaiLayer; }
        //    set { if (_loaiLayer == value) return; TnTableName._loaiLayer = value; }
        //}

        public TnTableName(IWorkspace workspace)
        {
            _workspace = workspace;
            
            
            
            
            
            //_tblDuongThua.InitIndex();
            //_tblTgdPnnDt.InitIndex();
        }
    }
}
