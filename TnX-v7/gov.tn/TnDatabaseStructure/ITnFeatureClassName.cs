using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.tn.TnDatabaseStructure
{
    public interface ITnFeatureClassName
    {
        TnFcDuong FC_DUONG { get; }
        TnFcThua FC_THUA { get; }
        TnFcHem FC_HEM { get; }
        TnFcRanhXaPoly FC_RANH_XA_POLY { get; }
        TnFcRanhXaLine FC_RANH_XA_LINE { get; }
        TnFcKtvhxh FC_KTVHXH { get; }
        TnFcThuaGiaDat FC_THUA_GIADAT { get; }
        TnFcThuaGiaDatDraft FC_THUA_GIADAT_DRAFT { get; }
        TnFcTrungTamXa FC_TRUNG_TAM_XA { get; }
        TnFcDuongChinhNongThon FC_DUONG_CHINH_NONG_THON { get; }
        TnFcGiaDatHem FC_GIA_DAT_HEM { get; }
        TnFcGiaDatHemPhu FC_GIA_DAT_HEM_PHU { get; }
    }
}
