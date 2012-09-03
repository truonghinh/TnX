using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace com.g1.arcgis.query
{
    public interface IAttributeQueryController
    {
        void Excute();
        void ExcuteForDataSet();
        void ReceiveResult(DataSet data);
        void ReceiveResult(SqlDataReader data);
    }
}
