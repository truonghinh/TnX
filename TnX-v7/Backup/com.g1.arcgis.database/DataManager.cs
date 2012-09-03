// File:    TnExToolsDataManager.cs
// Author:  HT
// Created: Saturday, October 22, 2011 12:21:44 AM
// Purpose: Definition of Class TnExToolsDataManager

using System;
using System.Data;
using System.Data.SqlClient;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Windows.Forms;
//using com.g1.GExtensionSpatialTool;
//using com.g1.GMemoryManager;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;
using com.g1.arcgis.connection;
using com.g1.arcgis.geoprocessorTool;
using gov.tn.system;
using gov.tn.TnDatabaseStructure;
//using TnToolBox.TnSql;

//using com.g1.GSdeToolBox.Relationship;

namespace com.g1.arcgis.database
{
   public class DataManager : GeoprocessorAbstract, IDataManager,ICopyFeatures,IAppend,ICopyFeatureClass,IFeatureClassManager
   {
       private ITnSystemTempPath _tempPath;
       //constructor
       private static int num = 0;
       
       public DataManager():this(null,null)
       {
           //ITnExToolsDataManager dataTool = new TnExToolsDataManager();
           //try
           //{
           //    IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
           //    IWorkspaceName workspaceName = workspaceFactory.Create("C:\\tn\\", "temp.mdb", null, 0);
           //    IName name = (IName)workspaceName;
           //    IWorkspace workspace2 = (IWorkspace)name.Open();

           //}
           //catch(Exception e){MessageBox.Show("line 37 --"+e.ToString());}

       }
       public DataManager(string environment):this(null,environment)
       {

       }
       public DataManager(IWorkspace wsp, string env)
       {
           this._environment = env;
           this._workspace = wsp;
           _tempPath = new TnSystemTempPath();
       }

       string IDataManager.TnCreateFeatureLayer(string inFeature, string outLayer, string environment, string dieukien)
      {
          Geoprocessor GP = new Geoprocessor();
          //MessageBox.Show(dieukien);
          // Intialize the MakeFeatureLayer tool
          GP.SetEnvironmentValue("workspace", environment);
          MakeFeatureLayer makefeaturelayer = new MakeFeatureLayer();

          makefeaturelayer.in_features = inFeature;
          makefeaturelayer.out_layer = outLayer;
          runTool(GP, makefeaturelayer, null);
          
          SelectLayerByAttribute SelectByAttribute = new SelectLayerByAttribute();
          GP.ResetEnvironments();

          SelectByAttribute.in_layer_or_view = outLayer;
          SelectByAttribute.selection_type = "NEW_SELECTION";
          SelectByAttribute.where_clause = dieukien;
          runTool(GP, SelectByAttribute, null);


          CopyFeatures copyFeatures = new CopyFeatures();
          
          copyFeatures.in_features = outLayer;

          copyFeatures.out_feature_class = string.Format("{0}", outLayer);//_tempPath.TempFullPath,outLayer);//copiedFeature

          // Set the output Coordinate System environment
          //GP.SetEnvironmentValue("outputCoordinateSystem",
          //@"C:\Program Files\ArcGIS\Coordinate Systems\Projected Coordinate Systems\UTM\Nad 1983\NAD 1983 UTM Zone 21N.prj");

          runTool(GP, copyFeatures, null);
          return string.Format("{0}{1}",_tempPath.TempFullPath,outLayer);
      }

