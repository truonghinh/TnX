using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.query
{
    public interface IAttributeQuery
    {
        string SqlCommand { get; set; }
        string SelectSqlCommand { get; set; }
        void Excute();
        void ExcuteForDataSet();
        void AddReceiver(IAttributeQueryView receiver);
        event QueryFinishedEventHandler Finished;
    }
}
