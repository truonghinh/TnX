using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geoprocessor;
using com.g1.arcgis.geoprocessorTool;

namespace com.g1.arcgis.spatialAnalysis
{
    public class GProximityTool:GeoprocessorAbstract,IBuffer
    {
        public GProximityTool(string env)
        {
            this._environment = env;
        }
        #region IBuffer Members

        void IBuffer.BufferInsideSde(string in_features, string out_feature, object distance)
        {
            Geoprocessor gp = new Geoprocessor();
            ESRI.ArcGIS.AnalysisTools.Buffer bufferTool = new ESRI.ArcGIS.AnalysisTools.Buffer();
            //_environment = "Database Connections/Connection to HT-LAPTOP.sde";
            //MessageBox.Show("TnBuffer-line:85--environment: " + _environment);
            gp.SetEnvironmentValue("workspace", _environment);
            bufferTool.in_features = in_features;
            bufferTool.out_feature_class = out_feature;
            bufferTool.buffer_distance_or_field = distance;
            runTool(gp, bufferTool, null);
        }

        #endregion
    }
}