       string IDataManager.TnCreateFeatureLayer(string inFeature, string outLayer, string dieukien)
       {
           //num++;
           Geoprocessor GP = new Geoprocessor();
           //MessageBox.Show(dieukien);
           // Intialize the MakeFeatureLayer tool
           //GP.SetEnvironmentValue("workspace", environment);
           MakeFeatureLayer makefeaturelayer = new MakeFeatureLayer();

           makefeaturelayer.in_features = inFeature;//this.Mem4DataManager.TempFullPath + inFeature;
           makefeaturelayer.out_layer =string.Format("{0}{1}",_tempPath.TempFullPath,outLayer);
           runTool(GP, makefeaturelayer, null);

           SelectLayerByAttribute SelectByAttribute = new SelectLayerByAttribute();
           GP.ResetEnvironments();
           SelectByAttribute.in_layer_or_view =string.Format("{0}{1}",_tempPath.TempFullPath,outLayer);
           SelectByAttribute.selection_type = "NEW_SELECTION";
           SelectByAttribute.where_clause = dieukien;
           runTool(GP, SelectByAttribute, null);


           CopyFeatures copyFeatures = new CopyFeatures();

           copyFeatures.in_features = outLayer;

           copyFeatures.out_feature_class = _tempPath.TempFullPath + "copiedFeature";

           // Set the output Coordinate System environment
           //GP.SetEnvironmentValue("outputCoordinateSystem",
           //@"C:\Program Files\ArcGIS\Coordinate Systems\Projected Coordinate Systems\UTM\Nad 1983\NAD 1983 UTM Zone 21N.prj");

           //runTool(GP, copyFeatures, null);
           GP.Execute(copyFeatures, null);
           return _tempPath.TempFullPath + "copiedFeature";
       }

       void IDataManager.TnCreateFeatureLayer(string inFeature, string outLayer, string dieukien,out string out_featureClass)
       {
           //num++;
           Geoprocessor GP = new Geoprocessor();
           //MessageBox.Show(dieukien);
           // Intialize the MakeFeatureLayer tool
           //GP.SetEnvironmentValue("workspace", environment);
           MakeFeatureLayer makefeaturelayer = new MakeFeatureLayer();
           
           //MessageBox.Show(inFeature);
           makefeaturelayer.in_features = _tempPath.TempFullPath + inFeature; //"C:/tayninh/temp/tempmdb.mdb/tntn_hem_buff_1";
           makefeaturelayer.out_layer = "outlayer";//"C:/tayninh/temp/tempmdb.mdb/ot";//this.Mem4DataManager.TempFullPath+"tn" + outLayer;
           runTool(GP, makefeaturelayer, null);

           SelectLayerByAttribute SelectByAttribute = new SelectLayerByAttribute();
           GP.ResetEnvironments();
           SelectByAttribute.in_layer_or_view = "outlayer";//"C:/tayninh/temp/tempmdb.mdb/ot"; //this.Mem4DataManager.TempFullPath + "tn" + outLayer;
           SelectByAttribute.selection_type = "NEW_SELECTION";
           SelectByAttribute.where_clause = dieukien;
           runTool(GP, SelectByAttribute, null);


           CopyFeatures copyFeatures = new CopyFeatures();

           copyFeatures.in_features = "outlayer";

           copyFeatures.out_feature_class = _tempPath.TempFullPath + "tn" + "cop";// + TnFeatureClassName.HEM_BUFFER_1M_CREATED_FROM_LAYER;

           // Set the output Coordinate System environment
           //GP.SetEnvironmentValue("outputCoordinateSystem",
           //@"C:\Program Files\ArcGIS\Coordinate Systems\Projected Coordinate Systems\UTM\Nad 1983\NAD 1983 UTM Zone 21N.prj");

           //runTool(GP, copyFeatures, null);
           GP.Execute(copyFeatures, null);
           out_featureClass = _tempPath.TempFullPath + "tn" + "cop";// + TnFeatureClassName.HEM_BUFFER_1M_CREATED_FROM_LAYER;
       }

       //IFeatureClass ITnExToolsDataManager.TnOpenFeatureClassFromFileMdb(string pathNoEnd, string name)
       //{
       //    IWorkspaceFactory2 mdbWspf = new AccessWorkspaceFactoryClass();
       //    IWorkspace wsp;
       //    IFeatureWorkspace fwsp;

       //    wsp = mdbWspf.OpenFromFile(pathNoEnd, 0);
       //    fwsp = (IFeatureWorkspace)wsp;
       //    return fwsp.OpenFeatureClass(name);
       //}

