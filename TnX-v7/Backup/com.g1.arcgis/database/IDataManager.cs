// File:    ITnExToolsDataManager.cs
// Author:  HT
// Created: Saturday, October 22, 2011 12:22:54 AM
// Purpose: Definition of Interface ITnExToolsDataManager

using System;
using ESRI.ArcGIS.Geodatabase;
using System.Data;
using ESRI.ArcGIS.Carto;
//using com.g1.GMemoryManager;


namespace com.g1.arcgis.database
{
    public interface IDataManager
    {
        //ITnExMemDataManager Mem4DataManager { get; }
        string TnCreateFeatureLayer(string inFeature, string outLayer, string environment, string dieukien);
        string TnCreateFeatureLayer(string inFeature, string outLayer, string dieukien);
        void TnCreateFeatureLayer(string inFeature, string outLayer, string dieukien, out string out_featureClass);
        //IFeatureClass TnOpenFeatureClassFromFileMdb(string pathNoEnd, string name);
        IFeatureClass TnOpenFeatureClassFromFileMdb(params string[] fullpathOrPathandname);
        IFeatureClass TnOpenFeatureClassFromSDE(IWorkspaceEdit workspace, string featureClass);
        ITable OpenTableFromSDE(IWorkspaceEdit workspace, string table);
        DataSet TnQueryBySQL(int isExpress,string[,] userInfo,string dieukien);
        
        bool TnUpdateBySQL(string[,] userInfo, string sql);

        bool TnCheckLayerExist(string[,] user_info, string layer_name);
        void CreateLyrFile(object inFeature, string outPath,string environment);
        void SaveToLayerFile(ILayer layer, string layerFilePath);
        bool LayerExist(string layer_name);
        
    }
}
