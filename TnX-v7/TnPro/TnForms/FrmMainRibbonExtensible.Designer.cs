using com.g1.arcgis.tn.calculation;
using com.g1.arcgis.calculation;
using com.g1.arcgis.tn.landprice;
using com.g1.arcgis.tn.query;
namespace TNPro.TnForms
{
    partial class FrmMainRibbonExtensible
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainRibbonExtensible));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.mmnBtnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.bbiInstallPlugin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRemovePlugin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoaiXa = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoaiDat = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKtvhxh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewMap = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpenMap = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseMap = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSaveMap = new DevExpress.XtraBars.BarSubItem();
            this.bbiSaveMap = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAsMap = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddLayer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSpan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFullExtent = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBackward = new DevExpress.XtraBars.BarButtonItem();
            this.bbiForward = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSelect = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClearSelected = new DevExpress.XtraBars.BarButtonItem();
            this.bbiZoomToSelected = new DevExpress.XtraBars.BarButtonItem();
            this.bbiScale = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bbiMapW = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLayersW = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAttributeW = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTinhHet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuaChon = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuaPnn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuaPnnDt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuaPnnNt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThuaNongNghiep = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXemGiaDat = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTimThuaBaseInfo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTimThuaTheoDuong = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAdmin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangePass = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConnectToDb = new DevExpress.XtraBars.BarButtonItem();
            this.beiChoPhepApGia = new DevExpress.XtraBars.BarEditItem();
            this.chkChoPhepApGia = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.beiApGiaCaoNhat = new DevExpress.XtraBars.BarEditItem();
            this.chkApGiaCaoNhat = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.beiK2MatTien = new DevExpress.XtraBars.BarEditItem();
            this.spnK2MatTien = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beiK3MatTien = new DevExpress.XtraBars.BarEditItem();
            this.spnK3MatTien = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beiK4MatTien = new DevExpress.XtraBars.BarEditItem();
            this.spnK4MatTien = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beiNamApDung = new DevExpress.XtraBars.BarEditItem();
            this.txtNamApDung = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bbiMoQuyDinh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLuuBangQD = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLuuBanSaoQd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQdTinhGiaDatNn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQdTinhGiaDatPnnNt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQdTinhGiaDatPnnDt = new DevExpress.XtraBars.BarButtonItem();
            this.beiGrDatNn = new DevExpress.XtraBars.BarEditItem();
            this.spnGrDatNn = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beiGrDatPnnNt = new DevExpress.XtraBars.BarEditItem();
            this.spnGrDatPnnNt = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beiGrDatPnnDt = new DevExpress.XtraBars.BarEditItem();
            this.spnGrDatPnnDt = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBanDoGiaDat = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAlgorithm = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGiaDatNn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGiaDatPnnNt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGiaDatPnnDt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditParams = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSplitLandPrice = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.txtStNam = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.bbiHesoVitri = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTinhGia = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenLandpriceTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenDuongTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenHemTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenXaPlTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenXaLiTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenThuaTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenTenDuongTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenKtvhxhTable = new DevExpress.XtraBars.BarButtonItem();
            this.bbiImportFromXml = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRegisterVersioned = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeletFeatureClass = new DevExpress.XtraBars.BarButtonItem();
            this.btnBangGiaTinh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAllParams = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTinhGiaHem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelectByLocation = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiaDatHemChinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnGiaDatHemPhu = new DevExpress.XtraBars.BarButtonItem();
            this.rbnHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgQuanLyNguoiDung = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbgCsdl = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnQuyDinhTinhGia = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgQuyDinhChung = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgThuaPnnNhieuMt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgQdDatGiapRanh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgQdTungLoaiDat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnBanDo = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgMapCommon = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTuongTacBanDo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgHienThi = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnCongCu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTimKiem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTinhGiaDat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpExtension = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgExtCommon = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgExtPlugins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnTroGiup = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpnTimKiemTheoThua2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer9 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gQueryInfoThuaView1 = new com.g1.arcgis.tn.query.GQueryInfoThuaView();
            this.dpnAttributeTable = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpnDangTinhGiaTatCa = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gCalculatingView1 = new com.g1.arcgis.tn.calculation.GCalculatingView();
            this.dpnTimKiemTheoDuong = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer5 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpnTinhGiaDatTatCa = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gCalculationView1 = new com.g1.arcgis.tn.calculation.GCalculationView();
            this.dpnTimDuong = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer6 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpnTinhGiaDatTungLoai = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer8 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dpnTinhGiaHemChinh = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer3 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gCalculationHemView1 = new com.g1.arcgis.tn.calculation.GCalculationHemView();
            this.dpnMap4Thua = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer4 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gMapView1 = new com.g1.arcgis.tn.map.GMapView();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gLayersView1 = new com.g1.arcgis.tn.map.GLayersView();
            this.controlContainer7 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnHelpFrmAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnTinhFrmAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloseFrmTinhAll = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChoPhepApGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApGiaCaoNhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnK2MatTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnK3MatTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnK4MatTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamApDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGrDatNn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGrDatPnnNt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGrDatPnnDt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dpnTimKiemTheoThua2.SuspendLayout();
            this.controlContainer9.SuspendLayout();
            this.dpnAttributeTable.SuspendLayout();
            this.dpnDangTinhGiaTatCa.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.dpnTimKiemTheoDuong.SuspendLayout();
            this.dpnTinhGiaDatTatCa.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dpnTimDuong.SuspendLayout();
            this.dpnTinhGiaDatTungLoai.SuspendLayout();
            this.dpnTinhGiaHemChinh.SuspendLayout();
            this.controlContainer3.SuspendLayout();
            this.dpnMap4Thua.SuspendLayout();
            this.controlContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.Controller = this.barAndDockingController1;
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiInstallPlugin,
            this.bbiRemovePlugin,
            this.bbiLoaiXa,
            this.bbiHem,
            this.bbiLoaiDat,
            this.bbiKtvhxh,
            this.bbiNewMap,
            this.bbiOpenMap,
            this.bbiCloseMap,
            this.bsiSaveMap,
            this.bbiSaveMap,
            this.bbiSaveAsMap,
            this.bbiAddLayer,
            this.bbiSpan,
            this.bbiZoomIn,
            this.bbiZoomOut,
            this.bbiFullExtent,
            this.bbiBackward,
            this.bbiForward,
            this.bbiSelect,
            this.bbiClearSelected,
            this.bbiZoomToSelected,
            this.bbiScale,
            this.bbiMapW,
            this.bbiLayersW,
            this.bbiAttributeW,
            this.bbiTinhHet,
            this.bbiThuaChon,
            this.bbiThuaPnn,
            this.bbiThuaPnnDt,
            this.bbiThuaPnnNt,
            this.bbiThuaNongNghiep,
            this.bbiXemGiaDat,
            this.bbiTimThuaBaseInfo,
            this.bbiTimThuaTheoDuong,
            this.bbiAdmin,
            this.bbiChangePass,
            this.bbiConnectToDb,
            this.beiChoPhepApGia,
            this.beiApGiaCaoNhat,
            this.beiK2MatTien,
            this.beiK3MatTien,
            this.beiK4MatTien,
            this.beiNamApDung,
            this.bbiMoQuyDinh,
            this.bbiLuuBangQD,
            this.bbiLuuBanSaoQd,
            this.bbiQdTinhGiaDatNn,
            this.bbiQdTinhGiaDatPnnNt,
            this.bbiQdTinhGiaDatPnnDt,
            this.beiGrDatNn,
            this.beiGrDatPnnNt,
            this.beiGrDatPnnDt,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barSubItem1,
            this.barButtonItem3,
            this.barButtonItem4,
            this.mmnBtnThoat,
            this.bbiBanDoGiaDat,
            this.bbiAlgorithm,
            this.bbiGiaDatNn,
            this.bbiGiaDatPnnNt,
            this.bbiGiaDatPnnDt,
            this.bbiEditParams,
            this.barButtonItem5,
            this.bbiSplitLandPrice,
            this.bbiDelete,
            this.txtStNam,
            this.barEditItem2,
            this.barEditItem3,
            this.bbiHesoVitri,
            this.bbiTinhGia,
            this.btnOpenLandpriceTable,
            this.btnOpenDuongTable,
            this.btnOpenHemTable,
            this.btnOpenXaPlTable,
            this.btnOpenXaLiTable,
            this.btnOpenThuaTable,
            this.btnOpenTenDuongTable,
            this.btnOpenKtvhxhTable,
            this.bbiImportFromXml,
            this.bbiRegisterVersioned,
            this.bbiDeletFeatureClass,
            this.btnBangGiaTinh,
            this.bbiAllParams,
            this.bbiTinhGiaHem,
            this.btnSelectByLocation,
            this.btnGiaDatHemChinh,
            this.btnGiaDatHemPhu});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 117;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnHeThong,
            this.rbnQuyDinhTinhGia,
            this.rbnBanDo,
            this.rbnCongCu,
            this.rbpExtension,
            this.rbnTroGiup,
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemComboBox1,
            this.chkChoPhepApGia,
            this.chkApGiaCaoNhat,
            this.repositoryItemSpinEdit1,
            this.spnK2MatTien,
            this.spnK3MatTien,
            this.spnK4MatTien,
            this.txtNamApDung,
            this.spnGrDatNn,
            this.spnGrDatPnnNt,
            this.spnGrDatPnnDt,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.SelectedPage = this.rbnHeThong;
            this.ribbon.Size = new System.Drawing.Size(1214, 145);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barSubItem1);
            this.applicationMenu1.ItemLinks.Add(this.mmnBtnThoat);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Lưu bản đồ";
            this.barSubItem1.Id = 69;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Lưu";
            this.barButtonItem3.Id = 70;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Lưu bản sao";
            this.barButtonItem4.Id = 71;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // mmnBtnThoat
            // 
            this.mmnBtnThoat.Caption = "Thoát";
            this.mmnBtnThoat.Id = 72;
            this.mmnBtnThoat.Name = "mmnBtnThoat";
            // 
            // bbiInstallPlugin
            // 
            this.bbiInstallPlugin.Caption = "Cài đặt ứng dụng";
            this.bbiInstallPlugin.Id = 1;
            this.bbiInstallPlugin.LargeGlyph = global::TNPro.Properties.Resources.install_48;
            this.bbiInstallPlugin.Name = "bbiInstallPlugin";
            this.bbiInstallPlugin.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.bbiInstallPlugin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbiRemovePlugin
            // 
            this.bbiRemovePlugin.Caption = "Gỡ bỏ ứng dụng";
            this.bbiRemovePlugin.Id = 2;
            this.bbiRemovePlugin.LargeGlyph = global::TNPro.Properties.Resources.remove_plugin_48;
            this.bbiRemovePlugin.Name = "bbiRemovePlugin";
            this.bbiRemovePlugin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bbiLoaiXa
            // 
            this.bbiLoaiXa.Caption = "Loại xã";
            this.bbiLoaiXa.Id = 3;
            this.bbiLoaiXa.LargeGlyph = global::TNPro.Properties.Resources._43_x;
            this.bbiLoaiXa.Name = "bbiLoaiXa";
            this.bbiLoaiXa.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiLoaiXa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiLoaiXa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoaiXa_ItemClick);
            // 
            // bbiHem
            // 
            this.bbiHem.Caption = "Hẻm";
            this.bbiHem.Id = 4;
            this.bbiHem.LargeGlyph = global::TNPro.Properties.Resources._43_h;
            this.bbiHem.Name = "bbiHem";
            this.bbiHem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiHem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiHem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHem_ItemClick);
            // 
            // bbiLoaiDat
            // 
            this.bbiLoaiDat.Caption = "Loại đất";
            this.bbiLoaiDat.Id = 5;
            this.bbiLoaiDat.LargeGlyph = global::TNPro.Properties.Resources._43_ld;
            this.bbiLoaiDat.Name = "bbiLoaiDat";
            this.bbiLoaiDat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiLoaiDat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoaiDat_ItemClick);
            // 
            // bbiKtvhxh
            // 
            this.bbiKtvhxh.Caption = "KTVHXH";
            this.bbiKtvhxh.Id = 6;
            this.bbiKtvhxh.LargeGlyph = global::TNPro.Properties.Resources._43_ktvhxh;
            this.bbiKtvhxh.Name = "bbiKtvhxh";
            this.bbiKtvhxh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiKtvhxh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiKtvhxh_ItemClick);
            // 
            // bbiNewMap
            // 
            this.bbiNewMap.Caption = "Bản đồ mới";
            this.bbiNewMap.Id = 7;
            this.bbiNewMap.LargeGlyph = global::TNPro.Properties.Resources.new_icon_50_50;
            this.bbiNewMap.Name = "bbiNewMap";
            this.bbiNewMap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiNewMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNewMap_ItemClick);
            // 
            // bbiOpenMap
            // 
            this.bbiOpenMap.Caption = "Mở bản đồ";
            this.bbiOpenMap.Glyph = global::TNPro.Properties.Resources.browse_24;
            this.bbiOpenMap.Id = 8;
            this.bbiOpenMap.Name = "bbiOpenMap";
            this.bbiOpenMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOpenMap_ItemClick);
            // 
            // bbiCloseMap
            // 
            this.bbiCloseMap.Caption = "Đóng bản đồ";
            this.bbiCloseMap.Glyph = global::TNPro.Properties.Resources.closeFolder_48;
            this.bbiCloseMap.Id = 9;
            this.bbiCloseMap.Name = "bbiCloseMap";
            this.bbiCloseMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCloseMap_ItemClick);
            // 
            // bsiSaveMap
            // 
            this.bsiSaveMap.Caption = "Lưu bản đồ";
            this.bsiSaveMap.Id = 10;
            this.bsiSaveMap.LargeGlyph = global::TNPro.Properties.Resources._7;
            this.bsiSaveMap.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveMap),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveAsMap)});
            this.bsiSaveMap.Name = "bsiSaveMap";
            this.bsiSaveMap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bbiSaveMap
            // 
            this.bbiSaveMap.Caption = "Lưu";
            this.bbiSaveMap.Id = 11;
            this.bbiSaveMap.Name = "bbiSaveMap";
            this.bbiSaveMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveMap_ItemClick);
            // 
            // bbiSaveAsMap
            // 
            this.bbiSaveAsMap.Caption = "Lưu bản sao";
            this.bbiSaveAsMap.Id = 12;
            this.bbiSaveAsMap.Name = "bbiSaveAsMap";
            this.bbiSaveAsMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAsMap_ItemClick);
            // 
            // bbiAddLayer
            // 
            this.bbiAddLayer.Caption = "Thêm lớp bản đồ";
            this.bbiAddLayer.Id = 13;
            this.bbiAddLayer.LargeGlyph = global::TNPro.Properties.Resources.add_48;
            this.bbiAddLayer.Name = "bbiAddLayer";
            this.bbiAddLayer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAddLayer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddLayer_ItemClick);
            // 
            // bbiSpan
            // 
            this.bbiSpan.Caption = "Di chuyển";
            this.bbiSpan.Id = 14;
            this.bbiSpan.LargeGlyph = global::TNPro.Properties.Resources.hand_48;
            this.bbiSpan.Name = "bbiSpan";
            this.bbiSpan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiSpan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSpan_ItemClick);
            // 
            // bbiZoomIn
            // 
            this.bbiZoomIn.Caption = "Phóng to";
            this.bbiZoomIn.Glyph = global::TNPro.Properties.Resources.zoom_in_16;
            this.bbiZoomIn.Id = 15;
            this.bbiZoomIn.Name = "bbiZoomIn";
            this.bbiZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomIn_ItemClick);
            // 
            // bbiZoomOut
            // 
            this.bbiZoomOut.Caption = "Thu nhỏ";
            this.bbiZoomOut.Glyph = global::TNPro.Properties.Resources.zoom_out_16;
            this.bbiZoomOut.Id = 16;
            this.bbiZoomOut.Name = "bbiZoomOut";
            this.bbiZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomOut_ItemClick);
            // 
            // bbiFullExtent
            // 
            this.bbiFullExtent.Caption = "Toàn cảnh";
            this.bbiFullExtent.Glyph = global::TNPro.Properties.Resources.zoom_extent;
            this.bbiFullExtent.Id = 17;
            this.bbiFullExtent.Name = "bbiFullExtent";
            this.bbiFullExtent.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFullExtent_ItemClick);
            // 
            // bbiBackward
            // 
            this.bbiBackward.Caption = "Về trước";
            this.bbiBackward.Glyph = global::TNPro.Properties.Resources.back_icon_16;
            this.bbiBackward.Id = 18;
            this.bbiBackward.Name = "bbiBackward";
            this.bbiBackward.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBackward_ItemClick);
            // 
            // bbiForward
            // 
            this.bbiForward.Caption = "Về sau";
            this.bbiForward.Glyph = global::TNPro.Properties.Resources.forward_icon_16;
            this.bbiForward.Id = 19;
            this.bbiForward.Name = "bbiForward";
            this.bbiForward.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiForward_ItemClick);
            // 
            // bbiSelect
            // 
            this.bbiSelect.Caption = "Chọn đối tượng";
            this.bbiSelect.Id = 20;
            this.bbiSelect.LargeGlyph = global::TNPro.Properties.Resources.select_48;
            this.bbiSelect.Name = "bbiSelect";
            this.bbiSelect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSelect_ItemClick);
            // 
            // bbiClearSelected
            // 
            this.bbiClearSelected.Caption = "Bỏ chọn";
            this.bbiClearSelected.Glyph = global::TNPro.Properties.Resources.clearSelection_icon_16;
            this.bbiClearSelected.Id = 21;
            this.bbiClearSelected.Name = "bbiClearSelected";
            this.bbiClearSelected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClearSelected_ItemClick);
            // 
            // bbiZoomToSelected
            // 
            this.bbiZoomToSelected.Caption = "Phóng tới đối tượng";
            this.bbiZoomToSelected.Glyph = global::TNPro.Properties.Resources.zoomToSelected_icon_16;
            this.bbiZoomToSelected.Id = 22;
            this.bbiZoomToSelected.Name = "bbiZoomToSelected";
            this.bbiZoomToSelected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiZoomToSelected_ItemClick);
            // 
            // bbiScale
            // 
            this.bbiScale.Caption = "Tỷ lệ:";
            this.bbiScale.Edit = this.repositoryItemComboBox1;
            this.bbiScale.Id = 26;
            this.bbiScale.Name = "bbiScale";
            this.bbiScale.Width = 80;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "1:1",
            "1:500",
            "1:1000",
            "1:2000",
            "1:5000",
            "1:10.000",
            "1:100.000"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // bbiMapW
            // 
            this.bbiMapW.Caption = "Bản đồ";
            this.bbiMapW.Glyph = global::TNPro.Properties.Resources.map_48;
            this.bbiMapW.Id = 27;
            this.bbiMapW.Name = "bbiMapW";
            // 
            // bbiLayersW
            // 
            this.bbiLayersW.Caption = "Các lớp bản đồ";
            this.bbiLayersW.Glyph = global::TNPro.Properties.Resources.Layers_icon_50_50;
            this.bbiLayersW.Id = 28;
            this.bbiLayersW.Name = "bbiLayersW";
            this.bbiLayersW.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLayersW_ItemClick);
            // 
            // bbiAttributeW
            // 
            this.bbiAttributeW.Caption = "Bảng thuộc tính";
            this.bbiAttributeW.Glyph = global::TNPro.Properties.Resources.table_16;
            this.bbiAttributeW.Id = 29;
            this.bbiAttributeW.Name = "bbiAttributeW";
            // 
            // bbiTinhHet
            // 
            this.bbiTinhHet.Caption = "Tất cả trường hợp";
            this.bbiTinhHet.Id = 30;
            this.bbiTinhHet.Name = "bbiTinhHet";
            this.bbiTinhHet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiTinhHet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTinhHet_ItemClick);
            // 
            // bbiThuaChon
            // 
            this.bbiThuaChon.Caption = "Thửa đang chọn";
            this.bbiThuaChon.Id = 31;
            this.bbiThuaChon.LargeGlyph = global::TNPro.Properties.Resources.pushme_48;
            this.bbiThuaChon.Name = "bbiThuaChon";
            this.bbiThuaChon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiThuaChon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiThuaChon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiThuaChon_ItemClick);
            // 
            // bbiThuaPnn
            // 
            this.bbiThuaPnn.Caption = "Thửa phi nông nghiệp";
            this.bbiThuaPnn.Id = 32;
            this.bbiThuaPnn.LargeGlyph = global::TNPro.Properties.Resources.phi_nn_do_thi;
            this.bbiThuaPnn.Name = "bbiThuaPnn";
            this.bbiThuaPnn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiThuaPnn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiThuaPnn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiThuaPnn_ItemClick);
            // 
            // bbiThuaPnnDt
            // 
            this.bbiThuaPnnDt.Caption = "Thửa phi nông nghiệp đô thị";
            this.bbiThuaPnnDt.Glyph = global::TNPro.Properties.Resources.phi_nn_do_thi;
            this.bbiThuaPnnDt.Id = 33;
            this.bbiThuaPnnDt.Name = "bbiThuaPnnDt";
            this.bbiThuaPnnDt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiThuaPnnDt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiThuaPnnDt_ItemClick);
            // 
            // bbiThuaPnnNt
            // 
            this.bbiThuaPnnNt.Caption = "Thửa phi nông nghiệp nông thôn";
            this.bbiThuaPnnNt.Glyph = global::TNPro.Properties.Resources.phi_nn_nt;
            this.bbiThuaPnnNt.Id = 34;
            this.bbiThuaPnnNt.Name = "bbiThuaPnnNt";
            this.bbiThuaPnnNt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiThuaPnnNt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiThuaPnnNt_ItemClick);
            // 
            // bbiThuaNongNghiep
            // 
            this.bbiThuaNongNghiep.Caption = "Thửa nông nghiệp";
            this.bbiThuaNongNghiep.Id = 35;
            this.bbiThuaNongNghiep.LargeGlyph = global::TNPro.Properties.Resources.nn1;
            this.bbiThuaNongNghiep.Name = "bbiThuaNongNghiep";
            this.bbiThuaNongNghiep.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiThuaNongNghiep.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiThuaNongNghiep.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiThuaNongNghiep_ItemClick);
            // 
            // bbiXemGiaDat
            // 
            this.bbiXemGiaDat.Caption = "Xem giá đất";
            this.bbiXemGiaDat.Glyph = global::TNPro.Properties.Resources.xemgiadat_48;
            this.bbiXemGiaDat.Id = 36;
            this.bbiXemGiaDat.Name = "bbiXemGiaDat";
            this.bbiXemGiaDat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiXemGiaDat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiXemGiaDat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiXemGiaDat_ItemClick);
            // 
            // bbiTimThuaBaseInfo
            // 
            this.bbiTimThuaBaseInfo.Caption = "Tìm thửa theo thông tin thửa";
            this.bbiTimThuaBaseInfo.Id = 37;
            this.bbiTimThuaBaseInfo.LargeGlyph = global::TNPro.Properties.Resources.info_48;
            this.bbiTimThuaBaseInfo.Name = "bbiTimThuaBaseInfo";
            this.bbiTimThuaBaseInfo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTimThuaBaseInfo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiTimThuaBaseInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTimThuaBaseInfo_ItemClick);
            // 
            // bbiTimThuaTheoDuong
            // 
            this.bbiTimThuaTheoDuong.Caption = "Tìm thửa theo đường giao thông";
            this.bbiTimThuaTheoDuong.Glyph = global::TNPro.Properties.Resources.road_icon_48;
            this.bbiTimThuaTheoDuong.Id = 38;
            this.bbiTimThuaTheoDuong.Name = "bbiTimThuaTheoDuong";
            this.bbiTimThuaTheoDuong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiTimThuaTheoDuong.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiTimThuaTheoDuong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTimThuaTheoDuong_ItemClick);
            // 
            // bbiAdmin
            // 
            this.bbiAdmin.Caption = "Thiết lập người dùng";
            this.bbiAdmin.Id = 39;
            this.bbiAdmin.LargeGlyph = global::TNPro.Properties.Resources._54;
            this.bbiAdmin.Name = "bbiAdmin";
            this.bbiAdmin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAdmin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdmin_ItemClick);
            // 
            // bbiChangePass
            // 
            this.bbiChangePass.Caption = "Thay đổi mật khẩu";
            this.bbiChangePass.Id = 40;
            this.bbiChangePass.LargeGlyph = global::TNPro.Properties.Resources._46;
            this.bbiChangePass.Name = "bbiChangePass";
            this.bbiChangePass.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiChangePass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangePass_ItemClick);
            // 
            // bbiConnectToDb
            // 
            this.bbiConnectToDb.Caption = "Kết nối cơ sở dữ liệu";
            this.bbiConnectToDb.Id = 41;
            this.bbiConnectToDb.LargeGlyph = global::TNPro.Properties.Resources._127;
            this.bbiConnectToDb.Name = "bbiConnectToDb";
            this.bbiConnectToDb.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiConnectToDb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConnectToDb_ItemClick);
            // 
            // beiChoPhepApGia
            // 
            this.beiChoPhepApGia.Caption = "Cho phép người dùng áp giá";
            this.beiChoPhepApGia.Edit = this.chkChoPhepApGia;
            this.beiChoPhepApGia.EditValue = true;
            this.beiChoPhepApGia.Id = 43;
            this.beiChoPhepApGia.Name = "beiChoPhepApGia";
            this.beiChoPhepApGia.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.beiChoPhepApGia.Width = 18;
            // 
            // chkChoPhepApGia
            // 
            this.chkChoPhepApGia.AutoHeight = false;
            this.chkChoPhepApGia.Name = "chkChoPhepApGia";
            // 
            // beiApGiaCaoNhat
            // 
            this.beiApGiaCaoNhat.Caption = "Áp dụng mức giá cao nhất";
            this.beiApGiaCaoNhat.Edit = this.chkApGiaCaoNhat;
            this.beiApGiaCaoNhat.EditValue = true;
            this.beiApGiaCaoNhat.Enabled = false;
            this.beiApGiaCaoNhat.Id = 45;
            this.beiApGiaCaoNhat.Name = "beiApGiaCaoNhat";
            this.beiApGiaCaoNhat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.beiApGiaCaoNhat.Width = 18;
            // 
            // chkApGiaCaoNhat
            // 
            this.chkApGiaCaoNhat.AutoHeight = false;
            this.chkApGiaCaoNhat.Caption = "";
            this.chkApGiaCaoNhat.Name = "chkApGiaCaoNhat";
            // 
            // beiK2MatTien
            // 
            this.beiK2MatTien.Caption = "Thửa có 2 mặt tiền: K=";
            this.beiK2MatTien.Edit = this.spnK2MatTien;
            this.beiK2MatTien.EditValue = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.beiK2MatTien.Id = 48;
            this.beiK2MatTien.Name = "beiK2MatTien";
            // 
            // spnK2MatTien
            // 
            this.spnK2MatTien.AutoHeight = false;
            this.spnK2MatTien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnK2MatTien.Name = "spnK2MatTien";
            this.spnK2MatTien.ReadOnly = true;
            // 
            // beiK3MatTien
            // 
            this.beiK3MatTien.Caption = "Thửa có 3 mặt tiền: K=";
            this.beiK3MatTien.Edit = this.spnK3MatTien;
            this.beiK3MatTien.EditValue = new decimal(new int[] {
            13,
            0,
            0,
            65536});
            this.beiK3MatTien.Id = 49;
            this.beiK3MatTien.Name = "beiK3MatTien";
            // 
            // spnK3MatTien
            // 
            this.spnK3MatTien.AutoHeight = false;
            this.spnK3MatTien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnK3MatTien.Name = "spnK3MatTien";
            this.spnK3MatTien.ReadOnly = true;
            // 
            // beiK4MatTien
            // 
            this.beiK4MatTien.Caption = "Thửa có 4 mặt tiền: K=";
            this.beiK4MatTien.Edit = this.spnK4MatTien;
            this.beiK4MatTien.EditValue = new decimal(new int[] {
            14,
            0,
            0,
            65536});
            this.beiK4MatTien.Id = 50;
            this.beiK4MatTien.Name = "beiK4MatTien";
            // 
            // spnK4MatTien
            // 
            this.spnK4MatTien.AutoHeight = false;
            this.spnK4MatTien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnK4MatTien.Name = "spnK4MatTien";
            this.spnK4MatTien.ReadOnly = true;
            // 
            // beiNamApDung
            // 
            this.beiNamApDung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.beiNamApDung.Appearance.Options.UseFont = true;
            this.beiNamApDung.Caption = "Năm áp dụng";
            this.beiNamApDung.Edit = this.txtNamApDung;
            this.beiNamApDung.EditValue = ((short)(2012));
            this.beiNamApDung.Id = 51;
            this.beiNamApDung.Name = "beiNamApDung";
            // 
            // txtNamApDung
            // 
            this.txtNamApDung.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNamApDung.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtNamApDung.Appearance.Options.UseFont = true;
            this.txtNamApDung.Appearance.Options.UseForeColor = true;
            this.txtNamApDung.AutoHeight = false;
            this.txtNamApDung.Name = "txtNamApDung";
            this.txtNamApDung.ReadOnly = true;
            // 
            // bbiMoQuyDinh
            // 
            this.bbiMoQuyDinh.Caption = "Mở bảng quy định";
            this.bbiMoQuyDinh.Glyph = global::TNPro.Properties.Resources.browse_24;
            this.bbiMoQuyDinh.Id = 52;
            this.bbiMoQuyDinh.Name = "bbiMoQuyDinh";
            this.bbiMoQuyDinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMoQuyDinh_ItemClick);
            // 
            // bbiLuuBangQD
            // 
            this.bbiLuuBangQD.Caption = "Lưu";
            this.bbiLuuBangQD.Glyph = global::TNPro.Properties.Resources._7_24;
            this.bbiLuuBangQD.Id = 55;
            this.bbiLuuBangQD.Name = "bbiLuuBangQD";
            this.bbiLuuBangQD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLuuBangQD_ItemClick);
            // 
            // bbiLuuBanSaoQd
            // 
            this.bbiLuuBanSaoQd.Caption = "Lưu bản sao";
            this.bbiLuuBanSaoQd.Id = 56;
            this.bbiLuuBanSaoQd.Name = "bbiLuuBanSaoQd";
            this.bbiLuuBanSaoQd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLuuBanSaoQd_ItemClick);
            // 
            // bbiQdTinhGiaDatNn
            // 
            this.bbiQdTinhGiaDatNn.Caption = "Đất nông nghiệp";
            this.bbiQdTinhGiaDatNn.Glyph = global::TNPro.Properties.Resources.nn;
            this.bbiQdTinhGiaDatNn.Id = 57;
            this.bbiQdTinhGiaDatNn.Name = "bbiQdTinhGiaDatNn";
            this.bbiQdTinhGiaDatNn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiQdTinhGiaDatNn_ItemClick);
            // 
            // bbiQdTinhGiaDatPnnNt
            // 
            this.bbiQdTinhGiaDatPnnNt.Caption = "Đất phi nông nghiệp nông thôn";
            this.bbiQdTinhGiaDatPnnNt.Glyph = global::TNPro.Properties.Resources.pnt;
            this.bbiQdTinhGiaDatPnnNt.Id = 58;
            this.bbiQdTinhGiaDatPnnNt.Name = "bbiQdTinhGiaDatPnnNt";
            this.bbiQdTinhGiaDatPnnNt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiQdTinhGiaDatPnnNt_ItemClick);
            // 
            // bbiQdTinhGiaDatPnnDt
            // 
            this.bbiQdTinhGiaDatPnnDt.Caption = "Đất phi nông nghiệp đô thị";
            this.bbiQdTinhGiaDatPnnDt.Glyph = global::TNPro.Properties.Resources.pdt;
            this.bbiQdTinhGiaDatPnnDt.Id = 59;
            this.bbiQdTinhGiaDatPnnDt.Name = "bbiQdTinhGiaDatPnnDt";
            this.bbiQdTinhGiaDatPnnDt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiQdTinhGiaDatPnnDt_ItemClick);
            // 
            // beiGrDatNn
            // 
            this.beiGrDatNn.Caption = "Đất nông nghiệp";
            this.beiGrDatNn.Edit = this.spnGrDatNn;
            this.beiGrDatNn.EditValue = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.beiGrDatNn.Id = 60;
            this.beiGrDatNn.Name = "beiGrDatNn";
            this.beiGrDatNn.Width = 60;
            // 
            // spnGrDatNn
            // 
            this.spnGrDatNn.AutoHeight = false;
            this.spnGrDatNn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnGrDatNn.DisplayFormat.FormatString = "{0} m";
            this.spnGrDatNn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnGrDatNn.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spnGrDatNn.Name = "spnGrDatNn";
            this.spnGrDatNn.ReadOnly = true;
            // 
            // beiGrDatPnnNt
            // 
            this.beiGrDatPnnNt.Caption = "Đất phi nông nghiệp nông thôn";
            this.beiGrDatPnnNt.Edit = this.spnGrDatPnnNt;
            this.beiGrDatPnnNt.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.beiGrDatPnnNt.Id = 63;
            this.beiGrDatPnnNt.Name = "beiGrDatPnnNt";
            this.beiGrDatPnnNt.Width = 60;
            // 
            // spnGrDatPnnNt
            // 
            this.spnGrDatPnnNt.AutoHeight = false;
            this.spnGrDatPnnNt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnGrDatPnnNt.DisplayFormat.FormatString = "{0} m";
            this.spnGrDatPnnNt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnGrDatPnnNt.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spnGrDatPnnNt.Name = "spnGrDatPnnNt";
            this.spnGrDatPnnNt.ReadOnly = true;
            this.spnGrDatPnnNt.ValidateOnEnterKey = true;
            // 
            // beiGrDatPnnDt
            // 
            this.beiGrDatPnnDt.Caption = "Đất phi nông nghiệp đô thị";
            this.beiGrDatPnnDt.Edit = this.spnGrDatPnnDt;
            this.beiGrDatPnnDt.EditValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.beiGrDatPnnDt.Id = 66;
            this.beiGrDatPnnDt.Name = "beiGrDatPnnDt";
            this.beiGrDatPnnDt.Width = 60;
            // 
            // spnGrDatPnnDt
            // 
            this.spnGrDatPnnDt.AutoHeight = false;
            this.spnGrDatPnnDt.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnGrDatPnnDt.DisplayFormat.FormatString = "{0} m";
            this.spnGrDatPnnDt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnGrDatPnnDt.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spnGrDatPnnDt.Name = "spnGrDatPnnDt";
            this.spnGrDatPnnDt.ReadOnly = true;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 67;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 68;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bbiBanDoGiaDat
            // 
            this.bbiBanDoGiaDat.Caption = "Bản đồ giá đất";
            this.bbiBanDoGiaDat.Id = 73;
            this.bbiBanDoGiaDat.LargeGlyph = global::TNPro.Properties.Resources._62;
            this.bbiBanDoGiaDat.Name = "bbiBanDoGiaDat";
            this.bbiBanDoGiaDat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBanDoGiaDat_ItemClick);
            // 
            // bbiAlgorithm
            // 
            this.bbiAlgorithm.Caption = "Tùy chỉnh thuật toán";
            this.bbiAlgorithm.Id = 74;
            this.bbiAlgorithm.Name = "bbiAlgorithm";
            this.bbiAlgorithm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAlgorithm_ItemClick);
            // 
            // bbiGiaDatNn
            // 
            this.bbiGiaDatNn.Caption = "Giá đất nông nghiệp";
            this.bbiGiaDatNn.Glyph = global::TNPro.Properties.Resources._80;
            this.bbiGiaDatNn.Id = 76;
            this.bbiGiaDatNn.Name = "bbiGiaDatNn";
            this.bbiGiaDatNn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGiaDatNn_ItemClick);
            // 
            // bbiGiaDatPnnNt
            // 
            this.bbiGiaDatPnnNt.Caption = "Giá đất phi nông nghiệp nông thôn";
            this.bbiGiaDatPnnNt.Glyph = global::TNPro.Properties.Resources._80;
            this.bbiGiaDatPnnNt.Id = 78;
            this.bbiGiaDatPnnNt.Name = "bbiGiaDatPnnNt";
            this.bbiGiaDatPnnNt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGiaDatPnnNt_ItemClick);
            // 
            // bbiGiaDatPnnDt
            // 
            this.bbiGiaDatPnnDt.Caption = "Giá đất phi nông nghiệp đô thị";
            this.bbiGiaDatPnnDt.Glyph = global::TNPro.Properties.Resources._80;
            this.bbiGiaDatPnnDt.Id = 82;
            this.bbiGiaDatPnnDt.Name = "bbiGiaDatPnnDt";
            this.bbiGiaDatPnnDt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGiaDatPnnDt_ItemClick);
            // 
            // bbiEditParams
            // 
            this.bbiEditParams.Caption = "Chỉnh sửa";
            this.bbiEditParams.Id = 84;
            this.bbiEditParams.Name = "bbiEditParams";
            this.bbiEditParams.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiEditParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditParams_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Hướng dẫn sử dụng";
            this.barButtonItem5.Id = 85;
            this.barButtonItem5.LargeGlyph = global::TNPro.Properties.Resources.help_43;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bbiSplitLandPrice
            // 
            this.bbiSplitLandPrice.Caption = "Phân loại giá trên 1 thửa";
            this.bbiSplitLandPrice.Id = 86;
            this.bbiSplitLandPrice.Name = "bbiSplitLandPrice";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "barButtonItem6";
            this.bbiDelete.Id = 87;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // txtStNam
            // 
            this.txtStNam.Caption = "Năm hiện hành:";
            this.txtStNam.Edit = this.repositoryItemTextEdit2;
            this.txtStNam.Id = 88;
            this.txtStNam.Name = "txtStNam";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "Người dùng:";
            this.barEditItem2.Edit = this.repositoryItemTextEdit3;
            this.barEditItem2.Id = 89;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "Kết nối CSDL";
            this.barEditItem3.Edit = this.repositoryItemTextEdit4;
            this.barEditItem3.Id = 91;
            this.barEditItem3.Name = "barEditItem3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // bbiHesoVitri
            // 
            this.bbiHesoVitri.Caption = "Hệ số vị trí - Thuật toán";
            this.bbiHesoVitri.Id = 92;
            this.bbiHesoVitri.LargeGlyph = global::TNPro.Properties.Resources.marker_43;
            this.bbiHesoVitri.Name = "bbiHesoVitri";
            this.bbiHesoVitri.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiHesoVitri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHesoVitri_ItemClick);
            // 
            // bbiTinhGia
            // 
            this.bbiTinhGia.Caption = "Tính giá đất";
            this.bbiTinhGia.Id = 93;
            this.bbiTinhGia.LargeGlyph = global::TNPro.Properties.Resources.calculator_1_43;
            this.bbiTinhGia.Name = "bbiTinhGia";
            this.bbiTinhGia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTinhGia_ItemClick);
            // 
            // btnOpenLandpriceTable
            // 
            this.btnOpenLandpriceTable.Caption = "Bảng giá công bố";
            this.btnOpenLandpriceTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenLandpriceTable.Id = 94;
            this.btnOpenLandpriceTable.Name = "btnOpenLandpriceTable";
            this.btnOpenLandpriceTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenLandpriceTable_ItemClick);
            // 
            // btnOpenDuongTable
            // 
            this.btnOpenDuongTable.Caption = "Bảng đường giao thông";
            this.btnOpenDuongTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenDuongTable.Id = 95;
            this.btnOpenDuongTable.Name = "btnOpenDuongTable";
            this.btnOpenDuongTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenDuongTable_ItemClick);
            // 
            // btnOpenHemTable
            // 
            this.btnOpenHemTable.Caption = "Bảng Hẻm";
            this.btnOpenHemTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenHemTable.Id = 96;
            this.btnOpenHemTable.Name = "btnOpenHemTable";
            this.btnOpenHemTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenHemTable_ItemClick);
            // 
            // btnOpenXaPlTable
            // 
            this.btnOpenXaPlTable.Caption = "Bảng ranh xã (vùng)";
            this.btnOpenXaPlTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenXaPlTable.Id = 97;
            this.btnOpenXaPlTable.Name = "btnOpenXaPlTable";
            this.btnOpenXaPlTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenXaPlTable_ItemClick);
            // 
            // btnOpenXaLiTable
            // 
            this.btnOpenXaLiTable.Caption = "Bảng ranh xã (đường)";
            this.btnOpenXaLiTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenXaLiTable.Id = 98;
            this.btnOpenXaLiTable.Name = "btnOpenXaLiTable";
            this.btnOpenXaLiTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenXaLiTable_ItemClick);
            // 
            // btnOpenThuaTable
            // 
            this.btnOpenThuaTable.Caption = "Bảng ranh thửa";
            this.btnOpenThuaTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenThuaTable.Id = 99;
            this.btnOpenThuaTable.Name = "btnOpenThuaTable";
            this.btnOpenThuaTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenThuaTable_ItemClick);
            // 
            // btnOpenTenDuongTable
            // 
            this.btnOpenTenDuongTable.Caption = "Bảng tên đường";
            this.btnOpenTenDuongTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenTenDuongTable.Id = 100;
            this.btnOpenTenDuongTable.Name = "btnOpenTenDuongTable";
            this.btnOpenTenDuongTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenTenDuongTable_ItemClick);
            // 
            // btnOpenKtvhxhTable
            // 
            this.btnOpenKtvhxhTable.Caption = "Bảng KTVHXH";
            this.btnOpenKtvhxhTable.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnOpenKtvhxhTable.Id = 101;
            this.btnOpenKtvhxhTable.Name = "btnOpenKtvhxhTable";
            this.btnOpenKtvhxhTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenKtvhxhTable_ItemClick);
            // 
            // bbiImportFromXml
            // 
            this.bbiImportFromXml.Caption = "Nhập dữ liệu từ file Xml";
            this.bbiImportFromXml.Glyph = global::TNPro.Properties.Resources.xml_16;
            this.bbiImportFromXml.Id = 102;
            this.bbiImportFromXml.Name = "bbiImportFromXml";
            this.bbiImportFromXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImportFromXml_ItemClick);
            // 
            // bbiRegisterVersioned
            // 
            this.bbiRegisterVersioned.Caption = "Đăng ký versioned";
            this.bbiRegisterVersioned.Glyph = global::TNPro.Properties.Resources.version_16;
            this.bbiRegisterVersioned.Id = 105;
            this.bbiRegisterVersioned.Name = "bbiRegisterVersioned";
            this.bbiRegisterVersioned.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbiRegisterVersioned.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRegisterVersioned_ItemClick);
            // 
            // bbiDeletFeatureClass
            // 
            this.bbiDeletFeatureClass.Caption = "Xóa Lớp dữ liệu";
            this.bbiDeletFeatureClass.Glyph = global::TNPro.Properties.Resources.deleteFile_16;
            this.bbiDeletFeatureClass.Id = 107;
            this.bbiDeletFeatureClass.Name = "bbiDeletFeatureClass";
            this.bbiDeletFeatureClass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeletFeatureClass_ItemClick);
            // 
            // btnBangGiaTinh
            // 
            this.btnBangGiaTinh.Caption = "Bảng giá tính toán";
            this.btnBangGiaTinh.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnBangGiaTinh.Id = 111;
            this.btnBangGiaTinh.Name = "btnBangGiaTinh";
            this.btnBangGiaTinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBangGiaTinh_ItemClick);
            // 
            // bbiAllParams
            // 
            this.bbiAllParams.Caption = "Tất cả tham số";
            this.bbiAllParams.Glyph = global::TNPro.Properties.Resources.numbers_icon_43;
            this.bbiAllParams.Id = 112;
            this.bbiAllParams.Name = "bbiAllParams";
            this.bbiAllParams.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAllParams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAllParams_ItemClick);
            // 
            // bbiTinhGiaHem
            // 
            this.bbiTinhGiaHem.Caption = "Tính giá hẻm";
            this.bbiTinhGiaHem.Id = 113;
            this.bbiTinhGiaHem.LargeGlyph = global::TNPro.Properties.Resources.calculator_2_43;
            this.bbiTinhGiaHem.Name = "bbiTinhGiaHem";
            this.bbiTinhGiaHem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTinhGiaHem_ItemClick);
            // 
            // btnSelectByLocation
            // 
            this.btnSelectByLocation.Caption = "Chọn theo không gian";
            this.btnSelectByLocation.Id = 114;
            this.btnSelectByLocation.LargeGlyph = global::TNPro.Properties.Resources.select_by_location_43;
            this.btnSelectByLocation.Name = "btnSelectByLocation";
            this.btnSelectByLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelectByLocation_ItemClick);
            // 
            // btnGiaDatHemChinh
            // 
            this.btnGiaDatHemChinh.Caption = "Giá hẻm chính";
            this.btnGiaDatHemChinh.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnGiaDatHemChinh.Id = 115;
            this.btnGiaDatHemChinh.Name = "btnGiaDatHemChinh";
            this.btnGiaDatHemChinh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGiaDatHemChinh_ItemClick);
            // 
            // btnGiaDatHemPhu
            // 
            this.btnGiaDatHemPhu.Caption = "Giá hẻm phụ";
            this.btnGiaDatHemPhu.Glyph = global::TNPro.Properties.Resources.table_16;
            this.btnGiaDatHemPhu.Id = 116;
            this.btnGiaDatHemPhu.Name = "btnGiaDatHemPhu";
            this.btnGiaDatHemPhu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGiaDatHemPhu_ItemClick);
            // 
            // rbnHeThong
            // 
            this.rbnHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgQuanLyNguoiDung,
            this.rbgCsdl});
            this.rbnHeThong.Name = "rbnHeThong";
            this.rbnHeThong.Text = "Hệ thống";
            // 
            // rbgQuanLyNguoiDung
            // 
            this.rbgQuanLyNguoiDung.ItemLinks.Add(this.bbiAdmin);
            this.rbgQuanLyNguoiDung.ItemLinks.Add(this.bbiChangePass);
            this.rbgQuanLyNguoiDung.Name = "rbgQuanLyNguoiDung";
            this.rbgQuanLyNguoiDung.ShowCaptionButton = false;
            this.rbgQuanLyNguoiDung.Text = "Quản lý người dùng";
            // 
            // rbgCsdl
            // 
            this.rbgCsdl.ItemLinks.Add(this.bbiConnectToDb);
            this.rbgCsdl.Name = "rbgCsdl";
            this.rbgCsdl.ShowCaptionButton = false;
            this.rbgCsdl.Text = "Cơ sở dữ liệu";
            // 
            // rbnQuyDinhTinhGia
            // 
            this.rbnQuyDinhTinhGia.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgQuyDinhChung,
            this.rpgThuaPnnNhieuMt,
            this.rpgQdDatGiapRanh,
            this.rpgQdTungLoaiDat,
            this.ribbonPageGroup3});
            this.rbnQuyDinhTinhGia.Name = "rbnQuyDinhTinhGia";
            this.rbnQuyDinhTinhGia.Text = "Quy định tính giá";
            // 
            // rpgQuyDinhChung
            // 
            this.rpgQuyDinhChung.ItemLinks.Add(this.beiNamApDung);
            this.rpgQuyDinhChung.ItemLinks.Add(this.bbiMoQuyDinh);
            this.rpgQuyDinhChung.ItemLinks.Add(this.bbiLuuBangQD);
            this.rpgQuyDinhChung.ItemLinks.Add(this.bbiEditParams, true);
            this.rpgQuyDinhChung.ItemLinks.Add(this.beiChoPhepApGia);
            this.rpgQuyDinhChung.ItemLinks.Add(this.beiApGiaCaoNhat);
            this.rpgQuyDinhChung.Name = "rpgQuyDinhChung";
            this.rpgQuyDinhChung.ShowCaptionButton = false;
            // 
            // rpgThuaPnnNhieuMt
            // 
            this.rpgThuaPnnNhieuMt.ItemLinks.Add(this.beiK2MatTien);
            this.rpgThuaPnnNhieuMt.ItemLinks.Add(this.beiK3MatTien);
            this.rpgThuaPnnNhieuMt.ItemLinks.Add(this.beiK4MatTien);
            this.rpgThuaPnnNhieuMt.Name = "rpgThuaPnnNhieuMt";
            this.rpgThuaPnnNhieuMt.Text = "Thửa phi nông nghiệp nhiều mặt tiền";
            this.rpgThuaPnnNhieuMt.Visible = false;
            this.rpgThuaPnnNhieuMt.CaptionButtonClick += new DevExpress.XtraBars.Ribbon.RibbonPageGroupEventHandler(this.rpgThuaPnnNhieuMt_CaptionButtonClick);
            // 
            // rpgQdDatGiapRanh
            // 
            this.rpgQdDatGiapRanh.ItemLinks.Add(this.beiGrDatNn);
            this.rpgQdDatGiapRanh.ItemLinks.Add(this.beiGrDatPnnDt);
            this.rpgQdDatGiapRanh.ItemLinks.Add(this.beiGrDatPnnNt);
            this.rpgQdDatGiapRanh.Name = "rpgQdDatGiapRanh";
            this.rpgQdDatGiapRanh.ShowCaptionButton = false;
            toolTipTitleItem1.Text = "Miêu tả";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Ðất tại khu vực đất giáp ranh đuợc xác định từ đuờng phân địa giới hành chính giữ" +
                "a các huyện, thị xã vào sâu địa phận mỗi huyện, thị xã một khoảng cách tùy theo " +
                "loại đất:";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.rpgQdDatGiapRanh.SuperTip = superToolTip1;
            this.rpgQdDatGiapRanh.Text = "Quy định cho đất giáp ranh";
            this.rpgQdDatGiapRanh.Visible = false;
            // 
            // rpgQdTungLoaiDat
            // 
            this.rpgQdTungLoaiDat.ItemLinks.Add(this.bbiAllParams);
            this.rpgQdTungLoaiDat.ItemLinks.Add(this.bbiQdTinhGiaDatNn);
            this.rpgQdTungLoaiDat.ItemLinks.Add(this.bbiQdTinhGiaDatPnnDt);
            this.rpgQdTungLoaiDat.ItemLinks.Add(this.bbiQdTinhGiaDatPnnNt);
            this.rpgQdTungLoaiDat.Name = "rpgQdTungLoaiDat";
            this.rpgQdTungLoaiDat.ShowCaptionButton = false;
            this.rpgQdTungLoaiDat.Text = "Quy định cụ thể cho từng loại đất";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiGiaDatNn);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiGiaDatPnnNt);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiGiaDatPnnDt);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Bảng giá ban hành";
            // 
            // rbnBanDo
            // 
            this.rbnBanDo.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgMapCommon,
            this.rpgTuongTacBanDo,
            this.rpgHienThi,
            this.ribbonPageGroup1});
            this.rbnBanDo.Name = "rbnBanDo";
            this.rbnBanDo.Text = "Bản đồ";
            // 
            // rpgMapCommon
            // 
            this.rpgMapCommon.ItemLinks.Add(this.bbiNewMap);
            this.rpgMapCommon.ItemLinks.Add(this.bbiOpenMap);
            this.rpgMapCommon.ItemLinks.Add(this.bbiCloseMap);
            this.rpgMapCommon.ItemLinks.Add(this.bsiSaveMap);
            this.rpgMapCommon.Name = "rpgMapCommon";
            this.rpgMapCommon.ShowCaptionButton = false;
            // 
            // rpgTuongTacBanDo
            // 
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiAddLayer);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiSpan);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiZoomIn);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiZoomOut);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiFullExtent);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiBackward);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiForward);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiSelect);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiClearSelected);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiZoomToSelected);
            this.rpgTuongTacBanDo.ItemLinks.Add(this.bbiScale);
            this.rpgTuongTacBanDo.Name = "rpgTuongTacBanDo";
            this.rpgTuongTacBanDo.ShowCaptionButton = false;
            this.rpgTuongTacBanDo.Text = "Tương tác bản đồ";
            // 
            // rpgHienThi
            // 
            this.rpgHienThi.ItemLinks.Add(this.bbiMapW);
            this.rpgHienThi.ItemLinks.Add(this.bbiLayersW);
            this.rpgHienThi.ItemLinks.Add(this.bbiAttributeW);
            this.rpgHienThi.Name = "rpgHienThi";
            this.rpgHienThi.ShowCaptionButton = false;
            this.rpgHienThi.Text = "Cửa sổ hiển thị";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiBanDoGiaDat);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Bản đồ giá đất";
            // 
            // rbnCongCu
            // 
            this.rbnCongCu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTimKiem,
            this.rpgTinhGiaDat,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.rbnCongCu.Name = "rbnCongCu";
            this.rbnCongCu.Text = "Công cụ";
            // 
            // rpgTimKiem
            // 
            this.rpgTimKiem.ItemLinks.Add(this.bbiXemGiaDat);
            this.rpgTimKiem.ItemLinks.Add(this.bbiTimThuaBaseInfo);
            this.rpgTimKiem.ItemLinks.Add(this.bbiTimThuaTheoDuong);
            this.rpgTimKiem.ItemLinks.Add(this.btnSelectByLocation);
            this.rpgTimKiem.Name = "rpgTimKiem";
            this.rpgTimKiem.ShowCaptionButton = false;
            this.rpgTimKiem.Text = "Tìm kiếm";
            this.rpgTimKiem.CaptionButtonClick += new DevExpress.XtraBars.Ribbon.RibbonPageGroupEventHandler(this.rpgTimKiem_CaptionButtonClick);
            // 
            // rpgTinhGiaDat
            // 
            this.rpgTinhGiaDat.ItemLinks.Add(this.bbiTinhGia);
            this.rpgTinhGiaDat.ItemLinks.Add(this.bbiTinhGiaHem);
            this.rpgTinhGiaDat.Name = "rpgTinhGiaDat";
            this.rpgTinhGiaDat.ShowCaptionButton = false;
            this.rpgTinhGiaDat.Text = "Tính giá đất";
            this.rpgTinhGiaDat.CaptionButtonClick += new DevExpress.XtraBars.Ribbon.RibbonPageGroupEventHandler(this.rpgTinhGiaDat_CaptionButtonClick);
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenLandpriceTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnBangGiaTinh);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenThuaTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenKtvhxhTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenDuongTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenHemTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenXaPlTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenXaLiTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenTenDuongTable);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnGiaDatHemChinh);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnGiaDatHemPhu);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "Bảng thuộc tính các lớp dữ liệu";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiImportFromXml);
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiRegisterVersioned);
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiDeletFeatureClass);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            this.ribbonPageGroup7.Text = "Cơ sở dữ liệu";
            // 
            // rbpExtension
            // 
            this.rbpExtension.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgExtCommon,
            this.rpgExtPlugins});
            this.rbpExtension.Name = "rbpExtension";
            this.rbpExtension.Text = "Mở rộng";
            // 
            // rpgExtCommon
            // 
            this.rpgExtCommon.ItemLinks.Add(this.bbiInstallPlugin);
            this.rpgExtCommon.ItemLinks.Add(this.bbiRemovePlugin);
            this.rpgExtCommon.Name = "rpgExtCommon";
            this.rpgExtCommon.ShowCaptionButton = false;
            // 
            // rpgExtPlugins
            // 
            this.rpgExtPlugins.Name = "rpgExtPlugins";
            this.rpgExtPlugins.ShowCaptionButton = false;
            this.rpgExtPlugins.Text = "Các chức năng mở rộng";
            // 
            // rbnTroGiup
            // 
            this.rbnTroGiup.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rbnTroGiup.Name = "rbnTroGiup";
            this.rbnTroGiup.Text = "Trợ giúp";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Danh mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiLoaiDat);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiKtvhxh);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiHesoVitri);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.txtStNam);
            this.ribbonStatusBar.ItemLinks.Add(this.barEditItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.barEditItem3);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 432);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1214, 31);
            // 
            // dockManager1
            // 
            this.dockManager1.Controller = this.barAndDockingController1;
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnTimKiemTheoThua2,
            this.dpnAttributeTable,
            this.dpnDangTinhGiaTatCa,
            this.dpnTimKiemTheoDuong,
            this.dpnTinhGiaDatTatCa,
            this.dpnTimDuong,
            this.dpnTinhGiaDatTungLoai,
            this.dpnTinhGiaHemChinh});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dpnMap4Thua});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dpnTimKiemTheoThua2
            // 
            this.dpnTimKiemTheoThua2.Controls.Add(this.controlContainer9);
            this.dpnTimKiemTheoThua2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpnTimKiemTheoThua2.FloatLocation = new System.Drawing.Point(45, 16);
            this.dpnTimKiemTheoThua2.FloatSize = new System.Drawing.Size(525, 596);
            this.dpnTimKiemTheoThua2.ID = new System.Guid("02810379-dc89-44b5-aabd-fecabee4dfab");
            this.dpnTimKiemTheoThua2.Location = new System.Drawing.Point(-32768, -32768);
            this.dpnTimKiemTheoThua2.Name = "dpnTimKiemTheoThua2";
            this.dpnTimKiemTheoThua2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpnTimKiemTheoThua2.SavedIndex = 2;
            this.dpnTimKiemTheoThua2.Size = new System.Drawing.Size(525, 596);
            this.dpnTimKiemTheoThua2.Text = "Tìm Kiếm theo thông tin thửa";
            this.dpnTimKiemTheoThua2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer9
            // 
            this.controlContainer9.Controls.Add(this.gQueryInfoThuaView1);
            this.controlContainer9.Location = new System.Drawing.Point(3, 22);
            this.controlContainer9.Name = "controlContainer9";
            this.controlContainer9.Size = new System.Drawing.Size(519, 571);
            this.controlContainer9.TabIndex = 0;
            // 
            // gQueryInfoThuaView1
            // 
            this.gQueryInfoThuaView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gQueryInfoThuaView1.Location = new System.Drawing.Point(0, 0);
            this.gQueryInfoThuaView1.Name = "gQueryInfoThuaView1";
            this.gQueryInfoThuaView1.Size = new System.Drawing.Size(519, 571);
            this.gQueryInfoThuaView1.TabIndex = 0;
            // 
            // dpnAttributeTable
            // 
            this.dpnAttributeTable.Controls.Add(this.controlContainer2);
            this.dpnAttributeTable.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpnAttributeTable.FloatLocation = new System.Drawing.Point(387, 162);
            this.dpnAttributeTable.FloatSize = new System.Drawing.Size(436, 259);
            this.dpnAttributeTable.FloatVertical = true;
            this.dpnAttributeTable.ID = new System.Guid("594122be-cd5f-473c-bd6f-2ce41104599f");
            this.dpnAttributeTable.Location = new System.Drawing.Point(-32768, -32768);
            this.dpnAttributeTable.Name = "dpnAttributeTable";
            this.dpnAttributeTable.OriginalSize = new System.Drawing.Size(113, 233);
            this.dpnAttributeTable.SavedIndex = 1;
            this.dpnAttributeTable.Size = new System.Drawing.Size(436, 259);
            this.dpnAttributeTable.Text = "Bảng thuộc tính";
            this.dpnAttributeTable.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer2
            // 
            this.controlContainer2.Location = new System.Drawing.Point(3, 22);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(430, 234);
            this.controlContainer2.TabIndex = 0;
            // 
            // dpnDangTinhGiaTatCa
            // 
            this.dpnDangTinhGiaTatCa.Controls.Add(this.controlContainer1);
            this.dpnDangTinhGiaTatCa.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpnDangTinhGiaTatCa.FloatLocation = new System.Drawing.Point(79, 210);
            this.dpnDangTinhGiaTatCa.FloatSize = new System.Drawing.Size(538, 397);
            this.dpnDangTinhGiaTatCa.ID = new System.Guid("a39fb016-99e4-4d95-82fd-dd2508f61780");
            this.dpnDangTinhGiaTatCa.Location = new System.Drawing.Point(-32768, -32768);
            this.dpnDangTinhGiaTatCa.Name = "dpnDangTinhGiaTatCa";
            this.dpnDangTinhGiaTatCa.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpnDangTinhGiaTatCa.SavedIndex = 2;
            this.dpnDangTinhGiaTatCa.Size = new System.Drawing.Size(538, 397);
            this.dpnDangTinhGiaTatCa.Text = "Đang tính giá";
            this.dpnDangTinhGiaTatCa.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.gCalculatingView1);
            this.controlContainer1.Location = new System.Drawing.Point(3, 22);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(532, 372);
            this.controlContainer1.TabIndex = 0;
            // 
            // gCalculatingView1
            // 
            this.gCalculatingView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCalculatingView1.Location = new System.Drawing.Point(0, 0);
            this.gCalculatingView1.Name = "gCalculatingView1";
            this.gCalculatingView1.Size = new System.Drawing.Size(532, 372);
            this.gCalculatingView1.TabIndex = 0;
            // 
            // dpnTimKiemTheoDuong
            // 
            this.dpnTimKiemTheoDuong.Controls.Add(this.controlContainer5);
            this.dpnTimKiemTheoDuong.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpnTimKiemTheoDuong.FloatLocation = new System.Drawing.Point(331, 196);
            this.dpnTimKiemTheoDuong.FloatVertical = true;
            this.dpnTimKiemTheoDuong.ID = new System.Guid("652c0826-4e3a-4952-8e20-a7ca2be1834b");
            this.dpnTimKiemTheoDuong.Location = new System.Drawing.Point(-32768, -32768);
            this.dpnTimKiemTheoDuong.Name = "dpnTimKiemTheoDuong";
            this.dpnTimKiemTheoDuong.OriginalSize = new System.Drawing.Size(190, 233);
            this.dpnTimKiemTheoDuong.SavedIndex = 2;
            this.dpnTimKiemTheoDuong.Size = new System.Drawing.Size(200, 200);
            this.dpnTimKiemTheoDuong.Text = "Tìm thửa theo đường";
            this.dpnTimKiemTheoDuong.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer5
            // 
            this.controlContainer5.Location = new System.Drawing.Point(3, 22);
            this.controlContainer5.Name = "controlContainer5";
            this.controlContainer5.Size = new System.Drawing.Size(194, 175);
            this.controlContainer5.TabIndex = 0;
            // 
            // dpnTinhGiaDatTatCa
            // 
            this.dpnTinhGiaDatTatCa.Controls.Add(this.dockPanel1_Container);
            this.dpnTinhGiaDatTatCa.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpnTinhGiaDatTatCa.FloatLocation = new System.Drawing.Point(69, 161);
            this.dpnTinhGiaDatTatCa.FloatSize = new System.Drawing.Size(395, 368);
            this.dpnTinhGiaDatTatCa.ID = new System.Guid("b82e0cfb-c175-4b91-97f2-4f9ea452b8c1");
            this.dpnTinhGiaDatTatCa.Location = new System.Drawing.Point(-32768, -32768);
            this.dpnTinhGiaDatTatCa.Name = "dpnTinhGiaDatTatCa";
            this.dpnTinhGiaDatTatCa.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpnTinhGiaDatTatCa.SavedIndex = 2;
            this.dpnTinhGiaDatTatCa.Size = new System.Drawing.Size(395, 368);
            this.dpnTinhGiaDatTatCa.Text = "Tính giá đất";
            this.dpnTinhGiaDatTatCa.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gCalculationView1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 22);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(389, 343);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gCalculationView1
            // 
            this.gCalculationView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCalculationView1.Location = new System.Drawing.Point(0, 0);
            this.gCalculationView1.Name = "gCalculationView1";
            this.gCalculationView1.Size = new System.Drawing.Size(389, 343);
            this.gCalculationView1.TabIndex = 0;
            // 
            // dpnTimDuong
            // 
            this.dpnTimDuong.Controls.Add(this.controlContainer6);
            this.dpnTimDuong.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpnTimDuong.FloatVertical = true;
            this.dpnTimDuong.ID = new System.Guid("96d7aa7d-f2d4-4406-bd3e-2008809550fc");
            this.dpnTimDuong.Location = new System.Drawing.Point(0, 0);
            this.dpnTimDuong.Name = "dpnTimDuong";
            this.dpnTimDuong.OriginalSize = new System.Drawing.Size(113, 200);
            this.dpnTimDuong.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpnTimDuong.SavedIndex = 0;
            this.dpnTimDuong.Size = new System.Drawing.Size(113, 287);
            this.dpnTimDuong.Text = "Tìm đường";
            this.dpnTimDuong.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer6
            // 
            this.controlContainer6.Location = new System.Drawing.Point(4, 23);
            this.controlContainer6.Name = "controlContainer6";
            this.controlContainer6.Size = new System.Drawing.Size(105, 260);
            this.controlContainer6.TabIndex = 0;
            // 
            // dpnTinhGiaDatTungLoai
            // 
            this.dpnTinhGiaDatTungLoai.Controls.Add(this.controlContainer8);
            this.dpnTinhGiaDatTungLoai.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpnTinhGiaDatTungLoai.FloatSize = new System.Drawing.Size(320, 351);
            this.dpnTinhGiaDatTungLoai.FloatVertical = true;
            this.dpnTinhGiaDatTungLoai.ID = new System.Guid("6fd63757-855f-47fa-82b2-e944a21d773c");
            this.dpnTinhGiaDatTungLoai.Location = new System.Drawing.Point(1093, 145);
            this.dpnTinhGiaDatTungLoai.Name = "dpnTinhGiaDatTungLoai";
            this.dpnTinhGiaDatTungLoai.OriginalSize = new System.Drawing.Size(121, 200);
            this.dpnTinhGiaDatTungLoai.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpnTinhGiaDatTungLoai.SavedIndex = 1;
            this.dpnTinhGiaDatTungLoai.Size = new System.Drawing.Size(121, 287);
            this.dpnTinhGiaDatTungLoai.Text = "Tính giá đất";
            this.dpnTinhGiaDatTungLoai.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer8
            // 
            this.controlContainer8.Location = new System.Drawing.Point(4, 23);
            this.controlContainer8.Name = "controlContainer8";
            this.controlContainer8.Size = new System.Drawing.Size(113, 260);
            this.controlContainer8.TabIndex = 0;
            // 
            // dpnTinhGiaHemChinh
            // 
            this.dpnTinhGiaHemChinh.Controls.Add(this.controlContainer3);
            this.dpnTinhGiaHemChinh.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dpnTinhGiaHemChinh.FloatLocation = new System.Drawing.Point(505, 217);
            this.dpnTinhGiaHemChinh.FloatSize = new System.Drawing.Size(360, 332);
            this.dpnTinhGiaHemChinh.ID = new System.Guid("926e81a5-31f6-4a4e-ad1b-59a72deceedc");
            this.dpnTinhGiaHemChinh.Location = new System.Drawing.Point(-32768, -32768);
            this.dpnTinhGiaHemChinh.Name = "dpnTinhGiaHemChinh";
            this.dpnTinhGiaHemChinh.OriginalSize = new System.Drawing.Size(200, 200);
            this.dpnTinhGiaHemChinh.SavedIndex = 1;
            this.dpnTinhGiaHemChinh.Size = new System.Drawing.Size(360, 332);
            this.dpnTinhGiaHemChinh.Text = "Tính giá hẻm chính";
            this.dpnTinhGiaHemChinh.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer3
            // 
            this.controlContainer3.Controls.Add(this.gCalculationHemView1);
            this.controlContainer3.Location = new System.Drawing.Point(3, 22);
            this.controlContainer3.Name = "controlContainer3";
            this.controlContainer3.Size = new System.Drawing.Size(354, 307);
            this.controlContainer3.TabIndex = 0;
            // 
            // gCalculationHemView1
            // 
            this.gCalculationHemView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCalculationHemView1.Location = new System.Drawing.Point(0, 0);
            this.gCalculationHemView1.Name = "gCalculationHemView1";
            this.gCalculationHemView1.Size = new System.Drawing.Size(354, 307);
            this.gCalculationHemView1.TabIndex = 0;
            // 
            // dpnMap4Thua
            // 
            this.dpnMap4Thua.Controls.Add(this.controlContainer4);
            this.dpnMap4Thua.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dpnMap4Thua.FloatSize = new System.Drawing.Size(495, 361);
            this.dpnMap4Thua.ID = new System.Guid("c214f364-4509-4b1f-b305-d0a395bc9ba5");
            this.dpnMap4Thua.Location = new System.Drawing.Point(0, 145);
            this.dpnMap4Thua.Name = "dpnMap4Thua";
            this.dpnMap4Thua.OriginalSize = new System.Drawing.Size(783, 200);
            this.dpnMap4Thua.Size = new System.Drawing.Size(783, 287);
            this.dpnMap4Thua.Text = "Bản đồ";
            // 
            // controlContainer4
            // 
            this.controlContainer4.Controls.Add(this.gMapView1);
            this.controlContainer4.Controls.Add(this.splitterControl1);
            this.controlContainer4.Controls.Add(this.gLayersView1);
            this.controlContainer4.Location = new System.Drawing.Point(4, 23);
            this.controlContainer4.Name = "controlContainer4";
            this.controlContainer4.Size = new System.Drawing.Size(775, 260);
            this.controlContainer4.TabIndex = 0;
            // 
            // gMapView1
            // 
            this.gMapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapView1.Location = new System.Drawing.Point(155, 0);
            this.gMapView1.Name = "gMapView1";
            this.gMapView1.Size = new System.Drawing.Size(620, 260);
            this.gMapView1.TabIndex = 1;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(150, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 260);
            this.splitterControl1.TabIndex = 0;
            this.splitterControl1.TabStop = false;
            // 
            // gLayersView1
            // 
            this.gLayersView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gLayersView1.Location = new System.Drawing.Point(0, 0);
            this.gLayersView1.Name = "gLayersView1";
            this.gLayersView1.Size = new System.Drawing.Size(150, 260);
            this.gLayersView1.TabIndex = 2;
            // 
            // controlContainer7
            // 
            this.controlContainer7.Location = new System.Drawing.Point(0, 0);
            this.controlContainer7.Name = "controlContainer7";
            this.controlContainer7.Size = new System.Drawing.Size(200, 100);
            this.controlContainer7.TabIndex = 0;
            // 
            // btnHelpFrmAll
            // 
            this.btnHelpFrmAll.Location = new System.Drawing.Point(0, 0);
            this.btnHelpFrmAll.Name = "btnHelpFrmAll";
            this.btnHelpFrmAll.Size = new System.Drawing.Size(75, 23);
            this.btnHelpFrmAll.TabIndex = 0;
            // 
            // btnTinhFrmAll
            // 
            this.btnTinhFrmAll.Location = new System.Drawing.Point(0, 0);
            this.btnTinhFrmAll.Name = "btnTinhFrmAll";
            this.btnTinhFrmAll.Size = new System.Drawing.Size(75, 23);
            this.btnTinhFrmAll.TabIndex = 0;
            // 
            // btnCloseFrmTinhAll
            // 
            this.btnCloseFrmTinhAll.Location = new System.Drawing.Point(0, 0);
            this.btnCloseFrmTinhAll.Name = "btnCloseFrmTinhAll";
            this.btnCloseFrmTinhAll.Size = new System.Drawing.Size(75, 23);
            this.btnCloseFrmTinhAll.TabIndex = 0;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.Controller = this.barAndDockingController1;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FrmMainRibbonExtensible
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 463);
            this.Controls.Add(this.dpnMap4Thua);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMainRibbonExtensible";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Phần mềm tính giá đất";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMainRibbonExtensible_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChoPhepApGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApGiaCaoNhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnK2MatTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnK3MatTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnK4MatTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNamApDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGrDatNn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGrDatPnnNt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnGrDatPnnDt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dpnTimKiemTheoThua2.ResumeLayout(false);
            this.controlContainer9.ResumeLayout(false);
            this.dpnAttributeTable.ResumeLayout(false);
            this.dpnDangTinhGiaTatCa.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.dpnTimKiemTheoDuong.ResumeLayout(false);
            this.dpnTinhGiaDatTatCa.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dpnTimDuong.ResumeLayout(false);
            this.dpnTinhGiaDatTungLoai.ResumeLayout(false);
            this.dpnTinhGiaHemChinh.ResumeLayout(false);
            this.controlContainer3.ResumeLayout(false);
            this.dpnMap4Thua.ResumeLayout(false);
            this.controlContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgQuanLyNguoiDung;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpExtension;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExtPlugins;
        private DevExpress.XtraBars.BarButtonItem bbiInstallPlugin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExtCommon;
        private DevExpress.XtraBars.BarButtonItem bbiRemovePlugin;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnBanDo;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnCongCu;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnTroGiup;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnQuyDinhTinhGia;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgCsdl;
        private DevExpress.XtraBars.BarButtonItem bbiLoaiXa;
        private DevExpress.XtraBars.BarButtonItem bbiHem;
        private DevExpress.XtraBars.BarButtonItem bbiLoaiDat;
        private DevExpress.XtraBars.BarButtonItem bbiKtvhxh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMapCommon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTuongTacBanDo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgHienThi;
        private DevExpress.XtraBars.BarButtonItem bbiNewMap;
        private DevExpress.XtraBars.BarButtonItem bbiOpenMap;
        private DevExpress.XtraBars.BarButtonItem bbiCloseMap;
        private DevExpress.XtraBars.BarSubItem bsiSaveMap;
        private DevExpress.XtraBars.BarButtonItem bbiSaveMap;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAsMap;
        private DevExpress.XtraBars.BarButtonItem bbiAddLayer;
        private DevExpress.XtraBars.BarButtonItem bbiSpan;
        private DevExpress.XtraBars.BarButtonItem bbiZoomIn;
        private DevExpress.XtraBars.BarButtonItem bbiZoomOut;
        private DevExpress.XtraBars.BarButtonItem bbiFullExtent;
        private DevExpress.XtraBars.BarButtonItem bbiBackward;
        private DevExpress.XtraBars.BarButtonItem bbiForward;
        private DevExpress.XtraBars.BarButtonItem bbiSelect;
        private DevExpress.XtraBars.BarButtonItem bbiClearSelected;
        private DevExpress.XtraBars.BarButtonItem bbiZoomToSelected;
        private DevExpress.XtraBars.BarEditItem bbiScale;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem bbiMapW;
        private DevExpress.XtraBars.BarButtonItem bbiLayersW;
        private DevExpress.XtraBars.BarButtonItem bbiAttributeW;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTimKiem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTinhGiaDat;
        private DevExpress.XtraBars.BarButtonItem bbiTinhHet;
        private DevExpress.XtraBars.BarButtonItem bbiThuaChon;
        private DevExpress.XtraBars.BarButtonItem bbiThuaPnn;
        private DevExpress.XtraBars.BarButtonItem bbiThuaPnnDt;
        private DevExpress.XtraBars.BarButtonItem bbiThuaPnnNt;
        private DevExpress.XtraBars.BarButtonItem bbiThuaNongNghiep;
        private DevExpress.XtraBars.BarButtonItem bbiXemGiaDat;
        private DevExpress.XtraBars.BarButtonItem bbiTimThuaBaseInfo;
        private DevExpress.XtraBars.BarButtonItem bbiTimThuaTheoDuong;
        private DevExpress.XtraBars.BarButtonItem bbiAdmin;
        private DevExpress.XtraBars.BarButtonItem bbiChangePass;
        private DevExpress.XtraBars.BarButtonItem bbiConnectToDb;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgQuyDinhChung;
        private DevExpress.XtraBars.BarEditItem beiChoPhepApGia;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkChoPhepApGia;
        private DevExpress.XtraBars.BarEditItem beiApGiaCaoNhat;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkApGiaCaoNhat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgThuaPnnNhieuMt;
        private DevExpress.XtraBars.BarEditItem beiK2MatTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnK2MatTien;
        private DevExpress.XtraBars.BarEditItem beiK3MatTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnK3MatTien;
        private DevExpress.XtraBars.BarEditItem beiK4MatTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnK4MatTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarEditItem beiNamApDung;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNamApDung;
        private DevExpress.XtraBars.BarButtonItem bbiMoQuyDinh;
        private DevExpress.XtraBars.BarButtonItem bbiLuuBangQD;
        private DevExpress.XtraBars.BarButtonItem bbiLuuBanSaoQd;
        private DevExpress.XtraBars.BarButtonItem bbiQdTinhGiaDatNn;
        private DevExpress.XtraBars.BarButtonItem bbiQdTinhGiaDatPnnNt;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgQdTungLoaiDat;
        private DevExpress.XtraBars.BarButtonItem bbiQdTinhGiaDatPnnDt;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgQdDatGiapRanh;
        private DevExpress.XtraBars.BarEditItem beiGrDatNn;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnGrDatNn;
        private DevExpress.XtraBars.BarEditItem beiGrDatPnnNt;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnGrDatPnnNt;
        private DevExpress.XtraBars.BarEditItem beiGrDatPnnDt;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnGrDatPnnDt;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem mmnBtnThoat;
        //private com.g1.arcgis.tn.map.MapView dpnMap;
        //private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        //private com.g1.arcgis.tn.map.LayersView dpnLayers;
        //private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dpnAttributeTable;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private DevExpress.XtraBars.Docking.DockPanel dpnTimDuong;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer6;
        private DevExpress.XtraBars.Docking.DockPanel dpnTimKiemTheoDuong;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer5;
        //private InfoQueryView dpnTimKiemTheoThua;
        //private DevExpress.XtraBars.Docking.ControlContainer controlContainer4;
        //private DevExpress.XtraBars.Docking.ControlContainer controlContainer3;
        //private DevExpress.XtraBars.Docking.DockPanel dpnTinhGiaDatAll;
        //private CalculationView dpnTinhGiaDatAll;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer7;
        private DevExpress.XtraBars.Docking.DockPanel dpnTinhGiaDatTungLoai;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer8;
        //private DevExpress.XtraEditors.PanelControl panelControl1;
        //private DevExpress.XtraEditors.PanelControl panelControl2;
        //private DevExpress.XtraEditors.SimpleButton btnClose;
        //private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        //private DevExpress.XtraTab.XtraTabControl tctr;
        //private DevExpress.XtraTab.XtraTabPage tpgTgdNn;
        //private DevExpress.XtraTab.XtraTabPage tpgTgdPnnNt;
        //private DevExpress.XtraEditors.SplitterControl splitterControl1;
        //private DevExpress.XtraEditors.SimpleButton btnAdvance;
        //private DevExpress.XtraEditors.SimpleButton btnLock;
        //private DevExpress.XtraEditors.GroupControl groupControl1;
        //private DevExpress.XtraEditors.LabelControl labelControl1;
        //private DevExpress.XtraEditors.TextEdit txtDiaChi;
        //private DevExpress.XtraEditors.TextEdit txtChuSoHuu;
        //private DevExpress.XtraEditors.LabelControl labelControl2;
        //private DevExpress.XtraGrid.GridControl grcTgdNn;
        //private DevExpress.XtraGrid.Views.Grid.GridView grvTgdNn;
        //private DevExpress.XtraEditors.TextEdit txtHuyen;
        //private DevExpress.XtraEditors.LabelControl labelControl3;
        //private DevExpress.XtraEditors.TextEdit txtXa;
        //private DevExpress.XtraEditors.LabelControl labelControl4;
        //private DevExpress.XtraEditors.TextEdit txtSoTo;
        //private DevExpress.XtraEditors.LabelControl labelControl5;
        //private DevExpress.XtraEditors.TextEdit txtKhuVuc;
        //private DevExpress.XtraEditors.TextEdit txtViTri;
        //private DevExpress.XtraEditors.TextEdit txtSoThua;
        //private DevExpress.XtraEditors.LabelControl labelControl6;
        //private DevExpress.XtraEditors.LabelControl labelControl7;
        //private DevExpress.XtraEditors.LabelControl labelControl8;
        //private DevExpress.XtraEditors.LabelControl labelControl9;
        //private DevExpress.XtraEditors.TextEdit txtLoaiDat;
        //private DevExpress.XtraEditors.TextEdit txtSoMatTien;
        //private DevExpress.XtraEditors.TextEdit txtNam;
        //private DevExpress.XtraEditors.TextEdit txtSoCachTinh;
        //private DevExpress.XtraEditors.TextEdit txtSoMatHem;
        //private DevExpress.XtraEditors.LabelControl labelControl14;
        //private DevExpress.XtraEditors.LabelControl labelControl13;
        //private DevExpress.XtraEditors.LabelControl labelControl12;
        //private DevExpress.XtraEditors.LabelControl labelControl11;
        //private DevExpress.XtraEditors.LabelControl labelControl10;
        //private DevExpress.XtraEditors.TextEdit txtDienTich;
        //private DevExpress.XtraEditors.LabelControl labelControl15;
        //private DevExpress.XtraEditors.TextEdit txtGiaDat;
        //private System.Windows.Forms.RichTextBox rtbCachTinh;
        //private DevExpress.XtraEditors.LabelControl labelControl16;
        //private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl2;
        //private DevExpress.XtraTab.XtraTabPage tpgTgdPnnDt;
        //private DevExpress.XtraGrid.GridControl grcTgdPnnNt;
        //private DevExpress.XtraGrid.Views.Grid.GridView grvTgdPnnNt;
        //private DevExpress.XtraGrid.GridControl grcTgdPnnDt;
        //private DevExpress.XtraGrid.Views.Grid.GridView grvTgdPnnDt;
        //private gov.tn.TnViews.TnXemGiaDatDockPanel dpnXemGiaDat;
        //private DevExpress.XtraEditors.GroupControl groupControl2;
        //private DevExpress.XtraEditors.PanelControl panelControl3;
        //private DevExpress.XtraEditors.PanelControl panelControl4;
        //private DevExpress.XtraEditors.CheckEdit chkOverWrite;
        //private DevExpress.XtraEditors.SpinEdit spnNam;
        //private DevExpress.XtraEditors.LabelControl labelControl17;
        //private DevExpress.XtraEditors.CheckEdit chkCalcAll;
        //private DevExpress.XtraEditors.LabelControl labelControl18;
        //private DevExpress.XtraEditors.LabelControl labelControl19;
        //private DevExpress.XtraEditors.ComboBoxEdit cbxDoanDuong;
        //private DevExpress.XtraEditors.ComboBoxEdit cbxDuong;
        //private DevExpress.XtraEditors.ComboBoxEdit cbxXa;
        //private DevExpress.XtraEditors.ComboBoxEdit cbxHuyen;
        //private DevExpress.XtraEditors.LabelControl labelControl20;
        //private DevExpress.XtraEditors.LabelControl labelControl21;
        //private DevExpress.XtraEditors.GroupControl groupControl4;
        //private TnControlLib.TnTreeViewCheckBox tvcLoaiThua;
        //private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl3;
        private DevExpress.XtraEditors.SimpleButton btnHelpFrmAll;
        private DevExpress.XtraEditors.SimpleButton btnTinhFrmAll;
        private DevExpress.XtraEditors.SimpleButton btnCloseFrmTinhAll;
        private DevExpress.XtraBars.BarButtonItem bbiBanDoGiaDat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private CalculatingView dpnDangTinhGia;
        //private LandpriceDetailView dpnXemGiaDat;
        //private InfoQueryView dpnTimKiemTheoThua;
        private DevExpress.XtraBars.BarButtonItem bbiAlgorithm;
        private DevExpress.XtraBars.Docking.DockPanel dpnTinhGiaDatTatCa;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private GCalculationView gCalculationView1;
        private DevExpress.XtraBars.Docking.DockPanel dpnDangTinhGiaTatCa;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private GCalculatingView gCalculatingView1;
        private DevExpress.XtraBars.Docking.DockPanel dpnMap4Thua;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer4;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private com.g1.arcgis.tn.map.GMapView gMapView1;
        private com.g1.arcgis.tn.map.GLayersView gLayersView1;
        private DevExpress.XtraBars.BarButtonItem bbiGiaDatNn;
        private DevExpress.XtraBars.BarButtonItem bbiGiaDatPnnNt;
        private DevExpress.XtraBars.BarButtonItem bbiGiaDatPnnDt;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiEditParams;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Docking.DockPanel dpnTimKiemTheoThua2;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer9;
        private GQueryInfoThuaView gQueryInfoThuaView1;
        private DevExpress.XtraBars.BarButtonItem bbiSplitLandPrice;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarEditItem txtStNam;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraBars.BarButtonItem bbiHesoVitri;
        private DevExpress.XtraBars.BarButtonItem bbiTinhGia;
        private DevExpress.XtraBars.BarButtonItem btnOpenLandpriceTable;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnOpenDuongTable;
        private DevExpress.XtraBars.BarButtonItem btnOpenHemTable;
        private DevExpress.XtraBars.BarButtonItem btnOpenXaPlTable;
        private DevExpress.XtraBars.BarButtonItem btnOpenXaLiTable;
        private DevExpress.XtraBars.BarButtonItem btnOpenThuaTable;
        private DevExpress.XtraBars.BarButtonItem btnOpenTenDuongTable;
        private DevExpress.XtraBars.BarButtonItem btnOpenKtvhxhTable;
        private DevExpress.XtraBars.BarButtonItem bbiImportFromXml;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem bbiRegisterVersioned;
        private DevExpress.XtraBars.BarButtonItem bbiDeletFeatureClass;
        private DevExpress.XtraBars.BarButtonItem btnBangGiaTinh;
        private DevExpress.XtraBars.BarButtonItem bbiAllParams;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiTinhGiaHem;
        private DevExpress.XtraBars.Docking.DockPanel dpnTinhGiaHemChinh;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer3;
        private GCalculationHemView gCalculationHemView1;
        private DevExpress.XtraBars.BarButtonItem btnSelectByLocation;
        private DevExpress.XtraBars.BarButtonItem btnGiaDatHemChinh;
        private DevExpress.XtraBars.BarButtonItem btnGiaDatHemPhu;
        //private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        //private DevExpress.XtraTab.XtraTabControl tctLayers;
        //private DevExpress.XtraTab.XtraTabPage pageLayers;
        //private DevExpress.XtraTab.XtraTabPage pageTables;
        //private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        //private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        //private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        //private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        //private DevExpress.XtraEditors.PanelControl panelControl2;
        //private DevExpress.XtraEditors.PictureEdit ptrMapRefresh;
        //private DevExpress.XtraEditors.LabelControl labelControl4;
        //private DevExpress.XtraEditors.LabelControl labelControl3;
        //private DevExpress.XtraEditors.TextEdit txtMapX;
        //private DevExpress.XtraEditors.TextEdit txtMapY;
        //private DevExpress.XtraEditors.LabelControl labelControl2;
        //private DevExpress.XtraEditors.LabelControl labelControl1;
        //private DevExpress.XtraEditors.LabelControl labelControl5;
        //private System.Windows.Forms.TreeView trvListThua;
        //private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        //private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        //private DevExpress.XtraEditors.PanelControl panelControl2;
        //private DevExpress.XtraEditors.PanelControl panelControl3;
        //private DevExpress.XtraEditors.GroupControl grcTkThuaThongTin;
        //private DevExpress.XtraVerticalGrid.VGridControl grcTkThuaTtThua;
        //private DevExpress.XtraEditors.SplitterControl splitterControl1;
        //private DevExpress.XtraEditors.GroupControl grcTkThuaLichSu;
        //private DevExpress.XtraEditors.PanelControl panelControl4;
        //private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        //private DevExpress.XtraEditors.SplitterControl splitterControl2;
        //private DevExpress.XtraEditors.SimpleButton btnTkThuaHelp;
        //private DevExpress.XtraEditors.SimpleButton btnTkThuaTool;
        //private DevExpress.XtraEditors.SimpleButton btnTkThuaFind;
        //private DevExpress.XtraEditors.SimpleButton btnTkThuaClose;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaChuSh;
        //private DevExpress.XtraEditors.LabelControl labelControl1;
        //private DevExpress.XtraEditors.LabelControl labelControl5;
        //private DevExpress.XtraEditors.LabelControl labelControl4;
        //private DevExpress.XtraEditors.LabelControl labelControl3;
        //private DevExpress.XtraEditors.LabelControl lbTkThuaDiaChi;
        //private DevExpress.XtraEditors.LabelControl labelControl7;
        //private DevExpress.XtraEditors.LabelControl labelControl6;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaSoCt;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaSoTo;
        //private DevExpress.XtraEditors.LabelControl labelControl9;
        //private DevExpress.XtraEditors.LabelControl labelControl8;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaLoaiDat;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaSoThua;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaSoMh;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaSoMt;
        //private DevExpress.XtraEditors.TextEdit txtTkThuaDiaChi;
        //private DevExpress.XtraEditors.PanelControl panelControl5;
        //private DevExpress.XtraGrid.GridControl grcTkThuaResult;
        //private DevExpress.XtraGrid.Views.Grid.GridView grvTkThuaResult;
        //private DevExpress.XtraEditors.SpinEdit spnTkThuaNam;
        //private DevExpress.XtraBars.Docking.ControlContainer controlContainer9;
        //private DevExpress.XtraEditors.GroupControl grcDtLog;
        //private DevExpress.XtraEditors.SplitterControl splitterControl2;
        //private DevExpress.XtraEditors.GroupControl grcListThua;
        //private DevExpress.XtraEditors.PanelControl panelControl5;
        //private System.Windows.Forms.RichTextBox rtbDtLog;
        //private DevExpress.XtraEditors.ListBoxControl lbcDtListThua;
        //private DevExpress.XtraEditors.GroupControl grcCachTinh;
        //private System.Windows.Forms.RichTextBox rtbDtCachTinh;
        //private DevExpress.XtraEditors.SimpleButton btnDtClose;
        //private DevExpress.XtraEditors.SimpleButton btnDtDetail;
        //private DevExpress.XtraEditors.SimpleButton btnDtHelp;
    }
}