       IFeatureClass IDataManager.TnOpenFeatureClassFromFileMdb(params string[] fullpathOrPathandname)
       {
           IWorkspaceFactory2 mdbWspf = new AccessWorkspaceFactoryClass();
           IWorkspace wsp;
           IFeatureWorkspace fwsp;
           int i = fullpathOrPathandname.Length;
           string pathNoEnd = "";
           string name = "";
           int j = 0;
           if (i == 2)
           {
               pathNoEnd = fullpathOrPathandname[0];
               name = fullpathOrPathandname[1];
           }
           else if(i==1)
           {
               for (j = fullpathOrPathandname[0].Length-1; j > 0; j--)
               {
                   if (fullpathOrPathandname[0][j].CompareTo(System.Char.Parse("/"))==0)
                   {
                       break;
                   }
               }
               pathNoEnd = fullpathOrPathandname[0].Substring(0, j);
               name = fullpathOrPathandname[0].Substring(j + 1, fullpathOrPathandname[0].Length - 1 - j);
           }
           
           wsp = mdbWspf.OpenFromFile(pathNoEnd, 0);
           fwsp = (IFeatureWorkspace)wsp;
           return fwsp.OpenFeatureClass(name);
       }

       IFeatureClass IDataManager.TnOpenFeatureClassFromSDE(IWorkspaceEdit workspace, string featureClass)
       {
           IFeatureWorkspace fwsp = (IFeatureWorkspace)workspace;
           return fwsp.OpenFeatureClass(featureClass);
       }

       ITable IDataManager.OpenTableFromSDE(IWorkspaceEdit workspace, string table)
       {
           IFeatureWorkspace fwsp = (IFeatureWorkspace)workspace;
           return fwsp.OpenTable(table);
       }

       bool IDataManager.TnCheckLayerExist(string[,] user_info, string layer_name)
       {
           string strConnection = "";
           string sql = "SELECT * FROM "+DataNameTemplate.SDE_LAYERS+" WHERE table_name='" + layer_name + "'";

           for (int i = 0; i < user_info.Length / 2; i++)
           {
               strConnection += user_info[i, 0] + "=" + user_info[i, 1];
               strConnection += ";";
           }
           SqlConnection conn = new SqlConnection(strConnection);
           SqlCommand cmd = new SqlCommand(sql, conn);
           conn.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           int a = 0;
           while (reader.Read())
           {
               a++;
           }
           if (reader.HasRows)
           {
               //MessageBox.Show(a.ToString());
               return true;
           }
           else
           {
               //MessageBox.Show(reader.HasRows.ToString());
               return false;
           }
       }

       DataSet IDataManager.TnQueryBySQL(int isExpress,string[,] userInfo, string dieukien)
       {
           string connectionString = String.Empty;
           SqlConnection connection;
           SqlCommand command;
           SqlDataAdapter adapter = new SqlDataAdapter();
           DataSet ds = new DataSet();
           
           //int i = 0;
           string sql = null;
           //if (userInfo != null)
           //{
           //    for (int j = 0; j < userInfo.Length / 2; j++)
           //    {
           //        connetionString += userInfo[j, 0] + "=" + userInfo[j, 1];
           //        connetionString += ";";
           //    }
           //}
           //else
           //{
           //    connetionString = GConnectionString.TRUSTED_CONNECT_EXPRESS;
           //}
           SdeConnection conn = new SdeConnection();
           ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
           ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
           ISqlUserInfo sqlUser = sdeUser.GetSqlUserInfo();
           //IUserInfo userInfo = (IUserInfo)sqlUser;
           connectionString = sqlUser.GetConnectionString();
           //connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
           //sql = "select * from tn_thua";
           sql = dieukien;


           try
           {
               connection = new SqlConnection(connectionString);
               connection.Open();
               
               //RootForm.Sqlconnection.Open();
               command = new SqlCommand(sql, connection);
               adapter.SelectCommand = command;
               adapter.Fill(ds);
               adapter.Dispose();
               command.Dispose();
               connection.Close();
               //SQLServerVersion.CallMe.SetCurrentVersion(SQLServerVersion.IS_EXPRESS);
               
               //this.dgvTable.DataSource = ds.Tables[0];


               //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
               //{
               //    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);

               //}
           }
           catch (Exception ex)
           {
               //connectionString = GConnectionString.TRUSTED_CONNECT_NON_EXPRESS;
               //connection = new SqlConnection(connectionString);
               //connection.Open();

               ////RootForm.Sqlconnection.Open();
               //command = new SqlCommand(sql, connection);
               //adapter.SelectCommand = command;
               //adapter.Fill(ds);
               //adapter.Dispose();
               //command.Dispose();
               //connection.Close();
               //SQLServerVersion.CallMe.SetCurrentVersion(SQLServerVersion.NON_EXPRESS);
           }
           return ds;
       }

