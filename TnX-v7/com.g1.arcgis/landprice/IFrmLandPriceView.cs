using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.landprice
{
    public interface IFrmLandPriceView
    {
        void Show();
        void ShowDialog();
        void Close();
        ILandpriceView GetView();
    }
}
