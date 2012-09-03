using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;

namespace com.g1.arcgis.query
{
    public interface IJoinView
    {
        void Perform();
        string LayerName { get; set; }
        string TableName { get; set; }
        esriJoinType Type { get; set; }
        string JoinFieldOnLayer { get; set; }
        string JoinFieldOnTable { get; set; }
        esriRelCardinality Cardinality { get; set; }
        IFeatureLayer FeatureLayer { get; set; }
        ITable Table { get; set; }
        int IndexLayer { get; set; }
        string FilterClause { get; set; }
    }
}
