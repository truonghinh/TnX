using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.database
{
    public interface ILoader
    {
        void Load(EnumG1ArcGisTnRecType type);
        void Reload();
        string Sql { get; set; }
        void AddReceiver(IReceiverView view);
        event LoaderFinishedEventHandler Finished;
        IDictionary<EnumG1ArcGisTnRecType, string> DicTableName { get; set; }
    }
}
