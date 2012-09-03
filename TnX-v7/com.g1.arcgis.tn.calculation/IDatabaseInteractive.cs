using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gov.tn.TnDatabaseStructure;

namespace com.g1.arcgis.tn.calculation
{
    public interface IDatabaseInteractive
    {
        ITnFeatureClassName TnFcName { get; set; }
        ITnTableName TnTbName { get; set; }
    }
}
