using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.algorithm
{
    public interface IFrmMethodBuilderView
    {
        void Show();
        void ShowDialog();
        void Close();
        void SetParamsEditorView(IFrmParamsEditorView frmParamsEditorView);
        ICalcMethodBuilderView GetView();
    }
}
