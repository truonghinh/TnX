using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.map
{
    public interface ITocContextMenu
    {
        void AddItem(object item, bool beginGroup, int subType);
        void PopupMenu(int X, int Y, int hWndParent);
    }
}
