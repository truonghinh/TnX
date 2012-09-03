using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.tn.calculation.calculator;
using com.g1.arcgis.calculation;
using com.g1.arcgis.database;
using com.g1.arcgis.tn.config;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using System.Runtime.InteropServices;
using System.Threading;

namespace com.g1.arcgis.tn.calculation
{
    public partial class FrmFilterLandprice : DevExpress.XtraEditors.XtraForm
    {
        private BackgroundWorker _bwk = new BackgroundWorker();
        private delegate void _prgressing(int progress);
        private delegate void _reporting(object log);
        //private static BackgroundWorker _bwk = new BackgroundWorker();
        private List<object> _publishedId=new List<object>();
        private const int CP_NOCLOSE_BUTTON = 0x200;
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        } 
        
        public FrmFilterLandprice()
        {
            InitializeComponent();
        }

        public List<object> GetPublishedId()
        {
            return _publishedId;
        }

        public void SetProgress(int progress)
        {
            if (this.progressBarControl1.InvokeRequired)
            {
                _prgressing progressDelegate = new _prgressing(this.SetProgress);
                this.progressBarControl1.Invoke(progressDelegate, new object[] { progress });
            }
            else
            {
                this.progressBarControl1.EditValue = progress;
            }
        }

        public void SetReport(object log)
        {
            if (this.labelControl1.InvokeRequired)
            {
                _reporting progressDelegate = new _reporting(this.SetReport);
                this.labelControl1.Invoke(progressDelegate, new object[] { log });
            }
            else
            {
                this.labelControl1.Text = string.Format("{0} ...",log.ToString());
            }
        }

        public void Filter(List<object> newId)
        {
            filterAndPublicPrice(newId);
        }

        

        public void filterAndPublicPrice(List<object> newId)
        {
            _bwk.DoWork -= _bwk_DoWork;
            _bwk.DoWork += _bwk_DoWork;

            _bwk.WorkerReportsProgress = true;
            _bwk.ProgressChanged -= _bwk_ProgressChanged;
            _bwk.ProgressChanged += _bwk_ProgressChanged;

            _bwk.RunWorkerCompleted -= _bwk_RunWorkerCompleted;
            _bwk.RunWorkerCompleted += _bwk_RunWorkerCompleted;
            _bwk.RunWorkerAsync(newId);
            //_bwk_DoWork(null, new DoWorkEventArgs(newId));
        }

