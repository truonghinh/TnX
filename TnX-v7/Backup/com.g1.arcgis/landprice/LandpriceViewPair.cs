using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.landprice
{
    public struct LandpriceViewPair
    {
        public string Key;
        public ILandpriceView View;
        public LandpriceViewPair(string key, ILandpriceView view)
        {
            Key = key;
            View = view;
        }
        
    }
}
