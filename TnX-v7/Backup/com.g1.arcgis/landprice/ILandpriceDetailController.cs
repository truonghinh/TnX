using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.landprice
{
    public interface ILandpriceDetailController
    {
        void ShowDetail();
        void ShowLocation();
        void LockPrices();
        void ReCalculate();
        void ShowHistory();
        void ShowQuery();
        void ShowAddvance();
    }
}
