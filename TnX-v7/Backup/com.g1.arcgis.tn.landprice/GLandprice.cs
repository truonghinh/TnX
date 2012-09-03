using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.landprice;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.calculation;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using gov.tn;
using com.g1.arcgis.database;

namespace com.g1.arcgis.tn.landprice
{
    public class GLandprice:ILandprice
    {
        private double _landprice;
        private double _area;
        private double _landpriceWithArea;
        private object _mathua;
        private int _lockStatus;
        //private object _thuaId;
        private ILandpriceView _view;
        private SdeConnection _conn;
        private ISdeConnectionInfo _sdeConn;
        private IFeatureWorkspace _fw;
        private IFeatureClass _thuaGiaDatFc;
        private IFeatureClass _thuaFc;
        private ITable _thuaGiaDatTable;
        private ITable _thuaTable;
        private string _nameOfThuaGiaDat;
        private string _nameOfThua;
        private string _tableName;
        private ICurrentConfig _conf;
        private ITnFeatureClassName _fcName;
        private ISDETableEditor _editorThua;
        private ISDETableEditor _editorTgd;
        private List<object[,]> _pairColValTgd = new List<object[,]>();
        private List<object[,]> _pairColValThua = new List<object[,]>();
        private object _currentThuaGiaDatId;
        private object _currentThuaId;
        public GLandprice()
            : this(null)
        {

        }
        public GLandprice(ICurrentConfig conf)
        {
            _conf = conf;
            _tableName = DataNameTemplate.Thua_Gia_Dat_Draft;
        }

        #region ILandprice Members

        double ILandprice.CurrentLandprice
        {
            get
            {
                return this._landprice;
            }
            set
            {
                this._landprice=value;
            }
        }

        double ILandprice.CurrentArea
        {
            get
            {
                return this._area;
            }
            set
            {
                this._area=value;
            }
        }

        double ILandprice.CurrentLandpriceWithArea
        {
            get
            {
                return this._landpriceWithArea;
            }
            set
            {
                this._landpriceWithArea=value;
            }
        }

        int ILandprice.CurrentLockStatus
        {
            get
            {
                return this._lockStatus;
            }
            set
            {
                this._lockStatus=value;
            }
        }

        object ILandprice.CurrentMathua
        {
            get
            {
                return this._mathua;
            }
            set
            {
                this._mathua=value;
            }
        }

