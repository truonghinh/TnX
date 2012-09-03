using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.landprice;
using com.g1.arcgis.calculation;
using com.g1.arcgis.algorithm;

namespace com.g1.arcgis.map
{
    public interface IMapContextMenu
    {
        void AddItem(object item, bool beginGroup, int subType);
        void PopupMenu(int X, int Y, int hWndParent);
        void SetKeyName(params string[] name);
        void SetLandPriceView(string key, ILandpriceView landpriceView);
        IEditPositionParamsView EditPosView { get; set; }
        ICalcMethodBuilderView CalcMethodBuilderView { get; set; }
    }
}
