using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using com.g1.GExtensionSpatialTool;
using ESRI.ArcGIS.Geoprocessor;
using System.Windows.Forms;
using com.g1.arcgis.geoprocessorTool;

namespace com.g1.arcgis.database
{
    public class GAppend : GeoprocessorAbstract
    {
        public GAppend() { }
        public GAppend(string env)
        {
            this._environment = env;
        }
        public void Excute(object inputFeatureClass, object targetFeatureClass)
        {
            try
            {
                Geoprocessor gp = new Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.Append appendTool = new ESRI.ArcGIS.DataManagementTools.Append();
                //IVariantArray param = new VarArrayClass();
                gp.SetEnvironmentValue("workspace", this._environment);
                appendTool.inputs = inputFeatureClass;
                appendTool.target = targetFeatureClass;
                //appendTool.out_feature_class = string.Format("{0}{1}", this._temFullPath, out_feature);//"C:\\tayninh\\temp\\tempmdb.mdb\\" + out_feature;

                runTool(gp, appendTool, null);
            }
            catch (Exception err) { MessageBox.Show("loi append: " + err.ToString()); }
        }
    }
}
