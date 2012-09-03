using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.g1.arcgis.map;
using com.g1.arcgis.landprice;

namespace com.g1.arcgis.query
{
    public interface IQueryThuaView
    {
        object TypeOfQuery { get; set; }
        void Query();
        void GetResult(SqlDataReader reader);
        void GetResult(DataSet dataset);
        IInfoForQuery Info { get; set; }
        void SetMapView(IMapView mapView);
        void SetLandpriceView(ILandpriceDetailView landpriceView);
    }
}
