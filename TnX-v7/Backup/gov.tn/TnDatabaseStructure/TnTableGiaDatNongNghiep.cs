using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace gov.tn.TnDatabaseStructure
{
    public class TnTableGiaDatNongNghiep:TnGeoDatabaseObject
    {
        private static TnTableGiaDatNongNghiep meClass = null;
        private string _colMaLoaiXa = "loaixa";
        //private string _colNamApDung = "namapdung";
        private string _colViTri = "vitri";
        private string _colMaLoaiDat = "maloaidat";
        private string _colGiaDat = "giadat";
        private string _colGhiChu = "ghichu";

        public string MA_LOAI_XA { get { return _colMaLoaiXa; } set { _colMaLoaiXa = value;onColNameChanged(value); } }
        public string GHI_CHU { get { return _colGhiChu; } set { _colGhiChu = value; onColNameChanged(value); } }
        public string VI_TRI { get { return _colViTri; } set { _colViTri = value; onColNameChanged(value);} }
        public string MA_LOAI_DAT { get { return _colMaLoaiDat; } set { _colMaLoaiDat = value; onColNameChanged(value);} }
        public string GIA_DAT { get { return _colGiaDat; } set { _colGiaDat = value; onColNameChanged(value);} }

        public static TnTableGiaDatNongNghiep GetMe(IWorkspace workspace)
        {
            if (meClass == null)
            {
                meClass = new TnTableGiaDatNongNghiep(workspace);
            }
            return meClass;
        }

        private TnTableGiaDatNongNghiep(IWorkspace workspace)
            : base(workspace)
        {
            _name = DataNameTemplate.Gia_Dat_Nongnghiep;
            //_table = _featureWorkspace.OpenTable(_name);
            iniObject();
            InitIndex();
            setAliasFieldsName();
        }

        protected override void iniObject()
        {
            base.iniObject();
            _lstColWithIndex.Add(new TnColWithIndexPair(2, _colMaLoaiDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(3, _colMaLoaiXa));
            _lstColWithIndex.Add(new TnColWithIndexPair(4, _colGhiChu));
            _lstColWithIndex.Add(new TnColWithIndexPair(5, _colGiaDat));
            _lstColWithIndex.Add(new TnColWithIndexPair(6, _colViTri));
        }

        protected override void setAliasFieldsName()
        {
            
            this._fieldList.Add(new string[,] { { "maloaidat", "Loại đất" } });
            this._fieldList.Add(new string[,] { { "vitri", "Vị trí" } });
            this._fieldList.Add(new string[,] { { "giadat", "Giá đất" } });
            this._fieldList.Add(new string[,] { { "loaixa", "Loại xã" } });  
            this._fieldList.Add(new string[,] { { "ghichu", "Ghi Chú" } });
        }
    }
}
