using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.g1.arcgis.calculation
{
    public abstract class BaseAlgorithm
    {
        protected string _name;
        public abstract void Accept(IVisitor visitor);
    }
}
