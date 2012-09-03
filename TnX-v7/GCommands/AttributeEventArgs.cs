using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCommands
{
    public class AttributeEventArgs:EventArgs
    {
        public object Objectid;
        public object PrimaryKey;
        public AttributeEventArgs() : base() { }
    }
}
