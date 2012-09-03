using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.util.filterName;

namespace com.g1.arcgis.util.comparation
{
    public class Compare
    {
        public static int Compare2SdeLayerName(string layer1, string layer2)
        {
            string l1 = FilterSdeLayerName.GetActualName(layer1);
            string l2 = FilterSdeLayerName.GetActualName(layer2);
            return string.Compare(l1, l2);
        }
    }
}
