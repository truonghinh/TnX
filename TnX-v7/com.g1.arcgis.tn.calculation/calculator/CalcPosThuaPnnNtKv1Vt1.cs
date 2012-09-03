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

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class CalcPosThuaPnnNtKv1Vt1 : Calculator, ICalculator
    {
        //!!!!tim cum tu [thaydoi] de biet cho thay doi giua cac may tinh
        //cum tu nay duoc dat truoc moi region
        private string vitri = "1 khu vực 1";
        private int _isDothi = 1;
        public CalcPosThuaPnnNtKv1Vt1()
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
            evt.Log = string.Format("**********  Bắt đầu tính cho thửa phi nông nghiệp ở vị trí {0} tại nông thôn ********", vitri);
            onCalculating(evt);
            #endregion

            //[thaydoi] - them cac khai bao can thiet
            //************************************
            #region khai bao cac bien
            //Lay connection info hien tai
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IWorkspaceEdit wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            ICopyFeatures copyTool = new DataManager(sdeConn.Workspace,sdeConn.Environment);

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
            IFeatureClass duongFeatureClass = fw.OpenFeatureClass(DataNameTemplate.Duong_Chinh_NongThon);
            IFeatureLayer duongFeatureLayer = new FeatureLayerClass();
            duongFeatureLayer.FeatureClass = duongFeatureClass;
            IFeatureSelection duongFeatureSelection;
            //_fcName.FC_DUONG.InitIndex();
            #endregion
            #region trung tam xa
            IFeatureClass ttXaFeatureClass = fw.OpenFeatureClass(DataNameTemplate.Trung_Tam_Xa);
            IFeatureLayer ttXaFeatureLayer = new FeatureLayerClass();
            ttXaFeatureLayer.FeatureClass = ttXaFeatureClass;
            IFeatureSelection ttXaFeatureSelection;
            _fcName.FC_DUONG.InitIndex();
            #endregion

            #region thua gia dat
            string tgd = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, this._currentConfig.NamApDung);
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgd;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            //_fcName.FC_THUA_GIADAT_DRAFT.NAME = tgd;
            //_fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            IFeatureClass tgdFeatureClass=null;
            try
            {
                tgdFeatureClass = fw.OpenFeatureClass(tgd);
            }
            catch (Exception exc)
            {
                evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", tgd);
                onCalculating(evt);
                onFinished(evt);
                return;
            }
            ITable tblThuaGiaDat = (ITable)tgdFeatureClass;
            IFeatureLayer tgdFeatureLayer = new FeatureLayerClass();
            ISDETableEditor sdeTblTgdEditor = new SDETable(tblThuaGiaDat, sdeConn.Workspace);
            #endregion

            #region gia dat phi nong nghiep nong thon
            string gdd = string.Format("{0}_{1}", DataNameTemplate.Gia_Dat_Pnn_Nongthon, this._currentConfig.NamApDung);
            _tblName.GIA_DAT_O_NONGTHON.NAME = gdd;
            _tblName.GIA_DAT_O_NONGTHON.InitIndex();
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
            #endregion

            #endregion
            //************************************

            //*******************************************
            //===========================================
            //===========================================

            #region bat dau tinh

            //[thaydoi] - cac may tinh khac chi can thay dieu kien truy van he so vi tri
            //******************************************************************
            #region lay cac quy tac tim vi tri

            #region log---
            evt.Log = string.Format("\n----Lấy các quy tắc tìm vị trí thửa từ bảng {0}, ứng với hệ số {1} ...", DataNameTemplate.He_So_K, TnHeSoK.DatOPnnKv1Vt1);
            onCalculating(evt);
            #endregion

            qrf.WhereClause = string.Format("{0}='{1}'", "hesovitri", TnHeSoK.DatOPnnKv1Vt1);
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

            quytac = DefaultExpressions._2110;

            Evaluation eval = new Evaluation(quytac);
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

                    #region tim duong chinh nong thon bang qua xa
                    //Chon cac duong co do rong theo quy dinh
                    //qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.PHAN_LOAI, _isDothi);// "maduong='2'";
                    qrf.WhereClause = "";
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
                        //object maduong = ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.MA_DUONG));
                        //lstMaDuong.Add(maduong);
                        string batdau = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.BAT_DAU)).ToString();
                        string ketthuc = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.KET_THUC)).ToString();

                        #endregion
                        //++++++++++++++++++++++++

                        //[kodoi]
                        //Chon duong dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
                        //====================
                        #region chon duong dang xet
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG_CHINH_NONG_THON.OID, duongId);
                        duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                        duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;
                        duongFeatureSelection.SelectionSet = duongSelectionSet;
                        #endregion

                        #region chon trung tam xa trong xa dang xet
                        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_TRUNG_TAM_XA.MA_XA, maxa);
                        ISelectionSet ttXaSelectionSet = ttXaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
                        ttXaFeatureSelection = (IFeatureSelection)ttXaFeatureLayer;
                        ttXaFeatureSelection.SelectionSet = ttXaSelectionSet;
                        #endregion
                        //====================

                        #region vong lap xet tung ttx
                        //[thaydoi] - co the them bien chay
                        //===============================
                        #region khoi dau
                        IEnumIDs eIdsTtXa = ttXaSelectionSet.IDs;
                        int ttXaId;
                        IFeature ftTtXa;
                        int iTtXa = 0;
                        evt.Reset();
                        evt.ProgressingPart1Total = ttXaSelectionSet.Count;
                        int progressingPart1Count = 1;
                        onCalculating(evt);
                        #endregion

                        while ((ttXaId = eIdsTtXa.Next()) != -1)
                        {
                            //[kodoi]
                            //======================
                            #region log-----
                            evt.Reset();
                            //evt.ProgressingPart1Total = progressingTotalCount;
                            evt.ProgressingPart1Count = progressingPart1Count;
                            onCalculating(evt);
                            progressingPart1Count++;
                            #endregion

                            //[capnhat] - lay ten duong tu bang ten duong
                            //++++++++++++++++++++++++
                            #region lay thong tin cua Ttx dang xet

                            ftTtXa = ttXaFeatureClass.GetFeature(ttXaId);
                            object maTtx = ftTtXa.get_Value(ftTtXa.Fields.FindField(_fcName.FC_TRUNG_TAM_XA.MA));
                            object tenTtx = ftTtXa.get_Value(ftTtXa.Fields.FindField(_fcName.FC_TRUNG_TAM_XA.TEN_TTX));
                            //double dorong;
                            //result = double.TryParse(ftTtXa.get_Value(ftTtXa.Fields.FindField(_fcName.FC_HEM.DO_RONG)).ToString(), out dorong);
                            //if (!result)
                            //{
                            //    dorong = 0;
                            //}
                            #endregion
                            //++++++++++++++++++++++++

                            //[kodoi]
                            //Chon hem dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
                            //====================
                            #region chon TtX dang xet
                            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_TRUNG_TAM_XA.OID, ttXaId);
                            ttXaSelectionSet = ttXaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
                            ttXaFeatureSelection = (IFeatureSelection)ttXaFeatureLayer;
                            ttXaFeatureSelection.SelectionSet = ttXaSelectionSet;
                            #endregion
                            //====================

                            //================================
                            //tim cac thua theo dieu kien mat tien
                            #region tinh vi tri cho cac thua
                            //[kodoi]
                            //============================
                            #region tim cac thua theo vi tri quy dinh
                            thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                            thuaFeatureSelection.Clear();

                            eval.ThuaLayer = thuaFeatureLayer;
                            eval.DuongLayer = duongFeatureLayer;
                            eval.TtXaLayer= ttXaFeatureLayer;
                            eval.EvaluateQuery();
                            //thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
                            ISelectionSet thuaSelectionSet = thuaFeatureSelection.SelectionSet;
                            #endregion
                            //============================

                            //MessageBox.Show(thuaSelectionSet.Count.ToString());
                            #endregion

                            //[kodoi]
                            //============================
                            #region ----log
                            if (thuaSelectionSet.Count == 0)
                            {
                                evt.Log = string.Format("\n !!! Không tìm thấy thửa nào trong hẻm {0},(mã={1}), và cách đường {2} đoạn từ {3} đến {4} 100m", tenTtx, maTtx, tenduong, batdau, ketthuc);
                                onCalculating(evt);

                                #region report progressing hem
                                if (iTtXa < ttXaSelectionSet.Count)
                                {
                                    decimal i = (decimal)iTtXa % (decimal)ttXaSelectionSet.Count * 100;
                                    int i1 = Convert.ToInt32(i);
                                    this._bgwCalculating.ReportProgress(i1);
                                    //MessageBox.Show("log 009");
                                }
                                else
                                {
                                    this._bgwCalculating.ReportProgress(99);
                                }
                                iTtXa++;
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
                                int hesoVitri = TnHeSoK.DatOPnnKv1Vt1;

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
                                    evt.Reset();
                                    evt.Log = string.Format("Chưa xác định mã xã cho thửa {0}", mathua);
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

                                #region danh rieng khi tinh theo xa
                                else if(maxaThua.ToString()!=maxa)
                                {
                                    #region ----log
                                    evt.Reset();
                                    evt.Log = string.Format("thửa {0} không thuộc xã {1}", mathua,tenxa);
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
                                bool datsxkd = false;
                                bool dathonhop = false;
                                bool codato = false;
                                bool chicodato = false;
                                bool chicodatsxkd = false;
                                bool datnn = false;
                                string loaidatNn = "";

                                //evt.Log = string.Format("line 983 mattien, loaidat:{0}", loaidat);
                                //onCalculating(evt);
                                if (loaidat.Contains("+"))
                                {
                                    //evt.Log = string.Format("line 987 mattien, loaidat:{0}, co +", loaidat);
                                    //onCalculating(evt);
                                    dathonhop = true;
                                    #region kiem tra co dat o
                                    if (loaidat.Contains("ODT"))
                                    {
                                        //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                                        //onCalculating(evt);

                                        codato = true;
                                    }
                                    #endregion

                                    #region kiem tra co dat nong nghiep

                                    foreach (string s in TnLoaiDats.NONG_NGHIEP)
                                    {
                                        if (loaidat.Contains(s))
                                        {
                                            datnn = true;
                                            loaidatNn = s;

                                            break;
                                        }
                                        else
                                        {
                                            datnn = false;
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

                                    if (loaidat.Contains("ODT"))
                                    {
                                        //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
                                        //onCalculating(evt);
                                        chicodato = true;
                                    }
                                    else
                                    {
                                        chicodato = false;
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
                                    
                                    hesoVitri = TnHeSoK.DatOPnnKv1Vt1;
                                    
                                }
                                else if (chicodatsxkd)
                                {
                                    hesoVitri = TnHeSoK.DatSxkdPnnKv1Vt1;
                                }
                                else if (dathonhop && codato && datnn)
                                {
                                    hesoVitri = TnHeSoK.DatONnPnnKv1Vt1;

                                }
                                else
                                {
                                    hesoVitri = TnHeSoK.KhongXacDinh;
                                }
                                //else if (dathonhop && codato && datsxkd)
                                //{
                                //    hesoVitri = TnHeSoK.DatOSxkdMatTien;
                                //}
                                #endregion
                                //***********************************

                                //[thaydoi] - thay doi dieu kien truy van ung voi tung may tinh khac nhau
                                //***********************************
                                #region kiem tra trong bang thua_giadat, voi dieu kien:mathua,maduong,hesovitri,khoagia=0
                                evt.Reset();
                                evt.Log = string.Format("\n[!]--- Kiểm tra các vị trí, cập nhật vị trí mới cho thửa {0} ...", mathua);
                                onCalculating(evt);
                                qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}'",
                                    _fcName.FC_THUA_GIADAT_DRAFT.LOCKED, 0, _fcName.FC_THUA_GIADAT_DRAFT.LOCKED,
                                    _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua,
                                    _fcName.FC_THUA_GIADAT_DRAFT.MA_TRUNG_TAM_XA, maTtx,
                                    _fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K, hesoVitri);
                                ICursor tgdFcs = tblThuaGiaDat.Search(qrf, false);
                                IRow tgdRow = null;
                                //MessageBox.Show(string.Format("line 1401 CalcPosThuaMattien - bat dau try, query:\n{0}", qrf.WhereClause));
                                try
                                {
                                    tgdRow = tgdFcs.NextRow();//dam bao la chi co 1 hang ket qua   
                                    if (tgdRow != null)
                                    {
                                        //MessageBox.Show("co");
                                        //kiem tra co cho phep tinh lai vi tri (locked=1)
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

                                            //[thaydoi] - them gia tri
                                            //**********************
                                            #region them feature moi
                                            wspEdit.StartEditing(true);
                                            wspEdit.StartEditOperation();
                                            object copiedId = copyTool.Copy(thuaFt, tgdFeatureClass);
                                            wspEdit.StopEditOperation();
                                            wspEdit.StopEditing(true);

                                            //them gia tri mathua,maduong,hesovitri
                                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                            //pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_TRUNG_TAM_XA), maTtx } });
                                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                            pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
                                            sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
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
                                        #region them feature moi
                                        wspEdit.StartEditing(true);
                                        wspEdit.StartEditOperation();
                                        object copiedId = copyTool.Copy(thuaFt, tgdFeatureClass);
                                        wspEdit.StopEditOperation();
                                        wspEdit.StopEditing(true);

                                        //them gia tri mathua,maduong,hesovitri
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_TRUNG_TAM_XA), maTtx } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
                                        sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
                                        rowTgdNnHandleUpdate++;
                                        pairColValTgd.Clear();
                                        newId.Add(copiedId);
                                        #endregion
                                        //***********************************
                                    }
                                    //MessageBox.Show(newId.Count.ToString());
                                }
                                catch (Exception e1) { MessageBox.Show(string.Format("CalcPosThuaMattien, line 1448-\n{0}", e1)); }
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
                            evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", tgd);
                            onCalculating(evt);
                            #endregion

                            sdeTblTgdEditor.SaveEdit();
                            sdeTblTgdEditor.StopEditOperation();
                            sdeTblTgdEditor.StopEditing(true);

                            #region ----log
                            evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", tgd);
                            onCalculating(evt);
                            #endregion

                            #endregion

                            #region tinh gia dat cho cac thua vua them vi tri
                            CalcLandprice calc = new CalcLandprice(this);
                            //MessageBox.Show(string.Format("final:{0}", newId.Count));
                            //calc.Maduong = maduong;
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
            }
            #endregion
            //=====================================================================
            //=====================================================================
            #region ko dung

            //#region tinh theo duong,doan duong
            //else
            //{
            //    #region timduong co ten dang xet
            //    //tinh theo doan duong
            //    #region tinh theo doan duong
            //    if (_inputParams.MA_DUONG != "-1")
            //    {
            //        qrf.WhereClause = string.Format("{0}={1} and {2}={3}", _fcName.FC_DUONG_CHINH_NONG_THON.MA_DUONG, _inputParams.MA_DUONG, _fcName.FC_DUONG.PHAN_LOAI, _isDothi);// "maduong='2'";

            //        #region ----log
            //        evt.Log = string.Format("\n************************************************");
            //        evt.Log += string.Format("\n******   Đang tính cho đoạn đường có mã: {0}  ******", _inputParams.MA_DUONG);
            //        evt.Log += string.Format("\n************************************************");
            //        onCalculating(evt);
            //        #endregion
            //    }
            //    #endregion
            //    //tinh cho 1 duong
            //    #region tinh cho 1 duong
            //    else if (_inputParams.TEN_DUONG != "" && _inputParams.TEN_DUONG != "*")
            //    {
            //        //phai sua lai thiet ke
            //        //dung relationshipclass many to many gia duong va ten duong
            //        #region tim trong bang ten duong
            //        qrf.WhereClause = string.Format("{0}=N'{1}'", _tblName.TEN_DUONG.TEN_DUONG, _inputParams.TEN_DUONG);
            //        ICursor tenduongCur = tblTenDuong.Search(qrf, false);
            //        object idDuong;
            //        List<object> lstIdDuong=new List<object>();
            //        try
            //        {
            //            IRow tenduongRow = null;
            //            while ((tenduongRow = tenduongCur.NextRow()) != null)
            //            {
            //                idDuong = tenduongRow.get_Value(tenduongRow.Fields.FindField(_tblName.TEN_DUONG.MA_DUONG));
            //                lstIdDuong.Add(idDuong);
            //            }
            //        }
            //        catch
            //        { }
            //        finally{Marshal.ReleaseComObject(tenduongCur);}
            //        #endregion

            //        #region tim trong bang duong
            //        string q = "";
            //        for (int i = 0; i < lstIdDuong.Count; i++)
            //        {
            //            if (i == lstIdDuong.Count - 1)
            //            {
            //                q += string.Format("{0}='{1}'", _fcName.FC_DUONG.MA_DUONG, lstIdDuong[i]);
            //            }
            //            else
            //            {
            //                q += string.Format("{0}='{1}' or ", _fcName.FC_DUONG.MA_DUONG, lstIdDuong[i]);
            //            }
            //        }
            //            qrf.WhereClause = q;// "maduong='2'";

            //        #region ----log
            //        evt.Log = string.Format("\n************************************************");
            //        evt.Log += string.Format("\n******   Đang tính cho cả đường: {0}  ******", _inputParams.TEN_DUONG);
            //        evt.Log += string.Format("\n************************************************");
            //        onCalculating(evt);
            //        #endregion
            //        #endregion
            //    }
            //    #endregion
            //    //tinh cho ca duong
            //    else
            //    {
            //        qrf.WhereClause = "";
            //    }
            //    //MessageBox.Show(string.Format("whereclause:{0}",duong.QueryFilter.WhereClause));
            //    ISelectionSet duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);

            //    if (duongSelectionSet.Count == 0)
            //    {
            //        return;
            //    }
            //    duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;
            //    duongFeatureSelection.SelectionSet = duongSelectionSet;

            //    #endregion

                

            //    #region vong lap xet tung duong

            //    //[thaydoi] - co the them bien chay
            //    //===============================
            //    #region khoi dau
            //    IEnumIDs eIds = duongSelectionSet.IDs;
            //    int duongId;
            //    IFeature ftDuong;
            //    int iDuong = 0;
            //    int progressingTotalCount = 1;
            //    evt.Reset();
            //    evt.ProgressingTotal = duongSelectionSet.Count;
            //    onCalculating(evt);
            //    List<object> lstMaDuong = new List<object>();
            //    #endregion
            //    //================================

            //    while ((duongId = eIds.Next()) != -1)
            //    {
            //        //[kodoi]
            //        //======================
            //        #region log-----
            //        evt.Reset();
            //        evt.ProgressingTotalCount = progressingTotalCount;
            //        onCalculating(evt);
            //        progressingTotalCount++;
            //        #endregion
            //        //======================

            //        //[capnhat] - lay ten duong tu bang ten duong
            //        //++++++++++++++++++++++++
            //        #region lay thong tin cua duong dang xet

            //        ftDuong = duongFeatureClass.GetFeature(duongId);
            //        string tenduong = "";//ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.TEN_DUONG)).ToString();
            //        object maduong = ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.MA_DUONG));
            //        lstMaDuong.Add(maduong);
            //        string batdau = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.BAT_DAU)).ToString();
            //        string ketthuc = "";// ftDuong.get_Value(_fcName.FC_DUONG.GetIndex(_fcName.FC_DUONG.KET_THUC)).ToString();

            //        #endregion
            //        //++++++++++++++++++++++++

            //        //[kodoi]
            //        //Chon duong dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
            //        //====================
            //        #region chon duong dang xet
            //        qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_DUONG.OID, duongId);
            //        duongSelectionSet = duongFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
            //        duongFeatureSelection = (IFeatureSelection)duongFeatureLayer;
            //        duongFeatureSelection.SelectionSet = duongSelectionSet;
            //        #endregion

            //        #region chon hem chinh cua duong
            //        qrf.WhereClause = string.Format("{0}='{1}' and ({2}='{3}' or {4} is null)", _fcName.FC_HEM.MA_DUONG, maduong, _fcName.FC_HEM.HEM_CHINH, 0, _fcName.FC_HEM.HEM_CHINH);
            //        ISelectionSet hemSelectionSet = ttXaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, sdeConn.Workspace);
            //        ttXaFeatureSelection = (IFeatureSelection)ttXaFeatureLayer;
            //        ttXaFeatureSelection.SelectionSet = hemSelectionSet;
            //        #endregion
            //        //====================

            //        #region vong lap xet tung hem
            //        //[thaydoi] - co the them bien chay
            //        //===============================
            //        #region khoi dau
            //        IEnumIDs eIdsHem = hemSelectionSet.IDs;
            //        int hemId;
            //        IFeature ftHem;
            //        int iHem = 0;
            //        evt.Reset();
            //        evt.ProgressingPart1Total = hemSelectionSet.Count;
            //        int progressingPart1Count = 1;
            //        onCalculating(evt);
            //        #endregion

            //        while ((hemId = eIdsHem.Next()) != -1)
            //        {
            //            //[kodoi]
            //            //======================
            //            #region log-----
            //            evt.Reset();
            //            //evt.ProgressingPart1Total = progressingTotalCount;
            //            evt.ProgressingPart1Count = progressingPart1Count;
            //            onCalculating(evt);
            //            progressingPart1Count++;
            //            #endregion

            //            //[capnhat] - lay ten duong tu bang ten duong
            //            //++++++++++++++++++++++++
            //            #region lay thong tin cua hem dang xet

            //            ftHem = ttXaFeatureClass.GetFeature(hemId);
            //            object mahem = ftHem.get_Value(ftHem.Fields.FindField(_fcName.FC_HEM.MA_HEM));
            //            object tenhem = ftHem.get_Value(ftHem.Fields.FindField(_fcName.FC_HEM.TEN_HEM));
            //            double dorong;
            //            result = double.TryParse(ftHem.get_Value(ftHem.Fields.FindField(_fcName.FC_HEM.DO_RONG)).ToString(),out dorong);
            //            if (!result)
            //            {
            //                dorong = 0;
            //            }
            //            #endregion
            //            //++++++++++++++++++++++++

            //            //[kodoi]
            //            //Chon hem dang xet, buoc này de ra layer duong dung de truy van khong gian cac thua dat
            //            //====================
            //            #region chon hem dang xet
            //            qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_HEM.OID, hemId);
            //            hemSelectionSet = ttXaFeatureClass.Select(qrf, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionOnlyOne, sdeConn.Workspace);
            //            ttXaFeatureSelection = (IFeatureSelection)ttXaFeatureLayer;
            //            ttXaFeatureSelection.SelectionSet = hemSelectionSet;
            //            #endregion
            //            //====================

            //            //================================
            //            //tim cac thua theo dieu kien mat tien
            //            #region tinh vi tri cho cac thua
            //            //[kodoi]
            //            //============================
            //            #region tim cac thua theo vi tri quy dinh
            //            thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
            //            thuaFeatureSelection.Clear();
                        
            //            eval.ThuaLayer = thuaFeatureLayer;
            //            eval.DuongLayer = duongFeatureLayer;
            //            eval.HemChinhLayer = ttXaFeatureLayer;
            //            eval.EvaluateQuery();
            //            //thuaFeatureSelection = (IFeatureSelection)thuaFeatureLayer;
            //            ISelectionSet thuaSelectionSet = thuaFeatureSelection.SelectionSet;
            //            #endregion
            //            //============================

            //            //MessageBox.Show(thuaSelectionSet.Count.ToString());
            //            #endregion

            //            //[kodoi]
            //            //============================
            //            #region ----log
            //            if (thuaSelectionSet.Count == 0)
            //            {
            //                evt.Log = string.Format("\n !!! Không tìm thấy thửa nào trong hẻm {0},(mã={1}), và cách đường {2} đoạn từ {3} đến {4} 100m",tenhem,mahem, tenduong, batdau, ketthuc);
            //                onCalculating(evt);

            //                #region report progressing hem
            //                if (iHem < hemSelectionSet.Count)
            //                {
            //                    decimal i = (decimal)iHem % (decimal)hemSelectionSet.Count * 100;
            //                    int i1 = Convert.ToInt32(i);
            //                    this._bgwCalculating.ReportProgress(i1);
            //                    //MessageBox.Show("log 009");
            //                }
            //                else
            //                {
            //                    this._bgwCalculating.ReportProgress(99);
            //                }
            //                iHem++;
            //                #endregion

            //                continue;
            //            }
            //            #endregion
            //            sothuatimthay += thuaSelectionSet.Count;
            //            //============================

            //            #region xet tung thua

            //            //[thaydoi] - co the them bien chay
            //            //********************
            //            #region khoi dau
            //            IEnumIDs thuaIds = thuaSelectionSet.IDs;
            //            int thuaId;
            //            IFeature thuaFt;
            //            int iThua = 0;
            //            List<object[,]> pairColValTgd = new List<object[,]>();
            //            int rowTgdNnHandleUpdate = 0;
            //            List<object> newId = new List<object>();
            //            #endregion
            //            //********************

            //            while ((thuaId = thuaIds.Next()) != -1)
            //            {
            //                int hesoVitri = TnHeSoK.DatOHemChinhR6mS100mTronThua;

            //                //[thaydoi] - co them them dieu kien de xac dinh vi tri cua thua
            //                //***********************************
            //                #region lay thong tin thua dang xet

            //                //[kodoi]
            //                //============================
            //                #region lay thong tin co ban
            //                thuaFt = thuaFeatureClass.GetFeature(thuaId);
            //                //neu thua bi khoa tim vi tri,bo qua,xet thua ke
            //                string lockTimVitri = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOCKED)).ToString();
            //                if (lockTimVitri == "1")
            //                {
            //                    sothuaKhongTinhDuoc++;

            //                    #region report progressing thua
            //                    if (iThua < thuaSelectionSet.Count)
            //                    {
            //                        decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
            //                        int i1 = Convert.ToInt32(i);
            //                        this._bgwCalculating.ReportProgress(i1);
            //                        //MessageBox.Show("log 009");
            //                    }
            //                    else
            //                    {
            //                        this._bgwCalculating.ReportProgress(99);
            //                    }
            //                    iThua++;
            //                    #endregion

            //                    continue;

            //                }
            //                //neu thua ko thuoc xa dang xet thi ko tinh tiep
            //                object mathua = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_THUA));
            //                object maxaThua = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.MA_XA));
            //                object dientichpl = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.DIEN_TICH));
            //                #endregion
            //                //============================

            //                //[kodoi]
            //                //============================
            //                #region kiem tra maxa
            //                if (maxaThua.ToString() == "" || maxaThua == null)
            //                {
            //                    maxaThua = "0";

            //                    #region ----log
            //                    evt.Reset();
            //                    evt.Log = string.Format("Chưa xác định mã xã cho thửa {0}", mathua);
            //                    onCalculating(evt);
            //                    #endregion

            //                    sothuaKhongTinhDuoc++;

            //                    #region report progressing thua
            //                    if (iThua < thuaSelectionSet.Count)
            //                    {
            //                        decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
            //                        int i1 = Convert.ToInt32(i);
            //                        this._bgwCalculating.ReportProgress(i1);
            //                        //MessageBox.Show("log 009");
            //                    }
            //                    else
            //                    {
            //                        this._bgwCalculating.ReportProgress(99);
            //                    }
            //                    iThua++;
            //                    #endregion

            //                    continue;
            //                }
            //                #endregion

            //                #region lay thong tin loai do thi
            //                //neu ko la do thi thi bo qua,xet thua ke
            //                qrf.WhereClause = string.Format("{0}={1}", _fcName.FC_RANH_XA_POLY.MA_XA, maxaThua);
            //                IFeatureCursor fcrXa = xaFeatureClass.Search(qrf, false);

            //                IFeature ftXa = fcrXa.NextFeature();
            //                string loaiDoThi = "";
            //                if (ftXa != null)
            //                {
            //                    loaiDoThi = ftXa.get_Value(ftXa.Fields.FindField(_fcName.FC_RANH_XA_POLY.LOAI_DO_THI)).ToString();
            //                }
            //                else
            //                {
            //                    loaiDoThi = "0";
            //                }
            //                if (loaiDoThi == "0")
            //                {
            //                    sothuaKhongTinhDuoc++;

            //                    #region report progressing thua
            //                    if (iThua < thuaSelectionSet.Count)
            //                    {
            //                        decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
            //                        int i1 = Convert.ToInt32(i);
            //                        this._bgwCalculating.ReportProgress(i1);
            //                        //MessageBox.Show("log 009");
            //                    }
            //                    else
            //                    {
            //                        this._bgwCalculating.ReportProgress(99);
            //                    }
            //                    iThua++;
            //                    #endregion

            //                    continue;
            //                }
            //                #endregion
            //                //============================

            //                #region lay loai dat

            //                //neu ko co dat phi nong nghiep thi bo qua,xet thua ke
            //                //neu co dat nong nghiep thi datnn=true
            //                //neu la dat hon hop, neu co dat sxkd thi datsxkd=true, 
            //                //neu co dat o thi codato=true
            //                //cac truong hop he so vi tri:
            //                //o:3010, sxkd:4010, o+nn:5010, o+sxkd:6010
            //                string loaidat = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOAI_DAT)).ToString();
            //                //evt.Log = string.Format("\n loai dat cua thua {0} la {1}", thuaId, loaidat);
            //                //onCalculating(evt);

            //                //[thaydoi] - may tinh dat nong nghiep co the khac
            //                //***********************
            //                #region kiem tra dat phi nong nghiep
            //                bool datpnn = false;
            //                foreach (string s in TnLoaiDats.PHI_NONG_NGHIEP_DOTHI)
            //                {
            //                    if (loaidat.Contains(s))
            //                    {
            //                        datpnn = true;
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        datpnn = false;
            //                    }
            //                }
            //                if (!datpnn)
            //                {
            //                    sothuaKhongTinhDuoc++;

            //                    #region report progressing thua
            //                    if (iThua < thuaSelectionSet.Count)
            //                    {
            //                        decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
            //                        int i1 = Convert.ToInt32(i);
            //                        this._bgwCalculating.ReportProgress(i1);
            //                        //MessageBox.Show("log 009");
            //                    }
            //                    else
            //                    {
            //                        this._bgwCalculating.ReportProgress(99);
            //                    }
            //                    iThua++;
            //                    #endregion

            //                    continue;
            //                }
            //                #endregion
            //                //***********************

            //                //[thaydoi] - may tinh dat nong nghiep co the khac
            //                //***********************
            //                #region kiem tra dat honhop
            //                bool datsxkd = false;
            //                bool dathonhop = false;
            //                bool codato = false;
            //                bool chicodato = false;
            //                bool chicodatsxkd = false;
            //                bool datnn = false;
            //                string loaidatNn = "";

            //                //evt.Log = string.Format("line 983 mattien, loaidat:{0}", loaidat);
            //                //onCalculating(evt);
            //                if (loaidat.Contains("+"))
            //                {
            //                    //evt.Log = string.Format("line 987 mattien, loaidat:{0}, co +", loaidat);
            //                    //onCalculating(evt);
            //                    dathonhop = true;
            //                    #region kiem tra co dat o
            //                    if (loaidat.Contains("ODT"))
            //                    {
            //                        //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
            //                        //onCalculating(evt);

            //                        codato = true;
            //                    }
            //                    #endregion

            //                    #region kiem tra co dat nong nghiep

            //                    foreach (string s in TnLoaiDats.NONG_NGHIEP)
            //                    {
            //                        if (loaidat.Contains(s))
            //                        {
            //                            datnn = true;
            //                            loaidatNn = s;

            //                            break;
            //                        }
            //                        else
            //                        {
            //                            datnn = false;
            //                        }
            //                    }
            //                    #endregion

            //                    #region kiem tra chi co dat sxkd
            //                    foreach (string s in TnLoaiDats.PNN_SX_KD)
            //                    {
            //                        if (loaidat == s)
            //                        {
            //                            chicodatsxkd = true;

            //                            break;
            //                        }

            //                        else
            //                        {
            //                            chicodatsxkd = false;
            //                        }
            //                    }
            //                    #endregion
            //                }
            //                else
            //                {
            //                    #region kiem tra chi co dat o

            //                    if (loaidat.Contains("ODT"))
            //                    {
            //                        //evt.Log = string.Format("line 992 mattien, loaidat:{0}, co odt", loaidat);
            //                        //onCalculating(evt);
            //                        chicodato = true;
            //                    }
            //                    else
            //                    {
            //                        chicodato = false;
            //                    }
            //                    #endregion

            //                    #region kiem tra chi co dat sxkd
            //                    foreach (string s in TnLoaiDats.PNN_SX_KD)
            //                    {
            //                        if (loaidat == s)
            //                        {
            //                            chicodatsxkd = true;

            //                            break;
            //                        }

            //                        else
            //                        {
            //                            chicodatsxkd = false;
            //                        }
            //                    }
            //                    #endregion

            //                }

            //                #endregion
            //                //***********************

            //                #endregion

            //                #endregion
            //                //***********************************

            //                //[thaydoi] - thay doi he so vi tri phu hop
            //                //***********************************
            //                #region quyet dinh he so vi tri cho thua
            //                if (chicodato)
            //                {
            //                    if (dorong > 6)
            //                    {
            //                        hesoVitri = TnHeSoK.DatOHemChinhR6mS100mTronThua;
            //                    }
            //                    else if (dorong < 3.5)
            //                    {
            //                        hesoVitri = TnHeSoK.DatOHemChinhR3mS100mTronThua;
            //                    }
            //                    else
            //                    {
            //                        hesoVitri = TnHeSoK.DatOHemChinhR3_6mS100mTronThua;
            //                    }
            //                }
            //                else if (chicodatsxkd)
            //                {
            //                    if (dorong > 6)
            //                    {
            //                        hesoVitri = TnHeSoK.DatSxkdHemChinhR6mS100mTronThua;
            //                    }
            //                    else if (dorong < 3.5)
            //                    {
            //                        hesoVitri = TnHeSoK.DatSxkdHemChinhR3mS100mTronThua;
            //                    }
            //                    else
            //                    {
            //                        hesoVitri = TnHeSoK.DatSxkdHemChinhR3_6mS100mTronThua;
            //                    }
            //                }
            //                else if (dathonhop && codato && datnn)
            //                {
            //                    if (dorong > 6)
            //                    {
            //                        hesoVitri = TnHeSoK.DatONnHemChinhR6mS100mTronThua;
            //                    }
            //                    else if (dorong < 3.5)
            //                    {
            //                        hesoVitri = TnHeSoK.DatONnHemChinhR3mS100mTronThua;
            //                    }
            //                    else
            //                    {
            //                        hesoVitri = TnHeSoK.DatONnHemChinhR3_6mS100mTronThua;
            //                    }
            //                }
            //                else
            //                {
            //                    hesoVitri = TnHeSoK.KhongXacDinh;
            //                }
            //                //else if (dathonhop && codato && datsxkd)
            //                //{
            //                //    hesoVitri = TnHeSoK.DatOSxkdMatTien;
            //                //}
            //                #endregion
            //                //***********************************

            //                //[thaydoi] - thay doi dieu kien truy van ung voi tung may tinh khac nhau
            //                //***********************************
            //                #region kiem tra trong bang thua_giadat, voi dieu kien:mathua,maduong,hesovitri,khoagia=0
            //                evt.Reset();
            //                evt.Log = string.Format("\n[!]--- Kiểm tra các vị trí, cập nhật vị trí mới cho thửa {0} ...",mathua);
            //                onCalculating(evt);
            //                qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}' and {7}='{8}'",
            //                    _fcName.FC_THUA_GIADAT_DRAFT.LOCKED, 0, _fcName.FC_THUA_GIADAT_DRAFT.LOCKED,
            //                    _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua,
            //                    _fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG, maduong,
            //                    _fcName.FC_THUA_GIADAT_DRAFT.MA_HEM,mahem,
            //                    _fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K, hesoVitri);
            //                ICursor tgdFcs = tblThuaGiaDat.Search(qrf, false);
            //                IRow tgdRow = null;
            //                //MessageBox.Show(string.Format("line 1401 CalcPosThuaMattien - bat dau try, query:\n{0}", qrf.WhereClause));
            //                try
            //                {
            //                    tgdRow = tgdFcs.NextRow();//dam bao la chi co 1 hang ket qua   
            //                    if (tgdRow != null)
            //                    {
            //                        //MessageBox.Show("co");
            //                        //kiem tra co cho phep tinh lai vi tri (locked=1)
            //                        //neu co:xoa feater cu,them feature moi
            //                        #region xet thua da co vi tri

            //                        bool isOverWritePos = true;

            //                        if (!isOverWritePos)
            //                        {
            //                            newId.Add(tgdRow.OID);
            //                            //continue;
            //                        }
            //                        else
            //                        {
            //                            //[kodoi]
            //                            //===================
            //                            #region xoa feature cu
            //                            wspEdit.StartEditing(true);
            //                            wspEdit.StartEditOperation();
            //                            //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
            //                            //tblThuaGiaDat.DeleteSearchedRows(qrf);
            //                            tgdRow.Delete();
            //                            wspEdit.StopEditOperation();
            //                            wspEdit.StopEditing(true);
            //                            #endregion
            //                            //===================

            //                            //[thaydoi] - them gia tri
            //                            //**********************
            //                            #region them feature moi
            //                            wspEdit.StartEditing(true);
            //                            wspEdit.StartEditOperation();
            //                            object copiedId = copyTool.Copy(thuaFt, tgdFeatureClass);
            //                            wspEdit.StopEditOperation();
            //                            wspEdit.StopEditing(true);

            //                            //them gia tri mathua,maduong,hesovitri
            //                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
            //                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
            //                            pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_HEM), mahem } });
            //                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
            //                            pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
            //                            sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
            //                            rowTgdNnHandleUpdate++;
            //                            pairColValTgd.Clear();
            //                            newId.Add(copiedId);
            //                            #endregion
            //                            //**********************
            //                        }

            //                        #endregion

            //                    }
            //                    else
            //                    {
            //                        //MessageBox.Show("ko co");
            //                        //[thaydoi] - them cac gia tri thich hop vao thua_giadat
            //                        //***********************************
            //                        #region them feature moi
            //                        wspEdit.StartEditing(true);
            //                        wspEdit.StartEditOperation();
            //                        object copiedId = copyTool.Copy(thuaFt, tgdFeatureClass);
            //                        wspEdit.StopEditOperation();
            //                        wspEdit.StopEditing(true);

            //                        //them gia tri mathua,maduong,hesovitri
            //                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
            //                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
            //                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_HEM), mahem } });
            //                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
            //                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
            //                        sdeTblTgdEditor.CacheData(copiedId, rowTgdNnHandleUpdate, pairColValTgd, EnumTypeOfEdit.UPDATE);
            //                        rowTgdNnHandleUpdate++;
            //                        pairColValTgd.Clear();
            //                        newId.Add(copiedId);
            //                        #endregion
            //                        //***********************************
            //                    }
            //                    //MessageBox.Show(newId.Count.ToString());
            //                }
            //                catch (Exception e1) { MessageBox.Show(string.Format("CalcPosThuaMattien, line 1448-\n{0}", e1)); }
            //                finally { Marshal.ReleaseComObject(tgdFcs); }
            //                #endregion
            //                //***********************************

            //                #region report progressing thua
            //                if (iThua < thuaSelectionSet.Count)
            //                {
            //                    decimal i = (decimal)iThua / (decimal)thuaSelectionSet.Count * 100;
            //                    int i1 = Convert.ToInt32(i);
            //                    this._bgwCalculating.ReportProgress(i1);
            //                    //MessageBox.Show("log 009");
            //                }
            //                else
            //                {
            //                    this._bgwCalculating.ReportProgress(99);
            //                }
            //                iThua++;
            //                #endregion
            //            }
            //            #endregion

            //            //[kodoi]
            //            //============================
            //            #region luu thong tin vao bang gia dat
            //            if (!sdeTblTgdEditor.IsEditing())
            //            {
            //                sdeTblTgdEditor.StartEditing(true);
            //                sdeTblTgdEditor.StartEditOperation();
            //            }

            //            #region ----log
            //            evt.Log = string.Format("\n----||| Đang lưu vị trí các thửa vào bảng {0} |||---- ", tgd);
            //            onCalculating(evt);
            //            #endregion

            //            sdeTblTgdEditor.SaveEdit();
            //            sdeTblTgdEditor.StopEditOperation();
            //            sdeTblTgdEditor.StopEditing(true);

            //            #region ----log
            //            evt.Log = string.Format("\n----||| Đã lưu vị trí các thửa vào bảng {0} |||---- ", tgd);
            //            onCalculating(evt);
            //            #endregion

            //            #endregion

            //            #region tinh gia dat cho cac thua vua them vi tri
            //            CalcLandprice calc = new CalcLandprice(this);
            //            //MessageBox.Show(string.Format("final:{0}", newId.Count));
            //            calc.Maduong = maduong;
            //            calc.Calculate(newId);
            //            newId.Clear();
            //            #endregion
            //            //============================
            //        }
            //        #endregion

                    



            //    }
            //    #endregion
            //}
            //#endregion

            #endregion ko dung

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
            evt.ProgressingPart1Count = ".";
            evt.ProgressingPart1Total = ".";
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
