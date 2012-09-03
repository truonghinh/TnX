using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;
using AMS.Profile;
using gov.tn.system;
using System.Windows.Forms;
using com.g1.arcgis.connection;
using ESRI.ArcGIS.Geodatabase;
using gov.tn.TnDatabaseStructure;
using System.Runtime.InteropServices;

namespace com.g1.arcgis.tn.config
{
    public class ConfigReader:IConfigReader
    {
        private ICurrentConfig _config;

        public ConfigReader(ICurrentConfig config)
        {
            this._config = config;
        }
        #region IConfigReader Members

        void IConfigReader.Read(string fileName,string nam)
        {
            //SdeConnection conn = new SdeConnection();
            //ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
            //if (sdeConn == null || sdeConn.Workspace==null)
            //{
            //    return;
            //}
            //IFeatureWorkspace fw = (IFeatureWorkspace)sdeConn.Workspace;
            //ITnTableName _tblName = new TnTableName(sdeConn.Workspace);
            //string paramTableName = DataNameTemplate.Thong_So + "_" + nam;
            //ITable paramTable = fw.OpenTable(paramTableName);
            //IQueryFilter q = new QueryFilterClass();
            //q.WhereClause = "";
            //ICursor parCursor = paramTable.Search(q, false);
            //IRow parRow = null;
            //try
            //{
            //    while ((parRow = parCursor.NextRow()) != null)
            //    {
            //        string parName = parRow.get_Value(parRow.Fields.FindField(_tblName.THONG_SO.TEN_THONG_SO)).ToString();
            //        object parVal = parRow.get_Value(parRow.Fields.FindField(_tblName.THONG_SO.GIA_TRI));
            //        _config.SetValue(parName, parVal);
            //    }
            //}
            //catch (Exception) { }
            //finally
            //{
            //    Marshal.ReleaseComObject(parCursor);
            //}

            Xml fileConfig = new Xml(fileName);
            string year = nam;//DateTime.Today.Year.ToString();
            this._config.NamApDung = year;
            using (fileConfig.Buffer(true))
            {
                this._config.ChoPhepApGia = fileConfig.GetValue(year, TnConfig.Param.ChoPhepApGia, 0);
                this._config.BTinhThuaDoiDien = fileConfig.GetValue(year, TnConfig.Param.BTinhThuaDoiDien, 1);
                this._config.DBKUbnd_truong_cho_tramyt = fileConfig.GetValue(year, TnConfig.Param.DBKUbnd_truong_cho_tramyt, 0);
                this._config.DCachDmgt_chodm = fileConfig.GetValue(year, TnConfig.Param.DCachDmgt_chodm, 0.1);
                this._config.DCachRgTmdv_dl_cn_cx_ktck = fileConfig.GetValue(year, TnConfig.Param.DCachRgTmdv_dl_cn_cx_ktck, 0.1);
                this._config.DGrDatNn = fileConfig.GetValue(year, TnConfig.Param.DGrDatNn, 0.1);
                this._config.DGrDatPnnDt = fileConfig.GetValue(year, TnConfig.Param.DGrDatPnnDt, 0.1);
                this._config.DGrDatPnnNt = fileConfig.GetValue(year, TnConfig.Param.DGrDatPnnNt, 0.1);
                this._config.DKhoangCach50mMatTien = fileConfig.GetValue(year, TnConfig.Param.DKhoangCach50mMatTien, 0.1);
                this._config.DRongDuongVitri1Nn = fileConfig.GetValue(year, TnConfig.Param.DRongDuongVitri1Nn, 0.1);
                this._config.DRongDuongVitri2NnMax = fileConfig.GetValue(year, TnConfig.Param.DRongDuongVitri2Nn, 0.1);
                this._config.DSauDuongVitri1Nn = fileConfig.GetValue(year, TnConfig.Param.DSauDuongVitri1Nn, 0.1);
                this._config.DSauDuongVitri2Nn = fileConfig.GetValue(year, TnConfig.Param.DSauDuongVitri2Nn, 0.1);
                this._config.DSauDuongVitri2Nn2 = fileConfig.GetValue(year, TnConfig.Param.DSauDuongVitri2Nn2, 0.1);
                this._config.DVt2Kv1 = fileConfig.GetValue(year, TnConfig.Param.DVt2Kv1, 0);
                this._config.GToiThieuDoThiLoai4 = fileConfig.GetValue(year, TnConfig.Param.GToiThieuDoThiLoai4, 0.1);
                this._config.GToiThieuDoThiLoai5 = fileConfig.GetValue(year, TnConfig.Param.GToiThieuDoThiLoai5, 0.1);
                this._config.K2MatTien = fileConfig.GetValue(year, TnConfig.Param.K2MatTien, 0.1);
                this._config.K3MatTien = fileConfig.GetValue(year, TnConfig.Param.K3MatTien, 0.1);
                this._config.K4MatTien = fileConfig.GetValue(year, TnConfig.Param.K4MatTien, 0.1);

                this._config.PDatSau50mMatTien = fileConfig.GetValue(year, TnConfig.Param.PDatSau50mMatTien, 0.1);
                this._config.PHemChinhRongDuoi3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemChinhRongDuoi3_5m, 0.1);
                this._config.PHemChinhRongTren3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemChinhRongTren3_5m, 0.1);
                this._config.PHemChinhRongTren6m = fileConfig.GetValue(year, TnConfig.Param.PHemChinhRongTren6m, 0.1);
                this._config.PHemPhuRongDuoi3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemPhuRongDuoi3_5m, 0.1);
                this._config.PHemPhuRongTren3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemPhuRongTren3_5m, 0.1);
                this._config.PHemPhuRongTren6m = fileConfig.GetValue(year, TnConfig.Param.PHemPhuRongTren6m, 0.1);
                this._config.PHemSauDuoi100m = fileConfig.GetValue(year, TnConfig.Param.PHemSauDuoi100m, 0.1);
                this._config.PHemSauDuoi200m = fileConfig.GetValue(year, TnConfig.Param.PHemSauDuoi200m, 0.1);
                this._config.PHemSauTren200m = fileConfig.GetValue(year, TnConfig.Param.PHemSauTren200m, 0.1);
                this._config.PPnnNtDuoi100m = fileConfig.GetValue(year, TnConfig.Param.PPnnNtDuoi100m, 0.1);
                this._config.PPnnNtTren100m = fileConfig.GetValue(year, TnConfig.Param.PPnnNtTren100m, 0.1);
            }
            //MessageBox.Show(string.Format("line 64-configreader:{0}",this._config.DGrDatNn));
        }

        void IConfigReader.WriteOut(string fileName,string nam)
        {
            Xml xml;
            xml = new Xml(TnSystemFileName.PARAMS);
            string year = nam;//DateTime.Today.Year.ToString();
            using (xml.Buffer(true))
            {
                xml.RootName = "params";
                xml.SetValue(year, TnConfig.Param.ChoPhepApGia, _config.ChoPhepApGia);
                //--pnndt--
                xml.SetValue(year, TnConfig.Param.K2MatTien, _config.K2MatTien);
                xml.SetValue(year, TnConfig.Param.K3MatTien, _config.K3MatTien);
                xml.SetValue(year, TnConfig.Param.K4MatTien, _config.K4MatTien);
                xml.SetValue(year, TnConfig.Param.GToiThieuDoThiLoai4, _config.GToiThieuDoThiLoai4);
                xml.SetValue(year, TnConfig.Param.GToiThieuDoThiLoai5, _config.GToiThieuDoThiLoai5);
                xml.SetValue(year, TnConfig.Param.PDatSau50mMatTien, _config.PDatSau50mMatTien);
                xml.SetValue(year, TnConfig.Param.PHemChinhRongDuoi3_5m, _config.PHemChinhRongDuoi3_5m);
                xml.SetValue(year, TnConfig.Param.PHemChinhRongTren3_5m, _config.PHemChinhRongTren3_5m);
                xml.SetValue(year, TnConfig.Param.PHemChinhRongTren6m, _config.PHemChinhRongTren6m);
                xml.SetValue(year, TnConfig.Param.PHemPhuRongDuoi3_5m, _config.PHemPhuRongDuoi3_5m);
                xml.SetValue(year, TnConfig.Param.PHemPhuRongTren3_5m, _config.PHemPhuRongTren3_5m);
                xml.SetValue(year, TnConfig.Param.PHemPhuRongTren6m, _config.PHemPhuRongTren6m);
                xml.SetValue(year, TnConfig.Param.PHemSauDuoi100m, _config.PHemSauDuoi100m);
                xml.SetValue(year, TnConfig.Param.PHemSauDuoi200m, _config.PHemSauDuoi200m);
                xml.SetValue(year, TnConfig.Param.PHemSauTren200m, _config.PHemSauTren200m);
                xml.SetValue(year, TnConfig.Param.DKhoangCach50mMatTien, _config.DKhoangCach50mMatTien);
                xml.SetValue(year, TnConfig.Param.DBufferMathem, _config.DBufferMathem);
                xml.SetValue(year, TnConfig.Param.DBufferMattien, _config.DBufferMattien);
                //--pnnnt--
                xml.SetValue(year, TnConfig.Param.PPnnNtDuoi100m, _config.PPnnNtDuoi100m);
                xml.SetValue(year, TnConfig.Param.PPnnNtTren100m, _config.PPnnNtTren100m);
                xml.SetValue(year, TnConfig.Param.DVt2Kv1, _config.DVt2Kv1);
                xml.SetValue(year, TnConfig.Param.DCachRgTmdv_dl_cn_cx_ktck, _config.DCachRgTmdv_dl_cn_cx_ktck);
                xml.SetValue(year, TnConfig.Param.DCachDmgt_chodm, _config.DCachDmgt_chodm);
                xml.SetValue(year, TnConfig.Param.DBKUbnd_truong_cho_tramyt, _config.DBKUbnd_truong_cho_tramyt);
                xml.SetValue(year, TnConfig.Param.BTinhThuaDoiDien, _config.BTinhThuaDoiDien);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongPnntVt1, _config.DBufferMepDuongPnntVt1);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongPnntVt2, _config.DBufferMepDuongPnntVt2);
                xml.SetValue(year, TnConfig.Param.DBkTimKdcttKv2, _config.DBkTimKdcttKv2);
                xml.SetValue(year, TnConfig.Param.DBkTimKdcttKv3, _config.DBkTimKdcttKv3);
                //--nong nghiep
                xml.SetValue(year, TnConfig.Param.DRongDuongVitri1Nn, _config.DRongDuongVitri1Nn);
                xml.SetValue(year, TnConfig.Param.DRongDuongVitri2Nn, _config.DRongDuongVitri2NnMax);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri1Nn, _config.DSauDuongVitri1Nn);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri2Nn, _config.DSauDuongVitri2Nn);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri2Nn2, _config.DSauDuongVitri2Nn2);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongNnVt1, _config.DBufferMepDuongNnVt1);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongNnVt2, _config.DBufferMepDuongNnVt2);

                //--giapranh--
                xml.SetValue(year, TnConfig.Param.DGrDatNn, _config.DGrDatNn);
                xml.SetValue(year, TnConfig.Param.DGrDatPnnDt, _config.DGrDatPnnDt);
                xml.SetValue(year, TnConfig.Param.DGrDatPnnNt, _config.DGrDatPnnNt);
            }
            //MessageBox.Show()
        }

        void IConfigReader.CreateDefaultConfig()
        {
            if (System.IO.File.Exists(TnSystemFileName.PARAMS))
            {
                return;
            }
            Xml xml;
            xml = new Xml(TnSystemFileName.PARAMS);
            string year = DateTime.Today.Year.ToString();
            using (xml.Buffer(true))
            {
                xml.RootName = "params";
                xml.SetValue(year, TnConfig.Param.ChoPhepApGia, 1);
                //--pnndt--
                xml.SetValue(year, TnConfig.Param.K2MatTien, 1.2);
                xml.SetValue(year, TnConfig.Param.K3MatTien, 1.3);
                xml.SetValue(year, TnConfig.Param.K4MatTien, 1.4);
                xml.SetValue(year, TnConfig.Param.GToiThieuDoThiLoai4, 100000);
                xml.SetValue(year, TnConfig.Param.GToiThieuDoThiLoai5, 80000);
                xml.SetValue(year, TnConfig.Param.PDatSau50mMatTien, 0.3);
                xml.SetValue(year, TnConfig.Param.PHemChinhRongDuoi3_5m, 0.2);
                xml.SetValue(year, TnConfig.Param.PHemChinhRongTren3_5m, 0.3);
                xml.SetValue(year, TnConfig.Param.PHemChinhRongTren6m, 0.4);
                xml.SetValue(year, TnConfig.Param.PHemPhuRongDuoi3_5m, 0.4);
                xml.SetValue(year, TnConfig.Param.PHemPhuRongTren3_5m, 0.6);
                xml.SetValue(year, TnConfig.Param.PHemPhuRongTren6m, 0.7);
                xml.SetValue(year, TnConfig.Param.PHemSauDuoi100m, 1);
                xml.SetValue(year, TnConfig.Param.PHemSauDuoi200m, 0.8);
                xml.SetValue(year, TnConfig.Param.PHemSauTren200m, 0.6);
                xml.SetValue(year, TnConfig.Param.DKhoangCach50mMatTien, 50);
                xml.SetValue(year, TnConfig.Param.DBufferMathem, 1);
                xml.SetValue(year, TnConfig.Param.DBufferMattien, 1);

                //--pnnnt--
                xml.SetValue(year, TnConfig.Param.PPnnNtDuoi100m, 1);
                xml.SetValue(year, TnConfig.Param.PPnnNtTren100m, 0.5);
                xml.SetValue(year, TnConfig.Param.DVt2Kv1, 1000);
                xml.SetValue(year, TnConfig.Param.DCachRgTmdv_dl_cn_cx_ktck, 500);
                xml.SetValue(year, TnConfig.Param.DCachDmgt_chodm, 500);
                xml.SetValue(year, TnConfig.Param.DBKUbnd_truong_cho_tramyt, 500);
                xml.SetValue(year, TnConfig.Param.BTinhThuaDoiDien, 1);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongPnntVt1,1);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongPnntVt2, 1);
                xml.SetValue(year, TnConfig.Param.DBkTimKdcttKv2, 100);
                xml.SetValue(year, TnConfig.Param.DBkTimKdcttKv3, 100);
                //--nong nghiep
                xml.SetValue(year, TnConfig.Param.DRongDuongVitri1Nn, 9);
                xml.SetValue(year, TnConfig.Param.DRongDuongVitri2Nn, 9);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri1Nn, 100);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri2Nn, 100);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri2Nn2, 200);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongNnVt1, 1);
                xml.SetValue(year, TnConfig.Param.DBufferMepDuongNnVt2, 1);

                //--giapranh--
                xml.SetValue(year, TnConfig.Param.DGrDatNn, 300);
                xml.SetValue(year, TnConfig.Param.DGrDatPnnDt, 100);
                xml.SetValue(year, TnConfig.Param.DGrDatPnnNt, 200);
            }
        }

        #endregion
    }
}