       bool IDataManager.TnUpdateBySQL(string[,] userInfo, string sql)
       {
           string connetionString = null;
           SqlConnection connection;
           SqlCommand command;
           

           int i = 0;
           string sqlCmd = null;
           for (int j = 0; j < userInfo.Length / 2; j++)
           {
               connetionString += userInfo[j, 0] + "=" + userInfo[j, 1];
               connetionString += ";";
           }
           //connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
           //sql = "select * from tn_thua";
           sqlCmd = sql;
           
           connection = new SqlConnection(connetionString);

           try
           {
               connection.Open();
               command = new SqlCommand(sqlCmd, connection);
               command.ExecuteNonQuery();
               command.Dispose();
               connection.Close();

               //this.dgvTable.DataSource = ds.Tables[0];


               //for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
               //{
               //    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);

               //}
           }
           catch
           {
               return false;
           }
           return true;
       }




       #region ITnExToolsDataManager Members

       //ITnExMemDataManager IDataManager.Mem4DataManager
       //{
       //    get { return null; }
       //}

       #endregion

       #region IDataManager Members


       void IDataManager.CreateLyrFile(object inFeature, string outPath, string environment)
       {
           Geoprocessor GP = new Geoprocessor();
           //MessageBox.Show(dieukien);
           // Intialize the MakeFeatureLayer tool
           GP.SetEnvironmentValue("workspace", environment);
           MakeFeatureLayer makefeaturelayer = new MakeFeatureLayer();

           makefeaturelayer.in_features = inFeature;//this.Mem4DataManager.TempFullPath + inFeature;
           makefeaturelayer.out_layer = "layer1";//outPath;
           runTool(GP, makefeaturelayer, null);

           SaveToLayerFile saveLayer = new SaveToLayerFile();
           saveLayer.in_layer = inFeature;
           saveLayer.out_layer = @"C:\tn\temp\layer3.lyr";
           
           runTool(GP, saveLayer, null);
       }

       #endregion

       #region IDataManager Members


       void IDataManager.SaveToLayerFile(ESRI.ArcGIS.Carto.ILayer layer, string layerFilePath)
       {
           if (layer == null)
           {
               return;
           }
           //create a new LayerFile instance
           ESRI.ArcGIS.Carto.ILayerFile layerFile = new ESRI.ArcGIS.Carto.LayerFileClass();

           //make sure that the layer file name is valid
           if (System.IO.Path.GetExtension(layerFilePath) != ".lyr")
               return;
           if (layerFile.get_IsPresent(layerFilePath))
               System.IO.File.Delete(layerFilePath);

           //create a new layer file
           layerFile.New(layerFilePath);

           //attach the layer file with the actual layer
           layerFile.ReplaceContents(layer);

           //save the layer file
           layerFile.Save();
       }

       #endregion

       #region ICopyFeatures Members

       void ICopyFeatures.AddFields(IFeatureBuffer featureBuffer, IFeature feature)
       {
           // Copy the attributes of the orig feature the new feature
           IRowBuffer rowBuffer = (IRowBuffer)featureBuffer;
           IFields fieldsNew = rowBuffer.Fields;

           IFields fields = feature.Fields;
           for (int i = 0; i <= fields.FieldCount - 1; i++)
           {
               IField field = fields.get_Field(i);
               if ((field.Type != esriFieldType.esriFieldTypeGeometry) &&
                   (field.Type != esriFieldType.esriFieldTypeOID))
               {
                   int intFieldIndex = fieldsNew.FindField(field.Name);
                   if (intFieldIndex != -1)
                   {
                       featureBuffer.set_Value(intFieldIndex, feature.get_Value(i));
                   }
               }
           }
       }

