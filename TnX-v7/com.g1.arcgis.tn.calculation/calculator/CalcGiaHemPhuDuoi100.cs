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
using com.g1.arcgis.database.versioning;
using com.g1.arcgis.spatialAnalysis;
using com.g1.arcgis.util.filterName;
using ESRI.ArcGIS.Geometry;
namespace com.g1.arcgis.tn.calculation.calculator
{
    public class CalcGiaHemPhuDuoi100 : Calculator, ICalculator
    {
        private string vitri = "";
        private int _isDothi = 1;
        private string vitiHem = "1";
        public CalcGiaHemPhuDuoi100()
            : base()
        {
            this._bgwCalculating.DoWork -= new DoWorkEventHandler(_bgwCalculating_DoWork);
            this._bgwCalculating.DoWork += new DoWorkEventHandler(_bgwCalculating_DoWork);
        }
        protected override void calculate()
        {

            #region khoi dau
            base.calculate();
            CalculationEventArg evt = new CalculationEventArg();
            //evt.Type = EnumTypeOfLoopCalculation.InListCalculators;
            evt.CurrentIndexCalculator = this._index;
            evt.Log = string.Format("**********  Bắt đầu tính giá cho hẻm {0} ********", vitri);
            onCalculating(evt);
            #endregion

            //[thaydoi] - them cac khai bao can thiet
            //************************************
            #region khai bao cac bien
            //Lay connection info hien tai
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IWorkspaceEdit wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            ICopyFeatures copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);

            #region thua

            //string thuaName = string.Format("{0}_{1}", DataNameTemplate.Thua, this._currentConfig.NamApDung);
            //_fcName.FC_THUA.NAME = thuaName;
            ////MessageBox.Show(string.Format("line 55 CalcMattien {0}", thuaName));
            //_fcName.FC_THUA.InitIndex();
            //IFeatureClass thuaFeatureClass = fw.OpenFeatureClass(thuaName);
            //IFeatureLayer thuaFeatureLayer = new FeatureLayerClass();
            //thuaFeatureLayer.FeatureClass = thuaFeatureClass;
            //IFeatureSelection thuaFeatureSelection;
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
            _fcName.FC_DUONG.InitIndex();
            #endregion

            #region hem
            IFeatureClass hemFeatureClass = fw.OpenFeatureClass(DataNameTemplate.Hem);
            IFeatureLayer hemChinhFeatureLayer = new FeatureLayerClass();
            hemChinhFeatureLayer.FeatureClass = hemFeatureClass;
            IFeatureSelection hemChinhFeatureSelection;

            //IFeatureClass hemPhuFeatureClass = fw.OpenFeatureClass(DataNameTemplate.Hem);
            IFeatureLayer hemPhuFeatureLayer = new FeatureLayerClass();
            hemPhuFeatureLayer.FeatureClass = hemFeatureClass;
            IFeatureSelection hemPhuFeatureSelection;
            //_fcName.FC_DUONG.InitIndex();
            #endregion
            #region gia dat hem
            string gdh = DataNameTemplate.Gia_Hem + "_" + _currentConfig.NamApDung.ToString();
            _fcName.FC_GIA_DAT_HEM.NAME = gdh;
            _fcName.FC_GIA_DAT_HEM.InitIndex();
            IFeatureClass gdhChinhFeatureClass = fw.OpenFeatureClass(gdh);
            IFeatureLayer gdhChinhFeatureLayer = new FeatureLayerClass();
            gdhChinhFeatureLayer.FeatureClass = gdhChinhFeatureClass;
            IFeatureSelection gdhChinhFeatureSelection;
            //ITable tblGdhChinh = (ITable)gdhChinhFeatureClass;
            //ISDETableEditor sdeTblGdhEditor = new SDETable(tblGdhChinh, sdeConn.Workspace);
            #endregion

            #region gia dat hem phu
            string gdhp = DataNameTemplate.Gia_Hem_Phu + "_" + _currentConfig.NamApDung.ToString();
            _fcName.FC_GIA_DAT_HEM_PHU.NAME = gdhp;
            _fcName.FC_GIA_DAT_HEM_PHU.InitIndex();
            IFeatureClass gdhPhuFeatureClass = fw.OpenFeatureClass(gdhp);
            IFeatureLayer gdhPhuFeatureLayer = new FeatureLayerClass();
            gdhPhuFeatureLayer.FeatureClass = gdhPhuFeatureClass;
            IFeatureSelection gdhPhuFeatureSelection;
            ITable tblGdhPhu = (ITable)gdhPhuFeatureClass;
            ISDETableEditor sdeTblGdhEditor = new SDETable(tblGdhPhu, sdeConn.Workspace);
            #endregion

            #region thua gia dat
            //string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, this._currentConfig.NamApDung);
            //_fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            //_fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            ////_fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            ////_fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            //IFeatureClass tgdFeatureClass=null;
            //try
            //{
            //    tgdFeatureClass = fw.OpenFeatureClass(tgdDraft);
            //}
            //catch (Exception exc)
            //{
            //    evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", tgdDraft);
            //    onCalculating(evt);
            //    onFinished(evt);
            //    return;
            //}
            //ITable tblThuaGiaDat = (ITable)tgdFeatureClass;
            //IFeatureLayer tgdFeatureLayer = new FeatureLayerClass();
            //ISDETableEditor sdeTblTgdEditor = new SDETable(tblThuaGiaDat, sdeConn.Workspace);
            #endregion

