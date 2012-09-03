using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace com.g1.arcgis.database
{
    public interface IReceiverView
    {
        void Load(EnumG1ArcGisTnRecType type);
        void Reload();
        string Sql { get; set; }
        IDictionary<EnumG1ArcGisTnRecType, string> DicSQL { get; }
        IDictionary<EnumG1ArcGisTnRecType, string> DicTableName { get; }
        IDictionary<EnumG1ArcGisTnRecType, string> DicColsName { get; }
        IDictionary<EnumG1ArcGisTnRecType, string> DicColsNameInWhereClause { get; }
        void SetSql(EnumG1ArcGisTnRecType type,string sql);
        void SetTableName(EnumG1ArcGisTnRecType type, string tableName);
        void SetColsName(EnumG1ArcGisTnRecType type, string colsName);
        void SetColsNameInWhereClause(EnumG1ArcGisTnRecType type, string colsName);
        void ReceiveData(SqlDataReader data,EnumG1ArcGisTnRecType type);
    }
}
