using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.util.filterName
{
    public class FilterSdeLayerName
    {
        public static string GetActualName(string fullName)
        {
            string name = fullName.Trim() ;
            string[] arr = name.Split('.');
            name = arr[arr.Length - 1];
            return name;
        }
    }
}
