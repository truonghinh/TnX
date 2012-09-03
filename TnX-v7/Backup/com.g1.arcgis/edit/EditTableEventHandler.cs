using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace com.g1.arcgis.edit
{
    [Serializable]
    [ComVisible(true)]
    public delegate void EditTableEventHandler(object sender, EditTableEvent e);
}
