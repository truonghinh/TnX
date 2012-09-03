using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Runtime.InteropServices;
using com.g1.arcgis.tn.calculation.evaluate;
using com.g1.arcgis.calculation;
using System.ComponentModel;
using com.g1.arcgis.connection;
using gov.tn.TnDatabaseStructure;
using System.Windows.Forms;
using com.g1.arcgis.database;
using com.g1.arcgis.tn.config;
using gov.tn.system;
using System.Threading;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class CalcLandprice
    {
        #region fields
        private object _maduong;
        private object _maTtXa;
        private ICurrentConfig _currentConfig;
        private Calculator _caller;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        private object _loaidatNn;
        private object _loaidatSxkd;
        private object _maktvhxh;
        private CalculationMethodBuilder _methodBuilder;
        private IWorkspaceEdit _wspEdit;
        private IMultiuserWorkspaceEdit _mwspEdit;
        private List<object> _publishedId;
        ICopyFeatures copyTool;
        //private FrmFilterLandprice frmFilterLandprice;
        #endregion

        #region Properties
        public object Maduong
        {
            get { return _maduong; }
            set { _maduong = value; }
        }

        public object Maktvhxh
        {
            get { return _maktvhxh; }
            set { _maktvhxh = value; }
        }

        public object MaTtXa
        {
            get { return _maTtXa; }
            set { _maTtXa = value; }
        }
        
        #endregion

        #region construction

        public CalcLandprice(Calculator caller)
        {
            _caller = caller;
            _currentConfig = CurrentConfig.CallMe();
            _methodBuilder = new CalculationMethodBuilder();
            _methodBuilder.Config = _currentConfig;
        }

        public CalcLandprice()
        {
            _caller = null;
            _currentConfig = CurrentConfig.CallMe();
            _methodBuilder = new CalculationMethodBuilder();
            _methodBuilder.Config = _currentConfig;
        }
        #endregion

        public void Calculate(List<object> newId)
        {
            
            #region tinh gia dat
            //cachtinhdongia = "[giadatduong] * [hesodatsxkd]";
            //cachtinhdongia = "DonGiaSxkdMattienDt(Multiply([giadatduong],[hesodatsxkd]))";
            //cachtinhdongia = "DonGiaOcoNnMattienDt([giadatduong])";
            //cachtinhdongia = "DonGiaOcoSxkdMattienDt([giadatduong])";
            //cachtinh="[giadatduong] * [dientich]";
            //cachtinh = "GiaDatSxkdMattienDt([giadatduong] * [hesodatsxkd] * [dientich])";
            //cachtinh = "DonGiaOcoNnMattienDt(Multiply([giadatduong],[giadatnongnghiep]))";

            #region khoi tao cac bien
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            _wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            _mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, this._currentConfig.NamApDung);
            string gdd = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Duong, this._currentConfig.NamApDung);
            string gdhem = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem, this._currentConfig.NamApDung);
            string gdhemPhu = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem_Phu, this._currentConfig.NamApDung);
            string thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, this._currentConfig.NamApDung);
            string gdNnName=string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Nongnghiep, this._currentConfig.NamApDung);
            string gdPnnNtName = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Pnn_Nongthon, this._currentConfig.NamApDung);
            _fcName.FC_THUA.NAME = thuaName;
            _fcName.FC_THUA.InitIndex();
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            _tblName.GIA_DAT_DUONG.NAME = gdd;
            _tblName.GIA_DAT_DUONG.InitIndex();
            _fcName.FC_GIA_DAT_HEM.NAME = gdhem;
            _fcName.FC_GIA_DAT_HEM.InitIndex();
            _fcName.FC_GIA_DAT_HEM_PHU.NAME = gdhemPhu;
            _fcName.FC_GIA_DAT_HEM_PHU.InitIndex();
            _tblName.GIA_DAT_NONGNGHIEP.NAME = gdNnName;
            _tblName.GIA_DAT_NONGNGHIEP.InitIndex();
            _tblName.GIA_DAT_O_NONGTHON.NAME = gdPnnNtName;
            _tblName.GIA_DAT_O_NONGTHON.InitIndex();
            IFeatureClass tgdDraftFeatureClass = null;
            try
            {
                tgdDraftFeatureClass = fw.OpenFeatureClass(tgdDraft);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgdDraft);
                return;
            }
            IFeatureClass fcGiaDatHem = null;
            try
            {
                fcGiaDatHem = fw.OpenFeatureClass(gdhem);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + gdhem);
            }
            IFeatureClass fcGiaDatHemPhu = null;
            try
            {
                fcGiaDatHemPhu = fw.OpenFeatureClass(gdhemPhu);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + gdhemPhu);
            }
            ITable tblLoaiDat;
            ITable tblThuaGiaDatDraft;
            ITable tblGiaDatDuong;
            ITable tblHesoVitri;
            ITable tblTenDuong;
            ITable tblGiaDatNn;
            ITable tblGiaDatPnnNt;
            IFeatureClass fcThua;
            IFeatureClass fcXa;
            IFeatureClass fcDuong;
            IFeatureClass fcKtvhxh;
            IFeatureClass fcHemChinh;
            #endregion

            
            #region dinh nghia cac bien

            try
            {
                fcThua = fw.OpenFeatureClass(thuaName);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + thuaName);
                return;
            }

            try
            {
                tblTenDuong = fw.OpenTable(DataNameTemplate.Ten_Duong);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Ten_Duong);
                return;
            }
            
            try
            {
                tblLoaiDat = fw.OpenTable(DataNameTemplate.Loai_Dat);
                tblThuaGiaDatDraft = (ITable)tgdDraftFeatureClass;

                //tblThuaGiaDat = fw.OpenTable(_fcName.FC_THUA_GIADAT.NAME);
                tblGiaDatDuong = fw.OpenTable(gdd);

                tblHesoVitri = fw.OpenTable(DataNameTemplate.He_So_K);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgdDraft);
                return;
            }

            try
            {
                tblGiaDatNn = fw.OpenTable(gdNnName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + gdNnName);
                return;
            }

            try
            {
                tblGiaDatPnnNt = fw.OpenTable(gdPnnNtName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + gdPnnNtName);
                return;
            }

            try
            {
                fcXa = fw.OpenFeatureClass(DataNameTemplate.Ranh_Xa_Poly);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Ranh_Xa_Poly);
                return;
            }

            try
            {
                fcHemChinh = fw.OpenFeatureClass(DataNameTemplate.Hem);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Hem);
                return;
            }

            ISDETableEditor sdeTblTgdEditor = new SDETable(tblThuaGiaDatDraft, sdeConn.Workspace);
            IQueryFilter qrf = new QueryFilterClass();
            #endregion

            string paramTableName = DataNameTemplate.Thong_So + "_" + _currentConfig.NamApDung;
            ITable paramTable = fw.OpenTable(paramTableName);
            Dictionary<string, object> pars4TinhGia = new Dictionary<string, object>();
            Dictionary<string, object> pars4TinhDonGia = new Dictionary<string, object>();
            IQueryFilter q = new QueryFilterClass();
            q.WhereClause = "";
            ICursor parCursor = paramTable.Search(q, false);
            IRow parRow = null;
            try
            {
                while ((parRow = parCursor.NextRow()) != null)
                {
                    string parName = parRow.get_Value(parRow.Fields.FindField(_tblName.THONG_SO.TEN_THONG_SO)).ToString();
                    object parVal = parRow.get_Value(parRow.Fields.FindField(_tblName.THONG_SO.GIA_TRI));
                    try
                    {
                        pars4TinhGia.Add(parName, parVal);
                        pars4TinhDonGia.Add(parName, parVal);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception) { }
            finally { Marshal.ReleaseComObject(parCursor); }
            pars4TinhGia.Add(ExpressionParameters.GiaDatDuong, 0);
            pars4TinhGia.Add(ExpressionParameters.DienTichPl, 0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatNn,0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatONT, 0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatHemChinh, 0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatHemPhu, 0);


            pars4TinhDonGia.Add(ExpressionParameters.GiaDatDuong,0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatNn,0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatONT, 0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatHemChinh, 0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatHemPhu, 0);

            #region vong lap tung id

            #region khoi dau
            int rowTgdNnHandleUpdate = 0;
            string cachtinh="";
            string cachtinhdongia = "";
            bool result = false;
            List<object[,]> pairColValTgd = new List<object[,]>();
            CalculationEventArg evt = new CalculationEventArg();
            if (_caller != null)
            {
                evt.Reset();
                evt.Log = "\n\nBắt đầu tính giá cho các thửa vừa xác định vị trí";
                _caller.onCalculating(evt);
            }
            int len = newId.Count;
            int thuaCount = 1;
            //MessageBox.Show(len.ToString());
            #endregion

            foreach (object o in newId)
            {
                #region lay thong tin thua gia dat
                IRow tgdRowNew = tblThuaGiaDatDraft.GetRow((int)o);
                string mathuaNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA)).ToString();
                string maduongNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG)).ToString();
                string hesovitriNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K)).ToString();
                object dientich = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH));
                object dientichpl = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY));
                object khoagia = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.LOCKED));
                object mahem=tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_HEM));
                object dorongHem=0;
                object tenHem = "";
                //MessageBox.Show("line 237 CalcLandprice, maduong=" + maduongNew);
                if (khoagia != null)
                {
                    if (khoagia.ToString() != "0" && khoagia.ToString()!="")
                    {
                        //MessageBox.Show(khoagia.ToString());
                        if (_caller != null)
                        {
                            evt.Reset();
                            evt.IdThuaKhoaGia = o;
                            evt.mathua = mathuaNew;
                            _caller.onCalculating(evt);
                        }
                        continue;
                    }
                }
                #endregion

                #region lay cach tinh
                qrf.WhereClause = string.Format("{0}='{1}'", "hesovitri", hesovitriNew);
                ICursor curNew = tblHesoVitri.Search(qrf, false);

                try
                {
                    IRow rowNew = curNew.NextRow();
                    if (rowNew != null)
                    {
                        cachtinh = rowNew.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH)).ToString();
                        cachtinhdongia = rowNew.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH_DON_GIA)).ToString();
                        //MessageBox.Show("line 262 CalcLandprice, cachtinhdongia=" + cachtinhdongia);
                    }
                }
                catch (COMException comExc) { }
                finally
                {
                    Marshal.ReleaseComObject(curNew);
                }

                Evaluation evalTinhGia = new Evaluation(cachtinh);
                Evaluation evalTinhDonGia = new Evaluation(cachtinhdongia);
                Evaluation evalCachtinh = new Evaluation(cachtinhdongia);
                #endregion

                #region lay gia dat duong
                //MessageBox.Show("line 365 maduong=" + maduongNew);
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.GIA_DAT_DUONG.MA_DUONG, maduongNew);
                ICursor gdDuongCur = null;
                gdDuongCur = tblGiaDatDuong.Search(qrf, false);
                IRow gdDuongRow = null;
                double giaduong = 0;
                try
                {
                    if ((gdDuongRow = gdDuongCur.NextRow()) != null)
                    {
                        result = double.TryParse(gdDuongRow.get_Value(_tblName.GIA_DAT_DUONG.GetIndex(_tblName.GIA_DAT_DUONG.GIA_DAT)).ToString(), out giaduong);
                        if (!result)
                        {
                            giaduong = 0;
                        }
                        //MessageBox.Show("line 292 CalcLandprice, giaduong=" + giaduong.ToString());
                    }
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(gdDuongCur); }
                #endregion

                

                #region lay ten duong
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.TEN_DUONG.MA_DUONG, maduongNew);
                ICursor tenDuongCur = null;
                tenDuongCur = tblTenDuong.Search(qrf, false);
                IRow tenDuongRow = null;
                object tenduong = "";
                object batdau = "";
                object ketthuc = "";
                try
                {
                    if ((tenDuongRow = tenDuongCur.NextRow()) != null)
                    {
                        tenduong = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.TEN_DUONG));
                        batdau = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.BAT_DAU));
                        ketthuc = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.KET_THUC));
                    }
                }
                catch (COMException comExc) { giaduong = 0; }
                finally { Marshal.ReleaseComObject(tenDuongCur); }
                #endregion

                #region lay loai dat, loai xa
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathuaNew);
                IFeatureCursor thuaCur = null;
                thuaCur = fcThua.Search(qrf, false);
                IFeature thuaFt = null;
                object loaidat = "";
                object maxa = "";
                try
                {
                    if ((thuaFt = thuaCur.NextFeature()) != null)
                    {
                        loaidat = thuaFt.get_Value(_fcName.FC_THUA.GetIndex(_fcName.FC_THUA.LOAI_DAT));
                        maxa = thuaFt.get_Value(_fcName.FC_THUA.GetIndex(_fcName.FC_THUA.MA_XA));
                    }

                    #region kiem tra co dat nong nghiep

                    foreach (string s in TnLoaiDats.NONG_NGHIEP)
                    {
                        if (loaidat.ToString().Contains(s))
                        {
                            _loaidatNn = s;

                            break;
                        }
                        else
                        {
                            _loaidatNn = "";
                        }
                    }
                    #endregion
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(thuaCur); }
                #endregion

                //danh cho thua co dat nong nghiep
                #region lay ma xa va gia dat nong nghiep
                object loaixa = "";
                object giadatNnDeGhi = 0;
                object giadatNnDeTinh = 0;
                int loaiDoThi = 0;
                object loaiDatNnDeTinh = "";
                string nnStart = hesovitriNew.Substring(0, 1);
                string nnEnd = hesovitriNew.Substring(hesovitriNew.Length - 1, 1);
                object giadatPnnNt = 0;
                double giahem = 0;
                double giahemPhu = 0;
                if (nnStart=="5" || nnStart=="2"|| nnStart=="1")
                {
                    

                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_RANH_XA_POLY.MA_XA, maxa);
                    IFeatureCursor xaFcr = fcXa.Search(qrf, false);
                    IFeature xaFt = null;
                    try
                    {
                        if ((xaFt = xaFcr.NextFeature()) != null)
                        {
                            loaixa = xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.MA_LOAI_XA));
                            result = int.TryParse(xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.MA_LOAI_XA)).ToString(), out loaiDoThi);
                        }
                    }
                    catch (Exception ex) { loaixa = ""; }
                    finally { Marshal.ReleaseComObject(xaFcr); }

                    if (loaixa != "")
                    {
                        #region neu la dat o nong thon
                        if (nnStart == "2")
                        {
                            object vitriPnn;
                            object khuvucPnn;
                            getVitriPnnNt(hesovitriNew, out vitriPnn, out khuvucPnn);
                            qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}' and {4}='{5}'",
                                _tblName.GIA_DAT_O_NONGTHON.MA_LOAI_XA, loaixa,
                                _tblName.GIA_DAT_O_NONGTHON.VI_TRI, vitriPnn,
                                _tblName.GIA_DAT_O_NONGTHON.MA_KHU_VUC, khuvucPnn);
                            //MessageBox.Show("line 471 CalcLandprice, qrf=" + qrf.WhereClause);
                            ICursor gdPnnCur = tblGiaDatPnnNt.Search(qrf, false);
                            IRow gdPnnRow = null;
                            try
                            {
                                if ((gdPnnRow = gdPnnCur.NextRow()) != null)
                                {
                                    giadatPnnNt = gdPnnRow.get_Value(gdPnnRow.Fields.FindField(_tblName.GIA_DAT_O_NONGTHON.GIA_DAT));
                                }
                                else
                                {
                                    giadatPnnNt = 0;
                                }
                                //MessageBox.Show("line 484 CalcLandprice, giadat=" + giadatPnnNt);
                            }
                            catch (Exception ex) { giadatPnnNt = 0; }
                            finally { Marshal.ReleaseComObject(gdPnnCur); }
                        }
                        #endregion

                        #region neu co dat nong nghiep
                        if (nnStart == "5" || (nnStart == "2" && nnEnd == "2") || nnStart == "1")
                        {
                            loaiDatNnDeTinh = _loaidatNn;
                            object vitriNn = getVitriNongNghiep(hesovitriNew);
                            
                            if (loaiDoThi != 0)
                            {
                                vitriNn = 1;
                                loaiDatNnDeTinh = "LNQ";
                            }
                            qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}' and {4}='{5}'",
                                _tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_DAT, loaiDatNnDeTinh,
                                _tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_XA, loaixa,
                                _tblName.GIA_DAT_NONGNGHIEP.VI_TRI, vitriNn);
                            ICursor gdNnCur = tblGiaDatNn.Search(qrf, false);
                            IRow gdNnRow = null;
                            try
                            {
                                if ((gdNnRow = gdNnCur.NextRow()) != null)
                                {
                                    giadatNnDeGhi = gdNnRow.get_Value(gdNnRow.Fields.FindField(_tblName.GIA_DAT_NONGNGHIEP.GIA_DAT));
                                }
                                else
                                {
                                    giadatNnDeGhi = 0;
                                }
                            }
                            catch (Exception ex) { giadatNnDeGhi = 0; }
                            finally { Marshal.ReleaseComObject(gdNnCur); }
                            //MessageBox.Show(string.Format("line 331 CalcLandprice giadatnndegi={0}", giadatNnDeGhi));

                            //neu ko phai dat thuan nong nghiep
                            if (nnStart != "1")
                            {
                                if (double.Parse(dientichpl.ToString()) < 200)
                                {
                                    giadatNnDeTinh = 0;
                                }
                                else
                                {
                                    giadatNnDeTinh = giadatNnDeGhi;
                                }
                            }
                            else
                            {
                                giadatNnDeTinh = giadatNnDeGhi;
                            }
                        }
                        #endregion

                        
                    }
                    //lay gia dat nn o vi tri theo quy dinh (vt3)
                    //qrf.WhereClause=string.Format("{0}='{1}' and {2}='{3}'",_tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_DAT,_loaidatNn,_tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_XA,)
                }

                #endregion
                if (mahem != null)
                {
                    #region lay thong tin hem
                    //MessageBox.Show("line 567 CalcLandprice, mahem=" + mahem);

                    if (mahem.ToString() != "0" && mahem.ToString() != "")
                    {
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, mahem);
                        IFeatureCursor hemFcur = fcHemChinh.Search(qrf, false);
                        IFeature hemFt = null;
                        int maHemChinh = 0;
                        try
                        {
                            if ((hemFt = hemFcur.NextFeature()) != null)
                            {
                                dorongHem = hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.DO_RONG));
                                tenHem = hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.TEN_HEM));
                                maduongNew = hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.MA_DUONG)).ToString();
                                result = int.TryParse(hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.HEM_CHINH)).ToString(), out maHemChinh);
                                if (!result)
                                {
                                    maHemChinh = 0;
                                }
                                //MessageBox.Show("line 586 CalcLandprice,mahemchinh=" + maHemChinh);
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("line 566 CalcLandprice, ex=" + ex.ToString()); 
                        }
                        finally { Marshal.ReleaseComObject(hemFcur); }

                        #region lay gia dat hem chinh
                        string hsvitriHem = getHesoHem(hesovitriNew);
                        //MessageBox.Show("line 597 hsvitrihem=" + hsvitriHem);
                        if (hsvitriHem == "0")
                        {
                            continue;
                        }
                        if (maHemChinh == 0)
                        {
                            qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, mahem, _fcName.FC_GIA_DAT_HEM.HE_SO, hsvitriHem);
                            //MessageBox.Show("line 603 CalcLandprice, qrf=" + qrf.WhereClause);
                            IFeatureCursor gdHemCur = null;
                            gdHemCur = fcGiaDatHem.Search(qrf, false);
                            IFeature gdHemRow = null;
                            //MessageBox.Show("line 588 CalcLandprice, giaHem=" + _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.GIA_DAT));
                            try
                            {
                                if ((gdHemRow = gdHemCur.NextFeature()) != null)
                                {

                                    result = double.TryParse(gdHemRow.get_Value(_fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.GIA_DAT)).ToString(), out giahem);
                                    if (!result)
                                    {
                                        giahem = 0;
                                    }
                                    //MessageBox.Show("line 588 CalcLandprice, giaHem=" + giahem.ToString());
                                }
                            }
                            catch (COMException comExc)
                            {
                                //MessageBox.Show("line 593 CalcLandprice comexc=" + comExc.ToString()); 
                            }
                            finally { Marshal.ReleaseComObject(gdHemCur); }
                        }
                        #endregion
                        #region lay gia hem phu
                        else
                        {
                            qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'", _fcName.FC_GIA_DAT_HEM_PHU.MA_HEM, mahem, _fcName.FC_GIA_DAT_HEM_PHU.HE_SO, hsvitriHem);
                            //MessageBox.Show("line 632 CalcLandprice, qrf=" + qrf.WhereClause);
                            IFeatureCursor gdHemPhuCur = null;
                            gdHemPhuCur = fcGiaDatHemPhu.Search(qrf, false);
                            IFeature gdHemPhuRow = null;
                            //MessageBox.Show("line 588 CalcLandprice, giaHem=" + _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.GIA_DAT));
                            try
                            {
                                if ((gdHemPhuRow = gdHemPhuCur.NextFeature()) != null)
                                {

                                    result = double.TryParse(gdHemPhuRow.get_Value(_fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.GIA_DAT)).ToString(), out giahemPhu);
                                    if (!result)
                                    {
                                        giahemPhu = 0;
                                    }
                                    //MessageBox.Show("line 646 CalcLandprice, giaHemPhu=" + giahemPhu.ToString());
                                }
                            }
                            catch (COMException comExc)
                            {
                                //MessageBox.Show("line 593 CalcLandprice comexc=" + comExc.ToString()); 
                            }
                            finally { Marshal.ReleaseComObject(gdHemPhuCur); }
                        }
                        #endregion

                        #region lay gia duong tu lop gia hem

                        qrf.WhereClause = string.Format("{0}='{1}'", _tblName.GIA_DAT_DUONG.MA_DUONG, maduongNew);
                        gdDuongCur = null;
                        gdDuongCur = tblGiaDatDuong.Search(qrf, false);
                        gdDuongRow = null;
                        giaduong = 0;
                        try
                        {
                            if ((gdDuongRow = gdDuongCur.NextRow()) != null)
                            {
                                result = double.TryParse(gdDuongRow.get_Value(_tblName.GIA_DAT_DUONG.GetIndex(_tblName.GIA_DAT_DUONG.GIA_DAT)).ToString(), out giaduong);
                                if (!result)
                                {
                                    giaduong = 0;
                                }
                                //MessageBox.Show("line 292 CalcLandprice, giaduong=" + giaduong.ToString());
                            }
                        }
                        catch (COMException comExc) { }
                        finally { Marshal.ReleaseComObject(gdDuongCur); }
                        #endregion
                    }
                    #endregion
                }
                    //MessageBox.Show(string.Format("line 346 CalcLandprice giadatnndegi={0}, giadatnndetinh={1}", giadatNnDeGhi, giadatNnDeTinh));
                #region lay gia dat o nong thon
                int intHsk = int.Parse(hesovitriNew);
                #endregion

                #region tinh gia
                //evalTinhGia.Giadatduong = giaduong;
                //evalTinhGia.Dientich = dientich;
                //evalTinhGia.Dientichpl = dientichpl;
                //evalTinhGia.GiadatNn = giadatNnDeTinh;
                //evalTinhDonGia.Giadatduong = giaduong;
                //evalTinhDonGia.GiadatNn = giadatNnDeTinh;
                //Dictionary<string, object> pars = new Dictionary<string, object>();
                //MessageBox.Show("line 609 CalcLandprice, giaHem=" + giahem.ToString());
                pars4TinhGia[ExpressionParameters.GiaDatDuong] = giaduong;
                pars4TinhGia[ExpressionParameters.DienTichPl] = dientichpl;
                pars4TinhGia[ExpressionParameters.GiaDatNn] = giadatNnDeTinh;
                pars4TinhGia[ExpressionParameters.GiaDatONT] = giadatPnnNt;
                pars4TinhGia[ExpressionParameters.GiaDatHemChinh] = giahem;
                pars4TinhGia[ExpressionParameters.GiaDatHemPhu] = giahemPhu;
                //pars.Add(ExpressionParameters.HeSoDatSxkd, _currentConfig.PGiaDatSxkddt);
                evalTinhGia.Params = pars4TinhGia;

                //Dictionary<string, object> pars1 = new Dictionary<string, object>();
                //pars1.Add(ExpressionParameters.GiaDatDuong, giaduong);
                //pars1.Add(ExpressionParameters.GiaDatNn, giadatNnDeTinh);
                //pars1.Add(ExpressionParameters.HeSoDatSxkd, _currentConfig.PGiaDatSxkddt);
                pars4TinhDonGia[ExpressionParameters.GiaDatDuong] = giaduong;
                pars4TinhDonGia[ExpressionParameters.DienTichPl] = dientichpl;
                pars4TinhDonGia[ExpressionParameters.GiaDatNn] = giadatNnDeTinh;
                pars4TinhDonGia[ExpressionParameters.GiaDatONT] = giadatPnnNt;
                pars4TinhDonGia[ExpressionParameters.GiaDatHemChinh] = giahem;
                pars4TinhDonGia[ExpressionParameters.GiaDatHemPhu] = giahemPhu;
                evalTinhDonGia.Params = pars4TinhDonGia;

                object giaMoiTinh = evalTinhGia.EvaluateLandPrice();
                object dongiaMoiTinh = evalTinhDonGia.EvaluateLandPrice();
                //MessageBox.Show(string.Format("line 660 CalcLandprice dongia={0}", dongiaMoiTinh));
                #endregion

                #region ghi cach tinh
                _methodBuilder.BatDau = batdau;
                _methodBuilder.CachTinh = cachtinh;
                _methodBuilder.CachTinhDonGia = cachtinhdongia;
                _methodBuilder.GiaDatNN = giadatNnDeGhi;
                _methodBuilder.GiaDuong = giaduong;
                _methodBuilder.KetThuc = ketthuc;
                _methodBuilder.LoaiDat = loaidat;
                _methodBuilder.TenDuong = tenduong;
                _methodBuilder.DoRongHem = dorongHem;
                _methodBuilder.LoaiXa = loaixa;
                string strCachtinh=_methodBuilder.GetMethodString(hesovitriNew);
                //evt.Reset();
                //evt.Log = string.Format("\n\nĐộ dài cách tính:{0}, cachtinh={1}",strCachtinh.Length,strCachtinh);
                //_caller.onCalculating(evt);
                //MessageBox.Show(string.Format("line 241 CalcLandprice {0}, {1}",hesovitriNew,TnHeSoK.DatOMatTienDt));
                //if (hesovitriNew == TnHeSoK.DatOMatTienDt.ToString())
                //{
                //    strCachtinh = string.Format("Đất ở đô thị ({0}), mặt tiền đường {1} (giá={2}) đoạn từ {3} đến {4}. Giá đất = {5}", loaidat, tenduong, giaduong, batdau, ketthuc, cachtinhdongia);
                //    //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
                //}
                //else if (hesovitriNew == TnHeSoK.DatSxkdMatTienDt.ToString())
                //{
                //    strCachtinh = string.Format("Đất sxkd tại đô thị ({0}) (hệ số ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", loaidat, _currentConfig.PGiaDatSxkddt, tenduong,giaduong, batdau, ketthuc, cachtinhdongia);
                //}
                //else if (hesovitriNew == TnHeSoK.DatONnMatTien.ToString())
                //{
                //    strCachtinh = string.Format("Đất ở tại đô thị có đất nông nghiệp ({0}) (giá đất nn ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", loaidat, giadatNnDeGhi, tenduong, giaduong, batdau, ketthuc, cachtinhdongia);
                //}
                #endregion

                #region lay cach ghi cach tinh gia
                //string ct = string.Format(cachtinh);
                //MessageBox.Show(evalCachtinh.EvaluateMethod().ToString());
                #endregion

                #region luu thong tin gia va cach tinh
                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DON_GIA), dongiaMoiTinh } });
                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.GIA_DAT), giaMoiTinh } });
                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.CACH_TINH), strCachtinh } });
                sdeTblTgdEditor.CacheData(o, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                rowTgdNnHandleUpdate++;
                pairColValTgd.Clear();
                #endregion

                #region ---log
                if (_caller != null)
                {
                    evt.Reset();
                    evt.IdThuaTinhGia = o;// new object[,] { { o, "tui", "soto", "sothua" } };
                    evt.mathua = mathuaNew;
                    _caller.onCalculating(evt);
                    evt.Reset();
                    if (thuaCount < len)
                    {
                        if (thuaCount % 10 == 0)
                        {
                            evt.Log = string.Format("\n---Đã tính cho {0} thửa----", thuaCount);
                        }
                        thuaCount++;
                    }
                    else if (thuaCount == len)
                    {
                        evt.Log = string.Format("\n---Đã tính cho {0} thửa---", thuaCount);
                    }
                    _caller.onCalculating(evt);
                }
                #endregion
            }

            #endregion

            #region luu thong tin vao bang gia dat
            if (!sdeTblTgdEditor.IsEditing())
            {
                sdeTblTgdEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblTgdEditor.StartEditOperation();
            }
            //else
            //{
            //    //try
            //    //{
            //    //    sdeTblTgdEditor.SaveEdit();
            //    //    sdeTblTgdEditor.StopEditOperation();
            //    //    sdeTblTgdEditor.StopEditing(true);
            //    //}
            //    //catch
            //    //{
            //    //    sdeTblTgdEditor.StopEditOperation();
            //    //    sdeTblTgdEditor.StopEditing(false);
            //    //}
            //    //sdeTblTgdEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
            //    //sdeTblTgdEditor.StartEditOperation();
            //}

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đang lưu bảng {0} |||---- ", tgdDraft);

                _caller.onCalculating(evt);
            }
            #endregion
            try
            {
                sdeTblTgdEditor.SaveEdit();
                sdeTblTgdEditor.StopEditOperation();
                sdeTblTgdEditor.StopEditing(true);
            }
            catch (Exception ex)
            {
                sdeTblTgdEditor.StopEditOperation();
                sdeTblTgdEditor.StopEditing(false);
            }

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đã lưu bảng {0} |||---- ", tgdDraft);
                _caller.onCalculating(evt);
            }
            #endregion

            #endregion

            #region loc gia dat
            
            ThreadStart filterThread =()=>fil(newId);
            Thread t = new Thread(filterThread);
            t.Start();
            //while (!t.IsAlive) ;
            //Thread.Sleep(1);
            //t.Abort();
            t.Join();

            
            #endregion
            #endregion
        }

        public void CalcGiaHem(List<object> newId)
        {
            #region khoi tao cac bien
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            _wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            _mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            string gdHem = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem, this._currentConfig.NamApDung);
            string gdd = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Duong, this._currentConfig.NamApDung);
            
            
            _fcName.FC_GIA_DAT_HEM.NAME = gdHem;
            _fcName.FC_GIA_DAT_HEM.InitIndex();
            _tblName.GIA_DAT_DUONG.NAME = gdd;
            _tblName.GIA_DAT_DUONG.InitIndex();
            
            IFeatureClass gdhFeatureClass = null;
            ITable tblgdHem=null;
            try
            {
                gdhFeatureClass = fw.OpenFeatureClass(gdHem);
                tblgdHem = (ITable)gdhFeatureClass;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + gdHem);
                return;
            }
            
            ITable tblGiaDatDuong;
            ITable tblHesoVitri;
            ITable tblTenDuong;
            ITable tblHemChinh;

            #endregion

            #region dinh nghia cac bien

            try
            {
                tblTenDuong = fw.OpenTable(DataNameTemplate.Ten_Duong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Ten_Duong);
                return;
            }

            try
            {
                tblGiaDatDuong = fw.OpenTable(gdd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + gdd);
                return;
            }
            try
            {
                tblHemChinh = fw.OpenTable(DataNameTemplate.Hem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Hem);
                return;
            }

            ISDETableEditor sdeTblGdhEditor = new SDETable(tblgdHem, sdeConn.Workspace);
            IQueryFilter qrf = new QueryFilterClass();
            #endregion

            #region vong lap tung id

            #region khoi dau
            int rowGdhHandleUpdate = 0;
            string cachtinh = "";
            string cachtinhdongia = "";
            bool result = false;
            List<object[,]> pairColValTgd = new List<object[,]>();
            CalculationEventArg evt = new CalculationEventArg();
            if (_caller != null)
            {
                evt.Reset();
                evt.Log = "\n\nBắt đầu tính giá cho các hẻm vừa xác định vị trí";
                _caller.onCalculating(evt);
            }
            int len = newId.Count;
            int thuaCount = 1;
            //MessageBox.Show(len.ToString());
            #endregion

            foreach (object o in newId)
            {
                if (!((int)o > 0))
                {
                    //MessageBox.Show("line 737 CalcLandprice: không thể tính cho hẻm có id=" + o);
                    continue;
                }
                #region lay thong tin hem gia dat
                IRow gdhRowNew = null;
                try
                {
                    gdhRowNew = tblgdHem.GetRow((int)o);
                }
                catch (Exception ex) { }
                if (gdhRowNew == null)
                {
                    continue;
                }
                
                string maduongNew = gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM.MA_DUONG)).ToString();
                int hesovitriNew;
                result=int.TryParse(gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM.HE_SO)).ToString(),out hesovitriNew);
                
                object khoagia = gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM.LOCKED));
                object mahem = gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM.MA_HEM));
                int dorongHem=0;
                object tenHem="";
                //MessageBox.Show("line 237 CalcLandprice, maduong=" + maduongNew);
                if (khoagia != null)
                {
                    if (khoagia.ToString() != "0" && khoagia.ToString() != "")
                    {
                        //MessageBox.Show(khoagia.ToString());
                        //evt.Reset();
                        //evt.IdThuaKhoaGia = o;
                        //evt.mathua = mahem;
                        //_caller.onCalculating(evt);
                        continue;
                    }
                }
                #endregion

                #region lay gia dat duong
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.GIA_DAT_DUONG.MA_DUONG, maduongNew);
                ICursor gdDuongCur = null;
                gdDuongCur = tblGiaDatDuong.Search(qrf, false);
                IRow gdDuongRow = null;
                double giaduong = 0;
                try
                {
                    if ((gdDuongRow = gdDuongCur.NextRow()) != null)
                    {
                        result = double.TryParse(gdDuongRow.get_Value(_tblName.GIA_DAT_DUONG.GetIndex(_tblName.GIA_DAT_DUONG.GIA_DAT)).ToString(), out giaduong);
                        if (!result)
                        {
                            giaduong = 0;
                        }
                        //MessageBox.Show("line 292 CalcLandprice, giaduong=" + giaduong.ToString());
                    }
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(gdDuongCur); }
                #endregion
                if (mahem != null)
                {
                    #region lay thong tin hem
                    if (mahem.ToString()!= "0" && mahem.ToString() != "")
                    {
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, mahem);
                        ICursor hemFcur = tblHemChinh.Search(qrf, false);
                        IRow hemRow = null;
                        try
                        {
                            if ((hemRow = hemFcur.NextRow()) != null)
                            {
                                object dorong = hemRow.get_Value(hemRow.Fields.FindField(_fcName.FC_HEM.DO_RONG));
                                result = int.TryParse(dorong.ToString(), out dorongHem);
                                if (!result)
                                {
                                    dorongHem = 0;
                                }
                                tenHem = hemRow.get_Value(hemRow.Fields.FindField(_fcName.FC_HEM.TEN_HEM));
                            }
                        }
                        catch (Exception ex) { }
                        finally { Marshal.ReleaseComObject(hemFcur); }
                    }
                    #endregion
                }
                #region lay ten duong
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.TEN_DUONG.MA_DUONG, maduongNew);
                ICursor tenDuongCur = null;
                tenDuongCur = tblTenDuong.Search(qrf, false);
                IRow tenDuongRow = null;
                object tenduong = "";
                object batdau = "";
                object ketthuc = "";
                try
                {
                    if ((tenDuongRow = tenDuongCur.NextRow()) != null)
                    {
                        tenduong = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.TEN_DUONG));
                        batdau = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.BAT_DAU));
                        ketthuc = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.KET_THUC));
                    }
                }
                catch (COMException comExc) { giaduong = 0; }
                finally { Marshal.ReleaseComObject(tenDuongCur); }
                #endregion

                object giaMoiTinh=0;
                double hesorong=1;
                double hesosau=1;

                #region chon chieu rong
                if (dorongHem < 3.5)
                {
                    hesorong = _currentConfig.PHemChinhRongDuoi3_5m;
                }
                else if (dorongHem < 6)
                {
                    hesorong = _currentConfig.PHemChinhRongTren3_5m;
                }
                else
                {
                    hesorong = _currentConfig.PHemChinhRongTren6m;
                }
                #endregion

                #region chon chieu sau
                if (hesovitriNew == 1) //chieu sau <100m
                {
                    hesosau = _currentConfig.PHemSauDuoi100m;
                }
                else if (hesovitriNew == 2)
                {
                    hesosau = _currentConfig.PHemSauDuoi200m;
                }
                else
                {
                    hesosau = _currentConfig.PHemSauTren200m;
                }
                #endregion

                giaMoiTinh = giaduong * hesorong * hesosau;
                //MessageBox.Show("line 868 CalcLandprice giamoitinh=" + giaMoiTinh);
                pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.GIA_DAT), giaMoiTinh } });
                sdeTblGdhEditor.CacheData(o, 0, pairColValTgd, EnumTypeOfEdit.UPDATE);
                pairColValTgd.Clear();
            }

            #endregion

            #region luu thong tin vao bang gia dat
            if (!sdeTblGdhEditor.IsEditing())
            {
                
                sdeTblGdhEditor.StartEditing(true);
                sdeTblGdhEditor.StartEditOperation();
            }
            else
            {
                try
                {
                    sdeTblGdhEditor.SaveEdit();
                    sdeTblGdhEditor.StopEditOperation();
                    sdeTblGdhEditor.StopEditing(true);
                }
                catch
                {
                    sdeTblGdhEditor.StopEditOperation();
                    sdeTblGdhEditor.StopEditing(false);
                }
                sdeTblGdhEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblGdhEditor.StartEditOperation();
            }

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", gdHem);
                _caller.onCalculating(evt);
            }
            #endregion
            try
            {
                sdeTblGdhEditor.SaveEdit();
                sdeTblGdhEditor.StopEditOperation();
                sdeTblGdhEditor.StopEditing(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("line 1405 CalcGiaHemChinh ex=" + ex.ToString());
                sdeTblGdhEditor.StopEditOperation();
                sdeTblGdhEditor.StopEditing(false);
            }

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", gdHem);
                _caller.onCalculating(evt);
            }
            #endregion

            #endregion
        }

        public void CalcGiaHemPhu(List<object> newId)
        {
            #region khoi tao cac bien
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            _wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            _mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            string gdHemPhu = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem_Phu, this._currentConfig.NamApDung);
            string gdHemChinh = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem, this._currentConfig.NamApDung);


            _fcName.FC_GIA_DAT_HEM_PHU.NAME = gdHemPhu;
            _fcName.FC_GIA_DAT_HEM_PHU.InitIndex();
            _fcName.FC_GIA_DAT_HEM.NAME = gdHemChinh;
            _fcName.FC_GIA_DAT_HEM.InitIndex();

            IFeatureClass gdhPhuFeatureClass = null;
            ITable tblgdHemPhu = null;
            try
            {
                gdhPhuFeatureClass = fw.OpenFeatureClass(gdHemPhu);
                tblgdHemPhu = (ITable)gdhPhuFeatureClass;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + gdHemPhu);
                return;
            }

            IFeatureClass gdhChinhFeatureClass;
            ITable tblHesoVitri;
            ITable tblTenDuong;
            ITable tblHemChinh;

            #endregion

            #region dinh nghia cac bien

            try
            {
                tblTenDuong = fw.OpenTable(DataNameTemplate.Ten_Duong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Ten_Duong);
                return;
            }

            try
            {
                gdhChinhFeatureClass = fw.OpenFeatureClass(gdHemChinh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + gdHemChinh);
                return;
            }
            try
            {
                tblHemChinh = fw.OpenTable(DataNameTemplate.Hem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Hem);
                return;
            }

            ISDETableEditor sdeTblGdhEditor = new SDETable(tblgdHemPhu, sdeConn.Workspace);
            IQueryFilter qrf = new QueryFilterClass();
            #endregion

            #region vong lap tung id

            #region khoi dau
            int rowGdhHandleUpdate = 0;
            string cachtinh = "";
            string cachtinhdongia = "";
            bool result = false;
            List<object[,]> pairColValTgd = new List<object[,]>();
            CalculationEventArg evt = new CalculationEventArg();
            if (_caller != null)
            {
                evt.Reset();
                evt.Log = "\n\nBắt đầu tính giá cho các hẻm vừa xác định vị trí";
                _caller.onCalculating(evt);
            }
            int len = newId.Count;
            int thuaCount = 1;
            //MessageBox.Show(len.ToString());
            #endregion

            foreach (object o in newId)
            {
                if (!((int)o > 0))
                {
                    //MessageBox.Show("line 737 CalcLandprice: không thể tính cho hẻm có id=" + o);
                    continue;
                }
                #region lay thong tin hem gia dat
                IRow gdhRowNew = null;
                try
                {
                    gdhRowNew = tblgdHemPhu.GetRow((int)o);
                }
                catch (Exception ex) { }
                if (gdhRowNew == null)
                {
                    continue;
                }

                string maHemChinhNew = gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM_CHINH)).ToString();
                int hesovitriNew;
                result = int.TryParse(gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.HE_SO)).ToString(), out hesovitriNew);

                object khoagia = gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.LOCKED));
                object mahem = gdhRowNew.get_Value(gdhRowNew.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM));
                int dorongHem = 0;
                object tenHem = "";
                //MessageBox.Show("line 237 CalcLandprice, maduong=" + maduongNew);
                if (khoagia != null)
                {
                    if (khoagia.ToString() != "0" && khoagia.ToString() != "")
                    {
                        //MessageBox.Show(khoagia.ToString());
                        //evt.Reset();
                        //evt.IdThuaKhoaGia = o;
                        //evt.mathua = mahem;
                        //_caller.onCalculating(evt);
                        continue;
                    }
                }
                #endregion

                #region lay gia dat hem chinh
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, maHemChinhNew);
                IFeatureCursor gdHemChinhCur = null;
                gdHemChinhCur = gdhChinhFeatureClass.Search(qrf, false);
                IFeature gdHemChinhRow = null;
                double giaHemChinh = 0;
                object maduong = 0;
                try
                {
                    if ((gdHemChinhRow = gdHemChinhCur.NextFeature()) != null)
                    {
                        result = double.TryParse(gdHemChinhRow.get_Value(_fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.GIA_DAT)).ToString(), out giaHemChinh);
                        if (!result)
                        {
                            giaHemChinh = 0;
                        }
                        maduong=gdHemChinhRow.get_Value(_fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.MA_DUONG));
                        //MessageBox.Show("line 1259 CalcLandprice, giahemchinh=" + giaHemChinh.ToString());
                    }
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(gdHemChinhCur); }
                #endregion
                if (mahem != null)
                {
                    #region lay thong tin hem
                    if (mahem.ToString() != "0" && mahem.ToString() != "")
                    {
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, mahem);
                        ICursor hemFcur = tblHemChinh.Search(qrf, false);
                        IRow hemRow = null;
                        try
                        {
                            if ((hemRow = hemFcur.NextRow()) != null)
                            {
                                object dorong = hemRow.get_Value(hemRow.Fields.FindField(_fcName.FC_HEM.DO_RONG));
                                result = int.TryParse(dorong.ToString(), out dorongHem);
                                if (!result)
                                {
                                    dorongHem = 0;
                                }
                                tenHem = hemRow.get_Value(hemRow.Fields.FindField(_fcName.FC_HEM.TEN_HEM));
                            }
                        }
                        catch (Exception ex) { }
                        finally { Marshal.ReleaseComObject(hemFcur); }
                    }
                    #endregion
                }
                #region lay ten duong
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.TEN_DUONG.MA_DUONG, maduong);
                ICursor tenDuongCur = null;
                tenDuongCur = tblTenDuong.Search(qrf, false);
                IRow tenDuongRow = null;
                object tenduong = "";
                object batdau = "";
                object ketthuc = "";
                try
                {
                    if ((tenDuongRow = tenDuongCur.NextRow()) != null)
                    {
                        tenduong = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.TEN_DUONG));
                        batdau = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.BAT_DAU));
                        ketthuc = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.KET_THUC));
                    }
                }
                catch (COMException comExc) { giaHemChinh = 0; }
                finally { Marshal.ReleaseComObject(tenDuongCur); }
                #endregion

                object giaMoiTinh = 0;
                double hesorong = 1;
                double hesosau = 1;

                #region chon chieu rong
                if (dorongHem < 3.5)
                {
                    hesorong = _currentConfig.PHemChinhRongDuoi3_5m;
                }
                else if (dorongHem < 6)
                {
                    hesorong = _currentConfig.PHemChinhRongTren3_5m;
                }
                else
                {
                    hesorong = _currentConfig.PHemChinhRongTren6m;
                }
                #endregion

                #region chon chieu sau
                if (hesovitriNew == 1) //chieu sau <100m
                {
                    hesosau = _currentConfig.PHemSauDuoi100m;
                }
                else if (hesovitriNew == 2)
                {
                    hesosau = _currentConfig.PHemSauDuoi200m;
                }
                else
                {
                    hesosau = _currentConfig.PHemSauTren200m;
                }
                #endregion

                giaMoiTinh = giaHemChinh * hesorong * hesosau;
                //MessageBox.Show("line 868 CalcLandprice giamoitinh=" + giaMoiTinh);
                pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.GIA_DAT), giaMoiTinh } });
                sdeTblGdhEditor.CacheData(o, 0, pairColValTgd, EnumTypeOfEdit.UPDATE);
                pairColValTgd.Clear();
            }

            #endregion

            #region luu thong tin vao bang gia dat
            if (!sdeTblGdhEditor.IsEditing())
            {

                sdeTblGdhEditor.StartEditing(true);
                sdeTblGdhEditor.StartEditOperation();
            }
            else
            {
                try
                {
                    sdeTblGdhEditor.SaveEdit();
                    sdeTblGdhEditor.StopEditOperation();
                    sdeTblGdhEditor.StopEditing(true);
                }
                catch
                {
                    sdeTblGdhEditor.StopEditOperation();
                    sdeTblGdhEditor.StopEditing(false);
                }
                sdeTblGdhEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblGdhEditor.StartEditOperation();
            }

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", gdHemPhu);
                _caller.onCalculating(evt);
            }
            #endregion
            try
            {
                sdeTblGdhEditor.SaveEdit();
                sdeTblGdhEditor.StopEditOperation();
                sdeTblGdhEditor.StopEditing(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("line 1405 CalcGiaHemChinh ex=" + ex.ToString());
                sdeTblGdhEditor.StopEditOperation();
                sdeTblGdhEditor.StopEditing(false);
            }

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", gdHemPhu);
                _caller.onCalculating(evt);
            }
            #endregion

            #endregion
        }

        public void CalculateTuGiaHem(List<object> newId)
        {

            #region tinh gia dat
            //cachtinhdongia = "[giadatduong] * [hesodatsxkd]";
            //cachtinhdongia = "DonGiaSxkdMattienDt(Multiply([giadatduong],[hesodatsxkd]))";
            //cachtinhdongia = "DonGiaOcoNnMattienDt([giadatduong])";
            //cachtinhdongia = "DonGiaOcoSxkdMattienDt([giadatduong])";
            //cachtinh="[giadatduong] * [dientich]";
            //cachtinh = "GiaDatSxkdMattienDt([giadatduong] * [hesodatsxkd] * [dientich])";
            //cachtinh = "DonGiaOcoNnMattienDt(Multiply([giadatduong],[giadatnongnghiep]))";

            #region khoi tao cac bien
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            _wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            _mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, this._currentConfig.NamApDung);
            string gdh = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem, this._currentConfig.NamApDung);
            string gdhPhu = string.Format("{0}_{1}", DataNameTemplate.Gia_Hem_Phu, this._currentConfig.NamApDung);
            string gdd = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Duong, this._currentConfig.NamApDung);
            string thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, this._currentConfig.NamApDung);
            string gdNnName = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Nongnghiep, this._currentConfig.NamApDung);
            string gdPnnNtName = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Pnn_Nongthon, this._currentConfig.NamApDung);
            _fcName.FC_THUA.NAME = thuaName;
            _fcName.FC_THUA.InitIndex();
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            _fcName.FC_GIA_DAT_HEM.NAME = gdh;
            _fcName.FC_GIA_DAT_HEM.InitIndex();
            _tblName.GIA_DAT_DUONG.NAME = gdd;
            _tblName.GIA_DAT_DUONG.InitIndex();
            _tblName.GIA_DAT_NONGNGHIEP.NAME = gdNnName;
            _tblName.GIA_DAT_NONGNGHIEP.InitIndex();
            _tblName.GIA_DAT_O_NONGTHON.NAME = gdPnnNtName;
            _tblName.GIA_DAT_O_NONGTHON.InitIndex();
            IFeatureClass tgdDraftFeatureClass = null;
            try
            {
                tgdDraftFeatureClass = fw.OpenFeatureClass(tgdDraft);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgdDraft);
                return;
            }
            ITable tblLoaiDat;
            ITable tblThuaGiaDatDraft;
            ITable tblGiaDatHem;
            ITable tblGiaDatDuong;
            ITable tblHesoVitri;
            ITable tblTenDuong;
            ITable tblGiaDatNn;
            ITable tblGiaDatPnnNt;
            IFeatureClass fcThua;
            IFeatureClass fcXa;
            IFeatureClass fcDuong;
            IFeatureClass fcKtvhxh;
            IFeatureClass fcHemChinh;
            #endregion


            #region dinh nghia cac bien

            try
            {
                fcThua = fw.OpenFeatureClass(thuaName);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + thuaName);
                return;
            }

            try
            {
                tblTenDuong = fw.OpenTable(DataNameTemplate.Ten_Duong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Ten_Duong);
                return;
            }

            try
            {
                tblLoaiDat = fw.OpenTable(DataNameTemplate.Loai_Dat);
                tblThuaGiaDatDraft = (ITable)tgdDraftFeatureClass;

                //tblThuaGiaDat = fw.OpenTable(_fcName.FC_THUA_GIADAT.NAME);
                tblGiaDatHem = fw.OpenTable(gdh);
                tblGiaDatDuong = fw.OpenTable(gdd);
                tblHesoVitri = fw.OpenTable(DataNameTemplate.He_So_K);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgdDraft);
                return;
            }

            try
            {
                tblGiaDatNn = fw.OpenTable(gdNnName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + gdNnName);
                return;
            }

            try
            {
                tblGiaDatPnnNt = fw.OpenTable(gdPnnNtName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy bảng " + gdPnnNtName);
                return;
            }

            try
            {
                fcXa = fw.OpenFeatureClass(DataNameTemplate.Ranh_Xa_Poly);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Ranh_Xa_Poly);
                return;
            }

            try
            {
                fcHemChinh = fw.OpenFeatureClass(DataNameTemplate.Hem);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + DataNameTemplate.Hem);
                return;
            }

            ISDETableEditor sdeTblTgdEditor = new SDETable(tblThuaGiaDatDraft, sdeConn.Workspace);
            IQueryFilter qrf = new QueryFilterClass();
            #endregion

            string paramTableName = DataNameTemplate.Thong_So + "_" + _currentConfig.NamApDung;
            ITable paramTable = fw.OpenTable(paramTableName);
            Dictionary<string, object> pars4TinhGia = new Dictionary<string, object>();
            Dictionary<string, object> pars4TinhDonGia = new Dictionary<string, object>();
            IQueryFilter q = new QueryFilterClass();
            q.WhereClause = "";
            ICursor parCursor = paramTable.Search(q, false);
            IRow parRow = null;
            try
            {
                while ((parRow = parCursor.NextRow()) != null)
                {
                    string parName = parRow.get_Value(parRow.Fields.FindField(_tblName.THONG_SO.TEN_THONG_SO)).ToString();
                    object parVal = parRow.get_Value(parRow.Fields.FindField(_tblName.THONG_SO.GIA_TRI));
                    try
                    {
                        pars4TinhGia.Add(parName, parVal);
                        pars4TinhDonGia.Add(parName, parVal);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception) { }
            finally { Marshal.ReleaseComObject(parCursor); }
            pars4TinhGia.Add(ExpressionParameters.GiaDatDuong, 0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatHemChinh, 0);
            pars4TinhGia.Add(ExpressionParameters.DienTichPl, 0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatNn, 0);
            pars4TinhGia.Add(ExpressionParameters.GiaDatONT, 0);

            pars4TinhDonGia.Add(ExpressionParameters.GiaDatDuong, 0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatHemChinh, 0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatNn, 0);
            pars4TinhDonGia.Add(ExpressionParameters.GiaDatONT, 0);

            #region vong lap tung id

            #region khoi dau
            int rowTgdNnHandleUpdate = 0;
            string cachtinh = "";
            string cachtinhdongia = "";
            bool result = false;
            List<object[,]> pairColValTgd = new List<object[,]>();
            CalculationEventArg evt = new CalculationEventArg();
            if (_caller != null)
            {
                evt.Reset();
                evt.Log = "\n\nBắt đầu tính giá cho các thửa vừa xác định vị trí";
                _caller.onCalculating(evt);
            }
            int len = newId.Count;
            int thuaCount = 1;
            //MessageBox.Show(len.ToString());
            #endregion

            foreach (object o in newId)
            {
                #region lay thong tin thua gia dat
                IRow tgdRowNew = tblThuaGiaDatDraft.GetRow((int)o);
                string mathuaNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA)).ToString();
                string maduongNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG)).ToString();
                string hesovitriNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K)).ToString();
                object dientich = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH));
                object dientichpl = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY));
                object khoagia = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.LOCKED));
                object mahem = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_HEM));
                object dorongHem = 0;
                object tenHem = "";
                //MessageBox.Show("line 237 CalcLandprice, maduong=" + maduongNew);
                if (khoagia != null)
                {
                    if (khoagia.ToString() != "0" && khoagia.ToString() != "")
                    {
                        //MessageBox.Show(khoagia.ToString());
                        if (_caller != null)
                        {
                            evt.Reset();
                            evt.IdThuaKhoaGia = o;
                            evt.mathua = mathuaNew;
                            _caller.onCalculating(evt);
                        }
                        continue;
                    }
                }
                #endregion

                #region lay cach tinh
                qrf.WhereClause = string.Format("{0}='{1}'", "hesovitri", hesovitriNew);
                ICursor curNew = tblHesoVitri.Search(qrf, false);

                try
                {
                    IRow rowNew = curNew.NextRow();
                    if (rowNew != null)
                    {
                        cachtinh = rowNew.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH)).ToString();
                        cachtinhdongia = rowNew.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH_DON_GIA)).ToString();
                        //MessageBox.Show("line 262 CalcLandprice, cachtinhdongia=" + cachtinhdongia);
                    }
                }
                catch (COMException comExc) { }
                finally
                {
                    Marshal.ReleaseComObject(curNew);
                }

                Evaluation evalTinhGia = new Evaluation(cachtinh);
                Evaluation evalTinhDonGia = new Evaluation(cachtinhdongia);
                Evaluation evalCachtinh = new Evaluation(cachtinhdongia);
                #endregion

                #region lay gia dat duong
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.GIA_DAT_DUONG.MA_DUONG, maduongNew);
                ICursor gdDuongCur = null;
                gdDuongCur = tblGiaDatDuong.Search(qrf, false);
                IRow gdDuongRow = null;
                double giaduong = 0;
                try
                {
                    if ((gdDuongRow = gdDuongCur.NextRow()) != null)
                    {
                        result = double.TryParse(gdDuongRow.get_Value(_tblName.GIA_DAT_DUONG.GetIndex(_tblName.GIA_DAT_DUONG.GIA_DAT)).ToString(), out giaduong);
                        if (!result)
                        {
                            giaduong = 0;
                        }
                        //MessageBox.Show("line 292 CalcLandprice, giaduong=" + giaduong.ToString());
                    }
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(gdDuongCur); }
                #endregion

                #region lay gia dat hem
                string hesohem="3";
                //int hsk;
                //result = int.TryParse(hesovitriNew, out hsk);
                //if (!result)
                //{
                //    hsk = 0;
                //    continue;
                //}
                hesohem = getHesoHem(hesovitriNew);
                //if (hsk == TnHeSoK.DatOHemChinhR3mS100mTronThua || hsk == TnHeSoK.DatOHemChinhR3_6mS100mTronThua || hsk == TnHeSoK.DatOHemChinhR6mS100mTronThua)
                //{
                //    hesohem = 1;
                //}
                //else if (hsk == TnHeSoK.DatOHemChinhR3mS100_200mTronThua || hsk == TnHeSoK.DatOHemChinhR3_6mS100_200mTronThua || hsk == TnHeSoK.DatOHemChinhR6mS100_200mTronThua)
                //{
                //    hesohem = 2;
                //}
                //else if (hsk == TnHeSoK.DatOHemChinhR3mS200mTronThua || hsk == TnHeSoK.DatOHemChinhR3_6mS200mTronThua || hsk == TnHeSoK.DatOHemChinhR6mS200mTronThua)
                //{
                //    hesohem = 3;
                //}
                qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, mahem,_fcName.FC_GIA_DAT_HEM.HE_SO,hesohem);
                ICursor gdHemCur = null;
                gdHemCur = tblGiaDatHem.Search(qrf, false);
                IRow gdHemRow = null;
                double giahem = 0;
                try
                {
                    if ((gdHemRow = gdHemCur.NextRow()) != null)
                    {
                        result = double.TryParse(gdHemRow.get_Value(_tblName.GIA_DAT_DUONG.GetIndex(_tblName.GIA_DAT_DUONG.GIA_DAT)).ToString(), out giahem);
                        if (!result)
                        {
                            giahem = 0;
                        }
                        //MessageBox.Show("line 292 CalcLandprice, giaduong=" + giaduong.ToString());
                    }
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(gdHemCur); }
                #endregion

                #region lay ten duong
                qrf.WhereClause = string.Format("{0}='{1}'", _tblName.TEN_DUONG.MA_DUONG, maduongNew);
                ICursor tenDuongCur = null;
                tenDuongCur = tblTenDuong.Search(qrf, false);
                IRow tenDuongRow = null;
                object tenduong = "";
                object batdau = "";
                object ketthuc = "";
                try
                {
                    if ((tenDuongRow = tenDuongCur.NextRow()) != null)
                    {
                        tenduong = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.TEN_DUONG));
                        batdau = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.BAT_DAU));
                        ketthuc = tenDuongRow.get_Value(_tblName.TEN_DUONG.GetIndex(_tblName.TEN_DUONG.KET_THUC));
                    }
                }
                catch (COMException comExc) { giahem = 0; }
                finally { Marshal.ReleaseComObject(tenDuongCur); }
                #endregion

                #region lay loai dat, loai xa
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathuaNew);
                IFeatureCursor thuaCur = null;
                thuaCur = fcThua.Search(qrf, false);
                IFeature thuaFt = null;
                object loaidat = "";
                object maxa = "";
                try
                {
                    if ((thuaFt = thuaCur.NextFeature()) != null)
                    {
                        loaidat = thuaFt.get_Value(_fcName.FC_THUA.GetIndex(_fcName.FC_THUA.LOAI_DAT));
                        maxa = thuaFt.get_Value(_fcName.FC_THUA.GetIndex(_fcName.FC_THUA.MA_XA));
                    }

                    #region kiem tra co dat nong nghiep

                    foreach (string s in TnLoaiDats.NONG_NGHIEP)
                    {
                        if (loaidat.ToString().Contains(s))
                        {
                            _loaidatNn = s;

                            break;
                        }
                        else
                        {
                            _loaidatNn = "";
                        }
                    }
                    #endregion
                }
                catch (COMException comExc) { }
                finally { Marshal.ReleaseComObject(thuaCur); }
                #endregion

                //danh cho thua co dat nong nghiep
                #region lay ma xa va gia dat nong nghiep
                object loaixa = "";
                int loaiDoThi = 0;
                object giadatNnDeGhi = 0;
                object giadatNnDeTinh = 0;
                object loaiDatNnDeTinh = "";
                string nnStart = hesovitriNew.Substring(0, 1);
                string nnEnd = hesovitriNew.Substring(hesovitriNew.Length - 1, 1);
                if (nnStart == "5" || (nnStart == "2" && nnEnd == "2") || nnStart == "1")
                {
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_RANH_XA_POLY.MA_XA, maxa);
                    IFeatureCursor xaFcr = fcXa.Search(qrf, false);
                    IFeature xaFt = null;
                    try
                    {
                        if ((xaFt = xaFcr.NextFeature()) != null)
                        {
                            loaixa = xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.MA_LOAI_XA));
                            result = int.TryParse(xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.MA_LOAI_XA)).ToString(), out loaiDoThi);
                        }
                    }
                    catch (Exception ex) { loaixa = ""; }
                    finally { Marshal.ReleaseComObject(xaFcr); }

                    if (loaixa != "")
                    {
                        loaiDatNnDeTinh = _loaidatNn;
                        object vitriNn = 3;
                        if (hesovitriNew == TnHeSoK.DatNongNghiepVt1.ToString())
                        {
                            vitriNn = 1;
                        }
                        else if (hesovitriNew == TnHeSoK.DatNongNghiepVt2Th1.ToString())
                        {
                            vitriNn = 2;
                        }
                        else if (hesovitriNew == TnHeSoK.DatNongNghiepVt3.ToString())
                        {
                            vitriNn = 3;
                        }
                        else
                        {
                            vitriNn = 3;
                        }
                        if (loaiDoThi != 0)
                        {
                            vitriNn = 1;
                            loaiDatNnDeTinh = "LNQ";
                        }
                        qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}' and {4}='{5}'",
                            _tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_DAT,loaiDatNnDeTinh,
                            _tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_XA, loaixa,
                            _tblName.GIA_DAT_NONGNGHIEP.VI_TRI, vitriNn);
                        ICursor gdNnCur = tblGiaDatNn.Search(qrf, false);
                        IRow gdNnRow = null;
                        try
                        {
                            if ((gdNnRow = gdNnCur.NextRow()) != null)
                            {
                                giadatNnDeGhi = gdNnRow.get_Value(gdNnRow.Fields.FindField(_tblName.GIA_DAT_NONGNGHIEP.GIA_DAT));
                            }
                            else
                            {
                                giadatNnDeGhi = 0;
                            }
                        }
                        catch (Exception ex) { giadatNnDeGhi = 0; }
                        finally { Marshal.ReleaseComObject(gdNnCur); }
                        //MessageBox.Show(string.Format("line 331 CalcLandprice giadatnndegi={0}", giadatNnDeGhi));

                        //neu ko phai dat thuan nong nghiep
                        if (nnStart != "1")
                        {
                            if (double.Parse(dientichpl.ToString()) < 200)
                            {
                                giadatNnDeTinh = 0;
                            }
                            else
                            {
                                giadatNnDeTinh = giadatNnDeGhi;
                            }
                        }
                        else
                        {
                            giadatNnDeTinh = giadatNnDeGhi;
                        }
                    }
                    //lay gia dat nn o vi tri theo quy dinh (vt3)
                    //qrf.WhereClause=string.Format("{0}='{1}' and {2}='{3}'",_tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_DAT,_loaidatNn,_tblName.GIA_DAT_NONGNGHIEP.MA_LOAI_XA,)
                }

                #endregion
                if (mahem != null)
                {
                    #region lay thong tin hem
                    if (mahem.ToString() != "0" && mahem.ToString() != "")
                    {
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, mahem);
                        IFeatureCursor hemFcur = fcHemChinh.Search(qrf, false);
                        IFeature hemFt = null;
                        try
                        {
                            if ((hemFt = hemFcur.NextFeature()) != null)
                            {
                                dorongHem = hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.DO_RONG));
                                tenHem = hemFt.get_Value(hemFt.Fields.FindField(_fcName.FC_HEM.TEN_HEM));
                            }
                        }
                        catch (Exception ex) { }
                        finally { Marshal.ReleaseComObject(hemFcur); }
                    }
                    #endregion
                }
                    //MessageBox.Show(string.Format("line 346 CalcLandprice giadatnndegi={0}, giadatnndetinh={1}", giadatNnDeGhi, giadatNnDeTinh));
                #region lay gia dat o nong thon
                int intHsk = int.Parse(hesovitriNew);
                #endregion

                #region tinh gia
                //evalTinhGia.Giadatduong = giaduong;
                //evalTinhGia.Dientich = dientich;
                //evalTinhGia.Dientichpl = dientichpl;
                //evalTinhGia.GiadatNn = giadatNnDeTinh;
                //evalTinhDonGia.Giadatduong = giaduong;
                //evalTinhDonGia.GiadatNn = giadatNnDeTinh;
                //Dictionary<string, object> pars = new Dictionary<string, object>();
                pars4TinhGia[ExpressionParameters.GiaDatDuong] = giaduong;
                pars4TinhGia[ExpressionParameters.GiaDatHemChinh] = giahem;
                pars4TinhGia[ExpressionParameters.DienTichPl] = dientichpl;
                pars4TinhGia[ExpressionParameters.GiaDatNn] = giadatNnDeTinh;
                //pars.Add(ExpressionParameters.HeSoDatSxkd, _currentConfig.PGiaDatSxkddt);
                evalTinhGia.Params = pars4TinhGia;

                //Dictionary<string, object> pars1 = new Dictionary<string, object>();
                //pars1.Add(ExpressionParameters.GiaDatDuong, giaduong);
                //pars1.Add(ExpressionParameters.GiaDatNn, giadatNnDeTinh);
                //pars1.Add(ExpressionParameters.HeSoDatSxkd, _currentConfig.PGiaDatSxkddt);
                pars4TinhDonGia[ExpressionParameters.GiaDatDuong] = giaduong;
                pars4TinhDonGia[ExpressionParameters.GiaDatHemChinh] = giahem;
                pars4TinhDonGia[ExpressionParameters.DienTichPl] = dientichpl;
                pars4TinhDonGia[ExpressionParameters.GiaDatNn] = giadatNnDeTinh;
                evalTinhDonGia.Params = pars4TinhDonGia;

                object giaMoiTinh = evalTinhGia.EvaluateLandPrice();
                object dongiaMoiTinh = evalTinhDonGia.EvaluateLandPrice();
                //MessageBox.Show(string.Format("line 442 CalcLandprice dongia={0}", dongiaMoiTinh));
                #endregion

                #region ghi cach tinh
                _methodBuilder.BatDau = batdau;
                _methodBuilder.CachTinhDonGia = cachtinhdongia;
                _methodBuilder.CachTinh = cachtinh;
                _methodBuilder.GiaDatNN = giadatNnDeGhi;
                _methodBuilder.GiaDuong = giahem;
                _methodBuilder.KetThuc = ketthuc;
                _methodBuilder.LoaiDat = loaidat;
                _methodBuilder.TenDuong = tenduong;
                _methodBuilder.DoRongHem = dorongHem;
                string strCachtinh = _methodBuilder.GetMethodString(hesovitriNew);
                //evt.Reset();
                //evt.Log = string.Format("\n\nĐộ dài cách tính:{0}, cachtinh={1}",strCachtinh.Length,strCachtinh);
                //_caller.onCalculating(evt);
                //MessageBox.Show(string.Format("line 241 CalcLandprice {0}, {1}",hesovitriNew,TnHeSoK.DatOMatTienDt));
                //if (hesovitriNew == TnHeSoK.DatOMatTienDt.ToString())
                //{
                //    strCachtinh = string.Format("Đất ở đô thị ({0}), mặt tiền đường {1} (giá={2}) đoạn từ {3} đến {4}. Giá đất = {5}", loaidat, tenduong, giaduong, batdau, ketthuc, cachtinhdongia);
                //    //MessageBox.Show(string.Format("line 241 CalcLandprice \n{0}", strCachtinh));
                //}
                //else if (hesovitriNew == TnHeSoK.DatSxkdMatTienDt.ToString())
                //{
                //    strCachtinh = string.Format("Đất sxkd tại đô thị ({0}) (hệ số ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", loaidat, _currentConfig.PGiaDatSxkddt, tenduong,giaduong, batdau, ketthuc, cachtinhdongia);
                //}
                //else if (hesovitriNew == TnHeSoK.DatONnMatTien.ToString())
                //{
                //    strCachtinh = string.Format("Đất ở tại đô thị có đất nông nghiệp ({0}) (giá đất nn ={1}), mặt tiền đường {2} (giá={3}) đoạn từ {4} đến {5}. Giá đất = {6}", loaidat, giadatNnDeGhi, tenduong, giaduong, batdau, ketthuc, cachtinhdongia);
                //}
                #endregion

                #region lay cach ghi cach tinh gia
                //string ct = string.Format(cachtinh);
                //MessageBox.Show(evalCachtinh.EvaluateMethod().ToString());
                #endregion

                #region luu thong tin gia va cach tinh
                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DON_GIA), dongiaMoiTinh } });
                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.GIA_DAT), giaMoiTinh } });
                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.CACH_TINH), strCachtinh } });
                sdeTblTgdEditor.CacheData(o, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                rowTgdNnHandleUpdate++;
                pairColValTgd.Clear();
                #endregion

                #region ---log
                if (_caller != null)
                {
                    evt.Reset();
                    evt.IdThuaTinhGia = o;// new object[,] { { o, "tui", "soto", "sothua" } };
                    evt.mathua = mathuaNew;
                    _caller.onCalculating(evt);
                    evt.Reset();
                    if (thuaCount < len)
                    {
                        if (thuaCount % 10 == 0)
                        {
                            evt.Log = string.Format("\n---Đã tính cho {0} thửa----", thuaCount);
                        }
                        thuaCount++;
                    }
                    else if (thuaCount == len)
                    {
                        evt.Log = string.Format("\n---Đã tính cho {0} thửa---", thuaCount);
                    }
                    _caller.onCalculating(evt);
                }
                #endregion
            }

            #endregion

            #region luu thong tin vao bang gia dat
            if (!sdeTblTgdEditor.IsEditing())
            {
                sdeTblTgdEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblTgdEditor.StartEditOperation();
            }
            else
            {
                try
                {
                    sdeTblTgdEditor.SaveEdit();
                    sdeTblTgdEditor.StopEditOperation();
                    sdeTblTgdEditor.StopEditing(true);
                }
                catch
                {
                    sdeTblTgdEditor.StopEditOperation();
                    sdeTblTgdEditor.StopEditing(false);
                }
                sdeTblTgdEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblTgdEditor.StartEditOperation();
            }


            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đang lưu bảng {0} |||---- ", tgdDraft);

                _caller.onCalculating(evt);
            }
            #endregion
            try
            {
                sdeTblTgdEditor.SaveEdit();
                sdeTblTgdEditor.StopEditOperation();
                sdeTblTgdEditor.StopEditing(true);
            }
            catch (Exception ex)
            {
                sdeTblTgdEditor.StopEditOperation();
                sdeTblTgdEditor.StopEditing(false);
            }

            #region ----log
            if (_caller != null)
            {
                evt.Log = string.Format("\n----||| Đã lưu bảng {0} |||---- ", tgdDraft);
                _caller.onCalculating(evt);
            }
            #endregion

            #endregion

            #region loc gia dat

            ThreadStart filterThread = () => fil(newId);
            Thread t = new Thread(filterThread);
            t.Start();
            //while (!t.IsAlive) ;
            //Thread.Sleep(1);
            //t.Abort();
            t.Join();


            #endregion
            #endregion
        }

        private void fil(List<object> newId)
        {
            FrmFilterLandprice frmFilterLandprice = new FrmFilterLandprice();
            frmFilterLandprice.Filter(newId);
            frmFilterLandprice.ShowDialog();
            
        }

        

        public void FilterPrice(List<object> newId)
        {
            #region chon loc gia dat

            #region khoi tao cac bien
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            string tgd = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat, this._currentConfig.NamApDung);
            string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, this._currentConfig.NamApDung);
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            _fcName.FC_THUA_GIADAT.NAME = tgd;
            _fcName.FC_THUA_GIADAT.InitIndex();
            IFeatureClass tgdFeatureClassDraft=null;
            IFeatureClass tgdFeatureClass = null;
            try
            {
                tgdFeatureClassDraft = fw.OpenFeatureClass(tgdDraft);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgdDraft);
                return;
            }
            try
            {
                tgdFeatureClass = fw.OpenFeatureClass(tgd);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgd);
                return;
            }
            ITable tblThuaGiaDatDraft = (ITable)tgdFeatureClassDraft;
            ITable tblThuaGiaDat = (ITable)tgdFeatureClass;
            ISDETableEditor sdeTblTgdEditor = new SDETable(tblThuaGiaDat, sdeConn.Workspace);
            IQueryFilter qrf = new QueryFilterClass();
            bool result = false;
            #endregion


            #region vong lap tung id

            #region khoi dau
            int rowTgdNnHandleUpdate = 0;
            string cachtinh = "";
            string cachtinhdongia = "";
            //bool result = false;
            List<object[,]> pairColValTgd = new List<object[,]>();
            CalculationEventArg evt = new CalculationEventArg();
            if (_caller != null)
            {
                evt.Reset();
                evt.Log = "\n\nBắt đầu chọn lọc giá cho các thửa vừa tính...";
                _caller.onCalculating(evt);
            }
            int len = newId.Count;
            int thuaCount = 1;
            //MessageBox.Show(string.Format("line 620 CalcLandprice {0}",len.ToString()));
            #endregion
            List<object> mathuaCalced = new List<object>();
            foreach (object o in newId)
            {
                if (_caller != null)
                {
                    evt.Reset();
                    evt.Log = string.Format("\n\nchọn lọc giá cho thửa {0}", o);
                    _caller.onCalculating(evt);
                }
                IRow tgdDraftRowNew = tblThuaGiaDatDraft.GetRow((int)o);
                string mathuaNew = tgdDraftRowNew.get_Value(tgdDraftRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA)).ToString();
                if (mathuaCalced.Count > 0)
                {
                    foreach (object ob in mathuaCalced)
                    {
                        if (string.Compare(mathuaNew.ToString(), ob.ToString()) == 0)
                        {
                            continue;
                        }
                    }
                }
                mathuaCalced.Add(mathuaNew);

                #region vong lap xet vung gia co ma mathuaNew
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathuaNew);
                IFeatureCursor tgdDraftCur = tgdFeatureClassDraft.Search(qrf, false);
                IFeature tgdDraftFt = null;
                List<landpriceInfo> info = new List<landpriceInfo>();
                List<landpriceInfo> infoResult;
                //List<
                try
                {
                    double dongia = 0;
                    object id = 0;
                    object hesok = 0;
                    
                    while ((tgdDraftFt = tgdDraftCur.NextFeature()) != null)
                    {
                        id = tgdDraftFt.OID;

                        hesok = tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K));
                        result =double.TryParse(tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DON_GIA)).ToString(),out dongia);
                        if (!result)
                        {
                            dongia = 0;
                        }
                        info.Add(new landpriceInfo(id, hesok, dongia));
                        //evt.Reset();
                        //evt.Log = string.Format("\n\nVùng giá {0}, số vùng giá:{1} ", id,info.Count);
                        //_caller.onCalculating(evt);
                    }

                    #region xet dieu kien de luu cac vung gia vao bang gia cong bo
                    //neu chi co 1 vung gia thi ko can suy nghi
                    int sovunggia=info.Count;
                    if (_caller != null)
                    {
                        evt.Reset();
                        evt.Log = string.Format("\n\nSố vùng giá của thửa {0} là {1}", mathuaNew, sovunggia);
                        _caller.onCalculating(evt);
                    }
                    if (sovunggia == 0)
                    {
                        continue;
                    }
                    //MessageBox.Show(string.Format("line 656 CalcLandprice, source={0}",info.Count));
                    getMaxValueWithDistinctKey(info, out infoResult);
                    //MessageBox.Show(string.Format("line 658 CalcLandprice, giadat={0}", infoResult[0].Dongia));
                    foreach (landpriceInfo inf in infoResult)
                    {
                        tgdDraftFt = tgdFeatureClassDraft.GetFeature((int)inf.Id);
                        object mathua = tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA));
                        qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'", 
                            _fcName.FC_THUA_GIADAT.HE_SO_K, inf.Hesok,
                            _fcName.FC_THUA_GIADAT.MA_THUA,mathua);
                        //MessageBox.Show("line 716, qrf=" + qrf);
                        IFeatureCursor tgdFcur = tgdFeatureClass.Search(qrf, false);
                        IFeature tgdFt = null;
                        List<object> publicIds = new List<object>();
                        try
                        {
                            //MessageBox.Show(string.Format("line 686 CalcLandprice, bat dau"));
                            if ((tgdFt = tgdFcur.NextFeature()) != null)
                            {
                                #region xet thua da co vi tri

                                bool isOverWritePos = true;

                                if (!isOverWritePos)
                                {
                                    publicIds.Add(tgdFt.OID);
                                    //continue;
                                }
                                else
                                {
                                    //[kodoi]
                                    //===================
                                    #region xoa feature cu
                                    try
                                    {
                                        _mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        _wspEdit.StartEditOperation();
                                        //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                                        //tblThuaGiaDat.DeleteSearchedRows(qrf);
                                        //MessageBox.Show(string.Format("line 720 CalcLandprice, bat dau xoa thua {0}",mathua))
                                        tgdFt.Delete();
                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(true);
                                    }
                                    catch(Exception ex) 
                                    {
                                        MessageBox.Show(string.Format("CalcLandprice, xoa feature line 751-\n{0}", ex));
                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(false);
                                    }
                                    
                                    #endregion
                                    //===================

                                    //[thaydoi] - them gia tri
                                    //**********************
                                    #region them feature moi
                                    object copiedId = null;
                                    try
                                    {
                                        _mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        _wspEdit.StartEditOperation();
                                        copiedId = copyTool.CopyWithAllAttribute(tgdDraftFt, tgdFeatureClass);
                                        //MessageBox.Show(string.Format("line 743 CalcLandprice, oid={0}", copiedId));
                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(true);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(string.Format("CalcLandprice, them feature line 776-\n{0}", ex));
                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(false);
                                    }
                                    

                                    //them gia tri mathua,maduong,hesovitri
                                    //pairColValTgd.Add(new object[,] { { tgdFt.Fields.FindField(__fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathuaNew } });
                                    //pairColValTgd.Add(new object[,] { { tgdFt.Fields.FindField(__fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                    //pairColValTgd.Add(new object[,] { { tgdFt.Fields.FindField(__fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                    //pairColValTgd.Add(new object[,] { { __fcName.FC_THUA_GIADAT_DRAFT.GetIndex(__fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
                                    //sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                    //rowTgdNnHandleUpdate++;
                                    //pairColValTgd.Clear();
                                    if (copiedId != null)
                                    {
                                        publicIds.Add(copiedId);
                                    }
                                    #endregion
                                    //**********************
                                }

                                #endregion
                            }
                            else
                            {
                                #region them feature moi
                                object copiedId = null;
                                try
                                {
                                    _mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                    _wspEdit.StartEditOperation();
                                    copiedId = copyTool.CopyWithAllAttribute(tgdDraftFt, tgdFeatureClass);
                                    //MessageBox.Show(string.Format("line 743 CalcLandprice, oid={0}", copiedId));
                                    _wspEdit.StopEditOperation();
                                    _wspEdit.StopEditing(true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(string.Format("CalcLandprice, them feature line 818-\n{0}", ex));
                                    _wspEdit.StopEditOperation();
                                    _wspEdit.StopEditing(false);
                                }
                                if (copiedId != null)
                                {
                                    publicIds.Add(copiedId);
                                }
                                #endregion
                            }
                        }
                        catch (Exception e1) 
                        { 
                            MessageBox.Show(string.Format("CalcLandprice, line 1842-\n{0}", e1)); 
                        }
                        finally { Marshal.ReleaseComObject(tgdFcur); }
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    continue;
                }
                finally
                {
                    Marshal.ReleaseComObject(tgdDraftCur);
                }
                #endregion
            }

            #endregion

            #endregion


        }

        private void getMaxValueWithDistinctKey2(List<landpriceInfo> source, out List<landpriceInfo> output)
        {
            //List<landpriceInfo> resultList=new List<landpriceInfo>();
            int len = source.Count;
            //resultList = source;
            object id1 = 0;
            object hesok1 = 0;
            double dongia1 = 0;
            object id2 = 0;
            object hesok2 = 0;
            double dongia2 = 0;
            hesok1 = source[0].Hesok;
            dongia1 = source[0].Dongia;
            bool con = true;
            for (int i = 1; i < len; i++)
            {
                hesok2 = source[i].Hesok;
                if (string.Compare(hesok1.ToString(), hesok2.ToString()) != 0)
                {
                    continue;
                }
                dongia2 = source[i].Dongia;
                if (dongia1 >= dongia2)
                {
                    source.RemoveAt(i);
                    break;
                }
                else if (dongia1 < dongia2)
                {
                    source.RemoveAt(0);
                    break;
                }
            }
            output = source;
            getMaxValueWithDistinctKey2(source, out output);
            
        }

        private void getMaxValueWithDistinctKey(List<landpriceInfo> source,out List<landpriceInfo> output)
        {
            CalculationEventArg evt = new CalculationEventArg();
            List<landpriceInfo> resultList = source;
            int len = source.Count;
            if (len == 0)
            {
                output = null;
                return;
            }
            else if(len!=1)
            {
                object id1 = 0;
                object hesok1 = 0;
                double dongia1 = 0;
                object id2 = 0;
                object hesok2 = 0;
                double dongia2 = 0;
                int decLen=0;
                int afterLen=len;
                for (int i = 0; i < len-decLen; i++)
                {
                    hesok1 = source[i].Hesok;
                    dongia1 = source[i].Dongia;
                    afterLen=source.Count;
                    for (int j = 0; j < afterLen; j++)
                    {
                        hesok2 = source[j].Hesok;
                        dongia2 = source[j].Dongia;
                        if (string.Compare(hesok1.ToString(), hesok2.ToString()) == 0)
                        {
                            if (dongia1 >= dongia2)
                            {
                                
                                if (j != i)
                                {
                                    resultList.RemoveAt(j);
                                    if (_caller != null)
                                    {
                                        evt.Reset();
                                        evt.Log = string.Format("\n\n Bỏ vùng giá có id={0}, đơn giá={1}--i={2},j={3}", resultList[j].Id, dongia2, i, j);
                                        _caller.onCalculating(evt);
                                    }
                                }
                                decLen++;
                                continue;
                            }
                            else if (dongia1 < dongia2)
                            {
                                if (_caller != null)
                                {
                                    evt.Reset();
                                    evt.Log = string.Format("\n\n Bỏ vùng giá có id={0}, đơn giá={1}--i={2},j={3}", resultList[j].Id, dongia1, i, j);
                                    _caller.onCalculating(evt);
                                }
                                resultList.RemoveAt(i);
                                decLen++;
                                break;
                            }
                        }
                    }
                }
            }

            output = resultList;
        }

        private object getVitriNongNghiep(string hsk)
        {
            object vitriNn = 3;
            if (hsk == TnHeSoK.DatNongNghiepVt1.ToString())
            {
                vitriNn = 1;
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt2Th1.ToString())
            {
                vitriNn = 2;
            }
            else if (hsk == TnHeSoK.DatNongNghiepVt3.ToString())
            {
                vitriNn = 3;
            }
            else
            {
                vitriNn = 3;
            }
            return vitriNn;
        }

        private void getVitriPnnNt(string hsk, out object vitri, out object khuvuc)
        {
            vitri = 3;
            khuvuc=3;
            if (hsk == TnHeSoK.DatOPnnKv1Vt1.ToString() || hsk == TnHeSoK.DatONnPnnKv1Vt1.ToString() || hsk == TnHeSoK.DatSxkdPnnKv1Vt1.ToString())
            {
                vitri = 1;
                khuvuc=1;
            }
            else if (hsk == TnHeSoK.DatOPnnKv1Vt2.ToString() || hsk == TnHeSoK.DatONnPnnKv1Vt2.ToString() || hsk == TnHeSoK.DatSxkdPnnKv1Vt2.ToString())
            {
                vitri = 2;
                khuvuc = 1;
            }
            else if (hsk == TnHeSoK.DatOPnnKv1Vt3.ToString() || hsk == TnHeSoK.DatONnPnnKv1Vt3.ToString() || hsk == TnHeSoK.DatSxkdPnnKv1Vt3.ToString())
            {
                vitri = 3;
                khuvuc = 1;
            }
            else if (hsk == TnHeSoK.DatOPnnKv2Vt1.ToString() || hsk == TnHeSoK.DatONnPnnKv2Vt1.ToString() || hsk == TnHeSoK.DatSxkdPnnKv2Vt1.ToString())
            {
                vitri = 1;
                khuvuc = 2;
            }
            else if (hsk == TnHeSoK.DatOPnnKv2Vt2.ToString() || hsk == TnHeSoK.DatONnPnnKv2Vt2.ToString() || hsk == TnHeSoK.DatSxkdPnnKv2Vt2.ToString())
            {
                vitri = 2;
                khuvuc = 2;
            }
            else if (hsk == TnHeSoK.DatOPnnKv2Vt3.ToString() || hsk == TnHeSoK.DatONnPnnKv2Vt3.ToString() || hsk == TnHeSoK.DatSxkdPnnKv2Vt3.ToString())
            {
                vitri = 3;
                khuvuc = 2;
            }
            else if (hsk == TnHeSoK.DatOPnnKv3Vt1.ToString() || hsk == TnHeSoK.DatONnPnnKv3Vt1.ToString() || hsk == TnHeSoK.DatSxkdPnnKv3Vt1.ToString())
            {
                vitri = 1;
                khuvuc = 3;
            }
            else if (hsk == TnHeSoK.DatOPnnKv3Vt2.ToString() || hsk == TnHeSoK.DatONnPnnKv3Vt2.ToString() || hsk == TnHeSoK.DatSxkdPnnKv3Vt2.ToString())
            {
                vitri = 2;
                khuvuc = 3;
            }
            else if (hsk == TnHeSoK.DatOPnnKv3Vt3.ToString() || hsk == TnHeSoK.DatONnPnnKv3Vt3.ToString() || hsk == TnHeSoK.DatSxkdPnnKv3Vt3.ToString())
            {
                vitri = 3;
                khuvuc = 3;
            }
            else
            {
                vitri = 3;
                khuvuc = 3;
            }

        }

        private string getHesoHem(string hsk)
        {
            string end = hsk.Substring(hsk.Length - 1, 1);
            string result = "0";
            int intEnd;
            bool check=int.TryParse(end,out intEnd);
            if (!check)
            {
                intEnd=0;
            }
            if (end == "1" || end == "2")
            {
                result = "1";
            }
            else if (end == "3" || end == "4" || end == "5")
            {
                result = "2";
            }
            else if (end == "6" || end == "7")
            {
                result = "3";
            }
            return result;
        }
    }

    public struct landpriceInfo
    {
        public double Dongia;
        public object Id;
        public object Hesok;
        public int Somattien;
        public landpriceInfo(object id, object hesok, double dongia)
        {
            Id = id;
            Hesok = hesok;
            Dongia = dongia;
            Somattien = 0;
        }
        public landpriceInfo(object id, object hesok, double dongia,int somattien)
        {
            Id = id;
            Hesok = hesok;
            Dongia = dongia;
            Somattien = somattien;
        }
    }

    
}
