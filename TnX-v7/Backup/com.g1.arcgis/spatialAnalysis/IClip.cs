using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.spatialAnalysis
{
    public interface IClip
    {
        void Clip(object in_feature, object clip_feature, string out_feature);
        void ClipInsideSde(object in_feature, object clip_feature, string out_feature);
        void ClipByLayerFileInsideSde(object in_feature,string in_layer_file_path, object clip_feature,string clip_layer_file_path, string out_feature);
    }
}
