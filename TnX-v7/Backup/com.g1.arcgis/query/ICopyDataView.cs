using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.g1.arcgis.edit;

namespace com.g1.arcgis.query
{
    public interface ICopyDataView
    {
        void Show();
        void ShowDialog();
        void Close();
        void Copy();
        DataTable Data{get;set;}
        void Update();
        IEditTableView Editor { get; set; }
        void Paste(int rowHandle);
        void Paste(int rowHandle,params ColValPair[] modify);
        string FromYear { get; set; }
        string ToYear { get; set; }
        
    }
}
