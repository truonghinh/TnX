using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IGeneralConfigView
    {
        void LoadConfig();
        void SetBuddyConfigView(IConfigView buddy);
    }
}
