using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.spatialAnalysis
{
    public interface IBuffer
    {
        void BufferInsideSde(string in_features, string out_feature, object distance);
    }
}
