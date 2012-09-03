using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using com.g1.arcgis.landprice;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.algorithm
{
    public interface ICalcMethodBuilderView
    {
        void SetContainer(XtraForm form);
        void Show();
        void ShowDialog();
        void Close();
        void Hide();
        object GetHesoK();
        void SetVisibleBtnChonHesoK(bool arg);
        void SetLandPriceView(ILandpriceView view);
        void SetCallerView(ICallerHskView view);
        IFrmParamsEditorView ParamsEditorView { get; set; }
        object Param { get; set; }
    }
}
