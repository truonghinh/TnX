using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Docking;
using com.g1.arcgis.map;

namespace com.g1.arcgis.landprice
{
    public interface ILandpriceDetailView
    {
        void AddRowClickEvent(RowClickEventHandler evt);
        void SetGridViews(GridView tgdNn,GridView tgdPnnNt,GridView tgdPnnDt);
        void ShowDetail();
        void ShowLocation();
        void LockPrices();
        void ReCalculate();
        void ShowHistory();
        void ShowQuery();
        void ShowAddvance();
        void Show();
        void SetParentControl(DockPanel parent);
        void SetTablesName(string nn,string pnnnt,string pnndt);
        void SetMapView(IMapView map);
        int LoaiDat { get; set; }
        string MaThua { get; set; }
        void Query();
        void ReLoad();
        string CurrentYear{get;set;}
    }
}
