using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using com.g1.arcgis.calculation;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using com.g1.arcgis.database;
using com.g1.arcgis.tn.config;
using System.Runtime.InteropServices;
using com.g1.arcgis.tn.calculation.calculator;
using com.g1.arcgis.algorithm;

namespace com.g1.arcgis.tn.calculation
{
    public partial class FrmSetPositionParam : DevExpress.XtraEditors.XtraForm,IEditPositionParamsView,ICallerHskView
    {
        private static FrmSetPositionParam _meForm = new FrmSetPositionParam();
        private static bool isShown = false;
        //private object _mathua;
        private List<object> _lstMaThua;
        private List<IFeature> _lstThuaFt;
        private ICalcMethodBuilderView _calcMethodBuilder;
        private FrmSetPositionParam()
        {
            InitializeComponent();
        }

        #region singleton
        public static FrmSetPositionParam CallMe
        {
            get {
                if (_meForm == null)
                {
                    _meForm = new FrmSetPositionParam();
                }
                return _meForm; }
        }
        static FrmSetPositionParam()
        {
            _meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            _meForm.Hide();
        }

        public new void ShowDialog()
        {
            if (isShown)
            {
                base.ShowDialog();
            }
            else
            {
                isShown = true;
                base.ShowDialog();
            }
        }

        public new void Show()
        {
            if (isShown)
            {
                base.Show();
            }
            else
            {
                isShown = true;
                base.Show();
            }
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region IEditPositionParamsView Members

        void IEditPositionParamsView.Show()
        {
            this.Show();
            
        }

        void IEditPositionParamsView.Close()
        {
            this.Close();
        }

        List<object> IEditPositionParamsView.MaThua
        {
            get
            {
                return _lstMaThua;
            }
            set
            {
                _lstMaThua = value;
                foreach (object o in _lstMaThua)
                {
                    lbxMaThua.Items.Add(o);
                }
                //lbxMaThua.Items.AddRange()
                //txtMathua.Text = _mathua.ToString();
            }
        }

        #endregion

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            bool removeOldPos = true;
            if (chkRemoveOldPos.CheckState == CheckState.Unchecked)
            {
                removeOldPos = false;
            }
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IWorkspaceEdit wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            ITnFeatureClassName _fcName = new TnFeatureClassName(sdeConn.Workspace);
            ITnTableName _tblName = new TnTableName(sdeConn.Workspace);
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            ICopyFeatures copyTool = new DataManager(sdeConn.Workspace, sdeConn.Environment);
            IQueryFilter qrf = new QueryFilterClass();
            IFeatureClass tgdFeatureClass = null;
            ICurrentConfig config = CurrentConfig.CallMe();
            List<object[,]> pairColValTgd = new List<object[,]>();
            int rowTgdNnHandleUpdate = 0;
            List<object> newId = new List<object>();
            string tgdDraft = string.Format("{0}_{1}", DataNameTemplate.Thua_Gia_Dat_Draft, config.NamApDung);
            _fcName.FC_THUA_GIADAT_DRAFT.NAME = tgdDraft;
            _fcName.FC_THUA_GIADAT_DRAFT.InitIndex();
            try
            {
                tgdFeatureClass = fw.OpenFeatureClass(tgdDraft);
            }
            catch (Exception exc)
            {
                //evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", tgdDraft);
                //onCalculating(evt);
                //onFinished(evt);
                return;
            }
            ITable tblThuaGiaDat = (ITable)tgdFeatureClass;
            ISDETableEditor sdeTblTgdEditor = new SDETable(tblThuaGiaDat, sdeConn.Workspace);

            //lay thong tin thua
            for (int i=0;i< _lstThuaFt.Count;i++)
            {
                IFeature thuaFt = _lstThuaFt[i];

                //string lockTimVitri = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.LOCKED)).ToString();
                object dientichpl = thuaFt.get_Value(thuaFt.Fields.FindField(_fcName.FC_THUA.DIEN_TICH));

                object mathua = _lstMaThua[i];//txtMathua.Text;
                string maduong = txtMaDuong.Text;
                string mahem = txtMaHem.Text;
                
                if (maduong == "" || maduong ==null)
                {
                    maduong = "0";
                }
                if (mahem == "" || mahem == null)
                {
                    mahem = "0";
                }
                string hesoVitri = txtHsk.Text;
                ICursor tgdFcs1;
                IRow tgdRow = null;
                if (removeOldPos)
                {
                    qrf.WhereClause = string.Format("{0}='{1}'", _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua);
                    tgdFcs1=tblThuaGiaDat.Search(qrf, false);
                    try
                    {
                        while ((tgdRow = tgdFcs1.NextRow()) != null)
                        {
                            #region xoa feature cu
                            mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                            wspEdit.StartEditOperation();
                            //qrf.WhereClause = string.Format("{0}='{1}'", "OBJECTID", tgdRow.OID);
                            //tblThuaGiaDat.DeleteSearchedRows(qrf);
                            tgdRow.Delete();
                            wspEdit.StopEditOperation();
                            wspEdit.StopEditing(true);
                            #endregion
                        }
                    }
                    catch { }
                    finally { Marshal.ReleaseComObject(tgdFcs1); }
                }
                
                if (mahem == "0")
                {
                    qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}' and {7}='{8}'",
                                    _fcName.FC_THUA_GIADAT_DRAFT.LOCKED, 0, _fcName.FC_THUA_GIADAT_DRAFT.LOCKED,
                                    _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua,
                                    _fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG, maduong,
                                    _fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K, hesoVitri);
                }
                else if (mahem != "0")
                {
                    qrf.WhereClause = string.Format("({0}='{1}' or {2} is null) and {3}='{4}' and {5}='{6}' and {7}='{8}'",
                                    _fcName.FC_THUA_GIADAT_DRAFT.LOCKED, 0, _fcName.FC_THUA_GIADAT_DRAFT.LOCKED,
                                    _fcName.FC_THUA_GIADAT_DRAFT.MA_THUA, mathua,
                                    _fcName.FC_THUA_GIADAT_DRAFT.MA_HEM, mahem,
                                    _fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K, hesoVitri);
                }
                //MessageBox.Show("line 157 FrmSet.., ",+ qrf.WhereClause);
                ICursor tgdFcs = tblThuaGiaDat.Search(qrf, false);
                