       object ICopyFeatures.Copy(IFeature copiedFeature, IFeatureClass toFeatureClass)
       {
           object id = 0;
           //using (ComReleaser releaser = new ComReleaser())
           //{
           //    _workspaceEdit = (IWorkspaceEdit)_workspace;
           //    _mWorkspaceEdit = (IMultiuserWorkspaceEdit)_workspace;
               //releaser.ManageLifetime(_workspaceEdit);
               //releaser.ManageLifetime(_mWorkspaceEdit);

               //_mWorkspaceEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
               //_workspaceEdit.StartEditOperation();
               
               try
               {
                   IFeatureCursor featureCursorInsert = toFeatureClass.Insert(true);
                   IFeatureBuffer featureBufferInsert = toFeatureClass.CreateFeatureBuffer();
                   //releaser.ManageLifetime(featureBufferInsert);
                   //releaser.ManageLifetime(featureCursorInsert);
                   // Add the original feature's geometry to the feature buffer.
                   //MessageBox.Show(copiedFeature.Shape.ToString());
                   featureBufferInsert.Shape = copiedFeature.Shape;
                   
                   // Add all the original feature's fields to the feature buffer.
                   //((ICopyFeatures)this).AddFields(featureBufferInsert, copiedFeature);
                   // Insert the feature into the cursor.

                   id = featureCursorInsert.InsertFeature(featureBufferInsert);
                   featureCursorInsert.Flush();
                   //_workspaceEdit.StopEditOperation();
                   //_workspaceEdit.StopEditing(true);
               }
               catch (Exception ex) 
               {
                   //MessageBox.Show("line 493 DataManager, ex=" + ex.ToString());
                   //_workspaceEdit.AbortEditOperation();
                   //_workspaceEdit.StopEditing(false);
               }
           //}
               //MessageBox.Show("new id=" + id.ToString());
           return id;
       }

       #endregion

       #region ICopyFeatures Members


       void ICopyFeatures.CopyUseGeoprocessing(object copiedFeature, object toFeatureClass,string env)
       {
           Geoprocessor gp = new Geoprocessor();
           ESRI.ArcGIS.DataManagementTools.MakeFeatureLayer makeFeatureLayer = new MakeFeatureLayer();
          // makeFeatureLayer.in_features = @"C:\tn\temp\tempmdb.mdb\thua_sau50m_clip";
          // makeFeatureLayer.out_layer = "making_layer";
          // runTool(gp, makeFeatureLayer, null);

          // ESRI.ArcGIS.DataManagementTools.SelectLayerByAttribute select = new SelectLayerByAttribute();

          // select.in_layer_or_view = "making_layer";
          //select.selection_type = "NEW_SELECTION";
          //select.where_clause = "OBJECTID>0";
          //runTool(gp, select, null);

           gp.SetEnvironmentValue("workspace", env);
           ESRI.ArcGIS.DataManagementTools.CopyFeatures tool = new CopyFeatures();
           tool.in_features = @"C:\tn\temp\tempmdb.mdb\thua_sau50m_clip";
           string o=string.Format("{0}/{1}",env,"sde.SDE.thua_giadat_2012");
           MessageBox.Show(string.Format("line 483 DataManager {0}", o));
           tool.out_feature_class = o;
           //tool.config_keyword = "WKB_GEOMETRY";
           runTool(gp, tool, null);
           
       }

       #endregion

       #region ICopyFeatures Members


