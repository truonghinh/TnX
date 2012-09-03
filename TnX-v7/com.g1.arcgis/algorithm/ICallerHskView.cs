using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.algorithm
{
    public interface ICallerHskView
    {
        void SetHsk(object hsk);
        void SetCalcMethodBuilderView(ICalcMethodBuilderView view);
    }
}
