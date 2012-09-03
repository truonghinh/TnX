using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.database
{
    public interface ISDETableQuery
    {
        List<string> GetLayersAndTables();
        List<string> GetLayers();
        List<string> GetTable();
    }
}