        private void _bwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ThreadStart sumThread = () => summarise(_publishedId);
            Thread sumT = new Thread(sumThread);
            sumT.Start();
            sumT.Join();
            this.Close();
        }

        private void _bwk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.SetProgress(e.ProgressPercentage);
        }

        private void _bwk_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> newId = (List<object>)e.Argument;
            //frm = new FrmFilterLandprice();
            //showFrm();

            //MessageBox.Show("line 117");
            ICurrentConfig _currentConfig = CurrentConfig.CallMe();
            ICopyFeatures copyTool;
            
            

            #region chon loc gia dat

            #region khoi tao cac bien
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            IWorkspaceEdit _wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit _mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            ITnFeatureClassName _fcName = new TnFeatureClassName(sdeConn.Workspace);
            //ITnTableName _tblName = new TnTableName(sdeConn.Workspace);
            string tgd = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat, _currentConfig.NamApDung);
            string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, _currentConfig.NamApDung);
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            _fcName.FC_THUA_GIADAT.NAME = tgd;
            _fcName.FC_THUA_GIADAT.InitIndex();
            IFeatureClass tgdFeatureClassDraft = null;
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
            ISDETableEditor sdeTblTgdDraftEditor = new SDETable(tblThuaGiaDatDraft, sdeConn.Workspace);
            List<object[,]> pairColValTgdDraft = new List<object[,]>();
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
            //evt.Reset();
            //evt.Log = "\n\nBắt đầu chọn lọc giá cho các thửa vừa tính...";
            //_caller.onCalculating(evt);
            int len = newId.Count;
            int thuaCount = 1;
            //MessageBox.Show(string.Format("line 620 CalcLandprice {0}",len.ToString()));
            #endregion
            List<object> mathuaCalced = new List<object>();
            _publishedId = new List<object>();
            foreach (object o in newId)
            {
                if (thuaCount < len)
                {
                    decimal i = (decimal)thuaCount / (decimal)len * 100;
                    int i1 = Convert.ToInt32(i);
                    _bwk.ReportProgress(i1);
                    //MessageBox.Show("log 009");
                }
                else
                {
                    _bwk.ReportProgress(99);
                }
                thuaCount++;
                //evt.Reset();
                //evt.Log = string.Format("\n\nchọn lọc giá cho thửa {0}", o);
                //_caller.onCalculating(evt);
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
                    int somattien = 0;
                    while ((tgdDraftFt = tgdDraftCur.NextFeature()) != null)
                    {
                        id = tgdDraftFt.OID;

                        hesok = tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K));
                        result = double.TryParse(tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DON_GIA)).ToString(), out dongia);
                        if (!result)
                        {
                            dongia = 0;
                        }
                        //result=int.TryParse(tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.SO_MAT_TIEN)).ToString(), out somattien);
                        //if (!result)
                        //{
                        //    somattien = 0;
                        //}
                        info.Add(new landpriceInfo(id, hesok, dongia));
                        //frm.SetReport(string.Format("\n\nVùng giá {0}, số vùng giá:{1} ", id, info.Count));
                        //evt.Reset();
                        //evt.Log = string.Format("\n\nVùng giá {0}, số vùng giá:{1} ", id,info.Count);
                        //_caller.onCalculating(evt);
                    }

                    #region xet dieu kien de luu cac vung gia vao bang gia cong bo
                    //neu chi co 1 vung gia thi ko can suy nghi
                    int sovunggia = info.Count;
                    this.SetReport(string.Format("Số vùng giá của thửa {0} là {1}", mathuaNew, sovunggia));
                    //evt.Reset();
                    //evt.Log = string.Format("\n\nSố vùng giá của thửa {0} là {1}", mathuaNew, sovunggia);
                    //_caller.onCalculating(evt);
                    if (sovunggia == 0)
                    {
                        continue;
                    }
                    //MessageBox.Show(string.Format("line 266 FrmFilterLandprice, sovung gia={0}", info.Count));

                    //=====================================================
                    //============Loc gia==================================
                    FilterLandprice.GetMaxValueWithDistinctKey(info, out infoResult);
                    //======================================================

                    //MessageBox.Show(string.Format("line 658 CalcLandprice, giadat={0}", infoResult[0].Dongia));
                    foreach (landpriceInfo inf in infoResult)
                    {
                        tgdDraftFt = tgdFeatureClassDraft.GetFeature((int)inf.Id);
                        object mathua = tgdDraftFt.get_Value(tgdDraftFt.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA));
                        qrf.WhereClause = string.Format("{0}='{1}' and {2}='{3}'",
                            _fcName.FC_THUA_GIADAT.HE_SO_K, inf.Hesok,
                            _fcName.FC_THUA_GIADAT.MA_THUA, mathua);
                        IFeatureCursor tgdFcur = tgdFeatureClass.Search(qrf, false);
                        IFeature tgdFt = null;
                        object copiedId = null;
                        try
                        {
                            //MessageBox.Show(string.Format("line 686 CalcLandprice, bat dau"));
                            if ((tgdFt = tgdFcur.NextFeature()) != null)
                            {
                                #region xet thua da co vi tri

                                bool isOverWritePos = true;

                                if (!isOverWritePos)
                                {
                                    _publishedId.Add(tgdFt.OID);
                                    continue;
                                }
                                else
                                {
                                    //[kodoi]
                                    //===================
                                    #region xoa feature cu
                                    //MessageBox.Show("line 303 FrmFilt, isbeingedit:"+_wspEdit.IsBeingEdited());
                                    if (_wspEdit.IsBeingEdited())
                                    {
                                        MessageBox.Show("line 305 FrmFilt, edited");
                                        try
                                        {
                                            
                                            _wspEdit.StopEditOperation();
                                            _wspEdit.StopEditing(true);
                                        }
                                        catch (Exception ex)
                                        {
                                            _wspEdit.StopEditOperation();
                                            _wspEdit.StopEditing(false);
                                        }
                                    }
                                    try
                                    {
                                        //_wspEdit.StopEditOperation();
                                        //_wspEdit.StopEditing(false);
                                        _mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        //_wspEdit.StartEditing(true);
                                        _wspEdit.StartEditOperation();
                                    }
                                    catch (Exception ex) 
                                    { 
                                        MessageBox.Show("line 323 FrmFilt, ex=" + ex); 
                                        //_wspEdit.StopEditOperation();
                                        //_wspEdit.StopEditing(false);
                                        //_mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                        //_wspEdit.StartEditOperation();
                                    }
                                    this.SetReport(string.Format("Xóa vùng giá {0}", mathua));
                                    //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                                    //tblThuaGiaDat.DeleteSearchedRows(qrf);
                                    //MessageBox.Show(string.Format("line 720 CalcLandprice, bat dau xoa thua {0}",mathua));
                                    tgdFt.Delete();
                                    _wspEdit.StopEditOperation();
                                    _wspEdit.StopEditing(true);
                                    #endregion
                                    //===================

                                    //[thaydoi] - them gia tri
                                    //**********************
                                    #region them feature moi
                                    if (_wspEdit.IsBeingEdited())
                                    {
                                        MessageBox.Show("line 334 FrmFilt, edited");
                                        try
                                        {

                                            _wspEdit.StopEditOperation();
                                            _wspEdit.StopEditing(true);
                                        }
                                        catch (Exception ex)
                                        {
                                            _wspEdit.StopEditOperation();
                                            _wspEdit.StopEditing(false);
                                        }
                                    }
                                    _mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                    _wspEdit.StartEditOperation();
                                    
                                    copiedId = copyTool.CopyWithAllAttribute(tgdDraftFt, tgdFeatureClass);
                                    this.SetReport(string.Format("Công bố vùng giá {0}", copiedId));
                                    //MessageBox.Show(string.Format("line 743 CalcLandprice, oid={0}", copiedId));
                                    try
                                    {
                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(true);
                                    }
                                    catch (Exception ex)
                                    {
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
                                    _publishedId.Add(copiedId);
                                    #endregion
                                    //**********************
                                }

                                #endregion
                            }
                            else
                            {
                                #region them feature moi
                                if (_wspEdit.IsBeingEdited())
                                {
                                    MessageBox.Show("line 385 FrmFilt, edited");
                                    try
                                    {

                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(true);
                                    }
                                    catch (Exception ex)
                                    {
                                        _wspEdit.StopEditOperation();
                                        _wspEdit.StopEditing(false);
                                    }
                                }
                                _mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                _wspEdit.StartEditOperation();
                                copiedId = copyTool.CopyWithAllAttribute(tgdDraftFt, tgdFeatureClass);
                                
                                //MessageBox.Show(string.Format("line 743 CalcLandprice, oid={0}", copiedId));
                                this.SetReport(string.Format("Công bố vùng giá {0}", copiedId));
                                try
                                {
                                    _wspEdit.StopEditOperation();
                                    _wspEdit.StopEditing(true);
                                }
                                catch (Exception ex)
                                {
                                    _wspEdit.StopEditOperation();
                                    _wspEdit.StopEditing(false);
                                }
                                _publishedId.Add(copiedId);
                                #endregion
                            }

                            #region ghi gia dat moi (da nhan he so mat tien neu co)
                            
                            pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.DON_GIA), inf.Dongia } });
                            pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT.GetIndex(_fcName.FC_THUA_GIADAT.SO_MAT_TIEN), inf.Somattien } });
                            sdeTblTgdEditor.CacheData(copiedId, 0, pairColValTgd, EnumTypeOfEdit.UPDATE);
                            pairColValTgd.Clear();
                            if (!sdeTblTgdEditor.IsEditing())
                            {
                                sdeTblTgdEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                                sdeTblTgdEditor.StartEditOperation();
                            }
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
                            #endregion
                        }
                        catch (Exception e1) { MessageBox.Show(string.Format("CalcLandprice, line 736-\n{0}", e1)); }
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
            //e.Result = _publishedId;

            #endregion

            #endregion


        }
        private void summarise(List<object> newId)
        {
            FrmSummarizeLandprice frm = new FrmSummarizeLandprice();
            frm.Summarize(newId);
            frm.ShowDialog();
        }
    }
}