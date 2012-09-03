using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace com.g1.arcgis.calculation
{
    [Serializable]
    [ComVisible(true)]
    public delegate void CalculatingEventHandler(object sender, CalculationEventArg e);
}
