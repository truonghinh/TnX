using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using com.g1.arcgis.edit;
using com.g1.arcgis.calculation;

namespace com.g1.arcgis.algorithm
{
    public interface IParamsEditorView
    {
        void SetContainer(IFrmParamsEditorView form);
        void Show();
        void ShowDialog();
        void Close();
        void Hide();
        object GetParams();
        void SetTextes(string ten, string mota, object giatri);
        void SetHook(IEditTableView hook);
        int CurrentRow { get; set; }
        void SetUseBtnVisible(bool arg);
    }
}
