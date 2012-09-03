using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IConfigController
    {
        void LoadConfig();
        void SaveConfig();
        void SaveAs();
        void SetSaveView(ISaveConfigView saveView);
        void SetOpenView(IOpenConfigView openView);
    }
}
