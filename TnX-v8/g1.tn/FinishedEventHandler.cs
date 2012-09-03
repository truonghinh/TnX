using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace g1.tn
{
    [Serializable]
    [ComVisible(true)]
    public delegate void FinishedEventHandler(object sender, EventArgs e);
}
