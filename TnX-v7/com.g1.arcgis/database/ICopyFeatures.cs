using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;

namespace com.g1.arcgis.database
{
    public interface ICopyFeatures
    {
        void AddFields(IFeatureBuffer featureBuffer, IFeature feature);
        object Copy(IFeature copiedFeature, IFeatureClass toFeatureClass);
        void CopyUseGeoprocessing(object copiedFeature, object toFeatureClass,string env);
        object CopyFromMdb(IFeature copiedFeature, IFeatureClass toFeatureClass);
        object CopyBulkFeature(IFeature copiedFeature, IFeatureClass toFeatureClass);
        object CopyWithAllAttribute(IFeature copiedFeature, IFeatureClass toFeatureClass);
    }
}