       object ICopyFeatures.CopyFromMdb(IFeature copiedFeature, IFeatureClass toFeatureClass)
       {
           MessageBox.Show(string.Format("line 492 DataManager \n{0}", copiedFeature.get_Value(2)));
           IFeature newfeature = toFeatureClass.CreateFeature();
           var simplifiedFeature = newfeature as IFeatureSimplify;
           IGeometry myGeometry = copiedFeature.ShapeCopy;
           try
           {
               simplifiedFeature.SimplifyGeometry(myGeometry);
               newfeature.Shape = myGeometry;
               newfeature.Store();
           }
           catch (Exception e1) { MessageBox.Show(string.Format("line 501 DataManager \n{0}", e1)); }
           //MessageBox.Show(string.Format("line 503 DataManager \n{0}", newfeature.OID));
           //return newfeature.OID;
           return 1;
       }

       #endregion

       #region ICopyFeatures Members


       object ICopyFeatures.CopyBulkFeature(IFeature copiedFeature, IFeatureClass toFeatureClass)
       {
  // Create a ComReleaser for cursor management.
           using (ComReleaser comReleaser = new ComReleaser())
           {
               // Create and manage a feature buffer.
               IFeatureBuffer featureBuffer = toFeatureClass.CreateFeatureBuffer();
               comReleaser.ManageLifetime(featureBuffer);

               // Create and manage an insert cursor.
               IFeatureCursor featureCursor = toFeatureClass.Insert(true);
               comReleaser.ManageLifetime(featureCursor);
               featureBuffer.Shape = copiedFeature.ShapeCopy;
               featureCursor.InsertFeature(featureBuffer);
               // Attempt to flush the buffer.
               featureCursor.Flush();
               //MessageBox.Show(string.Format("line 529 DataManager \n{0}", featureBuffer.get_Value(0)));
               //return featureBuffer.get_Value(0);
               return 1;
           }
       }

       #endregion

       #region IAppend Members

       void IAppend.Append(IFeatureClass fcSource, IFeatureClass fcTarget)
       {
           Geoprocessor gp = new Geoprocessor();
           ESRI.ArcGIS.DataManagementTools.Append pAppend = new ESRI.ArcGIS.DataManagementTools.Append(fcSource, fcTarget);
           gp.SetEnvironmentValue("workspace",this._environment);
           pAppend.schema_type = "NO_TEST";
           runTool(gp, pAppend, null);
       }

       #endregion

       #region ICopyFeatureClass Members

       object ICopyFeatureClass.RePlace(string name)
       {
           throw new NotImplementedException();
       }

       #endregion

       #region IFeatureClassManager Members

       void IFeatureClassManager.DeleteFeatureClass(IDataset data)
       {
           using (ComReleaser releaser = new ComReleaser())
           {
               _workspaceEdit = (IWorkspaceEdit)_workspace;
               _mWorkspaceEdit = (IMultiuserWorkspaceEdit)_workspace;
               //releaser.ManageLifetime(_workspaceEdit);
               //releaser.ManageLifetime(_mWorkspaceEdit);

               _mWorkspaceEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
               _workspaceEdit.StartEditOperation();

               try
               {
                   data.Delete();
                   _workspaceEdit.StartEditOperation();
                   _workspaceEdit.StopEditing(true);
               }
               catch (Exception ex)
               {
                   _workspaceEdit.AbortEditOperation();
                   _workspaceEdit.StopEditing(false);
               }

           }
           //fcThuaCliped = fw.OpenFeatureClass("thua_sau50m_clip");
           //IDataset ft = (IDataset)fcThuaCliped;
           
           
       }

