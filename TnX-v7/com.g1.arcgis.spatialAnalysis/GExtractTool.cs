using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.g1.arcgis.geoprocessorTool;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Geoprocessor;
using com.g1.arcgis.database;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace com.g1.arcgis.spatialAnalysis
{
    public class GExtractTool:GeoprocessorAbstract,IClip,IErase
    {

        public GExtractTool(string env)
        {
            this._environment = env;
        }
        #region IClip Members

        void IClip.Clip(object in_feature, object clip_feature, string out_feature)
        {
            try
            {
                Geoprocessor gp = new Geoprocessor();
                ESRI.ArcGIS.AnalysisTools.Clip clipTool = new ESRI.ArcGIS.AnalysisTools.Clip();
                //IVariantArray param = new VarArrayClass();
                gp.SetEnvironmentValue("workspace", this._environment);
                //MessageBox.Show(((IFeatureLayer)in_feature).FeatureClass.AliasName);
                clipTool.in_features = in_feature;
                clipTool.clip_features = clip_feature;
                clipTool.out_feature_class = string.Format("{0}",out_feature);//"C:\\tayninh\\temp\\tempmdb.mdb\\" + out_feature;

                runTool(gp, clipTool, null);
            }
            catch (Exception err) { MessageBox.Show("loi clip: " + err.ToString()); }
        }

        void IClip.ClipInsideSde(object in_feature, object clip_feature, string out_feature)
        {
            throw new NotImplementedException();
        }

        void IClip.ClipByLayerFileInsideSde(object in_feature, string in_layer_file_path, object clip_feature, string clip_layer_file_path, string out_feature)
        {
            using (ComReleaser releaser = new ComReleaser())
            {
                try
                {
                    Geoprocessor gp = new Geoprocessor();
                    IDataManager _dataManager = new DataManager(this._environment);
                    ESRI.ArcGIS.AnalysisTools.Clip clipTool = new ESRI.ArcGIS.AnalysisTools.Clip();
                   
                    
                    //releaser.ManageLifetime(gp);
                    //releaser.ManageLifetime(clipTool);
                    //IVariantArray param = new VarArrayClass();
                    
                    string inlayer = string.Format("{0}.lyr", in_layer_file_path);
                    string cliplayer = string.Format("{0}.lyr", clip_layer_file_path);
                    //MessageBox.Show(string.Format("line 61 GExtractTool in={0}, clip={1}", inlayer, cliplayer));
                    _dataManager.SaveToLayerFile((ILayer)in_feature, inlayer);
                    _dataManager.SaveToLayerFile((ILayer)clip_feature, cliplayer);

                    //MessageBox.Show(((IFeatureLayer)in_feature).FeatureClass.AliasName);
                    gp.SetEnvironmentValue("workspace", this._environment);
                    clipTool.in_features = inlayer;
                    clipTool.clip_features = cliplayer;
                    clipTool.out_feature_class = out_feature;//string.Format("{0}{1}", this._temFullPath, out_feature);//"C:\\tayninh\\temp\\tempmdb.mdb\\" + out_feature;

                    runTool(gp, clipTool, null);
                }
                catch (Exception err) { MessageBox.Show("loi clip: " + err.ToString()); }
            }
        }

        #endregion

        #region IErase Members

        void IErase.Erase(object inFeature, object eraseFeature)
        {
            throw new NotImplementedException();
        }

        void IErase.EraseInsideSde(object in_feature, object clip_feature, string out_feature)
        {
            throw new NotImplementedException();
        }

        void IErase.EraseByLayerFileInsideSde(object in_feature, string in_layer_file_path, object erase_feature, string erase_layer_file_path, string out_feature)
        {
            //using (ComReleaser releaser = new ComReleaser())
            //{
                try
                {
                    Geoprocessor gp = new Geoprocessor();
                    IDataManager _dataManager = new DataManager(this._environment);
                    ESRI.ArcGIS.AnalysisTools.Erase clipTool = new ESRI.ArcGIS.AnalysisTools.Erase();
                    //releaser.ManageLifetime(gp);
                    //releaser.ManageLifetime(clipTool);
                    //IVariantArray param = new VarArrayClass();

                    string inlayer = string.Format("{0}.lyr", in_layer_file_path);
                    string cliplayer = string.Format("{0}.lyr", erase_layer_file_path);
                    //MessageBox.Show(string.Format("line 105 GExtractTool in={0}, erase={1}", inlayer, cliplayer));
                    _dataManager.SaveToLayerFile((ILayer)in_feature, inlayer);
                    _dataManager.SaveToLayerFile((ILayer)erase_feature, cliplayer);

                    //MessageBox.Show("line 112 GExtractTool, "+((IFeatureLayer)in_feature).FeatureClass.AliasName+", "+this._environment,this._workspace.PathName);
                    gp.SetEnvironmentValue("workspace", this._environment);
                    clipTool.in_features = inlayer;
                    clipTool.erase_features = cliplayer; //@"D:\duong.shp";// cliplayer;
                    clipTool.out_feature_class = out_feature;// string.Format("{0}{1}", "C:\\tn\\temp\\tempmdb.mdb\\", out_feature);//"C:\\tayninh\\temp\\tempmdb.mdb\\" + out_feature;

                    runTool(gp, clipTool, null);
                }
                catch (Exception err) { MessageBox.Show("loi erase: " + err.ToString()); }
            //}
        }

        #endregion
    }
}