            #region gia dat duong
            //string gdd = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Duong, this._currentConfig.NamApDung);
            //_tblName.GIA_DAT_DUONG.NAME = gdd;
            //_tblName.GIA_DAT_DUONG.InitIndex();
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
            //ITable tblLoaiDat;
            //try
            //{
            //    tblLoaiDat = fw.OpenTable(DataNameTemplate.Loai_Dat);
            //}
            //catch (Exception exc)
            //{
            //    evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", DataNameTemplate.Loai_Dat);
            //    onCalculating(evt);
            //    onFinished(evt);
            //    return;
            //}
            #endregion

            #region he so vi tri
            //ITable tblHesoVitri;
            //try
            //{
            //    tblHesoVitri = fw.OpenTable(DataNameTemplate.He_So_K);
            //}
            //catch (Exception exc)
            //{
            //    evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", DataNameTemplate.He_So_K);
            //    onCalculating(evt);
            //    onFinished(evt);
            //    return;
            //}
            #endregion

            #region khac
            IQueryFilter qrf = new QueryFilterClass();
            IDataManager _dataManager;
            ISdeVersionInfo _version;
            IBuffer _bufferTool;
            IClip _clipTool;
            IErase _eraseTool;
            ITnSystemTempPath _sysTempPath;
            _sysTempPath = new TnSystemTempPath();
            bool result = false;
            int sothuatimthay = 0;
            int sothuatinhduoc = 0;
            int sothuaKhongTinhDuoc = 0;
            _dataManager = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            _version = SdeVersionsTool.CallMe();
            _clipTool = new GExtractTool(sdeConn.Environment);
            string hemBuffer200mNoSde = FilterSdeLayerName.GetActualName(DataNameTemplate.Hem_Buffer_);
            hemBuffer200mNoSde += "100";
            string hemClip100mNoSde = FilterSdeLayerName.GetActualName(DataNameTemplate.Hem_Clip_);
            hemClip100mNoSde += "100";
            //string duongBuffer50mCoSde = string.Format("{0}{1}", DataNameTemplate.Duong_Buffer_, 50);
            string hemClip100mCoSde = string.Format("{0}{1}", DataNameTemplate.Hem_Clip_, 100);

            _eraseTool = new GExtractTool(sdeConn.Environment);
            //string hemBuffer100mNoSde = FilterSdeLayerName.GetActualName(DataNameTemplate.Hem_Buffer_);
            //hemBuffer100mNoSde += "100";
            //string hemErase100mNoSde = FilterSdeLayerName.GetActualName(DataNameTemplate.Hem_Erase_);
            //hemErase100mNoSde += "100";
            ////string duongBuffer50mCoSde = string.Format("{0}{1}", DataNameTemplate.Duong_Buffer_, 50);
            //string hemErase100mCoSde = string.Format("{0}{1}", DataNameTemplate.Hem_Erase_, 100);
            #endregion

            #endregion
            //************************************

            //*******************************************
            //===========================================
            //===========================================

            #region bat dau tinh
            _bufferTool = new GProximityTool(sdeConn.Environment);

            if (!_dataManager.LayerExist(hemBuffer200mNoSde))
            {
                _bufferTool.BufferInsideSde(gdhChinhFeatureClass.AliasName, hemBuffer200mNoSde, 100);
            }
            IFeatureClass hemBuff200FeatureClass = fw.OpenFeatureClass(hemBuffer200mNoSde);
            IFeatureLayer hemBuff200FeatureLayer = new FeatureLayerClass();
            ISelectionSet hemBuff200Sls;
            IFeatureSelection hemBuff200Fsls;
            hemBuff200FeatureLayer.FeatureClass = hemBuff200FeatureClass;

            //if (!_dataManager.LayerExist(hemBuffer100mNoSde))
            //{
            //    _bufferTool.BufferInsideSde(gdhChinhFeatureClass.AliasName, hemBuffer100mNoSde, 100);
            //}
            //IFeatureClass hemBuff100FeatureClass = fw.OpenFeatureClass(hemBuffer100mNoSde);
            //IFeatureLayer hemBuff100FeatureLayer = new FeatureLayerClass();
            //ISelectionSet hemBuff100Sls;
            //IFeatureSelection hemBuff100Fsls;
            //hemBuff100FeatureLayer.FeatureClass = hemBuff100FeatureClass;

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

            //#region log---
            //evt.Log = string.Format("\n----Lấy các quy tắc tìm vị trí thửa từ bảng {0}, ứng với hệ số {1} ...", DataNameTemplate.He_So_K, TnHeSoK.DatOMtTtDt);
            //onCalculating(evt);
            //#endregion
            ////MessageBox.Show(String.Format("line 189 CalcThuaMattien, hsk={0}",TnHeSoK.DatOMtTtDt));
            //qrf.WhereClause = string.Format("{0}='{1}'", "hesovitri", TnHeSoK.DatOMtTtDt);
            //ICursor cur = tblHesoVitri.Search(qrf, false);
            //string quytac = "";
            //string cachtinh = "";
            //string cachtinhdongia = "";
            //try
            //{
            //    IRow row = cur.NextRow();
            //    if (row != null)
            //    {

