using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IOpenConfigView
    {
        void ShowDialog();
        void Close();
        void SetConfigView(IConfigView configView);
        string FileName { get; set; }
        string CurrentYear { get; set; }
        string NewYear { get; set; }
    }
}
