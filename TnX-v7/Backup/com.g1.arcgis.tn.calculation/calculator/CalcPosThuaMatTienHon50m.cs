using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using System.ComponentModel;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.database;
using ESRI.ArcGIS.Carto;
using System.Runtime.InteropServices;
using gov.tn.system;
using com.g1.arcgis.tn.calculation.evaluate;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using com.g1.arcgis.database.versioning;
using com.g1.arcgis.util.filterName;
using com.g1.arcgis.spatialAnalysis;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class CalcPosThuaMatTienHon50m : Calculator, ICalculator
    {
        private string vitri = "mặt tiền có đất sau mặt tiền 50m";
        private int _isDothi = 1;
        private IClip _clipTool;
        private IBuffer _bufferTool;
        IDataManager _dataManager;
        ITnSystemTempPath _sysTempPath;
        ISdeVersionInfo _version;
        public CalcPosThuaMatTienHon50m()
            : base()
        {
            this._bgwCalculating.DoWork -= new DoWorkEventHandler(_bgwCalculating_DoWork);
            this._bgwCalculating.DoWork += new DoWorkEventHandler(_bgwCalculating_DoWork);
            
            //_dataManager = new DataManager();
            _sysTempPath = new TnSystemTempPath();
        }
        protected override void calculate()
        {
            //base.calculate();
            #region khoi dau
            base.calculate();
            CalculationEventArg evt = new CalculationEventArg();
            //evt.Type = EnumTypeOfLoopCalculation.InListCalculators;
            evt.CurrentIndexCalculator = this._index;
            evt.Log = string.Format("**********  Bắt đầu tính cho thửa phi nông nghiệp ở vị trí {0} tại đô thị ********", vitri);
            onCalculating(evt);
            #endregion

            //[thaydoi] - them cac khai bao can thiet
            //************************************
            #region khai bao cac bien
            //Lay connection info hien tai
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IWorkspaceEdit wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit mwspEdit=(IMultiuserWorkspaceEdit)sdeConn.Workspace;
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            ICopyFeatures copyTool = new DataManager();

            #region thua
            string thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, this._currentConfig.NamApDung);
            _fcName.FC_THUA.NAME = thuaName;
            _fcName.FC_THUA.InitIndex();
            IFeatureClass thuaFeatureClass = fw.OpenFeatureClass(thuaName);
            IFeatureLayer thuaFeatureLayer = new FeatureLayerClass();
            thuaFeatureLayer.FeatureClass = thuaFeatureClass;
            IFeatureSelection thuaFeatureSelection;
            #endregion
            #region xa
            IFeatureClass xaFeatureClass = fw.OpenFeatureClass(DataNameTemplate.Ranh_Xa_Poly);
            IFeatureLayer xaFeatureLayer = new FeatureLayerClass();
            xaFeatureLayer.FeatureClass = xaFeatureClass;
            IFeatureSelection xaFeatureSelection;
            #endregion
            #region duong
            IFeatureClass duongFeatureClass = fw.OpenFeatureClass(DataNameTemplate.Duong);
            IFeatureLayer duongFeatureLayer = new FeatureLayerClass();
            duongFeatureLayer.FeatureClass = duongFeatureClass;
            IFeatureSelection duongFeatureSelection;
            //_fcName.FC_DUONG.InitIndex();
            #endregion

            #region thua gia dat
            string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, this._currentConfig.NamApDung);
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            //_fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            //_fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            IFeatureClass tgdFeatureClass = null;
            try
            {
                tgdFeatureClass = fw.OpenFeatureClass(tgdDraft);
            }
            catch (Exception exc)
            {
                evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", tgdDraft);
                onCalculating(evt);
                onFinished(evt);
                return;
            }
            //ITable tblThuaGiaDat = (ITable)tgdFeatureClass;
            IFeatureLayer tgdFeatureLayer = new FeatureLayerClass();
            ISDETableEditor sdeTblTgdEditor = new SDETable((ITable)tgdFeatureClass, sdeConn.Workspace);
            #endregion

            #region gia dat duong
            string gdd = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Duong, this._currentConfig.NamApDung);
            _tblName.GIA_DAT_DUONG.NAME = gdd;
            _tblName.GIA_DAT_DUONG.InitIndex();
            #endregion

            #region ten duong
            ITable tblTenDuong;
            try
            {
                tblTenDuong = fw.OpenTable(DataNameTemplate.Ten_Duong);
            }
            catch (Exception exc)
            {
                evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", DataNameTemplate.Ten_Duong);
                onCalculating(evt);
                onFinished(evt);
                return;
            }
            #endregion

            #region loai dat
            ITable tblLoaiDat;
            try
            {
                tblLoaiDat = fw.OpenTable(DataNameTemplate.Loai_Dat);
            }
            catch (Exception exc)
            {
                evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", DataNameTemplate.Loai_Dat);
                onCalculating(evt);
                onFinished(evt);
                return;
            }
            #endregion

            #region he so vi tri
            ITable tblHesoVitri;
            try
            {
                tblHesoVitri = fw.OpenTable(DataNameTemplate.He_So_K);
            }
            catch (Exception exc)
            {
                evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", DataNameTemplate.He_So_K);
                onCalculating(evt);
                onFinished(evt);
                return;
            }
            #endregion

            #region khac
            IQueryFilter qrf = new QueryFilterClass();
            bool result = false;
            int sothuatimthay = 0;
            int sothuatinhduoc = 0;
            int sothuaKhongTinhDuoc = 0;
            _dataManager = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            _version = SdeVersionsTool.CallMe();
            _clipTool = new GExtractTool(sdeConn.Environment);
            string duongBuffer50mNoSde = FilterSdeLayerName.GetActualName(DataNameTemplate.Duong_Buffer_);
            duongBuffer50mNoSde += _currentConfig.DKhoangCach50mMatTien;
            string thuaClip50mNoSde=FilterSdeLayerName.GetActualName(DataNameTemplate.Thua_Clip_);
            thuaClip50mNoSde += _currentConfig.DKhoangCach50mMatTien;
            string duongBuffer50mCoSde = string.Format("{0}{1}", DataNameTemplate.Duong_Buffer_, _currentConfig.DKhoangCach50mMatTien);
            string thuaClip50mCoSde = string.Format("{0}{1}", DataNameTemplate.Thua_Clip_, _currentConfig.DKhoangCach50mMatTien);
            #endregion

            #endregion
            //************************************

            //*******************************************
            //===========================================
            //===========================================

            #region bat dau tinh
            _bufferTool = new GProximityTool(sdeConn.Environment);
            
            if (!_dataManager.LayerExist(duongBuffer50mNoSde))
            {

                _bufferTool.BufferInsideSde(duongFeatureClass.AliasName, duongBuffer50mNoSde, _currentConfig.DKhoangCach50mMatTien);
            }
            IFeatureClass duongBuff50FeatureClass = fw.OpenFeatureClass(duongBuffer50mNoSde);
            IFeatureLayer duongBuff50FeatureLayer = new FeatureLayerClass();
            ISelectionSet duongBuff50Sls;
            IFeatureSelection duongBuff50Fsls;
            duongBuff50FeatureLayer.FeatureClass = duongBuff50FeatureClass;

            #region test
            //string ex = string.Format("VongLap(ChonDuong('dorong=10'),VongLap(ChonThua('dientich<1.5'),test([doituonglap]),[doituonglap]))");
            ////ex=string.Format("VongLap(DuongDangChon(),VongLap()
            //Evaluation evalu = new Evaluation(ex);
            //evalu.DuongLayer = duongFeatureLayer;
            //evalu.ThuaLayer = thuaFeatureLayer;
            //evalu.EvaluateCalculating();
            //return;

            #endregion

            //[thaydoi] - cac may tinh khac chi can thay dieu kien truy van he so vi tri
            //******************************************************************
            #region lay cac quy tac tim vi tri

            #region log---
            evt.Log = string.Format("\n----Lấy các quy tắc tìm vị trí thửa từ bảng {0}, ứng với hệ số {1} ...", DataNameTemplate.He_So_K, TnHeSoK.DatOMatTienHon50mDt);
            onCalculating(evt);
            #endregion

            qrf.WhereClause = string.Format("{0}='{1}'", "hesovitri", TnHeSoK.DatOMatTienHon50mDt);
            ICursor cur = tblHesoVitri.Search(qrf, false);
            string quytac = "";
            string cachtinh = "";
            string cachtinhdongia = "";
            try
            {
                IRow row = cur.NextRow();
                if (row != null)
                {
                    quytac = row.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.QUY_TAC)).ToString();
                    cachtinh = row.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH)).ToString();
                    cachtinhdongia = row.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH_DON_GIA)).ToString();
                }
            }
            catch { }
            finally
            {
                Marshal.ReleaseComObject(cur);
            }
            #endregion

            #region tinh theo xa
            if (this._inputParams.MA_XA != "-1")
            {
                //[kodoi]
                //=======================
                #region chon xa co ma dang xet
                //neu dang tinh cho 1 xa
                if (_inputParams.MA_XA != "*")
                {
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_RANH_XA_POLY.MA_XA, _inputParams.MA_XA);
                }
                else//neu dang tinh cho toan huyen
                {
                    qrf.WhereClause = "";
                }
                ISelectionSet xaSelectionSet = xaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                xaFeatureSelection = (IFeatureSelection)xaFeatureLayer;
                xaFeatureSelection.SelectionSet = xaSelectionSet;
                #endregion
                //=======================

                #region vong lap tung xa

                //[thaydoi] - co the them bien chay
                //*************************
                #region khoi dau
                IEnumIDs xaIds = xaSelectionSet.IDs;
                int xaId = 0;
                IFeature xaFt = null;
                List<object> lstMaDuong = new List<object>();
                #endregion
                //*************************

                while ((xaId = xaIds.Next()) != -1)
                {
                    //[kodoi]
                    //=======================
                    #region lay thong tin xa
                    xaFt = xaFeatureClass.GetFeature(xaId);
                    string maxa = xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.MA_XA)).ToString();
                    string tenxa = xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.TEN_XA)).ToString();
                    string loaixa = xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.MA_LOAI_XA)).ToString();
                    int loaidothi = 0;
                    result = int.TryParse(xaFt.get_Value(xaFt.Fields.FindField(_fcName.FC_RANH_XA_POLY.LOAI_DO_THI)).ToString(), out loaidothi);
                    #endregion

                    if (loaidothi == 0)
                    {
                        continue;
                    }

                    #region -----log
                    evt.Log = string.Format("\n************************************************");
                    evt.Log += string.Format("\n******   Đang tính cho xã/phường: {0}  ******", tenxa);
                    evt.Log += string.Format("\n************************************************");
                    onCalculating(evt);
                    #endregion

                    #region tim duong trong khu vuc do thi bang qua xa
                    //chon xa dang xet
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_RANH_XA_POLY.OID, xaId);
                    xaSelectionSet = xaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                    xaFeatureSelection = (IFeatureSelection)xaFeatureLayer;
                    xaFeatureSelection.SelectionSet = xaSelectionSet;
                    //Chon cac duong co do rong theo quy dinh
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.PHAN_LOAI, _isDothi);// "maduong='2'";
                    ISelectionSet duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                    duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;
                    duongFeatureSelection.SelectionSet = duongSelectionSet;

                    //bat dau truy van khong gian
                    _qrBl.FromLayer = duongFeatureLayer;
                    _qrBl.ByLayer = xaFeatureLayer;
                    _qrBl.LayerSelectionMethod = esriLayerSelectionMethod.esriLayerSelectIntersect;
                    _qrBl.ResultType = esriSelectionResultEnum.esriSelectionResultAnd;
                    _qrBl.UseSelectedFeatures = true;

                    duongSelectionSet = _qrBl.Select();

                    #endregion
                    //=======================

                    #region vong lap xet tung duong

                    //[thaydoi] - co the them bien chay
                    //===============================
                    #region khoi dau
                    IEnumIDs eIds = duongSelectionSet.IDs;
                    int duongId;
                    IFeature duongFt;
                    int iDuong = 0;
                    int progressingTotalCount = 1;
                    evt.Reset();
                    evt.ProgressingTotal = duongSelectionSet.Count;
                    onCalculating(evt);
                    //List<object> lstMaDuong = new List<object>();
                    #endregion
                    //================================

                    while ((duongId = eIds.Next()) != -1)
                    {
                        //[kodoi]
                        //======================
                        #region log-----
                        evt.Reset();
                        evt.ProgressingTotalCount = progressingTotalCount;
                        onCalculating(evt);
                        progressingTotalCount++;
                        #endregion
                        //======================

                        //[capnhat] - lay ten duong tu bang ten duong
                        //++++++++++++++++++++++++
                        #region lay thong tin cua duong dang xet

                        duongFt = duongFeatureClass.GetFeature(duongId);
                        string tenduong = "";//ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.TEN_DUONG)).ToString();
                        object maduong = duongFt.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.MA_DUONG));
                        //lstMaDuong.Add(maduong);
                        string batdau = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.BAT_DAU)).ToString();
                        string ketthuc = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.KET_THUC)).ToString();

                        #endregion
                        //++++++++++++++++++++++++

                        //[kodoi]
                        //Chon duong dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
                        //====================
                        #region chon duong dang xet

                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                        duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                        duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;

                        duongFeatureSelection.SelectionSet = duongSelectionSet;
                        #endregion
                        //====================

                        //tim cac thua theo dieu kien mat tien
                        #region tinh vi tri cho cac thua
                        //doc cach tim thua trong bang he so vi tri
                        //lay cach tim cho dat o
                        //truyen thong so cach tinh,thualayer,duonglayer,khoangcach

                        

                        //MessageBox.Show(func);
                        //func = "ChongLop([INTERSECT],[NEW_SELECTION],1) Then ChongLop([CONTAINED_BY],[AND_SELECTION],50)";

                        //[kodoi]
                        //============================
                        #region tim cac thua theo vi tri quy dinh
                        thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                        thuaFeatureSelection.Clear();
                        Evaluation eval = new Evaluation(quytac);
                        eval.ThuaLayer = thuaFeatureLayer;
                        eval.DuongLayer = duongFeatureLayer;
                        eval.EvaluateQuery();
                        //thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                        ISelectionSet thuaSelectionSet = thuaFeatureSelection.SelectionSet;
                        #endregion
                        //============================

                        //MessageBox.Show(thuaSelectionSet.Count.ToString());
                        #endregion

                        #region clip cac thua vua tim duoc

                        #region delete bang thua_sau50m_clip
                        IFeatureClass thuaClipFc = null;
                        #region log---
                        evt.Log = string.Format("\n----Kiểm tra, xóa bảng {0} ...", thuaClip50mCoSde);
                        onCalculating(evt);
                        #endregion

                        if (_dataManager.LayerExist(thuaClip50mNoSde))
                        {
                            //thuaClipFc = fw.OpenFeatureClass("sde.thua_sau50m_clip");
                            //mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                            //wspEdit.StartEditing(false);
                            //wspEdit.StartEditOperation();
                            ((IFeatureClassManager)_dataManager).DeleteFcInSde(thuaClip50mCoSde);
                            //((IDataset)thuaClipFc).Delete();
                            //wspEdit.StopEditOperation();
                            //wspEdit.StopEditing(true);
                        }
                        #endregion

                        #region chon duong buffer 50 dang xet
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                        duongBuff50Sls = duongBuff50FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                        duongBuff50Fsls = (IFeatureSelection)duongBuff50FeatureLayer;
                        duongBuff50Fsls.SelectionSet = duongBuff50Sls;
                        #endregion

                        #region log---
                        evt.Log = string.Format("\n----Kiểm tra, clip thửa theo đường buffer {0}m, lưu vào bảng {1} ...", _currentConfig.DKhoangCach50mMatTien, thuaClip50mCoSde);
                        onCalculating(evt);
                        #endregion

                        string thualyr = string.Format("{0}/{1}", _sysTempPath.TempPath, thuaClip50mNoSde);
                        string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, duongBuffer50mNoSde);
                        _clipTool.ClipByLayerFileInsideSde(thuaFeatureLayer, thualyr, duongBuff50FeatureLayer, duonglyr, thuaClip50mNoSde);
                        try
                        {
                            thuaClipFc = fw.OpenFeatureClass(thuaClip50mCoSde);
                        }
                        catch (Exception ex) { continue; }
                        _version.RegisterDataset((IDataset)thuaClipFc, true, true);
                        #endregion

                        //[kodoi]
                        //============================
                        #region ----log
                        if (thuaSelectionSet.Count == 0)
                        {
                            evt.Log = string.Format("\n !!! Không tìm thấy thửa nào tiếp giáp với đường {0} đoạn từ {1} đến {2} và nằm trong vùng buffer 50m", tenduong, batdau, ketthuc);
                            onCalculating(evt);

                            #region report progressing duong
                            if (iDuong < duongSelectionSet.Count)
                            {
                                decimal i = (decimal)iDuong % (decimal)duongSelectionSet.Count * 100;
                                int i1 = Convert.ToInt32(i);
                                this._bgwCalculating.ReportProgress(i1);
                                //MessageBox.Show("log 009");
                            }
                            else
                            {
                                this._bgwCalculating.ReportProgress(99);
                            }
                            iDuong++;
                            #endregion

                            continue;
                        }
                        #endregion
                        sothuatimthay += thuaSelectionSet.Count;
                        //============================

                        #region xet tung thua

                        //[thaydoi] - co the them bien chay
                        //********************
                        #region khoi dau
                        IEnumIDs thuaIds = thuaSelectionSet.IDs;
                        int thuaId;
                        IFeature thuaFt;
                        int iThua = 0;
                        List<object[,]> pairColValTgd = new List<object[,]>();
                        int rowTgdNnHandleUpdate = 0;
                        List<object> newId = new List<object>();
                        #endregion
                        //********************

                        while ((thuaId = thuaIds.Next()) != -1)
                        {
                            int hesoVitri = TnHeSoK.DatOMatTienHon50mDt;

                            #region chon thua dang xet
                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.OID, thuaId);
                            thuaSelectionSet = thuaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                            thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                            thuaFeatureSelection.SelectionSet = thuaSelectionSet;
                            #endregion

                            //[thaydoi] - co them them dieu kien de xac dinh vi tri cua thua
                            //***********************************
                            #region lay thong tin thua dang xet

                            //[kodoi]
                            //============================
                            #region lay thong tin co ban
                            thuaFt = thuaFeatureClass.GetFeature(thuaId);
                            //neu thua bi khoa tim vi tri,bo qua,xet thua ke
                            string lockTimVitri = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOCKED)).ToString();
                            if (lockTimVitri == "1")
                            {
                                sothuaKhongTinhDuoc++;

                                #region report progressing thua
                                if (iThua < thuaSelectionSet.Count)
                                {
                                    decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                    int i1 = Convert.ToInt32(i);
                                    this._bgwCalculating.ReportProgress(i1);
                                    //MessageBox.Show("log 009");
                                }
                                else
                                {
                                    this._bgwCalculating.ReportProgress(99);
                                }
                                iThua++;
                                #endregion

                                continue;

                            }
                            //neu thua ko thuoc xa dang xet thi ko tinh tiep
                            object mathua = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_THUA));
                            object maxaThua = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_XA));
                            object dientichpl = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.DIEN_TICH));
                            #endregion
                            //============================

                            //[kodoi]
                            //============================
                            #region kiem tra maxa
                            if (maxaThua.ToString() == "" || maxaThua == null)
                            {
                                maxaThua = "0";

                                #region ----log
                                evt.Log = string.Format("Chưa xác định mã xã cho thửa {0}", mathua);
                                #endregion

                                sothuaKhongTinhDuoc++;

                                #region report progressing thua
                                if (iThua < thuaSelectionSet.Count)
                                {
                                    decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                    int i1 = Convert.ToInt32(i);
                                    this._bgwCalculating.ReportProgress(i1);
                                    //MessageBox.Show("log 009");
                                }
                                else
                                {
                                    this._bgwCalculating.ReportProgress(99);
                                }
                                iThua++;
                                #endregion

                                continue;
                            }
                            #region danh rieng khi tinh theo xa
                            else if (maxaThua.ToString() != maxa)
                            {
                                #region ----log
                                evt.Reset();
                                evt.Log = string.Format("thửa {0} không thuộc xã {1}", mathua, tenxa);
                                onCalculating(evt);
                                #endregion
                                sothuaKhongTinhDuoc++;
                                #region report progressing thua
                                if (iThua < thuaSelectionSet.Count)
                                {
                                    decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                    int i1 = Convert.ToInt32(i);
                                    this._bgwCalculating.ReportProgress(i1);
                                    //MessageBox.Show("log 009");
                                }
                                else
                                {
                                    this._bgwCalculating.ReportProgress(99);
                                }
                                iThua++;
                                #endregion

                                continue;
                            }
                            #endregion
                            #endregion

                            #region lay thong tin loai do thi
                            //neu ko la do thi thi bo qua,xet thua ke
                            qrf.WhereClause = string.Format("{0}={1}", _fcName.FC_RANH_XA_POLY.MA_XA, maxaThua);
                            IFeatureCursor fcrXa = xaFeatureClass.Search(qrf, false);

                            IFeature ftXa = fcrXa.NextFeature();
                            string loaiDoThi = "";
                            if (ftXa != null)
                            {
                                loaiDoThi = ftXa.get_Value(ftXa.Fields.FindField(_fcName.FC_RANH_XA_POLY.LOAI_DO_THI)).ToString();
                            }
                            else
                            {
                                loaiDoThi = "0";
                            }
                            if (loaiDoThi == "0")
                            {
                                sothuaKhongTinhDuoc++;

                                #region report progressing thua
                                if (iThua < thuaSelectionSet.Count)
                                {
                                    decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                    int i1 = Convert.ToInt32(i);
                                    this._bgwCalculating.ReportProgress(i1);
                                    //MessageBox.Show("log 009");
                                }
                                else
                                {
                                    this._bgwCalculating.ReportProgress(99);
                                }
                                iThua++;
                                #endregion

                                continue;
                            }
                            #endregion
                            //============================

                            #region lay loai dat

                            //neu ko co dat phi nong nghiep thi bo qua,xet thua ke
                            //neu co dat nong nghiep thi datnn=true
                            //neu la dat hon hop, neu co dat sxkd thi datsxkd=true, 
                            //neu co dat o thi codato=true
                            //cac truong hop he so vi tri:
                            //o:3010, sxkd:4010, o+nn:5010, o+sxkd:6010
                            string loaidat = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOAI_DAT)).ToString();
                            //evt.Log = string.Format("\n loai dat cua thua {0} la {1}", thuaId, loaidat);
                            //onCalculating(evt);

                            //[thaydoi] - may tinh dat nong nghiep co the khac
                            //***********************
                            #region kiem tra dat phi nong nghiep
                            bool datpnn = false;
                            foreach (string s in TnLoaiDats.PHI_NONG_NGHIEP_DOTHI)
                            {
                                if (loaidat.Contains(s))
                                {
                                    datpnn = true;
                                    break;
                                }
                                else
                                {
                                    datpnn = false;
                                }
                            }
                            if (!datpnn)
                            {
                                sothuaKhongTinhDuoc++;

                                #region report progressing thua
                                if (iThua < thuaSelectionSet.Count)
                                {
                                    decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                    int i1 = Convert.ToInt32(i);
                                    this._bgwCalculating.ReportProgress(i1);
                                    //MessageBox.Show("log 009");
                                }
                                else
                                {
                                    this._bgwCalculating.ReportProgress(99);
                                }
                                iThua++;
                                #endregion

                                continue;
                            }
                            #endregion
                            //***********************

                            //[thaydoi] - may tinh dat nong nghiep co the khac
                            //***********************
                            #region kiem tra dat honhop
                            bool codatsxkd = false;
                            bool dathonhop = false;
                            bool codato = false;
                            bool chicodato = false;
                            bool chicodatsxkd = false;
                            bool codatnn = false;
                            string loaidatNn = "";

                            //evt.Log = string.Format("line 983 mattien, loaidat:{0}", loaidat);
                            //onCalculating(evt);
                            if (loaidat.Contains("+"))
                            {
                                //evt.Log = string.Format("line 987 mattien, loaidat:{0}, co +", loaidat);
                                //onCalculating(evt);
                                dathonhop = true;
                                #region kiem tra co dat o
                                foreach (string dato in TnLoaiDats.PNN_O_DT)
                                {
                                    if (loaidat.Contains(dato))
                                    {
                                        //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                                        //onCalculating(evt);

                                        codato = true;
                                        break;
                                    }
                                }
                                #endregion

                                #region kiem tra co dat nong nghiep

                                foreach (string s in TnLoaiDats.NONG_NGHIEP)
                                {
                                    if (loaidat.Contains(s))
                                    {
                                        codatnn = true;
                                        loaidatNn = s;

                                        break;
                                    }
                                    else
                                    {
                                        codatnn = false;
                                    }
                                }
                                #endregion

                                #region kiem tra chi co dat sxkd
                                foreach (string s in TnLoaiDats.PNN_SX_KD)
                                {
                                    if (loaidat == s)
                                    {
                                        chicodatsxkd = true;

                                        break;
                                    }

                                    else
                                    {
                                        chicodatsxkd = false;
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region kiem tra chi co dat o
                                foreach (string dato in TnLoaiDats.PNN_O_DT)
                                {
                                    if (loaidat.Contains(dato))
                                    {
                                        //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                                        //onCalculating(evt);
                                        chicodato = true;
                                        break;
                                    }
                                    else
                                    {
                                        chicodato = false;
                                    }
                                }
                                #endregion

                                #region kiem tra chi co dat sxkd
                                foreach (string s in TnLoaiDats.PNN_SX_KD)
                                {
                                    if (loaidat == s)
                                    {
                                        chicodatsxkd = true;

                                        break;
                                    }

                                    else
                                    {
                                        chicodatsxkd = false;
                                    }
                                }
                                #endregion

                            }

                            #endregion
                            //***********************

                            #endregion

                            #endregion
                            //***********************************

                            //[thaydoi] - thay doi he so vi tri phu hop
                            //***********************************
                            #region quyet dinh he so vi tri cho thua
                            if (chicodato)
                            {
                                hesoVitri = TnHeSoK.DatOMatTienHon50mDt;
                            }
                            else if (chicodatsxkd)
                            {
                                hesoVitri = TnHeSoK.DatSxkdMatTienHon50mDt;
                            }
                            else if (dathonhop && codato && codatnn)
                            {
                                hesoVitri = TnHeSoK.DatONnMatTienHon50mDt;
                            }
                            //else if (dathonhop && codato && codatsxkd)
                            //{
                            //    hesoVitri = TnHeSoK.DatOSxkdMatTienh;
                            //}
                            #endregion
                            //***********************************

                            //[thaydoi] - thay doi dieu kien truy van ung voi tung may tinh khac nhau
                            //***********************************
                            #region kiem tra trong bang thua_giadat, voi dieu kien:mathua,maduong,hesovitri,khoagia=0
                            evt.Reset();
                            evt.Log = "\n[!]--- Kiểm tra các vị trí, cập nhật vị trí mới ...";
                            onCalculating(evt);
                            qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}' and {7}='{8}'",
                                _fcName.FC_THUA_GIADAT_DRAFT.LOCKED, 0, _fcName.FC_THUA_GIADAT_DRAFT.LOCKED,
                                _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua,
                                _fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG, maduong,
                                _fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K, hesoVitri);
                            IFeatureCursor tgdFcs = tgdFeatureClass.Search(qrf, false);
                            IFeature tgdRow = null;
                            //MessageBox.Show(string.Format("line 1401 CalcPosThuaMattien - bat dau try, query:\n{0}", qrf.WhereClause));
                            try
                            {
                                tgdRow = tgdFcs.NextFeature();//dam bao la chi co 1 hang ket qua  
                                Marshal.ReleaseComObject(tgdFcs);
                                if (tgdRow != null)
                                {
                                    //MessageBox.Show("co");
                                    //kiem tra co cho phep tinh lai vi tri
                                    //neu co:xoa feater cu,them feature moi
                                    #region xet thua da co vi tri

                                    bool isOverWritePos = true;

                                    if (!isOverWritePos)
                                    {
                                        newId.Add(tgdRow.OID);
                                        //continue;
                                    }
                                    else
                                    {
                                        //[kodoi]
                                        //===================
                                        #region xoa feature cu
                                        wspEdit.StartEditing(true);
                                        wspEdit.StartEditOperation();
                                        //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                                        //tblThuaGiaDat.DeleteSearchedRows(qrf);
                                        tgdRow.Delete();
                                        wspEdit.StopEditOperation();
                                        wspEdit.StopEditing(true);
                                        #endregion
                                        //===================

                                        #region chon trong bang thua clip
                                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathua);
                                        IFeatureCursor thuaClipFcur = thuaClipFc.Search(qrf, false);
                                        IFeature thuaClipFt = null;
                                        try
                                        {
                                            thuaClipFt = thuaClipFcur.NextFeature();
                                        }
                                        catch (Exception ex) { return; }
                                        finally { Marshal.ReleaseComObject(thuaClipFcur); }

                                        #region lay thong tin thua clip
                                        IArea area = (IArea)thuaClipFt.Shape;
                                        #endregion

                                        #endregion

                                        #region them feature moi

                                        object copiedId = null;
                                        try
                                        {
                                            mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                            wspEdit.StartEditOperation();
                                            copiedId = copyTool.Copy(thuaClipFt, tgdFeatureClass);
                                            wspEdit.StopEditOperation();
                                            wspEdit.StopEditing(true);
                                        }
                                        catch (Exception ex)
                                        {
                                            wspEdit.AbortEditOperation();
                                            wspEdit.StopEditing(false);
                                        }

                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), Math.Round(area.Area, 2) } });
                                        sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                        //MessageBox.Show(string.Format("line 1604 CalcPosThuaSau50m copiedId={0}", copiedId));
                                        rowTgdNnHandleUpdate++;
                                        pairColValTgd.Clear();
                                        newId.Add(copiedId);
                                        #endregion

                                        //[thaydoi] - them gia tri
                                        //**********************
                                        #region clip thua dang xet
                                        /*
                                    #region chon duong buffer 50 dang xet
                                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                                    duongBuff50Sls = duongBuff50FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                                    duongBuff50Fsls = (IFeatureSelection)duongBuff50FeatureLayer;
                                    duongBuff50Fsls.SelectionSet = duongBuff50Sls;
                                    #endregion
                                    //_clipTool = new TnClip(sdeConn.Environment);
                                    //string thualyr = string.Format("{0}/{1}", _sysTempPath.TempPath, "thua_sau50m_clip.lyr");
                                    //string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, "duong_sau50m_clip.lyr");
                                    //_clipTool.ClipByLayerFileInsideSde(thuaFeatureLayer, thualyr, duongBuff50FeatureLayer, duonglyr, "thua_sau50m_clip");
                                    //_dataManager.SaveToLayerFile((ILayer)thuaFeatureLayer, thualyr);
                                    //_dataManager.SaveToLayerFile((ILayer)duongBuff50FeatureLayer, duonglyr);
                                    //_clipTool.Clip(thualyr, duonglyr, "thua_sau50m_clip");
                                    //MessageBox.Show(string.Format("line 1459 CalPosThuaSau50m {0}", _sysTempPath.TempFullPathNoEnd));
                                    IFeatureClass fcThuaCliped = _dataManager.TnOpenFeatureClassFromFileMdb(_sysTempPath.TempFullPathNoEnd, "thua_sau50m_clip");
                                    string clipPath = string.Format("{0}{1}", _sysTempPath.TempFullPath, "thua_sau50m_clip");
                                    IFeatureLayer flThuaCliped = new FeatureLayerClass();
                                    flThuaCliped.FeatureClass = fcThuaCliped;
                                    IFeatureCursor fcur = fcThuaCliped.Search(null, false);
                                    IFeature clipFt = null;
                                    try
                                    {
                                        clipFt = fcur.NextFeature();
                                    }
                                    catch { continue; }
                                    finally { Marshal.ReleaseComObject(fcur); }
                                    if (clipFt == null)
                                    {
                                        continue;
                                    }
                                    #endregion

                                    #region lay thong tin thua clip
                                    IArea area = (IArea)clipFt.Shape;
                                    #endregion

                                    #region them feature moi
                                    wspEdit.StartEditing(true);
                                    wspEdit.StartEditOperation();
                                    object copiedId = copyTool.CopyFromMdb(clipFt, tgdFeatureClass);
                                    //copyTool.CopyUseGeoprocessing(clipPath, tgdFeatureClass.AliasName);
                                    //IFeatureCursor fcurClip = tgdFeatureClass.Search(null, false);
                                    //object copiedId = null;
                                    //IFeature ftClip = null;
                                    //try
                                    //{
                                    //    while ((ftClip = fcurClip.NextFeature()) != null)
                                    //    {
                                    //        copiedId = ftClip.get_Value(0);
                                    //    }
                                    //}
                                    //catch {  }
                                    //finally { Marshal.ReleaseComObject(fcurClip); }
                                    wspEdit.StopEditOperation();
                                    wspEdit.StopEditing(true);
                                    //them gia tri mathua,maduong,hesovitri
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), area.Area } });
                                    sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                    MessageBox.Show(string.Format("line 1533 CalcPosThuaSau50m copiedId={0}", copiedId));
                                    rowTgdNnHandleUpdate++;
                                    pairColValTgd.Clear();
                                    newId.Add(copiedId);
                                     * */
                                    #endregion
                                        //**********************
                                    }

                                    #endregion

                                }
                                else
                                {
                                    #region chon trong bang thua clip
                                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathua);
                                    IFeatureCursor thuaClipFcur = thuaClipFc.Search(qrf, false);
                                    IFeature thuaClipFt = null;
                                    try
                                    {
                                        thuaClipFt = thuaClipFcur.NextFeature();
                                    }
                                    catch (Exception ex) { return; }
                                    finally { Marshal.ReleaseComObject(thuaClipFcur); }

                                    #region lay thong tin thua clip
                                    IArea area = (IArea)thuaClipFt.Shape;
                                    #endregion

                                    #endregion

                                    #region them feature moi

                                    object copiedId = null;
                                    try
                                    {
                                        mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        wspEdit.StartEditOperation();
                                        copiedId = copyTool.Copy(thuaClipFt, tgdFeatureClass);
                                        wspEdit.StopEditOperation();
                                        wspEdit.StopEditing(true);
                                    }
                                    catch (Exception ex)
                                    {
                                        wspEdit.AbortEditOperation();
                                        wspEdit.StopEditing(true);
                                    }

                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), Math.Round(area.Area, 2) } });
                                    sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                    //MessageBox.Show(string.Format("line 1604 CalcPosThuaSau50m copiedId={0}", copiedId));
                                    rowTgdNnHandleUpdate++;
                                    pairColValTgd.Clear();
                                    newId.Add(copiedId);
                                    #endregion
                                    //MessageBox.Show("ko co");
                                    //***********************************
                                }
                                //MessageBox.Show(newId.Count.ToString());
                            }
                            catch (Exception e1) { MessageBox.Show(string.Format("CalcPosThuaSau50m, line 1448-\n{0}", e1)); }
                            finally { Marshal.ReleaseComObject(tgdFcs); }
                            #endregion
                            //***********************************

                            #region report progressing thua
                            if (iThua < thuaSelectionSet.Count)
                            {
                                decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                int i1 = Convert.ToInt32(i);
                                this._bgwCalculating.ReportProgress(i1);
                                //MessageBox.Show("log 009");
                            }
                            else
                            {
                                this._bgwCalculating.ReportProgress(99);
                            }
                            iThua++;
                            #endregion
                        }
                        #endregion

                        //[kodoi]
                        //============================
                        #region luu thong tin vao bang gia dat
                        if (!sdeTblTgdEditor.IsEditing())
                        {
                            sdeTblTgdEditor.StartEditing(true);
                            sdeTblTgdEditor.StartEditOperation();
                        }

                        #region ----log
                        evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", tgdDraft);
                        onCalculating(evt);
                        #endregion

                        sdeTblTgdEditor.SaveEdit();
                        sdeTblTgdEditor.StopEditOperation();
                        sdeTblTgdEditor.StopEditing(true);

                        #region ----log
                        evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", tgdDraft);
                        onCalculating(evt);
                        #endregion

                        #endregion

                        #region tinh gia dat cho cac thua vua them vi tri
                        CalcLandprice calc = new CalcLandprice(this);
                        //MessageBox.Show(string.Format("final:{0}", newId.Count));
                        calc.Maduong = maduong;
                        calc.Calculate(newId);
                        newId.Clear();
                        #endregion
                        //============================



                    }
                    #endregion

                }
                #endregion
            }
            #endregion
            //=====================================================================
            //=====================================================================
            #region tinh theo duong,doan duong
            else
            {
                #region timduong co ten dang xet
                //tinh theo doan duong
                #region tinh theo doan duong
                if (_inputParams.MA_DUONG != "-1")
                {
                    qrf.WhereClause = string.Format("{0}={1} and {2}={3}", _fcName.FC_DUONG.MA_DUONG, _inputParams.MA_DUONG, _fcName.FC_DUONG.PHAN_LOAI, _isDothi);// "maduong='2'";

                    #region ----log
                    evt.Log = string.Format("\n************************************************");
                    evt.Log += string.Format("\n******   Đang tính cho đoạn đường có mã: {0}  ******", _inputParams.MA_DUONG);
                    evt.Log += string.Format("\n************************************************");
                    onCalculating(evt);
                    #endregion
                }
                #endregion
                //tinh cho 1 duong
                #region tinh cho 1 duong
                else if (_inputParams.TEN_DUONG != "" && _inputParams.TEN_DUONG != "*")
                {
                    //phai sua lai thiet ke
                    //dung relationshipclass many to many gia duong va ten duong
                    #region tim trong bang ten duong
                    qrf.WhereClause = string.Format("{0}=N'{1}'", _tblName.TEN_DUONG.TEN_DUONG, _inputParams.TEN_DUONG);
                    ICursor tenduongCur = tblTenDuong.Search(qrf, false);
                    object idDuong;
                    List<object> lstIdDuong = new List<object>();
                    try
                    {
                        IRow tenduongRow = null;
                        while ((tenduongRow = tenduongCur.NextRow()) != null)
                        {
                            idDuong = tenduongRow.get_Value(tenduongRow.Fields.FindField(_tblName.TEN_DUONG.MA_DUONG));
                            lstIdDuong.Add(idDuong);
                        }
                    }
                    catch
                    { }
                    finally { Marshal.ReleaseComObject(tenduongCur); }
                    #endregion

                    #region tim trong bang duong
                    string q = "";
                    for (int i = 0; i < lstIdDuong.Count; i++)
                    {
                        if (i == lstIdDuong.Count - 1)
                        {
                            q += string.Format("{0}='{1}'", _fcName.FC_DUONG.MA_DUONG, lstIdDuong[i]);
                        }
                        else
                        {
                            q += string.Format("{0}='{1}' or ", _fcName.FC_DUONG.MA_DUONG, lstIdDuong[i]);
                        }
                    }
                    qrf.WhereClause = q;// "maduong='2'";

                    #region ----log
                    evt.Log = string.Format("\n************************************************");
                    evt.Log += string.Format("\n******   Đang tính cho cả đường: {0}  ******", _inputParams.TEN_DUONG);
                    evt.Log += string.Format("\n************************************************");
                    onCalculating(evt);
                    #endregion
                    #endregion
                }
                #endregion
                //tinh cho ca duong
                else
                {
                    qrf.WhereClause = "";
                }
                //MessageBox.Show(string.Format("whereclause:{0}",duong.QueryFilter.WhereClause));
                ISelectionSet duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);

                if (duongSelectionSet.Count == 0)
                {
                    return;
                }
                duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;
                duongFeatureSelection.SelectionSet = duongSelectionSet;

                #endregion

                #region vong lap xet tung duong

                //[thaydoi] - co the them bien chay
                //===============================
                #region khoi dau
                IEnumIDs eIds = duongSelectionSet.IDs;
                int duongId;
                IFeature duongFt;
                int iDuong = 0;
                int progressingTotalCount = 1;
                evt.Reset();
                evt.ProgressingTotal = duongSelectionSet.Count;
                onCalculating(evt);
                //List<object> lstMaDuong = new List<object>();
                #endregion
                //================================

                while ((duongId = eIds.Next()) != -1)
                {
                    //[kodoi]
                    //======================
                    #region log-----
                    evt.Reset();
                    evt.ProgressingTotalCount = progressingTotalCount;
                    onCalculating(evt);
                    progressingTotalCount++;
                    #endregion
                    //======================

                    //[capnhat] - lay ten duong tu bang ten duong
                    //++++++++++++++++++++++++
                    #region lay thong tin cua duong dang xet

                    duongFt = duongFeatureClass.GetFeature(duongId);
                    string tenduong = "";//ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.TEN_DUONG)).ToString();
                    object maduong = duongFt.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.MA_DUONG));
                    //lstMaDuong.Add(maduong);
                    string batdau = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.BAT_DAU)).ToString();
                    string ketthuc = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.KET_THUC)).ToString();

                    #endregion
                    //++++++++++++++++++++++++

                    //[kodoi]
                    //Chon duong dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
                    //====================
                    #region chon duong dang xet
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                    duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                    duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;

                    duongFeatureSelection.SelectionSet = duongSelectionSet;
                    #endregion
                    //====================

                    //tim cac thua theo dieu kien mat tien
                    #region tinh vi tri cho cac thua
                    //doc cach tim thua trong bang he so vi tri
                    //lay cach tim cho dat o
                    //truyen thong so cach tinh,thualayer,duonglayer,khoangcach

                    //MessageBox.Show(func);
                    //func = "ChongLop([INTERSECT],[NEW_SELECTION],1) Then ChongLop([CONTAINED_BY],[AND_SELECTION],50)";

                    //[kodoi]
                    //============================
                    #region tim cac thua theo vi tri quy dinh
                    thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                    thuaFeatureSelection.Clear();
                    Evaluation eval = new Evaluation(quytac);
                    eval.ThuaLayer = thuaFeatureLayer;
                    eval.DuongLayer = duongFeatureLayer;
                    eval.EvaluateQuery();
                    //thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                    ISelectionSet thuaSelectionSet = thuaFeatureSelection.SelectionSet;
                    #endregion
                    //============================

                    //MessageBox.Show(thuaSelectionSet.Count.ToString());
                    #endregion

                    #region clip cac thua vua tim duoc

                    #region delete bang thua_sau50m_clip
                    IFeatureClass thuaClipFc=null;
                    #region log---
                    evt.Log = string.Format("\n----Kiểm tra, xóa bảng {0} ...", thuaClip50mCoSde);
                    onCalculating(evt);
                    #endregion
                    
                    if (_dataManager.LayerExist(thuaClip50mNoSde))
                    {
                        //thuaClipFc = fw.OpenFeatureClass("sde.thua_sau50m_clip");
                        //mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                        //wspEdit.StartEditing(false);
                        //wspEdit.StartEditOperation();
                        ((IFeatureClassManager)_dataManager).DeleteFcInSde(thuaClip50mCoSde);
                        //((IDataset)thuaClipFc).Delete();
                        //wspEdit.StopEditOperation();
                        //wspEdit.StopEditing(true);
                    }
                    #endregion

                    #region chon duong buffer 50 dang xet
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                    duongBuff50Sls = duongBuff50FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                    duongBuff50Fsls = (IFeatureSelection)duongBuff50FeatureLayer;
                    duongBuff50Fsls.SelectionSet = duongBuff50Sls;
                    #endregion

                    #region log---
                    evt.Log = string.Format("\n----Kiểm tra, clip thửa theo đường buffer {0}m, lưu vào bảng {1} ...", _currentConfig.DKhoangCach50mMatTien, thuaClip50mCoSde);
                    onCalculating(evt);
                    #endregion

                    string thualyr = string.Format("{0}/{1}", _sysTempPath.TempPath, thuaClip50mNoSde);
                    string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, duongBuffer50mNoSde);
                    _clipTool.ClipByLayerFileInsideSde(thuaFeatureLayer, thualyr, duongBuff50FeatureLayer, duonglyr, thuaClip50mNoSde);
                    try
                    {
                        thuaClipFc = fw.OpenFeatureClass(thuaClip50mCoSde);
                    }
                    catch (Exception ex) { continue; }
                    _version.RegisterDataset((IDataset)thuaClipFc, true, true);
                    #endregion

                    //[kodoi]
                    //============================
                    #region ----log
                    if (thuaSelectionSet.Count == 0)
                    {
                        evt.Log = string.Format("\n !!! Không tìm thấy thửa nào tiếp giáp với đường {0} đoạn từ {1} đến {2} và cắt vùng buffer 50m", tenduong, batdau, ketthuc);
                        onCalculating(evt);

                        #region report progressing duong
                        if (iDuong < duongSelectionSet.Count)
                        {
                            decimal i = (decimal)iDuong % (decimal)duongSelectionSet.Count * 100;
                            int i1 = Convert.ToInt32(i);
                            this._bgwCalculating.ReportProgress(i1);
                            //MessageBox.Show("log 009");
                        }
                        else
                        {
                            this._bgwCalculating.ReportProgress(99);
                        }
                        iDuong++;
                        #endregion

                        continue;
                    }
                    #endregion
                    sothuatimthay += thuaSelectionSet.Count;
                    //============================

                    #region xet tung thua

                    //[thaydoi] - co the them bien chay
                    //********************
                    #region khoi dau
                    IEnumIDs thuaIds = thuaSelectionSet.IDs;
                    int thuaId;
                    IFeature thuaFt;
                    int iThua = 0;
                    List<object[,]> pairColValTgd = new List<object[,]>();
                    int rowTgdNnHandleUpdate = 0;
                    List<object> newId = new List<object>();
                    #endregion
                    //********************

                    while ((thuaId = thuaIds.Next()) != -1)
                    {
                        int hesoVitri = TnHeSoK.DatOMatTienHon50mDt;

                        #region chon thua dang xet
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.OID, thuaId);
                        thuaSelectionSet = thuaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                        thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                        thuaFeatureSelection.SelectionSet = thuaSelectionSet;
                        #endregion

                        //[thaydoi] - co them them dieu kien de xac dinh vi tri cua thua
                        //***********************************
                        #region lay thong tin thua dang xet

                        //[kodoi]
                        //============================
                        #region lay thong tin co ban
                        thuaFt = thuaFeatureClass.GetFeature(thuaId);
                        //neu thua bi khoa tim vi tri,bo qua,xet thua ke
                        string lockTimVitri = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOCKED)).ToString();
                        if (lockTimVitri == "1")
                        {
                            sothuaKhongTinhDuoc++;

                            #region report progressing thua
                            if (iThua < thuaSelectionSet.Count)
                            {
                                decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                int i1 = Convert.ToInt32(i);
                                this._bgwCalculating.ReportProgress(i1);
                                //MessageBox.Show("log 009");
                            }
                            else
                            {
                                this._bgwCalculating.ReportProgress(99);
                            }
                            iThua++;
                            #endregion

                            continue;

                        }
                        //neu thua ko thuoc xa dang xet thi ko tinh tiep
                        object mathua = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_THUA));
                        object maxaThua = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_XA));
                        object dientichpl = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.DIEN_TICH));
                        #endregion
                        //============================

                        //[kodoi]
                        //============================
                        #region kiem tra maxa
                        if (maxaThua.ToString() == "" || maxaThua == null)
                        {
                            maxaThua = "0";

                            #region ----log
                            evt.Log = string.Format("Chưa xác định mã xã cho thửa {0}", mathua);
                            #endregion

                            sothuaKhongTinhDuoc++;

                            #region report progressing thua
                            if (iThua < thuaSelectionSet.Count)
                            {
                                decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                int i1 = Convert.ToInt32(i);
                                this._bgwCalculating.ReportProgress(i1);
                                //MessageBox.Show("log 009");
                            }
                            else
                            {
                                this._bgwCalculating.ReportProgress(99);
                            }
                            iThua++;
                            #endregion

                            continue;
                        }
                        #endregion

                        #region lay thong tin loai do thi
                        //neu ko la do thi thi bo qua,xet thua ke
                        qrf.WhereClause = string.Format("{0}={1}", _fcName.FC_RANH_XA_POLY.MA_XA, maxaThua);
                        IFeatureCursor fcrXa = xaFeatureClass.Search(qrf, false);

                        IFeature ftXa = fcrXa.NextFeature();
                        string loaiDoThi = "";
                        if (ftXa != null)
                        {
                            loaiDoThi = ftXa.get_Value(ftXa.Fields.FindField(_fcName.FC_RANH_XA_POLY.LOAI_DO_THI)).ToString();
                        }
                        else
                        {
                            loaiDoThi = "0";
                        }
                        if (loaiDoThi == "0")
                        {
                            sothuaKhongTinhDuoc++;

                            #region report progressing thua
                            if (iThua < thuaSelectionSet.Count)
                            {
                                decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                int i1 = Convert.ToInt32(i);
                                this._bgwCalculating.ReportProgress(i1);
                                //MessageBox.Show("log 009");
                            }
                            else
                            {
                                this._bgwCalculating.ReportProgress(99);
                            }
                            iThua++;
                            #endregion

                            continue;
                        }
                        #endregion
                        //============================

                        #region lay loai dat

                        //neu ko co dat phi nong nghiep thi bo qua,xet thua ke
                        //neu co dat nong nghiep thi datnn=true
                        //neu la dat hon hop, neu co dat sxkd thi datsxkd=true, 
                        //neu co dat o thi codato=true
                        //cac truong hop he so vi tri:
                        //o:3010, sxkd:4010, o+nn:5010, o+sxkd:6010
                        string loaidat = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOAI_DAT)).ToString();
                        //evt.Log = string.Format("\n loai dat cua thua {0} la {1}", thuaId, loaidat);
                        //onCalculating(evt);

                        //[thaydoi] - may tinh dat nong nghiep co the khac
                        //***********************
                        #region kiem tra dat phi nong nghiep
                        bool datpnn = false;
                        foreach (string s in TnLoaiDats.PHI_NONG_NGHIEP_DOTHI)
                        {
                            if (loaidat.Contains(s))
                            {
                                datpnn = true;
                                break;
                            }
                            else
                            {
                                datpnn = false;
                            }
                        }
                        if (!datpnn)
                        {
                            sothuaKhongTinhDuoc++;

                            #region report progressing thua
                            if (iThua < thuaSelectionSet.Count)
                            {
                                decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                                int i1 = Convert.ToInt32(i);
                                this._bgwCalculating.ReportProgress(i1);
                                //MessageBox.Show("log 009");
                            }
                            else
                            {
                                this._bgwCalculating.ReportProgress(99);
                            }
                            iThua++;
                            #endregion

                            continue;
                        }
                        #endregion
                        //***********************

                        //[thaydoi] - may tinh dat nong nghiep co the khac
                        //***********************
                        #region kiem tra dat honhop
                        bool codatsxkd = false;
                        bool dathonhop = false;
                        bool codato = false;
                        bool chicodato = false;
                        bool chicodatsxkd = false;
                        bool codatnn = false;
                        string loaidatNn = "";

                        //evt.Log = string.Format("line 983 mattien, loaidat:{0}", loaidat);
                        //onCalculating(evt);
                        if (loaidat.Contains("+"))
                        {
                            //evt.Log = string.Format("line 987 mattien, loaidat:{0}, co +", loaidat);
                            //onCalculating(evt);
                            dathonhop = true;
                            #region kiem tra co dat o
                            foreach (string dato in TnLoaiDats.PNN_O_DT)
                            {
                                if (loaidat.Contains(dato))
                                {
                                    //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                                    //onCalculating(evt);

                                    codato = true;
                                    break;
                                }
                            }
                            #endregion

                            #region kiem tra co dat nong nghiep

                            foreach (string s in TnLoaiDats.NONG_NGHIEP)
                            {
                                if (loaidat.Contains(s))
                                {
                                    codatnn = true;
                                    loaidatNn = s;

                                    break;
                                }
                                else
                                {
                                    codatnn = false;
                                }
                            }
                            #endregion

                            #region kiem tra chi co dat sxkd
                            foreach (string s in TnLoaiDats.PNN_SX_KD)
                            {
                                if (loaidat == s)
                                {
                                    chicodatsxkd = true;

                                    break;
                                }

                                else
                                {
                                    chicodatsxkd = false;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region kiem tra chi co dat o
                            foreach (string dato in TnLoaiDats.PNN_O_DT)
                            {
                                if (loaidat.Contains(dato))
                                {
                                    //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                                    //onCalculating(evt);
                                    chicodato = true;
                                    break;
                                }
                                else
                                {
                                    chicodato = false;
                                }
                            }
                            #endregion

                            #region kiem tra chi co dat sxkd
                            foreach (string s in TnLoaiDats.PNN_SX_KD)
                            {
                                if (loaidat == s)
                                {
                                    chicodatsxkd = true;

                                    break;
                                }

                                else
                                {
                                    chicodatsxkd = false;
                                }
                            }
                            #endregion

                        }

                        #endregion
                        //***********************

                        #endregion

                        #endregion
                        //***********************************

                        //[thaydoi] - thay doi he so vi tri phu hop
                        //***********************************
                        #region quyet dinh he so vi tri cho thua
                        if (chicodato)
                        {
                            hesoVitri = TnHeSoK.DatOMatTienHon50mDt;
                        }
                        else if (chicodatsxkd)
                        {
                            hesoVitri = TnHeSoK.DatSxkdMatTienHon50mDt;
                        }
                        else if (dathonhop && codato && codatnn)
                        {
                            hesoVitri = TnHeSoK.DatONnMatTienHon50mDt;
                        }
                        //else if (dathonhop && codato && codatsxkd)
                        //{
                        //    hesoVitri = TnHeSoK.DatOSxkdMatTienMoRongDt;
                        //}
                        #endregion
                        //***********************************

                        //[thaydoi] - thay doi dieu kien truy van ung voi tung may tinh khac nhau
                        //***********************************
                        #region kiem tra trong bang thua_giadat, voi dieu kien:mathua,maduong,hesovitri,khoagia=0
                        evt.Reset();
                        evt.Log = "\n[!]--- Kiểm tra các vị trí, cập nhật vị trí mới ...";
                        onCalculating(evt);
                        qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}' and {7}='{8}'",
                            _fcName.FC_THUA_GIADAT_DRAFT.LOCKED, 0, _fcName.FC_THUA_GIADAT_DRAFT.LOCKED,
                            _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua,
                            _fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG, maduong,
                            _fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K, hesoVitri);
                        IFeatureCursor tgdFcs = tgdFeatureClass.Search(qrf, false);
                        IFeature tgdRow = null;
                        //MessageBox.Show(string.Format("line 1401 CalcPosThuaMattien - bat dau try, query:\n{0}", qrf.WhereClause));
                        try
                        {
                            tgdRow = tgdFcs.NextFeature();//dam bao la chi co 1 hang ket qua  
                            Marshal.ReleaseComObject(tgdFcs);
                            if (tgdRow != null)
                            {
                                //MessageBox.Show("co");
                                //kiem tra co cho phep tinh lai vi tri
                                //neu co:xoa feater cu,them feature moi
                                #region xet thua da co vi tri

                                bool isOverWritePos = true;

                                if (!isOverWritePos)
                                {
                                    newId.Add(tgdRow.OID);
                                    //continue;
                                }
                                else
                                {
                                    //[kodoi]
                                    //===================
                                    #region xoa feature cu
                                    wspEdit.StartEditing(true);
                                    wspEdit.StartEditOperation();
                                    //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                                    //tblThuaGiaDat.DeleteSearchedRows(qrf);
                                    tgdRow.Delete();
                                    wspEdit.StopEditOperation();
                                    wspEdit.StopEditing(true);
                                    #endregion
                                    //===================

                                    #region chon trong bang thua clip
                                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathua);
                                    IFeatureCursor thuaClipFcur = thuaClipFc.Search(qrf, false);
                                    IFeature thuaClipFt = null;
                                    try
                                    {
                                        thuaClipFt = thuaClipFcur.NextFeature();
                                    }
                                    catch (Exception ex) { return; }
                                    finally { Marshal.ReleaseComObject(thuaClipFcur); }

                                    #region lay thong tin thua clip
                                    IArea area = (IArea)thuaClipFt.Shape;
                                    #endregion

                                    #endregion

                                    #region them feature moi

                                    object copiedId = null;
                                    try
                                    {
                                        mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        wspEdit.StartEditOperation();
                                        copiedId = copyTool.Copy(thuaClipFt, tgdFeatureClass);
                                        wspEdit.StopEditOperation();
                                        wspEdit.StopEditing(true);
                                    }
                                    catch (Exception ex)
                                    {
                                        wspEdit.AbortEditOperation();
                                        wspEdit.StopEditing(false);
                                    }

                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), Math.Round(area.Area,2) } });
                                    sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                    //MessageBox.Show(string.Format("line 1604 CalcPosThuaSau50m copiedId={0}", copiedId));
                                    rowTgdNnHandleUpdate++;
                                    pairColValTgd.Clear();
                                    newId.Add(copiedId);
                                    #endregion

                                    //[thaydoi] - them gia tri
                                    //**********************
                                    #region clip thua dang xet
                                    /*
                                    #region chon duong buffer 50 dang xet
                                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                                    duongBuff50Sls = duongBuff50FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                                    duongBuff50Fsls = (IFeatureSelection)duongBuff50FeatureLayer;
                                    duongBuff50Fsls.SelectionSet = duongBuff50Sls;
                                    #endregion
                                    //_clipTool = new TnClip(sdeConn.Environment);
                                    //string thualyr = string.Format("{0}/{1}", _sysTempPath.TempPath, "thua_sau50m_clip.lyr");
                                    //string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, "duong_sau50m_clip.lyr");
                                    //_clipTool.ClipByLayerFileInsideSde(thuaFeatureLayer, thualyr, duongBuff50FeatureLayer, duonglyr, "thua_sau50m_clip");
                                    //_dataManager.SaveToLayerFile((ILayer)thuaFeatureLayer, thualyr);
                                    //_dataManager.SaveToLayerFile((ILayer)duongBuff50FeatureLayer, duonglyr);
                                    //_clipTool.Clip(thualyr, duonglyr, "thua_sau50m_clip");
                                    //MessageBox.Show(string.Format("line 1459 CalPosThuaSau50m {0}", _sysTempPath.TempFullPathNoEnd));
                                    IFeatureClass fcThuaCliped = _dataManager.TnOpenFeatureClassFromFileMdb(_sysTempPath.TempFullPathNoEnd, "thua_sau50m_clip");
                                    string clipPath = string.Format("{0}{1}", _sysTempPath.TempFullPath, "thua_sau50m_clip");
                                    IFeatureLayer flThuaCliped = new FeatureLayerClass();
                                    flThuaCliped.FeatureClass = fcThuaCliped;
                                    IFeatureCursor fcur = fcThuaCliped.Search(null, false);
                                    IFeature clipFt = null;
                                    try
                                    {
                                        clipFt = fcur.NextFeature();
                                    }
                                    catch { continue; }
                                    finally { Marshal.ReleaseComObject(fcur); }
                                    if (clipFt == null)
                                    {
                                        continue;
                                    }
                                    #endregion

                                    #region lay thong tin thua clip
                                    IArea area = (IArea)clipFt.Shape;
                                    #endregion

                                    #region them feature moi
                                    wspEdit.StartEditing(true);
                                    wspEdit.StartEditOperation();
                                    object copiedId = copyTool.CopyFromMdb(clipFt, tgdFeatureClass);
                                    //copyTool.CopyUseGeoprocessing(clipPath, tgdFeatureClass.AliasName);
                                    //IFeatureCursor fcurClip = tgdFeatureClass.Search(null, false);
                                    //object copiedId = null;
                                    //IFeature ftClip = null;
                                    //try
                                    //{
                                    //    while ((ftClip = fcurClip.NextFeature()) != null)
                                    //    {
                                    //        copiedId = ftClip.get_Value(0);
                                    //    }
                                    //}
                                    //catch {  }
                                    //finally { Marshal.ReleaseComObject(fcurClip); }
                                    wspEdit.StopEditOperation();
                                    wspEdit.StopEditing(true);
                                    //them gia tri mathua,maduong,hesovitri
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), area.Area } });
                                    sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                    MessageBox.Show(string.Format("line 1533 CalcPosThuaSau50m copiedId={0}", copiedId));
                                    rowTgdNnHandleUpdate++;
                                    pairColValTgd.Clear();
                                    newId.Add(copiedId);
                                     * */
                                    #endregion
                                    //**********************
                                }

                                #endregion

                            }
                            else
                            {
                                #region chon trong bang thua clip
                                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathua);
                                IFeatureCursor thuaClipFcur = thuaClipFc.Search(qrf, false);
                                IFeature thuaClipFt = null;
                                try
                                {
                                    thuaClipFt = thuaClipFcur.NextFeature();
                                }
                                catch (Exception ex) { return; }
                                finally { Marshal.ReleaseComObject(thuaClipFcur); }

                                #region lay thong tin thua clip
                                IArea area = (IArea)thuaClipFt.Shape;
                                #endregion

                                #endregion

                                #region them feature moi

                                object copiedId = null;
                                try
                                {
                                    mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                    wspEdit.StartEditOperation();
                                    copiedId = copyTool.Copy(thuaClipFt, tgdFeatureClass);
                                    wspEdit.StopEditOperation();
                                    wspEdit.StopEditing(true);
                                }
                                catch (Exception ex)
                                {
                                    wspEdit.AbortEditOperation();
                                    wspEdit.StopEditing(true);
                                }

                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), Math.Round(area.Area, 2) } });
                                sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                //MessageBox.Show(string.Format("line 1604 CalcPosThuaSau50m copiedId={0}", copiedId));
                                rowTgdNnHandleUpdate++;
                                pairColValTgd.Clear();
                                newId.Add(copiedId);
                                #endregion
                                //MessageBox.Show("ko co");
                                #region clip thua dang xet
                                /*
                                #region chon duong buffer 50 dang xet
                                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
                                duongBuff50Sls = duongBuff50FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                                duongBuff50Fsls = (IFeatureSelection)duongBuff50FeatureLayer;
                                duongBuff50Fsls.SelectionSet = duongBuff50Sls;
                                #endregion

                                //_clipTool = new TnClip(sdeConn.Environment);
                                //string thualyr = string.Format("{0}/{1}", _sysTempPath.TempPath, "thua_sau50m_clip.lyr");
                                //string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, "duong_sau50m_clip.lyr");
                                //_dataManager.SaveToLayerFile((ILayer)thuaFeatureLayer, thualyr);
                                //_dataManager.SaveToLayerFile((ILayer)duongBuff50FeatureLayer, duonglyr);

                                //((IFeatureClassManager)_dataManager).DeleteFcInSde("sde.thua_sau50m_clip");
                                //mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                //wspEdit.StartEditOperation();
                                IFeatureClass fcThuaCliped;
                                //try
                                //{
                                //    fcThuaCliped = fw.OpenFeatureClass("thua_sau50m_clip");
                                //    IDataset ft = (IDataset)fcThuaCliped;
                                //    ft.Delete();

                                //    wspEdit.StopEditOperation();
                                //    wspEdit.StopEditing(true);
                                //}
                                //catch (Exception ex)
                                //{
                                //    MessageBox.Show(string.Format("line 1577 CalcPosThuaSau50m {0}", ex));
                                //    wspEdit.AbortEditOperation();
                                //    wspEdit.StopEditing(false);
                                //}

                                _clipTool.ClipInsideSde(thualyr, duonglyr, "thua_sau50m_clip");

                                

                                //MessageBox.Show(string.Format("line 1517 CalPosThuaSau50m {0}", _sysTempPath.TempFullPathNoEnd));
                                fcThuaCliped = fw.OpenFeatureClass("sde.thua_sau50m_clip");//_dataManager.TnOpenFeatureClassFromFileMdb(_sysTempPath.TempFullPathNoEnd, "thua_sau50m_clip");
                                _version.RegisterDataset((IDataset)fcThuaCliped, true, true);

                                string clipPath = string.Format("{0}{1}", _sysTempPath.TempFullPath, "thua_sau50m_clip");
                                IFeatureLayer flThuaCliped = new FeatureLayerClass();
                                flThuaCliped.FeatureClass = fcThuaCliped;
                                IFeatureCursor fcur = fcThuaCliped.Search(null, false);
                                IFeature clipFt = null;
                                try
                                {
                                    clipFt = fcur.NextFeature();
                                }
                                catch { continue; }
                                finally { Marshal.ReleaseComObject(fcur); }
                                if (clipFt == null)
                                {
                                    continue;
                                }
                                #endregion

                                #region lay thong tin thua clip
                                IArea area = (IArea)clipFt.Shape;
                                #endregion
                                //[thaydoi] - them cac gia tri thich hop vao thua_giadat
                                //***********************************
                                #region them feature moi
                                
                                object copiedId = null;
                                try
                                {
                                    //MessageBox.Show()
                                    mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                    wspEdit.StartEditOperation();
                                    copiedId = copyTool.Copy(clipFt, tgdFeatureClass);
                                    //copyTool.CopyUseGeoprocessing(clipPath, tgdFeatureClass.AliasName,sdeConn.Environment);
                                    //IAppend app = (IAppend)copyTool;
                                    //app.Append(fcThuaCliped, thuaFeatureClass);
                                    #region
                                    //IGeometry g = new PolygonClass();
                                    
                                    //MessageBox.Show(string.Format("line 1597 CalcPosThuaSau50m {0}", g.GeometryType.ToString()));
                                    //IFeature feature = tgdFeatureClass.CreateFeature();
                                    //feature.Shape = g;

                                    //// Apply the appropriate subtype to the feature.
                                    //ISubtypes subtypes = (ISubtypes)tgdFeatureClass;
                                    //IRowSubtypes rowSubtypes = (IRowSubtypes)feature;
                                    //if (subtypes.HasSubtype)
                                    //{
                                    //    // In this example, the value of 3 represents the PVC subtype.
                                    //    rowSubtypes.SubtypeCode = 3;
                                    //}

                                    //// Initialize any default values the feature has.
                                    //rowSubtypes.InitDefaultValues();

                                    //// Update the value on a string field that indicates who installed the feature.
                                    ////int contractorFieldIndex = tgdFeatureClass.FindField("CONTRACTOR");
                                    ////feature.set_Value(contractorFieldIndex, "K Johnston");

                                    //// Commit the new feature to the geodatabase.
                                    //feature.Store();
                                    wspEdit.StopEditOperation();
                                    wspEdit.StopEditing(true);
                                    #endregion
                                }
                                catch (Exception e1)
                                {
                                    wspEdit.AbortEditOperation();
                                    wspEdit.StopEditing(false); 
                                    MessageBox.Show(string.Format("line 1593 CalcPosThuaSau50m {0} \n{1}", copiedId, e1));
                                }
                                MessageBox.Show(string.Format("line 1593 CalcPosThuaSau50m {0}",copiedId));
                                //copyTool.CopyUseGeoprocessing(clipPath, tgdFeatureClass.AliasName);
                                //IFeatureCursor fcurClip = tgdFeatureClass.Search(null, false);
                                //object copiedId=null;
                                //IFeature ftClip=null;
                                //try
                                //{
                                //    while ((ftClip = fcurClip.NextFeature()) != null)
                                //    {
                                //        copiedId = ftClip.get_Value(0);
                                //    }
                                //}
                                //catch { }
                                //finally { Marshal.ReleaseComObject(fcurClip); }
                                
                                //them gia tri mathua,maduong,hesovitri
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), area.Area } });
                                sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                MessageBox.Show(string.Format("line 1604 CalcPosThuaSau50m copiedId={0}", copiedId));
                                rowTgdNnHandleUpdate++;
                                pairColValTgd.Clear();
                                newId.Add(copiedId);
                                 * */
                                #endregion
                                //***********************************
                            }
                            //MessageBox.Show(newId.Count.ToString());
                        }
                        catch (Exception e1) { MessageBox.Show(string.Format("CalcPosThuaSau50m, line 1448-\n{0}", e1)); }
                        finally { Marshal.ReleaseComObject(tgdFcs); }
                        #endregion
                        //***********************************

                        #region report progressing thua
                        if (iThua < thuaSelectionSet.Count)
                        {
                            decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
                            int i1 = Convert.ToInt32(i);
                            this._bgwCalculating.ReportProgress(i1);
                            //MessageBox.Show("log 009");
                        }
                        else
                        {
                            this._bgwCalculating.ReportProgress(99);
                        }
                        iThua++;
                        #endregion
                    }
                    #endregion

                    //[kodoi]
                    //============================
                    #region luu thong tin vao bang gia dat
                    if (!sdeTblTgdEditor.IsEditing())
                    {
                        sdeTblTgdEditor.StartEditing(true);
                        sdeTblTgdEditor.StartEditOperation();
                    }

                    #region ----log
                    evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", tgdDraft);
                    onCalculating(evt);
                    #endregion

                    sdeTblTgdEditor.SaveEdit();
                    sdeTblTgdEditor.StopEditOperation();
                    sdeTblTgdEditor.StopEditing(true);

                    #region ----log
                    evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", tgdDraft);
                    onCalculating(evt);
                    #endregion

                    #endregion

                    #region tinh gia dat cho cac thua vua them vi tri
                    CalcLandprice calc = new CalcLandprice(this);
                    //MessageBox.Show(string.Format("final:{0}", newId.Count));
                    calc.Maduong = maduong;
                    calc.Calculate(newId);
                    newId.Clear();
                    #endregion
                    //============================



                }
                #endregion
            }
            #endregion

            #endregion

            //===========================================
            //===========================================
            //*******************************************

            //[kodoi]
            //==============
            #region doan ket
            sothuatinhduoc = sothuatimthay - sothuaKhongTinhDuoc;

            #region ----log
            evt.Log = string.Format("\n\n=====================================\n******* Đã tính xong*******\n=====================================");
            //evt.Log += string.Format("\n Số thửa tìm thấy: {0}", sothuatimthay);
            //evt.Log += string.Format("\n Số thửa được tính: {0}", sothuatinhduoc);
            onCalculating(evt);
            #endregion
            evt.Reset();
            evt.ProgressingTotalCount = ".";
            evt.ProgressingTotal = ".";
            onCalculating(evt);
            evt.CurrentIndexCalculator = this._index;
            onFinished(evt);
            #endregion
            //==============
        }
        void _bgwCalculating_DoWork(object sender, DoWorkEventArgs e)
        {
            this.calculate();
        }

        #region ICalculator Members

        void ICalculator.Next(Delegate steps)
        {
            throw new NotImplementedException();
        }

        void ICalculator.Start()
        {
            //if (this._bgwCalculating.IsBusy)
            //{
            //    this._bgwCalculating.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(nextCalc);
            //    this._bgwCalculating.RunWorkerCompleted += new RunWorkerCompletedEventHandler(nextCalc);
            //}
            //else
            //{
                this._bgwCalculating.RunWorkerAsync();
            //}
        }

        void nextCalc(object sender, RunWorkerCompletedEventArgs e)
        {
            this._bgwCalculating.RunWorkerAsync();
        }

        void ICalculator.Stop()
        {
            CalculationEventArg evt = new CalculationEventArg();
            //evt.Type = EnumTypeOfLoopCalculation.InListCalculators;
            evt.CurrentIndexCalculator = this._index;

            onFinished(evt);
        }

        event CalculatingEventHandler ICalculator.Calculating
        {
            add { this._calculating += value; }
            remove { this._calculating -= value; }
        }

        event CalculationFinishedEventHandler ICalculator.Finished
        {
            add { this._finished += value; }
            remove { this._finished -= value; }
        }

        int ICalculator.Index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        IInputParams ICalculator.InputParams
        {
            get
            {
                return this._inputParams;
            }
            set
            {
                this._inputParams = value;
            }
        }

        ICurrentConfig ICalculator.CurrentConfig
        {
            get
            {
                return this._currentConfig;
            }
            set
            {
                this._currentConfig = value;
            }
        }

        BackgroundWorker ICalculator.GetBackgroundWorker()
        {
            return this._bgwCalculating;
        }

        void ICalculator.RemoveAllEventHandler()
        {
            //foreach(Delegate d in )
        }

        void ICalculator.TimCachTinh(int vitri, string ma_xa, List<string> ma_duong)
        {

        }

        #endregion
    }
}
