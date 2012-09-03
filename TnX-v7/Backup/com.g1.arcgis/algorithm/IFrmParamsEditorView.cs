using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.algorithm
{
    public interface IFrmParamsEditorView
    {
        void Show();
        void ShowDialog();
        void Close();
        void Hide();
        IParamsEditorView ParamsEditorView { get; set; }
        object Param { get; set; }
        void SetUseBtnVisible(bool arg);
        ICalcMethodBuilderView Hook { get; set; }
    }
}
