using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.connection;

namespace com.g1.arcgis.landprice
{
    public interface IXacNhan
    {
        void ShowDialog();
        void SetSwitch(IParamSwitch param);
    }
}
