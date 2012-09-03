using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableGiaDatONt:TnGeoDatabaseObject
    {
        private static TnTableGiaDatONt meClass = null;

        private string _colMaLoaiXa = "loaixa";
        //private string _colMlxKvx = "malx_kvx";
        private string _colGhiChu = "ghichu";
        private string _colMaKhuVuc = "khuvuc";
        private string _colViTri = "vitri";
        private string _colMaLoaiDat = "maloaidat";
        private string _colGiaDat = "giadat";

        public static TnTableGiaDatONt GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableGiaDatONt(workspace);
            }
            return meClass;
        }

        private TnTableGiaDatONt(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Gia_Dat_Pnn_Nongthon;

            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        public string MA_LOAI_XA { get { return _colMaLoaiXa; } set { _colMaLoaiXa = value; onColNameChanged(value); } }
        //public string MA_LX_KVX { get { return _colMlxKvx; } set { _colMlxKvx = value; onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string MA_KHU_VUC { get { return _colMaKhuVuc; } set { _colMaKhuVuc = value; onColNameChanged(value); } }
        public string VI_TRI { get { return _colViTri; } set { _colViTri = value; onColNameChanged(value); } }
        public string MA_LOAI_DAT { get { return _colMaLoaiDat; } set { _colMaLoaiDat = value; onColNameChanged(value); } }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value); } }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaLoaiXa));
            //_lstColWithIndex.Add(new TnColWithIndexPair(3, _colMlxKvx));
            //_lstColWithIndex.Add(new TnColWithIndexPair(4, _colNamApDung));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colMaKhuVuc));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colViTri));
            _lstColWithIndex.Add(new TnColWithIndexPair(7, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(8, _colMaLoaiDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colGhiChu));
        }

        protected override void setAliasFieldsName()
        {
            
            _fieldList.Add(new string[,] { { _colMaLoaiDat, "Loại đất" } });
            _fieldList.Add(new string[,] { { _colViTri, "Vị trí" } });
            _fieldList.Add(new string[,] { { _colMaKhuVuc, "Khu vực" } });
            _fieldList.Add(new string[,] { { _colGiaDat, "Giá đất" } });
            _fieldList.Add(new string[,] { { _colMaLoaiXa, "Loại xã" } });
            _fieldList.Add(new string[,] { { _colGhiChu, "Ghi chú" } });
        }
    }
}