            //        quytac = row.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.QUY_TAC)).ToString();
            //        cachtinh = row.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH)).ToString();
            //        cachtinhdongia = row.get_Value(_tblName.HESO_VITRI.GetIndex(_tblName.HESO_VITRI.CACH_TINH_DON_GIA)).ToString();
            //        //MessageBox.Show(string.Format("line 198 CalcMatTien, quytac={0}", quytac));
            //    }
            //}
            //catch { }
            //finally
            //{
            //    Marshal.ReleaseComObject(cur);
            //}
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
                    #endregion

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
                    IFeature ftDuong;
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

                        ftDuong = duongFeatureClass.GetFeature(duongId);
                        string tenduong = "";//ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.TEN_DUONG)).ToString();
                        object maduong = ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.MA_DUONG));
                        lstMaDuong.Add(maduong);
                        string batdau = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.BAT_DAU)).ToString();
                        string ketthuc = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.KET_THUC)).ToString();

                        #endregion
                        //++++++++++++++++++++++++

                        //[kodoi]
                        //Chon duong dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
                        //====================
                        #region chon hem dang xet
                        qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'", _fcName.FC_GIA_DAT_HEM.MA_DUONG, maduong, _fcName.FC_GIA_DAT_HEM.HE_SO, vitiHem);
                        IFeatureCursor gdhChinhFc = gdhChinhFeatureClass.Search(qrf, false);
                        IFeature gdhChinhFt = null;
                        try
                        {
                            while ((gdhChinhFt = gdhChinhFc.NextFeature()) != null)
                            {
                                //chon gia dat hem chinh dang xet
                                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.OID, gdhChinhFt.OID);
                                ISelectionSet hemSelectionSet = gdhChinhFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                                gdhChinhFeatureSelection = (IFeatureSelection)gdhChinhFeatureLayer;
                                gdhChinhFeatureSelection.SelectionSet = hemSelectionSet;

                                //lay thong tin hem chinh
                                object maHemChinh = gdhChinhFt.get_Value(gdhChinhFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM.MA_HEM));

                                #region chon hem phu cua hem
                                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.HEM_CHINH, maHemChinh);
                                ISelectionSet hemPhuSelectionSet = hemFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                                hemPhuFeatureSelection = (IFeatureSelection)hemPhuFeatureLayer;
                                hemPhuFeatureSelection.SelectionSet = hemPhuSelectionSet;
                                #endregion

                                //tim cac thua theo dieu kien mat tien

                                //doc cach tim thua trong bang he so vi tri
                                //lay cach tim cho dat o
                                //truyen thong so cach tinh,thualayer,duonglayer,khoangcach



                                //MessageBox.Show(func);
                                //func = "ChongLop([INTERSECT],[NEW_SELECTION],1) Then ChongLop([CONTAINED_BY],[AND_SELECTION],50)";

                                //[kodoi]
                                //============================



                                #region clip cac hem vua tim duoc

                                #region delete bang hem_sau100m_clip
                                IFeatureClass hemClipFc = null;
                                #region log---
                                evt.Log = string.Format("\n----Kiểm tra, xóa bảng {0} ...", hemClip100mCoSde);
                                onCalculating(evt);
                                #endregion

                                if (_dataManager.LayerExist(hemClip100mNoSde))
                                {
                                    //thuaClipFc = fw.OpenFeatureClass("sde.thua_sau50m_clip");
                                    //mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                    //wspEdit.StartEditing(false);
                                    //wspEdit.StartEditOperation();
                                    ((IFeatureClassManager)_dataManager).DeleteFcInSde(hemClip100mCoSde);
                                    //((IDataset)thuaClipFc).Delete();
                                    //wspEdit.StopEditOperation();
                                    //wspEdit.StopEditing(true);
                                }
                                #endregion

                                #region chon hem buffer 100 dang xet
                                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, maHemChinh);
                                hemBuff200Sls = hemBuff200FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                                hemBuff200Fsls = (IFeatureSelection)hemBuff200FeatureLayer;
                                hemBuff200Fsls.SelectionSet = hemBuff200Sls;
                                #endregion

                                #region log---
                                evt.Log = string.Format("\n----Kiểm tra, clip hẻm theo đường buffer {0}m, lưu vào bảng {1} ...", 200, hemClip100mCoSde);
                                onCalculating(evt);
                                #endregion

                                string hemlyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemClip100mNoSde);
                                string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemBuffer200mNoSde);
                                _clipTool.ClipByLayerFileInsideSde(hemChinhFeatureLayer, hemlyr, hemBuff200FeatureLayer, duonglyr, hemClip100mNoSde);
                                try
                                {
                                    hemClipFc = fw.OpenFeatureClass(hemClip100mCoSde);
                                    //MessageBox.Show("line 1002 CalcGiaHem100_200,hemclip200=" + hemClipFc.AliasName);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show("line 1002 CalcGiaHem100_200,ex=" + ex); 
                                    continue;
                                }
                                _version.RegisterDataset((IDataset)hemClipFc, true, true);
                                #endregion

                                #region erase phan hem duoi 100m
                                #region chon duong buffer 100 dang xet
                                //qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, maHemChinh);
                                //hemBuff100Sls = hemBuff100FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                                //hemBuff100Fsls = (IFeatureSelection)hemBuff100FeatureLayer;
                                //hemBuff100Fsls.SelectionSet = hemBuff100Sls;
                                #endregion
                                #region chon cac hem vua clip
                                IFeatureLayer hemClipFlayer = new FeatureLayerClass();
                                hemClipFlayer.FeatureClass = hemClipFc;
                                qrf.WhereClause = "";
                                ISelectionSet hclipSls = hemClipFc.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                                IFeatureSelection hclipFs = (IFeatureSelection)hemClipFlayer;
                                hclipFs.SelectionSet = hclipSls;
                                //MessageBox.Show("line 1028 CalcHemChinh100_200,hemclip.count=" + hclipSls.Count);
                                if (!(hclipSls.Count > 0))
                                {
                                    continue;
                                }
                                #endregion

                                #region delete bang hem_erase_100
                                //IFeatureClass hemErFc = null;
                                #region log---
                                //evt.Log = string.Format("\n----Kiểm tra, xóa bảng {0} ...", hemErase100mCoSde);
                                //onCalculating(evt);
                                #endregion

                                //if (_dataManager.LayerExist(hemErase100mNoSde))
                                //{
                                //    ((IFeatureClassManager)_dataManager).DeleteFcInSde(hemErase100mCoSde);
                                //}
                                #endregion

                                //string hemErlyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemErase100mNoSde);
                                //string duongErlyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemBuffer100mNoSde);
                                //_eraseTool.EraseByLayerFileInsideSde(hemClipFlayer, hemlyr, hemBuff100FeatureLayer, duonglyr, hemErase100mNoSde);
                                #endregion

                                //try
                                //{
                                //    hemErFc = fw.OpenFeatureClass(hemErase100mCoSde);
                                //}
                                //catch (Exception ex) { continue; }
                                //_version.RegisterDataset((IDataset)hemErFc, true, true);

                                #region xet tung hem da clip va erase

                                //[thaydoi] - co the them bien chay
                                //********************
                                #region khoi dau
                                IEnumIDs hemPhuIds = hemPhuSelectionSet.IDs;
                                //IFeatureCursor hemErCur = hemErFc.Search(null, false);
                                int hemPhuId;
                                IFeature hemPhuFt;
                                int iHem = 0;
                                List<object[,]> pairColValTgd = new List<object[,]>();
                                int rowTgdNnHandleUpdate = 0;
                                List<object> newId = new List<object>();
                                #endregion
                                //try
                                //{
                                while ((hemPhuId = hemPhuIds.Next()) != -1)
                                {
                                    //he so vi tri hem ung voi doan sau <100m
                                    //int hesoVitri = 2;
                                    #region lay thong tin hem dang xet

                                    //[kodoi]
                                    //============================
                                    #region lay thong tin co ban
                                    hemPhuFt = hemFeatureClass.GetFeature(hemPhuId);
                                    //hemErId = hemErFt.OID;

                                    object maHem = hemPhuFt.get_Value(hemPhuFt.Fields.FindField(_fcName.FC_HEM.MA_HEM));

                                    #endregion

                                    #endregion

                                    #region kiem tra trong bang giadat_hem, voi dieu kien:mahem,hesovitri,khoagia=0
                                    evt.Reset();
                                    evt.Log = "\n[!]--- Kiểm tra các hẻm đã có giá, cập nhật giá mới ...";
                                    onCalculating(evt);
                                    qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}'",
                                        _fcName.FC_GIA_DAT_HEM_PHU.LOCKED, 0, _fcName.FC_GIA_DAT_HEM_PHU.LOCKED,
                                        _fcName.FC_GIA_DAT_HEM_PHU.MA_HEM, maHem,
                                        _fcName.FC_GIA_DAT_HEM_PHU.HE_SO, vitiHem);
                                    IFeatureCursor gdhPhuFcs = gdhPhuFeatureClass.Search(qrf, false);
                                    IFeature gdhPhuFt = null;

                                    try
                                    {
                                        gdhPhuFt = gdhPhuFcs.NextFeature();//dam bao la chi co 1 hang ket qua   
                                        if (gdhPhuFt != null)
                                        {
                                            //MessageBox.Show("co");
                                            //kiem tra co cho phep tinh lai vi tri
                                            //neu co:xoa feater cu,them feature moi
                                            #region xet thua da co vi tri

                                            bool isOverWritePos = true;

                                            if (!isOverWritePos)
                                            {
                                                newId.Add(gdhPhuFt.OID);
                                                //continue;
                                            }
                                            else
                                            {
                                                //[kodoi]
                                                //===================
                                                #region xoa feature cu
                                                if (mwspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
                                                {
                                                    mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                                }
                                                else
                                                {
                                                    wspEdit.StartEditing(true);
                                                }
                                                wspEdit.StartEditOperation();
                                                //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                                                //tblThuaGiaDat.DeleteSearchedRows(qrf);
                                                gdhPhuFt.Delete();
                                                wspEdit.StopEditOperation();
                                                wspEdit.StopEditing(true);
                                                #endregion
                                                //===================
                                                #region chon trong bang thua clip
                                                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, maHem);
                                                IFeatureCursor hemErFcur = hemClipFc.Search(qrf, false);
                                                IFeature hemErFt = null;
                                                try
                                                {
                                                    hemErFt = hemErFcur.NextFeature();
                                                }
                                                catch (Exception ex) { return; }
                                                finally { Marshal.ReleaseComObject(hemErFcur); }

                                                #region lay thong tin thua clip
                                                //IArea area = (IArea)hemClipFt.Shape;
                                                #endregion

                                                #endregion
                                                //[thaydoi] - them gia tri
                                                //**********************
                                                #region them feature moi
                                                if (mwspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
                                                {
                                                    mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                                }
                                                else
                                                {
                                                    wspEdit.StartEditing(true);
                                                }
                                                wspEdit.StartEditOperation();
                                                object copiedId = copyTool.Copy(hemErFt, gdhPhuFeatureClass);
                                                try
                                                {
                                                    wspEdit.StopEditOperation();
                                                    wspEdit.StopEditing(true);
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("line 1292 CalcGiaHemChinh ex=" + ex.ToString());
                                                    wspEdit.StopEditOperation();
                                                    wspEdit.StopEditing(false);
                                                }

                                                //them gia tri mathua,maduong,hesovitri
                                                pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM), maHem } });
                                                pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM_CHINH), maHemChinh } });
                                                pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.LOCKED), 0 } });
                                                pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.HE_SO), vitiHem } });
                                                pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_DUONG), maduong } });
                                                sdeTblGdhEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                                rowTgdNnHandleUpdate++;
                                                pairColValTgd.Clear();

                                                newId.Add(copiedId);
                                                #endregion
                                                //**********************
                                            }

                                            #endregion

                                        }
                                        else
                                        {
                                            //MessageBox.Show("ko co");
                                            //[thaydoi] - them cac gia tri thich hop vao thua_giadat
                                            //***********************************
                                            #region chon trong bang thua clip
                                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, maHem);
                                            //MessageBox.Show("line 1322 CalcGiaHemChinh, mahem=" + maHem);
                                            IFeatureCursor hemErFcur = hemClipFc.Search(qrf, false);
                                            IFeature hemErFt = null;
                                            try
                                            {
                                                hemErFt = hemErFcur.NextFeature();
                                                if (hemErFt == null)
                                                {
                                                    continue;
                                                }
                                            }
                                            catch (Exception ex) { return; }
                                            finally { Marshal.ReleaseComObject(hemErFcur); }

                                            #region lay thong tin thua clip
                                            //IArea area = (IArea)hemClipFt.Shape;
                                            #endregion

                                            #endregion
                                            #region them feature moi
                                            if (mwspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
                                            {
                                                mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                            }
                                            else
                                            {
                                                wspEdit.StartEditing(true);
                                            }
                                            wspEdit.StartEditOperation();
                                            object copiedId = copyTool.Copy(hemErFt, gdhPhuFeatureClass);
                                            try
                                            {
                                                wspEdit.StopEditOperation();
                                                wspEdit.StopEditing(true);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("line 1355 CalcGiaHemChinh ex=" + ex.ToString());
                                                wspEdit.StopEditOperation();
                                                wspEdit.StopEditing(false);
                                            }
                                            //MessageBox.Show("line 1234 CalcGiaHem100_200,copiedId=" + copiedId);
                                            //them gia tri mathua,maduong,hesovitri
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM), maHem } });
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM_CHINH), maHemChinh } });
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.HE_SO), vitiHem } });
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.LOCKED), 0 } });
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.MA_DUONG), maduong } });
                                            //MessageBox.Show(string.Format("line 1364 CalcGiaHemChinh heso={0},mahem={1},maduong={2},lock={3}", _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.HE_SO), _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.MA_HEM), _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.MA_DUONG), _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.LOCKED)));
                                            sdeTblGdhEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                            rowTgdNnHandleUpdate++;
                                            pairColValTgd.Clear();
                                            newId.Add(copiedId);

                                            #endregion
                                            //***********************************
                                        }
                                        //MessageBox.Show(newId.Count.ToString());
                                    }
                                    catch (Exception e1)
                                    {
                                        MessageBox.Show(string.Format("CalcGiaHemChinh, line 1448-\n{0}", e1));
                                    }
                                    finally { Marshal.ReleaseComObject(gdhPhuFcs); }

                                    #endregion
                                }
                                //}
                                //catch (Exception ex) { MessageBox.Show(string.Format("CalcGiaHemChinh, line 1260-\n{0}", ex)); }
                                //finally { Marshal.ReleaseComObject(hemErCur); }

                                #endregion

                                //[kodoi]
                                //============================
                                #region luu thong tin vao bang gia dat
                                if (!sdeTblGdhEditor.IsEditing())
                                {
                                    sdeTblGdhEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                    sdeTblGdhEditor.StartEditOperation();
                                }

                                #region ----log
                                evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", gdhChinhFeatureClass.AliasName);
                                onCalculating(evt);
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
                                evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", gdhChinhFeatureClass.AliasName);
                                onCalculating(evt);
                                #endregion

                                #endregion

                                #region tinh gia dat cho cac hem vua them vi tri
                                CalcLandprice calc = new CalcLandprice(this);
                                //MessageBox.Show(string.Format("final:{0}", newId.Count));

                                calc.CalcGiaHemPhu(newId);
                                newId.Clear();
                                #endregion
                                //============================
                            }
                        }
                        catch { }
                        finally { Marshal.ReleaseComObject(gdhChinhFc); }

                        #endregion
                        //====================
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
                IFeature ftDuong;
                int iDuong = 0;
                int progressingTotalCount = 1;
                evt.Reset();
                evt.ProgressingTotal = duongSelectionSet.Count;
                onCalculating(evt);
                List<object> lstMaDuong = new List<object>();
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

                    ftDuong = duongFeatureClass.GetFeature(duongId);
                    string tenduong = "";//ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.TEN_DUONG)).ToString();
                    object maduong = ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.MA_DUONG));
                    lstMaDuong.Add(maduong);
                    string batdau = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.BAT_DAU)).ToString();
                    string ketthuc = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.KET_THUC)).ToString();

                    #endregion
                    //++++++++++++++++++++++++

                    //[kodoi]
                    //Chon duong dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
                    //====================
                    #region chon hem dang xet
                    qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'", _fcName.FC_GIA_DAT_HEM.MA_DUONG, maduong, _fcName.FC_GIA_DAT_HEM.HE_SO, vitiHem);
                    IFeatureCursor gdhChinhFc = gdhChinhFeatureClass.Search(qrf, false);
                    IFeature gdhChinhFt = null;
                    try
                    {
                        while ((gdhChinhFt = gdhChinhFc.NextFeature()) != null)
                        {
                            //chon gia dat hem chinh dang xet
                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.OID, gdhChinhFt.OID);
                            ISelectionSet hemSelectionSet = gdhChinhFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                            gdhChinhFeatureSelection = (IFeatureSelection)gdhChinhFeatureLayer;
                            gdhChinhFeatureSelection.SelectionSet = hemSelectionSet;

                            //lay thong tin hem chinh
                            object maHemChinh = gdhChinhFt.get_Value(gdhChinhFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM.MA_HEM));

                            #region chon hem phu cua hem
                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.HEM_CHINH, maHemChinh);
                            ISelectionSet hemPhuSelectionSet = hemFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                            hemPhuFeatureSelection = (IFeatureSelection)hemPhuFeatureLayer;
                            hemPhuFeatureSelection.SelectionSet = hemPhuSelectionSet;
                            #endregion

                            //tim cac thua theo dieu kien mat tien

                            //doc cach tim thua trong bang he so vi tri
                            //lay cach tim cho dat o
                            //truyen thong so cach tinh,thualayer,duonglayer,khoangcach



                            //MessageBox.Show(func);
                            //func = "ChongLop([INTERSECT],[NEW_SELECTION],1) Then ChongLop([CONTAINED_BY],[AND_SELECTION],50)";

                            //[kodoi]
                            //============================



                            #region clip cac hem vua tim duoc

                            #region delete bang hem_sau100m_clip
                            IFeatureClass hemClipFc = null;
                            #region log---
                            evt.Log = string.Format("\n----Kiểm tra, xóa bảng {0} ...", hemClip100mCoSde);
                            onCalculating(evt);
                            #endregion

                            if (_dataManager.LayerExist(hemClip100mNoSde))
                            {
                                //thuaClipFc = fw.OpenFeatureClass("sde.thua_sau50m_clip");
                                //mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                //wspEdit.StartEditing(false);
                                //wspEdit.StartEditOperation();
                                ((IFeatureClassManager)_dataManager).DeleteFcInSde(hemClip100mCoSde);
                                //((IDataset)thuaClipFc).Delete();
                                //wspEdit.StopEditOperation();
                                //wspEdit.StopEditing(true);
                            }
                            #endregion

                            #region chon hem buffer 100 dang xet
                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, maHemChinh);
                            hemBuff200Sls = hemBuff200FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                            hemBuff200Fsls = (IFeatureSelection)hemBuff200FeatureLayer;
                            hemBuff200Fsls.SelectionSet = hemBuff200Sls;
                            #endregion

                            #region log---
                            evt.Log = string.Format("\n----Kiểm tra, clip hẻm theo đường buffer {0}m, lưu vào bảng {1} ...", 200, hemClip100mCoSde);
                            onCalculating(evt);
                            #endregion

                            string hemlyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemClip100mNoSde);
                            string duonglyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemBuffer200mNoSde);
                            _clipTool.ClipByLayerFileInsideSde(hemChinhFeatureLayer, hemlyr, hemBuff200FeatureLayer, duonglyr, hemClip100mNoSde);
                            try
                            {
                                hemClipFc = fw.OpenFeatureClass(hemClip100mCoSde);
                                //MessageBox.Show("line 1002 CalcGiaHem100_200,hemclip200=" + hemClipFc.AliasName);
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show("line 1002 CalcGiaHem100_200,ex=" + ex); 
                                continue;
                            }
                            _version.RegisterDataset((IDataset)hemClipFc, true, true);
                            #endregion

                            #region erase phan hem duoi 100m
                            #region chon duong buffer 100 dang xet
                            //qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_GIA_DAT_HEM.MA_HEM, maHemChinh);
                            //hemBuff100Sls = hemBuff100FeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                            //hemBuff100Fsls = (IFeatureSelection)hemBuff100FeatureLayer;
                            //hemBuff100Fsls.SelectionSet = hemBuff100Sls;
                            #endregion
                            #region chon cac hem vua clip
                            IFeatureLayer hemClipFlayer = new FeatureLayerClass();
                            hemClipFlayer.FeatureClass = hemClipFc;
                            qrf.WhereClause = "";
                            ISelectionSet hclipSls = hemClipFc.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                            IFeatureSelection hclipFs = (IFeatureSelection)hemClipFlayer;
                            hclipFs.SelectionSet = hclipSls;
                            //MessageBox.Show("line 1028 CalcHemChinh100_200,hemclip.count=" + hclipSls.Count);
                            if (!(hclipSls.Count > 0))
                            {
                                continue;
                            }
                            #endregion

                            #region delete bang hem_erase_100
                            //IFeatureClass hemErFc = null;
                            #region log---
                            //evt.Log = string.Format("\n----Kiểm tra, xóa bảng {0} ...", hemErase100mCoSde);
                            //onCalculating(evt);
                            #endregion

                            //if (_dataManager.LayerExist(hemErase100mNoSde))
                            //{
                            //    ((IFeatureClassManager)_dataManager).DeleteFcInSde(hemErase100mCoSde);
                            //}
                            #endregion

                            //string hemErlyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemErase100mNoSde);
                            //string duongErlyr = string.Format("{0}/{1}", _sysTempPath.TempPath, hemBuffer100mNoSde);
                            //_eraseTool.EraseByLayerFileInsideSde(hemClipFlayer, hemlyr, hemBuff100FeatureLayer, duonglyr, hemErase100mNoSde);
                            #endregion

                            //try
                            //{
                            //    hemErFc = fw.OpenFeatureClass(hemErase100mCoSde);
                            //}
                            //catch (Exception ex) { continue; }
                            //_version.RegisterDataset((IDataset)hemErFc, true, true);

                            #region xet tung hem da clip va erase

                            //[thaydoi] - co the them bien chay
                            //********************
                            #region khoi dau
                            IEnumIDs hemPhuIds = hemPhuSelectionSet.IDs;
                            //IFeatureCursor hemErCur = hemErFc.Search(null, false);
                            int hemPhuId;
                            IFeature hemPhuFt;
                            int iHem = 0;
                            List<object[,]> pairColValTgd = new List<object[,]>();
                            int rowTgdNnHandleUpdate = 0;
                            List<object> newId = new List<object>();
                            #endregion
                            //try
                            //{
                            while ((hemPhuId = hemPhuIds.Next()) != -1)
                            {
                                //he so vi tri hem ung voi doan sau <100m
                                //int hesoVitri = 2;
                                #region lay thong tin hem dang xet

                                //[kodoi]
                                //============================
                                #region lay thong tin co ban
                                hemPhuFt = hemFeatureClass.GetFeature(hemPhuId);
                                //hemErId = hemErFt.OID;

                                object maHem = hemPhuFt.get_Value(hemPhuFt.Fields.FindField(_fcName.FC_HEM.MA_HEM));

                                #endregion

                                #endregion

                                #region kiem tra trong bang giadat_hem, voi dieu kien:mahem,hesovitri,khoagia=0
                                evt.Reset();
                                evt.Log = "\n[!]--- Kiểm tra các hẻm đã có giá, cập nhật giá mới ...";
                                onCalculating(evt);
                                qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}'",
                                    _fcName.FC_GIA_DAT_HEM_PHU.LOCKED, 0, _fcName.FC_GIA_DAT_HEM_PHU.LOCKED,
                                    _fcName.FC_GIA_DAT_HEM_PHU.MA_HEM, maHem,
                                    _fcName.FC_GIA_DAT_HEM_PHU.HE_SO, vitiHem);
                                IFeatureCursor gdhPhuFcs = gdhPhuFeatureClass.Search(qrf, false);
                                IFeature gdhPhuFt = null;

                                try
                                {
                                    gdhPhuFt = gdhPhuFcs.NextFeature();//dam bao la chi co 1 hang ket qua   
                                    if (gdhPhuFt != null)
                                    {
                                        //MessageBox.Show("co");
                                        //kiem tra co cho phep tinh lai vi tri
                                        //neu co:xoa feater cu,them feature moi
                                        #region xet thua da co vi tri

                                        bool isOverWritePos = true;

                                        if (!isOverWritePos)
                                        {
                                            newId.Add(gdhPhuFt.OID);
                                            //continue;
                                        }
                                        else
                                        {
                                            //[kodoi]
                                            //===================
                                            #region xoa feature cu
                                            if (mwspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
                                            {
                                                mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                            }
                                            else
                                            {
                                                wspEdit.StartEditing(true);
                                            }
                                            wspEdit.StartEditOperation();
                                            //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                                            //tblThuaGiaDat.DeleteSearchedRows(qrf);
                                            gdhPhuFt.Delete();
                                            wspEdit.StopEditOperation();
                                            wspEdit.StopEditing(true);
                                            #endregion
                                            //===================
                                            #region chon trong bang thua clip
                                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, maHem);
                                            IFeatureCursor hemErFcur = hemClipFc.Search(qrf, false);
                                            IFeature hemErFt = null;
                                            try
                                            {
                                                hemErFt = hemErFcur.NextFeature();
                                            }
                                            catch (Exception ex) { return; }
                                            finally { Marshal.ReleaseComObject(hemErFcur); }

                                            #region lay thong tin thua clip
                                            //IArea area = (IArea)hemClipFt.Shape;
                                            #endregion

                                            #endregion
                                            //[thaydoi] - them gia tri
                                            //**********************
                                            #region them feature moi
                                            if (mwspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
                                            {
                                                mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                            }
                                            else
                                            {
                                                wspEdit.StartEditing(true);
                                            }
                                            wspEdit.StartEditOperation();
                                            object copiedId = copyTool.Copy(hemErFt, gdhPhuFeatureClass);
                                            try
                                            {
                                                wspEdit.StopEditOperation();
                                                wspEdit.StopEditing(true);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("line 1292 CalcGiaHemChinh ex=" + ex.ToString());
                                                wspEdit.StopEditOperation();
                                                wspEdit.StopEditing(false);
                                            }

                                            //them gia tri mathua,maduong,hesovitri
                                            pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM), maHem } });
                                            pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM_CHINH), maHemChinh } });
                                            pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.LOCKED), 0 } });
                                            pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.HE_SO), vitiHem } });
                                            pairColValTgd.Add(new object[,] { { gdhPhuFt.Fields.FindField(_fcName.FC_GIA_DAT_HEM_PHU.MA_DUONG), maduong } });
                                            sdeTblGdhEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                            rowTgdNnHandleUpdate++;
                                            pairColValTgd.Clear();

                                            newId.Add(copiedId);
                                            #endregion
                                            //**********************
                                        }

                                        #endregion

                                    }
                                    else
                                    {
                                        //MessageBox.Show("ko co");
                                        //[thaydoi] - them cac gia tri thich hop vao thua_giadat
                                        //***********************************
                                        #region chon trong bang thua clip
                                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.MA_HEM, maHem);
                                        //MessageBox.Show("line 1322 CalcGiaHemChinh, mahem=" + maHem);
                                        IFeatureCursor hemErFcur = hemClipFc.Search(qrf, false);
                                        IFeature hemErFt = null;
                                        try
                                        {
                                            hemErFt = hemErFcur.NextFeature();
                                            if (hemErFt == null)
                                            {
                                                continue;
                                            }
                                        }
                                        catch (Exception ex) { return; }
                                        finally { Marshal.ReleaseComObject(hemErFcur); }

                                        #region lay thong tin thua clip
                                        //IArea area = (IArea)hemClipFt.Shape;
                                        #endregion

                                        #endregion
                                        #region them feature moi
                                        if (mwspEdit.SupportsMultiuserEditSessionMode(esriMultiuserEditSessionMode.esriMESMVersioned))
                                        {
                                            mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        }
                                        else
                                        {
                                            wspEdit.StartEditing(true);
                                        }
                                        wspEdit.StartEditOperation();
                                        object copiedId = copyTool.Copy(hemErFt, gdhPhuFeatureClass);
                                        try
                                        {
                                            wspEdit.StopEditOperation();
                                            wspEdit.StopEditing(true);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("line 1355 CalcGiaHemChinh ex=" + ex.ToString());
                                            wspEdit.StopEditOperation();
                                            wspEdit.StopEditing(false);
                                        }
                                        //MessageBox.Show("line 1234 CalcGiaHem100_200,copiedId=" + copiedId);
                                        //them gia tri mathua,maduong,hesovitri
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM), maHem } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.MA_HEM_CHINH), maHemChinh } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.HE_SO), vitiHem } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.LOCKED), 0 } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_GIA_DAT_HEM_PHU.GetIndex(_fcName.FC_GIA_DAT_HEM_PHU.MA_DUONG), maduong } });
                                        //MessageBox.Show(string.Format("line 1364 CalcGiaHemChinh heso={0},mahem={1},maduong={2},lock={3}", _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.HE_SO), _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.MA_HEM), _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.MA_DUONG), _fcName.FC_GIA_DAT_HEM.GetIndex(_fcName.FC_GIA_DAT_HEM.LOCKED)));
                                        sdeTblGdhEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                        rowTgdNnHandleUpdate++;
                                        pairColValTgd.Clear();
                                        newId.Add(copiedId);

                                        #endregion
                                        //***********************************
                                    }
                                    //MessageBox.Show(newId.Count.ToString());
                                }
                                catch (Exception e1)
                                {
                                    MessageBox.Show(string.Format("CalcGiaHemChinh, line 1448-\n{0}", e1));
                                }
                                finally { Marshal.ReleaseComObject(gdhPhuFcs); }

                                #endregion
                            }
                            //}
                            //catch (Exception ex) { MessageBox.Show(string.Format("CalcGiaHemChinh, line 1260-\n{0}", ex)); }
                            //finally { Marshal.ReleaseComObject(hemErCur); }

                            #endregion

                            //[kodoi]
                            //============================
                            #region luu thong tin vao bang gia dat
                            if (!sdeTblGdhEditor.IsEditing())
                            {
                                sdeTblGdhEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                sdeTblGdhEditor.StartEditOperation();
                            }

                            #region ----log
                            evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", gdhChinhFeatureClass.AliasName);
                            onCalculating(evt);
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
                            evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", gdhChinhFeatureClass.AliasName);
                            onCalculating(evt);
                            #endregion

                            #endregion

                            #region tinh gia dat cho cac hem vua them vi tri
                            CalcLandprice calc = new CalcLandprice(this);
                            //MessageBox.Show(string.Format("final:{0}", newId.Count));

                            calc.CalcGiaHemPhu(newId);
                            newId.Clear();
                            #endregion
                            //============================
                        }
                    }
                    catch { }
                    finally { Marshal.ReleaseComObject(gdhChinhFc); }

                    #endregion
                    //====================








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
            evt.Log = string.Format("\n\n**************************************\n******* Đã tính xong các thửa phi nông nghiệp tại đô thị vị trí mặt tiền*******\n**********************************");
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
