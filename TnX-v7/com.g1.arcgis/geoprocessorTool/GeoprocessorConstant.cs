
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;

namespace com.g1.arcgis.geoprocessorTool
{
    public class GeoprocessorConstant
    {
        public static Dictionary<string, esriLayerSelectionMethod> LayerSelectionMethods=new Dictionary<string,esriLayerSelectionMethod>();
        public static Dictionary<string, esriSelectionResultEnum> SelectionResults;

        public static object GetSelectionMethod(string key)
        {
            object result=null;
            if (string.Compare(key, "INTERSECT") == 0)
            {
                result = esriLayerSelectionMethod.esriLayerSelectIntersect;
            }
            else if (string.Compare(key, "CONTAINED_BY") == 0)
            {
                result = esriLayerSelectionMethod.esriLayerSelectContainedBy;
            }
            return result;
        }

        public static object GetSelectionResult(string key)
        {
            object result = null;
            if (string.Compare(key, "NEW_SELECTION") == 0)
            {
                result = esriSelectionResultEnum.esriSelectionResultNew;
            }
            else if (string.Compare(key, "ADD_SELECTION") == 0)
            {
                result = esriSelectionResultEnum.esriSelectionResultAdd;
            }
            else if (string.Compare(key, "AND_SELECTION") == 0)
            {
                result = esriSelectionResultEnum.esriSelectionResultAnd;
            }
            else if (string.Compare(key, "SUBTRACT_SELECTION") == 0)
            {
                result = esriSelectionResultEnum.esriSelectionResultSubtract;
            }
            else if (string.Compare(key, "XOR_SELECTION") == 0)
            {
                result = esriSelectionResultEnum.esriSelectionResultXOR;
            }
            return result;
        }
    }
}