        void ILandprice.LoadPrice()
        {
            _conn = new SdeConnection();
            _sdeConn = (ISdeConnectionInfo)_conn;
            _fw = (IFeatureWorkspace)_sdeConn.Workspace;
            IQueryFilter qrf = new QueryFilterClass();
            _fcName=new TnFeatureClassName(_sdeConn.Workspace);
            _nameOfThuaGiaDat=string.Format("{0}_{1}",_tableName,_conf.NamApDung);
            _nameOfThua=string.Format("{0}_{1}",DataNameTemplate.Thua,_conf.NamApDung);
            try
            {
                _thuaGiaDatFc = _fw.OpenFeatureClass(_nameOfThuaGiaDat);
                _thuaGiaDatTable = (ITable)_thuaGiaDatFc;
            }
            catch { MessageBox.Show(string.Format("Không tìm thấy bảng {0}", _nameOfThuaGiaDat)); return; }

            try
            {
                _thuaFc = _fw.OpenFeatureClass(_nameOfThua);
                _thuaTable = (ITable)_thuaFc;
            }
            catch { MessageBox.Show(string.Format("Không tìm thấy bảng {0}", _nameOfThua)); return; }

            _fcName.FC_THUA_GIADAT.NAME = _nameOfThuaGiaDat;
            _fcName.FC_THUA_GIADAT.InitIndex();
            _fcName.FC_THUA.NAME = _nameOfThua;
            _fcName.FC_THUA.InitIndex();

            _editorThua = new SDETable(_thuaTable, _sdeConn.Workspace);
            _editorTgd = new SDETable(_thuaGiaDatTable, _sdeConn.Workspace);

            List<ThuaGiaDatInfo> thuaGiaDat = new List<ThuaGiaDatInfo>();
            if (this._mathua != null)
            {
                //object giadat;
                //object dongia;
                //object dientich;
                //object dientichpl;
                //object giadatTheoDientich;
                int khoaGia;
                //int khoaGiaTay;
                //int khoaGiaTuDong;
                //object khoaViTri;
                //object soMatTien;
                //object soMatHem;
                //object cachtinh;
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, _mathua);
                IFeatureCursor thuaFcur = _thuaFc.Search(qrf, false);
                IFeature thuaFt = null;
                int khoavitri = 0;
                bool result = false;
                try
                {
                    if ((thuaFt = thuaFcur.NextFeature()) != null)
                    {
                        result = int.TryParse(thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOCKED)).ToString(), out khoavitri);
                        if (!result)
                        {
                            khoavitri = 0;
                        }
                    }
                }
                catch (Exception e1) { MessageBox.Show(string.Format("Line 172 - GLandprice - {0}", e1)); }
                finally { Marshal.ReleaseComObject(thuaFcur); }

                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA_GIADAT.MA_THUA, _mathua);
                //MessageBox.Show(string.Format("line 139 {0}", qrf.WhereClause));
                IFeatureCursor fcur=_thuaGiaDatFc.Search(qrf, false);
                IFeature ft = null;
                
                try
                {
                    int i = 0;

                    while ((ft = fcur.NextFeature()) != null)
                    {
                        thuaGiaDat.Add(new ThuaGiaDatInfo());
                        //MessageBox.Show(string.Format("line 147 - {0}_{1}",thuaGiaDat.Count,i));
                        thuaGiaDat[i].Mathua = this._mathua;
                        thuaGiaDat[i].Oid = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.OID));
                        thuaGiaDat[i].Dongia = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.DON_GIA));
                        thuaGiaDat[i].Giadat = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.GIA_DAT));
                        result=int.TryParse(ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.LOCKED)).ToString(),out khoaGia);
                        if(!result)
                        {
                            khoaGia=0;
                        }
                        thuaGiaDat[i].Khoagia = khoaGia;
                        thuaGiaDat[i].Hesovitri = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.HE_SO_K));
                        thuaGiaDat[i].Cachtinh = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.CACH_TINH));
                        thuaGiaDat[i].Dientich = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.DIEN_TICH));
                        thuaGiaDat[i].Dientichpl = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.DIEN_TICH_PHAP_LY));
                        thuaGiaDat[i].Maduong = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.MA_DUONG));
                        thuaGiaDat[i].Mahem = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.MA_HEM));
                        thuaGiaDat[i].KhoaVitri = khoavitri;
                        i++;
                        
                    }
                    //MessageBox.Show(string.Format("line 157 - {0}_{1}", thuaGiaDat.Count, i));
                    //if (thuaGiaDat.Count > 0)
                    //{
                        _view.UpDate(thuaGiaDat);
                    //}
                        
                }
                catch (Exception e1) { MessageBox.Show(string.Format("Line 167 - GLandprice - {0}", e1)); }
                finally { Marshal.ReleaseComObject(fcur); }
            }
        }

        void ILandprice.ReCalcWithCurPos()
        {
            throw new NotImplementedException();
        }

        void ILandprice.ReCalcWithNewPos()
        {
            throw new NotImplementedException();
        }

        void ILandprice.ReCalcMethod()
        {
            throw new NotImplementedException();
        }

        void ILandprice.CalcLandpriceWithArea()
        {
            throw new NotImplementedException();
        }

        void ILandprice.LockAutoMethod()
        {
            
        }

        void ILandprice.LockAllMethod()
        {
            
        }

        void ILandprice.Unlock()
        {
            
        }

        void ILandprice.CommitLandprice()
        {
            throw new NotImplementedException();
        }

        void ILandprice.UpdateLandprice()
        {
            throw new NotImplementedException();
        }

        object ILandprice.CurrentThuaId
        {
            get
            {
                return this._currentThuaId;
            }
            set
            {
                this._currentThuaId = value;
            }
        }

        void ILandprice.SetView(ILandpriceView view)
        {
            this._view=view;
        }

        #endregion

        #region ILandprice Members


        ICurrentConfig ILandprice.Config
        {
            get
            {
                return this._conf;
            }
            set
            {
                _conf = value;
            }
        }

        #endregion

        #region ILandprice Members


        void ILandprice.LoadPriceFromOid()
        {
            throw new NotImplementedException();
        }

        void ILandprice.LoadPriceFromKey()
        {
            _conn = new SdeConnection();
            _sdeConn = (ISdeConnectionInfo)_conn;
            _fw = (IFeatureWorkspace)_sdeConn.Workspace;
            IQueryFilter qrf = new QueryFilterClass();
            _fcName = new TnFeatureClassName(_sdeConn.Workspace);
            _nameOfThuaGiaDat = string.Format("{0}_{1}", _tableName, _conf.NamApDung);
            try
            {
                _thuaGiaDatFc = _fw.OpenFeatureClass(_nameOfThuaGiaDat);
                _thuaGiaDatTable = (ITable)_thuaGiaDatFc;
            }
            catch { MessageBox.Show(string.Format("Không tìm thấy bảng {0}", _nameOfThuaGiaDat)); }

            _fcName.FC_THUA_GIADAT.NAME = _nameOfThuaGiaDat;
            _fcName.FC_THUA_GIADAT.InitIndex();

            List<ThuaGiaDatInfo> thuaGiaDat = new List<ThuaGiaDatInfo>();
            if (this._mathua != null)
            {
                //object giadat;
                //object dongia;
                //object dientich;
                //object dientichpl;
                //object giadatTheoDientich;
                int khoaGia;
                //int khoaGiaTay;
                //int khoaGiaTuDong;
                //object khoaViTri;
                //object soMatTien;
                //object soMatHem;
                //object cachtinh;

                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA_GIADAT.MA_THUA, _mathua);
                //MessageBox.Show(string.Format("line 139 {0}", qrf.WhereClause));
                IFeatureCursor fcur = _thuaGiaDatFc.Search(qrf, false);
                IFeature ft = null;
                bool result = false;
                try
                {
                    int i = 0;
                    while ((ft = fcur.NextFeature()) != null)
                    {
                        thuaGiaDat.Add(new ThuaGiaDatInfo());
                        //MessageBox.Show(string.Format("line 147 - {0}_{1}",thuaGiaDat.Count,i));
                        thuaGiaDat[i].Mathua = this._mathua;
                        thuaGiaDat[i].Oid = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.OID));
                        thuaGiaDat[i].Dongia = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.DON_GIA));
                        thuaGiaDat[i].Giadat = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.GIA_DAT));
                        result = int.TryParse(ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.LOCKED)).ToString(), out khoaGia);
                        if (!result)
                        {
                            khoaGia = 0;
                        }
                        thuaGiaDat[i].Khoagia = khoaGia;
                        thuaGiaDat[i].Hesovitri = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.HE_SO_K));
                        thuaGiaDat[i].Cachtinh = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.CACH_TINH));
                        thuaGiaDat[i].Dientich = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.DIEN_TICH));
                        thuaGiaDat[i].Dientichpl = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.DIEN_TICH_PHAP_LY));
                        thuaGiaDat[i].Maduong = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.MA_DUONG));
                        thuaGiaDat[i].Mahem = ft.get_Value(ft.Fields.FindField(_fcName.FC_THUA_GIADAT.MA_HEM));
                        i++;
                    }
                    //MessageBox.Show(string.Format("line 157 - {0}_{1}", thuaGiaDat.Count, i));
                    if (thuaGiaDat.Count > 0)
                    {
                        _view.UpDate(thuaGiaDat);
                    }
                }
                catch (Exception e1) { MessageBox.Show(string.Format("Line 167 - GLandprice - {0}", e1)); }
                finally { Marshal.ReleaseComObject(fcur); }
            }
        }

        string ILandprice.TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName=value;
            }
        }

        #endregion

        #region ILandprice Members


        void ILandprice.StartEdit()
        {
            if (_editorThua != null && !_editorThua.IsEditing())
            {
                _editorThua.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                _editorThua.StartEditOperation();
            }
            if (_editorTgd != null && !_editorTgd.IsEditing())
            {
                _editorTgd.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                _editorTgd.StartEditOperation();
            }
        }

        void ILandprice.SaveEdit()
        {
            if (!(_editorTgd == null || _currentThuaGiaDatId==null))
            {
                //MessageBox.Show("line 418 GLandprice, thuagiadatid=" + _currentThuaGiaDatId.ToString());
                _editorTgd.CacheData(_currentThuaGiaDatId, 0, _pairColValTgd, EnumTypeOfEdit.UPDATE);
                _editorTgd.SaveEdit();
            }
            if (!(_editorThua == null || _currentThuaId==null))
            {
                //MessageBox.Show("line 424 GLandprice, thuaid=" + _currentThuaId.ToString());
                _editorThua.CacheData(_currentThuaId, 0, _pairColValThua, EnumTypeOfEdit.UPDATE);
                _editorThua.SaveEdit();
                
            }
        }

        void ILandprice.StopEdit()
        {
            if (_editorThua != null)
            {
                _editorThua.StopEditOperation();
                _editorThua.StopEditing(true);
                
            }
            if (_editorThua != null)
            {
                _editorTgd.StopEditOperation();
                _editorTgd.StopEditing(true);

            }
        }

        void ILandprice.StopEditWithoutSaving()
        {
            if (_editorThua != null)
            {
                _editorThua.StopEditOperation();
                _editorThua.StopEditing(false);
                
            }
            if (_editorThua != null)
            {
                _editorTgd.StopEditOperation();
                _editorTgd.StopEditing(false);

            }
            
        }

        List<object[,]> ILandprice.ListOfValueThuaGiaDat
        {
            get
            {
                return _pairColValTgd;
            }
            set
            {
                _pairColValTgd=value;
            }
        }

        List<object[,]> ILandprice.ListOfValueThua
        {
            get
            {
                return _pairColValThua;
            }
            set
            {
                _pairColValThua=value;
            }
        }

        #endregion

        #region ILandprice Members


        object ILandprice.CurrentThuaGiaDatId
        {
            get
            {
                return _currentThuaGiaDatId;
            }
            set
            {
                _currentThuaGiaDatId=value;
            }
        }

        #endregion

        #region ILandprice Members


        void ILandprice.Remove(object oid)
        {
            IQueryFilter qrf = new QueryFilterClass();
            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA_GIADAT.OID, oid);
            MessageBox.Show(string.Format("line 519 {0}", qrf.WhereClause));
            IFeatureCursor fcur = _thuaGiaDatFc.Search(qrf, false);
            IFeature ft = null;
            if((ft = fcur.NextFeature())== null)
            {
                return;
            }
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IWorkspaceEdit wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            wspEdit.StartEditing(true);
            wspEdit.StartEditOperation();
            try
            {
                ft.Delete();
                wspEdit.StopEditOperation();
                wspEdit.StopEditing(true);
            }
            catch (Exception ex) { MessageBox.Show("line 538 GLandprice, ex=" + ex.ToString()); }
            finally
            {
                wspEdit.StopEditOperation();
                wspEdit.StopEditing(false);
            }
            
        }

        #endregion
    }
}
