using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TNPro.Check;
using AMS.Profile;
using TnUtilities;

using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.calculation;
using gov.tn.system;
using com.g1.arcgis.tn.config;

namespace TNPro.TnForms
{
    public partial class FrmTnLogin : DevExpress.XtraEditors.XtraForm
    {
        private static readonly FrmTnLogin meForm = new FrmTnLogin();
        private static bool isShown = false;
        private TnRoles roles;
        private ITnUtilitiesFile fileUtil;
        private FrmTnLogin()
        {
            InitializeComponent();
            roles = TnRoles.CallMe();
            fileUtil = new UtilitiesBox();
            bgwLoadUsers.RunWorkerAsync();
            bgwLoadParams.RunWorkerAsync();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //FrmTnMainRibbon frmMain = FrmTnMainRibbon.CallMe;
            
            //bgwLogin.RunWorkerAsync();


            meForm.Close();
            //frmMain.Show();
        }

        public static FrmTnLogin CallMe
        {
            get { return meForm; }
        }
        static FrmTnLogin()
        {
            meForm.FormClosing += new FormClosingEventHandler(meForm_FormClosing);
        }

        static void meForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            isShown = false;
            meForm.Hide();
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

        private void bgwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show(roles.ListUsers.Count.ToString());
            foreach (string s in roles.ListUsers)
            {
                //MessageBox.Show(s);
                if (textEdit1.Text == s)
                {
                    MessageBox.Show("ok");
                }
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bgwLoadUsers_DoWork(object sender, DoWorkEventArgs e)
        {
            //roles.LoadUsers(1);
            
        }

        private void bgwLoadUsers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("da load");
        }