                try
                {
                    tgdRow = tgdFcs.NextRow();//dam bao la chi co 1 hang ket qua   
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
                            mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
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
                            mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                            wspEdit.StartEditOperation();
                            object copiedId = copyTool.Copy(thuaFt, tgdFeatureClass);
                            wspEdit.StopEditOperation();
                            wspEdit.StopEditing(true);

                            //them gia tri mathua,maduong,hesovitri
                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.MA_HEM), mahem } });
                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                            pairColValTgd.Add(new object[,] { { tgdRow.Fields.FindField(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
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
                        //MessageBox.Show("line 220 FrmSet.., " + thuaFt.ToString());
                        //[thaydoi] - them cac gia tri thich hop vao thua_giadat
                        //***********************************
                        #region them feature moi
                        mwspEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                        wspEdit.StartEditOperation();
                        object copiedId = copyTool.Copy(thuaFt, tgdFeatureClass);
                        //MessageBox.Show("line 220 FrmSet.., copiedid" + copiedId.ToString());
                        wspEdit.StopEditOperation();
                        wspEdit.StopEditing(true);

                        //them gia tri mathua,maduong,hesovitri
                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), mathua } });
                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), maduong } });
                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_HEM), mahem } });
                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), hesoVitri } });
                        pairColValTgd.Add(new object[,] { { _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY), dientichpl } });
                        //MessageBox.Show(string.Format("line 248 FrmSet.., mathua={0},maduong={1},hsk={2}, dientich={3}" , mathua,maduong,hesoVitri,dientichpl));
                        //MessageBox.Show(string.Format("line 249 FrmSet..,index mathua={0},maduong={1},hsk={2}, dientich={3}" , _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_THUA), _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.MA_DUONG), _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.HE_SO_K), _fcName.FC_THUA_GIADAT_DRAFT.GetIndex(_fcName.FC_THUA_GIADAT_DRAFT.DIEN_TICH_PHAP_LY)));
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
            }
            #region luu thong tin vao bang gia dat
            //MessageBox.Show("line 250 FrmSet..., "+wspEdit.IsBeingEdited().ToString());
            if (!sdeTblTgdEditor.IsEditing())
            {
                sdeTblTgdEditor.StartEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
                //MessageBox.Show("line 250 FrmSet..., " + wspEdit.IsBeingEdited().ToString());
                sdeTblTgdEditor.StartEditOperation();
            }
            try
            {
                sdeTblTgdEditor.SaveEdit();
                sdeTblTgdEditor.StopEditOperation();
                sdeTblTgdEditor.StopEditing(true);
            }
            catch 
            {
                sdeTblTgdEditor.AbortEditOperation();
                sdeTblTgdEditor.StopEditing(false);
            }

            #endregion

            #region tinh gia dat cho cac thua vua them vi tri
            CalcLandprice calc = new CalcLandprice();
            calc.Calculate(newId);
            newId.Clear();
            #endregion
            this.Close();
        }

        #region IEditPositionParamsView Members


        List<IFeature> IEditPositionParamsView.MyFeature
        {
            get
            {
                return _lstThuaFt;
            }
            set
            {
                _lstThuaFt = value;
            }
        }

        #endregion

        #region IEditPositionParamsView Members


        void IEditPositionParamsView.ClearMaThua()
        {
            lbxMaThua.Items.Clear();
        }

        #endregion

        private void btnHskBrowse_Click(object sender, EventArgs e)
        {
            if (_calcMethodBuilder == null)
            {
                return;
            }
            _calcMethodBuilder.SetCallerView(this);
            _calcMethodBuilder.SetVisibleBtnChonHesoK(true);
            _calcMethodBuilder.ShowDialog();
        }

        #region ICallerHskView Members

        void ICallerHskView.SetHsk(object hsk)
        {
            this.txtHsk.Text = hsk.ToString();
        }

        #endregion

        #region ICallerHskView Members


        void ICallerHskView.SetCalcMethodBuilderView(ICalcMethodBuilderView view)
        {
            _calcMethodBuilder = view;
        }

        #endregion
    }
}