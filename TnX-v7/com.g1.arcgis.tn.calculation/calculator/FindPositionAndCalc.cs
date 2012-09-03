using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using gov.tn.TnDatabaseStructure;
using ESRI.ArcGIS.Geodatabase;
using com.g1.arcgis.tn.config;
using com.g1.arcgis.tn.calculation.evaluate;
using com.g1.arcgis.connection;
using gov.tn.system;
using System.Runtime.InteropServices;

namespace com.g1.arcgis.tn.calculation.calculator
{
    public class FindPositionAndCalc
    {
        private ICurrentConfig _currentConfig;
        private Calculator _caller;
        private ITnFeatureClassName _fcName;
        private ITnTableName _tblName;
        private IWorkspaceEdit _wspEdit;
        private IMultiuserWorkspaceEdit _mwspEdit;
        private CalculationMethodBuilder _methodBuilder;
        #region construction
        public FindPositionAndCalc(Calculator caller)
        {
            _caller = caller;
            _currentConfig = CurrentConfig.CallMe();
            _methodBuilder = new CalculationMethodBuilder();
            _methodBuilder.Config = _currentConfig;
        }
        #endregion
        public void Find(List<object> mathua,object maduong)
        {
            #region khai bao ban dau
            CalculationEventArg evt = new CalculationEventArg();
            SdeConnection conn = new SdeConnection();
            ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            IWorkspaceEdit wspEdit = (IWorkspaceEdit)sdeConn.Workspace;
            IMultiuserWorkspaceEdit mwspEdit = (IMultiuserWorkspaceEdit)sdeConn.Workspace;
            this._fcName = new TnFeatureClassName(sdeConn.Workspace);
            this._tblName = new TnTableName(sdeConn.Workspace);
            IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            #endregion

            #region mo bang he so vi tri
            ITable tblHesoVitri;
            try
            {
                tblHesoVitri = fw.OpenTable(DataNameTemplate.He_So_K);
            }
            catch (Exception exc)
            {
                evt.Log = string.Format("Không tìm thấy lớp dữ liệu: {0}", DataNameTemplate.He_So_K);
                _caller.onCalculating(evt);
                _caller.onFinished(evt);
                return;
            }
            #endregion

            #region xet loai dat
                
            #endregion

            #region lay cac quy tac tim vi tri
            IQueryFilter qrf = new QueryFilterClass();
            #region log---
            
            evt.Log = string.Format("\n----Lấy các quy tắc tìm vị trí thửa từ bảng {0}, ứng với hệ số {1} ...", DataNameTemplate.He_So_K, TnHeSoK.DatOMtTtDt);
            _caller.onCalculating(evt);
            #endregion
            //MessageBox.Show(String.Format("line 189 CalcThuaMattien, hsk={0}",TnHeSoK.DatOMtTtDt));
            qrf.WhereClause = string.Format("{0}='{1}'", "hesovitri", TnHeSoK.DatOMtTtDt);
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
                    //MessageBox.Show(string.Format("line 198 CalcMatTien, quytac={0}", quytac));
                }
            }
            catch { }
            finally
            {
                Marshal.ReleaseComObject(cur);
            }
            #endregion
        }
    }
}
