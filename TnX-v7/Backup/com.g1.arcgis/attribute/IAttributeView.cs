using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.Ribbon;
using com.g1.arcgis.map;
using com.g1.arcgis.query;
using com.g1.arcgis.landprice;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.attribute
{
    public interface IAttributeView
    {
        void Show();
        void Close();
        void SetParent(RibbonForm parent);
        void SetTableName(string name);
        void SetAliasFieldsName(List<string[,]> fields);
        void SetMapView(IMapView mapview);
        void SetTitle(string title);
        IAttributeQueryView GetView();
        void SetDetailView(ILandpriceView calcView, ILandpriceView publicView);
        IExecutor Executor { get; set; }
        ICalculationController CalcController { get; set; }
    }
}
