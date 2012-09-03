using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public interface ITnTableName
    {
        TnTableLoaiLopDulieu LOAI_LOP_DU_LIEU { get; }
        TnTableUsers USERS { get; }
        TnTableQdKtvhxh QD_KTVHXH { get; }
        TnTableGiadatDuong GIA_DAT_DUONG { get; }
        TnTableDuongThua DUONG_THUA { get; }
        TnTableLoaiXa LOAI_XA { get; }
        TnTableLoaiDat LOAI_DAT { get; }
        TnTableQuyDinh QUY_DINH { get; }
        TnTableHemThuaCs HEM_THUA_CHIEUSAU { get; }
        TnTableGiaDatONt GIA_DAT_O_NONGTHON { get; }
        TnTableGiaDatNongNghiep GIA_DAT_NONGNGHIEP { get; }
        TnTableThuaNam THUA_NAM { get; }
        TnTableThuaSau50m THUA_SAU_50M { get; }
        TnTableTgdPnnNt THUA_GIADAT_PNN_NONGTHON { get; }
        TnTableTgdPnnDt THUA_GIADAT_PNN_DOTHI { get; }
        TnTableTgdNn THUA_GIADAT_NN { get; }
        TnTableTenDuong TEN_DUONG { get; }
        TnTableThuaGiaDat THUA_GIADAT { get; }
        TnTableHesoVitri HESO_VITRI { get; }
        TnTableThongSo THONG_SO { get; }
        
    }
}
