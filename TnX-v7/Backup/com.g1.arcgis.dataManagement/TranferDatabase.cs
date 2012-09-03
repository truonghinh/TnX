using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.GeoDatabaseDistributed;
using ESRI.ArcGIS.esriSystem;

namespace com.g1.arcgis.dataManagement
{
    public class TranferDatabase
    {
        public static void ImportFromXml(IWorkspace targetWorkspace, string sourcePath, bool schemaOnly)
        {
            // Open the target File geodatabase and create a name object for it.
            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
            //IWorkspace workspace = workspaceFactory.OpenFromFile("ImportXmlDoc.gdb", 0);
            IDataset workspaceDataset = (IDataset)targetWorkspace;
            IName workspaceName = workspaceDataset.FullName;

            // Create a GdbImporter and use it to generate name mappings.
            IGdbXmlImport gdbXmlImport = new GdbImporterClass();
            IEnumNameMapping enumNameMapping = null;
            Boolean conflictsFound = gdbXmlImport.GenerateNameMapping(sourcePath,
              targetWorkspace, out enumNameMapping);

            // Check for conflicts.
            if (conflictsFound)
            {
                // Iterate through each name mapping.
                INameMapping nameMapping = null;
                enumNameMapping.Reset();
                while ((nameMapping = enumNameMapping.Next()) != null)
                {
                    // Resolve the mapping's conflict (if there is one).
                    if (nameMapping.NameConflicts)
                    {
                        nameMapping.TargetName = nameMapping.GetSuggestedName(workspaceName);
                    }

                    // See if the mapping's children have conflicts.
                    IEnumNameMapping childEnumNameMapping = nameMapping.Children;
                    if (childEnumNameMapping != null)
                    {
                        childEnumNameMapping.Reset();

                        // Iterate through each child mapping.
                        INameMapping childNameMapping = null;
                        while ((childNameMapping = childEnumNameMapping.Next()) != null)
                        {
                            if (childNameMapping.NameConflicts)
                            {
                                childNameMapping.TargetName = childNameMapping.GetSuggestedName
                                  (workspaceName);
                            }
                        }
                    }
                }
            }

            // Import the workspace document, including both schema and data.
            gdbXmlImport.ImportWorkspace(sourcePath, enumNameMapping, targetWorkspace, schemaOnly);
        }

        public static void ImportFromXml(IWorkspace targetWorkspace, string sourcePath, bool schemaOnly,bool boquaLopCungTen)
        {
            // Open the target File geodatabase and create a name object for it.
            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
            //IWorkspace workspace = workspaceFactory.OpenFromFile("ImportXmlDoc.gdb", 0);
            IDataset workspaceDataset = (IDataset)targetWorkspace;
            IName workspaceName = workspaceDataset.FullName;

            // Create a GdbImporter and use it to generate name mappings.
            IGdbXmlImport gdbXmlImport = new GdbImporterClass();
            IEnumNameMapping enumNameMapping = null;
            Boolean conflictsFound = gdbXmlImport.GenerateNameMapping(sourcePath,
              targetWorkspace, out enumNameMapping);

            // Check for conflicts.
            if (conflictsFound)
            {
                // Iterate through each name mapping.
                INameMapping nameMapping = null;
                enumNameMapping.Reset();
                while ((nameMapping = enumNameMapping.Next()) != null)
                {
                    // Resolve the mapping's conflict (if there is one).
                    if (nameMapping.NameConflicts)
                    {
                        nameMapping.TargetName = nameMapping.GetSuggestedName(workspaceName);
                    }

                    // See if the mapping's children have conflicts.
                    IEnumNameMapping childEnumNameMapping = nameMapping.Children;
                    if (childEnumNameMapping != null)
                    {
                        childEnumNameMapping.Reset();

                        // Iterate through each child mapping.
                        INameMapping childNameMapping = null;
                        while ((childNameMapping = childEnumNameMapping.Next()) != null)
                        {
                            if (childNameMapping.NameConflicts)
                            {
                                childNameMapping.TargetName = childNameMapping.GetSuggestedName
                                  (workspaceName);
                            }
                        }
                    }
                }
            }

            // Import the workspace document, including both schema and data.
            gdbXmlImport.ImportWorkspace(sourcePath, enumNameMapping, targetWorkspace, schemaOnly);
        }

