using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace com.g1.arcgis.query
{
    public interface ICopyData
    {
        void Copy();
        void SetView(ICopyDataView view);
        DataTable Data { get; set; }
        event QueryFinishedEventHandler Finished;
        event QueryingEventHandler Copying;
        string FromYear { get; set; }
        string ToYear { get; set; }
    }
}
