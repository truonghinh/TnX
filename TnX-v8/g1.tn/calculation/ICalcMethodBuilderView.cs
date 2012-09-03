using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace g1.tn
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
