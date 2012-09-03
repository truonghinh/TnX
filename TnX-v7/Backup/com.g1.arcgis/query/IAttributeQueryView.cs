using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.g1.arcgis.map;
using com.g1.arcgis.landprice;

namespace com.g1.arcgis.query
{
    public interface IAttributeQueryView
    {
        string SqlCommand { get; set; }
        void Excute();
        void ReceiveResult(DataSet data);
        void ReceiveResult(SqlDataReader data,EnumTypeOfResult type);
        string SelectSqlCommand { get; set; }
        void ExcuteForDataSet();
        void UpdateThuaInfo();
        void SetMapView(IMapView mapView);
        void SetDetailView(ILandpriceView calcView, ILandpriceView publicView);
    }
}
