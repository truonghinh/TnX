using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.config;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.database;
using System.Runtime.InteropServices;

namespace com.g1.arcgis.tn.calculation
{
    public partial class FrmSummarizeLandprice : DevExpress.XtraEditors.XtraForm
    {
        private BackgroundWorker _bwk = new BackgroundWorker();
        private delegate void _prgressing(int progress);
        private delegate void _reporting(object log);
        public FrmSummarizeLandprice()
        {
            InitializeComponent();
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
                this.progressBarControl1.Text = progress.ToString();
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
                this.labelControl1.Text = string.Format("{0} ...", log.ToString());
            }
        }

        public void Summarize(List<object> newId)
        {
            _bwk.DoWork -= _bwk_DoWork;
            _bwk.DoWork += _bwk_DoWork;

            _bwk.WorkerReportsProgress = true;
            _bwk.ProgressChanged -= _bwk_ProgressChanged;
            _bwk.ProgressChanged += _bwk_ProgressChanged;

            _bwk.RunWorkerCompleted -= _bwk_RunWorkerCompleted;
            _bwk.RunWorkerCompleted += _bwk_RunWorkerCompleted;
            _bwk.RunWorkerAsync(newId);
        }
        private void _bwk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        private void _bwk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.SetProgress(e.ProgressPercentage);
        }
        private void _bwk_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> newId = (List<object>)e.Argument;
            ICurrentConfig _currentConfig = CurrentConfig.CallMe();

            #region khoi tao connection
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            IWorkspaceEdit _wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit _mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            ITnFeatureClassName _fcName = new TnFeatureClassName(sdeConn.Workspace);
            ITnTableName _tblName = new TnTableName(sdeConn.Workspace);
            #endregion

            #region khoi tao cac bien
            string tgd = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat, _currentConfig.NamApDung);
            string thua = string.Format("{0}_{1}", DataNameTemplate.Thua, _currentConfig.NamApDung);
            _fcName.FC_THUA_GIADAT.NAME = tgd;
            _fcName.FC_THUA_GIADAT.InitIndex();
            _fcName.FC_THUA.NAME = thua;
            _fcName.FC_THUA.InitIndex();
            IFeatureClass tgdFeatureClass = null;
            IFeatureClass thuaFeatureClass = null;
            try
            {
                tgdFeatureClass = fw.OpenFeatureClass(tgd);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + tgd);
                return;
            }
            try
            {
                thuaFeatureClass = fw.OpenFeatureClass(thua);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy bảng " + thua);
                return;
            }
            ITable tblThua = (ITable)thuaFeatureClass;
            ITable tblThuaGiaDat = (ITable)tgdFeatureClass;
            ISDETableEditor sdeTblThuaEditor = new SDETable(tblThua, sdeConn.Workspace);
            IQueryFilter qrf = new QueryFilterClass();
            bool result = false;
            #endregion

            #region vong lap tung id

            #region khoi dau

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
                IRow tgdRowNew=null;
                try
                {
                    tgdRowNew = tblThuaGiaDat.GetRow((int)o);
                }
                catch(Exception ex) { continue; }
                if (tgdRowNew == null)
                {
                    continue;
                }
                string mathuaNew = tgdRowNew.get_Value(tgdRowNew.Fields.FindField(_fcName.FC_THUA_GIADAT.MA_THUA)).ToString();
                //MessageBox.Show(string.Format("line 156 Sum: mathua={0}", mathuaNew));
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
                qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA_GIADAT.MA_THUA, mathuaNew);
                IFeatureCursor tgdCur = tgdFeatureClass.Search(qrf, false);
                IFeature tgdFt = null;
                try
                {
                    double giadatTong = 0;
                    double giadat = 0;
                    object id = 0;
                    int maduong = 0;
                    while ((tgdFt = tgdCur.NextFeature()) != null)
                    {
                        id = tgdFt.OID;
                        result = double.TryParse(tgdFt.get_Value(tgdFt.Fields.FindField(_fcName.FC_THUA_GIADAT.GIA_DAT)).ToString(), out giadat);
                        if (!result)
                        {
                            giadat = 0;
                        }
                        giadatTong += giadat;
                        result =int.TryParse(tgdFt.get_Value(tgdFt.Fields.FindField(_fcName.FC_THUA_GIADAT.MA_DUONG)).ToString(),out maduong);
                        if (!result)
                        {
                            maduong = 0;
                        }
                        //MessageBox.Show(string.Format("line 187 id= {0}, Sum: giadat={1}",id, giadatTong));
                    }
                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA.GetIndex(_fcName.FC_THUA.GIA_DAT), giadatTong } });
                    pairColValTgd.Add(new object[,] { { _fcName.FC_THUA.GetIndex(_fcName.FC_THUA.MA_DUONG), maduong } });
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA.MA_THUA, mathuaNew);
                    IFeatureCursor thuaCur = thuaFeatureClass.Search(qrf, false);
                    IFeature thuaFt = null;
                    try
                    {
                        if ((thuaFt = thuaCur.NextFeature()) != null)
                        {
                            object tid = thuaFt.OID;
                            //MessageBox.Show(string.Format("line 199 Sum: id={0}", tid));
                            //MessageBox.Show(string.Format("line 187 id= {0}, Sum: giadat={1}", tid, giadatTong));
                            sdeTblThuaEditor.CacheData(tid, 0, pairColValTgd, EnumTypeOfEdit.UPDATE);
                            pairColValTgd.Clear();
                        }
                    }
                    catch (Exception ex) { continue; }
                    finally { Marshal.ReleaseComObject(thuaCur); }

                    
                }
                catch (Exception ex)
                {
                    continue;
                }
                finally
                {
                    Marshal.ReleaseComObject(tgdCur);
                }

                
                #endregion
            }
            if (!sdeTblThuaEditor.IsEditing())
            {
                sdeTblThuaEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblThuaEditor.StartEditOperation();
            }
            else
            {
                try
                {
                    sdeTblThuaEditor.SaveEdit();
                    sdeTblThuaEditor.StopEditOperation();
                    sdeTblThuaEditor.StopEditing(true);
                }
                catch
                {
                    sdeTblThuaEditor.StopEditOperation();
                    sdeTblThuaEditor.StopEditing(false);
                }
                sdeTblThuaEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                sdeTblThuaEditor.StartEditOperation();
            }
            try
            {
                sdeTblThuaEditor.SaveEdit();
                sdeTblThuaEditor.StopEditOperation();
                sdeTblThuaEditor.StopEditing(true);
            }
            catch (Exception ex)
            {
                sdeTblThuaEditor.StopEditOperation();
                sdeTblThuaEditor.StopEditing(false);
            }
            #endregion

        }
    }
}