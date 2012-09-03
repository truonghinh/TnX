using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Docking;
using com.g1.arcgis.landprice;
using com.g1.arcgis.map;

namespace com.g1.arcgis.calculation
{
    public interface ICalculationMonitor:IComparable<ICalculationMonitor>
    {
        void Watching(object arg);
        void Watching(CalculationEventArg e);
        void Watching(object[,] arg);
        void Watching(List<object> arg);
        void Watching(int report);
        void Progressing(object report);
        void AddListObject(string obj);
        void AddListThuaDuocTinhGia(object[,] args);
        void AddListThuaDuocTinhGia(params object[] args);
        void AddListThuaKhoaGia(object[,] args);
        void AddListThuaKhoaGia(params object[] args);
        //void AddListThuaDuocTinhGia(object arg);
        //void AddListThuaKhoaGia(object arg);
        void ProgressingTotal(object arg);
        void ProgressingTotalCount(object arg);
        void ProgressingPart1Total(object arg);
        void ProgressingPart1Count(object arg);
        void CatchThuaTinhGia(List<object> arg);
        void CatchThuaKhoaGia(List<object> arg);
        void CatchThuaTinhGia(object arg);
        void CatchThuaKhoaGia(object arg);
        void Finished();
        void Begining();
        string Name { get; }
        void Show();
        void SetParentControl(DockPanel parent);
        void SetDetailView(ILandpriceView calcView,ILandpriceView publicView);
        IExecutor Executor { get; set; }
        ICalculationController CalcController { get; set; }
        //void SetDetailView(ILandpriceDetailView view);
        
        //void SetMapView(IMapView mapView);
    }
}