        private void getParams()
        {
            ICurrentConfig conf = CurrentConfig.CallMe();
            Xml fileConfig = new Xml(TnSystemFileName.PARAMS);
            string year = "2011";//DateTime.Today.Year.ToString();
            using (fileConfig.Buffer(true))
            {
                conf.ChoPhepApGia = fileConfig.GetValue(year, TnConfig.Param.ChoPhepApGia, 0);
                conf.BTinhThuaDoiDien = fileConfig.GetValue(year, TnConfig.Param.BTinhThuaDoiDien, 1);
                conf.DBKUbnd_truong_cho_tramyt = fileConfig.GetValue(year, TnConfig.Param.DBKUbnd_truong_cho_tramyt, 0);
                conf.DCachDmgt_chodm = fileConfig.GetValue(year, TnConfig.Param.DCachDmgt_chodm, 0.1);
                conf.DCachRgTmdv_dl_cn_cx_ktck = fileConfig.GetValue(year, TnConfig.Param.DCachRgTmdv_dl_cn_cx_ktck, 0.1);
                conf.DGrDatNn = fileConfig.GetValue(year, TnConfig.Param.DGrDatNn, 0.1);
                conf.DGrDatPnnDt = fileConfig.GetValue(year, TnConfig.Param.DGrDatPnnDt, 0.1);
                conf.DGrDatPnnNt = fileConfig.GetValue(year, TnConfig.Param.DGrDatPnnNt, 0.1);
                conf.DKhoangCach50mMatTien = fileConfig.GetValue(year, TnConfig.Param.DKhoangCach50mMatTien, 0.1);
                conf.DRongDuongVitri1Nn = fileConfig.GetValue(year, TnConfig.Param.DRongDuongVitri1Nn, 0.1);
                conf.DRongDuongVitri2NnMax = fileConfig.GetValue(year, TnConfig.Param.DRongDuongVitri2Nn, 0.1);
                conf.DSauDuongVitri1Nn = fileConfig.GetValue(year, TnConfig.Param.DSauDuongVitri1Nn, 0.1);
                conf.DSauDuongVitri2Nn = fileConfig.GetValue(year, TnConfig.Param.DSauDuongVitri2Nn, 0.1);
                conf.DSauDuongVitri2Nn2 = fileConfig.GetValue(year, TnConfig.Param.DSauDuongVitri2Nn2, 0.1);
                conf.DVt2Kv1 = fileConfig.GetValue(year, TnConfig.Param.DVt2Kv1, 0);
                conf.GToiThieuDoThiLoai4 = fileConfig.GetValue(year, TnConfig.Param.GToiThieuDoThiLoai4, 0.1);
                conf.GToiThieuDoThiLoai5 = fileConfig.GetValue(year, TnConfig.Param.GToiThieuDoThiLoai5, 0.1);
                conf.K2MatTien = fileConfig.GetValue(year, TnConfig.Param.K2MatTien, 0.1);
                conf.K3MatTien = fileConfig.GetValue(year, TnConfig.Param.K3MatTien, 0.1);
                conf.K4MatTien = fileConfig.GetValue(year, TnConfig.Param.K4MatTien, 0.1);
                conf.NamApDung = fileConfig.GetValue(year, TnConfig.Param.NamApDung, "2011");
                conf.PDatSau50mMatTien = fileConfig.GetValue(year, TnConfig.Param.PDatSau50mMatTien, 0.1);
                conf.PHemChinhRongDuoi3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemChinhRongDuoi3_5m, 0.1);
                conf.PHemChinhRongTren3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemChinhRongTren3_5m, 0.1);
                conf.PHemChinhRongTren6m = fileConfig.GetValue(year, TnConfig.Param.PHemChinhRongTren6m, 0.1);
                conf.PHemPhuRongDuoi3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemPhuRongDuoi3_5m, 0.1);
                conf.PHemPhuRongTren3_5m = fileConfig.GetValue(year, TnConfig.Param.PHemPhuRongTren3_5m, 0.1);
                conf.PHemPhuRongTren6m = fileConfig.GetValue(year, TnConfig.Param.PHemPhuRongTren6m, 0.1);
                conf.PHemSauDuoi100m = fileConfig.GetValue(year, TnConfig.Param.PHemSauDuoi100m, 0.1);
                conf.PHemSauDuoi200m = fileConfig.GetValue(year, TnConfig.Param.PHemSauDuoi200m, 0.1);
                conf.PHemSauTren200m = fileConfig.GetValue(year, TnConfig.Param.PHemSauTren200m, 0.1);
                conf.PPnnNtDuoi100m = fileConfig.GetValue(year, TnConfig.Param.PPnnNtDuoi100m, 0.1);
                conf.PPnnNtTren100m = fileConfig.GetValue(year, TnConfig.Param.PPnnNtTren100m, 0.1);
            }
        }

        private void initParamsFile()
        {
            if (fileUtil.FileExist(TnSystemFileName.PARAMS))
            {

                return;
            }
            Xml xml;
            xml = new Xml(TnSystemFileName.PARAMS);
            string year = "2011";//DateTime.Today.Year.ToString();
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
                //--pnnnt--
                xml.SetValue(year, TnConfig.Param.PPnnNtDuoi100m, 1);
                xml.SetValue(year, TnConfig.Param.PPnnNtTren100m, 0.5);
                xml.SetValue(year, TnConfig.Param.DVt2Kv1, 1000);
                xml.SetValue(year, TnConfig.Param.DCachRgTmdv_dl_cn_cx_ktck, 500);
                xml.SetValue(year, TnConfig.Param.DCachDmgt_chodm, 500);
                xml.SetValue(year, TnConfig.Param.DBKUbnd_truong_cho_tramyt, 500);
                xml.SetValue(year, TnConfig.Param.BTinhThuaDoiDien, 1);
                //--nong nghiep
                xml.SetValue(year, TnConfig.Param.DRongDuongVitri1Nn, 9);
                xml.SetValue(year, TnConfig.Param.DRongDuongVitri2Nn, 9);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri1Nn, 100);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri2Nn, 100);
                xml.SetValue(year, TnConfig.Param.DSauDuongVitri2Nn2, 200);

                //--giapranh--
                xml.SetValue(year, TnConfig.Param.DGrDatNn, 300);
                xml.SetValue(year, TnConfig.Param.DGrDatPnnDt, 100);
                xml.SetValue(year, TnConfig.Param.DGrDatPnnNt, 200);
            }
        }

        private void iniConfigFile()
        {
            Config p = new Config();
            

            if (fileUtil.FileExist(TnSystemFileName.Config))
            {
                return;
            }
            p = new Config(TnSystemFileName.Config);
            
            

            using (p.Buffer(true))
            {
                //ghi thong tin phan mem

                p.SetValue(TnConfig.Product.Name, TnConfig.Product.Developer, "tn");
                TnSecParamForCalc a = TnSecParamForCalc.CallMe();
                //thong tin sde
                p.SetValue(TnConfig.Sde.Name, TnConfig.Sde.ServiceName, "esri_sde");

                //ghi list cac lop du lieu su dung
                //"thua", "thixa_thua" }, { "duong", "thixa_duong" }, { "hem", "thixa_hem" }, { "duong_buffer_1m", "thixa_duong_buffer_1m" }, { "duong_buffer_50m", "thixa_duong_buffer_50m" }, { "duong_buffer_100m", "thixa_duong_buffer_100m" }, { "duong_buffer_200m", "thixa_duong_buffer_200m" }, { "hem_buffer_1m", "thixa_hem_buffer_1m" }, { "hem_layer_buffer_1m", "thixa_hem_layer_buffer_1m" }, { "hem_buffer_1m_crt_frm_layer", "thixa_hem_buffer_1m_selected" } };
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Thua, "thixa_thua");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Duong, "thixa_duong");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Hem, "thixa_hem");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Duong_buffer_1m, "thixa_duong_buffer_1m");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Duong_buffer_50m, "thixa_duong_buffer_50m");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Duong_buffer_100m, "thixa_duong_buffer_100m");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Duong_buffer_200m, "thixa_duong_buffer_200m");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Hem_buffer_1m, "thixa_hem_buffer_1m");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Hem_layer_buffer_1m, "thixa_hem_layer_buffer_1m");
                p.SetValue(TnConfig.Layers.Name, TnConfig.Layers.Hem_buffer_1m_crt_frm_layer, "thixa_hem_buffer_1m_selected");

                /*
                //ghi các tham số quy định tính giá đất

                //Nam ap dung
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.NamApDung, 2011);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.ChoPhepApGia, 1);
                //--pnndt--
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.K2MatTien, 1.2);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.K3MatTien, 1.3);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.K4MatTien, 1.4);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.GToiThieuDoThiLoai4, 100000);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.GToiThieuDoThiLoai5, 80000);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PDatSau50mMatTien, 0.3);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemChinhRongDuoi3_5m, 0.2);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemChinhRongTren3_5m, 0.3);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemChinhRongTren6m, 0.4);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemPhuRongDuoi3_5m, 0.4);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemPhuRongTren3_5m, 0.6);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemPhuRongTren6m, 0.7);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemSauDuoi100m, 1);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemSauDuoi200m, 0.8);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PHemSauTren200m, 0.6);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DKhoangCach50mMatTien, 50);
                //--pnnnt--
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PPnnNtDuoi100m, 1);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.PPnnNtTren100m, 0.5);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DVt2Kv1, 1000);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DCachRgTmdv_dl_cn_cx_ktck, 500);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DCachDmgt_chodm, 500);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DBKUbnd_truong_cho_tramyt, 500);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.BTinhThuaDoiDien, 1);
                //--nong nghiep
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DRongDuongVitri1Nn, 9);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DRongDuongVitri2Nn, 9);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DSauDuongVitri1Nn, 100);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DSauDuongVitri2Nn, 100);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DSauDuongVitri2Nn2, 200);

                //--giapranh--
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DGrDatNn, 300);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DGrDatPnnDt, 100);
                p.SetValue(TnConfig.Param.Name, TnConfig.Param.DGrDatPnnNt, 200);
                 * */
            }
        }

        private void bgwLoadParams_DoWork(object sender, DoWorkEventArgs e)
        {
            initParamsFile();
            iniConfigFile();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
            Application.Exit();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //FrmTnAlgorithm f = new FrmTnAlgorithm();
            //f.Show();
        }
        
    }
}