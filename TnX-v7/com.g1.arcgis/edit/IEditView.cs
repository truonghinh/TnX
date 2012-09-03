using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.edit
{
    public interface IEditView
    {
        void Close();
        void SaveEdit();
        void StopEdit();
        void StartEdit();
        void StopEditWithoutSaving();
        bool IsSaved { get; set; }
        bool IsEditting { get; set; }
    }
}
