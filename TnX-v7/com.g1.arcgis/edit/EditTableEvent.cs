﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.edit
{
    public class EditTableEvent : EventArgs
    {
        public bool IsEditing;
        
        public EditTableEvent()
        {
            IsEditing = false;
        }
    }
}