       void IFeatureClassManager.DeleteFcInSde(string data)
       {
           using (ComReleaser releaser = new ComReleaser())
           {
               _workspaceEdit = (IWorkspaceEdit)_workspace;
               _mWorkspaceEdit = (IMultiuserWorkspaceEdit)_workspace;
               IFeatureWorkspace fw = (IFeatureWorkspace)_workspace;
               IFeatureClass fc=null;
               //releaser.ManageLifetime(_workspaceEdit);
               //releaser.ManageLifetime(_mWorkspaceEdit);
               //releaser.ManageLifetime(fw);
               //releaser.ManageLifetime(fc);
               try
               {
                   fc = fw.OpenFeatureClass(data);
               }
               catch
               {
                   return;
               }
               

               _mWorkspaceEdit.StartMultiuserEditing(esriMultiuserEditSessionMode.esriMESMVersioned);
               _workspaceEdit.StartEditOperation();

               try
               {
                   ((IDataset)fc).Delete();
                   _workspaceEdit.StartEditOperation();
                   _workspaceEdit.StopEditing(true);
               }
               catch (Exception ex)
               {
                   _workspaceEdit.AbortEditOperation();
                   _workspaceEdit.StopEditing(false);
               }

           }
       }

       #endregion

       #region IDataManager Members


       bool IDataManager.LayerExist(string layer_name)
       {
           string sql = "SELECT * FROM " + DataNameTemplate.SDE_LAYERS + " WHERE table_name='" + layer_name + "'";

           SdeConnection conn = new SdeConnection();
           ISdeConnectionInfo sdeConn = conn as ISdeConnectionInfo;
           ISdeUserInfo sdeUser = sdeConn.GetSdeUserInfo();
           ISqlUserInfo sqlUser = sdeUser.GetSqlUserInfo();
           //IUserInfo userInfo = (IUserInfo)sqlUser;
           string connectionString = sqlUser.GetConnectionString();

           SqlConnection sqlConn = new SqlConnection(connectionString);
           SqlCommand cmd = new SqlCommand(sql, sqlConn);
           sqlConn.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           bool result = reader.Read();
           if (result)
           {
               //MessageBox.Show(string.Format("line 667 DataManager true"));
               //sqlConn.Close();
               return true;
           }
           else
           {
               //MessageBox.Show(string.Format("line 667 DataManager false"));
               //sqlConn.Close();
               return false;
           }
           
       }

       #endregion

       #region ICopyFeatures Members


       object ICopyFeatures.CopyWithAllAttribute(IFeature copiedFeature, IFeatureClass toFeatureClass)
       {
           object id = 0;
           try
           {
               IFeatureCursor featureCursorInsert = toFeatureClass.Insert(true);
               IFeatureBuffer featureBufferInsert = toFeatureClass.CreateFeatureBuffer();
               //releaser.ManageLifetime(featureBufferInsert);
               //releaser.ManageLifetime(featureCursorInsert);
               // Add the original feature's geometry to the feature buffer.
               featureBufferInsert.Shape = copiedFeature.Shape;
               // Add all the original feature's fields to the feature buffer.
               //((ICopyFeatures)this).AddFields(featureBufferInsert, copiedFeature);
               // Insert the feature into the cursor.

               

               for (int i = 1; i < copiedFeature.Fields.FieldCount; i++)
               {
                   IFeatureClass sourceFeatureClass = (IFeatureClass)copiedFeature.Class;

                   string fieldName = copiedFeature.Fields.get_Field(i).Name;
                   bool bCondition1 = fieldName == sourceFeatureClass.ShapeFieldName;
                   bool bCondition2 = (sourceFeatureClass.LengthField != null &&
                                       fieldName == sourceFeatureClass.LengthField.Name);
                   bool bCondition3 = (sourceFeatureClass.AreaField != null &&
                                       fieldName == sourceFeatureClass.AreaField.Name);

                   if (!(bCondition1 || bCondition2 || bCondition3))
                   // Don't do shape fields
                   {
                       int myTargetFieldId = toFeatureClass.FindField(fieldName);
                       // Id of field in source feature
                       featureBufferInsert.set_Value(myTargetFieldId, copiedFeature.get_Value(i)); // Copy value
                       
                   }
               }

               id = featureCursorInsert.InsertFeature(featureBufferInsert);
               featureCursorInsert.Flush();
               //_workspaceEdit.StopEditOperation();
               //_workspaceEdit.StopEditing(true);
           }
           catch (Exception ex)
           {
               //_workspaceEdit.AbortEditOperation();
               //_workspaceEdit.StopEditing(false);
           }
           return id;
       }

       #endregion
   }
}
