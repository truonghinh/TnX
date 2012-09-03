using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public interface IParams
    {
        IInputParams GetInputParams();
        ICurrentConfig GetCurrentConfig();
    }
}