        public static void TranferBetweenGeodatabase(string featureClass, string targetPath, string sourcePath)
        {
            // Create new workspace name objects.
            IWorkspaceName sourceWorkspaceName = new WorkspaceNameClass();
            IWorkspaceName targetWorkspaceName = new WorkspaceNameClass();
            IName targetName = (IName)targetWorkspaceName;

            // Set the workspace name properties.
            sourceWorkspaceName.PathName = @sourcePath;//"C:\arcgis\ArcTutor\BuildingaGeodatabase\Montgomery.gdb";
            sourceWorkspaceName.WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory";
            targetWorkspaceName.PathName = @targetPath;//"PartialMontgomery.gdb";
            targetWorkspaceName.WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory";

            // Create a name object for the source feature class.
            IFeatureClassName featureClassName = new FeatureClassNameClass();

            // Set the featureClassName properties.
            IDatasetName sourceDatasetName = (IDatasetName)featureClassName;
            sourceDatasetName.WorkspaceName = sourceWorkspaceName;
            sourceDatasetName.Name = featureClass;//"Blocks";
            IName sourceName = (IName)sourceDatasetName;

            // Create an enumerator for source datasets.
            IEnumName sourceEnumName = new NamesEnumeratorClass();
            IEnumNameEdit sourceEnumNameEdit = (IEnumNameEdit)sourceEnumName;

            // Add the name object for the source class to the enumerator.
            sourceEnumNameEdit.Add(sourceName);

            // Create a GeoDBDataTransfer object and a null name mapping enumerator.
            IGeoDBDataTransfer geoDBDataTransfer = new GeoDBDataTransferClass();
            IEnumNameMapping enumNameMapping = null;

            // Use the data transfer object to create a name mapping enumerator.
            Boolean conflictsFound = geoDBDataTransfer.GenerateNameMapping(sourceEnumName,
              targetName, out enumNameMapping);
            enumNameMapping.Reset();

            // Check for conflicts.
            if (conflictsFound)
            {
                // Iterate through each name mapping.
                INameMapping nameMapping = null;
                while ((nameMapping = enumNameMapping.Next()) != null)
                {
                    // Resolve the mapping's conflict (if there is one).
                    if (nameMapping.NameConflicts)
                    {
                        nameMapping.TargetName = nameMapping.GetSuggestedName(targetName);
                    }

                    // See if the mapping's children have conflicts.
                    IEnumNameMapping childEnumNameMapping = nameMapping.Children;
                    if (childEnumNameMapping != null)
                    {
                        childEnumNameMapping.Reset();

                        // Iterate through each child mapping.
                        INameMapping childNameMapping = null;
                        while ((childNameMapping = childEnumNameMapping.Next()) != null)
                        {
                            if (childNameMapping.NameConflicts)
                            {
                                childNameMapping.TargetName = childNameMapping.GetSuggestedName
                                  (targetName);
                            }
                        }
                    }
                }
            }

            // Start the transfer.
            geoDBDataTransfer.Transfer(enumNameMapping, targetName);
        }

        public static void ExportToXml(IWorkspace sourceWorkspace, string targetPath)
        {
            // Open the source geodatabase and create a name object for it.
            IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
            //IWorkspace workspace = workspaceFactory.OpenFromFile(databaseName, 0);
            IDataset workspaceDataset = (IDataset)sourceWorkspace;
            IName workspaceName = workspaceDataset.FullName;

            // Retrieve the first feature dataset from the workspace.
            IEnumDatasetName enumDatasetName = sourceWorkspace.get_DatasetNames
              (esriDatasetType.esriDTFeatureDataset);
            enumDatasetName.Reset();
            IName featureDatasetName = (IName)enumDatasetName.Next();
            if (featureDatasetName == null)
            {
                throw new Exception(
                  "No feature datasets exist in the specified geodatabase.");
            }

            // Create a new names enumerator and add the feature dataset name.
            IEnumNameEdit enumNameEdit = new NamesEnumeratorClass();
            enumNameEdit.Add(featureDatasetName);
            IEnumName enumName = (IEnumName)enumNameEdit;

            // Create a GeoDBDataTransfer object and create a name mapping.
            IGeoDBDataTransfer geoDBDataTransfer = new GeoDBDataTransferClass();
            IEnumNameMapping enumNameMapping = null;
            geoDBDataTransfer.GenerateNameMapping(enumName, workspaceName, out enumNameMapping);

            // Create an exporter and export the dataset with binary geometry, not compressed,
            // and including metadata.
            IGdbXmlExport gdbXmlExport = new GdbExporterClass();
            gdbXmlExport.ExportDatasets(enumNameMapping, targetPath, true, false, true);
        }

        public static void ExportToXml(IWorkspace sourceWorkspace, string targetPath,bool binaryGeometry,bool compressed,bool retriveMetadata)
        {
            // Open the source geodatabase and create a name object for it.
            IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
            //IWorkspace workspace = workspaceFactory.OpenFromFile(databaseName, 0);
            IDataset workspaceDataset = (IDataset)sourceWorkspace;
            IName workspaceName = workspaceDataset.FullName;

            // Retrieve the first feature dataset from the workspace.
            IEnumDatasetName enumDatasetName = sourceWorkspace.get_DatasetNames
              (esriDatasetType.esriDTFeatureDataset);
            enumDatasetName.Reset();
            IName featureDatasetName = (IName)enumDatasetName.Next();
            if (featureDatasetName == null)
            {
                throw new Exception(
                  "No feature datasets exist in the specified geodatabase.");
            }

            // Create a new names enumerator and add the feature dataset name.
            IEnumNameEdit enumNameEdit = new NamesEnumeratorClass();
            enumNameEdit.Add(featureDatasetName);
            IEnumName enumName = (IEnumName)enumNameEdit;

            // Create a GeoDBDataTransfer object and create a name mapping.
            IGeoDBDataTransfer geoDBDataTransfer = new GeoDBDataTransferClass();
            IEnumNameMapping enumNameMapping = null;
            geoDBDataTransfer.GenerateNameMapping(enumName, workspaceName, out enumNameMapping);

            // Create an exporter and export the dataset with binary geometry, not compressed,
            // and including metadata.
            IGdbXmlExport gdbXmlExport = new GdbExporterClass();
            gdbXmlExport.ExportDatasets(enumNameMapping, targetPath, binaryGeometry, compressed, retriveMetadata);
        }
    }
}
