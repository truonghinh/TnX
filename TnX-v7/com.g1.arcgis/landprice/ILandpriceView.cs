using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking;
using com.g1.arcgis.algorithm;
using com.g1.arcgis.calculation;
using com.g1.arcgis.map;

namespace com.g1.arcgis.landprice
{
    public interface ILandpriceView
    {
        double CurrentLandprice { get; set; }
        double CurrentArea { get; set; }
        double CurrentLandpriceWithArea { get; set; }
        int CurrentLockStatus { get; set; }
        object CurrentMathua { get; set; }
        object CurrentThuaId { get; set; }
        void LoadForm();
        void LoadPrice();
        void LoadPriceFromOid();
        void LoadPriceFromKey();
        void Close();
        void ShowDialog();
        void Show();
        void UpdateLandprice();
        void SetContainer(XtraForm form);
        void SetContainer(DockPanel dockpanel);
        void UpDate(List<ThuaGiaDatInfo> giaDatInfo);
        ICurrentConfig Config { get; set; }
        string LandpriceTableName { get; set; }
        void StartEdit();
        void SaveEdit();
        void StopEdit();
        void StopEditWithoutSaving();
        bool IsSaved { get; set; }
        bool IsEditting { get; set; }
        List<object[,]> ListOfValueThuaGiaDat { get; set; }
        List<object[,]> ListOfValueThua { get; set; }
        object CurrentThuaGiaDatId { get; set; }
        void SetCalcMethodBuilderView(ICalcMethodBuilderView view);
        IMapView MapView { get; set; }
        void SetHesoK(object hsk);
        IExecutor Excutor { get; set; }
        ICalculationController CalcController { get; set; }
        void IsAllowRecalcPoistion(bool arg);
        void ClearAll();
    }
}
