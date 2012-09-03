using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace g1.tn.param
{
    public interface ISaveConfigView
    {
        void ShowDialog();
        void Close();
        string FileName { get; set; }
        void SetConfigView(IConfigView configView);
        string CurrentYear { get; set; }
        string NewYear { get; set; }
    }
}
