using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.geoprocessorTool
{
    public class GeoprocessorAbstract
    {
        protected string _environment="";
        protected IWorkspace _workspace;
        protected IWorkspaceEdit _workspaceEdit;
        protected IMultiuserWorkspaceEdit _mWorkspaceEdit;
        protected virtual void runTool(Geoprocessor geoprocessor, IGPProcess process, ITrackCancel TC)
        {

            // Set the overwrite output option to true
            geoprocessor.OverwriteOutput = true;

            // Execute the tool            
            try
            {
                geoprocessor.Execute(process, TC);
                ReturnMessages(geoprocessor);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                ReturnMessages(geoprocessor);
            }
        }
        protected virtual void runTool(Geoprocessor geoprocessor, string name, IGPProcess process, IVariantArray param, ITrackCancel TC)
        {

            // Set the overwrite output option to true
            geoprocessor.OverwriteOutput = true;

            // Execute the tool            
            try
            {
                geoprocessor.Execute(name, param, TC);//"Clip_analysis"
                ReturnMessages(geoprocessor);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                ReturnMessages(geoprocessor);
            }
        }
        protected virtual void ReturnMessages(Geoprocessor gp)
        {
            if (gp.MessageCount > 0)
            {
                for (int Count = 0; Count <= gp.MessageCount - 1; Count++)
                {
                    Console.WriteLine(gp.GetMessage(Count));
                }
            }

        }
    }
}
